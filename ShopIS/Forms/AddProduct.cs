using ShopIS.ModelClasses;
using System;
using System.Windows.Forms;

namespace ShopIS.Forms
{
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        public AddProduct(int id)
        {
            InitializeComponent();
            ProductObject = new Product(id);
            tbPrice.Text = ProductObject.Price.ToString();
            tbDescription.Text = ProductObject.Description;
        }

        private void btAddProduct_Click(object sender, EventArgs e)
        {
            if (tbPrice.Text.Equals(string.Empty) || tbDescription.Text.Equals(string.Empty))
            {
                new ErrorForm("Vyplnte vsetky polia").Show();
            }
            if (double.TryParse(tbPrice.Text, out double price))
            {
                if (ProductObject == null)
                {
                    new DatabaseOperations().InsertObject("products", new Product()
                    {
                        Price = price,
                        Description = tbDescription.Text
                    });
                }
                else
                {
                    ProductObject.Price = price;
                    ProductObject.Description = tbDescription.Text;
                    new DatabaseOperations().UpdateObject("products", ProductObject);
                }
            }
            else
            {
                new ErrorForm("Vyplnte korektne cenu").Show();
            }
            Close();
        }

        public Product ProductObject { get; set; }
    }
}
