using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_POS
{
    public partial class NewMenu : Form
    {
        public NewMenu()
        {
            InitializeComponent();
        }

        private void NewMenu_Load(object sender, EventArgs e)
        {
            try
            { 
            LoadMenu();
            HorsePower.FillCombo(comboBox2,"SELECT `ItemName` FROM `itemcategories` WHERE 1");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public Boolean Check()
        {
            return false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void LoadMenu()
        {
            try
            {
               
                dataGridView1.DataSource = HorsePower.Select("SELECT `Name`, `Quantity`, `Price`, `Type`, `Details`, `Availability` FROM `itemsmenu` WHERE 1");
                for (int i=0;i< dataGridView1.Rows.Count;i++)
                {
                    if (int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) >= 10)
                    {
                       // dataGridView1.Rows[i]. = Color.Green;
                    }
                    else
                    {
                        dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox3.ReadOnly = true;
            comboBox2.Text = row.Cells[3].Value.ToString();
            textBox4.Text = row.Cells[4].Value.ToString();
            comboBox1.Text = row.Cells[5].Value.ToString();
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
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox3.ReadOnly = true;
            comboBox2.Text = row.Cells[3].Value.ToString();
            textBox4.Text = row.Cells[4].Value.ToString();
            comboBox1.Text = row.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                if (open.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = open.FileName;
                    File.Copy(open.FileName, "itemicons/" + open.SafeFileName);
                    iconname.Text = open.SafeFileName;
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                String SQL = @"INSERT INTO `itemsmenu`(`Name`, `Quantity`, `Price`,`Type`, `Details`, `Availability`,`Photo`) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox2.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','"+iconname.Text+"')";
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Cannot Add that item to Menu ", "GreenCafe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //check first if item is there
                    if (HorsePower.ISavailable("SELECT * FROM `itemsmenu` WHERE `NAME`='"+textBox1.Text+"' "))
                    {
                        MessageBox.Show("Cannot Add "+textBox1.Text+" to Menu,  It Already Exists", "GreenCafe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        File.WriteAllText("SQL.txt",SQL);
                        HorsePower.ExecuteSQL(MySql.Data.MySqlClient.MySqlHelper.EscapeString(SQL));
                        //reload the grid
                        LoadMenu();
                        //
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        comboBox1.Text = "";
                        comboBox2.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            try
            {
                String SQL = "UPDATE `itemsmenu` SET `Name`='" + textBox1.Text + "', `Quantity`='" + textBox2.Text + "', `Price`='" + textBox3.Text + "',`Type`='" + comboBox2.Text + "', `Details`='" + textBox4.Text + "', `Availability`='" + comboBox1.Text + "'  WHERE  `Name`= '" + textBox1.Text + "'";
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Cannot Edit / Update that Menu ", "GreenCafe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    HorsePower.ExecuteSQL(SQL);
                    //reload the grid
                    LoadMenu();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            try
            {
                String SQL = "DELETE FROM `itemsmenu` WHERE `Name`='" + textBox1.Text + "'";
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Cannot Edit / Update that Menu ", "GreenCafe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    HorsePower.ExecuteSQL(SQL);
                    //reload the grid
                    LoadMenu();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            ItemStatus im = new ItemStatus();
            im.ShowDialog();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
            try
            {
                count.Text = dataGridView1.Rows.Count.ToString();
            }
            catch(Exception ex)
            {

            }
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.ResetText();
            comboBox2.ResetText();
            textBox3.Enabled = true;
        }
    }
}
