using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows.Forms;

namespace JummahManagement.Data
{
    class DhaeData
    {
        private readonly DataCon DataCon = new DataCon();

        //function to load suggested Dhae for Jummah
        public DataSet SuggestedDhaeList(string Dhae1, string Dhae2, string Dhae3, string Dhae4)
        {
            try
            {
                DataCon.Con.Open();
                SQLiteDataAdapter cmdCat = new SQLiteDataAdapter("SELECT Dhae_Name FROM tbl_Dhae_temp Where Dhae_Name <> '" + Dhae1 + "' AND Dhae_Name <> '" + Dhae2 + "' AND Dhae_Name <> '" + Dhae3 + "' AND Dhae_Name <> '" + Dhae4 + "' ORDER BY NEWID()", DataCon.Con);
                DataSet ds = new DataSet();
                cmdCat.Fill(ds);          
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
                
                {
                    DataCon.Con.Open();
                }
                SQLiteCommand adp = new SQLiteCommand("Delete From tbl_Dhae_temp Where Dhae_Name = ('" + DhaeName + "')", DataCon.Con);
                adp.ExecuteNonQuery();               
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
                SQLiteCommand command = new SQLiteCommand(@"USE [JummahManagement]
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
                        ) ON [PRIMARY]", DataCon.Con);
                SQLiteCommand cmd = new SQLiteCommand(@"INSERT INTO tbl_Dhae_temp SELECT * FROM tbl_Dhae", DataCon.Con);
                
                {
                    DataCon.Con.Open();
                }
                command.ExecuteNonQuery();
                
                
                {
                    DataCon.Con.Open();
                }
                cmd.ExecuteNonQuery();
                
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
                    if (DataCon.Con.State == ConnectionState.Open)
                    {
                        SQLiteCommand Check_City = new SQLiteCommand("SELECT * FROM tbl_City WHERE City = '" + City + "'", DataCon.Con);
                        SQLiteDataReader reader = Check_City.ExecuteReader();

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
                                SQLiteCommand cmd = new SQLiteCommand("INSERT INTO tbl_City (City) VALUES ('" + City + "')", DataCon.Con);
                                cmd.ExecuteNonQuery();
                                result = 1;
                                reader.Close();
                                
                                return result;
                            }
                            catch (Exception)
                            {
                                reader.Close();
                                
                                return result;
                            }
                        }

                    }
                    else
                    {
                        
                        {
                            DataCon.Con.Open();
                        }
                        SQLiteCommand Check_City = new SQLiteCommand("SELECT * FROM tbl_City WHERE City = '" + City + "'", DataCon.Con);
                        SQLiteDataReader reader = Check_City.ExecuteReader();

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
                                SQLiteCommand cmd = new SQLiteCommand("INSERT INTO tbl_City (City) VALUES ('" + City + "')", DataCon.Con);
                                cmd.ExecuteNonQuery();
                                result = 1;
                                reader.Close();
                                
                                return result;
                            }
                            catch (Exception)
                            {
                                reader.Close();
                                
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
                SQLiteCommand cmd = new SQLiteCommand(@"INSERT INTO tbl_Dhae_temp SELECT * FROM tbl_Dhae Where Dhae_Name = '"+ DhaeName +"'", DataCon.Con);
                
                {
                    DataCon.Con.Open();
                }
                cmd.ExecuteNonQuery();
                
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
                    if (DataCon.Con.State == ConnectionState.Open)
                    {
                        SQLiteCommand Check_Dhae_ID = new SQLiteCommand("SELECT * FROM tbl_Dhae WHERE Dhae_ID = '" + Dhae_ID + "'", DataCon.Con);
                        SQLiteDataReader reader = Check_Dhae_ID.ExecuteReader();

                        if (reader.HasRows)
                        {
                            try
                            {
                                reader.Close();
                                
                                return result;
                            }
                            catch (Exception)
                            {
                                
                                return result;
                            }
                        }
                        else
                        {
                            try
                            {
                                SQLiteCommand cmd = new SQLiteCommand("INSERT INTO tbl_Dhae (Dhae_ID,Dhae_Name,Dhae_Contact,House_No,Street_Name,City,District) VALUES ('" + Dhae_ID + "','" + Dhae_Name + "','" + Dhae_Contact + "','" + House_No + "','" + Street_Name + "','" + City + "','" + District + "')", DataCon.Con);
                                cmd.ExecuteNonQuery();
                                result = 1;
                                reader.Close();
                                
                                return result;
                            }
                            catch (Exception)
                            {
                                reader.Close();
                                
                                return result;
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            
                            {
                                DataCon.Con.Open();
                            }
                            SQLiteCommand Check_Dhae = new SQLiteCommand("SELECT * FROM tbl_Dhae WHERE Dhae_ID = '" + Dhae_ID + "'", DataCon.Con);
                            SQLiteDataReader reader = Check_Dhae.ExecuteReader();

                            if (reader.HasRows)
                            {
                                try
                                {
                                    reader.Close();
                                    
                                    return result;
                                }
                                catch (Exception)
                                {
                                    
                                    return result;
                                }
                            }
                            else
                            {
                                try
                                {
                                    
                                    {
                                        DataCon.Con.Open();
                                    }
                                    SQLiteCommand cmd = new SQLiteCommand("INSERT INTO tbl_Dhae (Dhae_ID,Dhae_Name,Dhae_Contact,House_No,Street_Name,City,District) VALUES ('" + Dhae_ID + "','" + Dhae_Name + "','" + Dhae_Contact + "','" + House_No + "','" + Street_Name + "','" + City + "','" + District + "')", DataCon.Con); 
                                    cmd.ExecuteNonQuery();
                                    result = 1;
                                    reader.Close();
                                    
                                    return result;
                                }
                                catch (Exception)
                                {
                                    reader.Close();
                                    
                                    return result;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            
                            return result;
                        }

                    }
                }
                catch (Exception)
                {
                    
                    return result;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //Function to move the deleted Dhae details to Temporary Table
        public int InsertDhaeDetailsToDeleted(int Dhae_ID)
        {
            int result = 0; 
            try
            {
                
                {
                    DataCon.Con.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand(@"INSERT INTO tbl_Dhae_Deleted SELECT * FROM tbl_Dhae Where Dhae_ID = '" + Dhae_ID + "'", DataCon.Con);                
                cmd.ExecuteNonQuery();
                result = 1;
                
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
                
                {
                    DataCon.Con.Open();
                }
                string query = "Select * From tbl_Dhae";
                SQLiteDataAdapter sda = new SQLiteDataAdapter(query, DataCon.Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                
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
                
                {
                    DataCon.Con.Open();
                }
                string query = "Select Dhae_ID,Dhae_Name,Dhae_Contact,City,District From tbl_Dhae";
                SQLiteDataAdapter sda = new SQLiteDataAdapter(query, DataCon.Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                
                return dt;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //Function to Load Dhae by Dhae ID
        public DataTable LoadDhaeByDhaeID(int DhaeID)
        {
            try
            {
                
                {
                    DataCon.Con.Open();
                }
                string query = "Select * From tbl_Dhae Where Dhae_ID = '"+ DhaeID +"'";
                SQLiteDataAdapter sda = new SQLiteDataAdapter(query, DataCon.Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                
                return dt;
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
                
                {
                    DataCon.Con.Open();
                }
                SQLiteDataAdapter adp = new SQLiteDataAdapter("Update tbl_Dhae set Dhae_Name = ('" + Dhae_Name + "'), Dhae_Contact = ('" + Dhae_Contact + "'), House_No = ('" + Dhae_House_No + "'), Street_Name = ('" + Dhae_Street_Name + "'), City = ('" + Dhae_City + "'), District = ('" + Dhae_District + "') Where Dhae_ID = '" + Dhae_ID + "'", DataCon.Con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                result = 1;
                
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
                
                {
                    DataCon.Con.Open();
                }
                SQLiteCommand adp = new SQLiteCommand("Delete From tbl_Dhae Where Dhae_ID = ('" + Dhae_ID + "')", DataCon.Con);
                adp.ExecuteNonQuery();
                result = 1;                
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                if (DataCon.Con != null)
                    DataCon.Con.Close();
            }
        }

        //Function to Autoload Dhae Naem from Database to Front End
        public DataTable GetAllDhaeNames()
        {
            try
            {
                
                {
                    DataCon.Con.Open();
                }
                string query = "Select Dhae_Name From tbl_Dhae";
                SQLiteDataAdapter sda = new SQLiteDataAdapter(query, DataCon.Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);               
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                if (DataCon.Con != null)
                    DataCon.Con.Close();
            }
        }

        //Function to Load Dhae Contact by Dhae Name
        public DataTable LoadDhaeNoByDhaeName(string DhaeName)
        {
            try
            {
                
                {
                    DataCon.Con.Open();
                }
                string query = "Select Dhae_Contact From tbl_Dhae Where Dhae_Name = '" + DhaeName + "'";
                SQLiteDataAdapter sda = new SQLiteDataAdapter(query, DataCon.Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);                
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                if (DataCon.Con != null)
                    DataCon.Con.Close();
            }
        }

        //Function to Load Dhae Details by Dhae Name
        public DataTable LoadDhaeDetailsByDhaeName(string DhaeName)
        {
            try
            {
                
                {
                    DataCon.Con.Open();
                }
                string query = "Select * From tbl_Dhae Where Dhae_Name = '" + DhaeName + "'";
                SQLiteDataAdapter sda = new SQLiteDataAdapter(query, DataCon.Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);             
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                if (DataCon.Con != null)
                    DataCon.Con.Close();
            }
        }
    }
}
