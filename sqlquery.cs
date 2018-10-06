using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;


namespace ePlusReplication
{
    public class sqlquery
    {

        public struct QueryInfo
        {
        public string DBCode;
        public long ID;
        public long BatchID;
        public string ObjectType;
        public string ObjectName;
        public string CommandType;
        public string CommandString;
       }
        string connectionString = null;
        string connectionString1 = null;
        MySqlConnection cnn;
        MySqlConnection conn;
        
        DBConnections dbinfo1 = new DBConnections();
        DBinfo dbinfo = new DBinfo();
        MySqlCommand cmnd = new MySqlCommand();
        MySqlCommand cmd = new MySqlCommand();
        static xmlSettings settings;
       
        

        public DataTable GridFillSql()
        {
            clsXMLData clsXmlData = new clsXMLData();
            settings = clsXmlData.ReadSettings();

            dbinfo.ServerName = settings.serverName;
            dbinfo.DBName = settings.dbName;
            dbinfo.DBPort = settings.dbPort;
            dbinfo.DBUser = settings.userName;
            dbinfo.DBPWD = settings.password;

            
            DataTable dt = new DataTable();
            cnn = new MySqlConnection(connectionString);
            conn = new MySqlConnection(connectionString1);
            try
            {
                cnn.Open();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT LASTCONNECTION,COUNT(ID),(SELECT COUNT(ID) FROM REPLICATIONLOG WHERE COMMANDSTATUS = 'SUCCESS') APPLIEDQUERY , (SELECT COUNT(ID) FROM REPLICATIONLOG WHERE UPDATESTATUS = 'SUCCESS') VERIFIEDQUERY FROM replicationinfo JOIN replicationlog ON replicationlog.DBCODE = replicationinfo.CODE ", conn);
                cmd.CommandType = CommandType.Text;
                MySqlDataAdapter sqlda = new MySqlDataAdapter(cmd);
                sqlda.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't open connection" + ex.ToString());
            }
            finally
            {
                cnn.Close();
                conn.Close();
            }
            return dt ;
        }  
    }
}

    

