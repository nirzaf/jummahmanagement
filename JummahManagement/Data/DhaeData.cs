using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace JummahManagement.Data
{
    class DhaeData
    {
        DataCon newCon = new DataCon();

        //function to load suggested Dhae for Jummah
        public DataSet SuggestedDhaeList(string Dhae1, string Dhae2, string Dhae3, string Dhae4)
        {
            try
            {
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                MySqlDataAdapter cmdCat = new MySqlDataAdapter("SELECT Dhae_Name FROM tbl_Dhae_temp Where Dhae_Name <> '" + Dhae1 + "' AND Dhae_Name <> '" + Dhae2 + "' AND Dhae_Name <> '" + Dhae3 + "' AND Dhae_Name <> '" + Dhae4 + "' ORDER BY NEWID()", newCon.Con);
                DataSet ds = new DataSet();
                cmdCat.Fill(ds);
                newCon.CloseSQLConnecion();
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Function to Delete Dhaedata  from TempDhae table
        public void DeleteDhaeFromTempTable(string DhaeName)
        {
            try
            {
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                MySqlCommand adp = new MySqlCommand("Delete From tbl_Dhae_temp Where Dhae_Name = ('" + DhaeName + "')", newCon.Con);
                adp.ExecuteNonQuery();
                newCon.CloseSQLConnecion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Function to create temp Dhae Table
        public void CreateTempDhaeTable()
        {
            try
            {
                MySqlCommand command = new MySqlCommand(@"USE [JummahManagement]
                        DROP TABLE [dbo].[tbl_Dhae_temp]
                        SET ANSI_NULLS ON
                        SET QUOTED_IDENTIFIER ON
                        CREATE TABLE [dbo].[tbl_Dhae_temp](
	                        [Dhae_ID] [int] NOT NULL,
	                        [Dhae_Name] [nvarchar](100) NOT NULL,
	                        [Dhae_Contact] [nvarchar](15) NOT NULL,
	                        [House_No] [nchar](10) NULL,
	                        [Street_Name] [nvarchar](50) NULL,
	                        [City] [nvarchar](50) NULL,
	                        [District] [nvarchar](20) NULL,
                         CONSTRAINT [PK_tbl_Dhae_temp] PRIMARY KEY CLUSTERED 
                        (
	                        [Dhae_ID] ASC
                        )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                        ) ON [PRIMARY]", newCon.Con);
                MySqlCommand cmd = new MySqlCommand(@"INSERT INTO tbl_Dhae_temp SELECT * FROM tbl_Dhae", newCon.Con);
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                command.ExecuteNonQuery();
                newCon.CloseSQLConnecion();
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                cmd.ExecuteNonQuery();
                newCon.CloseSQLConnecion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Function to Add new City
        public int AddCity(string City)
        {
            try
            {
                int result = 0;
                try
                {
                    if (newCon.Con.State == ConnectionState.Open)
                    {
                        MySqlCommand Check_City = new MySqlCommand("SELECT * FROM tbl_City WHERE City = '" + City + "'", newCon.Con);
                        MySqlDataReader reader = Check_City.ExecuteReader();

                        if (reader.HasRows)
                        {
                            try
                            {
                                reader.Close();
                                return result;
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
                        else
                        {
                            try
                            {
                                MySqlCommand cmd = new MySqlCommand("INSERT INTO tbl_City (City) VALUES ('" + City + "')", newCon.Con);
                                cmd.ExecuteNonQuery();
                                result = 1;
                                reader.Close();
                                newCon.CloseSQLConnecion();
                                return result;
                            }
                            catch (Exception)
                            {
                                reader.Close();
                                newCon.CloseSQLConnecion();
                                return result;
                            }
                        }

                    }
                    else
                    {
                        if (newCon.Con.State == ConnectionState.Closed)
                        {
                            newCon.Con.Open();
                        }
                        MySqlCommand Check_City = new MySqlCommand("SELECT * FROM tbl_City WHERE City = '" + City + "'", newCon.Con);
                        MySqlDataReader reader = Check_City.ExecuteReader();

                        if (reader.HasRows)
                        {
                            try
                            {
                                reader.Close();
                                return result;
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
                        else
                        {
                            try
                            {
                                MySqlCommand cmd = new MySqlCommand("INSERT INTO tbl_City (City) VALUES ('" + City + "')", newCon.Con);
                                cmd.ExecuteNonQuery();
                                result = 1;
                                reader.Close();
                                newCon.CloseSQLConnecion();
                                return result;
                            }
                            catch (Exception)
                            {
                                reader.Close();
                                newCon.CloseSQLConnecion();
                                return result;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //function to insert Dhae Details in Temporary Dhae Details Table
        public void InsertDhaeDetailsToTempTable(string DhaeName)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"INSERT INTO tbl_Dhae_temp SELECT * FROM tbl_Dhae Where Dhae_Name = '"+ DhaeName +"'", newCon.Con);
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                cmd.ExecuteNonQuery();
                newCon.CloseSQLConnecion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Function to Add New Dhae Details
        public int AddDhae(int Dhae_ID, string Dhae_Name, string Dhae_Contact, string House_No,string Street_Name, string City, string District)
        {
            try
            {
                int result = 0;
                try
                {
                    if (newCon.Con.State == ConnectionState.Open)
                    {
                        MySqlCommand Check_Dhae_ID = new MySqlCommand("SELECT * FROM tbl_Dhae WHERE Dhae_ID = '" + Dhae_ID + "'", newCon.Con);
                        MySqlDataReader reader = Check_Dhae_ID.ExecuteReader();

                        if (reader.HasRows)
                        {
                            try
                            {
                                reader.Close();
                                newCon.CloseSQLConnecion();
                                return result;
                            }
                            catch (Exception)
                            {
                                newCon.CloseSQLConnecion();
                                return result;
                            }
                        }
                        else
                        {
                            try
                            {
                                MySqlCommand cmd = new MySqlCommand("INSERT INTO tbl_Dhae (Dhae_ID,Dhae_Name,Dhae_Contact,House_No,Street_Name,City,District) VALUES ('" + Dhae_ID + "','" + Dhae_Name + "','" + Dhae_Contact + "','" + House_No + "','" + Street_Name + "','" + City + "','" + District + "')", newCon.Con);
                                cmd.ExecuteNonQuery();
                                result = 1;
                                reader.Close();
                                newCon.CloseSQLConnecion();
                                return result;
                            }
                            catch (Exception)
                            {
                                reader.Close();
                                newCon.CloseSQLConnecion();
                                return result;
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            if (newCon.Con.State == ConnectionState.Closed)
                            {
                                newCon.Con.Open();
                            }
                            MySqlCommand Check_Dhae = new MySqlCommand("SELECT * FROM tbl_Dhae WHERE Dhae_ID = '" + Dhae_ID + "'", newCon.Con);
                            MySqlDataReader reader = Check_Dhae.ExecuteReader();

                            if (reader.HasRows)
                            {
                                try
                                {
                                    reader.Close();
                                    newCon.CloseSQLConnecion();
                                    return result;
                                }
                                catch (Exception)
                                {
                                    newCon.CloseSQLConnecion();
                                    return result;
                                }
                            }
                            else
                            {
                                try
                                {
                                    if (newCon.Con.State == ConnectionState.Closed)
                                    {
                                        newCon.Con.Open();
                                    }
                                    MySqlCommand cmd = new MySqlCommand("INSERT INTO tbl_Dhae (Dhae_ID,Dhae_Name,Dhae_Contact,House_No,Street_Name,City,District) VALUES ('" + Dhae_ID + "','" + Dhae_Name + "','" + Dhae_Contact + "','" + House_No + "','" + Street_Name + "','" + City + "','" + District + "')", newCon.Con); 
                                    cmd.ExecuteNonQuery();
                                    result = 1;
                                    reader.Close();
                                    newCon.CloseSQLConnecion();
                                    return result;
                                }
                                catch (Exception)
                                {
                                    reader.Close();
                                    newCon.CloseSQLConnecion();
                                    return result;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            newCon.CloseSQLConnecion();
                            return result;
                        }

                    }
                }
                catch (Exception)
                {
                    newCon.CloseSQLConnecion();
                    return result;
                }
            }
            catch (Exception)
            {
                newCon.CloseSQLConnecion();
                throw;
            }
        }

        //Function to move the deleted Dhae details to Temporary Table
        public int InsertDhaeDetailsToDeleted(int Dhae_ID)
        {
            int result = 0; 
            try
            {
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                MySqlCommand cmd = new MySqlCommand(@"INSERT INTO tbl_Dhae_Deleted SELECT * FROM tbl_Dhae Where Dhae_ID = '" + Dhae_ID + "'", newCon.Con);                
                cmd.ExecuteNonQuery();
                result = 1;
                newCon.CloseSQLConnecion();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return result;
            }
        }

        //Function to Load All Dhae Details
        public DataTable ViewAllDhaes()
        {
            try
            {
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                string query = "Select * From tbl_Dhae";
                MySqlDataAdapter sda = new MySqlDataAdapter(query, newCon.Con);
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

        //Function to Load All Dhae Details
        public DataTable LoadDhaes()
        {
            try
            {
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                string query = "Select Dhae_ID,Dhae_Name,Dhae_Contact,City,District From tbl_Dhae";
                MySqlDataAdapter sda = new MySqlDataAdapter(query, newCon.Con);
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

        //Function to Load Dhae by Dhae ID
        public DataTable LoadDhaeByDhaeID(int DhaeID)
        {
            try
            {
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                string query = "Select * From tbl_Dhae Where Dhae_ID = '"+ DhaeID +"'";
                MySqlDataAdapter sda = new MySqlDataAdapter(query, newCon.Con);
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

        //Function to Update Dhae Details
        public int UpdateDhaeDetails(int Dhae_ID, string Dhae_Name, string Dhae_Contact,string Dhae_House_No,string Dhae_Street_Name,string Dhae_City, string Dhae_District)
        {
            int result = 0;
            try
            {
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                MySqlDataAdapter adp = new MySqlDataAdapter("Update tbl_Dhae set Dhae_Name = ('" + Dhae_Name + "'), Dhae_Contact = ('" + Dhae_Contact + "'), House_No = ('" + Dhae_House_No + "'), Street_Name = ('" + Dhae_Street_Name + "'), City = ('" + Dhae_City + "'), District = ('" + Dhae_District + "') Where Dhae_ID = '" + Dhae_ID + "'", newCon.Con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                result = 1;
                newCon.CloseSQLConnecion();
                return result;
            }
            catch (Exception)
            {
                newCon.CloseSQLConnecion();
                return result;
            }
        }


        //Function to Delete Dhae Details 
        public int DeleteDhaeDetails(int Dhae_ID)
        {
            int result = 0;
            try
            {
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                MySqlCommand adp = new MySqlCommand("Delete From tbl_Dhae Where Dhae_ID = ('" + Dhae_ID + "')", newCon.Con);
                adp.ExecuteNonQuery();
                result = 1;
                newCon.CloseSQLConnecion();
                return result;
            }
            catch (Exception)
            {
                newCon.CloseSQLConnecion();
                return result;
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
                MySqlDataAdapter sda = new MySqlDataAdapter(query, newCon.Con);
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

        //Function to Load Dhae Contact by Dhae Name
        public DataTable LoadDhaeNoByDhaeName(string DhaeName)
        {
            try
            {
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                string query = "Select Dhae_Contact From tbl_Dhae Where Dhae_Name = '" + DhaeName + "'";
                MySqlDataAdapter sda = new MySqlDataAdapter(query, newCon.Con);
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

        //Function to Load Dhae Details by Dhae Name
        public DataTable LoadDhaeDetailsByDhaeName(string DhaeName)
        {
            try
            {
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                string query = "Select * From tbl_Dhae Where Dhae_Name = '" + DhaeName + "'";
                MySqlDataAdapter sda = new MySqlDataAdapter(query, newCon.Con);
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
    }
}
