using System;
using System.Data;
using System.Data.SqlClient;

namespace JummahManagement.Data
{
    class DhaeData
    {
        DataCon newCon = new DataCon();

        //Function to Add City
        public int AddCity(string City)
        {
            try
            {
                int result = 0;
                try
                {
                    if (ConnectionState.Closed == newCon.Con.State)
                    {
                        newCon.Con.Open();
                        SqlCommand Check_City = new SqlCommand("SELECT * FROM tbl_City WHERE City = '" + City + "'", newCon.Con);
                        SqlDataReader reader = Check_City.ExecuteReader();

                        if (reader.HasRows)
                        {
                            try
                            {
                                reader.Close();
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
                                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_City (City) VALUES ('" + City + "')", newCon.Con);
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
                        SqlCommand Check_City = new SqlCommand("SELECT * FROM tbl_City WHERE City = '" + City + "'", newCon.Con);
                        SqlDataReader reader = Check_City.ExecuteReader();

                        if (reader.HasRows)
                        {
                            try
                            {
                                reader.Close();
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
                                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_City (City) VALUES ('" + City + "')", newCon.Con);
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


        //Function to Add New Staff Details
        public int AddDhae(int Dhae_ID, string Dhae_Name, string Dhae_Contact, string House_No,string Street_Name, string City, string District)
        {
            try
            {
                int result = 0;
                try
                {
                    if (ConnectionState.Closed == newCon.Con.State)
                    {
                        newCon.Con.Open();
                        SqlCommand Check_Dhae = new SqlCommand("SELECT * FROM tbl_Dhae WHERE Dhae_ID = '" + Dhae_ID + "'", newCon.Con);
                        SqlDataReader reader = Check_Dhae.ExecuteReader();

                        if (reader.HasRows)
                        {
                            try
                            {
                                reader.Close();
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
                                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_Dhae (Dhae_ID,Dhae_Name,Dhae_Contact,House_No,Street_Name,City,District) VALUES ('" + Dhae_ID + "','" + Dhae_Name + "','" + Dhae_Contact + "','" + House_No + "','" + Street_Name + "','" + City + "','" + District + "')", newCon.Con);
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
                            SqlCommand Check_Dhae = new SqlCommand("SELECT * FROM tbl_Dhae WHERE Dhae_ID = '" + Dhae_ID + "'", newCon.Con);
                            SqlDataReader reader = Check_Dhae.ExecuteReader();

                            if (reader.HasRows)
                            {
                                try
                                {
                                    reader.Close();
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
                                    SqlCommand cmd = new SqlCommand("INSERT INTO tbl_Dhae (Dhae_ID,Dhae_Name,Dhae_Contact,House_No,Street_Name,City,District) VALUES ('" + Dhae_ID + "','" + Dhae_Name + "','" + Dhae_Contact + "','" + House_No + "','" + Street_Name + "','" + City + "','" + District + "')", newCon.Con); 
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
