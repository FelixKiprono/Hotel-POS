using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_POS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        public void checklogin()
        {

            if (textBox1.Text == "" || comboBox2.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Some Fields Are Empty", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                MySqlCommand cmd = new MySqlCommand("Select * FROM `login2` WHERE Username = '" + textBox1.Text + "' AND Role = '" + comboBox2.Text + "' AND Password = '" + textBox2.Text + "'", HorsePower.OpenConnection());
                MySqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {

                    WriteLog();
                    this.Hide();
                    Menus c = new Menus(textBox1.Text, comboBox2.Text);
                    c.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Login Failed Try Again", "Unable To Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    comboBox2.Text = "";
                    textBox1.Focus();

                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

            checklogin();
        }
        private void Log(String msg, TextWriter t)
        {
            try
            {
                t.Write("Greencare Logged in as " + comboBox2.Text + " " + DateTime.Now + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        private void WriteLog()
        {
            try
            {
                String ms = "Greencare Hotel POS Logged in as " + comboBox2.Text + " " + DateTime.Now + Environment.NewLine;
                using (StreamWriter sw = File.AppendText("log.txt"))
                {
                    Log(ms, sw);
                }
            }
            catch (Exception error)
            {
                Console.Write("Error Found :" + error);
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //base.OnPaint(e);

            //Rectangle recta = new Rectangle(0, 0, this.Width, this.Height);
            //GraphicsPath path = new GraphicsPath();
            //path.AddArc(recta.X, recta.Y, 50, 50, 180, 90);
            //path.AddArc(recta.X + recta.Width - 50, recta.Y, 50, 50, 270, 90);
            //path.AddArc(recta.X + recta.Width - 50, recta.Y + recta.Height - 50, 50, 50, 0, 90);
            //path.AddArc(recta.X, recta.Y + recta.Height - 50, 50, 50, 90, 90);

            //this.Region = new Region(path);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                NewOrder ne = new NewOrder("Waiter");
                ne.ShowDialog();
            }
            else
            {

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                checklogin();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked == true)
            {
                textBox2.PasswordChar= ' ';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            HorsePower.FillCombo(textBox1,"SELECT Username FROM login2 WHERE 1");
        }
    }
}