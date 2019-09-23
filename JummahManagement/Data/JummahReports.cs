using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace JummahManagement.Data
{
	class JummahReports
	{
		DataCon C = new DataCon();

		//Function to Complete DGV Dt Jumma Schedule
		public DataTable LoadDGVdtJummaSchedule()
		{
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            try
			{
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_Jummah_Schedule_temp", C.Con))
                {
                    C.Con.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        ds.Tables.Add(dt);
                        ds.EnforceConstraints = false;
                        dt.Load(dr);
                    }
                }
				return dt;
			}
			catch (Exception)
			{
                throw;
			}
		}

		//Function to Complete Jumma Report
		public DataTable GetAll()
		{
			try
			{
				if (C.Con.State == ConnectionState.Closed)
				{
					C.Con.Open();
				}
				MySqlDataAdapter cmdCat = new MySqlDataAdapter("SELECT * FROM tbl_Jummah_Schedule", C.Con);
				DataTable dt = new DataTable();
				cmdCat.Fill(dt);
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
				if (C.Con.State == ConnectionState.Closed)
				{
					C.Con.Open();
				}
				MySqlDataAdapter cmdCat = new MySqlDataAdapter("SELECT Branch_Name FROM tbl_Jummah_Schedule Where Date = '" + Date + "' AND Dhae_Name ='" + DhaeName + "' ", C.Con);
				DataTable dt = new DataTable();
				cmdCat.Fill(dt);				
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
				if (C.Con.State == ConnectionState.Closed)
				{
					C.Con.Open();
				}
				MySqlDataAdapter cmdCat = new MySqlDataAdapter("SELECT Dhae_Name FROM tbl_Jummah_Schedule Where Date = '" + Date + "' AND Branch_Name ='"+ BranchName +"' ", C.Con);
				DataTable dt = new DataTable();
				cmdCat.Fill(dt);
				
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
				if (C.Con.State == ConnectionState.Closed)
				{
					C.Con.Open();
				}
				MySqlDataAdapter cmdCat = new MySqlDataAdapter("Select * From tbl_Jummah_Schedule Where Date = '" + Date + "'", C.Con);
				DataTable dt = new DataTable();
				cmdCat.Fill(dt);
				
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
				if (C.Con.State == ConnectionState.Closed)
				{
					C.Con.Open();
				}
				MySqlDataAdapter cmdCat = new MySqlDataAdapter("GetCities", C.Con);
				cmdCat.SelectCommand.CommandType = CommandType.StoredProcedure;
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
				if (C.Con.State == ConnectionState.Closed)
				{
					C.Con.Open();
				}
				MySqlCommand cmd = new MySqlCommand("UPDATE tbl_City SET City = '"+ CityName +"' WHERE City_ID = '"+ CityID +"'", C.Con);
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
				if (C.Con.State == ConnectionState.Closed)
				{
					C.Con.Open();
				}
				MySqlDataAdapter cmdCat = new MySqlDataAdapter("SELECT * FROM tbl_Jummah_Schedule Where Date = '"+ Date +"'", C.Con);
				DataTable dt = new DataTable();
				
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
				if (C.Con.State == ConnectionState.Closed)
				{
					C.Con.Open();
				}
				MySqlCommand cmd = new MySqlCommand("DELETE FROM tbl_Jummah_Schedule_temp Where ID = '" + RowID + "'", C.Con);
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

		//Function to Delete Selected Row from Completed Schedule
		public int DeleteScheduleRow(int ID)
		{
			int result = 0;
			try
			{
				if (C.Con.State == ConnectionState.Closed)
				{
					C.Con.Open();
				}
				MySqlCommand cmd = new MySqlCommand("DELETE FROM tbl_Jummah_Schedule Where ID = '" + ID + "'", C.Con);
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


		//Function to Insert Jumma  Schedule into Temporary Table
		public int AddJummaSchedule(int RowCount, string DhaeName, string DhaeContact, string BranchName, string JIPName, string JIPContact, string Date)
		{
			try
			{
				int result = 0;
				try
				{
					if (C.Con.State == ConnectionState.Open)
					{
						MySqlCommand Check_Dhae = new MySqlCommand("SELECT * FROM tbl_Jummah_Schedule_temp WHERE Dhae_Name = '" + DhaeName + "'", C.Con);
						MySqlCommand Check_Branch = new MySqlCommand("SELECT * FROM tbl_Jummah_Schedule_temp WHERE Branch_Name = '" + BranchName + "'", C.Con);
						MySqlDataReader reader = Check_Dhae.ExecuteReader();
						MySqlDataReader reader1 = Check_Branch.ExecuteReader();

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
								
								throw;
							}
						}
						else
						{
							try
							{
								MySqlCommand cmd = new MySqlCommand("INSERT INTO tbl_Jummah_Schedule_temp (Row_Count,Dhae_Name,Dhae_Contact,Branch_Name,JIP_Name,JIP_Contact,Date) VALUES ('" + RowCount + "','" + DhaeName + "','" + DhaeContact + "','" + BranchName + "','" + JIPName + "','" + JIPContact + "','" + Date + "')", C.Con);
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
							if (C.Con.State == ConnectionState.Closed)
							{
								C.Con.Open();
							}
							MySqlCommand Check_Dhae = new MySqlCommand("SELECT * FROM tbl_Jummah_Schedule_temp WHERE Dhae_Name = '" + DhaeName + "'", C.Con);
							MySqlCommand Check_Branch = new MySqlCommand("SELECT * FROM tbl_Jummah_Schedule_temp WHERE Branch_Name = '" + BranchName + "'", C.Con);
							MySqlDataReader reader = Check_Dhae.ExecuteReader();
							MySqlDataReader reader1 = Check_Branch.ExecuteReader();

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
									
									throw;
								}
							}
							else
							{
								try
								{
									if (C.Con.State == ConnectionState.Closed)
									{
										C.Con.Open();
									}
									MySqlCommand cmd = new MySqlCommand("INSERT INTO tbl_Jummah_Schedule_temp (Row_Count,Dhae_Name,Dhae_Contact,Branch_Name,JIP_Name,JIP_Contact,Date) VALUES ('" + RowCount + "','" + DhaeName + "','" + DhaeContact + "','" + BranchName + "','" + JIPName + "','" + JIPContact + "','" + Date + "')", C.Con);
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
							C.Con.Close();
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
				if (C.Con.State == ConnectionState.Closed)
				{
					C.Con.Open();
				}
				MySqlDataAdapter cmdCat = new MySqlDataAdapter("SELECT Branch_Name,Dhae_Name FROM tbl_Jummah_Schedule Where Date = '" + Date + "'", C.Con);
				DataTable dt = new DataTable();
				cmdCat.Fill(dt);
				
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
					MySqlCommand command = new MySqlCommand(@"USE [JummahManagement]
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
							) ON [PRIMARY]", C.Con);
				if (C.Con.State == ConnectionState.Closed)
				{
					C.Con.Open();
				}
				command.ExecuteNonQuery();
				
			}
			catch (Exception ex)
			{
				
				MessageBox.Show(ex.Message);
			}
		}
	}
}
