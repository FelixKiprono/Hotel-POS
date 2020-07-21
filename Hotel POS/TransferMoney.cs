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
    public partial class TransferMoney : Form
    {
        public TransferMoney()
        {
            InitializeComponent();
        }
        public void LoadUsers()
        {
            try
            {
                MySqlCommand cmd = HorsePower.OpenConnection().CreateCommand();
                cmd.CommandText = "Select * From  `login2`  WHERE 1";
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    comboBox2.Items.Add(read.GetString(1));
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        private void TransferMoney_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmd = HorsePower.OpenConnection().CreateCommand();
                cmd.CommandText = "Select * From  `account`  WHERE 1";
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    comboBox1.Items.Add(read.GetString(1));
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            //load users
            LoadUsers();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmd = HorsePower.OpenConnection().CreateCommand();
                cmd.CommandText = "Select `AccountNumber`, `AccountName`, `Bank`, `Signitory`,  `Amount` From  `account`  WHERE `AccountName` = '" + comboBox1.Text + "'";
                MySqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    accountnumber.Text = read.GetString(0);
                    accountname.Text = read.GetString(1);
                    bankname.Text = read.GetString(2);
                    signitory.Text = read.GetString(3);
                    amount.Text = read.GetString(4);
                }
                else
                {
                    accountnumber.Text = "";
                    bankname.Text = "";
                    signitory.Text = "";
                    amount.Text = "";

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
                //check user account 
                String AS = "SELECT `Username`, `Role`, `Password` FROM `login2` WHERE `Username` = '" + comboBox2.Text + "' AND `Role` = 'Admin' AND `Password` = '" + textBox1.Text + "'";
               // V2MySqlServer v2 = new V2MySqlServer(Server.getIP(), "root", "", "hotel");
                MySqlCommand cmd = HorsePower.OpenConnection().CreateCommand();
                cmd.CommandText = AS;
                MySqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    if (!comboBox1.Text.Equals(""))
                    {
                        //proceed to transfer money
                        int total = int.Parse(amount.Text) + int.Parse(tobank.Text);
                        //confirm from user
                        DialogResult res = MessageBox.Show("AMOUNT KSH:" + tobank.Text + " \n WILL BE TRANSFERED TO : " + bankname.Text + " \n ON : " + dateTimePicker1.Text + " \n BY : " + comboBox2.Text, "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            textBox1.Text = "";
                            textBox1.Visible = false;
                            label11.Visible = false;
                            //proceed
                           HorsePower.ExecuteSQL("UPDATE `account` SET `Amount`='" + total.ToString() + "' WHERE `AccountNumber` ='" + accountnumber.Text + "' AND `AccountName` = '" + accountname.Text + "'");
                            //save transaction trail
                            TransactionTrail();
                            //clear everything
                            accountname.Text = "";
                            accountnumber.Text = "";
                            bankname.Text = "";
                            signitory.Text = "";
                            amount.Text = "";
                            tobank.Text = "";
                            source.Text = "";
                            //refresh the account balance
                            RefreshAccount(comboBox1.Text);
                        }
                        else
                        {
                            MessageBox.Show("Oooh No ! You Have Not Selected Bank Account", "Invalid Parameters", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                        }
                    }
                    //do nothing
                }
                else
                {
                    //do not do anything
                    MessageBox.Show("Sorry You Do Not Have Sufficient To Complete This Operation", "Invalid Account", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox1.Text = "";
                    textBox1.Visible = false;
                    label11.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

        }

        private void TransactionTrail()
        {
           HorsePower.ExecuteSQL("INSERT INTO `transactionlog`(`Date`,`Time`, `BankName`, `AccountNumber`, `AccountName`, `TransferedAmount`, `Username`) VALUES ('" + dateTimePicker1.Text + "','" + time.Text + "','" + bankname.Text + "','" + accountname.Text + "','" + accountnumber.Text + "','" + tobank.Text + "','" + comboBox2.Text + "')");

        }

        private void RefreshAccount(string text)
        {
             MySqlCommand cmd = HorsePower.OpenConnection().CreateCommand();
            cmd.CommandText = "Select `AccountNumber`, `AccountName`, `Bank`, `Signitory`,  `Amount` From  `account`  WHERE `AccountName` = '" + text + "'";
            MySqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                accountnumber.Text = read.GetString(0);
                accountname.Text = read.GetString(1);
                bankname.Text = read.GetString(2);
                signitory.Text = read.GetString(3);
                amount.Text = read.GetString(4);
            }


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Visible = true;
            label11.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime dd = DateTime.Now;
                time.Text = dd.ToString("h:m:s");
            }
            catch (Exception ex)
            {
                Console.Write(ex);

            }
        }
    }
}
