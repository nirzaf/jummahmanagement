using System;
using System.Data;
using System.Data.SqlClient;

namespace BabatyeInventory.Data
{
    public class DataCon
    {
        public SqlConnection Con = new SqlConnection("Data Source =.\\SQLEXPRESS01; Initial Catalog = babatie; Integrated Security = True; MultipleActiveResultSets = True");

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
