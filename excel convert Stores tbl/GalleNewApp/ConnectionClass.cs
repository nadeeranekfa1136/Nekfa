using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace My_New_Project.Controls
{
    public class ConnectionClass
    {
        public static string conString = "localhost";
        public static string database = "jaelauc";
        public static string password = "Msdh@7#8";
        public static string userName = "root";

        public static MySqlConnection set_dbconnection()
        {
            String my_con = "Host=" + conString + "; UserName=" + userName + "; Port=3306;  Password=" + password + ";Database=" + database + ";";


            MySqlConnection con = new MySqlConnection(my_con);
            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();
                }
                if (conString == null)
                {
                    MessageBox.Show("Cannot Create database access.\nHost Name = " + conString + "\nPlease check the network connection and try again !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception e)
            {
                e.ToString();
                MessageBox.Show("Cannot Create database access.\nHost Name = " + conString + "\nPlease check the network connection and try again !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return con;
        }
    }
}
