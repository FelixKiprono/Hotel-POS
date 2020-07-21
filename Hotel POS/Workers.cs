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
    public partial class Workers : Form
    {
        public Workers()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(firstname.Text==""||lastname.Text==""||idnumber.Text==""||phone.Text==""||residence.Text=="")
            {
                MessageBox.Show("Some Important Details Missing","GreenCafe",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                String QSL = "INSERT INTO `workers`(`FirstName`, `LastName`, `IDNumber`, `Gender`, `Telephone`, `Residence`, `WorkPosition`, `Salary`, `PaymentMode`, `WorkingDuration`) VALUES ('"+firstname.Text  +"','"+lastname.Text+"','"+idnumber.Text+ "','" + gender.Text + "','" + phone.Text + "','" + residence.Text + "','" +position.Text + "','" + salary.Text + "','" + mode.Text + "','" + duration.Text + "')";

                HorsePower.ExecuteSQL(QSL);
                //reload the grid
                LoadAllWorkers();


            }
        }

        private void LoadAllWorkers()
        {
            try
            {
                dataGridView1.DataSource = HorsePower.Select("SELECT `FirstName`, `LastName`, `IDNumber`, `Gender`, `Telephone`, `Residence`, `WorkPosition`, `Salary`, `PaymentMode`, `WorkingDuration` FROM `workers` WHERE 1");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void Workers_Load(object sender, EventArgs e)
        {
            LoadAllWorkers();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            firstname.Text = "";
            lastname.Text = "";
            idnumber.Text = "";
            gender.Text = "";
            phone.Text = "";
            residence.Text = "";
            position.Text = "";
            mode.Text = "";
            salary.Text = "";
            duration.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
