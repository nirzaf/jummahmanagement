using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace JummahManagement.Data
{
    class JummahReports
    {
        DataCon newCon = new DataCon();

        //Function to Complete DGV Dt Jumma Schedule
        public DataTable LoadDGVdtJummaSchedule()
        {
            DataTable dt = new DataTable();
            try
            {
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                SqlDataAdapter cmdCat = new SqlDataAdapter("SELECT * FROM tbl_Jummah_Schedule_temp", newCon.Con);
                cmdCat.Fill(dt);
                newCon.CloseSQLConnecion();
                return dt;
            }
            catch (Exception)
            {
                newCon.CloseSQLConnecion();
                dt = null;
                return dt;
            }
        }

        //Function to Complete Jumma Report
        public DataTable GetAll()
        {
            try
            {
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                SqlDataAdapter cmdCat = new SqlDataAdapter("SELECT * FROM tbl_Jummah_Schedule", newCon.Con);
                DataTable dt = new DataTable();
                cmdCat.Fill(dt);
                newCon.CloseSQLConnecion();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Function to load Last four weeks jummah report for Dhae Name  
        public DataTable LastMonthBranchReportByDate(string Date, string DhaeName)
        {
            try
            {
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                SqlDataAdapter cmdCat = new SqlDataAdapter("SELECT Branch_Name FROM tbl_Jummah_Schedule Where Date = '" + Date + "' AND Dhae_Name ='" + DhaeName + "' ", newCon.Con);
                DataTable dt = new DataTable();
                cmdCat.Fill(dt);
                newCon.CloseSQLConnecion();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Function to load Last four weeks jummah report for Branch Name  
        public DataTable LastMonthDhaeReportByDate(string Date, string BranchName)
        {
            try
            {
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                SqlDataAdapter cmdCat = new SqlDataAdapter("SELECT Dhae_Name FROM tbl_Jummah_Schedule Where Date = '" + Date + "' AND Branch_Name ='"+ BranchName +"' ", newCon.Con);
                DataTable dt = new DataTable();
                cmdCat.Fill(dt);
                newCon.CloseSQLConnecion();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Function to Load All Jummah Dhae Report by date
        public DataTable LoadDhaeReportByDate(string Date)
        {
            try
            {
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                SqlDataAdapter cmdCat = new SqlDataAdapter("Select * From tbl_Jummah_Schedule Where Date = '" + Date + "'", newCon.Con);
                DataTable dt = new DataTable();
                cmdCat.Fill(dt);
                newCon.CloseSQLConnecion();
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
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                SqlDataAdapter cmdCat = new SqlDataAdapter("SELECT * FROM tbl_City", newCon.Con);
                DataTable dt = new DataTable();
                cmdCat.Fill(dt);
                newCon.CloseSQLConnecion();
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
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE tbl_City SET City = '"+ CityName +"' WHERE City_ID = '"+ CityID +"'", newCon.Con);
                cmd.ExecuteNonQuery();
                result = 1;
                newCon.CloseSQLConnecion();
                return result;
            }
            catch (Exception ex)
            {
                newCon.CloseSQLConnecion();
                MessageBox.Show(ex.Message);
                return result;
            }
        }

        //Function to load jummah Schedule by date
        public DataTable JummaScheduleReportByDate(string Date)
        {
            try
            {
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                SqlDataAdapter cmdCat = new SqlDataAdapter("SELECT * FROM tbl_Jummah_Schedule Where Date = '"+ Date +"'", newCon.Con);
                DataTable dt = new DataTable();
                newCon.CloseSQLConnecion();
                cmdCat.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Function to Delete Selected Row from Temp Schedule List
        public int DeleteTempRow(int RowID)
        {
            int result = 0;
            try
            {
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM tbl_Jummah_Schedule_temp Where ID = '" + RowID + "'", newCon.Con);
                cmd.ExecuteNonQuery();
                result = 1;
                newCon.CloseSQLConnecion();
                return result;
            }
            catch (Exception ex)
            {
                newCon.CloseSQLConnecion();
                MessageBox.Show(ex.Message);
                return result;
            }
        }

        //Function to Delete Selected Row from Completed Schedule
        public int DeleteScheduleRow(int ID)
        {
            int result = 0;
            try
            {
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM tbl_Jummah_Schedule Where ID = '" + ID + "'", newCon.Con);
                cmd.ExecuteNonQuery();
                result = 1;
                newCon.CloseSQLConnecion();
                return result;
            }
            catch (Exception ex)
            {
                newCon.CloseSQLConnecion();
                MessageBox.Show(ex.Message);
                return result;
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
                    if (newCon.Con.State == ConnectionState.Open)
                    {
                        SqlCommand Check_Dhae = new SqlCommand("SELECT * FROM tbl_Jummah_Schedule_temp WHERE Dhae_Name = '" + DhaeName + "'", newCon.Con);
                        SqlCommand Check_Branch = new SqlCommand("SELECT * FROM tbl_Jummah_Schedule_temp WHERE Branch_Name = '" + BranchName + "'", newCon.Con);
                        SqlDataReader reader = Check_Dhae.ExecuteReader();
                        SqlDataReader reader1 = Check_Branch.ExecuteReader();

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
                                newCon.CloseSQLConnecion();
                                throw;
                            }
                        }
                        else if (reader1.HasRows)
                        {
                            try
                            {
                                reader.Close();
                                MessageBox.Show("This Branch Assigned Already");
                                return result;
                            }
                            catch (Exception)
                            {
                                newCon.CloseSQLConnecion();
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
                            SqlCommand Check_Dhae = new SqlCommand("SELECT * FROM tbl_Jummah_Schedule_temp WHERE Dhae_Name = '" + DhaeName + "'", newCon.Con);
                            SqlCommand Check_Branch = new SqlCommand("SELECT * FROM tbl_Jummah_Schedule_temp WHERE Branch_Name = '" + BranchName + "'", newCon.Con);
                            SqlDataReader reader = Check_Dhae.ExecuteReader();
                            SqlDataReader reader1 = Check_Branch.ExecuteReader();

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
                                    newCon.CloseSQLConnecion();
                                    throw;
                                }
                            }
                            else if (reader1.HasRows)
                            {
                                try
                                {
                                    reader.Close();
                                    MessageBox.Show("This Branch Assigned Already");
                                    newCon.CloseSQLConnecion();
                                    return result;
                                }
                                catch (Exception)
                                {
                                    newCon.CloseSQLConnecion();
                                    throw;
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
                                    SqlCommand cmd = new SqlCommand("INSERT INTO tbl_Jummah_Schedule_temp (Row_Count,Dhae_Name,Dhae_Contact,Branch_Name,JIP_Name,JIP_Contact,Date) VALUES ('" + RowCount + "','" + DhaeName + "','" + DhaeContact + "','" + BranchName + "','" + JIPName + "','" + JIPContact + "','" + Date + "')", newCon.Con);
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

        //PDF Report by Date 
        public DataTable PDFJummaScheduleReportByDate(string Date)
        {
            try
            {
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                SqlDataAdapter cmdCat = new SqlDataAdapter("SELECT Branch_Name,Dhae_Name FROM tbl_Jummah_Schedule Where Date = '" + Date + "'", newCon.Con);
                DataTable dt = new DataTable();
                cmdCat.Fill(dt);
                newCon.CloseSQLConnecion();
                return dt;
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
                if (newCon.Con.State == ConnectionState.Closed)
                {
                    newCon.Con.Open();
                }
                command.ExecuteNonQuery();
                newCon.CloseSQLConnecion();
            }
            catch (Exception ex)
            {
                newCon.CloseSQLConnecion();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
