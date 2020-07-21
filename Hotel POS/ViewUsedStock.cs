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
    public partial class ViewUsedStock : Form
    {
        public ViewUsedStock()
        {
            InitializeComponent();
        }

        private void ViewUsedStock_Load(object sender, EventArgs e)
        {
            String SQL = "SELECT `Code`, `Name`, `Date`, `QuantityOut`, `Notes` FROM `stockout` WHERE 1";
            try
            {

                  dataGridView1.DataSource = HorsePower.Select(SQL);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}
