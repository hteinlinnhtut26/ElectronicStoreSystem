using ElectronicStore.Domain.Models.Sale;
using ElectronicStore.WinForms.Clients;

namespace ElectronicStore.WinForms;

public partial class SaleForm : Form
{
    private readonly SaleClient _saleClient;

    public SaleForm()
    {
        InitializeComponent();

        _saleClient = new SaleClient();

        UITheme.ApplyFormTheme(this);
        UITheme.StyleHeaderPanel(pnlHeader, lblTitle, lblSubtitle);
        UITheme.StyleCardPanel(pnlSalesCard);
        UITheme.StyleDataGridView(dgvSales);
        UITheme.StyleSecondaryButton(btnLoadSales);
        UITheme.StylePrimaryButton(btnCreateSale);
    }

    private void btnLoadSales_Click(object sender, EventArgs e)
    {
        LoadSaleList();
    }

    private void LoadSaleList()
    {
        var response = _saleClient.GetSales();

        if (!response.IsSuccess)
        {
            MessageBox.Show(response.Message);
            return;
        }

        dgvSales.DataSource = response.Sales;
    }

    private void dgvSales_CellContentClick(
    object sender,
    DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
        {
            return;
        }

        if (dgvSales.Columns[e.ColumnIndex].Name == "colViewDetail")
        {
            var row = dgvSales.Rows[e.RowIndex];

            int saleId =
                Convert.ToInt32(row.Cells["SaleId"].Value);

            var response =
                _saleClient.GetSaleById(saleId);

            if (!response.IsSuccess)
            {
                MessageBox.Show(response.Message);
                return;
            }

            string detail = "";

            detail += $"Voucher No: {response.VoucherNo}\n";
            detail += $"Sale Date: {response.SaleDate:yyyy-MM-dd HH:mm}\n";
            detail += $"Total: {response.TotalAmount:N0}\n";
            detail += $"Paid: {response.PaidAmount:N0}\n";
            detail += $"Change: {response.ChangeAmount:N0}\n\n";
            detail += "Items:\n";

            foreach (var item in response.Items)
            {
                detail +=
                    $"{item.ProductName} | " +
                    $"Qty: {item.Quantity} | " +
                    $"Price: {item.UnitPrice:N0} | " +
                    $"Total: {item.LineTotal:N0}\n";
            }

            MessageBox.Show(
                detail,
                "Sale Detail",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }

    private void btnCreateSale_Click(object sender, EventArgs e)
    {
        var saleCreateForm = new SaleCreateForm();

        saleCreateForm.ShowDialog();

        LoadSaleList();
    }

    private void SaleForm_Load(object sender, EventArgs e)
    {
        LoadSaleList();
    }

    private void txtSearchSale_TextChanged(
    object sender,
    EventArgs e)
    {
        SearchSales();
    }

    private void dtpSaleDate_ValueChanged(object sender, EventArgs e)
    {
        SearchSales();

    }

    private void SearchSales()
    {
        var model = new SaleSearchRequestModel
        {
            KeyWord = txtSearchSale.Text.Trim(),

            SaleDate = dtpSaleDate.Checked
                ? dtpSaleDate.Value.Date
                : null
        };

        var response =
            _saleClient.SaleSearch(model);

        if (!response.IsSuccess)
        {
            MessageBox.Show(
                response.Message,
                "Search Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        dgvSales.DataSource = null;
        dgvSales.DataSource = response.Sales;
    }
}