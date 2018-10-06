using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ePlusReplication
{
    public struct DBinfo
    {
        //string settings1;
        public string DBCode;
        public string ServerName;
        public string DBName;
        public string DBUser;
        public string DBPort;
        public string DBPWD;
        public string ConnectionString;
        public string ConnectionString1;
        public Boolean Success;
    }
    public class DBConnections
    {

        public string getConnectionString(DBinfo dbconnstring)
                {
           // MessageBox.Show("Data Source=MSERVER" + ";Initial Catalog=eplus108_log" + ";User ID=root" + ";Password=metalic");
            return "Data Source="+dbconnstring.ServerName + ";Initial Catalog="+dbconnstring.DBName + ";User ID=root" + ";Password=metalic";
           
        }
        public string getConnectionString1(DBinfo dbconnstring)
        {
            string logname = dbconnstring.DBName;
            logname = logname.Replace("_data", "_log");
            // MessageBox.Show("Data Source=MSERVER" + ";Initial Catalog=eplus108_log" + ";User ID=root" + ";Password=metalic");
            return "Data Source="+dbconnstring.ServerName + ";Initial Catalog="+logname+ ";User ID=root" + ";Password=metalic";

        }


    }
}
