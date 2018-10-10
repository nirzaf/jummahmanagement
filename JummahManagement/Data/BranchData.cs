using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using JummahManagement;

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
                    if (ConnectionState.Closed == newCon.Con.State)
                    {
                        newCon.Con.Open();
                        SqlCommand Check_Branch = new SqlCommand("SELECT * FROM tbl_Branches WHERE Branch_ID = '" + Branch_ID + "'", newCon.Con);
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
                                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_Branches (Branch_ID,Branch_Name,JIP_Name,JIP_Contact,No,Street_Name,City,District) VALUES ('" + Branch_ID + "','" + Branch_Name + "','" + JIP_Name + "','" + JIP_Contact + "','" + Building_No + "','" + Street_Name + "','" + City + "','" + District + "')", newCon.Con);
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
                            SqlCommand Check_Branch = new SqlCommand("SELECT * FROM tbl_Branches WHERE Branch_ID = '" + Branch_ID + "'", newCon.Con);
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
                                    SqlCommand cmd = new SqlCommand("INSERT INTO tbl_Branches (Branch_ID,Branch_Name,JIP_Name,JIP_Contact,No,Street_Name,City,District) VALUES ('" + Branch_ID + "','" + Branch_Name + "','" + JIP_Name + "','" + JIP_Contact + "','" + Building_No + "','" + Street_Name + "','" + City + "','" + District + "')", newCon.Con);
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

        //Function to move the deleted Branch details to Temporary Table
        public int InsertBranchDetailsToDeleted(string Branch_ID)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO tbl_Branches_Deleted SELECT * FROM tbl_Branches Where Branch_ID = '" + Branch_ID + "'", newCon.Con);
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

        //Function to Load Branch by Branch ID
        public DataTable LoadBranchByBranchID(string Branch_ID)
        {
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                string query = "Select * From tbl_Branches Where Branch_ID = '" + Branch_ID + "'";
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

        //Function to Update Branch Details
        public int UpdateBranchDetails(string Branch_ID, string Branch_Name, string JIP_Name, string JIP_Contact, string Branch_Building_No, string Branch_Street_Name, string Branch_City, string Branch_District)
        {
            int result = 0;
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                SqlDataAdapter adp = new SqlDataAdapter("Update tbl_Branches set Branch_Name = ('" + Branch_Name + "'), JIP_Name = ('" + JIP_Name + "'),JIP_Contact = ('" + JIP_Contact + "'), No = ('" + Branch_Building_No + "'), Street_Name = ('" + Branch_Street_Name + "'), City = ('" + Branch_City + "'), District = ('" + Branch_District + "') Where Branch_ID = '" + Branch_ID + "'", newCon.Con);
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

        //Function to Autoload Branch Name from Database to Front End
        public DataTable GetAllBranchNames()
        {
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                string query = "Select Branch_Name From tbl_Branches";
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

        //Function to Get Branch ID from Branch Name to Front End
        public DataTable GetAllBranchIDByBranchName(string BranchName)
        {
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                string query = "Select Branch_ID From tbl_Branches Where Branch_Name = '"+ BranchName +"'";
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

        //Function to Delete Branch Details 
        public int DeleteBranchDetails(string Branch_ID)
        {
            int result = 0;
            try
            {
                if (ConnectionState.Closed == newCon.Con.State)
                {
                    newCon.Con.Open();
                }
                SqlCommand adp = new SqlCommand("Delete From tbl_Branches Where Branch_ID = '" + Branch_ID + "'", newCon.Con);
                adp.ExecuteNonQuery();
                result = 1;
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }
    }
}

