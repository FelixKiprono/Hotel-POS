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
    public partial class summaryitems : UserControl
    {
        private string _itemname;
        private string _itemprice;
        private string _category;
        public string ItemName
        {
            get { return _itemname; }
            set { _itemname = value; itemname.Text = value; }
        }
        public string Details
        {
            get { return _category; }
            set { _category = value; details.Text = value; }
        }

        public string Price
        {
            get { return _category; }
            set { _category = value; pricetag.Text = value; }
        }

        public summaryitems()
        {
            InitializeComponent();
        }

        private void summaryitems_Load(object sender, EventArgs e)
        {

        }
    }
}
