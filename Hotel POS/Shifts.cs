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
    public partial class Shifts : Form
    {
        public Shifts()
        {
            InitializeComponent();
        }
        public void getShifts()
        {
            try
            {
                   dataGridView2.DataSource = HorsePower.Select("SELECT * FROM `Shift` WHERE 1");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        private void Shifts_Load(object sender, EventArgs e)
        {
            try
            {
                getShifts();
                   dataGridView1.DataSource = HorsePower.Select("SELECT `IDNumber`,`FirstName`, `LastName`, `WorkingDuration` FROM `workers` WHERE 1");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        Boolean check(string idnumber,string date)
        {
           
            MySqlCommand cmd = new MySqlCommand("SELECT `IDNumber`, `FullNames`, `Date`, `StartTime`, `StopTime` FROM `shift` WHERE `IDNumber`= '" + idnumber + "' AND `Date` = '" + date + "'", HorsePower.OpenConnection());
            MySqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                return true;
            }
            else
            {

                return false;
            }
           // return false;
        }
        void RemoveShift(string id,string date)
        {
            try
            { 
           HorsePower.ExecuteSQL("DELETE FROM `shift` WHERE `IDNumber`='"+id+"' AND `Date` = '"+date+"'");
            getShifts();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //check if there is an existing shift
           
            try
            { 
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            String number = row.Cells[0].Value.ToString();
            String firstname = row.Cells[1].Value.ToString();
            String lastname = row.Cells[2].Value.ToString();
            DateTime d = DateTime.Now;
            String Time = d.ToString("t");
            if (check(number, dateTimePicker1.Text))
            {
                MessageBox.Show("Sorry But : "+firstname+lastname+" Has Already Started Shift","Hotel POS",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                //insert to db
                String QSL = "INSERT INTO `shift`(`IDNumber`,`FullNames`, `Date`,`StartTime`) VALUES ('" + number + "','" + firstname + lastname + "','" + dateTimePicker1.Text + "','" + Time + "')";

                HorsePower.ExecuteSQL(QSL);

                //get shifts
                getShifts();
            }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            { 
             DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            String number = row.Cells[0].Value.ToString();
            String firstname = row.Cells[1].Value.ToString();
            String lastname = row.Cells[2].Value.ToString();
            String Names = firstname + lastname;
            DateTime d = DateTime.Now;
            String Time = d.ToString("t");
            String SQL = "UPDATE `shift` SET  `StopTime`='"+Time+"' WHERE  `FullNames`='"+Names+"'";

           HorsePower.ExecuteSQL(SQL);

            //get shifts
            getShifts();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            { 
            DataGridViewRow row = this.dataGridView2.SelectedRows[0];
            String number = row.Cells[0].Value.ToString();
            String date = row.Cells[2].Value.ToString();
            RemoveShift(number,date);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}
