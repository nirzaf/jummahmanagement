using JummahManagement.Data;
using System;


namespace JummahManagement.Business
{
    class DhaeBAL
    { 
        DhaeData dd = new DhaeData();
        
        //Function to Add Dhae
        public int AddDhae(int Dhae_ID, string Dhae_Name, string Dhae_Contact, string House_No, string Street_Name, string City, string District)
        {
            try
            {
                int result = dd.AddDhae(Dhae_ID, Dhae_Name, Dhae_Contact, House_No, Street_Name, City, District);
                return result;
            }
            catch (Exception)
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
            catch (Exception)
            {
                throw;
            }
        }

    }
}
