using System;
using System.Data;
using System.Configuration;
using System.Web;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

public static class Connection_Main
{
    public static string conString = "localhost";
    public static string database = "wattalauc";
    public static string password = "Msdh@7#8";
    public static string userName = "root";


    public static MySqlConnection set_dbconnection()
    {
        //Provider=MySQLProv; Data Source=nekfaaccount.db.6619256.hostedresource.com; Initial Catalog=nekfaaccount; User ID=nekfaaccount; Password='your password';
        //String my_con = "Server=jawdatabase.db.6619256.hostedresource.com; Port=3306; Database=jawdatabase; Uid=jawdatabase; Pwd=Msdh@7#8";
        //String my_con = "server=localhost; user id=root;Password=Msdh@7#8 ;database=hrdatabase";
        // String my_con = "Host=192.168.1.101; UserName=root; Password=Msdh@7#8 ;Database=baseproduct";
       
        
        //------------------database connection string for server------------------------------------
        String my_con = "Host=" + conString + "; UserName=" + userName + "; Port=3306;  Password=" + password + ";Database=" + database + ";CharSet=utf8;";
        //String my_con = "Host=hrdatabasetest.db.6619256.hostedresource.com; UserName=hrdatabasetest; Port=3306;  Password=Msdh@7#8 ;Database=hrdatabasetest";
       
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
            MessageBox.Show("Cannot Create database access.\nHost Name = "+conString+"\nPlease check the network connection and try again !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //Application.Exit();
        }
        return con;
    }

    public static MySqlConnection set_dbconnection(string conName)
    {
        //Provider=MySQLProv; Data Source=nekfaaccount.db.6619256.hostedresource.com; Initial Catalog=nekfaaccount; User ID=nekfaaccount; Password='your password';
        //String my_con = "Server=jawdatabase.db.6619256.hostedresource.com; Port=3306; Database=jawdatabase; Uid=jawdatabase; Pwd=Msdh@7#8";
        //String my_con = "server=localhost; user id=root;Password=Msdh@7#8 ;database=hrdatabase";
        // String my_con = "Host=192.168.1.101; UserName=root; Password=Msdh@7#8 ;Database=baseproduct";


        //------------------database connection string for server------------------------------------
        String my_con = "Host=" + conString + "; UserName=" + userName + "; Port=3306;  Password=" + password + ";Database=" + conName + ";CharSet=utf8;";
        //String my_con = "Host=hrdatabasetest.db.6619256.hostedresource.com; UserName=hrdatabasetest; Port=3306;  Password=Msdh@7#8 ;Database=hrdatabasetest";

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
            //Application.Exit();
        }
        return con;
    }


    public static void close_con(MySqlConnection con)
    {
        con.Close();
    }


    public static bool UpdateInternetConnectionString(string orgString)
    {

        try
        {
            MySqlConnection c = set_dbconnection();
            MySqlCommand cm = new MySqlCommand("update tbl_internet set internetString='" + orgString + "'", c);
            cm.ExecuteNonQuery();
            cm.Dispose();
            c.Close();
            return true;
        }
        catch (Exception)
        {
            return false;
        }

    }

    public static MySqlConnection setInternetConnection(string newConString)
    {
        MySqlConnection con = null;
        string my_con = returnInternetConnectionString();
        if (newConString.Equals(my_con))
        {
            con = new MySqlConnection(my_con);
            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return con;
        }
        else
        {
            if (UpdateInternetConnectionString(newConString))
            {
                con = new MySqlConnection(newConString);
                try
                {
                    if (con.State.ToString() != "Open")
                    {
                        con.Open();
                    }
                }
                catch (Exception e)
                {
                    e.ToString();
                }
                return con;
            }
            else
                return null;
        }
    }

    public static string returnInternetConnectionString()
    {
        MySqlConnection con1 = set_dbconnection();
        MySqlCommand cmd = new MySqlCommand("select internetString from tbl_internet", con1);
        DataSet ds = new DataSet();
        MySqlDataAdapter data_adapter = new MySqlDataAdapter(cmd);
        data_adapter.Fill(ds);
        DataTable dt = ds.Tables[0];
        string my_con = "";
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow r in dt.Rows)
            {
                my_con = r["internetString"].ToString();
            }
        }
        cmd.Dispose();
        con1.Close();
        return my_con;
    }

    public static void closeInternetConnection(MySqlConnection con)
    {
        con.Close();
    }

    public static bool setTestingConnection()
    {
        //Provider=MySQLProv; Data Source=nekfaaccount.db.6619256.hostedresource.com; Initial Catalog=nekfaaccount; User ID=nekfaaccount; Password='your password';
        //String my_con = "Server=jawdatabase.db.6619256.hostedresource.com; Port=3306; Database=jawdatabase; Uid=jawdatabase; Pwd=Msdh@7#8";
        //String my_con = "server=localhost; user id=root;Password=Msdh@7#8 ;database=hrdatabase";
        // String my_con = "Host=192.168.1.101; UserName=root; Password=Msdh@7#8 ;Database=baseproduct";


        //------------------database connection string for server------------------------------------
        String my_con = "Host=localhost; UserName=root; Port=3306;  Password=Msdh@7#8 ;Database=jaelauc;";

        MySqlConnection con = new MySqlConnection(my_con);
        try
        {
            if (con.State.ToString() != "Open")
            {
                con.Open();
                return true;
            }
            return true;
        }
        catch (Exception e)
        {
            e.ToString();
            return false;
        }
    }

    public static MySqlConnection SetLocalHostConnection()
    {
        String my_con = "Host=localhost; UserName=root; Port=3306;  Password=Msdh@7#8;Database=" + database + ";CharSet=utf8;";
        MySqlConnection con = new MySqlConnection(my_con);
        try
        {
            if (con.State.ToString() != "Open")
            {
                con.Open();
            }
            if (conString == null)
            {
                MessageBox.Show("Cannot Access Localhost", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        catch (Exception e)
        {
            e.ToString();
            MessageBox.Show("Cannot Access Localhost", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //Application.Exit();
        }
        return con;
    }

}
