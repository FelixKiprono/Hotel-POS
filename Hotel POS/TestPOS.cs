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
    public partial class TestPOS : Form
    {
        public TestPOS()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string GS = Convert.ToString((char)29);
            string ESC = Convert.ToString((char)27);
            Random rno = new Random();
            string receipt = rno.Next(0, 10000).ToString();
            string COMMAND = "";
            COMMAND = ESC + "@";
            COMMAND += GS + "V" + (char)1;
            DateTime D = DateTime.Now;
            //  int i = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append("_______________________________________________\n");
            sb.Append("           GREEN CAFE POS PRINTER TEST         \n");
             sb.Append("DATE      :" + D.ToString() + "                \n");
            sb.Append("SYSTEM    :  GREEN CARE CAFE POS               \n");
            sb.Append("ADDRESS   :  127.0.0.1                         \n");
            sb.Append("RECEIPTNO : " + receipt.ToString() + "         \n");
            sb.Append("DEVELOPER :FELIX K KIPRONO                     \n");
            sb.Append("_______________________________________________\n");
            // sb.Append("No     Name       Quantity      Price     Total\n");
            sb.Append("_______________________________________________\n");
            sb.Append("IF YOU HAVE SEEN THIS RECEIPT IT MEANS PRINTER IS WORKING\n");
            sb.Append("_______________________________________________\n");
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


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
