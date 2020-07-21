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
    public partial class POSMain : Form
    {
        public static double Total = 0;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 0x2000000;
                return cp;
            }
        }
        public POSMain()
        {
            InitializeComponent();
        }
        //0728797738
       void LoadMenuItemss()
        {

            positems.Controls.Clear();
            item[] items = new item[12];
            for(int i=0;i<items.Count();i++)
            {
                items[i] = new item();
                items[i].FoodName = "Test Food";
                items[i].Price = "45.98";
                items[i].Category = "Main Food";
                items[i].ClickItem += POSMain_ClickItem;
                positems.Controls.Add(items[i]);
            }
        }

        //add items to shopping list
        void LoadShopping()
        {

            shopinglist.Controls.Clear();
            summaryitems[] items = new summaryitems[4];
            for (int i = 0; i < items.Count(); i++)
            {
                items[i] = new summaryitems();
                items[i].Width = shopinglist.Width - 1;
                items[i].Dock = DockStyle.Top;

                // items[i].Location = new Point(shopinglist.Location.X -10 , shopinglist.Location.Y - 4);

                shopinglist.Controls.Add(items[i]);
            }
        }
        private void POSMain_ClickItem(object sender, EventArgs e)
        {

            item itm1 = (sender as item);
            summaryitems items = new summaryitems();
            items.ItemName = itm1.FoodName.ToString();
            items.Price = itm1.Price.ToString();
            items.Details = itm1.Category;
            items.Width = shopinglist.Width - 8;
            shopinglist.Controls.Add(items);

            //add items 0
            Total += double.Parse(itm1.Price.ToString());
           // total.Text = Total.ToString();
        }

        private void Item_Click(object sender, EventArgs e)
        {
         
        }

        void LoadCategories()
        {
            List<String> itm = HorsePower.getItemsType();
            topmenu.Controls.Clear();
            topmenu.FlowDirection = FlowDirection.TopDown;
            categoriesmenu[] items = new categoriesmenu[itm.Count()];
            foreach (String n in HorsePower.getItemsType())
            {
                int i = +1;
                items[i] = new categoriesmenu();
                items[i].Width = topmenu.Width - 8;
                items[i].Margins(6, 1, 1, 1);
                items[i].PropertyName = n;
                topmenu.Controls.Add(items[i]);
            }
        }
        private void m_Click(object sender, EventArgs e)
        {            
          
        }
        private void POSMain_Load(object sender, EventArgs e)
        {
                      

      
        render.RunWorkerAsync();
    }

    private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuMetroTextbox1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void rendergraphics_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke((Action)delegate
            {
                LoadCategories();
                LoadMenuItemss();
              //  LoadShopping();

            });
        }

        private void item1_Load(object sender, EventArgs e)
        {

        }

        private void item1_ItemClick(object sender, EventArgs e)
        {
           
        }

        private void item1_ClickItem(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToShortDateString();
        }
    }
}
