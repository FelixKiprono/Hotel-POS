using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//namespace
namespace Hotel_POS
{

    public class Server
    {
        public static string getIP()
        {
            try
            {
                IEnumerable<string> servers = System.IO.File.ReadLines("Serverconfig.txt");
                foreach (string item in servers)
                {
                    return item;

                }
               
            }
            catch(FileNotFoundException fe)
            {

                Console.Write(fe);
                MessageBox.Show("Configuration File Not Found In The Root Directory FelixWizard Will Autocreate","Configuration Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
                string path = "Serverconfig.txt";
                if(!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("localhost");
                        MessageBox.Show("Configuration File Created Successfully By Wizard","Configuraton Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                } 
            }
            return "127.0.0.1";
        }



    }
}
