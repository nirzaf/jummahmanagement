using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace JummahManagement.Data
{
    public class DataCon
    {
        //public SqlConnection Con = new SqlConnection("Data Source= JummahManagement.mssql.somee.com; Initial Catalog=JummahManagement; user id=nirzaf_SQLLogin_1; password=ng1mkfixd4; MultipleActiveResultSets = True");
        public MySqlConnection Con = new MySqlConnection("Data Source= JummahManagement.mssql.somee.com; Initial Catalog=JummahManagement; user id=nirzaf_SQLLogin_1; password=ng1mkfixd4; MultipleActiveResultSets = True");

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
