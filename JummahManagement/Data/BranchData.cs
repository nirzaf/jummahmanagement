using System;
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
    }
}

