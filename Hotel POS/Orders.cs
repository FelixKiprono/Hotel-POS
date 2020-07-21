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
    public partial class Orders : Form
    {
        public ListViewItem lv;
        public Orders()
        {
            InitializeComponent();
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            HorsePower.FillCombo(comboBox2, "SELECT `TableNumber` FROM `table` WHERE 1");

            try
            {
                 dataGridView1.DataSource = HorsePower.Select("SELECT `OrderNumber`, `Date`, `Status`, `Total`, `Waiter`,`TableNumber`,`OrderStatus` FROM `Orders` WHERE OrderStatus = 'Not Seen' AND `Status` = 'Closed'");
            }
            catch (Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                String number = row.Cells[0].Value.ToString();
                             dataGridView2.DataSource = HorsePower.Select("SELECT `ItemName`, `Quantity`, `Price`,`Total` FROM `OrderInfor` WHERE `OrderNumber`='" + number + "'");

                AddTotals();
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }
           
        }
        private void AddTotals()
        {
            try
            {
                int tot = 0;
                int tot2 = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    tot += int.Parse(dataGridView2.Rows[i].Cells[1].Value.ToString());
                    tot2 += int.Parse(dataGridView2.Rows[i].Cells[3].Value.ToString());
                }
                label6.Text = tot.ToString();
                label7.Text = tot2.ToString();
            }
            catch(FormatException ex)
            {
                Console.Write(ex);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = HorsePower.Select("SELECT `OrderNumber`, `Date`, `Status`, `Total`, `Waiter`,`TableNumber`,`OrderStatus` FROM `Orders` WHERE `Status`='Closed' AND `OrderStatus`='"+comboBox1.Text+"'");

            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error Unable To Load data", "Error");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                 dataGridView1.DataSource = HorsePower.Select("SELECT `OrderNumber`, `Date`, `Status`, `Total`, `Waiter`,`OrderStatus` FROM `Orders` WHERE `TableNumber`='" + comboBox2.Text + "'");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Unable To Load data", "Error");
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
            try
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                String number = row.Cells[0].Value.ToString();
                dataGridView2.DataSource = HorsePower.Select("SELECT `ItemName`, `Quantity`, `Price`,`Total` FROM `OrderInfor` WHERE `OrderNumber`='" + number + "'");

                AddTotals();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ItemStatus im = new ItemStatus();
            im.ShowDialog();
        }
        void LoadOrders()
        {
            try
            {
               
                dataGridView1.DataSource = HorsePower.Select("SELECT `OrderNumber`, `Date`, `Status`, `Total`, `Waiter`,`TableNumber`,`OrderStatus` FROM `Orders` WHERE OrderStatus='Not Seen' `Status` = 'Closed'");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                MessageBox.Show("Error Unable To Load data", "Error");
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void seenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            DialogResult res = MessageBox.Show("ARE YOU SURE YOU WANT TO MARK ORDER : " + row.Cells[0].Value.ToString()+" AS SEEN", "Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {

                String on = row.Cells[0].Value.ToString();
                String waiter = row.Cells[3].Value.ToString();
                String Query = "UPDATE `orders` SET `OrderStatus`='Seen' WHERE  `OrderNumber`='" + on + "' ";
                HorsePower.ExecuteSQL(Query);
               
            }
            LoadOrders();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
