using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BabatyeInventory.Data
{
    class ClothData
    {
        DataCon newCon = new DataCon();
        Cloth cloth = new Cloth();

        //function to insert Dhae Details in Temporary Dhae Details Table
        public bool Insert_Cloth()
        {
            if (isExist(SKU))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(@"UPDATE tbl_cloths SET Count = Count + 1 WHERE SKU = '" + cloth.SkuNumber + "'", newCon.Con);
                    if (newCon.Con.State == ConnectionState.Closed)
                    {
                        newCon.Con.Open();
                    }
                    int result = cmd.ExecuteNonQuery();
                    newCon.CloseSQLConnecion();
                    if (result > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_cloths (SKU,Name,Color,Size,Count) VALUES ('" + cloth.SkuNumber + "', '" + cloth.ProductName + "','" + cloth.ProductSize + "', '" + cloth.ProductColor + "')", newCon.Con);
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                int result = cmd.ExecuteNonQuery();
                newCon.CloseSQLConnecion();
                if (result > 0)
                    return true;
                else
                    return false;

            }
        }

        //Function to Autoload Dhae Naem from Database to Front End
        public DataTable GetAllDhaeNames()
        {
            try
            {
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                string query = "Select Dhae_Name From tbl_Dhae";
                SqlDataAdapter sda = new SqlDataAdapter(query, newCon.Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                newCon.CloseSQLConnecion();
                return dt;
            }
            catch (Exception)
            {
                newCon.CloseSQLConnecion();
                throw;
            }
        }

        public bool isExist(string SKU)
        {
            try
            {
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                string query = "Select COUNT(*) From tbl_cloths Where SKU = '" + SKU + "'";
                SqlCommand cmd = new SqlCommand(query, newCon.Con);
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                int result = cmd.ExecuteNonQuery();
                newCon.CloseSQLConnecion();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                newCon.CloseSQLConnecion();
                throw;
            }

        }
    }
}
