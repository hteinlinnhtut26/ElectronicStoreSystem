namespace ElectronicStore.WinForms
{
    partial class Form1
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
            btnSale = new Button();
            lblSubtitle = new Label();
            lblTitle = new Label();
            pnlContent = new Panel();
            pnlProductCard = new Panel();
            btnAddProduct = new Button();
            txtStockQuantity = new TextBox();
            lblStock = new Label();
            txtPrice = new TextBox();
            lblPrice = new Label();
            txtProductName = new TextBox();
            lblProductName = new Label();
            lblFormHint = new Label();
            lblFormTitle = new Label();
            pnlGridCard = new Panel();
            dgvProducts = new DataGridView();
            colEdit = new DataGridViewButtonColumn();
            colDelete = new DataGridViewButtonColumn();
            pnlGridToolbar = new Panel();
            lblSearch = new Label();
            txtSearchProduct = new TextBox();
            btnLoadProducts = new Button();
            lblGridTitle = new Label();
            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlProductCard.SuspendLayout();
            pnlGridCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            pnlGridToolbar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(btnSale);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1184, 94);
            pnlHeader.TabIndex = 0;
            // 
            // btnSale
            // 
            btnSale.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSale.Location = new Point(1022, 28);
            btnSale.Name = "btnSale";
            btnSale.Size = new Size(130, 40);
            btnSale.TabIndex = 2;
            btnSale.Text = "Sales";
            btnSale.Click += btnSale_Click;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Location = new Point(30, 55);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(430, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Manage product catalog, stock levels and pricing";
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(28, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(300, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Product Management";
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(pnlProductCard);
            pnlContent.Controls.Add(pnlGridCard);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 94);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(24);
            pnlContent.Size = new Size(1184, 667);
            pnlContent.TabIndex = 1;
            // 
            // pnlProductCard
            // 
            pnlProductCard.Controls.Add(btnAddProduct);
            pnlProductCard.Controls.Add(txtStockQuantity);
            pnlProductCard.Controls.Add(lblStock);
            pnlProductCard.Controls.Add(txtPrice);
            pnlProductCard.Controls.Add(lblPrice);
            pnlProductCard.Controls.Add(txtProductName);
            pnlProductCard.Controls.Add(lblProductName);
            pnlProductCard.Controls.Add(lblFormHint);
            pnlProductCard.Controls.Add(lblFormTitle);
            pnlProductCard.Dock = DockStyle.Right;
            pnlProductCard.Location = new Point(820, 24);
            pnlProductCard.Name = "pnlProductCard";
            pnlProductCard.Size = new Size(340, 619);
            pnlProductCard.TabIndex = 1;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnAddProduct.Location = new Point(24, 337);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(292, 42);
            btnAddProduct.TabIndex = 8;
            btnAddProduct.Text = "Add Product";
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // txtStockQuantity
            // 
            txtStockQuantity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtStockQuantity.Location = new Point(24, 282);
            txtStockQuantity.Name = "txtStockQuantity";
            txtStockQuantity.Size = new Size(292, 23);
            txtStockQuantity.TabIndex = 7;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(24, 255);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(85, 15);
            lblStock.TabIndex = 6;
            lblStock.Text = "Stock Quantity";
            // 
            // txtPrice
            // 
            txtPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPrice.Location = new Point(24, 213);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(292, 23);
            txtPrice.TabIndex = 5;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(24, 186);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(33, 15);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "Price";
            // 
            // txtProductName
            // 
            txtProductName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtProductName.Location = new Point(24, 144);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(292, 23);
            txtProductName.TabIndex = 3;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(24, 117);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(84, 15);
            lblProductName.TabIndex = 2;
            lblProductName.Text = "Product Name";
            // 
            // lblFormHint
            // 
            lblFormHint.AutoSize = true;
            lblFormHint.Location = new Point(24, 70);
            lblFormHint.Name = "lblFormHint";
            lblFormHint.Size = new Size(183, 15);
            lblFormHint.TabIndex = 1;
            lblFormHint.Text = "Enter product information below.";
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblFormTitle.Location = new Point(22, 25);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(170, 25);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "Add / Edit Product";
            // 
            // pnlGridCard
            // 
            pnlGridCard.Controls.Add(dgvProducts);
            pnlGridCard.Controls.Add(pnlGridToolbar);
            pnlGridCard.Dock = DockStyle.Fill;
            pnlGridCard.Location = new Point(24, 24);
            pnlGridCard.Margin = new Padding(0, 0, 18, 0);
            pnlGridCard.Name = "pnlGridCard";
            pnlGridCard.Padding = new Padding(1);
            pnlGridCard.Size = new Size(1136, 619);
            pnlGridCard.TabIndex = 0;
            // 
            // dgvProducts
            // 
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { colEdit, colDelete });
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(1, 69);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.Size = new Size(1134, 549);
            dgvProducts.TabIndex = 1;
            dgvProducts.CellContentClick += dgvProducts_CellContentClick;
            // 
            // colEdit
            // 
            colEdit.FillWeight = 55F;
            colEdit.HeaderText = "Edit";
            colEdit.Name = "colEdit";
            colEdit.ReadOnly = true;
            colEdit.Text = "Edit";
            colEdit.UseColumnTextForButtonValue = true;
            // 
            // colDelete
            // 
            colDelete.FillWeight = 65F;
            colDelete.HeaderText = "Delete";
            colDelete.Name = "colDelete";
            colDelete.ReadOnly = true;
            colDelete.Text = "Delete";
            colDelete.UseColumnTextForButtonValue = true;
            // 
            // pnlGridToolbar
            // 
            pnlGridToolbar.Controls.Add(lblSearch);
            pnlGridToolbar.Controls.Add(txtSearchProduct);
            pnlGridToolbar.Controls.Add(btnLoadProducts);
            pnlGridToolbar.Controls.Add(lblGridTitle);
            pnlGridToolbar.Dock = DockStyle.Top;
            pnlGridToolbar.Location = new Point(1, 1);
            pnlGridToolbar.Name = "pnlGridToolbar";
            pnlGridToolbar.Size = new Size(1134, 68);
            pnlGridToolbar.TabIndex = 0;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(456, 28);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(87, 15);
            lblSearch.TabIndex = 2;
            lblSearch.Text = "Search Product";
            // 
            // txtSearchProduct
            // 
            txtSearchProduct.Location = new Point(571, 20);
            txtSearchProduct.Name = "txtSearchProduct";
            txtSearchProduct.Size = new Size(199, 23);
            txtSearchProduct.TabIndex = 3;
            txtSearchProduct.TextChanged += txtSearchProduct_TextChanged;
            // 
            // btnLoadProducts
            // 
            btnLoadProducts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLoadProducts.Location = new Point(975, 15);
            btnLoadProducts.Name = "btnLoadProducts";
            btnLoadProducts.Size = new Size(140, 38);
            btnLoadProducts.TabIndex = 1;
            btnLoadProducts.Text = "Refresh Products";
            btnLoadProducts.Click += btnLoadProducts_Click;
            // 
            // lblGridTitle
            // 
            lblGridTitle.AutoSize = true;
            lblGridTitle.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            lblGridTitle.Location = new Point(18, 20);
            lblGridTitle.Name = "lblGridTitle";
            lblGridTitle.Size = new Size(146, 25);
            lblGridTitle.TabIndex = 0;
            lblGridTitle.Text = "Product Catalog";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 761);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Name = "Form1";
            Text = "Electronic Store - Products";
            Load += Form1_Load;
            pnlHeader.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlProductCard.ResumeLayout(false);
            pnlProductCard.PerformLayout();
            pnlGridCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            pnlGridToolbar.ResumeLayout(false);
            pnlGridToolbar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Button btnSale;
        private Panel pnlContent;
        private Panel pnlGridCard;
        private Panel pnlGridToolbar;
        private Label lblGridTitle;
        private Button btnLoadProducts;
        private DataGridView dgvProducts;
        private DataGridViewButtonColumn colEdit;
        private DataGridViewButtonColumn colDelete;
        private Panel pnlProductCard;
        private Label lblFormTitle;
        private Label lblFormHint;
        private Label lblProductName;
        private TextBox txtProductName;
        private Label lblPrice;
        private TextBox txtPrice;
        private Label lblStock;
        private TextBox txtStockQuantity;
        private Button btnAddProduct;
        private TextBox txtSearchProduct;
        private Label lblSearch;
    }
}
