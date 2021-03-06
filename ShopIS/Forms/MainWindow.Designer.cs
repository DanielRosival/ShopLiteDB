﻿namespace ShopIS
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabCustomers = new System.Windows.Forms.TabPage();
            this.dataGridCustomers = new System.Windows.Forms.DataGridView();
            this.CustomersID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridCustomersDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabProducts = new System.Windows.Forms.TabPage();
            this.dataGridProducts = new System.Windows.Forms.DataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabOrders = new System.Windows.Forms.TabPage();
            this.dataGridOrders = new System.Windows.Forms.DataGridView();
            this.IdOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Products = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteOrder = new System.Windows.Forms.DataGridViewButtonColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabControl.SuspendLayout();
            this.tabCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomers)).BeginInit();
            this.tabProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProducts)).BeginInit();
            this.tabOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrders)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabCustomers);
            this.mainTabControl.Controls.Add(this.tabProducts);
            this.mainTabControl.Controls.Add(this.tabOrders);
            this.mainTabControl.Location = new System.Drawing.Point(12, 27);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(775, 440);
            this.mainTabControl.TabIndex = 0;
            // 
            // tabCustomers
            // 
            this.tabCustomers.Controls.Add(this.dataGridCustomers);
            this.tabCustomers.Location = new System.Drawing.Point(4, 22);
            this.tabCustomers.Name = "tabCustomers";
            this.tabCustomers.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustomers.Size = new System.Drawing.Size(767, 414);
            this.tabCustomers.TabIndex = 0;
            this.tabCustomers.Text = "Zakaznici";
            this.tabCustomers.UseVisualStyleBackColor = true;
            // 
            // dataGridCustomers
            // 
            this.dataGridCustomers.AllowUserToAddRows = false;
            this.dataGridCustomers.AllowUserToDeleteRows = false;
            this.dataGridCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomersID,
            this.CustomerName,
            this.dataGridCustomersDelete});
            this.dataGridCustomers.Location = new System.Drawing.Point(3, 3);
            this.dataGridCustomers.Name = "dataGridCustomers";
            this.dataGridCustomers.Size = new System.Drawing.Size(758, 408);
            this.dataGridCustomers.TabIndex = 0;
            this.dataGridCustomers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridCustomers_CellContentClick);
            this.dataGridCustomers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridCustomers_CellDoubleClick);
            // 
            // CustomersID
            // 
            this.CustomersID.HeaderText = "Id";
            this.CustomersID.Name = "CustomersID";
            this.CustomersID.ReadOnly = true;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "Meno zakaznika";
            this.CustomerName.Name = "CustomerName";
            // 
            // dataGridCustomersDelete
            // 
            this.dataGridCustomersDelete.HeaderText = "Vymazat";
            this.dataGridCustomersDelete.Name = "dataGridCustomersDelete";
            this.dataGridCustomersDelete.Text = "Delete";
            this.dataGridCustomersDelete.UseColumnTextForButtonValue = true;
            // 
            // tabProducts
            // 
            this.tabProducts.Controls.Add(this.dataGridProducts);
            this.tabProducts.Location = new System.Drawing.Point(4, 22);
            this.tabProducts.Name = "tabProducts";
            this.tabProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tabProducts.Size = new System.Drawing.Size(767, 414);
            this.tabProducts.TabIndex = 1;
            this.tabProducts.Text = "Produkty";
            this.tabProducts.UseVisualStyleBackColor = true;
            // 
            // dataGridProducts
            // 
            this.dataGridProducts.AllowUserToAddRows = false;
            this.dataGridProducts.AllowUserToDeleteRows = false;
            this.dataGridProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductId,
            this.Price,
            this.Description,
            this.DeleteProduct});
            this.dataGridProducts.Location = new System.Drawing.Point(4, 4);
            this.dataGridProducts.Name = "dataGridProducts";
            this.dataGridProducts.Size = new System.Drawing.Size(757, 404);
            this.dataGridProducts.TabIndex = 0;
            this.dataGridProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProducts_CellContentClick);
            this.dataGridProducts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProducts_CellDoubleClick);
            // 
            // ProductId
            // 
            this.ProductId.HeaderText = "Id";
            this.ProductId.Name = "ProductId";
            this.ProductId.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.HeaderText = "Cena";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.HeaderText = "Opis";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // DeleteProduct
            // 
            this.DeleteProduct.HeaderText = "Delete";
            this.DeleteProduct.Name = "DeleteProduct";
            this.DeleteProduct.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeleteProduct.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DeleteProduct.Text = "Delete";
            this.DeleteProduct.UseColumnTextForButtonValue = true;
            // 
            // tabOrders
            // 
            this.tabOrders.Controls.Add(this.dataGridOrders);
            this.tabOrders.Location = new System.Drawing.Point(4, 22);
            this.tabOrders.Name = "tabOrders";
            this.tabOrders.Size = new System.Drawing.Size(767, 414);
            this.tabOrders.TabIndex = 2;
            this.tabOrders.Text = "Objednavky";
            this.tabOrders.UseVisualStyleBackColor = true;
            // 
            // dataGridOrders
            // 
            this.dataGridOrders.AllowUserToAddRows = false;
            this.dataGridOrders.AllowUserToDeleteRows = false;
            this.dataGridOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdOrder,
            this.OrderDate,
            this.Customer,
            this.Products,
            this.DeleteOrder});
            this.dataGridOrders.Location = new System.Drawing.Point(4, 4);
            this.dataGridOrders.Name = "dataGridOrders";
            this.dataGridOrders.ReadOnly = true;
            this.dataGridOrders.Size = new System.Drawing.Size(760, 407);
            this.dataGridOrders.TabIndex = 0;
            this.dataGridOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridOrders_CellContentClick);
            this.dataGridOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridOrders_CellContentDoubleClick);
            // 
            // IdOrder
            // 
            this.IdOrder.HeaderText = "Id";
            this.IdOrder.Name = "IdOrder";
            this.IdOrder.ReadOnly = true;
            // 
            // OrderDate
            // 
            this.OrderDate.HeaderText = "Datum objednavky";
            this.OrderDate.Name = "OrderDate";
            this.OrderDate.ReadOnly = true;
            // 
            // Customer
            // 
            this.Customer.HeaderText = "Zakaznik";
            this.Customer.Name = "Customer";
            this.Customer.ReadOnly = true;
            // 
            // Products
            // 
            this.Products.HeaderText = "Produkty";
            this.Products.Name = "Products";
            this.Products.ReadOnly = true;
            // 
            // DeleteOrder
            // 
            this.DeleteOrder.HeaderText = "Delete";
            this.DeleteOrder.Name = "DeleteOrder";
            this.DeleteOrder.ReadOnly = true;
            this.DeleteOrder.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeleteOrder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DeleteOrder.Text = "Delete";
            this.DeleteOrder.UseColumnTextForButtonValue = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCustomerToolStripMenuItem,
            this.newProductToolStripMenuItem,
            this.newOrderToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // newCustomerToolStripMenuItem
            // 
            this.newCustomerToolStripMenuItem.Name = "newCustomerToolStripMenuItem";
            this.newCustomerToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.newCustomerToolStripMenuItem.Text = "New customer";
            this.newCustomerToolStripMenuItem.Click += new System.EventHandler(this.newCustomerToolStripMenuItem_Click);
            // 
            // newProductToolStripMenuItem
            // 
            this.newProductToolStripMenuItem.Name = "newProductToolStripMenuItem";
            this.newProductToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.newProductToolStripMenuItem.Text = "New product";
            this.newProductToolStripMenuItem.Click += new System.EventHandler(this.newProductToolStripMenuItem_Click);
            // 
            // newOrderToolStripMenuItem
            // 
            this.newOrderToolStripMenuItem.Name = "newOrderToolStripMenuItem";
            this.newOrderToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.newOrderToolStripMenuItem.Text = "New order";
            this.newOrderToolStripMenuItem.Click += new System.EventHandler(this.newOrderToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 493);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Shop information system";
            this.mainTabControl.ResumeLayout(false);
            this.tabCustomers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomers)).EndInit();
            this.tabProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProducts)).EndInit();
            this.tabOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrders)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabCustomers;
        private System.Windows.Forms.DataGridView dataGridCustomers;
        private System.Windows.Forms.TabPage tabProducts;
        private System.Windows.Forms.DataGridView dataGridProducts;
        private System.Windows.Forms.TabPage tabOrders;
        private System.Windows.Forms.DataGridView dataGridOrders;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newOrderToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Products;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomersID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridCustomersDelete;
    }
}

