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
    public partial class ChangePrices : Form
    {
        public ChangePrices()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = HorsePower.Select("SELECT `Name`, `Quantity`, `Price` FROM `itemsmenu` WHERE `Name` LIKE  '" + textBox1.Text + "%'");
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                name.Text = row.Cells[0].Value.ToString();
                quantity.Text = row.Cells[1].Value.ToString();
                oldprice.Text = row.Cells[2].Value.ToString();

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               
                dataGridView1.DataSource = HorsePower.Select("SELECT `Name`, `Quantity`, `Price` FROM `itemsmenu` WHERE `Type`  = '" + comboBox1.Text + "'");
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
                 
                dataGridView1.DataSource = HorsePower.Select("SELECT `Name`, `Quantity`, `Price` FROM `itemsmenu` WHERE `Availability` = '" + comboBox1.Text + "'");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            name.Text = row.Cells[0].Value.ToString();
            quantity.Text = row.Cells[1].Value.ToString();
            oldprice.Text = row.Cells[2].Value.ToString();

        }

        private void ChangePrices_Load(object sender, EventArgs e)
        {
            ReloadGrid();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            name.Text = row.Cells[0].Value.ToString();
            quantity.Text = row.Cells[1].Value.ToString();
            oldprice.Text = row.Cells[2].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String SQL = "UPDATE `itemsmenu` SET `Price`='" + newprice.Text + "'  WHERE  `Name`= '" + name.Text + "'";
          HorsePower.ExecuteSQL(SQL);
            newprice.Text = "";
            ReloadGrid();
        }

        private void ReloadGrid()
        {
            try
            {
                  dataGridView1.DataSource = HorsePower.Select("SELECT `Name`, `Quantity`, `Price` FROM `itemsmenu` WHERE 1");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            name.Text = row.Cells[0].Value.ToString();
            quantity.Text = row.Cells[1].Value.ToString();
            oldprice.Text = row.Cells[2].Value.ToString();
        }
    }
}