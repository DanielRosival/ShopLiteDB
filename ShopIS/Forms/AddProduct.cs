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
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void btAddProduct_Click(object sender, EventArgs e)
        {
            if (tbPrice.Text.Equals(string.Empty) || tbDescription.Text.Equals(string.Empty))
            {
                new ErrorForm("Vyplnte vsetky polia").Show();
            }
            //vsetko je v c# objekt, takze vieme nad datovymi typmi volat operacie napriklad TryParse
            //metoda vrati true, ak sa nam podarilo dostat zo stringu double a false ak nie, takze vieme vyhodit nejaku hlasku
            //
            //c# umoznuje nieco taketo co c++ nie, vytvaranie triedy v argumente funkcie. Skratit vam to o jeden riadok program :D 
            //Dalsia vec co sa da vsimnut, je ze Customer nema ziadny konstruktor kde by som hned dal meno. Presne tymto zapisom to je ale mozne pri vytvoreni
            //novej triedy spravit. Takze zavolame normalny konstruktor a potom v kuceravych zatvorkach sa daju zadefinovat properties noveho objektu, oddelene ciarkou.
            if (double.TryParse(tbPrice.Text,out double price))
            {
                new DatabaseOperations().InsertObject("products", new Product()
                {
                    Price = price,
                    Description = tbDescription.Text
                });
            }
            else
            {
                new ErrorForm("Vyplnte korektne cenu").Show();
            }
            Close();
        }
    }
}
