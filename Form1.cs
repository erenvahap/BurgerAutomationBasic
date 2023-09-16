using BurgerAutomation.Enums;
using BurgerAutomation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BurgerAutomation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<BurgerMenu> menus = new List<BurgerMenu>
            {
                new BurgerMenu{Name = "Texas SmokeHouse"  ,Price = 40, Explanation = "Delicious sealed meat"},
                new BurgerMenu{Name = "Barbeque Brioche"  ,Price = 50, Explanation = "Mexican fire with bbq sauce"},
                new BurgerMenu{Name = "Crispy Chicken"    ,Price = 35, Explanation = "Crispy chicken tenders"},
                new BurgerMenu{Name = "Steakhouse"        ,Price = 47, Explanation = "Literarly steak"},
                new BurgerMenu{Name = "TenderCrisp"       ,Price = 33, Explanation = "Hot and Crispy"}
            };

            cmbMenus.DataSource = menus;
            cmbMenus.SelectedIndex = -1;
        }

        private void cmbMenus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMenus.SelectedItem != null)
            {
                lblExplanation.Text = (cmbMenus.SelectedItem as BurgerMenu).Explanation;
            }
            else
            {
                lblExplanation.Text = "";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Order s = new Order();
            s.Name = txtName.Text;
            if(cmbMenus.SelectedItem == null)
            {
                MessageBox.Show("Please select a Menu");
                return;
            }

            s.SelectedMenu = cmbMenus.SelectedItem as BurgerMenu;

            s.Number = Convert.ToInt16(nmrNumber.Value);

            if (rdbBig.Checked) s.Size = Sizes.Big;
            else if (rdbMedium.Checked) s.Size = Sizes.Medium;

            foreach (CheckBox item in groupBox1.Controls)
            {
                if (item.Checked)
                {
                    ExtraIngredient ex = new ExtraIngredient();
                    ex.Name = item.Text;
                    ex.Price = Convert.ToDecimal(item.Tag);
                    s.Ingredients.Add(ex);
                }
            }

            s.CalculateBill();
            lstOrders.Items.Add(s);
        }

        private void btnGain_Click(object sender, EventArgs e)
        {

            decimal InTotal = 0;

            foreach (Order item in lstOrders.Items)
            {
                InTotal += item.Price;
            }
            MessageBox.Show(InTotal.ToString());

        }
    }
}
