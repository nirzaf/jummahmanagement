﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace JummahManagement.Data
{
	class BranchData
	{
		DataCon newCon = new DataCon();

		//Function to Add Branch
		public int AddBranch(string Branch_ID, string Branch_Name, string JIP_Name, string JIP_Contact, string Building_No, string Street_Name, string City, string District)
		{
			try
			{
				int result = 0;
				try
				{
					if (newCon.Con.State == ConnectionState.Closed)
					{
						newCon.Con.Open();
					}

					SqlCommand Check_Branch = new SqlCommand("SELECT * FROM tbl_Branches WHERE Branch_ID = '" + Branch_ID + "'", newCon.Con);
					SqlDataReader reader = Check_Branch.ExecuteReader();

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
							if (newCon.Con.State == ConnectionState.Closed)
							{
								newCon.Con.Open();
							}
							SqlCommand cmd = new SqlCommand("INSERT INTO tbl_Branches (Branch_ID,Branch_Name,JIP_Name,JIP_Contact,No,Street_Name,City,District) VALUES ('" + Branch_ID + "','" + Branch_Name + "','" + JIP_Name + "','" + JIP_Contact + "','" + Building_No + "','" + Street_Name + "','" + City + "','" + District + "')", newCon.Con);
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
				SqlCommand cmd = new SqlCommand(@"CreateTempBranchTable", newCon.Con);
				cmd.CommandType = CommandType.StoredProcedure;
				if (newCon.Con.State == ConnectionState.Closed)
				{
					newCon.Con.Open();
				}
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
				if (newCon.Con.State == ConnectionState.Closed)
				{
					newCon.Con.Open();
				}
				SqlCommand adp = new SqlCommand("Delete From tbl_Branches_temp Where Branch_Name = ('" + BranchName + "')", newCon.Con);
				adp.ExecuteNonQuery();
				newCon.CloseSQLConnecion();
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
				SqlCommand cmd = new SqlCommand(@"INSERT INTO tbl_Branches_Deleted SELECT * FROM tbl_Branches Where Branch_ID = '" + Branch_ID + "'", newCon.Con);
				if (newCon.Con.State == ConnectionState.Closed)
				{
					newCon.Con.Open();
				}
				cmd.ExecuteNonQuery();
				result = 1;
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
				if (newCon.Con.State == ConnectionState.Closed)
				{
					newCon.Con.Open();
				}
				SqlDataAdapter sda = new SqlDataAdapter(query, newCon.Con);
				DataTable dt = new DataTable();
				sda.Fill(dt);
				newCon.CloseSQLConnecion();
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
				if (newCon.Con.State == ConnectionState.Closed)
				{
					newCon.Con.Open();
				}
				string query = "Select * From tbl_Branches Where Branch_ID = '" + Branch_ID + "'";
				SqlDataAdapter sda = new SqlDataAdapter(query, newCon.Con);
				DataTable dt = new DataTable();
				sda.Fill(dt);
				newCon.CloseSQLConnecion();
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
				if (newCon.Con.State == ConnectionState.Closed)
				{
					newCon.Con.Open();
				}
				string query = "Select * From tbl_Branches";
				SqlDataAdapter sda = new SqlDataAdapter(query, newCon.Con);
				DataTable dt = new DataTable();
				sda.Fill(dt);
				newCon.CloseSQLConnecion();
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
				if (newCon.Con.State == ConnectionState.Closed)
				{
					newCon.Con.Open();
				}
				string query = "Select Branch_ID,Branch_Name,JIP_Name,JIP_Contact,District From tbl_Branches";
				SqlDataAdapter sda = new SqlDataAdapter(query, newCon.Con);
				DataTable dt = new DataTable();
				sda.Fill(dt);
				newCon.CloseSQLConnecion();
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
				if (newCon.Con.State == ConnectionState.Closed)
				{
					newCon.Con.Open();
				}
				SqlDataAdapter adp = new SqlDataAdapter("Update tbl_Branches set Branch_Name = ('" + Branch_Name + "'), JIP_Name = ('" + JIP_Name + "'),JIP_Contact = ('" + JIP_Contact + "'), No = ('" + Branch_Building_No + "'), Street_Name = ('" + Branch_Street_Name + "'), City = ('" + Branch_City + "'), District = ('" + Branch_District + "') Where Branch_ID = '" + Branch_ID + "'", newCon.Con);
				DataTable dt = new DataTable();
				adp.Fill(dt);
				newCon.CloseSQLConnecion();
				result = 1;
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
				if (newCon.Con.State == ConnectionState.Closed)
				{
					newCon.Con.Open();
				}
				string query = "Select Branch_Name From tbl_Branches";
				SqlDataAdapter sda = new SqlDataAdapter(query, newCon.Con);
				DataTable dt = new DataTable();
				sda.Fill(dt);
				newCon.CloseSQLConnecion();
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
				if (newCon.Con.State == ConnectionState.Closed)
				{
					newCon.Con.Open();
				}
				string query = "Select Branch_ID From tbl_Branches Where Branch_Name = '" + BranchName + "'";
				SqlDataAdapter sda = new SqlDataAdapter(query, newCon.Con);
				DataTable dt = new DataTable();
				sda.Fill(dt);
				newCon.CloseSQLConnecion();
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
				if (newCon.Con.State == ConnectionState.Closed)
				{
					newCon.Con.Open();
				}
				SqlCommand adp = new SqlCommand("Delete From tbl_Branches Where Branch_ID = '" + Branch_ID + "'", newCon.Con);
				adp.ExecuteNonQuery();
				result = 1;
				newCon.CloseSQLConnecion();
				return result;
			}
			catch (Exception)
			{
				return result;
			}
		}
	}
}

