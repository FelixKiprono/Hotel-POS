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
    public partial class UpdateStock : Form
    {
        public UpdateStock(string name)
        {
            InitializeComponent();
            try
            {
                textBox2.AutoCompleteMode = AutoCompleteMode.Suggest; 
                MySqlCommand cmd = HorsePower.OpenConnection().CreateCommand();
                cmd.CommandText = "Select `ItemName` From stock WHERE 1";
                MySqlDataReader read = cmd.ExecuteReader();
                AutoCompleteStringCollection ds = new AutoCompleteStringCollection();
                while (read.Read())
                {
                    ds.Add(read.GetString(0));
                }
                textBox2.AutoCompleteCustomSource = ds;
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }
           // textBox2.Text = name;


        }

        private void itemname_KeyUp(object sender, KeyEventArgs e)
        {
             
            }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmd = HorsePower.OpenConnection().CreateCommand();
                cmd.CommandText = "Select * From stock  WHERE `ItemName` like '" + itemname.Text + "'";
                MySqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    code.Text = read.GetString(0);
                    textBox1.Text = read.GetString(1);
                    quantity.Text = read.GetString(2);
                    units.Text = read.GetString(4);
                    bp.Text = read.GetString(5);
                    supplier.Text = read.GetString(6);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void itemname_TextChanged(object sender, EventArgs e)
        {
            
        }
        
        private void UpdateStock_Load(object sender, EventArgs e)
        {
            try
            {
                 MySqlCommand cmd =HorsePower.OpenConnection().CreateCommand();
                cmd.CommandText = "Select * From stock  WHERE `ItemName` like '" + itemname.Text + "'";
                MySqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    code.Text = read.GetString(0);
                    textBox1.Text = read.GetString(1);
                    quantity.Text = read.GetString(2);
                    units.Text = read.GetString(4);
                    bp.Text = read.GetString(5);
                    supplier.Text = read.GetString(6);
                    newitem.Text = read.GetString(1);
                    newunits.Text = read.GetString(4);
                    newsupplier.Text = read.GetString(6);
                  
                }
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
                if (newitem.Text.Equals("") || newqty.Text.Equals("") || newbp.Text.Equals(""))
                {
                    MessageBox.Show("Please Search item First","Green Care POS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {
                    int totqty = int.Parse(quantity.Text) + int.Parse(newqty.Text);
                    HorsePower.ExecuteSQL("UPDATE `stock` SET `ItemName`='" + newitem.Text + "',`Quantity`='" + totqty.ToString() + "',`Units`='" + newunits.Text + "',`BuyingPrice`='" + newbp.Text + "',`Supplier`='" + newsupplier.Text + "',`PurchaseDate`='" + pdate.Text + "' WHERE `ItemName`='" + itemname.Text + "' AND `Code` = '" + code.Text + "'");
                    MessageBox.Show("Successfully Updated "+newitem.Text, "Green Care POS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //save purchase log
                    int total = int.Parse(newbp.Text) * int.Parse(newqty.Text);
                    HorsePower.ExecuteSQL("INSERT INTO `purchase_log`(`Date`, `Name`, `Quantity`, `Price`, `Total`) VALUES ('" + pdate.Text + "','" + newitem.Text + "','" + newqty.Text + "','" + newbp.Text + "','" + total.ToString() + "')");


                }
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                  MySqlCommand cmd = HorsePower.OpenConnection().CreateCommand();
                cmd.CommandText = "Select * From stock  WHERE `ItemName` like '" + textBox2.Text + "'";
                MySqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    code.Text = read.GetString(0);
                    textBox1.Text = read.GetString(1);
                    quantity.Text = read.GetString(2);
                    units.Text = read.GetString(4);
                    bp.Text = read.GetString(5);
                    supplier.Text = read.GetString(6);
                    newitem.Text = read.GetString(1);
                    newunits.Text = read.GetString(4);
                    newsupplier.Text = read.GetString(6);

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}
