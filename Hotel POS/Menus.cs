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
    public partial class Menus : Form
    {
        public string name;
        public string role;
        public Menus(String username, String role)
        {
            InitializeComponent();
            this.name = username;
            this.role = role;
        }

        private void jKBDSJABFToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_Click(object sender, EventArgs e)
        {
       
           
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
           
        }

        private void Menus_Load(object sender, EventArgs e)
        {

            toolStripStatusLabel2.Text = name;
            toolStripStatusLabel3.Text = role;
            label4.Text = "Welcome " + Environment.UserDomainName.ToString() + " To GreenCafe Point Of Sale System";
            if (role == "Cashier")
            {
                panel1.Enabled = true;
                waitress.Enabled = false;
                table.Enabled = false;
                shifts.Enabled = false;
                mail.Enabled = false;
                setprices.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button17.Enabled = true;
               p2.Enabled = true;
                // toolStripMenuItem6.Enabled = false;
                toolStripMenuItem2.Enabled = false;
                managerToolStripMenuItem.Enabled = false;
            }
            if (role == "Waiter")
            {
                p1.Enabled = true;
                toolStripMenuItem6.Enabled = false;
                toolStripMenuItem2.Enabled = false;
                managerToolStripMenuItem.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button17.Enabled =false;
            }
            if (role == "Kitchen")
            {
              
                button1.Enabled = false;
                button2.Enabled = true;
                 button3.Enabled = false;
                button4.Enabled = false;
                button17.Enabled = false;
                // p1.Enabled = true;
                // toolStripMenuItem6.Enabled = false;
                toolStripMenuItem2.Enabled = false;
                toolStripMenuItem6.Enabled = false;
                managerToolStripMenuItem.Enabled = false;
                /*
                p2.Enabled = true;
                toolStripMenuItem6.Enabled = false;
                toolStripMenuItem2.Enabled = false;
                managerToolStripMenuItem.Enabled = false;*/
            }
            if (role=="Admin")
            {
                p1.Enabled = true;
                p2.Enabled = true;
                p3.Enabled = true;

            }
            if (role == "Manager")
            {
                p1.Enabled = true;
                p2.Enabled = true;
                p3.Enabled = true;

            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void systemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit a = new Exit();
            a.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Tables t = new Tables();
            t.ShowDialog();
        }

        private void patientInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Workers w = new Workers();
            w.ShowDialog();
        }

        private void floatOpeningBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpeningBalance o = new OpeningBalance();
            o.ShowDialog();
        }

        private void shiftsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shifts s = new Shifts();
            s.ShowDialog();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesReport s = new SalesReport();
            s.ShowDialog();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockReport s = new StockReport();
            s.ShowDialog();
        }

        private void suppliersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SuppliersReport s = new SuppliersReport();
            s.ShowDialog();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewHotelMenu v = new ViewHotelMenu();
            v.ShowDialog();
        }

        private void viewOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderReport or = new OrderReport();
            or.ShowDialog();
        }

        private void viewWorkersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkersReport w = new WorkersReport();
            w.ShowDialog();
        }

        private void viewOpeningBalancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewOpeningBalance o = new ViewOpeningBalance();
            o.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NewStock n = new NewStock();
            n.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Categories c = new Categories();
            c.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Suppliers s = new Suppliers();
            s.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            KitchenStock d = new KitchenStock();
            d.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewMenu n = new NewMenu();
            n.ShowDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ItemCategories i = new ItemCategories();
            i.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OrdersApproval o = new OrdersApproval();
            o.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewOrder n = new NewOrder(toolStripStatusLabel2.Text);
            n.ShowDialog();
        }

        private void addAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void loginLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
          DialogResult res =   MessageBox.Show("Are You Sure You Want To Logout From This Account", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.Hide();
                Login l = new Login();
                l.Show();
            }




        }

        private void aboutSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                //  V2.V2Encrypter v = new V2.V2Encrypter();
                //String Val = v.MD5Encrypt(DateTime.Now.ToString());
                //V2.Backup bc = new V2.Backup(@"backup" + "\\Greencare_HotelPOS_" + Val + "_Backup" + ".sql", Server.getIP(), "root", "", "hotel");
                //MessageBox.Show("SYSTEM MAIN DATABASE BACKUP COMPLETED SUCCESSFULLY ", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   }
            catch (Exception ex)
            {
                Console.Write(ex + "Backup Was Unable To Complete ");
            }
            this.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SalesReport s = new SalesReport();
            s.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SuppliersReport s = new SuppliersReport();
            s.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            WorkersReport w = new WorkersReport();
            w.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            PurchaseLogReport p = new PurchaseLogReport();
            p.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Orders o = new Orders();
            o.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime dd = DateTime.Now;
                toolStripStatusLabel1.Text = "Today : " + dd.ToString();
            }
            catch(Exception ex)
            {
                Console.Write(ex);
                    
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
           
        }

        private void endDaySummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EndDay ed = new EndDay();
            ed.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
           UpdateStock ed = new UpdateStock("");
            ed.ShowDialog();
        }

        private void changeAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
            //    V2.V2Encrypter v = new V2.V2Encrypter();
            //    String Val = v.MD5Encrypt(DateTime.Now.ToString());
            //    V2.Backup bc = new V2.Backup(@"backup" + "\\Greencare_HotelPOS_" + Val + "_Backup" + ".sql", Server.getIP(), "root", "", "hotel");
            //    MessageBox.Show("SYSTEM MAIN DATABASE BACKUP COMPLETED SUCCESSFULLY ", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                Console.Write(ex + "Backup Was Unable To Complete ");
            }
            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addAccountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddAccount a = new AddAccount();
            a.ShowDialog();
        }

        private void loginLogToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoginLog l = new LoginLog();
            l.ShowDialog();
        }

        private void button12_MouseClick(object sender, MouseEventArgs e)
        {
            
                contextMenuStrip1.Show(MousePosition.X,MousePosition.Y);
            
        }

        private void viewCurrentStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockReport s = new StockReport();
            s.ShowDialog();
        }

        private void viewUsedStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewUsedStock v = new ViewUsedStock();
            v.ShowDialog();
        }

        private void endDaySummaryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            EndDay ed = new EndDay();
            ed.ShowDialog();
        }

        private void createAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DefineAccounts de = new DefineAccounts();
            de.ShowDialog();
        }

        private void transferMoneyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransferMoney tm = new TransferMoney();
            tm.ShowDialog();
        }

        private void chartOfAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinanceStatus f = new FinanceStatus();
            f.ShowDialog();
        }

        private void accountsStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            //pictureBox4.BorderStyle = BorderStyle.FixedSingle;

        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
         //   pictureBox4.BorderStyle = BorderStyle.None;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
         //   pictureBox4.BorderStyle = BorderStyle.FixedSingle;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Exit a = new Exit();
            a.ShowDialog();
        }

        private void mailMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailSender em = new EmailSender();
            em.ShowDialog();
        }

        private void setChangePricesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePrices em = new ChangePrices();
            em.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void testPrinterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestPOS ts = new TestPOS();
            ts.ShowDialog();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login a = new Login();
            a.ShowDialog();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().ShowDialog();
        }
    }
}
