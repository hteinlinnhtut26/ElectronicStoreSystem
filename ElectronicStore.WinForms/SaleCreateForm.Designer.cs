namespace ElectronicStore.WinForms
{
    partial class SaleCreateForm
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
            pnlCartCard = new Panel();
            dgvSaleItems = new DataGridView();
            colRemove = new DataGridViewButtonColumn();
            pnlCheckout = new Panel();
            btnCreateSale = new Button();
            txtPaidAmount = new TextBox();
            lblPaidAmount = new Label();
            lblCartTotalValue = new Label();
            lblCartTotal = new Label();
            lblCartTitle = new Label();
            pnlItemCard = new Panel();
            btnAddItem = new Button();
            txtQuantity = new TextBox();
            lblQuantity = new Label();
            cboProduct = new ComboBox();
            lblProduct = new Label();
            lblItemTitle = new Label();
            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlCartCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSaleItems).BeginInit();
            pnlCheckout.SuspendLayout();
            pnlItemCard.SuspendLayout();
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
            lblSubtitle.Size = new Size(440, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Add products to the cart and complete checkout";
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(28, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(220, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "New Sale";
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(pnlCartCard);
            pnlContent.Controls.Add(pnlItemCard);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 94);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(24, 20, 24, 18);
            pnlContent.Size = new Size(1100, 606);
            pnlContent.TabIndex = 1;
            // 
            // pnlCartCard
            // 
            pnlCartCard.Controls.Add(dgvSaleItems);
            pnlCartCard.Controls.Add(pnlCheckout);
            pnlCartCard.Controls.Add(lblCartTitle);
            pnlCartCard.Dock = DockStyle.Fill;
            pnlCartCard.Location = new Point(24, 138);
            pnlCartCard.Name = "pnlCartCard";
            pnlCartCard.Padding = new Padding(22);
            pnlCartCard.Size = new Size(1052, 450);
            pnlCartCard.TabIndex = 1;
            // 
            // dgvSaleItems
            // 
            dgvSaleItems.Columns.AddRange(new DataGridViewColumn[] { colRemove });
            dgvSaleItems.Dock = DockStyle.Fill;
            dgvSaleItems.Location = new Point(22, 61);
            dgvSaleItems.Name = "dgvSaleItems";
            dgvSaleItems.ReadOnly = true;
            dgvSaleItems.Size = new Size(1008, 285);
            dgvSaleItems.TabIndex = 1;
            dgvSaleItems.CellContentClick += dgvSaleItems_CellContentClick;
            // 
            // colRemove
            // 
            colRemove.HeaderText = "Delete";
            colRemove.Name = "colRemove";
            colRemove.ReadOnly = true;
            colRemove.Text = "Delete";
            // 
            // pnlCheckout
            // 
            pnlCheckout.Controls.Add(btnCreateSale);
            pnlCheckout.Controls.Add(txtPaidAmount);
            pnlCheckout.Controls.Add(lblPaidAmount);
            pnlCheckout.Controls.Add(lblCartTotalValue);
            pnlCheckout.Controls.Add(lblCartTotal);
            pnlCheckout.Dock = DockStyle.Bottom;
            pnlCheckout.Location = new Point(22, 346);
            pnlCheckout.Name = "pnlCheckout";
            pnlCheckout.Padding = new Padding(18, 14, 18, 14);
            pnlCheckout.Size = new Size(1008, 82);
            pnlCheckout.TabIndex = 2;
            // 
            // btnCreateSale
            // 
            btnCreateSale.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreateSale.Location = new Point(842, 20);
            btnCreateSale.Name = "btnCreateSale";
            btnCreateSale.Size = new Size(148, 42);
            btnCreateSale.TabIndex = 4;
            btnCreateSale.Text = "Complete Sale";
            btnCreateSale.Click += btnCreateSale_Click;
            // 
            // txtPaidAmount
            // 
            txtPaidAmount.Location = new Point(535, 28);
            txtPaidAmount.Name = "txtPaidAmount";
            txtPaidAmount.Size = new Size(170, 23);
            txtPaidAmount.TabIndex = 3;
            // 
            // lblPaidAmount
            // 
            lblPaidAmount.AutoSize = true;
            lblPaidAmount.Location = new Point(432, 31);
            lblPaidAmount.Name = "lblPaidAmount";
            lblPaidAmount.Size = new Size(77, 15);
            lblPaidAmount.TabIndex = 2;
            lblPaidAmount.Text = "Paid Amount";
            // 
            // lblCartTotalValue
            // 
            lblCartTotalValue.AutoSize = true;
            lblCartTotalValue.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            lblCartTotalValue.Location = new Point(116, 22);
            lblCartTotalValue.Name = "lblCartTotalValue";
            lblCartTotalValue.Size = new Size(50, 28);
            lblCartTotalValue.TabIndex = 1;
            lblCartTotalValue.Text = "0.00";
            // 
            // lblCartTotal
            // 
            lblCartTotal.AutoSize = true;
            lblCartTotal.Location = new Point(18, 30);
            lblCartTotal.Name = "lblCartTotal";
            lblCartTotal.Size = new Size(57, 15);
            lblCartTotal.TabIndex = 0;
            lblCartTotal.Text = "Cart Total";
            // 
            // lblCartTitle
            // 
            lblCartTitle.AutoSize = true;
            lblCartTitle.Dock = DockStyle.Top;
            lblCartTitle.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            lblCartTitle.Location = new Point(22, 22);
            lblCartTitle.Name = "lblCartTitle";
            lblCartTitle.Padding = new Padding(0, 0, 0, 14);
            lblCartTitle.Size = new Size(98, 39);
            lblCartTitle.TabIndex = 0;
            lblCartTitle.Text = "Cart Items";
            // 
            // pnlItemCard
            // 
            pnlItemCard.Controls.Add(btnAddItem);
            pnlItemCard.Controls.Add(txtQuantity);
            pnlItemCard.Controls.Add(lblQuantity);
            pnlItemCard.Controls.Add(cboProduct);
            pnlItemCard.Controls.Add(lblProduct);
            pnlItemCard.Controls.Add(lblItemTitle);
            pnlItemCard.Dock = DockStyle.Top;
            pnlItemCard.Location = new Point(24, 20);
            pnlItemCard.Name = "pnlItemCard";
            pnlItemCard.Size = new Size(1052, 118);
            pnlItemCard.TabIndex = 0;
            // 
            // btnAddItem
            // 
            btnAddItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddItem.Location = new Point(841, 54);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(185, 40);
            btnAddItem.TabIndex = 5;
            btnAddItem.Text = "+ Add Item to Cart";
            btnAddItem.Click += btnAddItem_Click;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(649, 61);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(150, 23);
            txtQuantity.TabIndex = 4;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(649, 37);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(53, 15);
            lblQuantity.TabIndex = 3;
            lblQuantity.Text = "Quantity";
            // 
            // cboProduct
            // 
            cboProduct.Location = new Point(22, 61);
            cboProduct.Name = "cboProduct";
            cboProduct.Size = new Size(590, 23);
            cboProduct.TabIndex = 2;
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Location = new Point(22, 37);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(49, 15);
            lblProduct.TabIndex = 1;
            lblProduct.Text = "Product";
            // 
            // lblItemTitle
            // 
            lblItemTitle.AutoSize = true;
            lblItemTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblItemTitle.Location = new Point(20, 8);
            lblItemTitle.Name = "lblItemTitle";
            lblItemTitle.Size = new Size(100, 21);
            lblItemTitle.TabIndex = 0;
            lblItemTitle.Text = "Add an Item";
            // 
            // SaleCreateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 700);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Name = "SaleCreateForm";
            Text = "Electronic Store - New Sale";
            Load += SaleCreateForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlCartCard.ResumeLayout(false);
            pnlCartCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSaleItems).EndInit();
            pnlCheckout.ResumeLayout(false);
            pnlCheckout.PerformLayout();
            pnlItemCard.ResumeLayout(false);
            pnlItemCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel pnlContent;
        private Panel pnlItemCard;
        private Label lblItemTitle;
        private Label lblProduct;
        private ComboBox cboProduct;
        private Label lblQuantity;
        private TextBox txtQuantity;
        private Button btnAddItem;
        private Panel pnlCartCard;
        private Label lblCartTitle;
        private DataGridView dgvSaleItems;
        private Panel pnlCheckout;
        private Label lblCartTotal;
        private Label lblCartTotalValue;
        private Label lblPaidAmount;
        private TextBox txtPaidAmount;
        private Button btnCreateSale;
        private DataGridViewButtonColumn colRemove;
    }
}
