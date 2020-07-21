using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
namespace Hotel_POS
{
    public partial class EmailSender : Form
    {
        public EmailSender()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String exte = "";
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                exte= Path.GetExtension(open.FileName);
                if (exte.Equals(".rar"))
                {
                    //it is rar
                  listBox1.Items.Add(open.FileName);
                    exte = "";
                }
                else
                {
                    MessageBox.Show("Please Add Your Files to a folder \n Then Compress the folder  \n The Upload The Compress Folder","Mail Master",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    exte = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            catch(Exception ex)
            {
                Console.Write(ex);

            }
        }
        void SendMail()
        {
            try
            {
                //send mail 
                MailMessage Msg = new MailMessage();
                Msg.From = new MailAddress(from.Text);
                Msg.To.Add(recepient.Text);
                Msg.Subject = subject.Text;
                Msg.Body = message.Text;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential(from.Text, password.Text);
                smtp.EnableSsl = true;
                smtp.Send(Msg);
                //save the record in db
                DateTime d = DateTime.Now;
                string add = "INSERT INTO `MailMaster`(`To`, `From`, `Date`, `Subject`, `Message`, `Attachments`) VALUES  ('" + recepient.Text + "','" + from.Text + "','" + d.ToString() + "','" + subject.Text + "','" + message.Text + "','" + listBox1.Items.Count + "')";
                HorsePower.ExecuteSQL(add);
                MessageBox.Show("Email Sent and Saved", "Mail Master", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadMails();
            }
            catch(SmtpException ex)
            {
                MessageBox.Show("Cannot Send E-Mail : "+ex);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(recepient.Text=="" || from.Text == "")
            {
                MessageBox.Show("Cannot Send Email To Blank Recepient/Unknown Sender", "Mail Master",MessageBoxButtons.OK,MessageBoxIcon.Warning);
             }
            else
            {
                SendMail();
            }
        }
        void loadMails()
        {
            try
            {
                  dataGridView1.DataSource = HorsePower.Select("SELECT `To`, `Date`, `Subject`, `Message`, `Attachments` FROM `MailMaster` WHERE 1");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                MessageBox.Show("Error Unable To Load data", "Error");
            }
        }
        private void EmailSender_Load(object sender, EventArgs e)
        {
            loadMails();
        }
    }
}
