using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using My_New_Project.Controls;

namespace GalleNewApp
{
    public class CtlClass : Connection
    {
        int propertyID;
        string searchVal;
        private DataRow[] streetRow;
        private DataTable streetFilterTable;
        private DataSet dsTemp;
        private MySqlDataAdapter adapDt;
        private String query;

        public DataTable getStreet()
        {
            query = "select * from tbl_street;";
            DataTable dt = FillDataSet(query).Tables[0];
            return dt;
        }

        public DataTable getDivision()
        {           
            query = "select div_Id from tbl_division order by id asc; ";
            DataTable dt = FillDataSet(query).Tables[0];
            return dt;
        }

        public DataTable FilterStreetUsingDivision(string divId, DataTable streetTable)
        {
            if (divId != "0")
            {
                streetRow = streetTable.Select("divId='" + divId + "'");
                this.createStreetFillterTable();
                DataRow rx = this.streetFilterTable.NewRow();
                if (streetRow.Length > 0)
                {
                    foreach (DataRow r in streetRow)
                    {
                        streetFilterTable.Rows.Add(r["id"], r["street_Id"], r["street_Name"], r["divId"]);
                    }
                }
                return streetFilterTable;
            }
            else
            {
                return streetTable;
            }


        }
        public void createStreetFillterTable()
        {
            streetFilterTable = new DataTable();
            streetFilterTable.Columns.Add("id", typeof(string));
            streetFilterTable.Columns.Add("street_Id", typeof(string));
            streetFilterTable.Columns.Add("street_Name", typeof(string));
            streetFilterTable.Columns.Add("divId", typeof(string));
            streetFilterTable.Rows.Add("1", "---", "[Select]", "0");
        }

        public bool InsertDataFromExcel(DataTable dt)
        {
            MySqlConnection con = null;
            MySqlTransaction trans = null;
            bool flag = false;
            DataTable payDt = null;
            try
            {
                con = Connection_Main.set_dbconnection();
                trans = con.BeginTransaction();

                query = "TRUNCATE table div08new;";
                flag = ExecuteUpdateNonQueryWithConnection(query,con);
                if (flag)
                {
                    
                        //string columnName = "c'" + a + "'";
                        
                        for (int x = 0; x <= dt.Rows.Count-1; x++)
                        {
                            string columnValue = "(";
                            DataRow dr = dt.Rows[x];

                            for (int y = 0; y < dr.ItemArray.Length; y++)
                            {
                                if (y == dr.ItemArray.Length - 1)
                                    columnValue = columnValue +"'"+  (dr[y]).ToString()+"'" ;
                                else
                                    columnValue = columnValue + "'" + (dr[y]).ToString() + "',";
                            }
                            columnValue = columnValue + ")";


                            //for (int a = 0; a < 4; a++)
                            //{
                            //    //if (a ==7)
                            //    //{
                            //    //    string dtt = Convert.ToDateTime((dr[a - 1])).ToString("yyyy-MM-dd");
                            //    //    string date = Convert.ToDateTime(dr[a - 1]).ToShortDateString();
                            //    //    columnValue = columnValue + "'" + dtt + "',";
                            //    //}
                            //    //else
                            //    //{
                            //        //string val = dr[a - 1].ToString().Replace("'", "");
                            //        //if (a == 8)
                            //        //{
                            //        //    columnValue = columnValue + "'" + val + "'";
                            //        //}
                            //        //else
                            //        //{
                            //        //    columnValue = columnValue + "'" + val + "',";
                            //        //}
                            //    //}
                            //}
                            //string bank = dt.Rows[x - 1][2].ToString();
                            //string val = dt.Rows[x - 1][3].ToString().Replace("'", "");
                            //if (dt.Rows[x - 1][2].ToString() == "PEOPLE'S BANK" || dt.Rows[x - 1][2].ToString() == "People's Bank")
                            //    bank = "Peoples Bank";
                           
                            //char val = Convert.ToChar(" ");
                            //char c = Convert.ToChar("'");
                            //if (columnValue.Contains(c))
                            //{
                            //    columnValue = columnValue.Replace(c, val);
                            //}
                            //columnValue = columnValue.TrimStart();
                            //int proID = this.SelectPropertyID(columnValue);
                            query = "insert into div08new values " + columnValue;
                            flag = ExecuteUpdateNonQuery(query, con, trans);
                            if (!flag)
                            {
                                break;
                            }
                            else
                            {

                            }
                        }
                        
                   
                }
            }
            catch (Exception ee)
            {
                flag = false;
            }
            finally
            {
                if (flag)
                    trans.Commit();
                else
                    trans.Rollback();
                con.Close();
            }
            return flag;
        }

        private DataTable CheckAlreadyUpdated(int proID)
        {
            query = "SELECT * from acopy where PropertyID='" + proID + "';";
            DataTable dt = FillDataSet(query).Tables[0];
            return dt;
        }

        private DataTable SelectPaymentDetails(int propID, string date)
        {
            query = "SELECT propertyId,arrease from tbl_payments  WHERE propertyId='" + propID + "' and pay_date >'" + date + "' and pay_type!='Debit';";
            DataTable dt = FillDataSet(query).Tables[0];
            return dt;
        }

        private int SelectPropertyID(string columnValue)
        {
            int Pro=0;
            query = "SELECT id from tbl_property where property_no = '" + columnValue.TrimStart() + "' and division='' and street_Id='';";
            DataTable dt = FillDataSet(query).Tables[0];
            foreach (DataRow r in dt.Rows)
            {
                Pro = int.Parse(r["id"].ToString());  
            }
            return Pro;
        }


        public DataTable SelectInsertedData()
        {
            query = "SELECT * from a WHERE PropertyID=0;";
            DataTable dt = FillDataSet(query).Tables[0];
            return dt;
        }

        public bool updateQuery()
        {
            bool flag = false;
            MySqlConnection con = null;
            MySqlTransaction trans = null;
            DataTable payDt = null;
            try
            {
                con = Connection_Main.set_dbconnection();
                trans = con.BeginTransaction();
               
                query = "UPDATE tbl_loan as l, a_loan_copy as a set l.fromPeriod=a.c7  WHERE l.id=a.c20;";
                flag = ExecuteUpdateNonQuery(query, con, trans);
                if (!flag)
                {
                   
                }
                else
                {

                }
            }
            catch (Exception ee)
            {
                flag = false;
            }
            finally
            {
                if (flag)
                    trans.Commit();
                else
                    trans.Rollback();
                con.Close();
            }
            return flag;
        }

        public DataTable GetDt()
        {
            query = "SELECT * from a_loan_copy;";
            DataTable dt = FillDataSet(query).Tables[0];
            return dt;
        }
    }
}
