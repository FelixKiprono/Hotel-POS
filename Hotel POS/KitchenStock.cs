using MySql.Data.MySqlClient;
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
    public partial class KitchenStock : Form
    {
        public KitchenStock()
        {
            InitializeComponent();
        }

        private void KitchenStock_Load(object sender, EventArgs e)
        {
            try
            {
               
                dataGridView1.DataSource = HorsePower.Select("SELECT `Code`,`ItemName`, `Quantity`, `Categories`, `PurchaseDate` FROM `stock` WHERE 1");
                dataGridView1.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Unable To Load data", "Error");
                Console.Write(ex);
            }
        }
        public void Reload()
        {
            try
            {
             dataGridView1.DataSource = HorsePower.Select("SELECT `Code`,`ItemName`, `Quantity`, `Categories`, `PurchaseDate` FROM `stock` WHERE 1");
                dataGridView1.Columns[0].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Unable To Load data", "Error");
                Console.Write(ex);
            }
        }
        private void qtytotal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                 dataGridView1.DataSource = HorsePower.Select("SELECT `Code`,`ItemName`, `Quantity`, `Categories`, `PurchaseDate` FROM `stock` WHERE `ItemName` = '" +itemname.Text+"'");
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Unable To Load data", "Error");
                Console.Write(ex);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
           // ReduceQty(name,Qty);
        }

        private void ReduceQty(string name, string qty)
        {
            try
            { 
            int q = 0;
            //fetch the quantity
              MySqlCommand cmd = new MySqlCommand("SELECT `Quantity` FROM `stock` WHERE `ItemName` = '"+name+"'", HorsePower.OpenConnection());
            MySqlDataReader read = cmd.ExecuteReader();
           if (read.Read())
            {
             q =    int.Parse(read.GetString(0));

            }
            //now reduce the stock by subtratcting 
            int total = q - int.Parse(qty);
            
            //now update the new stock qty

         HorsePower.ExecuteSQL("UPDATE `stock` SET `Quantity`='"+total+"' WHERE `ItemName` = '"+name+"'");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            { 
            DateTime date = DateTime.Now;
            DialogResult res = MessageBox.Show("Be Sure Because This Will Reduce Stock","Stock",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                //REDECE STOCK
                ReduceQty(textBox1.Text,textBox2.Text);
                //ADD TO LIST
                ListViewItem lv = new ListViewItem(new String[] { textBox1.Text, textBox2.Text });
                listView1.Items.Add(lv);
                Reload();
             HorsePower.ExecuteSQL("INSERT INTO `StockOut`(`Code`, `Name`, `Date`, `QuantityOut`, `Notes`) VALUES ('" + code.Text + "','" + textBox1.Text + "','"+date+"','" + textBox2.Text + "','" + textBox3.Text + "')");

            }
            else
            {
               
            }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            code.Text = row.Cells[0].Value.ToString();
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = "0";
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
           
        }
    }
}
