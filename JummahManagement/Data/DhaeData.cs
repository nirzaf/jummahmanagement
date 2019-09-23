using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace JummahManagement.Data
{
    class DhaeData
    {
        DataCon C = new DataCon();

        //function to load suggested Dhae for Jummah
        public DataSet SuggestedDhaeList(string Dhae1, string Dhae2, string Dhae3, string Dhae4)
        {
            try
            {
                DataSet ds = new DataSet();
                using (MySqlDataAdapter cmdCat = new MySqlDataAdapter("SELECT Dhae_Name FROM tbl_Dhae_temp Where Dhae_Name <> '" + Dhae1 + "' AND Dhae_Name <> '" + Dhae2 + "' AND Dhae_Name <> '" + Dhae3 + "' AND Dhae_Name <> '" + Dhae4 + "' ORDER BY NEWID()", C.Con))
                {
                    C.Con.Open();
                    cmdCat.Fill(ds);
                }
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
                using (MySqlCommand adp = new MySqlCommand("Delete From tbl_Dhae_temp Where Dhae_Name = ('" + DhaeName + "')", C.Con))
                {
                    adp.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Function to create temp Dhae Table
        public void CreateTempDhaeTable()
        {
            int result = 0;
            try
            {
                using (MySqlCommand command = new MySqlCommand(@"USE [JummahManagement]
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
                        ) ON [PRIMARY]", C.Con))
                {
                    C.Con.Open();
                    MySqlCommand cmd = new MySqlCommand(@"INSERT INTO tbl_Dhae_temp SELECT * FROM tbl_Dhae", C.Con);
                    result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        int res = cmd.ExecuteNonQuery();
                        if (res == 0)
                        {
                            MessageBox.Show("Something went wrong");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong");
                    }
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Function to Add new City
        public int AddCity(string City)
        {
                int result = 0;
                try
                {
                    using (MySqlCommand Check_City = new MySqlCommand("SELECT * FROM tbl_City WHERE City = '" + City + "'", C.Con))
                    {
                        C.Con.Open();
                        using (MySqlDataReader reader = Check_City.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                return result;
                            }
                            else
                            {
                                try
                                {
                                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO tbl_City (City) VALUES ('" + City + "')", C.Con))
                                    {
                                        C.Con.Open();
                                        result = cmd.ExecuteNonQuery();
                                    }
                                    return result;
                                }
                                catch (Exception)
                                {
                                    return result;
                                }
                            }
                        }
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
                using (MySqlCommand cmd = new MySqlCommand(@"INSERT INTO tbl_Dhae_temp SELECT * FROM tbl_Dhae Where Dhae_Name = '" + DhaeName + "'", C.Con))
                {
                    C.Con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Function to Add New Dhae Details
        public int AddDhae(int Dhae_ID, string Dhae_Name, string Dhae_Contact, string House_No,string Street_Name, string City, string District)
        {
                int result = 0;
                try
                {
                    using (MySqlCommand Check_Dhae_ID = new MySqlCommand("SELECT * FROM tbl_Dhae WHERE Dhae_ID = '" + Dhae_ID + "'", C.Con))
                    {
                        C.Con.Open();
                        using (MySqlDataReader reader = Check_Dhae_ID.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                return result;
                            }
                            else
                            {
                                try
                                {
                                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO tbl_Dhae (Dhae_ID,Dhae_Name,Dhae_Contact,House_No,Street_Name,City,District) VALUES ('" + Dhae_ID + "','" + Dhae_Name + "','" + Dhae_Contact + "','" + House_No + "','" + Street_Name + "','" + City + "','" + District + "')", C.Con))
                                    {
                                        //C.Con.Open();
                                        result = cmd.ExecuteNonQuery();                                    
                                    }
                                    return result;
                                }
                                catch (Exception)
                                {
                                    return result;
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    return result;
                }
        }

        //Function to move the deleted Dhae details to Temporary Table
        public int InsertDhaeDetailsToDeleted(int Dhae_ID)
        {
            int result = 0; 
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(@"INSERT INTO tbl_Dhae_Deleted SELECT * FROM tbl_Dhae Where Dhae_ID = '" + Dhae_ID + "'", C.Con))
                {
                    C.Con.Open();
                    result = cmd.ExecuteNonQuery();
                }
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
                DataTable dt = new DataTable();
                string query = "Select * From tbl_Dhae";
                using (MySqlDataAdapter sda = new MySqlDataAdapter(query, C.Con))
                {
                    C.Con.Open();                   
                    sda.Fill(dt);
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Function to Load All Dhae Details
        public DataTable LoadDhaes()
        {
            try
            {
                using (DataSet ds = new DataSet())
                {
                    using (DataTable dt = new DataTable())
                    {
                        string query = "Select Dhae_ID AS `Dhae Id`, Dhae_Name AS `Dhae Name`, Dhae_Contact AS `Dhae Contact`, City, District From tbl_Dhae";
                        using (MySqlCommand cmd = new MySqlCommand(query, C.Con))
                        {
                            C.Con.Open();
                            using (MySqlDataReader msdr = cmd.ExecuteReader())
                            {
                                ds.Tables.Add(dt);
                                ds.EnforceConstraints = false;
                                dt.Load(msdr);
                            }
                        }
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        //Function to Load Dhae by Dhae ID
        public DataTable LoadDhaeByDhaeID(int DhaeID)
        {
            try
            {
                using (DataSet ds = new DataSet())
                {
                    using (DataTable dt = new DataTable())
                    {
                        string query = "Select* From tbl_Dhae Where Dhae_ID = '"+ DhaeID +"'";
                        using (MySqlCommand cmd = new MySqlCommand(query, C.Con))
                        {
                            C.Con.Open();
                            using (MySqlDataReader msdr = cmd.ExecuteReader())
                            {
                                ds.Tables.Add(dt);
                                ds.EnforceConstraints = false;
                                dt.Load(msdr);
                            }
                        }
                        return dt;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Function to Update Dhae Details
        public int UpdateDhaeDetails(int Dhae_ID, string Dhae_Name, string Dhae_Contact,string Dhae_House_No,string Dhae_Street_Name,string Dhae_City, string Dhae_District)
        {
            int result = 0;
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("Update tbl_Dhae set Dhae_Name = ('" + Dhae_Name + "'), Dhae_Contact = ('" + Dhae_Contact + "'), House_No = ('" + Dhae_House_No + "'), Street_Name = ('" + Dhae_Street_Name + "'), City = ('" + Dhae_City + "'), District = ('" + Dhae_District + "') Where Dhae_ID = '" + Dhae_ID + "'", C.Con))
                {
                    C.Con.Open();
                    result = cmd.ExecuteNonQuery();
                }
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }


        //Function to Delete Dhae Details 
        public int DeleteDhaeDetails(int Dhae_ID)
        {
            int result = 0;
            try
            {
                using (MySqlCommand adp = new MySqlCommand("Delete From tbl_Dhae Where Dhae_ID = ('" + Dhae_ID + "')", C.Con))
                {
                    C.Con.Open();
                    result = adp.ExecuteNonQuery();
                }
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        //Function to Autoload Dhae Naem from Database to Front End
        public DataTable GetAllDhaeNames()
        {
            try
            {
                using (DataSet ds = new DataSet())
                {
                    using (DataTable dt = new DataTable())
                    {
                        string query = "Select Dhae_Name From tbl_Dhae";
                        using (MySqlCommand cmd = new MySqlCommand(query, C.Con))
                        {
                            C.Con.Open();
                            using (MySqlDataReader msdr = cmd.ExecuteReader())
                            {
                                ds.Tables.Add(dt);
                                ds.EnforceConstraints = false;
                                dt.Load(msdr);
                            }
                        }
                        return dt;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Function to Load Dhae Contact by Dhae Name
        public DataTable LoadDhaeNoByDhaeName(string DhaeName)
        {
            try
            {
                using (DataSet ds = new DataSet())
                {
                    using (DataTable dt = new DataTable())
                    {
                        string query = "Select Dhae_Contact From tbl_Dhae Where Dhae_Name = '" + DhaeName + "'";
                        using (MySqlCommand cmd = new MySqlCommand(query, C.Con))
                        {
                            C.Con.Open();
                            using (MySqlDataReader msdr = cmd.ExecuteReader())
                            {
                                ds.Tables.Add(dt);
                                ds.EnforceConstraints = false;
                                dt.Load(msdr);
                            }
                        }
                        return dt;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (C.Con != null) C.Con.Close();
            }
        }

        //Function to Load Dhae Details by Dhae Name
        public DataTable LoadDhaeDetailsByDhaeName(string DhaeName)
        {
            try
            {
                using (DataSet ds = new DataSet())
                {
                    using (DataTable dt = new DataTable())
                    {
                        string query = "Select * From tbl_Dhae Where Dhae_Name = '" + DhaeName + "'";
                        using (MySqlCommand cmd = new MySqlCommand(query, C.Con))
                        {
                            C.Con.Open();
                            using (MySqlDataReader msdr = cmd.ExecuteReader())
                            {
                                ds.Tables.Add(dt);
                                ds.EnforceConstraints = false;
                                dt.Load(msdr);
                            }
                        }
                        return dt;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
