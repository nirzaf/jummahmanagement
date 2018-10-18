﻿using System;
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
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                SqlDataAdapter cmdCat = new SqlDataAdapter("SELECT Dhae_Name FROM tbl_Dhae_temp Where Dhae_Name <> '" + Dhae1 + "' AND Dhae_Name <> '" + Dhae2 + "' AND Dhae_Name <> '" + Dhae3 + "' AND Dhae_Name <> '" + Dhae4 + "' ORDER BY NEWID()", newCon.Con);
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
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                SqlCommand adp = new SqlCommand("Delete From tbl_Dhae_temp Where Dhae_Name = ('" + DhaeName + "')", newCon.Con);
                adp.ExecuteNonQuery();
                newCon.Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //function to create temp Dhae Table
        public void CreateTempDhaeTable()
        {
            try
            {
                SqlCommand command = new SqlCommand(@"USE [dbJummah_Management]
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
                SqlCommand cmd = new SqlCommand(@"INSERT INTO tbl_Dhae_temp SELECT * FROM tbl_Dhae",newCon.Con);
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                command.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                newCon.Con.Close();
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
		// will throw an exception if there is an error connecting to the database
		if(ConnectionState.Close == newCon.Con.State){
			newCon.Con.Open();
		}

		// removing whitespaces at start and end
		City = City.Trim();

		//INSERT will return success only if the City is not exists in the table otherwise will throw an exception
		SqlCommand Add_City_Query = new SqlCommand("INSERT INTO tbl_City (City) VALUES ('" + City + "')", newCon.Con);
		Add_City_Query.ExecuteNonQuery();
		//City is Added
		result = 1;
		newCon.Con.Close();
		return result;

	    }
	    catch (Exception ex)
	    {
		Console.WriteLine(ex.ToString());
		return result;
	    }

	}

        //function to insert Dhae Details in Temporary Dhae Details Table
        public void InsertDhaeDetailsToTempTable(string DhaeName)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO tbl_Dhae_temp SELECT * FROM tbl_Dhae Where Dhae_Name = '"+ DhaeName +"'", newCon.Con);
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                cmd.ExecuteNonQuery();
                newCon.Con.Close();
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
		// will throw an exception if there is an error connecting to the database
		//will be handled in the catch statement
		if(ConnectionState.Close == newCon.Con.State){
			newCon.Con.Open();
		}


		//INSERT will return success only if the City is not exists in the table otherwise will throw an exception
		SqlCommand Add_Dhae_Query = new SqlCommand("INSERT INTO tbl_Dhae (Dhae_ID,Dhae_Name,Dhae_Contact,House_No,Street_Name,City,District) VALUES ('" + Dhae_ID + "','" + Dhae_Name + "','" + Dhae_Contact + "','" + House_No + "','" + Street_Name + "','" + City + "','" + District + "')", newCon.Con);
		Add_Dhae_Query.ExecuteNonQuery();
		//Dhae is Added
		result = 1;
		newCon.Con.Close();
		return result;

	    }
	    catch (Exception ex)
	    {
		Console.WriteLine(ex.ToString());
		return result;
	    }

	}

        //Function to move the deleted Dhae details to Temporary Table
        public int InsertDhaeDetailsToDeleted(int Dhae_ID)
        {
            int result = 0; 
            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO tbl_Dhae_Deleted SELECT * FROM tbl_Dhae Where Dhae_ID = '" + Dhae_ID + "'", newCon.Con);
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                cmd.ExecuteNonQuery();
                newCon.Con.Close();
                result = 1;
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        //Function to Load All Dhae Details
        public DataTable ViewAllDhaes()
        {
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                string query = "Select * From tbl_Dhae";
                SqlDataAdapter sda = new SqlDataAdapter(query, newCon.Con);
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
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                string query = "Select * From tbl_Dhae Where Dhae_ID = '"+ DhaeID +"'";
                SqlDataAdapter sda = new SqlDataAdapter(query, newCon.Con);
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
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                SqlDataAdapter adp = new SqlDataAdapter("Update tbl_Dhae set Dhae_Name = ('" + Dhae_Name + "'), Dhae_Contact = ('" + Dhae_Contact + "'), House_No = ('" + Dhae_House_No + "'), Street_Name = ('" + Dhae_Street_Name + "'), City = ('" + Dhae_City + "'), District = ('" + Dhae_District + "') Where Dhae_ID = '" + Dhae_ID + "'", newCon.Con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                newCon.Con.Close();
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
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                SqlCommand adp = new SqlCommand("Delete From tbl_Dhae Where Dhae_ID = ('" + Dhae_ID + "')", newCon.Con);
                adp.ExecuteNonQuery();
                result = 1;
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
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                string query = "Select Dhae_Name From tbl_Dhae";
                SqlDataAdapter sda = new SqlDataAdapter(query, newCon.Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
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
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                string query = "Select Dhae_Contact From tbl_Dhae Where Dhae_Name = '" + DhaeName + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, newCon.Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Function to Load Dhae Details by Dhae Name
        public DataTable LoadDhaeDetailsByDhaeName(string DhaeName)
        {
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                string query = "Select * From tbl_Dhae Where Dhae_Name = '" + DhaeName + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, newCon.Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
