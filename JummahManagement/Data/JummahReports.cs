using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnvDTE;
using JummahManagement.Data;

namespace JummahManagement.Data
{
    class JummahReports
    {
        DataCon newCon = new DataCon();

        //Function to Load All Jummah Dhae Report by date
        public DataTable LoadDhaeReportByDate(string Date)
        {
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                string query = "Select * From tbl_Jummah_Schedule Where Date = '" + Date + "'";
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

        //Function to load All city Names
        public DataTable GetCity()
        {
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                SqlDataAdapter cmdCat = new SqlDataAdapter("SELECT * FROM tbl_City", newCon.Con);
                DataTable dt = new DataTable();
                cmdCat.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Function to update City names
        public int UpdateCityName(int CityID, string CityName)
        {
            int result = 0;
            try
            {              
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE tbl_City SET City = '"+ CityName +"' WHERE City_ID = '"+ CityID +"'", newCon.Con);
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

        //Function to load jummah Schedule by date
        public DataTable JummaScheduleReportByDate(string Date)
        {
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                SqlDataAdapter cmdCat = new SqlDataAdapter("SELECT * FROM tbl_Jummah_Schedule Where Date = '"+ Date +"'", newCon.Con);
                DataTable dt = new DataTable();
                cmdCat.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Function to Insert Jumma  Schedule into Temporary Table
        public int AddJummaSchedule(int RowCount, string DhaeName, string DhaeContact, string BranchName, string JIPName, string JIPContact, string Date)
        {
            try
            {
                int result = 0;
                try
                {
                    if (ConnectionState.Closed == newCon.Con.State)
                    {
                        newCon.Con.Open();
                        SqlCommand Check_Branch = new SqlCommand("SELECT * FROM tbl_Branches WHERE Branch_ID = '" + DhaeName + "'", newCon.Con);
                        SqlDataReader reader = Check_Branch.ExecuteReader();

                        if (reader.HasRows)
                        {
                            try
                            {
                                reader.Close();
                                MessageBox.Show("This Dhae Assigned Already");
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
                                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_Jummah_Schedule_temp (Row_Count,Dhae_Name,Dhae_Contact,Branch_Name,JIP_Name,JIP_Contact,Date) VALUES ('" + RowCount + "','" + DhaeName + "','" + DhaeContact + "','" + BranchName + "','" + JIPName + "','" + JIPContact + "','" + Date + "')", newCon.Con);
                                cmd.ExecuteNonQuery();
                                result = 1;
                                reader.Close();
                                newCon.Con.Close();
                                return result;
                            }
                            catch (Exception)
                            {
                                reader.Close();
                                newCon.Con.Close();
                                return result;
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            SqlCommand Check_Branch = new SqlCommand("SELECT * FROM tbl_Branches WHERE Branch_ID = '" + DhaeName + "'", newCon.Con);
                            SqlDataReader reader = Check_Branch.ExecuteReader();

                            if (reader.HasRows)
                            {
                                try
                                {
                                    reader.Close();
                                    MessageBox.Show("This Branch is already exisits in the System");
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
                                    SqlCommand cmd = new SqlCommand("INSERT INTO tbl_Jummah_Schedule_temp (Row_Count,Dhae_Name,Dhae_Contact,Branch_Name,JIP_Name,JIP_Contact,Date) VALUES ('" + RowCount + "','" + DhaeName + "','" + DhaeContact + "','" + BranchName + "','" + JIPName + "','" + JIPContact + "','" + Date + "')", newCon.Con);
                                    cmd.ExecuteNonQuery();
                                    result = 1;
                                    reader.Close();
                                    newCon.Con.Close();
                                    return result;
                                }
                                catch (Exception)
                                {
                                    reader.Close();
                                    newCon.Con.Close();
                                    return result;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            newCon.Con.Close();
                            throw;
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

        //function to drop and recreate the temp table
        public void DropAndRecreate()
        {
            try
            {
                    SqlCommand command = new SqlCommand(@"USE [dbJummah_Management]
                            DROP TABLE [dbo].[tbl_Jummah_Schedule_temp]
                            CREATE TABLE [dbo].[tbl_Jummah_Schedule_temp](
	                            [ID] [int] IDENTITY(1,1) NOT NULL,
	                            [Row_Count] [int] NOT NULL,
	                            [Dhae_Name] [nvarchar](50) NOT NULL,
	                            [Dhae_Contact] [nvarchar](20) NOT NULL,
	                            [Branch_Name] [nvarchar](50) NOT NULL,
	                            [JIP_Name] [nvarchar](50) NOT NULL,
	                            [JIP_Contact] [nvarchar](50) NOT NULL,
	                            [Date] [nvarchar](20) NOT NULL,
                             CONSTRAINT [PK_tbl_Jummah_Schedule_temp] PRIMARY KEY CLUSTERED 
                            (
	                            [ID] ASC
                            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                            ) ON [PRIMARY]", newCon.Con);
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                command.ExecuteNonQuery();
                newCon.Con.Close();             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
