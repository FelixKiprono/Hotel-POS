using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_POS
{
    public partial class OrdersApproval : Form
    {
        public OrdersApproval()
        {
            InitializeComponent();
        }

        private void OrdersApproval_Load(object sender, EventArgs e)
        {
            try
            {

                 dataGridView1.DataSource = HorsePower.Select("SELECT `OrderNumber`,`Status`, `Total`, `Waiter` FROM `orders` WHERE `Status` = 'Open' AND `Date` = '" + dateTimePicker1.Text + "'");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {

                 dataGridView1.DataSource = HorsePower.Select("SELECT `OrderNumber`,`Status`, `Total`, `Waiter` FROM `orders` WHERE `OrderNumber` = '" + textBox1.Text + "%'");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {

                 dataGridView1.DataSource = HorsePower.Select("SELECT `OrderNumber`,`Status`, `Total`, `Waiter` FROM `orders` WHERE `Waiter` LIKE '" + textBox2.Text + "%'");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
              dataGridView1.DataSource = HorsePower.Select("SELECT `OrderNumber`,`Status`, `Total`, `Waiter` FROM `orders` WHERE `Status` = '" + comboBox1.Text + "' ");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void closeOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];

                panel2.Visible = true;
                String number = row.Cells[0].Value.ToString();
                 dataGridView2.DataSource = HorsePower.Select("SELECT `ItemName`, `Quantity`, `Price`,`Total` FROM `OrderInfor` WHERE `OrderNumber`='" + number + "'");

                total.Text = row.Cells[2].Value.ToString();
                waiter.Text = row.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void SaveSale(string on, string waiter)
        {
            //loop through the order
             MySqlCommand cmd = new MySqlCommand("SELECT `ItemName`, `Quantity`, `Price`, `Total` FROM `orderinfor` WHERE `OrderNumber` = '" + on + "'", HorsePower.OpenConnection());
            MySqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                //insert the sales table
                   HorsePower.ExecuteSQL("INSERT INTO `sales`(`Worker`,`Date`,`ItemName`,`Quantity`, `Price`,`Total`) VALUES ('" + waiter + "','" + dateTimePicker1.Text + "','" + read.GetString(0) + "','" + read.GetString(1) + "','" + read.GetString(2) + "','" + read.GetString(3) + "')");
            }
            MessageBox.Show("Hotel Sale Information Saved Successfully ", "Sale Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void LoadOrders()
        {
            try
            {

                  dataGridView1.DataSource = HorsePower.Select("SELECT `OrderNumber`,`Status`, `Total`, `Waiter` FROM `orders` WHERE `Status` = 'Open' AND `Date` = '" + dateTimePicker1.Text + "'");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            try
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];


                DialogResult res = MessageBox.Show("ARE YOU SURE YOU WANT TO CLOSE THIS ORDER : " + row.Cells[0].Value.ToString(), "Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {

                    String on = row.Cells[0].Value.ToString();
                    String waiter1 = row.Cells[3].Value.ToString();
                    String Query = "UPDATE `orders` SET `Status`='Closed' WHERE  `OrderNumber`='" + on + "' ";
                      HorsePower.ExecuteSQL(Query);
                    LoadOrders();
                    //save the sale 
                    SaveSale(on, waiter1);
                    //save statement
                    HorsePower.ExecuteSQL(" INSERT INTO `finance_statement` (`name`, `type`, `date`, `debit`, `credit`, `balance` ) VALUES ('Income', 'Income', '"+DateTime.Now.ToShortDateString()+"', '0', '"+paid.Text+"', '0' );");

                    panel2.Visible = false;

                    string GS = Convert.ToString((char)29);
                    string ESC = Convert.ToString((char)27);
                    Random rno = new Random();
                    string receipt = rno.Next(0, 100).ToString();
                    string COMMAND = "";
                    COMMAND = ESC + "@";
                    COMMAND += GS + "V" + (char)1;
                    DateTime D = DateTime.Now;
                    //  int i = 0;
                    StringBuilder sb = new StringBuilder();
                    sb.Append("           DYKAAN HOTEL                       \n");
                    sb.Append("KIAMBUU TWIGA BUILDING SECOND FLOOR           \n");
                    sb.Append("P.O. Box                                      \n");

                    //sb.Append("KIAMBUU                                      \n");
                    // sb.Append("         BILLING RECEIPT                       \n");

                    sb.Append("DATE      :" + D.ToString() + "                \n");
                    sb.Append("TELL NO   : 0723156900                         \n");
                    sb.Append("TILL NO   : 83359                              \n");
                    sb.Append("ADDRESS   : 01000 - 152 THIKA                  \n");
                    sb.Append("RECEIPTNO : " + receipt.ToString() + "         \n");
                    // sb.Append("WAITER    : " + comboBox3.Text + "             \n");

                    sb.Append("          CASH SALE RECEIPT                    \n");
                    sb.Append("_______________________________________________\n");
                    // sb.Append("No     Name       Quantity      Price     Total\n");
                    sb.Append("_______________________________________________\n");
                    sb.Append("               Customer Bill List              \n");
                    sb.Append("_______________________________________________\n");
                    int j = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        j = j + 1;
                        sb.Append(j.ToString() + "." + "     " + dataGridView2.Rows[i].Cells[0].Value + "        " + dataGridView2.Rows[i].Cells[1].Value + " X   " + dataGridView2.Rows[i].Cells[2].Value + "      \n");
                    }
                    /*  for (int i = 0; i < dataGridView2.Rows.Count; i++)
                      {
                          j = j + 1;
                          sb.Append("     " + dataGridView2.Rows[i].Cells[1].Value + " x       " + dataGridView2.Rows[i].Cells[2].Value + "  "+ dataGridView2.Rows[i].Cells[0].Value + "           \n");
                      }*/
                    sb.Append("______________________________________________ \n");
                    sb.Append("Serverd By  : " + waiter.Text + "          \n");
                    // sb.Append("Table Number : " + comboBox2.Text + "          \n");
                    sb.Append("_______________________________________________\n");
                    sb.Append("            Total Items  : " + dataGridView2.Rows.Count.ToString() + "\n");
                    sb.Append("            Total Bill   : " + total.Text + "\n");
                    //  sb.Append("            Paid Amount : " + paid.Text +     "\n");
                    //  sb.Append("            Change      : " + change.Text +   "\n");
                    sb.Append("            Mode         : Cash                 \n");
                    sb.Append("_______________________________________________\n");
                    sb.Append("   Come in as Guest Leave As Family            \n");
                    sb.Append("                THANK YOU                      \n");

                    sb.Append("                                               \n");
                    sb.Append("                                               \n");
                    sb.Append("                                               \n");
                    sb.Append("                                               \n");
                    sb.Append("                                               \n");
                    sb.Append("                                               \n");
                    sb.Append("                                               \n");
                    sb.Append("                                               \n");
                    sb.Append("                                               \n");
                    sb.Append("                                               \n");
                    string s = sb.ToString();
                    // device-dependent string, need a FormFeed?
                    //
                    // Allow the user to select a printer.
                    PrintDialog pd = new PrintDialog();
                    pd.PrinterSettings = new PrinterSettings();
                    // Send a printer-specific to the printer.
                    RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, s + COMMAND);
                    total.Text = "";
                    paid.Text = "";
                    waiter.Text = "";
                    change.Text = "";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void paid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int t = int.Parse(total.Text);
                int p = int.Parse(paid.Text);
                int c = p - t;
                change.Text = c.ToString();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void printOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];

                panel2.Visible = true;
                String number = row.Cells[0].Value.ToString();
                dataGridView2.DataSource = HorsePower.Select("SELECT `ItemName`, `Quantity`, `Price`,`Total` FROM `OrderInfor` WHERE `OrderNumber`='" + number + "'");

                total.Text = row.Cells[2].Value.ToString();
                waiter.Text = row.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        void PrintOrder()
        {
            try
            {
                //panel2.Visible = false;

                DataGridViewRow row = this.dataGridView1.SelectedRows[0];

                String on = row.Cells[0].Value.ToString();
                String waiter1 = row.Cells[3].Value.ToString();
                String Query = "UPDATE `orders` SET `Status`='Closed' WHERE  `OrderNumber`='" + on + "' ";
                 HorsePower.ExecuteSQL(Query);
                LoadOrders();
                SaveSale(on, waiter1);
                panel2.Visible = false;
                string GS = Convert.ToString((char)29);
                string ESC = Convert.ToString((char)27);
                Random rno = new Random();
                string receipt = rno.Next(0, 100).ToString();
                string COMMAND = "";
                COMMAND = ESC + "@";
                COMMAND += GS + "V" + (char)1;
                DateTime D = DateTime.Now;
                //  int i = 0;
                StringBuilder sb = new StringBuilder();
                sb.Append("           DYKAAN HOTEL                       \n");
                sb.Append("KIAMBUU TWIGA BUILDING SECOND FLOOR           \n");
                sb.Append("P.O. Box                                      \n");

                //sb.Append("KIAMBUU                                      \n");
                // sb.Append("         BILLING RECEIPT                       \n");

                sb.Append("DATE      :" + D.ToString() + "                \n");
                sb.Append("TELL NO   : 0723156900                         \n");
                sb.Append("TILL NO   : 83359                              \n");
                sb.Append("ADDRESS   : 01000 - 152 THIKA                  \n");
                sb.Append("RECEIPTNO : " + receipt.ToString() + "         \n");
                // sb.Append("WAITER    : " + comboBox3.Text + "             \n");

                sb.Append("          CASH SALE RECEIPT                    \n");
                sb.Append("_______________________________________________\n");
                // sb.Append("No     Name       Quantity      Price     Total\n");
                sb.Append("_______________________________________________\n");
                sb.Append("               Customer Bill List              \n");
                sb.Append("_______________________________________________\n");
                int j = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    j = j + 1;
                    sb.Append(j.ToString() + "." + " " + dataGridView2.Rows[i].Cells[0].Value + "               " + dataGridView2.Rows[i].Cells[1].Value + " X   " + dataGridView2.Rows[i].Cells[2].Value + "      \n");
                }
                /*  for (int i = 0; i < dataGridView2.Rows.Count; i++)
                  {
                      j = j + 1;
                      sb.Append("     " + dataGridView2.Rows[i].Cells[1].Value + " x       " + dataGridView2.Rows[i].Cells[2].Value + "  "+ dataGridView2.Rows[i].Cells[0].Value + "           \n");
                  }*/
                sb.Append("______________________________________________ \n");
                sb.Append("Serverd By  : " + waiter.Text + "          \n");
                // sb.Append("Table Number : " + comboBox2.Text + "          \n");
                sb.Append("_______________________________________________\n");
                sb.Append("            Total Items  : " + dataGridView2.Rows.Count.ToString() + "\n");
                sb.Append("            Total Bill   : " + total.Text + "\n");
                //  sb.Append("            Paid Amount : " + paid.Text +     "\n");
                //  sb.Append("            Change      : " + change.Text +   "\n");
                sb.Append("            Mode         : Cash                 \n");
                sb.Append("_______________________________________________\n");
                sb.Append("   Come in as Guest Leave As Family            \n");
                sb.Append("                THANK YOU                      \n");

                sb.Append("                                               \n");
                sb.Append("                                               \n");
                sb.Append("                                               \n");
                sb.Append("                                               \n");
                sb.Append("                                               \n");
                sb.Append("                                               \n");
                sb.Append("                                               \n");
                sb.Append("                                               \n");
                sb.Append("                                               \n");
                sb.Append("                                               \n");
                string s = sb.ToString();
                // device-dependent string, need a FormFeed?
                //
                // Allow the user to select a printer.
                PrintDialog pd = new PrintDialog();
                pd.PrinterSettings = new PrinterSettings();
                // Send a printer-specific to the printer.
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, s + COMMAND);
                total.Text = "";
                paid.Text = "";
                waiter.Text = "";
                change.Text = "";
            }
            catch (Exception ex)
            {
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
           
            }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }
    }
}
