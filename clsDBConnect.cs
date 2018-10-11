using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ePlusReplication
{
    public class clsDBConnect
    {
        
        public Boolean mainDBConnections;
        public DatabaseInfo MainDBInfo, LogDBInfo;
        public DatabaseInfo[] slaveDatabaseInfo;
        public MySqlConnection MainDBConne, LogDBConne, slaveDatabase;
        public System.Collections.Queue replicationQueue;
        public xmlSettings settings;
        public string errorMessage, dbCode;
        public ulong replicationID;     
       

        public clsDBConnect(xmlSettings xmlsettings)
        {
            
            settings = xmlsettings;
            mainDBConnections = btnConnect();
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
                MainDBConne = new MySqlConnection(MainDBInfo.ConnectionString);
                MainDBConne.Open();
                dbCode = clsDBUtility.GetConnectedDatabaseCode(MainDBInfo.ServerName, MainDBInfo.DBName, MainDBInfo.DBPort, MainDBConne, ref errorMessage);
                LogDBInfo = clsDBUtility.GetLogDBDetails(MainDBConne, dbCode, ref errorMessage);
                LogDBInfo.DBUser = settings.userName;
                LogDBInfo.DBPWD = settings.password;
                clsDBUtility.GetReplicationLogDBInfo(MainDBConne, dbCode, ref errorMessage, ref slaveDatabaseInfo);
                MySqlConnection.ClearPool(MainDBConne);
                MainDBConne.Close();
                MainDBConne.Dispose();
                LogDBInfo.ConnectionString = clsDBUtility.CreateConnectionString(LogDBInfo);
                LogDBConne = new MySqlConnection(LogDBInfo.ConnectionString);
                LogDBConne.Open();
                           
            }
            catch (Exception ex)
            {
               
            }
            return true;
        }
        public void Requeue(MySqlConnection conn, ref string errorString)
        {
            string strSql = "", str;
            MySqlCommand cmd;
            MySqlDataReader reader = null;
          
            str = "SELECT DBCODE,ID FROM replicationlog WHERE UPDATESTATUS = 'Failed' AND SKIP = 'No' ORDER BY DBCODE,ID LIMIT 1";
            MySqlCommand Com = new MySqlCommand();
            Com.Connection = conn;

            try
            {
               Com.CommandText = str;
               reader = Com.ExecuteReader();
               while (reader.Read())
               {
                  dbCode = reader["DBCODE"].ToString();
                  replicationID = Convert.ToUInt64(reader["ID"].ToString());
               }
                  reader.Close();
            }
            catch (MySqlException sqlEx)
             {
               errorString = sqlEx.Message;

             }
            try
             {
               strSql = "UPDATE REPLICATIONLOG SET UPDATESTATUS='Pending' WHERE DBCODE = '" + dbCode + "' AND ID =" + replicationID.ToString();
               cmd = new MySqlCommand(strSql, conn);
               cmd.CommandType = System.Data.CommandType.Text;
               cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
              errorString = e.Message;

           }
         }
        public void UpdateSkip(MySqlConnection conn,  ref string errorString)
        {
            string strSql = "",str; 
            MySqlCommand cmd;
            MySqlDataReader reader=null;
           
           
                str = "SELECT DBCODE,ID FROM replicationlog WHERE UPDATESTATUS = 'Failed' AND SKIP = 'No' ORDER BY DBCODE,ID LIMIT 1";
                MySqlCommand Com = new MySqlCommand();               
                Com.Connection = conn;

                try
                {
                    Com.CommandText = str;
                    reader = Com.ExecuteReader();
                    while (reader.Read())
                    {
                        dbCode = reader["DBCODE"].ToString();
                        replicationID = Convert.ToUInt64(reader["ID"].ToString());
                    }
                    reader.Close();
                }
                catch (MySqlException sqlEx)
                {
                    errorString = sqlEx.Message;

                }
                try
                {
                    strSql = "UPDATE REPLICATIONLOG SET SKIP='Yes' WHERE DBCODE = '" + dbCode + "' AND ID =" + replicationID.ToString();
                    cmd = new MySqlCommand(strSql, conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    errorString = e.Message;

                }           
        }
        public void closeconnection()
        {
            MainDBConne.Close();
            MainDBConne.Dispose();
            LogDBConne.Close();
            LogDBConne.Dispose();
        }

    }
}
