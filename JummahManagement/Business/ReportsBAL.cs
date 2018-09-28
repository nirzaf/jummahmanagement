using JummahManagement.Data;
using System;
using System.Data;

namespace JummahManagement.Business
{ 
    class ReportsBAL
    {
        DataCon newCon = new DataCon();
        JummahReports jr = new JummahReports();
        public DataTable GetCity()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = jr.GetCity();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AddJummaSchedule(int RowCount, string DhaeName, string DhaeContact, string BranchName, string JIPName, string JIPContact, string Date)
        {
            try
            {
                int result = jr.AddJummaSchedule(RowCount, DhaeName, DhaeContact, BranchName, JIPName, JIPContact, Date);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Function to load jummah Schedule by date
        public DataTable JummaScheduleReportByDate(string Date)
        {
            try
            {
                DataTable dt = jr.JummaScheduleReportByDate(Date);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Function to update City names
        public int UpdateCityName(int CityID, string CityName)
        {
            int result = 0;
            try
            {
                result = jr.UpdateCityName(CityID, CityName);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
