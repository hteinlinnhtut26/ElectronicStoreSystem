using ElectronicStore.Domain.Models.Product;
using ElectronicStore.Domain.Models.Sale;
using ElectronicStore.WinForms.Clients;

namespace ElectronicStore.WinForms;

public partial class SaleCreateForm : Form
{
    private readonly ProductClient _productClient;
    private readonly SaleClient _saleClient;
    private readonly List<SaleCartItemModel> _cartItems = new();

    public SaleCreateForm()
    {
        InitializeComponent();

        _productClient = new ProductClient();
        _saleClient = new SaleClient();

        UITheme.ApplyFormTheme(this);
        UITheme.StyleHeaderPanel(pnlHeader, lblTitle, lblSubtitle);
        UITheme.StyleCardPanel(pnlItemCard);
        UITheme.StyleCardPanel(pnlCartCard);
        UITheme.StyleCardPanel(pnlCheckout);
        UITheme.StyleDataGridView(dgvSaleItems);
        UITheme.StyleComboBox(cboProduct);
        UITheme.StyleTextBox(txtQuantity);
        UITheme.StyleTextBox(txtPaidAmount);
        UITheme.StyleSuccessButton(btnAddItem);
        UITheme.StylePrimaryButton(btnCreateSale);
    }

    private void SaleCreateForm_Load(object sender, EventArgs e)
    {
        LoadProducts();
    }

    private void LoadProducts()
    {
        var response = _productClient.GetProducts();

        if (!response.IsSuccess)
        {
            MessageBox.Show(response.Message);
            return;
        }

        cboProduct.DataSource = response.Products;
        cboProduct.DisplayMember = "ProductName";
        cboProduct.ValueMember = "ProductId";
        cboProduct.SelectedIndex = -1;
    }

    public class SaleCartItemModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal LineTotal { get; set; }
    }

    private void btnAddItem_Click(object sender, EventArgs e)
    {
        if (cboProduct.SelectedItem == null)
        {
            MessageBox.Show("Please select a product.");
            return;
        }

        int quantity = Convert.ToInt32(txtQuantity.Text);

        if (quantity <= 0)
        {
            MessageBox.Show("Quantity must be greater than zero.");
            return;
        }

        var product =
            (ProductListItemModel)cboProduct.SelectedItem;

        var cartItem = new SaleCartItemModel
        {
            ProductId = product.ProductId,
            ProductName = product.ProductName,
            Quantity = quantity,
            UnitPrice = product.Price,
            LineTotal = product.Price * quantity
        };

        _cartItems.Add(cartItem);

        dgvSaleItems.DataSource = null;
        dgvSaleItems.DataSource = _cartItems;
        UITheme.StyleDataGridView(dgvSaleItems);
        UpdateCartTotal();

        cboProduct.SelectedIndex = -1;
        txtQuantity.Clear();
    }

    private void UpdateCartTotal()
    {
        decimal total = _cartItems.Sum(x => x.LineTotal);
        lblCartTotalValue.Text = total.ToString("N2");
    }

    private void btnCreateSale_Click(object sender, EventArgs e)
    {
        if (_cartItems.Count == 0)
        {
            MessageBox.Show("Please add at least one item.");
            return;
        }

        if (!decimal.TryParse(txtPaidAmount.Text, out decimal paidAmount))
        {
            MessageBox.Show("Please enter a valid paid amount.");
            return;
        }

        var request = new SaleCreateRequestModel
        {
            PaidAmount = paidAmount
        };

        foreach (var item in _cartItems)
        {
            request.Items.Add(new SaleItemRequestModel
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity
            });
        }

        var response = _saleClient.CreateSale(request);

        MessageBox.Show(response.Message);

        if (!response.IsSuccess)
        {
            return;
        }

        MessageBox.Show(
            $"Voucher No: {response.VoucherNo}\n" +
            $"Total Amount: {response.TotalAmount:N0}\n" +
            $"Paid Amount: {response.PaidAmount:N0}\n" +
            $"Change Amount: {response.ChangeAmount:N0}",
            "Sale Created",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        _cartItems.Clear();

        dgvSaleItems.DataSource = null;
        dgvSaleItems.DataSource = _cartItems;
        UITheme.StyleDataGridView(dgvSaleItems);
        UpdateCartTotal();

        cboProduct.SelectedIndex = -1;
        txtQuantity.Clear();
        txtPaidAmount.Clear();

        LoadProducts();
    }
}