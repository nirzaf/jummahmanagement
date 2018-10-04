using JummahManagement.Data;
using System;
using System.Data;

namespace JummahManagement.Business
{ 
    class ReportsBAL
    {
        DataCon newCon = new DataCon();
        JummahReports jr = new JummahReports();

        //Function to Complete Jumma Report
        public DataTable GetAll()
        {
            try
            {
                DataTable dt = jr.GetAll();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Function to load all the City
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

        //Function to Delete Selected Row from Temp Schedule List
        public int DeleteTempRow(int RowID)
        {
            int result = 0;
            try
            {
                result = jr.DeleteTempRow(RowID);
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        //Function to Delete Selected Row from Completed Schedule List
        public int DeleteScheduleRow(int ID)
        {
            int result = 0;
            try
            {
                result = jr.DeleteScheduleRow(ID);
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        //Function to Add Jummah Schedule data into temp table
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

        //Function to Export PDF Report of jummah Schedule by date
        public DataTable PDFJummaScheduleReportByDate(string Date)
        {
            try
            {
                DataTable dt = jr.PDFJummaScheduleReportByDate(Date);
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

        //Function to load Last four weeks jummah report for Branch Name  
        public DataTable LastMonthDhaeReportByDate(string Date, string BranchName)
        {
            try
            {
                DataTable dt = jr.LastMonthDhaeReportByDate(Date, BranchName);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Function to load Last four weeks jummah report for Dhae Name  
        public DataTable LastMonthBranchReportByDate(string Date, string DhaeName)
        {
            try
            {
                DataTable dt = jr.LastMonthBranchReportByDate(Date, DhaeName);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
