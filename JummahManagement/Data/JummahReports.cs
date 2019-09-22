using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows.Forms;

namespace JummahManagement.Data
{
	class JummahReports
	{
		DataCon DataCon = new DataCon();

		//Function to Complete DGV Dt Jumma Schedule
		public DataTable LoadDGVdtJummaSchedule()
		{
			DataTable dt = new DataTable();
			try
			{
                DataCon.Con.Open();
				SQLiteDataAdapter cmdCat = new SQLiteDataAdapter("SELECT * FROM tbl_Jummah_Schedule_temp", DataCon.Con);
				cmdCat.Fill(dt);
				
				return dt;
			}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                DataCon.Con.Close();
            }
        }

		//Function to Complete Jumma Report
		public DataTable GetAll()
		{
			try
			{
                DataCon.Con.Open();
                SQLiteDataAdapter cmdCat = new SQLiteDataAdapter("SELECT * FROM tbl_Jummah_Schedule", DataCon.Con);
				DataTable dt = new DataTable();
				cmdCat.Fill(dt);			
				return dt;
			}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                DataCon.Con.Close();
            }
        }

		//Function to load Last four weeks jummah report for Dhae Name  
		public DataTable LastMonthBranchReportByDate(string Date, string DhaeName)
		{
			try
			{
                DataCon.Con.Open();
                SQLiteDataAdapter cmdCat = new SQLiteDataAdapter("SELECT Branch_Name FROM tbl_Jummah_Schedule Where Date = '" + Date + "' AND Dhae_Name ='" + DhaeName + "' ", DataCon.Con);
				DataTable dt = new DataTable();
				cmdCat.Fill(dt);				
				return dt;
			}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                DataCon.Con.Close();
            }
        }

		//Function to load Last four weeks jummah report for Branch Name  
		public DataTable LastMonthDhaeReportByDate(string Date, string BranchName)
		{
			try
			{
                DataCon.Con.Open();
                SQLiteDataAdapter cmdCat = new SQLiteDataAdapter("SELECT Dhae_Name FROM tbl_Jummah_Schedule Where Date = '" + Date + "' AND Branch_Name ='"+ BranchName +"' ", DataCon.Con);
				DataTable dt = new DataTable();
				cmdCat.Fill(dt);				
				return dt;
			}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                DataCon.Con.Close();
            }
        }

		//Function to Load All Jummah Dhae Report by date
		public DataTable LoadDhaeReportByDate(string Date)
		{
			try
			{
                DataCon.Con.Open();
                SQLiteDataAdapter cmdCat = new SQLiteDataAdapter("Select * From tbl_Jummah_Schedule Where Date = '" + Date + "'", DataCon.Con);
				DataTable dt = new DataTable();
				cmdCat.Fill(dt);				
				return dt;
			}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                DataCon.Con.Close();
            }
        }

		//Function to load All city Names
		public DataTable GetCity()
		{
			try
			{
                DataCon.Con.Open();
                SQLiteDataAdapter cmdCat = new SQLiteDataAdapter("GetCities", DataCon.Con);
				cmdCat.SelectCommand.CommandType = CommandType.StoredProcedure;
				DataTable dt = new DataTable();
				cmdCat.Fill(dt);				
				return dt;
			}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                DataCon.Con.Close();
            }
        }

		//Function to update City names
		public int UpdateCityName(int CityID, string CityName)
		{
			int result = 0;
			try
			{
                DataCon.Con.Open();
                SQLiteCommand cmd = new SQLiteCommand("UPDATE tbl_City SET City = '"+ CityName +"' WHERE City_ID = '"+ CityID +"'", DataCon.Con);
				cmd.ExecuteNonQuery();
				result = 1;				
			}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DataCon.Con.Close();
            }
            return result;
        }

		//Function to load jummah Schedule by date
		public DataTable JummaScheduleReportByDate(string Date)
		{
			try
			{
                DataCon.Con.Open();
                SQLiteDataAdapter cmdCat = new SQLiteDataAdapter("SELECT * FROM tbl_Jummah_Schedule Where Date = '"+ Date +"'", DataCon.Con);
				DataTable dt = new DataTable();				
				cmdCat.Fill(dt);
				return dt;
			}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                DataCon.Con.Close();
            }
        }

		//Function to Delete Selected Row from Temp Schedule List
		public int DeleteTempRow(int RowID)
		{
			int result = 0;
			try
			{
                DataCon.Con.Open();
                SQLiteCommand cmd = new SQLiteCommand("DELETE FROM tbl_Jummah_Schedule_temp Where ID = '" + RowID + "'", DataCon.Con);
				cmd.ExecuteNonQuery();
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
                DataCon.Con.Close();
            }
        }

		//Function to Delete Selected Row from Completed Schedule
		public int DeleteScheduleRow(int ID)
		{
			int result = 0;
			try
			{
                DataCon.Con.Open();
                SQLiteCommand cmd = new SQLiteCommand("DELETE FROM tbl_Jummah_Schedule Where ID = '" + ID + "'", DataCon.Con);
				cmd.ExecuteNonQuery();
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
                DataCon.Con.Close();
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
					if (DataCon.Con.State == ConnectionState.Open)
					{
						SQLiteCommand Check_Dhae = new SQLiteCommand("SELECT * FROM tbl_Jummah_Schedule_temp WHERE Dhae_Name = '" + DhaeName + "'", DataCon.Con);
						SQLiteCommand Check_Branch = new SQLiteCommand("SELECT * FROM tbl_Jummah_Schedule_temp WHERE Branch_Name = '" + BranchName + "'", DataCon.Con);
						SQLiteDataReader reader = Check_Dhae.ExecuteReader();
						SQLiteDataReader reader1 = Check_Branch.ExecuteReader();

						if (reader.HasRows)
						{
							try
							{
								reader.Close();
								MessageBox.Show("This Dhae Assigned Already");
                                return result;
                            }
							catch (Exception ex)
							{
                                MessageBox.Show(ex.Message);
                                return 0;
                            }
                            finally
                            {
                                DataCon.Con.Close();
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
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                return 0;
                            }
                            finally
                            {
                                DataCon.Con.Close();
                            }
                        }
						else
						{
							try
							{
								SQLiteCommand cmd = new SQLiteCommand("INSERT INTO tbl_Jummah_Schedule_temp (Row_Count,Dhae_Name,Dhae_Contact,Branch_Name,JIP_Name,JIP_Contact,Date) VALUES ('" + RowCount + "','" + DhaeName + "','" + DhaeContact + "','" + BranchName + "','" + JIPName + "','" + JIPContact + "','" + Date + "')", DataCon.Con);
								cmd.ExecuteNonQuery();
								result = 1;
								reader.Close();								
								return result;
							}
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                return 0;
                            }
                            finally
                            {
                                DataCon.Con.Close();
                            }
                        }
					}
					else
					{
						try
						{
							if (DataCon.Con.State == ConnectionState.Closed)
							{
								DataCon.Con.Open();
							}
							SQLiteCommand Check_Dhae = new SQLiteCommand("SELECT * FROM tbl_Jummah_Schedule_temp WHERE Dhae_Name = '" + DhaeName + "'", DataCon.Con);
							SQLiteCommand Check_Branch = new SQLiteCommand("SELECT * FROM tbl_Jummah_Schedule_temp WHERE Branch_Name = '" + BranchName + "'", DataCon.Con);
							SQLiteDataReader reader = Check_Dhae.ExecuteReader();
							SQLiteDataReader reader1 = Check_Branch.ExecuteReader();

							if (reader.HasRows)
							{
								try
								{
									reader.Close();
									MessageBox.Show("This Dhae Assigned Already");
									return result;
								}
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    return 0;
                                }
                                finally
                                {
                                    DataCon.Con.Close();
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
							else
							{
								try
								{
									if (DataCon.Con.State == ConnectionState.Closed)
									{
										DataCon.Con.Open();
									}
									SQLiteCommand cmd = new SQLiteCommand("INSERT INTO tbl_Jummah_Schedule_temp (Row_Count,Dhae_Name,Dhae_Contact,Branch_Name,JIP_Name,JIP_Contact,Date) VALUES ('" + RowCount + "','" + DhaeName + "','" + DhaeContact + "','" + BranchName + "','" + JIPName + "','" + JIPContact + "','" + Date + "')", DataCon.Con);
									cmd.ExecuteNonQuery();
									result = 1;
									reader.Close();
									
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                if(DataCon.Con!=null)
                DataCon.Con.Close();
            }
        }

		//PDF Report by Date 
		public DataTable PDFJummaScheduleReportByDate(string Date)
		{
			try
			{
                DataCon.Con.Open();
                SQLiteDataAdapter cmdCat = new SQLiteDataAdapter("SELECT Branch_Name,Dhae_Name FROM tbl_Jummah_Schedule Where Date = '" + Date + "'", DataCon.Con);
				DataTable dt = new DataTable();
				cmdCat.Fill(dt);
				
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

		//function to drop and recreate the temp table
		public void DropAndRecreate()
		{
			try
			{
                SQLiteCommand command = new SQLiteCommand(@"DROP TABLE [tbl_Jummah_Schedule_temp];
                    CREATE TABLE [tbl_Jummah_Schedule_temp] 
                      ([ID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
                    , [Row_Count] int NOT NULL
                    , [Dhae_Name] nvarchar(50) NOT NULL COLLATE NOCASE
                    , [Dhae_Contact] nvarchar(20) NOT NULL COLLATE NOCASE
                    , [Branch_Name] nvarchar(50) NOT NULL COLLATE NOCASE
                    , [JIP_Name] nvarchar(50) NOT NULL COLLATE NOCASE
                    , [JIP_Contact] nvarchar(50) NOT NULL COLLATE NOCASE
                    , [Date] nvarchar(20) NOT NULL COLLATE NOCASE
                    );", DataCon.Con);
                DataCon.Con.Open();
				command.ExecuteNonQuery();			
			}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (DataCon.Con != null)
                    DataCon.Con.Close();
            }
        }
	}
}
