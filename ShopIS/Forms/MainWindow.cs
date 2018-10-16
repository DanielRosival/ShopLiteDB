using ShopIS.Forms;
using ShopIS.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ShopIS
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            //Naloadime vsetko co mame v databaze, ved moze mat niekto nieco ulozene
            ReloadCustomers();
            ReloadProducts();
            ReloadOrders();
        }

        private void dataGridCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridCustomers.Columns[e.ColumnIndex].Name.Equals("dataGridCustomersDelete"))
            {
                DatabaseOperations dbOperations = new DatabaseOperations();
                int idCustomer = (int)dataGridCustomers.Rows[e.RowIndex].Cells[0].Value;
                if (!(new Customer(idCustomer).CheckIfHasOrders()))
                {
                    dbOperations.DeleteObject<Customer>("customers", idCustomer);
                    ReloadCustomers();
                }
                else
                {
                    new ErrorForm("Nie je mozne zmazat, na zakaznika je vytvorena objednavka, najprv je potrebne zrusit tu.").Show();
                }
            }
        }

        private void dataGridCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddCustomer editCustomer = new AddCustomer((int)dataGridCustomers.Rows[e.RowIndex].Cells[0].Value);
            editCustomer.Text = "Edit customer";
            editCustomer.FormClosed += new FormClosedEventHandler(AddCustomerForm_FormClosed);
            editCustomer.Show();
        }

        private void dataGridProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridProducts.Columns[e.ColumnIndex].Name.Equals("DeleteProduct"))
            {
                DatabaseOperations dbOperations = new DatabaseOperations();
                int idProduct = (int)dataGridProducts.Rows[e.RowIndex].Cells[0].Value;
                if (!(new Product(idProduct).CheckIfHasOrders()))
                {
                    dbOperations.DeleteObject<Product>("products", idProduct);
                    ReloadProducts();
                }
                else
                {
                    new ErrorForm("Nie je mozne zmazat, na tovar je vytvorena objednavka, najprv je potrebne zrusit tu.").Show();
                }
            }
        }

        private void dataGridProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddProduct editProduct = new AddProduct((int)dataGridProducts.Rows[e.RowIndex].Cells[0].Value);
            editProduct.Text = "Edit product";
            editProduct.FormClosed += new FormClosedEventHandler(AddProductForm_FormClosed);
            editProduct.Show();
        }

        private void dataGridOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridOrders.Columns[e.ColumnIndex].Name.Equals("DeleteOrder"))
            {
                int idOrder = (int)dataGridOrders.Rows[e.RowIndex].Cells[0].Value;
                new DatabaseOperations().DeleteObject<Order>("orders", idOrder);
                ReloadOrders();
            }
        }

        private void dataGridOrders_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddOrder editOrder = new AddOrder((int)dataGridOrders.Rows[e.RowIndex].Cells[0].Value);
            editOrder.Text = "Edit order";
            editOrder.FormClosed += new FormClosedEventHandler(AddOrderForm_FormClosed);
            editOrder.Show();
        }

        private void newCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();
            addCustomer.FormClosed += new FormClosedEventHandler(AddCustomerForm_FormClosed);
            addCustomer.Show();
        }

        private void AddCustomerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ReloadCustomers();
            ReloadOrders();
        }

        private void newProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.FormClosed += new FormClosedEventHandler(AddProductForm_FormClosed);
            addProduct.Show();
        }

        private void AddProductForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ReloadProducts();
            ReloadOrders();
        }

        private void newOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddOrder addOrder = new AddOrder();
            addOrder.FormClosed += new FormClosedEventHandler(AddOrderForm_FormClosed);
            addOrder.Show();
        }

        private void AddOrderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ReloadOrders();
        }

        private void ReloadCustomers()
        {
            dataGridCustomers.Rows.Clear();
            List<Customer> customers = new DatabaseOperations().GetCollection<Customer>("customers").FindAll().ToList();
            foreach (Customer customer in customers)
            {
                dataGridCustomers.Rows.Add(customer.Id, customer.Name);
            }
        }

        private void ReloadProducts()
        {
            dataGridProducts.Rows.Clear();
            IEnumerable<Product> products = new DatabaseOperations().GetCollection<Product>("products").FindAll();
            foreach (Product product in products)
            {
                dataGridProducts.Rows.Add(product.Id, product.Price.ToString(), product.Description);
            }
        }

        private void ReloadOrders()
        {
            dataGridOrders.Rows.Clear();
            IEnumerable<Order> orders = new DatabaseOperations().GetCollection<Order>("orders").Include(x => x.Customer).Include(x => x.Products).FindAll();
            foreach (Order order in orders)
            {
                dataGridOrders.Rows.Add(order.Id, order.OrderDate, order.Customer.Name, string.Join(", ", order.Products));
            }
        }
    }
}
