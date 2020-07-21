using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_POS
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle recta = new Rectangle(0, 0, this.Width, this.Height);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(recta.X, recta.Y, 30, 30, 180, 90);

            path.AddArc(recta.X + recta.Width - 50, recta.Y, 50, 50, 270, 90);
            path.AddArc(recta.X + recta.Width - 50, recta.Y + recta.Height - 50, 50, 50, 0, 90);
            path.AddArc(recta.X, recta.Y + recta.Height - 50, 50, 50, 90, 90);

            this.Region = new Region(path);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Value = progressBar1.Value + 1;
                label3.Text = "Loading [ " + progressBar1.Value + " ] %";
                if (progressBar1.Value == 100)
                {
                    timer1.Enabled = false;
                    this.Hide();
                    Login l = new Login();
                    l.Show();


                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

        }

        private void Splash_Load(object sender, EventArgs e)
        {

        }
    }
}
