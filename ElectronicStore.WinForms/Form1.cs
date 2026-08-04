using ElectronicStore.Domain.Models.Product;
using ElectronicStore.WinForms.Clients;

namespace ElectronicStore.WinForms;

public partial class Form1 : Form
{
    private readonly ProductClient _productClient;
    public Form1()
    {
        InitializeComponent();

        _productClient = new ProductClient();

        UITheme.ApplyFormTheme(this);
        UITheme.StyleHeaderPanel(pnlHeader, lblTitle, lblSubtitle);
        UITheme.StyleCardPanel(pnlGridCard);
        UITheme.StyleCardPanel(pnlProductCard);
        UITheme.StyleDataGridView(dgvProducts);
        UITheme.StylePrimaryButton(btnAddProduct);
        UITheme.StyleSecondaryButton(btnLoadProducts);
        UITheme.StyleSecondaryButton(btnSale);
        UITheme.StyleTextBox(txtProductName);
        UITheme.StyleTextBox(txtPrice);
        UITheme.StyleTextBox(txtStockQuantity);
        UITheme.StyleTextBox(txtSearchProduct);
        lblFormHint.ForeColor = UITheme.TextMuted;
    }

    private void btnLoadProducts_Click(object sender, EventArgs e)
    {
        var response = _productClient.GetProducts();

        if (!response.IsSuccess)
        {
            MessageBox.Show(response.Message);
            return;
        }

        dgvProducts.DataSource = response.Products;
    }

    private void btnAddProduct_Click(object sender, EventArgs e)
    {
        string productName = txtProductName.Text.Trim();

        if (string.IsNullOrWhiteSpace(productName))
        {
            MessageBox.Show(
                "Please enter product name.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtProductName.Focus();
            return;
        }

        if (!decimal.TryParse(
            txtPrice.Text,
            out decimal price))
        {
            MessageBox.Show(
                "Please enter a valid price.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtPrice.Focus();
            return;
        }

        if (price <= 0)
        {
            MessageBox.Show(
                "Price must be greater than zero.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtPrice.Focus();
            return;
        }

        if (!int.TryParse(
            txtStockQuantity.Text,
            out int stockQuantity))
        {
            MessageBox.Show(
                "Please enter a valid stock quantity.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtStockQuantity.Focus();
            return;
        }

        if (stockQuantity < 0)
        {
            MessageBox.Show(
                "Stock quantity cannot be negative.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtStockQuantity.Focus();
            return;
        }

        if (txtProductName.Tag == null)
        {
            var request = new ProductCreateRequestModel
            {
                ProductName = productName,
                Price = price,
                StockQuantity = stockQuantity
            };

            var response =
                _productClient.CreateProduct(request);

            MessageBox.Show(response.Message);

            if (!response.IsSuccess)
            {
                return;
            }
        }
        else
        {
            int productId =
                Convert.ToInt32(txtProductName.Tag);

            var request = new ProductUpdateRequestModel
            {
                ProductId = productId,
                ProductName = productName,
                Price = price,
                StockQuantity = stockQuantity
            };

            var response =
                _productClient.UpdateProduct(request);

            MessageBox.Show(response.Message);

            if (!response.IsSuccess)
            {
                return;
            }
        }

        txtProductName.Clear();
        txtPrice.Clear();
        txtStockQuantity.Clear();

        txtProductName.Tag = null;
        btnAddProduct.Text = "Add Product";

        LoadProductList();

        txtProductName.Focus();
    }

    private void LoadProductList()
    {
        var response =
            _productClient.GetProducts();

        if (!response.IsSuccess)
        {
            MessageBox.Show(
                response.Message,
                "Connection Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            dgvProducts.DataSource = null;
            return;
        }

        dgvProducts.DataSource = null;
        dgvProducts.DataSource = response.Products;
    }

    private void dgvProducts_CellContentClick(
    object sender,
    DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
        {
            return;
        }

        if (dgvProducts.Columns[e.ColumnIndex].Name == "colEdit")
        {
            var row = dgvProducts.Rows[e.RowIndex];

            int productId =
                Convert.ToInt32(row.Cells["ProductId"].Value);

            txtProductName.Text =
                Convert.ToString(row.Cells["ProductName"].Value)
                ?? string.Empty;

            txtPrice.Text =
                Convert.ToString(row.Cells["Price"].Value)
                ?? string.Empty;

            txtStockQuantity.Text =
                Convert.ToString(row.Cells["StockQuantity"].Value)
                ?? string.Empty;

            txtProductName.Tag = productId;

            btnAddProduct.Text = "Update Product";
        }

        if (dgvProducts.Columns[e.ColumnIndex].Name == "colDelete")
        {
            var row = dgvProducts.Rows[e.RowIndex];

            int productId =
                Convert.ToInt32(row.Cells["ProductId"].Value);

            string productName =
                Convert.ToString(row.Cells["ProductName"].Value)
                ?? string.Empty;

            var confirmResult = MessageBox.Show(
                $"Are you sure you want to delete {productName}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                var response =
                    _productClient.DeleteProduct(productId);

                MessageBox.Show(response.Message);

                if (response.IsSuccess)
                {
                    LoadProductList();
                }
            }
        }

    }

    private void Form1_Load(object sender, EventArgs e)
    {
        LoadProductList();
    }

    private void btnSale_Click(object sender, EventArgs e)
    {
        var saleForm = new SaleForm();
        saleForm.ShowDialog();
    }

    private void txtSearchProduct_TextChanged(
    object sender,
    EventArgs e)
    {
        var model = new ProductSearchRequestModel
        {
            Keyword = txtSearchProduct.Text.Trim()
        };

        var response =
            _productClient.SearchProduct(model);

        if (!response.IsSuccess)
        {
            MessageBox.Show(
                response.Message,
                "Search Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        dgvProducts.DataSource = null;
        dgvProducts.DataSource = response.Products;
    }
}