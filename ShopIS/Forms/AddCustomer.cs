using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiteDB;
using System.Configuration;
using ShopIS.ModelClasses;

namespace ShopIS.Forms
{
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        public AddCustomer(int id)
        {
            InitializeComponent();
            CustomerObject = new Customer(id);
            tbName.Text = CustomerObject.Name;
            string[] lines = { "adasdls" };
        }

        private void btAddCustomer_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Equals(string.Empty))
            {
                new ErrorForm("Vyplnte meno").Show();
            }
            if (CustomerObject == null)
            {
                new DatabaseOperations().InsertObject("customers", new Customer()
                {
                    Name = tbName.Text
                });
            }
            else
            {
                CustomerObject.Name = tbName.Text;
                new DatabaseOperations().UpdateObject("customers", CustomerObject);
            }
            

            Close();
        }

        public Customer CustomerObject { get; set; }
    }
}
