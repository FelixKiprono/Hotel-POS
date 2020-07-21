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
    public partial class Exit : Form
    {
        public Exit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*try
            {
                Random r = new Random();
                int i = r.Next(0, 5000);

                V2.Backup bc = new V2.Backup(@"backup\HotelPOSbackup" + i.ToString() + ".sql", Server.getIP(), "root", "", "hotel");
                MessageBox.Show("DATABASE BACKUP COMPLETED SUCCESSFULLY ", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Console.Write(ex + "Backup Was Unable To Complete ");
            }*/
            this.Close();
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
