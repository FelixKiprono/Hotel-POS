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
    public partial class FinanceStatus : Form
    {
        public FinanceStatus()
        {
            InitializeComponent();
        }
        private void getAccounts()
        {
            try
            {

                  dataGridView2.DataSource = HorsePower.Select("SELECT `AccountNumber`, `AccountName`, `Bank`, `DateOpened`, `Signitory`, `Accounttype` FROM `account` WHERE 1");
                int total = dataGridView2.Rows.Count;
                label1.Text ="( "+total+" )"+ "Total  Accounts ";
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        private void getLog()
        {
            try
            {

                  dataGridView3.DataSource = HorsePower.Select("SELECT `Date`,`Time`, `BankName`, `AccountNumber`, `AccountName`, `Username`,`TransferedAmount`  FROM `transactionlog` WHERE 1");
                int total = dataGridView3.Rows.Count;
                int t = 0;
                label3.Text = " ( " + total + " ) " + " Total Existing Transfer Logs ";
                for(int i=0;i< dataGridView3.Rows.Count;i++)
                {
                    t += int.Parse(dataGridView3.Rows[i].Cells[6].Value.ToString());
                }
                label4.Text = " Total Amount : "+t;

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        private void getAccountAmunt()
        {
            try
            {

                  dataGridView1.DataSource = HorsePower.Select("SELECT `AccountNumber`, `AccountName`,`Amount` FROM `account` WHERE 1");
                int sum = 0;
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    sum += int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                }
                label2.Text = " Total Amount : " + sum;

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        private void FinanceStatus_Load(object sender, EventArgs e)
        {
            getAccounts();
            getLog();
            getAccountAmunt();
        }
    }
}
