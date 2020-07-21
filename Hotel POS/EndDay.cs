using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace Hotel_POS
{
    public partial class EndDay : Form
    {
        public EndDay()
        {
            InitializeComponent();
        }

        private void EndDay_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSales(dateTimePicker1.Text);
                LoadOpeningBalance(dateTimePicker1.Text);
                LoadOrders(dateTimePicker1.Text);
                LoadPurchases(dateTimePicker1.Text);
                cashin.Text = textBox4.Text;
                cashout.Text = (int.Parse(textBox2.Text) + int.Parse(textBox3.Text)).ToString();
                profit.Text = (int.Parse(cashin.Text) - int.Parse(cashout.Text)).ToString();
            }
            catch(Exception ex)
            {
                Console.Write("Error : "+ex);
                MessageBox.Show(ex.ToString(), "Error Found :");
            }
        }

        private void LoadOrders(string text)
        {
            try
            {
                 dataGridView4.DataSource = HorsePower.Select("SELECT `OrderNumber`,`Total`, `Waiter`,`TableNumber` FROM `Orders` WHERE `Date` = '" +text+"' AND `Status`='Closed'");
                int total = 0;
                for (int i = 0; i < dataGridView4.Rows.Count; i++)
                {
                    total += int.Parse(dataGridView4.Rows[i].Cells[1].Value.ToString());

                }
                textBox4.Text =  total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex, "Error Unable To Load data :");
            }
        }

        private void LoadOpeningBalance(string text)
        {
            try
            {
                 dataGridView3.DataSource = HorsePower.Select("SELECT `FullNames`, `Date`, `Amount` FROM `openingbalance` WHERE `Date` = '" +text+"'");
                int total = 0;
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    total += int.Parse(dataGridView3.Rows[i].Cells[2].Value.ToString());

                }
                textBox3.Text =  total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex, "Error Unable To Load data :");
            }
        }

        private void LoadPurchases(string text)
        {
            try
            {
                  dataGridView2.DataSource = HorsePower.Select("SELECT `Name`, `Quantity`, `Price`, `Total` FROM `purchase_log` WHERE  `Date` = '" + text + "'");
                int total = 0;
                for (int i=0;i<dataGridView2.Rows.Count;i++)
                {
                    total += int.Parse(dataGridView2.Rows[i].Cells[3].Value.ToString());

                }
                textBox2.Text = total.ToString() ;

            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex, "Error Unable To Load data :");
            }
        }

        private void LoadSales(string text)
        {
            try
            {
                 dataGridView1.DataSource = HorsePower.Select("SELECT `ItemName`, `Quantity`, `Price`, `Total` FROM `sales` WHERE `Date` = '" +text+"'");
                int total = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    total += int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());

                }
                textBox1.Text =  total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" "+ex, "Error Unable To Load data :");
            }
        }
    }
}
