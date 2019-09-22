using System.Data.SQLite;

namespace JummahManagement.Data
{
    public class DataCon
    {
        //public SQLiteConnection Con = new SQLiteConnection("Data Source= JummahManagement.mssql.somee.com; Initial Catalog=JummahManagement; user id=nirzaf_SQLLogin_1; password=ng1mkfixd4; MultipleActiveResultSets = True");
        public static SQLiteConnection Con = new SQLiteConnection(@"Data Source= jummahManagement.db; Version=3; FailIfMissing=True; Foreign Keys=True; Pooling=True; Max Pool Size=100;");
    }
}
