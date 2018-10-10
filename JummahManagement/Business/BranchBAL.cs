using JummahManagement.Data;
using System;
using System.Data;

namespace JummahManagement.Business
{
    class BranchBAL
    {
        BranchData bd = new BranchData();
        //Function to Add Branch
        public int AddBranch(string Branch_ID, string Branch_Name, string JIP_Name, string JIP_Contact, string Building_No, string Street_Name, string City, string District)
        {
            try
            {
                int result = bd.AddBranch(Branch_ID,Branch_Name,JIP_Name,JIP_Contact,Building_No,Street_Name, City, District);
                return result;
            }        
            catch (Exception)
            {
                throw;
            }
        }

        //Function to Load Branch by Branch ID
        public DataTable LoadBranchByBranchID(string Branch_ID)
        {
            try
            {
                DataTable dt = bd.LoadBranchByBranchID(Branch_ID);
                return dt;
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
                result = bd.InsertBranchDetailsToDeleted(Branch_ID);
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        //Function to Update Branch Details
        public int UpdateBranchDetails(string Branch_ID, string Branch_Name, string JIP_Name, string JIP_Contact, string Branch_Building_No, string Branch_Street_Name, string Branch_City, string Branch_District)
        {
            int result = 0;
            try
            {
                result = bd.UpdateBranchDetails(Branch_ID,Branch_Name,JIP_Name,JIP_Contact,Branch_Building_No,Branch_Street_Name,Branch_City, Branch_District);
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
                DataTable dt = bd.GetAllBranchNames();
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
                DataTable dt = bd.GetAllBranchIDByBranchName(BranchName);
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
                result = bd.DeleteBranchDetails(Branch_ID);
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }
    }

}
