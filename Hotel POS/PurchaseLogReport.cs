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
    public partial class PurchaseLogReport : Form
    {
        public PurchaseLogReport()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            SingleLoad(dateTimePicker1.Text);
            single.Visible = false;
        }

        private void SingleLoad(string text)
        {
            try
            {
                String SQL = "SELECT `Name`, `Quantity`, `Price`, `Total` FROM `purchase_log` WHERE `Date` = '"+text+"'";
                 MySqlCommand cmd = new MySqlCommand(SQL,HorsePower.OpenConnection());
                MySqlDataReader read = cmd.ExecuteReader();
                var html = new StringBuilder();
                html.AppendLine("<html><body>");
                html.AppendLine("<head><style>table {background:white;border-collapse: collapse;width: 100%;},th{background:#4CAF50;}, td {  text-align: left;padding: 10px;background:#fafafa;}tr:nth-child(even){background-color: #f2f2f2}th {background-color: #4CAF50;color: white;}</style></head>");


                html.AppendLine("<table border='1'><tr><th><center><h2>PURCHASE LOG REPORT<h2></center></th> </tr> </table> ");

                html.AppendLine("<table>");
                // html.AppendLine("<tr><td></td><td><h3>GreenCare POS</h3></td></tr>");
                // html.AppendLine("<tr><td></td><td></td></tr>");

                html.AppendLine("</table>");
                html.AppendLine("<tr>");
                html.AppendLine("<table border='0'><tr><td></td><td></td>");
                html.AppendLine("<tr>");
                html.AppendLine("<td>No.</td><td>Name</td><td>Quantity</td><td>Price</td><td>Total</td>");
                html.AppendLine("<tr>");
                int i = 0;
                int sum = 0;
                while (read.Read())
                {
                    i++;
                    sum += int.Parse(read.GetString(3));
                    html.AppendLine("<tr>");
                    html.AppendLine("<td>" + i + "</td>");
                    html.AppendLine("<td>" + read.GetString(0) + "</td>");
                    html.AppendLine("<td>" + read.GetString(1) + "</td>");
                    html.AppendLine("<td>" + read.GetString(2) + "</td>");
                    html.AppendLine("<td>" + read.GetString(3) + "</td>");
                    html.AppendLine("</tr>");
                }
                html.AppendLine("<tr><td></td><td></td><td></td><td></td><td></td></tr>");

                html.AppendLine("<tr><td></td><td></td><td></td><td>Grand Total</td><td>" + sum + "</td></tr>");
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
                String SQL = "SELECT `Name`, `Quantity`, `Price`, `Total` FROM `purchase_log` WHERE `Date`  BETWEEN '" + text1+ "' AND '"+text2+"'";
                  MySqlCommand cmd = new MySqlCommand(SQL, HorsePower.OpenConnection());
                MySqlDataReader read = cmd.ExecuteReader();
                var html = new StringBuilder();
                html.AppendLine("<html><body>");
                html.AppendLine("<head><style>table {background:white;border-collapse: collapse;width: 100%;},th{background:#4CAF50;}, td {  text-align: left;padding: 10px;background:#fafafa;}tr:nth-child(even){background-color: #f2f2f2}th {background-color: #4CAF50;color: white;}</style></head>");


                html.AppendLine("<table border='1'><tr><th><center><h2>PURCHASE LOG REPORT<h2></center></th> </tr> </table> ");

                html.AppendLine("<table>");
                // html.AppendLine("<tr><td></td><td><h3>GreenCare POS</h3></td></tr>");
                // html.AppendLine("<tr><td></td><td></td></tr>");

                html.AppendLine("</table>");
                html.AppendLine("<tr>");
                html.AppendLine("<table border='0'><tr><td></td><td></td>");
                html.AppendLine("<tr>");
                html.AppendLine("<td>No.</td><td>Name</td><td>Quantity</td><td>Price</td><td>Total</td>");
                html.AppendLine("<tr>");
                int i = 0;
                int sum = 0;
                while (read.Read())
                {
                    i++;
                    sum += int.Parse(read.GetString(3));
                    html.AppendLine("<tr>");
                    html.AppendLine("<td>" + i + "</td>");
                    html.AppendLine("<td>" + read.GetString(0) + "</td>");
                    html.AppendLine("<td>" + read.GetString(1) + "</td>");
                    html.AppendLine("<td>" + read.GetString(2) + "</td>");
                    html.AppendLine("<td>" + read.GetString(3) + "</td>");
                    html.AppendLine("</tr>");
                }
                html.AppendLine("<tr><td></td><td></td><td></td><td></td><td></td></tr>");

                html.AppendLine("<tr><td></td><td></td><td></td><td>Grand Total</td><td>" + sum + "</td></tr>");
                webBrowser1.DocumentText = html.ToString();

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Text == "Today Purchases")
            {
                single.Visible = true;
            }
            if (treeView1.SelectedNode.Text == "Range Purchases")
            {
                range.Visible = true;
            }
        }

        private void PurchaseLogReport_Load(object sender, EventArgs e)
        {

        }
    }
}
