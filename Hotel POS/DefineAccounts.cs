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
    public partial class DefineAccounts : Form
    {
        public DefineAccounts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("Please Fill Account Details", "Invalid Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //check if account exists
                      MySqlCommand cmd = HorsePower.OpenConnection().CreateCommand();
                    cmd.CommandText = "Select * From  `account`  WHERE `AccountNumber` = '" + textBox1.Text + "'";
                    MySqlDataReader read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        MessageBox.Show("Duplicate Account Exists", "Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        //create account
                        String SQLQUERY = "INSERT INTO `account`(`AccountNumber`, `AccountName`, `Bank`, `DateOpened`, `Signitory`, `Accounttype`, `Amount`) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + textBox5.Text + "')";
                        HorsePower.ExecuteSQL(SQLQUERY);
                        MessageBox.Show("Account Information Saved", "Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch    (Exception ex)
            {
                Console.Write(ex);
            }
                
            }
        

        private void DefineAccounts_Load(object sender, EventArgs e)
        {

        }
    }
}
