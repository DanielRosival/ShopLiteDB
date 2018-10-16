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

namespace ShopIS.Forms
{
    public partial class AddOrder : Form
    {
        public AddOrder()
        {
            InitializeComponent();
            FillCustomers();
        }

        public AddOrder(int id)
        {
            InitializeComponent();
            OrderObject = new Order(id);
            tbProductIDs.Text = string.Join(";", OrderObject.Products.Select(x => x.Id));
            FillCustomers();
            ddlCustomers.SelectedItem = new Item(OrderObject.Customer.Name, OrderObject.Customer.Id);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (tbProductIDs.Text.Equals(string.Empty))
            {
                new ErrorForm("Vyplnte produkty").Show();
                Close();
                return;
            }

            List<int> productsIds = new List<int>();
            tbProductIDs.Text.Split(';').Select(x => x.Trim()).ToList().ForEach(x =>
            {
                if (int.TryParse(x, out int a))
                {
                    productsIds.Add(a);
                }
            });

            if (productsIds.Count() == 0)
            {
                new ErrorForm("Vyplnte produkty spravne").Show();
                Close();
                return;
            }

            if (OrderObject == null)
            {
                new DatabaseOperations().InsertObject("orders", new Order()
                {
                    OrderDate = dtPicker.Value,
                    Customer = new DatabaseOperations().GetCollection<Customer>("customers").FindById((ddlCustomers.SelectedItem as Item).Value),
                    Products = new DatabaseOperations().GetCollection<Product>("products").FindAll().Where(p => productsIds.Contains(p.Id)).ToList()
                });
            }
            else
            {
                new DatabaseOperations().UpdateObject("orders", new Order()
                {
                    OrderDate = dtPicker.Value,
                    Customer = new DatabaseOperations().GetCollection<Customer>("customers").FindById((ddlCustomers.SelectedItem as Item).Value),
                    Products = new DatabaseOperations().GetCollection<Product>("products").FindAll().Where(p => productsIds.Contains(p.Id)).ToList()
                });
            }

            Close();
        }

        private void FillCustomers()
        {
            var customers = new DatabaseOperations().GetCollection<Customer>("customers").FindAll().ToList();
            if (customers.Count() > 0)
            {
                customers.ForEach(x => ddlCustomers.Items.Add(new Item(x.Name, x.Id)));
            }
        }

        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name;
                Value = value;
            }

            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }

        public Order OrderObject { get; set; }
    }
}
