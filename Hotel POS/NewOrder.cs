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
    public partial class NewOrder : Form
    {
        string w = "";
        public NewOrder(string name)
        {
            InitializeComponent();
            this.w = name;

        }
        public void PopulateList()
        {
            try
            {
                //Take imagelist for store images to use in listview.
                System.Windows.Forms.ImageList myImageList1 = new ImageList();
                //set the image size of which size images will be displayed in the listview.
                myImageList1.ImageSize = new Size(64, 64);

                //Now add the images into the imageList..
                  MySqlCommand cmd = new MySqlCommand("SELECT * FROM `itemcategories` WHERE 1", HorsePower.OpenConnection());
                MySqlDataReader read = cmd.ExecuteReader();
               // int x = 0;
                while (read.Read())
                {
                    String image = read.GetString(1);
                    String im = image.Replace(@"/", @"\");
                    // x = x + 1;
                    // myImageList1.Images.Add(Image.FromFile(im));
                    // this.listView2.LargeImageList = myImageList1;

                    // this.listView2.Items.Add(read.GetString(0), x);
                }
            }
            catch(Exception ex)

            {
                Console.Write(ex.ToString());
            }

        }
        private void NewOrder_Load(object sender, EventArgs e)
        {
            try
            { 
            //initialize stuff
                 waiter.Text = this.w;
                comboBox3.Text = this.w;
                textBox3.Text = this.w;
            label1.Text =  this.w;
            LoadCategories();
            LoadOrders();
            DateTime D = DateTime.Now;
            date.Text = D.ToString();
            PopulateList();
            //load tables 
            HorsePower.FillCombo(comboBox2, "SELECT `TableNumber` FROM `table` WHERE 1");
            HorsePower.FillCombo(comboBox3, "SELECT CONCAT(FirstName,LastName) FROM workers;");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void Loaditems(string name)
        {
            try
            {
                  dataGridView1.DataSource = HorsePower.Select("SELECT `Name`, `Price` FROM `itemsmenu` WHERE `Type` = '" + name + "'");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Unable To Load data","Error");
                Console.Write(ex);
            }
        }

        private void LoadCategories()
        {
           try
            {
                HorsePower.LoadList(listBox1);

            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            String name = (String)listBox1.SelectedItem;
            Loaditems(name);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                String name = row.Cells[0].Value.ToString();
                String Price = row.Cells[1].Value.ToString();
               // int qty = 1;
                itemname.Text = name;
                itemprice.Text = Price;
                itemqty.Text = "1";
                panel6.Visible = true;

                /*try
                {
                    DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                    String name = row.Cells[0].Value.ToString();
                    String Price = row.Cells[1].Value.ToString();
                    int qty = 1;
                    int total = int.Parse(Price) * qty;
                    ListViewItem lv = new ListViewItem(new String[] {name, qty.ToString(), Price, total.ToString() });
                    listView1.Items.Add(lv);
                    //calculate
                    AddTotals();


                }
                catch (Exception ex)
                {
                    AddTotals();
                    Console.Write(ex);

                }
                */
            }
            catch(Exception ex)
            {
                Console.Write("Error Found : "+ex);
            }

        }

        private void AddTotals()
        {
            try
            {

                //do the calculations here 
                int tot = 0;
                int tot2 = 0;
                foreach (ListViewItem item in this.listView1.Items)
                {
                    tot += int.Parse(item.SubItems[1].Text);
                    tot2 += int.Parse(item.SubItems[3].Text);
                }
                qtytotal.Text = tot.ToString();
                Subtotal.Text = tot2.ToString();
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    //place order 
                    //generate the random order number
                    Random r = new Random();
                    int ii = r.Next(0, 50000);
                    String id1 = ii.ToString();
                    DateTime d = DateTime.Now;
                    //add order to db
                    String SQL1 = "INSERT INTO `Orders`(`OrderNumber`,`Date`, `Status`, `Total`, `Waiter`,`TableNumber`) VALUES ('" + id1 + "','" + dateTimePicker1.Text + "','Open','" + Subtotal.Text + "','" + textBox3.Text + "','" + comboBox2.Text + "')";
                   HorsePower.ExecuteSQL(SQL1);
                    MessageBox.Show("Order Posted Successfully", "Green Care POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    foreach (ListViewItem item in this.listView1.Items)
                    {
                       HorsePower.ExecuteSQL("INSERT INTO `OrderInfor`(`OrderNumber`, `ItemName`, `Quantity`, `Price`,`Total`)VALUES('" + id1 + "','" + item.SubItems[0].Text + "','" + item.SubItems[1].Text + "','" + item.SubItems[2].Text + "','" + item.SubItems[3].Text + "')");

                    }

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
                    sb.Append("           DYKAAN HOTEL                       \n");
                    //sb.Append("KIAMBUU                                      \n");
                    sb.Append("         BILLING RECEIPT                       \n");

                    sb.Append("DATE      :" + D.ToString() + "                \n");
                    sb.Append("TELL NO   :                                    \n");
                    sb.Append("ADDRESS   : 386-30400                          \n");
                    sb.Append("RECEIPTNO : " + receipt.ToString() + "         \n");
                    sb.Append("WAITER    : " + comboBox3.Text + "             \n");

                    sb.Append("           CUSTOMER BILL RECEIPT               \n");
                    sb.Append("_______________________________________________\n");
                    // sb.Append("No     Name       Quantity      Price     Total\n");
                    sb.Append("_______________________________________________\n");
                    sb.Append("          ITEMS LISTS                          \n");
                    sb.Append("_______________________________________________\n");

                    foreach (ListViewItem item in listView1.Items)
                    {
                        i = i + 1;
                        sb.Append(i.ToString() + "." + "     " + item.SubItems[0].Text + "        " + item.SubItems[1].Text + " X   " + item.SubItems[2].Text + "       " + item.SubItems[3].Text + "\n");
                    }
                    sb.Append("_______________________________________________\n");
                    sb.Append("Servered By  : " + comboBox3.Text + "          \n");
                    sb.Append("Table Number : " + comboBox2.Text + "          \n");
                    sb.Append("_______________________________________________\n");
                    sb.Append("            Total Bill  : " + Subtotal.Text + "\n");
                    sb.Append("            Total Items : " + Subtotal.Text + "\n");
                    sb.Append("                 Mode   : Cash                 \n");
                    sb.Append("_______________________________________________\n");
                    sb.Append("   Come in as Guest Leave As Family           \n");
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
                    listView1.Items.Clear();
                    Subtotal.Text = "";
                    qtytotal.Text = "";
                    comboBox2.Text = "";
                    comboBox3.Text = "";
                    LoadOrders();
                }
                else
                {

                    //generate the random order number
                    Random r = new Random();
                    int i = r.Next(0, 50000);
                    String id = i.ToString();
                    DateTime d = DateTime.Now;
                    //add order to db
                    String SQL = "INSERT INTO `Orders`(`OrderNumber`,`Date`, `Status`, `Total`, `Waiter`,`TableNumber`) VALUES ('" + id + "','" + dateTimePicker1.Text + "','Open','" + Subtotal.Text + "','" +textBox3.Text + "','" + comboBox2.Text + "')";
                   HorsePower.ExecuteSQL(SQL);
                    MessageBox.Show("Order Posted Successfully", "Green Care POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    foreach (ListViewItem item in this.listView1.Items)
                    {
                        HorsePower.ExecuteSQL("INSERT INTO `OrderInfor`(`OrderNumber`, `ItemName`, `Quantity`, `Price`,`Total`)VALUES('" + id + "','" + item.SubItems[0].Text + "','" + item.SubItems[1].Text + "','" + item.SubItems[2].Text + "','" + item.SubItems[3].Text + "')");

                    }
                    LoadOrders();
                    listView1.Items.Clear();
                    Subtotal.Text = "";
                    qtytotal.Text = "";
                    comboBox2.Text = "";
                    comboBox3.Text = "";
                }
                }
            catch(Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
           // groupBox3.Visible = true;
            /*ListViewItem item = this.listView1.SelectedItems[0];
            String qty = item.SubItems[0].Text.ToString();*/

        }
        int i = 0;
        private void button2_Click_1(object sender, EventArgs e)
        {
          
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            try
            {
                int total = int.Parse(itemprice.Text) * int.Parse(itemqty.Text);
                ListViewItem lv = new ListViewItem(new String[] { itemname.Text, itemqty.Text,itemprice.Text, total.ToString() });
                listView1.Items.Add(lv);
                //calculate
                AddTotals();
                panel6.Visible = false;
                dataGridView1.Enabled = true;

            }
            catch(Exception ex)
            {
                 AddTotals();
                Console.Write(ex);

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                String Quantity = this.listView1.SelectedItems[0].SubItems[1].Text;
                String Price = this.listView1.SelectedItems[0].SubItems[2].Text;
                if (int.Parse(textBox2.Text)< int.Parse(Quantity))
                {
                    int tot = int.Parse(Quantity) -  int.Parse(textBox2.Text) ;
                    int final = int.Parse(Price) * tot;
                    this.listView1.SelectedItems[0].SubItems[1].Text = tot.ToString();
                    this.listView1.SelectedItems[0].SubItems[3].Text = final.ToString();
                    }
                else
                {
                    int tot = int.Parse(textBox2.Text) - int.Parse(Quantity);
                    int final = int.Parse(Price) * tot;
                    this.listView1.SelectedItems[0].SubItems[1].Text = tot.ToString();
                    this.listView1.SelectedItems[0].SubItems[3].Text = final.ToString();
                   }
                AddTotals();
            }
            catch (Exception ex)
            {
               // groupBox3.Visible = false;
                Console.Write(ex);

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // groupBox3.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            { 
            listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);
            AddTotals();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in this.listView1.Items)
                {
                    HorsePower.ExecuteSQL("INSERT INTO `sales`(`Worker`,`Date`,`ItemName`,`Quantity`, `Price`,`Total`) VALUES ('"+textBox3.Text+"','" + saledate.Text + "','" + item.SubItems[0].Text + "','" + item.SubItems[1].Text + "','" + item.SubItems[2].Text + "','" + item.SubItems[3].Text + "')");
                  

                }
                MessageBox.Show("Hotel Sale Information Saved Successfully ", "Sale Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LoadOrders()
        {
            String s = "Open";
            try
            {
                  dataGridView2.DataSource = HorsePower.Select("SELECT `OrderNumber`,  `Status`, `Total` FROM `orders` WHERE `Status` = '" +s + "' AND `Waiter` = '" + comboBox3.Text + "'");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Unable To Load data", "Error");
                Console.Write(ex);
            }
        }
private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                  dataGridView2.DataSource = HorsePower.Select("SELECT `OrderNumber`,  `Status`, `Total` FROM `orders` WHERE `Status` = '" + comboBox1.Text + "' AND `Waiter` = '"+this.w+"'");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Unable To Load data", "Error");
                Console.Write(ex);
            }
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
           /* if (e.Button == MouseButtons.Left)
            {*/
                
        }

        private void closeOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SaveSale(string on)
        {
            try
            {
                //loop through the order
                 MySqlCommand cmd = new MySqlCommand("SELECT `ItemName`, `Quantity`, `Price`, `Total` FROM `orderinfor` WHERE `OrderNumber` = '" + on + "'", HorsePower.OpenConnection());
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    //insert the sales table
                  HorsePower.ExecuteSQL("INSERT INTO `sales`(`Worker`,`Date`,`ItemName`,`Quantity`, `Price`,`Total`) VALUES ('" + comboBox3.Text + "','" + date.Text + "','" + read.GetString(0) + "','" + read.GetString(1) + "','" + read.GetString(2) + "','" + read.GetString(3) + "')");
                }
                MessageBox.Show("Hotel Sale Information Saved Successfully ", "Sale Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);


        }
        public void DeleteOrders(String q1,String q2)
        {
            try
            { 
            //delete orders
            HorsePower.ExecuteSQL(q1);

            //delete order infor
            HorsePower.ExecuteSQL(q2);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in this.listView2.SelectedItems)
            {
                //MessageBox.Show();
               
                     dataGridView1.DataSource = HorsePower.Select("SELECT `Name`, `Price` FROM `itemsmenu` WHERE `Type` = '" + item.Text.ToString() + "' ");
                
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Unable To Load data", "Error");
                Console.Write(ex);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*try
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                String name = row.Cells[0].Value.ToString();
                String Price = row.Cells[1].Value.ToString();
                int qty = 1;
                itemname.Text = name;
                itemprice.Text = Price;
                itemqty.Text = "1";
                //dataGridView1.Enabled = false;

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }*/
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            panel6.Visible = false;
            dataGridView1.Enabled = true;

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
                     }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try

            {
                 dataGridView1.DataSource = HorsePower.Select("SELECT `Name`, `Price` FROM `itemsmenu` WHERE `Name` LIKE '" + textBox2.Text + "%'");


            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

        }

        private void Subtotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime dd = DateTime.Now;
                label16.Text ="Today : "+dd.ToString();
            }
            catch (Exception ex)
            {
                Console.Write(ex);

            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                String name = row.Cells[0].Value.ToString();
                String Price = row.Cells[1].Value.ToString();
               // int qty = 1;
                itemname.Text = name;
                itemprice.Text = Price;
                itemqty.Text = "1";
                panel6.Visible = true;
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
                //then print receipt
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
                sb.Append("           DYKAAN HOTEL                       \n");
                //sb.Append("KIAMBUU                                      \n");
                sb.Append("         BILLING RECEIPT                       \n");

                sb.Append("DATE      :" + D.ToString() + "                \n");
                sb.Append("TELL NO   :                                    \n");
                sb.Append("ADDRESS   : 386-30400                          \n");
                sb.Append("RECEIPTNO : " + receipt.ToString() + "         \n");
                sb.Append("WAITER    : " + comboBox3.Text + "             \n");

                sb.Append("           CUSTOMER BILL RECEIPT               \n");
                sb.Append("_______________________________________________\n");
                // sb.Append("No     Name       Quantity      Price     Total\n");
                sb.Append("_______________________________________________\n");
                sb.Append("          ITEMS LISTS                          \n");
                sb.Append("_______________________________________________\n");
            
                foreach (ListViewItem item in listView1.Items)
                {
                    i = i + 1;
                    sb.Append(i.ToString() + "." + "     " + item.SubItems[0].Text + "        " + item.SubItems[1].Text + " X   " + item.SubItems[2].Text + "       " + item.SubItems[3].Text + "\n");
                }
                sb.Append("_______________________________________________\n");
                sb.Append("Servered By  : " + comboBox3.Text + "          \n");
                sb.Append("Table Number : " + comboBox2.Text + "          \n");
                sb.Append("_______________________________________________\n");
                sb.Append("            Total Bill  : " + Subtotal.Text + "\n");
                sb.Append("            Total Items : " + Subtotal.Text + "\n");
                sb.Append("                 Mode   : Cash                 \n");
                sb.Append("_______________________________________________\n");
                sb.Append("   Come in as Guest Leave As Family           \n");
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
                listView1.Items.Clear();
                Subtotal.Text = "";
                qtytotal.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                LoadOrders();
           
        }
        private void SaveSale(string on, string waiter)
        {
            try
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
            catch(Exception ex)
            {
                Console.Write(ex);
            }
        }
        private void closeOrderToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView2.SelectedRows[0];

                if (row.Selected)
                {
                    DialogResult res = MessageBox.Show("ARE YOU SURE YOU WANT TO CANCEL ORDERNUMBER : " + row.Cells[0].Value.ToString(), "System Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        String q1 = "DELETE FROM `orders` WHERE `OrderNumber` = '" + row.Cells[0].Value.ToString() + "'";
                        String q2 = "DELETE FROM `orderinfor` WHERE `OrderNumber` = '" + row.Cells[0].Value.ToString() + "'";

                        DeleteOrders(q1, q2);
                        MessageBox.Show("Order Successfully Removed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadOrders();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Row of Item You Wish To Cancel", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            string itm = (String)listBox1.SelectedItem;
            if (checkBox2.Checked == true)
            {
                checkBox2.Text = "Cooked";
                try

                { 
                    dataGridView1.DataSource = HorsePower.Select("SELECT `Name`, `Price` FROM `itemsmenu` WHERE `Status` ='Cooked'");


                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
            else
            {
                try

                {
                    checkBox2.Text= "UnCooked";

               
                dataGridView1.DataSource = HorsePower.Select("SELECT `Name`, `Price` FROM `itemsmenu` WHERE `Status` = 'UnCooked'");
            }
                catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Login l = new Login();
            l.ShowDialog();
           // Application.Run(new Login());
          
        }
    }
}
