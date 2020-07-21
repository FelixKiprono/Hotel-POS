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
    public partial class item : UserControl
    {

        public event EventHandler ClickItem = null;

        public Image images;
        private string itemname;
        private string itemprice;
        private string category;

        public Image ItemImage
        {
            get { return images; }
            set
            {
                images = value;
                pictureBox1.Image = images;
            }
        }
        public String FoodName
        {
            get { return itemname; }
            set
            {
                itemname = value;
                label1.Text = itemname;
            }
        }
        public String Price
        {
            get { return itemprice; }
            set
            {
                itemprice = value;
                label3.Text = itemprice;
            }
        }
        public String Category
        {
            get { return category; }
            set
            {
                category = value;
                label2.Text = category;
            }
        }
        public item()
        {
            InitializeComponent();
            ClickItem += Item_ClickItem;
          
        }

        private void Item_ClickItem(object sender, EventArgs e)
        {
          
        }


        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Silver;
            this.BackColor = Color.Silver;
            label1.BackColor = Color.Silver;
            label2.BackColor = Color.Silver;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.White;
            this.BackColor = Color.White;
            label1.BackColor = Color.White;
            label2.BackColor = Color.White;

        }


        private void item_Load(object sender, EventArgs e)
        {

        }

        private void item_Click(object sender, EventArgs e)
        {
            if (ClickItem != null)
            {
                ClickItem.Invoke(this, null);
            }
        }
    }
}
