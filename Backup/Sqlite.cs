using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace AlphaIMS
{
    class Sqlite
    {
        static string SQLITE_DB = "D:\\Tables\\Table.db";
        static string COLUMNSINFO_TBL_NAME = "ColumnsInfo";
        static string PRODUCTS_TBL_NAME = "Products";
        static string ACCOUNT_TBL_NAME = "Account";
        static string DATA_TBL_NAME = "Data";

        private static SQLiteConnection sqlite_connect = null;
        private static SQLiteCommand sqlite_cmd;

        public static void Open()
        {
            string xmlFile = Application.StartupPath + "\\Setting.xml";
            if (File.Exists(xmlFile))
            {
                XmlDocument doc;
                XmlNode node;

                doc = new XmlDocument();
                doc.Load(xmlFile);
                node = doc.DocumentElement.SelectSingleNode("/Setting/FilePath");
                SQLITE_DB = node.InnerText + "\\Table.db";
            }  

            if (!File.Exists(SQLITE_DB))
            {
                SQLiteConnection.CreateFile(SQLITE_DB);
            }

            sqlite_connect = new SQLiteConnection("Data source=" + SQLITE_DB);

            sqlite_connect.Open();// Open
            sqlite_cmd = sqlite_connect.CreateCommand();//create command

            sqlite_cmd.CommandText = @"CREATE TABLE IF NOT EXISTS " + COLUMNSINFO_TBL_NAME + " (station TEXT, model_number TEXT, customer TEXT, column INTEGER, name TEXT, formula TEXT, min TEXT, max TEXT, readvalue INTEGER)";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = @"CREATE TABLE IF NOT EXISTS " + PRODUCTS_TBL_NAME + " (station TEXT, model_number TEXT, customer TEXT, rows INTEGER, columns INTEGER)";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = @"CREATE TABLE IF NOT EXISTS " + ACCOUNT_TBL_NAME + " (username TEXT, password TEXT)";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = @"CREATE TABLE IF NOT EXISTS " + DATA_TBL_NAME + " (station TEXT, model_number TEXT, customer TEXT, data TEXT, time TEXT)";
            sqlite_cmd.ExecuteNonQuery();
        }

        public static void Close()
        {
            if (sqlite_connect != null)
                sqlite_connect.Close();
        }


        //----------------------------Products Table----------------------------
        public static void InsertProduct(string station, string model_number, string customer, int rows, int columns)
        {     
            sqlite_cmd = sqlite_connect.CreateCommand();//create command
            sqlite_cmd.CommandText = "INSERT INTO " + PRODUCTS_TBL_NAME + " VALUES ('" + station + "','" + model_number + "','" + customer + "','" + rows + "','" + columns + "');";
            sqlite_cmd.ExecuteNonQuery();
        }

        public static int SelectProduct(string station, string model_number, string customer)
        {
            sqlite_cmd = sqlite_connect.CreateCommand();//create command
            sqlite_cmd.CommandText = "SELECT * FROM " + PRODUCTS_TBL_NAME + " WHERE model_number='" + model_number + "' AND customer='" + customer + "' AND station='" + station + "'";

            var result = sqlite_cmd.ExecuteScalar();
            if (result == null)
            {
                return 0;
            }

            return 1;
        }

        public static void UpdateProduct(string station, string model_number, string customer, int rows, int columns)
        {
            sqlite_cmd = sqlite_connect.CreateCommand();//create command
            sqlite_cmd.CommandText = ("UPDATE " + PRODUCTS_TBL_NAME + " SET rows='" + rows + "', columns='" + columns + "' WHERE model_number ='" + model_number + "' AND customer='" + customer + "' AND station='" + station + "'");
            sqlite_cmd.ExecuteNonQuery();
        }

        public static void DeleteProduct(string station, string model_number, string customer)
        {
            sqlite_cmd = sqlite_connect.CreateCommand();//create command
            sqlite_cmd.CommandText = "DELETE FROM " + PRODUCTS_TBL_NAME + " WHERE model_number='" + model_number + "' AND customer='" + customer + "' AND station='" + station + "'";
                          sqlite_cmd.ExecuteNonQuery(); 
        }

        public static void SelectAllStation(ref List<string> stationList)
        {
            sqlite_cmd = sqlite_connect.CreateCommand();//create command
            sqlite_cmd.CommandText = "SELECT DISTINCT station FROM " + PRODUCTS_TBL_NAME;

            using (SQLiteDataReader rdr = sqlite_cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    string station = rdr.GetString(0);
                    stationList.Add(station);
                }
            }
        }

        public static void SelectAllModelNum(string station, ref List<string> modelNumList)
        {
            sqlite_cmd = sqlite_connect.CreateCommand();//create command
            sqlite_cmd.CommandText = "SELECT DISTINCT model_number FROM " + PRODUCTS_TBL_NAME + " WHERE station='" + station + "'";

            using (SQLiteDataReader rdr = sqlite_cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    string model_number = rdr.GetString(0);
                    modelNumList.Add(model_number);
                }
            }
        }

        public static void SelectAllCustomer(string station, string model_number, ref List<string> customerList)
        {
            sqlite_cmd = sqlite_connect.CreateCommand();//create command
            sqlite_cmd.CommandText = "SELECT customer FROM " + PRODUCTS_TBL_NAME + " WHERE model_number='" + model_number + "' AND station='" + station + "'";

            using (SQLiteDataReader rdr = sqlite_cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    string customer = rdr.GetString(0);
                    customerList.Add(customer);
                }
            }
        }

        public static int SelectRowsColumns(string station, string model_number, string customer, ref int rows, ref int columns)
        {
            int result = 0;

            sqlite_cmd = sqlite_connect.CreateCommand();//create command
            sqlite_cmd.CommandText = "SELECT rows, columns FROM " + PRODUCTS_TBL_NAME + " WHERE model_number='" + model_number + "' AND customer='" + customer + "' AND station='" + station + "'";

            using (SQLiteDataReader rdr = sqlite_cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    rows = rdr.GetInt32(0);
                    columns = rdr.GetInt32(1);
                }
            }

            return result;
        }


        //----------------------------Columns Info Table----------------------------
        public static void InsertColumnInfo(string station, string model_number, string customer, int column, TABLECOLUMN tableCol)
        {
            sqlite_cmd = sqlite_connect.CreateCommand();//create command
            sqlite_cmd.CommandText = "INSERT INTO " + COLUMNSINFO_TBL_NAME + " VALUES ('" + station + "','" + model_number + "','" + customer + "','" + column + "','" + tableCol.Name + "','" + tableCol.Formula + "','" + tableCol.Min + "','" + tableCol.Max + "','" + tableCol.Readvalue + "');";
            sqlite_cmd.ExecuteNonQuery();
        }

        public static void UpdateColumnsInfo(string station, string model_number, string customer, int column, TABLECOLUMN tableCol)
        {
            sqlite_cmd = sqlite_connect.CreateCommand();//create command
            sqlite_cmd.CommandText = ("UPDATE " + COLUMNSINFO_TBL_NAME + " SET name='" + tableCol.Name + "', formula='" + tableCol.Formula + "', min='" + tableCol.Min + "', max='" + tableCol.Max + "', readvalue='" + tableCol.Readvalue + "' WHERE model_number ='" + model_number + "' AND customer='" + customer + "' AND station='" + station + "' AND column='" + column + "'");
            sqlite_cmd.ExecuteNonQuery();
        }

        public static void SelectColumnsInfo(string station, string model_number, string customer, ref List<TABLECOLUMN> tableColList)
        {
            TABLECOLUMN tableCol;
            sqlite_cmd = sqlite_connect.CreateCommand();//create command
            sqlite_cmd.CommandText = "SELECT name, formula, min, max, readvalue FROM " + COLUMNSINFO_TBL_NAME + " WHERE station='" + station + "' AND model_number='" + model_number + "' AND customer='" + customer + "' ORDER BY column";
            sqlite_cmd.ExecuteNonQuery();

            using (SQLiteDataReader rdr = sqlite_cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    double min, max;
                    tableCol = new TABLECOLUMN();
                    tableCol.Name = rdr.GetString(0);
                    tableCol.Formula = rdr.GetString(1);

                    if (Double.TryParse(rdr.GetString(2), out min))
                        tableCol.Min = min;

                    if (Double.TryParse(rdr.GetString(3), out max))
                        tableCol.Max = max;

                    tableCol.Readvalue = rdr.GetInt32(4);

                    tableColList.Add(tableCol);
                }
            }
        }

        public static void DeleteColumnInfo(string station, string model_number, string customer, int column)
        {
            sqlite_cmd = sqlite_connect.CreateCommand();//create command
            sqlite_cmd.CommandText = "DELETE FROM " + COLUMNSINFO_TBL_NAME + " WHERE model_number='" + model_number + "' AND customer='" + customer + "' AND station='" + station + "' AND column='" + column + "'";
            sqlite_cmd.ExecuteNonQuery();
        }

        //----------------------------Data Table----------------------------
        public static void InsertData(string station, string model_number, string customer, string data, string time)
        {
            sqlite_cmd = sqlite_connect.CreateCommand();//create command

            sqlite_cmd.CommandText = "SELECT * FROM " + DATA_TBL_NAME + " WHERE station='" + station + "' AND model_number='" + model_number + "' AND customer='" + customer + "'";

            var result = sqlite_cmd.ExecuteScalar();
            if (result == null)
            {
                sqlite_cmd.CommandText = "INSERT INTO " + DATA_TBL_NAME + " VALUES ('" + station + "','" + model_number + "','" + customer + "','" + data + "','" + time + "');";
            }
            else
            {
                sqlite_cmd.CommandText = ("UPDATE " + DATA_TBL_NAME + " SET data='" + data + "', time='" + time + "' WHERE model_number ='" + model_number + "' AND customer='" + customer + "' AND station='" + station + "'");
            }

            sqlite_cmd.ExecuteNonQuery();
        }
    }
}
