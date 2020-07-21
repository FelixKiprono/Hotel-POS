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
    public partial class Suppliers : Form
    {
        public Suppliers()
        {
            InitializeComponent();
        }
        public String NAMES = "";

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (company.Text == "" ||location.Text==""|| fullnames.Text == "" || mobile.Text == "")
                {
                    MessageBox.Show("Some Supplier Information Missing", "GreenCafe", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    String SQL = "INSERT INTO `suppliers`(`Company`, `Location`, `FullNames`, `OfficeTel`, `Mobile`, `Date`) VALUES ('" + company.Text + "','" + location.Text + "','" + fullnames.Text + "','" + office.Text + "','" + mobile.Text + "','" + dateTimePicker1.Text + "')";
                    HorsePower.ExecuteSQL(SQL);
                    MessageBox.Show("Successfully Saved Supplier Information", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    get();
                }
        }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
}
        public void get()
        {
            try
            {

                   dataGridView1.DataSource = HorsePower.Select("SELECT * FROM `Suppliers` WHERE 1");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        private void Suppliers_Load(object sender, EventArgs e)
        {
            try
            {
                 dataGridView1.DataSource = HorsePower.Select("SELECT * FROM `Suppliers` WHERE 1");
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
            company.Text = row.Cells[0].Value.ToString();
            location.Text = row.Cells[1].Value.ToString();
            fullnames.Text = row.Cells[2].Value.ToString();
                NAMES = row.Cells[2].Value.ToString();
                office.Text = row.Cells[3].Value.ToString();
            mobile.Text = row.Cells[4].Value.ToString();
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
                String Update = "UPDATE `suppliers` SET `Company`='" + company.Text + "',`Location`='" + location.Text + "',`FullNames`='" + fullnames.Text + "',`OfficeTel`='" + office.Text + "',`Mobile`='" + mobile.Text + "' WHERE `FullNames` = '" +NAMES + "'";
                HorsePower.ExecuteSQL(Update);
               // MessageBox.Show("Successfully Updated Supplier Information", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                get();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }




        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                String Update = "DELETE FROM `suppliers` WHERE `FullNames` ='" + NAMES+ "'";
               HorsePower.ExecuteSQL(Update);
                   get();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}
