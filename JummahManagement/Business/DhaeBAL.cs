using JummahManagement.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace JummahManagement.Business
{
    class DhaeBAL
    { 
        DhaeData dd = new DhaeData();
        JummahReports jr = new JummahReports();

        //function to load suggested Dhae for Jummah
        public DataSet SuggestedDhaeList(string Dhae1, string Dhae2, string Dhae3, string Dhae4)
        {
            try
            {
                DataSet dt = dd.SuggestedDhaeList(Dhae1,Dhae2,Dhae3,Dhae4);
                return dt;
            }
            catch (MySqlException)
            {
                throw;
            }
        }

        //Function to Load All Dhae Details
        public DataTable LoadDhaes()
        {
            try
            {
                DataTable dt = dd.LoadDhaes();
                return dt;
            }
            catch (MySqlException)
            {
                throw;
            }
        }


        //Function to Load All Jummah Dhae Report by date
        public DataTable LoadDhaeReportByDate(string Date)
        {
            try
            {
                DataTable dt = jr.LoadDhaeReportByDate(Date);
                return dt;
            }
            catch (MySqlException)
            {
                throw;
            }
        }

        //Function to Delete Dhaedata  from TempDhae table
        public void DeleteDhaeFromTempTable(string DhaeName)
        {
            try
            {
                dd.DeleteDhaeFromTempTable(DhaeName);
            }
            catch (MySqlException)
            {
                throw;
            }
        }


        //Function to Add Dhae
        public int AddDhae(int Dhae_ID, string Dhae_Name, string Dhae_Contact, string House_No, string Street_Name, string City, string District)
        {
            try
            {
                int result = dd.AddDhae(Dhae_ID, Dhae_Name, Dhae_Contact, House_No, Street_Name, City, District);
                return result;
            }
            catch (MySqlException)
            {
                throw;
            }
        }

        //Function to move the deleted Dhae details to Temporary Table
        public int AddDhaeToDeleted(int Dhae_ID, string Dhae_Name, string Dhae_Contact, string House_No, string Street_Name, string City, string District)
        {
            try
            {
                int result = dd.AddDhae(Dhae_ID, Dhae_Name, Dhae_Contact, House_No, Street_Name, City, District);
                return result;
            }
            catch (MySqlException)
            {
                throw;
            }
        }

        //Function to Add City 
        public int AddCity(string City)
        {
            try
            {
                int result = dd.AddCity(City);
                return result;
            }
            catch (MySqlException)
            {
                throw;
            }
        }

        //Function to View all Dhaes
        public DataTable ViewAllDhaes()
        {
            try
            {
                DataTable dt = dd.ViewAllDhaes();
                return dt;
            }
            catch (MySqlException)
            {
                throw;
            }
        }

        //Function to Load Dhae by Dhae ID
        public DataTable LoadDhaeByDhaeID(int DhaeID)
        {
            try
            {
                DataTable dt = dd.LoadDhaeByDhaeID(DhaeID);
                return dt;
            }
            catch (MySqlException)
            {
                throw;
            }
        }

        //Function to Update Dhae Details
        public int UpdateDhaeDetails(int Dhae_ID, string Dhae_Name, string Dhae_Contact, string Dhae_House_No, string Dhae_Street_Name, string Dhae_City, string Dhae_District)
        {
            int result = 0;
            try
            {
                result = dd.UpdateDhaeDetails(Dhae_ID, Dhae_Name, Dhae_Contact, Dhae_House_No, Dhae_Street_Name, Dhae_City, Dhae_District);
                return result;
            }
            catch (MySqlException)
            {
                return result;
            }
        }

        //Function to Delete Dhae Details 
        public int DeleteDhaeDetails(int Dhae_ID)
        {
            int result = 0;
            try
            {
                result = dd.DeleteDhaeDetails(Dhae_ID);
                return result;
            }
            catch (MySqlException)
            {
                return result;
            }
        }

        //Function to Autoload Dhae Naem from Database to Front End
        public DataTable GetAllDhaeNames()
        {
            try
            {
                DataTable dt = dd.GetAllDhaeNames();
                return dt;
            }
            catch (MySqlException)
            {
                throw;
            }
        }

        //Function to Load Dhae Contact by Dhae Name
        public DataTable LoadDhaeNoByDhaeName(string DhaeName)
        {
            try
            {
                DataTable dt = dd.LoadDhaeNoByDhaeName(DhaeName);
                return dt;
            }
            catch (MySqlException)
            {
                throw;
            }
        }

        //Function to Load Dhae Details by Dhae Name
        public DataTable LoadDhaeDetailsByDhaeName(string DhaeName)
        {
            try
            {
                DataTable dt = dd.LoadDhaeDetailsByDhaeName(DhaeName);
                return dt;
            }
            catch (MySqlException)
            {
                throw;
            }
        }

        public void InsertDhaeDetailsToTempTable(string DhaeName)
        {
            try
            {
                dd.InsertDhaeDetailsToTempTable(DhaeName);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Function to move the deleted Dhae details to Temporary Table
        public int InsertDhaeDetailsToDeleted(int Dhae_ID)
        {
            int result = 0;
            try
            {
                result = dd.InsertDhaeDetailsToDeleted(Dhae_ID);
                return result;
            }
            catch (MySqlException)
            {
                return result;
            }
        }

    }
}
