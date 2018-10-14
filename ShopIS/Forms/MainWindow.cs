﻿using ShopIS.Forms;
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

        private void dataGridCustomers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void dataGridProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

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
            //Ziskame si kolekciu nasim jemne upravenym sposobom, robim to preto tak, lebo logika aplikacie by mala byt oddelena od vystupu.
            //FindAll() nam vrati vsetky zaznamy z databazy danej entity v datovom type IEnumerable.
            //Cez takyto datovy typ vieme iterovat, mozem vysvetlit aj podrobnejsie ako funguje to IEnumerable a interfacy, len na pisanie by to
            //bolo trocha zlozite. Podstatne vieme este na to zavolat metodu ToList() - list je asi najpouzivanejsia kolekcia je to ekvivalent c++ vektoru
            //v c# t.j. pole s automatickym riadenim pameti.
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
