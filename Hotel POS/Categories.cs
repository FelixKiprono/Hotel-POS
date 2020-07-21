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
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text == "")
                {
                    MessageBox.Show("Some  Information Missing", "Point Of Sale", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    HorsePower.ExecuteSQL("INSERT INTO `Categories`(`CategoryName`)VALUES ('" + textBox1.Text + "')");
                    getCat();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void getCat()
        {
            try
            {
                dataGridView1.DataSource = HorsePower.Select("SELECT * FROM `Categories` WHERE 1");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        private void getUnits()
        {
            try
            {
                dataGridView2.DataSource = HorsePower.Select("SELECT * FROM `Units` WHERE 1");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox2.Text == "")
                {
                    MessageBox.Show("Some  Information Missing", "Point Of Sale", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    HorsePower.ExecuteSQL("INSERT INTO `Units`(`UnitName`)VALUES ('" + textBox2.Text + "')");
                    getUnits();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void Categories_Load(object sender, EventArgs e)
        {
            getCat();
            getUnits();
        }
    }
}
