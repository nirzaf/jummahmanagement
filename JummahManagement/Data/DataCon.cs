using System;
using System.Data;
using System.Data.SqlClient;

namespace JummahManagement.Data
{
    public class DataCon
    {
        //public SqlConnection Con = new SqlConnection("Data Source=192.168.1.4,1433;Initial Catalog=dbJummah_Management; User ID=sa; Password=123; MultipleActiveResultSets = True");
        //public SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\dbJummah_Management.mdf;Integrated Security=True;Connect Timeout=30");
        //public SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename="+ Path.GetFullPath(Environment.CurrentDirectory) + "\\dbJummah_Management.mdf; MultipleActiveResultSets = True ;Connect Timeout=30");
         public SqlConnection Con = new SqlConnection("Data Source=JummahManagement.mssql.somee.com;Initial Catalog=JummahManagement; user id=nirzaf_SQLLogin_1; password=ng1mkfixd4; MultipleActiveResultSets = True");
        //public SqlConnection Con = new SqlConnection("Data Source=192.168.1.1,1433;Initial Catalog=dbJummah_Management; User ID=sa; Password=123; MultipleActiveResultSets = True");

        public bool CloseSQLConnecion()
        {
            try
            {
                if (ConnectionState.Open == Con.State)
                {
                    Con.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
