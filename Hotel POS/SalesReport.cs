using MySql.Data.MySqlClient;
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
    public partial class SalesReport : Form
    {
        public SalesReport()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintPreviewDialog();
        }

       
        public void generateReport()
        {


            try
            {
                String SQL = "SELECT  `ItemName`, `Quantity`, `Total` FROM `sales` WHERE 1";
                 MySqlCommand cmd = new MySqlCommand(SQL, HorsePower.OpenConnection());
                MySqlDataReader read = cmd.ExecuteReader();
                var html = new StringBuilder();
                html.AppendLine("<html><body>");
                html.AppendLine("<head><style>table {background:white;border-collapse: collapse;width: 100%;},th{background:#4CAF50;}, td {  text-align: left;padding: 10px;background:#fafafa;}tr:nth-child(even){background-color: #f2f2f2}th {background-color: #4CAF50;color: white;}</style></head>");


                html.AppendLine("<table border='1'><tr><th><center><h3>SALES REPORT</h3></center></th></tr> </table> ");

               // html.AppendLine("<table>");
               // html.AppendLine("<tr><td></td><td><h3>GreenCare POS</h3></td></tr>");
               // html.AppendLine("<tr><td></td><td></td></tr>");
               
                //html.AppendLine("</table>");
                html.AppendLine("<tr>");
                html.AppendLine("<table border='0'><tr><td></td><td></td>");
                html.AppendLine("<tr>");
                html.AppendLine("<td>No.</td><td>Item Name</td><td>Quantity</td><td>Total</td>");
                html.AppendLine("<tr>");
                int i = 0;
                int sum = 0;
                while (read.Read())
                {
                    i++;
                    sum += int.Parse(read.GetString(2));
                    html.AppendLine("<tr>");
                    html.AppendLine("<td>" + i + "</td>");
                    html.AppendLine("<td>" + read.GetString(0) + "</td>");
                    html.AppendLine("<td>" + read.GetString(1) + "</td>");
                    html.AppendLine("<td>" + read.GetString(2) + "</td>");
                    html.AppendLine("</tr>");
                }
                html.AppendLine("<tr><td></td><td></td><td>Grand Total</td><td>"+sum+"</td></tr>");
                webBrowser1.DocumentText = html.ToString();

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        private void SalesReport_Load(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
            HorsePower.FillCombo(comboBox1, "SELECT `Name` FROM `itemsmenu` WHERE 1");
            //HorsePower.FillCombo(comboBox2, "SELECT `Username` FROM `login2` WHERE 1");
            HorsePower.FillCombo(comboBox2, "SELECT CONCAT(FirstName,LastName) FROM workers;");


        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintDialog();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintPreviewDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Text.Equals("All Sales"))
            {
                generateReport();
                single.Visible = false;
                range.Visible = false;
                peritem.Visible = false;
                perwaiter.Visible = false;
            }
            if (treeView1.SelectedNode.Text.Equals("Sales Per Day"))
            {
               single.Visible = true;
                range.Visible = false;
                peritem.Visible = false;
                perwaiter.Visible = false;
            }
            if (treeView1.SelectedNode.Text.Equals("Range Sales"))
            {
                range.Visible = true;
                single.Visible = false;
                peritem.Visible = false;
                perwaiter.Visible = false;
            }
            if (treeView1.SelectedNode.Text.Equals("Sales Per Item"))
            {
                peritem.Visible = true;
                single.Visible = false;
                range.Visible = false;
                perwaiter.Visible = false;
            }
            if (treeView1.SelectedNode.Text.Equals("Sales Per Waiter"))
            {
                single.Visible = false;
                range.Visible = false;
                peritem.Visible = false;
                perwaiter.Visible = true;
            }
            
            //Sales Per Waiter
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalesPerday(dateTimePicker1.Text);
            single.Visible = false;
        }

        private void SalesPerday(string text)
        {
            try
            {
                String SQL = "SELECT  `ItemName`, `Quantity`, `Total` FROM `sales` WHERE `Date` = '"+text+"'";
                 MySqlCommand cmd = new MySqlCommand(SQL, HorsePower.OpenConnection());
                MySqlDataReader read = cmd.ExecuteReader();
                var html = new StringBuilder();
                html.AppendLine("<html><body>");
                html.AppendLine("<head><style>table {background:white;border-collapse: collapse;width: 100%;},th{background:#4CAF50;}, td {  text-align: left;padding: 10px;background:#fafafa;}tr:nth-child(even){background-color: #f2f2f2}th {background-color: #4CAF50;color: white;}</style></head>");


                html.AppendLine("<table border='1'><tr><th><center><h2>SALES REPORT<h2></center></th> </tr> </table> ");

                // html.AppendLine("<table>");
                // html.AppendLine("<tr><td></td><td><h3>GreenCare POS</h3></td></tr>");
                // html.AppendLine("<tr><td></td><td></td></tr>");

                // html.AppendLine("</table>");
                html.AppendLine("<tr>");
                html.AppendLine("<table border='0'><tr><td></td><td></td>");
                html.AppendLine("<tr>");
                html.AppendLine("<td>No.</td><td>ItemName</td><td>Quantity</td><td>Total</td>");
                html.AppendLine("<tr>");
                int i = 0;
                int sum = 0;
                while (read.Read())
                {
                    i++;
                    sum += int.Parse(read.GetString(2));
                    html.AppendLine("<tr>");
                    html.AppendLine("<td>" + i + "</td>");
                    html.AppendLine("<td>" + read.GetString(0) + "</td>");
                    html.AppendLine("<td>" + read.GetString(1) + "</td>");
                    html.AppendLine("<td>" + read.GetString(2) + "</td>");
                    html.AppendLine("</tr>");
                }
                html.AppendLine("<tr><td></td><td></td><td>Grand Total</td><td>" + sum + "</td></tr>");
                webBrowser1.DocumentText = html.ToString();

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadRange(dateTimePicker2.Text,dateTimePicker3.Text);
            range.Visible = false;
        }

        private void LoadRange(string text1, string text2)
        {

                try
                {
                    String SQL = "SELECT  `ItemName`, `Quantity`, `Total` FROM `sales` WHERE `Date` BETWEEN  '" + text1 + "' AND '"+text2+"'";
                      MySqlCommand cmd = new MySqlCommand(SQL, HorsePower.OpenConnection());
                    MySqlDataReader read = cmd.ExecuteReader();
                    var html = new StringBuilder();
                    html.AppendLine("<html><body>");
                    html.AppendLine("<head><style>table {background:white;border-collapse: collapse;width: 100%;},th{background:#4CAF50;}, td {  text-align: left;padding: 10px;background:#fafafa;}tr:nth-child(even){background-color: #f2f2f2}th {background-color: #4CAF50;color: white;}</style></head>");


                    html.AppendLine("<table border='1'><tr><th><center><h3>SALES REPORT</h3></center></th> </tr> </table> ");

                    // html.AppendLine("<table>");
                    // html.AppendLine("<tr><td></td><td><h3>GreenCare POS</h3></td></tr>");
                    // html.AppendLine("<tr><td></td><td></td></tr>");

                    // html.AppendLine("</table>");
                    html.AppendLine("<tr>");
                    html.AppendLine("<table border='0'><tr><td></td><td></td>");
                    html.AppendLine("<tr>");
                    html.AppendLine("<td>No.</td><td>ItemName</td><td>Quantity</td><td>Total</td>");
                    html.AppendLine("<tr>");
                    int i = 0;
                    int sum = 0;
                    while (read.Read())
                    {
                        i++;
                        sum += int.Parse(read.GetString(2));
                        html.AppendLine("<tr>");
                        html.AppendLine("<td>" + i + "</td>");
                        html.AppendLine("<td>" + read.GetString(0) + "</td>");
                        html.AppendLine("<td>" + read.GetString(1) + "</td>");
                        html.AppendLine("<td>" + read.GetString(2) + "</td>");
                        html.AppendLine("</tr>");
                    }
                    html.AppendLine("<tr><td></td><td></td><td>Grand Total</td><td>" + sum + "</td></tr>");
                    webBrowser1.DocumentText = html.ToString();

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }

        private void button3_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text.Equals(""))
            {
                MessageBox.Show("Please Choose Item ","Green Care POS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                LoadPerItem(comboBox1.Text);
                peritem.Visible = false;
            }
        }

        private void LoadPerItem(string text)
        {
            try
            {
                String SQL = "SELECT  `ItemName`, `Quantity`, `Total` FROM `sales` WHERE `ItemName` = '" + text + "'";
                  MySqlCommand cmd = new MySqlCommand(SQL, HorsePower.OpenConnection());
                MySqlDataReader read = cmd.ExecuteReader();
                var html = new StringBuilder();
                html.AppendLine("<html><body>");
                html.AppendLine("<head><style>table {background:white;border-collapse: collapse;width: 100%;},th{background:#4CAF50;}, td {  text-align: left;padding: 10px;background:#fafafa;}tr:nth-child(even){background-color: #f2f2f2}th {background-color: #4CAF50;color: white;}</style></head>");


                html.AppendLine("<table border='1'><tr><th><center><h2>SALES REPORT</h3></center></th> </tr> </table> ");

                html.AppendLine("<table>");
                // html.AppendLine("<tr><td></td><td><h3>GreenCare POS</h3></td></tr>");
                // html.AppendLine("<tr><td></td><td></td></tr>");

                html.AppendLine("</table>");
                html.AppendLine("<tr>");
                html.AppendLine("<table border='0'><tr><td></td><td></td>");
                html.AppendLine("<tr>");
                html.AppendLine("<td>No.</td><td>ItemName</td><td>Quantity</td><td>Total</td>");
                html.AppendLine("<tr>");
                int i = 0;
                int sum = 0;
                while (read.Read())
                {
                    i++;
                    sum += int.Parse(read.GetString(2));
                    html.AppendLine("<tr>");
                    html.AppendLine("<td>" + i + "</td>");
                    html.AppendLine("<td>" + read.GetString(0) + "</td>");
                    html.AppendLine("<td>" + read.GetString(1) + "</td>");
                    html.AppendLine("<td>" + read.GetString(2) + "</td>");
                    html.AppendLine("</tr>");
                }
                html.AppendLine("<tr><td></td><td></td><td>Grand Total</td><td>" + sum + "</td></tr>");
                webBrowser1.DocumentText = html.ToString();

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Loadbyworkers(comboBox2.Text);
            perwaiter.Visible = false;
        }

        private void Loadbyworkers(string text)
        {
            try
            {
                String SQL = "SELECT  `ItemName`, `Quantity`, `Total` FROM `sales` WHERE `Worker` = '" + text + "'";
                 MySqlCommand cmd = new MySqlCommand(SQL, HorsePower.OpenConnection());
                MySqlDataReader read = cmd.ExecuteReader();
                var html = new StringBuilder();
                html.AppendLine("<html><body>");
                html.AppendLine("<head><style>table {background:white;border-collapse: collapse;width: 100%;},th{background:#4CAF50;}, td {  text-align: left;padding: 10px;background:#fafafa;}tr:nth-child(even){background-color: #f2f2f2}th {background-color: #4CAF50;color: white;}</style></head>");


                html.AppendLine("<table border='0'><tr><th><center><h2>SALES REPORT<h2></center></th> </tr> </table> ");

                html.AppendLine("<table>");
                // html.AppendLine("<tr><td></td><td><h3>GreenCare POS</h3></td></tr>");
                // html.AppendLine("<tr><td></td><td></td></tr>");

                html.AppendLine("</table>");
                html.AppendLine("<tr>");
                html.AppendLine("<table border='0'><tr><td></td><td></td>");
                html.AppendLine("<tr>");
                html.AppendLine("<td>No.</td><td>ItemName</td><td>Quantity</td><td>Total</td>");
                html.AppendLine("<tr>");
                int i = 0;
                int sum = 0;
                while (read.Read())
                {
                    i++;
                    sum += int.Parse(read.GetString(2));
                    html.AppendLine("<tr>");
                    html.AppendLine("<td>" + i + "</td>");
                    html.AppendLine("<td>" + read.GetString(0) + "</td>");
                    html.AppendLine("<td>" + read.GetString(1) + "</td>");
                    html.AppendLine("<td>" + read.GetString(2) + "</td>");
                    html.AppendLine("</tr>");
                }
                html.AppendLine("<tr><td></td><td></td><td>Grand Total</td><td>" + sum + "</td></tr>");
                webBrowser1.DocumentText = html.ToString();

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void range_Paint(object sender, PaintEventArgs e)
        {

        }

        private void salesChartToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //SalesChart s = new SalesChart();
            //s.ShowDialog();
        }
    }
}
