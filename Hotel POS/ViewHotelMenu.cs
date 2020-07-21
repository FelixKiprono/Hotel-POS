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
    public partial class ViewHotelMenu : Form
    {
        public ViewHotelMenu()
        {
            InitializeComponent();
        }

        private void ViewHotelMenu_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = HorsePower.Select("SELECT `Name`, `Type`,`Quantity`, `Price`,`Availability` FROM `itemsmenu` WHERE 1");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}
