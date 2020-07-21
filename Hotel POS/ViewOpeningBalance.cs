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
    public partial class ViewOpeningBalance : Form
    {
        public ViewOpeningBalance()
        {
            InitializeComponent();
        }

        private void ViewOpeningBalance_Load(object sender, EventArgs e)
        {
            try
            {
                
                dataGridView2.DataSource = HorsePower.Select("SELECT `FullNames`,  `Amount`,`Status` FROM `OpeningBalance` WHERE `Date` = '" + dateTimePicker1.Text + "'");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.DataSource = HorsePower.Select("SELECT `FullNames`,  `Amount`,`Status` FROM `OpeningBalance` WHERE `Date` = '" + dateTimePicker1.Text + "' AND `Status` = '"+comboBox1.Text+"'");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}
