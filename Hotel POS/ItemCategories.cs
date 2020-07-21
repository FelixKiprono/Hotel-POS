using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Hotel_POS
{
    public partial class ItemCategories : Form
    {
        public ItemCategories()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if(open.ShowDialog() == DialogResult.OK)
            {
                
                String final = "icons/" + ItemName.Text + ".jpg";
                MoveImage(open.FileName, "icons/" +ItemName.Text+".jpg");
                pictureBox1.ImageLocation = final;
                  }
            
        }

        private void MoveImage(string v, string imageLocation)
        {
            
            File.Copy(v,imageLocation,true);
            
        }
        public void PopulateList()
        {
            //Take imagelist for store images to use in listview.
            System.Windows.Forms.ImageList myImageList1 = new ImageList();
            //set the image size of which size images will be displayed in the listview.
            myImageList1.ImageSize = new Size(64, 64);

            //Now add the images into the imageList..
             MySqlCommand cmd = new MySqlCommand("SELECT * FROM `itemcategories` WHERE 1", HorsePower.OpenConnection());
            MySqlDataReader read = cmd.ExecuteReader();
            int x = 0;
            if(read.Read())
            {
                byte[] pic = read["image"] as byte[] ?? null;
                MemoryStream m = new MemoryStream(pic);
                    x = x + 1;
                //myImageList1.Images.Add(Image.FromStream(m));

                this.listView1.LargeImageList = myImageList1;

                this.listView1.Items.Add(read.GetString(0), x);
            }
           
        }
        private void button4_Click(object sender, EventArgs e)
        {
          

        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                if (ItemName.Text == "")
                {
                    MessageBox.Show("Some  Information Missing", "Point Of Sale", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                  HorsePower.ExecuteSQL("INSERT INTO `ItemCategories`(`ItemName`,`Image`)VALUES ('" + ItemName.Text + "','"+pictureBox1.Image+"')");
                
                    Loads();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public void Loads()
        {
            try
            {

                   dataGridView1.DataSource = HorsePower.Select("SELECT `ItemName` FROM `ItemCategories` WHERE 1");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        private void ItemCategories_Load(object sender, EventArgs e)
        {
            try
            { 
            PopulateList();
            Loads();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}
