using ElectronicStore.Domain.Models.Product;
using ElectronicStore.Domain.Models.Sale;
using ElectronicStore.WinForms.Clients;
using System.ComponentModel;

namespace ElectronicStore.WinForms;

public partial class SaleCreateForm : Form
{
    private readonly ProductClient _productClient;
    private readonly SaleClient _saleClient;

    private readonly BindingList<SaleCartItemModel> _cartItems = new();
    private readonly BindingSource _cartBindingSource = new();

    public SaleCreateForm()
    {
        InitializeComponent();

        _productClient = new ProductClient();
        _saleClient = new SaleClient();

        ApplyTheme();
        SetupCartGrid();

        dgvSaleItems.CellContentClick -=
            dgvSaleItems_CellContentClick;

        dgvSaleItems.CellContentClick +=
            dgvSaleItems_CellContentClick;
    }

    private void ApplyTheme()
    {
        UITheme.ApplyFormTheme(this);

        UITheme.StyleHeaderPanel(
            pnlHeader,
            lblTitle,
            lblSubtitle);

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

    private void SetupCartGrid()
    {
        dgvSaleItems.AutoGenerateColumns = false;
        dgvSaleItems.AllowUserToAddRows = false;
        dgvSaleItems.AllowUserToDeleteRows = false;
        dgvSaleItems.ReadOnly = true;
        dgvSaleItems.MultiSelect = false;
        dgvSaleItems.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        dgvSaleItems.Columns.Clear();

        var removeColumn = new DataGridViewButtonColumn
        {
            Name = "colRemove",
            HeaderText = "Action",
            Text = "Remove",
            UseColumnTextForButtonValue = true,

            AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
            Width = 70,

            FlatStyle = FlatStyle.Flat
        };

        var productIdColumn = new DataGridViewTextBoxColumn
        {
            Name = "colProductId",
            HeaderText = "Product ID",
            DataPropertyName = "ProductId",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            FillWeight = 15
        };

        var productNameColumn = new DataGridViewTextBoxColumn
        {
            Name = "colProductName",
            HeaderText = "Product Name",
            DataPropertyName = "ProductName",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            FillWeight = 30
        };

        var quantityColumn = new DataGridViewTextBoxColumn
        {
            Name = "colQuantity",
            HeaderText = "Quantity",
            DataPropertyName = "Quantity",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            FillWeight = 15
        };

        var unitPriceColumn = new DataGridViewTextBoxColumn
        {
            Name = "colUnitPrice",
            HeaderText = "Unit Price",
            DataPropertyName = "UnitPrice",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            FillWeight = 20
        };

        var lineTotalColumn = new DataGridViewTextBoxColumn
        {
            Name = "colLineTotal",
            HeaderText = "Line Total",
            DataPropertyName = "LineTotal",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            FillWeight = 20
        };

        lineTotalColumn.DefaultCellStyle.Format = "N0";

        dgvSaleItems.Columns.Add(removeColumn);
        dgvSaleItems.Columns.Add(productIdColumn);
        dgvSaleItems.Columns.Add(productNameColumn);
        dgvSaleItems.Columns.Add(quantityColumn);
        dgvSaleItems.Columns.Add(unitPriceColumn);
        dgvSaleItems.Columns.Add(lineTotalColumn);

        _cartBindingSource.DataSource = _cartItems;
        dgvSaleItems.DataSource = _cartBindingSource;

        dgvSaleItems.Columns["colRemove"].AutoSizeMode =
            DataGridViewAutoSizeColumnMode.None;

        dgvSaleItems.Columns["colRemove"].Width = 70;

        UpdateCartTotal();
    }

    private void SaleCreateForm_Load(
        object sender,
        EventArgs e)
    {
        LoadProducts();

        txtQuantity.Text = "1";
        txtPaidAmount.Clear();

        UpdateCartTotal();
    }

    private void LoadProducts()
    {
        var response = _productClient.GetProducts();

        if (!response.IsSuccess)
        {
            MessageBox.Show(
                response.Message,
                "Product Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        cboProduct.DataSource = response.Products;
        cboProduct.DisplayMember = "ProductName";
        cboProduct.ValueMember = "ProductId";
        cboProduct.SelectedIndex = -1;
    }

    private void btnAddItem_Click(
        object sender,
        EventArgs e)
    {
        if (cboProduct.SelectedItem == null)
        {
            MessageBox.Show(
                "Please select a product.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            cboProduct.Focus();
            return;
        }

        if (!int.TryParse(
            txtQuantity.Text,
            out int quantity))
        {
            MessageBox.Show(
                "Please enter a valid quantity.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtQuantity.Focus();
            return;
        }

        if (quantity <= 0)
        {
            MessageBox.Show(
                "Quantity must be greater than zero.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtQuantity.Focus();
            return;
        }

        var product =
            (ProductListItemModel)cboProduct.SelectedItem;

        var existingItem = _cartItems
            .FirstOrDefault(
                x => x.ProductId == product.ProductId);

        int requestedQuantity = quantity;

        if (existingItem != null)
        {
            requestedQuantity += existingItem.Quantity;
        }

        if (requestedQuantity > product.StockQuantity)
        {
            MessageBox.Show(
                $"Insufficient stock. Available stock: " +
                $"{product.StockQuantity}.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtQuantity.Focus();
            return;
        }

        if (existingItem == null)
        {
            _cartItems.Add(new SaleCartItemModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Quantity = quantity,
                UnitPrice = product.Price,
                LineTotal = product.Price * quantity
            });
        }
        else
        {
            existingItem.Quantity = requestedQuantity;

            existingItem.LineTotal =
                existingItem.UnitPrice *
                existingItem.Quantity;

            _cartBindingSource.ResetBindings(false);
        }

        UpdateCartTotal();

        cboProduct.SelectedIndex = -1;
        txtQuantity.Text = "1";

        cboProduct.Focus();
    }

    private void dgvSaleItems_CellContentClick(
        object sender,
        DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0)
        {
            return;
        }

        if (dgvSaleItems.Columns[e.ColumnIndex].Name
            != "colRemove")
        {
            return;
        }

        var cartItem =
            dgvSaleItems.Rows[e.RowIndex].DataBoundItem
            as SaleCartItemModel;

        if (cartItem == null)
        {
            return;
        }

        var confirmResult = MessageBox.Show(
            $"Remove {cartItem.ProductName} from cart?",
            "Confirm Remove",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirmResult != DialogResult.Yes)
        {
            return;
        }

        _cartItems.Remove(cartItem);

        UpdateCartTotal();
    }

    private void UpdateCartTotal()
    {
        decimal total =
            _cartItems.Sum(x => x.LineTotal);

        lblCartTotalValue.Text =
            total.ToString("N2");
    }

    private void btnCreateSale_Click(
        object sender,
        EventArgs e)
    {
        if (_cartItems.Count == 0)
        {
            MessageBox.Show(
                "Please add at least one item.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            cboProduct.Focus();
            return;
        }

        if (!decimal.TryParse(
            txtPaidAmount.Text,
            out decimal paidAmount))
        {
            MessageBox.Show(
                "Please enter a valid paid amount.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtPaidAmount.Focus();
            return;
        }

        decimal totalAmount =
            _cartItems.Sum(x => x.LineTotal);

        if (paidAmount < totalAmount)
        {
            MessageBox.Show(
                $"Paid amount is not enough.\n" +
                $"Total Amount: {totalAmount:N0}",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtPaidAmount.Focus();
            return;
        }

        var request = new SaleCreateRequestModel
        {
            PaidAmount = paidAmount
        };

        foreach (var item in _cartItems)
        {
            request.Items.Add(
                new SaleItemRequestModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                });
        }

        var response =
            _saleClient.CreateSale(request);

        if (!response.IsSuccess)
        {
            MessageBox.Show(
                response.Message,
                "Sale Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

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

        UpdateCartTotal();

        cboProduct.SelectedIndex = -1;
        txtQuantity.Text = "1";
        txtPaidAmount.Clear();

        LoadProducts();

        cboProduct.Focus();
    }

    public class SaleCartItemModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }
            = string.Empty;

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal LineTotal { get; set; }
    }
}