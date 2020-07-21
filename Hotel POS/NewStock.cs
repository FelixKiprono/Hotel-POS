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
    public partial class NewStock : Form
    {
        public NewStock()
        {
            InitializeComponent();
            try
            {
                itemname.AutoCompleteMode = AutoCompleteMode.Suggest;
                 MySqlCommand cmd = HorsePower.OpenConnection().CreateCommand();
                cmd.CommandText = "Select `ItemName` From stock  WHERE 1";
                MySqlDataReader read = cmd.ExecuteReader();
                AutoCompleteStringCollection ds = new AutoCompleteStringCollection();
                while (read.Read())
                {
                    ds.Add(read.GetString(0));
                }
                itemname.AutoCompleteCustomSource = ds;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (itemname.Text==""||quantity.Text==""||bp.Text==""||categories.Text==""||units.Text==""||supplier.Text==""||date.Text=="")
                {
                    MessageBox.Show("Some  Information Missing", "Point Of Sale", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    try
                    {
                        HorsePower.ExecuteSQL("INSERT INTO `Stock`(`Code`, `ItemName`, `Quantity`, `Categories`, `Units`, `BuyingPrice`, `Supplier`, `PurchaseDate`)VALUES ('" + code.Text + "','" + itemname.Text + "','" + quantity.Text + "','" + categories.Text + "','" + units.Text + "','" + bp.Text + "','" + supplier.Text + "','" + date.Text + "')");
                        //insert purchase record
                        int total = int.Parse(bp.Text) * int.Parse(quantity.Text);
                        HorsePower.ExecuteSQL("INSERT INTO `purchase_log`(`Date`, `Name`, `Quantity`, `Price`, `Total`) VALUES ('" + date.Text + "','" + itemname.Text + "','" + quantity.Text + "','" + bp.Text + "','"+total.ToString()+"')");


                        MessageBox.Show("Successfully Added New  Stock", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        itemname.Text = "";
                        code.Text = "";
                        quantity.Text = "";
                        categories.Text = "";
                        units.Text = "";
                        bp.Text = "";
                        supplier.Text = "";
                        
                        get();
                    }
                    catch(Exception ex)
                    {
                        Console.Write(ex);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }
        }
        public void get()
        {
            try
            {

                  dataGridView1.DataSource = HorsePower.Select("SELECT * FROM `Stock` WHERE 1");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        private void NewStock_Load(object sender, EventArgs e)
        {
            try
            { 
            get();
            //load combo boxes
            HorsePower.FillCombo(units,"SELECT `UnitName` FROM `units` WHERE 1");
            HorsePower.FillCombo(categories, "SELECT `CategoryName` FROM `categories` WHERE 1");
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
                //delete item now
                  DialogResult res = MessageBox.Show("ARE YOU SURE YOU WANT TO DELETE ITEM : "+itemname.Text+" COMPLETELY", "SYSTEM CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                   HorsePower.ExecuteSQL("DELETE FROM `stock` WHERE `ItemName`='" + itemname.Text + "' AND `Code` = '" + code.Text + "'");

                    MessageBox.Show("Item Deleted/Removed From Current Stock DB", "Green Care POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    itemname.Text = "";
                    code.Text = "";
                    quantity.Text = "";
                    categories.Text = "";
                    units.Text = "";
                    bp.Text = "";
                    supplier.Text = "";
                    button1.Visible = true;
                    button2.Visible = false;
                    button3.Visible = false;
                    button4.Visible = false;
                    get();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                code.Enabled = false;
                Random r = new Random();
                int i = r.Next(0, 500);
                code.Text = "ITEM"+ i.ToString();
            }
            else
            {
                code.Enabled = true;
                code.Focus();
            }
        }

        private void itemname_TextChanged(object sender, EventArgs e)
        {

            try
            {
                  dataGridView1.DataSource = HorsePower.Select("SELECT * FROM `stock` WHERE `ItemName` LIKE '" + itemname.Text + "%'");
                 MySqlCommand cmd = HorsePower.OpenConnection().CreateCommand();
                cmd.CommandText = "Select * From stock  WHERE `ItemName` like '" + itemname.Text + "'";
                MySqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    code.Text = read.GetString(0);
                    quantity.Text = read.GetString(2);
                    categories.Text = read.GetString(3);
                    units.Text = read.GetString(4);
                    bp.Text = read.GetString(5);
                    supplier.Text = read.GetString(6);
                    button1.Visible = false;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;

                }
                else
                {

                    code.Text = "";
                    quantity.Text = "";
                    categories.Text = "";
                    units.Text = "";
                    bp.Text = "";
                    supplier.Text = "";
                    button1.Visible = true;
                    button2.Visible = false;
                    button3.Visible = false;
                    button4.Visible = false;

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateStock s = new UpdateStock(itemname.Text);
            s.ShowDialog();
        }
    }
}
