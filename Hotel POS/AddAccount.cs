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
    public partial class AddAccount : Form
    {
        public AddAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (username.Text == "" || comboBox2.Text == "" || password.Text == "")
                {
                    MessageBox.Show("Incomplete Information ", "Warning");
                }
                else
                {
                    string add = "INSERT INTO `login2`(`username`,`Role`, `Password`) VALUES ('" + username.Text + "','" + comboBox2.Text + "','" + password.Text + "')";
                   HorsePower.ExecuteSQL(add);
                    MessageBox.Show("New Account Created ", "Transaction Succeeded",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void AddAccount_Load(object sender, EventArgs e)
        {

        }
    }
}
