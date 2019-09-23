using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace JummahManagement.Data
{
	class BranchData
	{
		DataCon C = new DataCon();

		//Function to Add Branch
		public int AddBranch(string Branch_ID, string Branch_Name, string JIP_Name, string JIP_Contact, string Building_No, string Street_Name, string City, string District)
		{
				int result = 0;
				try
                {
                    MySqlDataReader reader;
                    using (MySqlCommand Check_Branch = new MySqlCommand("SELECT * FROM tbl_Branches WHERE Branch_ID = '" + Branch_ID + "'", C.Con))
                    {
                        C.Con.Open();
                        reader = Check_Branch.ExecuteReader();
                    }

                    if (reader.HasRows)
                    {
                         MessageBox.Show("This Branch is already exisits in the System");
                         return result;
                    }
                    else
                    {
                        try
                        {
                            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO tbl_Branches (Branch_ID,Branch_Name,JIP_Name,JIP_Contact,No,Street_Name,City,District) VALUES ('" + Branch_ID + "','" + Branch_Name + "','" + JIP_Name + "','" + JIP_Contact + "','" + Building_No + "','" + Street_Name + "','" + City + "','" + District + "')", C.Con))
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
                using (MySqlCommand cmd = new MySqlCommand(@"CreateTempBranchTable", C.Con){CommandType = CommandType.StoredProcedure})
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

		//Function to Delete Branch data  From TempDhae table
		public void DeleteBranchFromTempTable(string BranchName)
		{
			try
            {
                using (MySqlCommand adp = new MySqlCommand("Delete From tbl_Branches_temp Where Branch_Name = ('" + BranchName + "')", C.Con))
                {
                    C.Con.Open();
                    adp.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
        }


		//Function to move the deleted Branch details to Temporary Table
		public int InsertBranchDetailsToDeleted(string Branch_ID)
		{
			int result = 0;
			try
            {
                using (MySqlCommand cmd = new MySqlCommand(@"INSERT INTO tbl_Branches_Deleted SELECT * FROM tbl_Branches Where Branch_ID = '" + Branch_ID + "'", C.Con))
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

		//Function to move the deleted Branch details to Temporary Table
		public DataTable GetRowCountForTempBranchTempTable()
		{
			try
            {
                string query = "Select Branch_Name From tbl_Branches_temp";
                DataTable dt = new DataTable();
                using (MySqlDataAdapter sda = new MySqlDataAdapter(query, C.Con))
                {
                    C.Con.Open();
                    sda.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				throw;
			}
		}

		//Function to Load Branch by Branch ID
		public DataTable LoadBranchByBranchID(string Branch_ID)
		{
			try
			{
                DataTable dt = new DataTable();
                string query = "Select * From tbl_Branches Where Branch_ID = '" + Branch_ID + "'";
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

		//Function to Load all Branches
		public DataTable LoadAllBraches()
		{
			try
			{
                DataTable dt = new DataTable();
                string query = "Select * From tbl_Branches";
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

		//Function to Load all Branches
		public DataTable LoadBracheDetails()
		{
			try
            {
                DataTable dt = new DataTable();              
                string query = "Select Branch_ID,Branch_Name,JIP_Name,JIP_Contact,District From tbl_Branches";
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

		//Function to Update Branch Details
		public int UpdateBranchDetails(string Branch_ID, string Branch_Name, string JIP_Name, string JIP_Contact, string Branch_Building_No, string Branch_Street_Name, string Branch_City, string Branch_District)
		{
			int result = 0;
			try
            { 
                using (MySqlCommand cmd = new MySqlCommand("Update tbl_Branches set Branch_Name = ('" + Branch_Name + "'), JIP_Name = ('" + JIP_Name + "'),JIP_Contact = ('" + JIP_Contact + "'), No = ('" + Branch_Building_No + "'), Street_Name = ('" + Branch_Street_Name + "'), City = ('" + Branch_City + "'), District = ('" + Branch_District + "') Where Branch_ID = '" + Branch_ID + "'", C.Con))
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

		//Function to Autoload Branch Name from Database to Front End
		public DataTable GetAllBranchNames()
		{
			try
            {
                DataTable dt = new DataTable();
                string query = "Select Branch_Name From tbl_Branches";
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

		//Function to Get Branch ID from Branch Name to Front End
		public DataTable GetAllBranchIDByBranchName(string BranchName)
		{
			try
            {
                string query = "Select Branch_ID From tbl_Branches Where Branch_Name = '" + BranchName + "'";
                DataTable dt = new DataTable();
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

		//Function to Delete Branch Details 
		public int DeleteBranchDetails(string Branch_ID)
		{
			int result = 0;
			try
            {
                using (MySqlCommand adp = new MySqlCommand("Delete From tbl_Branches Where Branch_ID = '" + Branch_ID + "'", C.Con))
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
	}
}

