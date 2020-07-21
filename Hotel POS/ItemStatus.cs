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
    public partial class ItemStatus : Form
    {
        public ItemStatus()
        {
            InitializeComponent();
        }
        void LoadStatus()
        {
            try
            {

                  dataGridView1.DataSource = HorsePower.Select("SELECT `Name`, `Price`, `Type`, `Details`, `Availability`,`Status` FROM `itemsmenu` WHERE 1");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        private void ItemStatus_Load(object sender, EventArgs e)
        {
            try
            {

                 dataGridView1.DataSource = HorsePower.Select("SELECT `Name`, `Price`, `Type`, `Details`, `Availability`,`Status` FROM `itemsmenu` WHERE 1");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void closeOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];


            DialogResult res = MessageBox.Show("ARE YOU SURE YOU WANT TO MARK : " + row.Cells[0].Value.ToString()+" AS COOKED", "STATUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {

                String on = row.Cells[0].Value.ToString();
                String Query = "UPDATE `itemsmenu` SET `Status`='Cooked' WHERE `Name`='" + on + "' ";
                HorsePower.ExecuteSQL(Query);
                LoadStatus();

            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
        }

        private void markAsUncookedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];



            DialogResult res = MessageBox.Show("ARE YOU SURE YOU WANT TO MARK : " + row.Cells[0].Value.ToString() + " AS UNCOOKED", "STATUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {

                String on = row.Cells[0].Value.ToString();
                String Query = "UPDATE `itemsmenu` SET `Status`='UnCooked' WHERE `Name`='" + on + "' ";
               HorsePower.ExecuteSQL(Query);
                LoadStatus();

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //change the item status as the combo is clicked
                LoadStatus2(comboBox1.Text);

            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void LoadStatus2(string text)
        {
            try
            {

                  dataGridView1.DataSource = HorsePower.Select("SELECT `Name`, `Price`, `Type`, `Details`, `Availability`,`Status` FROM `itemsmenu` WHERE `Status` = '" +comboBox1.Text+"'");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}
