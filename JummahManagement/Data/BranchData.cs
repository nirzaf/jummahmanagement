using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows.Forms;

namespace JummahManagement.Data
{
	class BranchData
	{
		DataCon DataCon = new DataCon();
		//Function to Add Branch
		public int AddBranch(string Branch_ID, string Branch_Name, string JIP_Name, string JIP_Contact, string Building_No, string Street_Name, string City, string District)
		{
			try
			{
				int result = 0;
				try
				{
                    DataCon.Con.Open();
                    SQLiteCommand Check_Branch = new SQLiteCommand("SELECT * FROM tbl_Branches WHERE Branch_ID = '" + Branch_ID + "'", DataCon.Con);
					SQLiteDataReader reader = Check_Branch.ExecuteReader();

					if (reader.HasRows)
					{
						try
						{
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
                            DataCon.Con.Open();
                            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO tbl_Branches (Branch_ID,Branch_Name,JIP_Name,JIP_Contact,No,Street_Name,City,District) VALUES ('" + Branch_ID + "','" + Branch_Name + "','" + JIP_Name + "','" + JIP_Contact + "','" + Building_No + "','" + Street_Name + "','" + City + "','" + District + "')", DataCon.Con);
							cmd.ExecuteNonQuery();
							result = 1;
							return result;
						}
						catch (Exception)
						{
							return result;
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

		//Function to create temp branch Table
		public void CreateTempBranchTable()
		{
			try
			{
				SQLiteCommand cmd = new SQLiteCommand(@"CreateTempBranchTable", DataCon.Con);
				cmd.CommandType = CommandType.StoredProcedure;
                DataCon.Con.Open();
                cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		//Function to Delete Branch data  From TempDhae table
		public void DeleteBranchFromTempTable(string BranchName)
		{
			try
			{
                DataCon.Con.Open();
                SQLiteCommand adp = new SQLiteCommand("Delete From tbl_Branches_temp Where Branch_Name = ('" + BranchName + "')", DataCon.Con);
				adp.ExecuteNonQuery();				
			}
			catch (SQLiteException ex)
			{
				MessageBox.Show(ex.Message);
			}
            finally
            {
                DataCon.Con.Close();
            }
		}


		//Function to move the deleted Branch details to Temporary Table
		public int InsertBranchDetailsToDeleted(string Branch_ID)
		{
			int result = 0;
			try
			{
				SQLiteCommand cmd = new SQLiteCommand(@"INSERT INTO tbl_Branches_Deleted SELECT * FROM tbl_Branches Where Branch_ID = '" + Branch_ID + "'", DataCon.Con);
                DataCon.Con.Open();
                cmd.ExecuteNonQuery();
				result = 1;
				return result;
			}
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                DataCon.Con.Close();
            }
        }

		//Function to move the deleted Branch details to Temporary Table
		public DataTable GetRowCountForTempBranchTempTable()
		{
			try
			{
				string query = "Select Branch_Name From tbl_Branches_temp";
                DataCon.Con.Open();
                SQLiteDataAdapter sda = new SQLiteDataAdapter(query, DataCon.Con);
				DataTable dt = new DataTable();
				sda.Fill(dt);				
				return dt;
			}
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                DataCon.Con.Close();
            }
        }

		//Function to Load Branch by Branch ID
		public DataTable LoadBranchByBranchID(string Branch_ID)
		{
			try
			{
                DataCon.Con.Open();
                string query = "Select * From tbl_Branches Where Branch_ID = '" + Branch_ID + "'";
				SQLiteDataAdapter sda = new SQLiteDataAdapter(query, DataCon.Con);
				DataTable dt = new DataTable();
				sda.Fill(dt);				
				return dt;
			}
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                DataCon.Con.Close();
            }
        }

		//Function to Load all Branches
		public DataTable LoadAllBraches()
		{
			try
			{
                DataCon.Con.Open();
                string query = "Select * From tbl_Branches";
				SQLiteDataAdapter sda = new SQLiteDataAdapter(query, DataCon.Con);
				DataTable dt = new DataTable();
				sda.Fill(dt);				
				return dt;
			}
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                DataCon.Con.Close();
            }
        }

		//Function to Load all Branches
		public DataTable LoadBracheDetails()
		{
			try
			{
                DataCon.Con.Open();
                string query = "Select Branch_ID,Branch_Name,JIP_Name,JIP_Contact,District From tbl_Branches";
				SQLiteDataAdapter sda = new SQLiteDataAdapter(query, DataCon.Con);
				DataTable dt = new DataTable();
				sda.Fill(dt);				
				return dt;
			}
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                DataCon.Con.Close();
            }
        }

		//Function to Update Branch Details
		public int UpdateBranchDetails(string Branch_ID, string Branch_Name, string JIP_Name, string JIP_Contact, string Branch_Building_No, string Branch_Street_Name, string Branch_City, string Branch_District)
		{
			int result = 0;
			try
			{
                DataCon.Con.Open();
                SQLiteDataAdapter adp = new SQLiteDataAdapter("Update tbl_Branches set Branch_Name = ('" + Branch_Name + "'), JIP_Name = ('" + JIP_Name + "'),JIP_Contact = ('" + JIP_Contact + "'), No = ('" + Branch_Building_No + "'), Street_Name = ('" + Branch_Street_Name + "'), City = ('" + Branch_City + "'), District = ('" + Branch_District + "') Where Branch_ID = '" + Branch_ID + "'", DataCon.Con);
				DataTable dt = new DataTable();
				adp.Fill(dt);
				
				result = 1;
				return result;
			}
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                DataCon.Con.Close();
            }
        }

		//Function to Autoload Branch Name from Database to Front End
		public DataTable GetAllBranchNames()
		{
			try
			{
                DataCon.Con.Open();
                string query = "Select Branch_Name From tbl_Branches";
				SQLiteDataAdapter sda = new SQLiteDataAdapter(query, DataCon.Con);
				DataTable dt = new DataTable();
				sda.Fill(dt);
				
				return dt;
			}
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                DataCon.Con.Close();
            }
        }

		//Function to Get Branch ID from Branch Name to Front End
		public DataTable GetAllBranchIDByBranchName(string BranchName)
		{
			try
			{
                DataCon.Con.Open();
                string query = "Select Branch_ID From tbl_Branches Where Branch_Name = '" + BranchName + "'";
				SQLiteDataAdapter sda = new SQLiteDataAdapter(query, DataCon.Con);
				DataTable dt = new DataTable();
				sda.Fill(dt);
				
				return dt;
			}
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                DataCon.Con.Close();
            }
        }

		//Function to Delete Branch Details 
		public int DeleteBranchDetails(string Branch_ID)
		{
			int result = 0;
			try
			{
                DataCon.Con.Open();
				SQLiteCommand adp = new SQLiteCommand("Delete From tbl_Branches Where Branch_ID = '" + Branch_ID + "'", DataCon.Con);
				adp.ExecuteNonQuery();
				result = 1;
				
				return result;
			}
            catch (SQLiteException ex)
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
}

