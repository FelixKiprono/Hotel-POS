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
    public partial class OpeningBalance : Form
    {
        public OpeningBalance()
        {
            InitializeComponent();
        }
        public void get()
        {
            try
            {

                    dataGridView1.DataSource = HorsePower.Select("SELECT `FirstName`, `LastName` FROM `workers` WHERE 1");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public void LoadStuff()
        {
            try
            {

                  dataGridView2.DataSource = HorsePower.Select("SELECT `FullNames`,  `Amount`,`Status` FROM `OpeningBalance` WHERE `Date` = '" +dateTimePicker1.Text+"'");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        private void OpeningBalance_Load(object sender, EventArgs e)
        {
            get();
            LoadStuff();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (firstname.Text=="" || lastname.Text=="" || amount.Text=="")
            {
                MessageBox.Show("Please Select Worker","GreenCare",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    String sql = "INSERT INTO `OpeningBalance`(`FullNames`, `Date`, `Amount`,`Status`) VALUES ('" + firstname.Text + lastname.Text + "','" + dateTimePicker1.Text + "','" + amount.Text + "','Pending')";
                    HorsePower.ExecuteSQL(sql);
                    LoadStuff();
                }
                catch(Exception ex)
                {
                    Console.Write(ex);

                }


            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            firstname.Text= row.Cells[0].Value.ToString();
            lastname.Text = row.Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int total = int.Parse(textBox2.Text) - int.Parse(add.Text);

            //update the db
           HorsePower.ExecuteSQL("UPDATE `openingbalance` SET `Amount`='" + total.ToString() + "' WHERE `FullNames`='" + textBox1.Text + "' AND `Date` = '"+dateTimePicker1.Text+"'");
            //reload the datagrid
            LoadStuff();
            //hide me
            groupBox1.Visible = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void add_TextChanged(object sender, EventArgs e)
        {

        }

        private void closeOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.SelectedRows[0];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            groupBox1.Visible = true;
            btnreduce.Visible = false;
            btnadd.Visible = true;
        }

        private void reduceFloatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.SelectedRows[0];

            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            groupBox1.Visible = true;
            btnadd.Visible = false;
            btnreduce.Visible = true;
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            int total = int.Parse(textBox2.Text) + int.Parse(add.Text);
            //update the db
           HorsePower.ExecuteSQL("UPDATE `openingbalance` SET `Amount`='"+total.ToString()+"' WHERE `FullNames`='" + textBox1.Text + "' AND `Date` = '" + dateTimePicker1.Text + "'");
            //reload the datagrid
            LoadStuff();
            //hide me
            groupBox1.Visible = false;
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void clearFloatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.SelectedRows[0];
            String name = row.Cells[0].Value.ToString();
            DialogResult res = MessageBox.Show("ARE YOU SURE YOU WANT TO CLEAR FLOAT FOR : " + row.Cells[0].Value.ToString()+"\n This Means That He/She Has Returned Total Float" ,"FLOAT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                //set status to cleared
                HorsePower.ExecuteSQL("UPDATE `openingbalance` SET `Status`='Cleared' WHERE `FullNames`='" + name + "' AND `Date` = '" + dateTimePicker1.Text + "'");

                LoadStuff();
            }
        }
    }
}
