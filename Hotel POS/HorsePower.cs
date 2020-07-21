using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_POS
{
    public class HorsePower
    {
        public static String ConStr = "";
        public static MySqlConnection con = null;
        public HorsePower()
        {
          
           
        }
        public static MySqlConnection OpenConnection()
        {
            ConStr = File.ReadAllText("connection.settings");
            con = new MySqlConnection(ConStr);
            con.Open();
            return con;
        }
       public static  Boolean ExecuteSQL(String SQL)
        {
            MySqlCommand cmd = new MySqlCommand(SQL, OpenConnection());
           int x =  cmd.ExecuteNonQuery();
            if(x>0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        static public DataTable Select(String SQL)
        {
            MySqlDataAdapter adp = new MySqlDataAdapter(SQL, OpenConnection());
            DataTable tabe = new DataTable();
            adp.Fill(tabe);
            return tabe;
        }
        //this routine fills comobo box
        static public void FillCombo(ComboBox cb,String SQL)
        {
       
                MySqlCommand cmd = new MySqlCommand(SQL,OpenConnection());
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    cb.Items.Add(read.GetString(0));
                }
                con.Close();
         
        }
        static public Boolean ISavailable(String SQL)
        {

            MySqlCommand cmd = new MySqlCommand(SQL, OpenConnection());
            MySqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                con.Close();
                return true;
               
            }
            else
            {
                con.Close();
                return false;
            }
          

        }
        static public List<String> getItemsType()
        {
            List<String> st = new List<String>();
            try
            {
               // V2MySqlServer sql = new V2MySqlServer(Server.getIP(), "root", "", "hotel");
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT `TYPE` FROM ITEMSMENU", OpenConnection());
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    st.Add(read.GetString(0));
                }
                con.Close();
                return st;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        static public void LoadCombo(ComboBox cb)
        {
            try
            {
               // V2MySqlServer sql = new V2MySqlServer(Server.getIP(), "root", "", "hotel");

                MySqlCommand cmd = new MySqlCommand("SELECT `Name` FROM `` WHERE 1", OpenConnection());
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    cb.Items.Add(read.GetString(0));
                }
                con.Close();
            }
            catch(Exception ex)
            {
                Console.Write("Error Located : "+ex);
            }

        }
        static public int Count(String SQL)
        {
            int REC = 0;
            try
            {
               // V2MySqlServer sql = new V2MySqlServer(Server.getIP(), "root", "", "hotel");\


                MySqlCommand cmd = new MySqlCommand(SQL,OpenConnection());
                REC = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                return REC;
            }
            catch(Exception ex)
            {
                Console.Write("Error Located :  "+ex);
                return REC;
            }

        }
        static public void LoadList(ListBox ls)
        {
            try
            {
            //    V2MySqlServer sql = new V2MySqlServer(Server.getIP(), "root", "", "hotel");

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `itemcategories` WHERE 1", OpenConnection());
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    ls.Items.Add(read.GetString(0));

                }
                con.Close();
            }
            catch(Exception ex)
            {
                Console.Write("Error Located  :"+ex);
            }

        }
    }
}
