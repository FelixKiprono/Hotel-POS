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
    public partial class Tables : Form
    {
        public Tables()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text == "" || textBox2.Text=="")
                {
                    MessageBox.Show("Some  Information Missing", "Point Of Sale", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                   HorsePower.ExecuteSQL("INSERT INTO `Table`(`TableNumber`,`TableName`)VALUES ('" + textBox1.Text + "','" + textBox2.Text + "')");
                    //MessageBox.Show("Successfully Added Table", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gettable();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void gettable()
        {
            try
            {

                     dataGridView1.DataSource = HorsePower.Select("SELECT * FROM `Table` WHERE 1");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void Tables_Load(object sender, EventArgs e)
        {
            gettable();
        }
    }
}
