using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace My_New_Project.Controls
{
    public class Connection
    {
        public static bool isDuplicate;
        public static string ErrorMessage { set; get; }
        public static DataSet FillDataSetFromLocalHost(string select)
        {
            DataSet dataset = new DataSet();
            try
            {
                MySqlConnection con = ConnectionClass.set_dbconnection();
                MySqlCommand cmd = new MySqlCommand(select, con);
                cmd.CommandTimeout = 1200;
                MySqlDataAdapter data_adapter = new MySqlDataAdapter(cmd);
                data_adapter.Fill(dataset);
                data_adapter.Dispose();

                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return dataset;

        }


        public void UpdateTable(string sql)
        {
            try
            {
                MySqlConnection cn = ConnectionClass.set_dbconnection();
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = cn;
                cmd.CommandText =sql;
                int numRowsUpdated = cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (MySqlException exSql)
            {
                //Console.Error.WriteLine("Error - SafeMySql: SQL Exception: " + query);
                //Console.Error.WriteLine(exSql.StackTrace);
            }
            catch (Exception ex)
            {
                //Console.Error.WriteLine("Error - SafeMySql: Exception: " + query);
                //Console.Error.WriteLine(ex.StackTrace);
            }
        }
        public static DataSet FillDataSet(string select)
        {
            ErrorMessage = null;
            DataSet dataset = new DataSet();
            try
            {
                MySqlConnection con = Connection_Main.set_dbconnection();
                MySqlCommand cmd = new MySqlCommand(select, con);
                cmd.CommandTimeout = 1800;
                MySqlDataAdapter data_adapter = new MySqlDataAdapter(cmd);
                data_adapter.Fill(dataset);
                con.Close();
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                //ErrorForm errorFrm = new ErrorForm(e.Message, select);
                //errorFrm.ShowDialog();
            }
            return dataset;

        }

        public static bool ExecuteUpdateNonQuery(string sql, MySqlConnection connection, MySqlTransaction transaction)
        {
            bool status = false;
            try
            {

                MySqlCommand command = new MySqlCommand(sql, connection, transaction);
                int rowAffected = command.ExecuteNonQuery();
                command.CommandTimeout = 1800;
                // if (rowAffected > 0)
                status = true;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                    isDuplicate = true;
                status = false;
                ErrorMessage = ex.Message;
                //MessageBox.Show(ex.Message);
            }

            return status;
        }

        public static bool ExecuteUpdateNonQueryWithConnection(string sql, MySqlConnection connection)
        {
            bool status = false;
            isDuplicate = false;
            ErrorMessage = "";
            try
            {

                MySqlCommand command = new MySqlCommand(sql, connection);
                int rowAffected = command.ExecuteNonQuery();
                // if (rowAffected > 0)
                status = true;
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show(ex.Message);
                status = false;
                if (ex.Number == 1062)
                {
                    isDuplicate = true;
                }
                else if (ex.Number == 1452)
                ErrorMessage = ex.Message;
            }

            return status;
        }
    }
}
