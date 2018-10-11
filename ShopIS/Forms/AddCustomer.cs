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

        private void btAddCustomer_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Equals(string.Empty))
            {
                new ErrorForm("Vyplnte meno").Show();
            }
            //Kurzor do objektu a ked stlacite F12 uvidite definiciu/implementaciu.
            //c# umoznuje nieco taketo co c++ nie, vytvaranie triedy v argumente funkcie. Skratit vam to o jeden riadok program :D 
            //Dalsia vec co sa da vsimnut, je ze Customer nema ziadny konstruktor kde by som hned dal meno. Presne tymto zapisom to je ale mozne pri vytvoreni
            //novej triedy spravit. Takze zavolame normalny konstruktor a potom v kuceravych zatvorkach sa daju zadefinovat properties noveho objektu, oddelene ciarkou.
            new DatabaseOperations().InsertObject("customers", new Customer()
            {
                Name = tbName.Text
            });

            Close();
        }
    }
}
