﻿using MySql.Data.MySqlClient;
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
    public partial class WorkersReport : Form
    {
        public WorkersReport()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintPreviewDialog();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintDialog();
        }
        private void LoadReport()
        {

            try
            {
                String SQL = "SELECT `FirstName`, `LastName`, `IDNumber`, `Gender`, `Telephone`, `Residence`, `WorkPosition`, `Salary`, `PaymentMode`, `WorkingDuration` FROM `workers` WHERE 1";
                MySqlCommand cmd = new MySqlCommand(SQL, HorsePower.OpenConnection());
                MySqlDataReader read = cmd.ExecuteReader();
                var html = new StringBuilder();
                html.AppendLine("<html><body>");
                html.AppendLine("<head><style>table {background:white;border-collapse: collapse;width: 100%;},th{background:#4CAF50;}, td {  text-align: left;padding: 10px;background:#fafafa;}tr:nth-child(even){background-color: #f2f2f2}th {background-color: #4CAF50;color: white;}</style></head>");

                html.AppendLine("<p>");
                html.AppendLine("</p>");
                html.AppendLine("<table border='1'><tr><th><center><h2>WORKERS REPORT<h2></center></th> </tr> </table> ");

                html.AppendLine("<table>");
                // html.AppendLine("<tr><td></td><td><h3>GreenCare POS</h3></td></tr>");
                // html.AppendLine("<tr><td></td><td></td></tr>");

                html.AppendLine("</table>");
                html.AppendLine("<tr>");
                html.AppendLine("<table border='1'><tr><td></td><td></td>");
                html.AppendLine("<tr>");
                html.AppendLine("<th>No.</th><th>FirstName</th><th>LastName</th><th>IDNumber</th><th>Gender</th><th>Mobile Number</th><th>Residence</th><th>Work Position</th><th>Salary</th><th>Payment Mode</th><th>Working Duration</th>");
                html.AppendLine("<tr>");
                int i = 0;
                while (read.Read())
                {
                    i++;
                    html.AppendLine("<tr>");
                    html.AppendLine("<td>" + i + "</td>");
                    html.AppendLine("<td>" + read.GetString(0) + "</td>");
                    html.AppendLine("<td>" + read.GetString(1) + "</td>");
                    html.AppendLine("<td>" + read.GetString(2) + "</td>");
                    html.AppendLine("<td>" + read.GetString(3) + "</td>");
                    html.AppendLine("<td>" + read.GetString(4) + "</td>");
                    html.AppendLine("<td>" + read.GetString(5) + "</td>");
                    html.AppendLine("<td>" + read.GetString(6) + "</td>");
                    html.AppendLine("<td>" + read.GetString(7) + "</td>");
                    html.AppendLine("<td>" + read.GetString(8) + "</td>");
                    html.AppendLine("<td>" + read.GetString(9) + "</td>");

                    html.AppendLine("</tr>");
                }
                webBrowser1.DocumentText = html.ToString();

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void WorkersReport_Load(object sender, EventArgs e)
        {
            LoadReport();

        }
    }
}
