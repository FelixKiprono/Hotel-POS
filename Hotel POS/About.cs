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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void About_Load(object sender, EventArgs e)
        {
            machinename.Text = Environment.UserDomainName.ToString();
            osversion.Text =  Environment.OSVersion.ToString();
            currentdirectory.Text = Environment.CurrentDirectory.ToString();
            textBox11.Text = Environment.WorkingSet.ToString();


        }
    }
}
