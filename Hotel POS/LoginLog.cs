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
    public partial class LoginLog : Form
    {
        public LoginLog()
        {
            InitializeComponent();
        }

        private void LoginLog_Load(object sender, EventArgs e)
        {
            try
            {
                string[] lines = File.ReadAllLines("Log.txt");

                foreach (string l in lines)
                {
                    textBox1.Text += l + Environment.NewLine;

                }




            }
            catch (FileNotFoundException fe)
            {
                Console.Write(fe);
            }

        }
    }
}
