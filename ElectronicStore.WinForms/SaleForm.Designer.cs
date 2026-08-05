namespace ElectronicStore.WinForms
{
    partial class SaleForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            pnlContent = new Panel();
            pnlSalesCard = new Panel();
            dgvSales = new DataGridView();
            colViewDetail = new DataGridViewButtonColumn();
            pnlToolbar = new Panel();
            txtSearchSale = new TextBox();
            label1 = new Label();
            btnCreateSale = new Button();
            btnLoadSales = new Button();
            lblGridTitle = new Label();
            dtpSaleDate = new DateTimePicker();
            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlSalesCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSales).BeginInit();
            pnlToolbar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1100, 94);
            pnlHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Location = new Point(30, 55);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(420, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Review transactions and open voucher details";
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(28, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(250, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Sales History";
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(pnlSalesCard);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 94);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(24);
            pnlContent.Size = new Size(1100, 606);
            pnlContent.TabIndex = 1;
            // 
            // pnlSalesCard
            // 
            pnlSalesCard.Controls.Add(dgvSales);
            pnlSalesCard.Controls.Add(pnlToolbar);
            pnlSalesCard.Dock = DockStyle.Fill;
            pnlSalesCard.Location = new Point(24, 24);
            pnlSalesCard.Name = "pnlSalesCard";
            pnlSalesCard.Padding = new Padding(1);
            pnlSalesCard.Size = new Size(1052, 558);
            pnlSalesCard.TabIndex = 0;
            // 
            // dgvSales
            // 
            dgvSales.Columns.AddRange(new DataGridViewColumn[] { colViewDetail });
            dgvSales.Dock = DockStyle.Fill;
            dgvSales.Location = new Point(1, 77);
            dgvSales.Name = "dgvSales";
            dgvSales.ReadOnly = true;
            dgvSales.Size = new Size(1050, 480);
            dgvSales.TabIndex = 1;
            dgvSales.CellContentClick += dgvSales_CellContentClick;
            // 
            // colViewDetail
            // 
            colViewDetail.FillWeight = 70F;
            colViewDetail.HeaderText = "Action";
            colViewDetail.Name = "colViewDetail";
            colViewDetail.ReadOnly = true;
            colViewDetail.Text = "View Detail";
            colViewDetail.UseColumnTextForButtonValue = true;
            // 
            // pnlToolbar
            // 
            pnlToolbar.Controls.Add(dtpSaleDate);
            pnlToolbar.Controls.Add(txtSearchSale);
            pnlToolbar.Controls.Add(label1);
            pnlToolbar.Controls.Add(btnCreateSale);
            pnlToolbar.Controls.Add(btnLoadSales);
            pnlToolbar.Controls.Add(lblGridTitle);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(1, 1);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(1050, 76);
            pnlToolbar.TabIndex = 0;
            // 
            // txtSearchSale
            // 
            txtSearchSale.Location = new Point(236, 35);
            txtSearchSale.Name = "txtSearchSale";
            txtSearchSale.Size = new Size(185, 23);
            txtSearchSale.TabIndex = 4;
            txtSearchSale.TextChanged += txtSearchSale_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(161, 43);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 3;
            label1.Text = "Search Sale ";
            // 
            // btnCreateSale
            // 
            btnCreateSale.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreateSale.Location = new Point(882, 18);
            btnCreateSale.Name = "btnCreateSale";
            btnCreateSale.Size = new Size(148, 40);
            btnCreateSale.TabIndex = 2;
            btnCreateSale.Text = "+ Create Sale";
            btnCreateSale.Click += btnCreateSale_Click;
            // 
            // btnLoadSales
            // 
            btnLoadSales.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLoadSales.Location = new Point(726, 18);
            btnLoadSales.Name = "btnLoadSales";
            btnLoadSales.Size = new Size(142, 40);
            btnLoadSales.TabIndex = 1;
            btnLoadSales.Text = "Refresh Sales";
            btnLoadSales.Click += btnLoadSales_Click;
            // 
            // lblGridTitle
            // 
            lblGridTitle.AutoSize = true;
            lblGridTitle.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            lblGridTitle.Location = new Point(20, 24);
            lblGridTitle.Name = "lblGridTitle";
            lblGridTitle.Size = new Size(115, 25);
            lblGridTitle.TabIndex = 0;
            lblGridTitle.Text = "Transactions";
            // 
            // dtpSaleDate
            // 
            dtpSaleDate.Format = DateTimePickerFormat.Short;
            dtpSaleDate.Location = new Point(438, 35);
            dtpSaleDate.Name = "dtpSaleDate";
            dtpSaleDate.ShowCheckBox = true;
            dtpSaleDate.Size = new Size(200, 23);
            dtpSaleDate.TabIndex = 5;
            dtpSaleDate.ValueChanged += dtpSaleDate_ValueChanged;
            // 
            // SaleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 700);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Name = "SaleForm";
            Text = "Electronic Store - Sales History";
            Load += SaleForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlSalesCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSales).EndInit();
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel pnlContent;
        private Panel pnlSalesCard;
        private Panel pnlToolbar;
        private Label lblGridTitle;
        private Button btnLoadSales;
        private Button btnCreateSale;
        private DataGridView dgvSales;
        private DataGridViewButtonColumn colViewDetail;
        private TextBox txtSearchSale;
        private Label label1;
        private DateTimePicker dtpSaleDate;
    }
}
