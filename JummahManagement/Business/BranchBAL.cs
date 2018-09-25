using JummahManagement.Data;
using System;

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
    }

}
