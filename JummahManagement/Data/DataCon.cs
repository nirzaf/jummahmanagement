using EnvDTE;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace JummahManagement.Data
{
    public class DataCon
    {
        //public SqlConnection Con = new SqlConnection("Data Source= JummahManagement.mssql.somee.com; Initial Catalog=JummahManagement; user id=nirzaf_SQLLogin_1; password=ng1mkfixd4; MultipleActiveResultSets = True");
        public MySqlConnection Con = new MySqlConnection("User Id=root;Host=localhost;Database=jummahmanagement;");
        
    }
}
