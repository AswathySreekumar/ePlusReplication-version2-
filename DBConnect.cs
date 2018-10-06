using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ePlusReplication
{
    public struct XMlSettings
    {
        public string serverName;
        public string dbName;
        public string dbPort;
        public string userName;
        public string password;
        public bool success;
        public string errorMessage;
        public string timer;
    }
    public class DBConnect
    {
        public Boolean mainDBConnection;
        protected DatabaseInfo MainDBInfo, LogDBInfo;
        protected DatabaseInfo[] slaveDatabaseInfo;
        protected MySqlConnection MainDBConn, LogDBConn, slaveDatabase;
        protected System.Collections.Queue replicationQueue;
        protected XMlSettings settings;
        protected string errorMessage, dbCode;
        public DBConnect(XMlSettings xmlsettings)
        {
            settings = xmlsettings;
            mainDBConnection = btnConnect();
        }
        public Boolean btnConnect()
        {
            MainDBInfo.ServerName = settings.serverName;
            MainDBInfo.DBName = settings.dbName;
            MainDBInfo.DBPort = settings.dbPort;
            MainDBInfo.DBUser = settings.userName;
            MainDBInfo.DBPWD = settings.password;

            MainDBInfo.ConnectionString = clsDBUtility.CreateConnectionString(MainDBInfo);
            try
            {
                MainDBConn = new MySqlConnection(MainDBInfo.ConnectionString);
                MainDBConn.Open();
                dbCode = clsDBUtility.GetConnectedDatabaseCode(MainDBInfo.ServerName, MainDBInfo.DBName, MainDBInfo.DBPort, MainDBConn, ref errorMessage);
                System.Threading.Thread.Sleep(500);
                LogDBInfo = clsDBUtility.GetLogDBDetails(MainDBConn, dbCode, ref errorMessage);
                LogDBInfo.DBUser = settings.userName;
                LogDBInfo.DBPWD = settings.password;
                clsDBUtility.GetReplicationLogDBInfo(MainDBConn, dbCode, ref errorMessage, ref slaveDatabaseInfo);
                System.Threading.Thread.Sleep(500);
                MySqlConnection.ClearPool(MainDBConn);
                MainDBConn.Close();
                MainDBConn.Dispose();
                System.Threading.Thread.Sleep(500);
                LogDBInfo.ConnectionString = clsDBUtility.CreateConnectionString(LogDBInfo);
                LogDBConn = new MySqlConnection(LogDBInfo.ConnectionString);
                LogDBConn.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
    public static void Requeue(MySqlConnection conn, ref string dbCode, ref ulong ID,ref string errorString)
    {
        string str;
        str = "SELECT DBCODE,ID FROM replicationlog WHERE UPDATESTATUS = 'Pending' AND SKIP = 'No' ORDER BY DBCODE,ID LIMIT 1";
        MySqlCommand Com = new MySqlCommand();
        MySqlDataReader reader;
        Com.Connection = conn;
        try
        {
            Com.CommandText = str;
            reader = Com.ExecuteReader();
            while (reader.Read())
            {
                dbCode = reader["DBCODE"].ToString();
                ID = Convert.ToUInt64(reader["ID"].ToString());
            }
            reader.Close();
        }
        catch(MySqlException sqlEx)
        {
            errorString = sqlEx.Message;
            return;
        }
        Com.Dispose();
    }
    public static Boolean UpdateSkip(MySqlConnection conn, string dbCode, ulong id, ref string errorString)
    {
        string strSql = "";
        MySqlCommand cmd;
        try
        {
            strSql = "UPDATE REPLICATIONLOG SET SKIP='Yes' WHERE DBCODE = '" + dbCode + "' AND ID =" + id.ToString();
            cmd = new MySqlCommand(strSql, conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
        }
        catch (MySqlException e)
        {
            errorString = e.Message;
            return false;
        }
        return true;
    }
    
}
