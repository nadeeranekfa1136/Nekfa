using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

namespace GalleNewApp
{
    public partial class Form1 : Form
    {
        OleDbConnection oledbConn;
        string path;
        DataTable div;
        DataTable street;
        CtlClass cClz;
        DataRow dr;
        private DataTable streetTable,streetFilterTable;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {           
            cClz = new CtlClass();
        }

        private void fillDetails()
        {
           
        }       

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string folderPath = "";
            openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = openFileDialog1.FileName;
                textBox1.Text = folderPath;
            }
        }

        private void btnSaveDB_Click(object sender, EventArgs e)
        {

            lblVisible.Text = "Processing Transactions..Don't Click any Button..!!";

            if (textBox1.Text == "")
            {
                MessageBox.Show("Please select excell sheet path.");
            }
            else
            {
                this.GenerateExcelData();
            }
           
        }


        private void GenerateExcelData()
        {
            string sql;
            string date1;
            try
            {               
                string path = System.IO.Path.GetFullPath(textBox1.Text.ToString());//Server.MapPath("~/os.xlsx"));
               
                if (Path.GetExtension(path) == ".xls")
                {
                    oledbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"");
                }
                else if (Path.GetExtension(path) == ".xlsx")
                {
                    oledbConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';");
                }
                oledbConn.Open();
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataAdapter oleda = new OleDbDataAdapter();
                DataSet ds = new DataSet();
                cmd.Connection = oledbConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM [Sheet1$]";
                oleda = new OleDbDataAdapter(cmd);
                //oleda.TableMappings.Add("Table", "a");
                oleda.Fill(ds);

                string id;
                string arr;
               


                int intRw = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    intRw = intRw + 1;
                    if (intRw == 240)
                    {
                        string a = "a";
                    }


                    //DataTable dt = new DataTable();
                    //dt = cClz.GetDt();

                   // string a = "";

                    MySqlConnection con = Connection_Main.set_dbconnection();
                    MySqlTransaction trans = con.BeginTransaction();
                    bool state = false;
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        id = r["vote"].ToString();
                        arr = r["amount"].ToString();
                        if (arr == "")
                        {
                            arr = "0.00";
                        }
                       

                        state = false;
                        sql = "insert INTO vote(vote,amount) ";
                        sql = sql + "values ('" + id + "','" + arr + "');";
                        MySqlCommand cmmd = new MySqlCommand(sql, con, trans);
                        cmmd.ExecuteNonQuery();
                        state = true;
                    }
           trans.Commit();

                }

            }
            catch (Exception ex)
            {
                string strErMsg = ex.Message.ToString().Trim();

            }
            finally
            {
                oledbConn.Close();
                
            }


        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void liststreetname_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridResult.DataSource = null;
            lblError.Text = "";
            textBox1.Clear();
        }

        //private void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    UpdateReservationTable();
        //}

        //private void UpdateReservationTable()
        //{
        //    bool state = false;
        //    List<string> ledgerID = new List<string>;
        //    try
        //    {
        //        MySqlConnection con = Connection_Main.set_dbconnection();
        //        con.Open();
        //        strSql = "SELECT ledgerId FROM tbl_credit_reservation1;";
        //        MySqlCommand command = new MySqlCommand(strSql, this.mySqlCon);
        //        MySqlDataAdapter da = new MySqlDataAdapter(command);
        //        ds = new DataSet();
        //        da.Fill(ds, "LedgerIDList");
        //        dt = ds.Tables["LedgerIDList"];
        //        if (dt.Rows.Count > 0)
        //        {
        //            foreach (DataRow dtRow in dt.Rows)
        //            {
        //                ledgerID.Add(dtRow["ledgerId"].ToString());
        //            }
        //            state = true;
        //        }
        //        if (state)
        //        {
        //            foreach (string id in ledgerID)
        //            {
        //            strSql = "SELECT id FROM tbl_expence_ledger WHERE ledgerCode=@id;";
        //            MySqlCommand command = new MySqlCommand(strSql, this.mySqlCon);
        //            MySqlDataAdapter da = new MySqlDataAdapter(command);
        //            ds = new DataSet();
        //            da.Fill(ds, "id");
        //            dt = ds.Tables["id"];
        //            foreach (DataRow dtRow in dt.Rows)
        //            {
        //                MySqlTransaction trans = con.BeginTransaction();

        //            }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        string strErMsg = ex.Message.ToString().Trim();

        //    }
        //    finally
        //    {
        //       con.Close();
        //    }


        //}
        
    }
}
