using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_POS
{
    public partial class categoriesmenu : UserControl
    {
        private string itemname;
        public String PropertyName
        {
            get { return itemname; }
            set
            {
                itemname = value;
                label1.Text = itemname;
            }
        }
        public categoriesmenu()
        {
            InitializeComponent();
        }

        private void categoriesmenu_MouseEnter(object sender, EventArgs e)
        {
        
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Aquamarine;
            label1.BackColor = Color.Transparent;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.MediumAquamarine;
            label1.BackColor = Color.Transparent;
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
           // this.Width += label1.Text.Length;
        }
        public void Margins(int a, int b, int c,int d)
        {
            this.Margin = new Padding(a,b,c,d);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
