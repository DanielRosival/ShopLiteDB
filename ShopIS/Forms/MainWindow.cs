using ShopIS.Forms;
using ShopIS.ModelClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        }

        private void dataGridCustomers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridOrders_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void newCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addCustomer = new AddCustomer();
            addCustomer.FormClosed += new FormClosedEventHandler(AddCustomerForm_FormClosed);
            addCustomer.Show();
        }

        private void AddCustomerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ReloadCustomers();            
        }

        private void newProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addProduct = new AddProduct();
            addProduct.FormClosed += new FormClosedEventHandler(AddProductForm_FormClosed);
            addProduct.Show();
        }

        private void AddProductForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ReloadProducts();
        }

        private void newOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addOrder = new AddOrder();
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
            //Ziskame si kolekciu nasim jemne upravenym sposobom, robim to preto tak, lebo logika aplikacie by mala byt oddelena od vystupu.
            //FindAll() nam vrati vsetky zaznamy z databazy danej entity v datovom type IEnumerable.
            //Cez takyto datovy typ vieme iterovat, mozem vysvetlit aj podrobnejsie ako funguje to IEnumerable a interfacy, len na pisanie by to
            //bolo trocha zlozite. Podstatne vieme este na to zavolat metodu ToList() - list je asi najpouzivanejsia kolekcia je to ekvivalent c++ vektoru
            //v c# t.j. pole s automatickym riadenim pameti.
            List<Customer> customers = new DatabaseOperations().GetCollection<Customer>("customers").FindAll().ToList();
            foreach (var customer in customers)
            {
                dataGridCustomers.Rows.Add(customer.Id, customer.Name);
            }
        }

        private void ReloadProducts()
        {
            dataGridProducts.Rows.Clear();
            var products = new DatabaseOperations().GetCollection<Product>("products").FindAll();
            foreach (var product in products)
            {
                dataGridProducts.Rows.Add(product.Id, product.Price.ToString(), product.Description);
            }
        }
        
        private void ReloadOrders()
        {
            dataGridOrders.Rows.Clear();
            var orders = new DatabaseOperations().GetCollection<Order>("orders").Include(x => x.Customer).Include(x => x.Products).FindAll();
            foreach (var order in orders)
            {
                dataGridOrders.Rows.Add(order.Id, order.OrderDate, order.Customer.Name, string.Join(", ", order.Products));
            }
        }
    }
}
