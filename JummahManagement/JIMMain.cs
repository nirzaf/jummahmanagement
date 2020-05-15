using iTextSharp.text;
using iTextSharp.text.pdf;
using JummahManagement.Business;
using JummahManagement.Data;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Document = iTextSharp.text.Document;
using Excell = Microsoft.Office.Interop.Excel;

namespace JummahManagement
{
    public partial class main : Form
    {
        private DhaeBAL db = new DhaeBAL();
        private BranchBAL bb = new BranchBAL();
        private ReportsBAL rb = new ReportsBAL();
        private DhaeData dd = new DhaeData();
        private JummahReports jr = new JummahReports();
        public string City_ID;
        public string City;
        public string Temp_Schedule_ID;
        private string Temp_Dhae_Name;
        public string Temp_ID;
        private int xpos;
        private int ypos;
        private string mode;

        public main()
        {
            Thread t = new Thread(new ThreadStart(SplashScreen));
            t.Start();
            Thread.Sleep(10000);
            InitializeComponent();
            t.Abort();
        }

        private void main_Load(object sender, EventArgs e)
        {
            try
            {
                dtPickerScheduleReport.Focus();
                LoadMainFormElements();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        public void SplashScreen()
        {
            Application.Run(new SplashScreen());
        }

        public void LoadMainFormElements()
        {
            try
            {
                dtCityNames.DataSource = rb.GetCity();
                dtCityNames.Columns["City_ID"].Visible = false;
                LblOverDTPicker.Visible = false;
                LblSelectedJummahDate.Visible = false;
                //BlinkDatePicker();
                LoanMainUIElements();
                FormLoad();
                LoadBranchNames();
                LoadDhaeNames();
                LoadCityNames();
                LoadCityNames1();
                LoadDhaeNames1();
                LoadBranchNames1();
                LoadFilterByDhaeNameReport();
                LoadFilterByBranchNameReport();
                LoadFilterByDhaeContactNumber();
                LoadFilterByJummahInchargePerson();
                LoadDGVDtJummahSchedule();
                LoadTextBoxes();
                DGVDhaeDetails.DataSource = db.LoadDhaes();
                DGVBranchDetails.DataSource = bb.LoadAllBraches();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        public void LoanMainUIElements()
        {
            try
            {
                PanelBranchesLeft.Width = 0;
                DhaeData dd = new DhaeData();
                DataTable dtBranches = bb.LoadAllBraches();
                if (dtBranches.Rows.Count > 0)
                {
                    LblTotalBraches.Text = dtBranches.Rows.Count.ToString();
                }
                DataTable dtDhaes = db.GetAllDhaeNames();
                if (dtDhaes.Rows.Count > 0)
                {
                    LblTotalDhaeCount.Text = dtDhaes.Rows.Count.ToString();
                }
                if (dtJummaSchedule.Rows.Count > 1)
                {
                    BtnShowPendingBranches.Visible = true;
                }
                DataTable DhaeList = db.LoadDhaes();
                DGVDhaeDetails.DataSource = DhaeList;
                DataTable BranchList = bb.LoadBracheDetails();
                DGVBranchDetails.DataSource = BranchList;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        public void LoadTextBoxes()
        {
            lblMessage.Text = "";
            L1.Text = "";
            L2.Text = "";
            L3.Text = "";
            L4.Text = "";
        }

        public void LoadDGVDtJummahSchedule()
        {
            dtJummaSchedule.DataSource = jr.LoadDGVdtJummaSchedule();
        }

        public void LoadFilterByDhaeNameReport()
        {
            dtPickerScheduleReport.Format = DateTimePickerFormat.Custom;
            dtPickerScheduleReport.CustomFormat = "yyyy-MM-dd";
            string SelectedDate = dtPickerScheduleReport.Value.ToShortDateString();
            AutoCompleteStringCollection DhaeNames = new AutoCompleteStringCollection();
            DataTable dtb = rb.JummaScheduleReportByDate(SelectedDate);
            foreach (DataRow drb in dtb.Rows)
            {
                DhaeNames.Add(drb[2].ToString());
            }
            FilterByDhaeNameReport.AutoCompleteCustomSource = DhaeNames;
        }

        public void LoadFilterByDhaeContactNumber()
        {
            dtPickerScheduleReport.Format = DateTimePickerFormat.Custom;
            dtPickerScheduleReport.CustomFormat = "yyyy-MM-dd";
            string SelectedDate = dtPickerScheduleReport.Value.ToShortDateString();
            AutoCompleteStringCollection DhaeNumbers = new AutoCompleteStringCollection();
            DataTable dtb = rb.JummaScheduleReportByDate(SelectedDate);
            foreach (DataRow drb in dtb.Rows)
            {
                DhaeNumbers.Add(drb[3].ToString());
            }
            FilterByDhaeContactNumber.AutoCompleteCustomSource = DhaeNumbers;
        }

        public void LoadFilterByBranchNameReport()
        {
            dtPickerScheduleReport.Format = DateTimePickerFormat.Custom;
            dtPickerScheduleReport.CustomFormat = "yyyy-MM-dd";
            string SelectedDate = dtPickerScheduleReport.Value.ToShortDateString();
            AutoCompleteStringCollection BranchNames = new AutoCompleteStringCollection();
            DataTable dtb = rb.JummaScheduleReportByDate(SelectedDate);
            foreach (DataRow drb in dtb.Rows)
            {
                BranchNames.Add(drb[4].ToString());
            }
            FilterByBranchNameReport.AutoCompleteCustomSource = BranchNames;
        }

        public void LoadFilterByJummahInchargePerson()
        {
            dtPickerScheduleReport.Format = DateTimePickerFormat.Custom;
            dtPickerScheduleReport.CustomFormat = "yyyy-MM-dd";
            string SelectedDate = dtPickerScheduleReport.Value.ToShortDateString();
            AutoCompleteStringCollection JIP = new AutoCompleteStringCollection();
            DataTable dtb = rb.JummaScheduleReportByDate(SelectedDate);
            foreach (DataRow drb in dtb.Rows)
            {
                JIP.Add(drb[5].ToString());
            }
            FilterByInchargePersonReport.AutoCompleteCustomSource = JIP;
        }

        public void LoadFilter()
        {
            dtPickerScheduleReport.Format = DateTimePickerFormat.Custom;
            dtPickerScheduleReport.CustomFormat = "yyyy-MM-dd";
            string SelectedDate = dtPickerScheduleReport.Value.ToShortDateString();
            AutoCompleteStringCollection DhaeNumbers = new AutoCompleteStringCollection();
            DataTable dtb = rb.JummaScheduleReportByDate(SelectedDate);
            foreach (DataRow drb in dtb.Rows)
            {
                DhaeNumbers.Add(drb[2].ToString());
            }
            FilterByDhaeContactNumber.AutoCompleteCustomSource = DhaeNumbers;
        }

        public void LoadBranchNames()
        {
            AutoCompleteStringCollection BranchNames = new AutoCompleteStringCollection();
            DataTable dtb = bb.GetAllBranchNames();
            foreach (DataRow drb in dtb.Rows)
            {
                BranchNames.Add(drb[0].ToString());
            }
            txtJummaBranchName.AutoCompleteCustomSource = BranchNames;
        }

        public void LoadBranchNames1()
        {
            AutoCompleteStringCollection BranchNames = new AutoCompleteStringCollection();
            DataTable dtb = bb.GetAllBranchNames();
            foreach (DataRow drb in dtb.Rows)
            {
                BranchNames.Add(drb[0].ToString());
            }
            FilterByBranchName.AutoCompleteCustomSource = BranchNames;
        }

        public void LoadDhaeNames()
        {
            AutoCompleteStringCollection DhaeNames = new AutoCompleteStringCollection();
            DataTable dt = db.GetAllDhaeNames();
            foreach (DataRow dr in dt.Rows)
            {
                DhaeNames.Add(dr[0].ToString());
            }
            txtJummaDhaeName.AutoCompleteCustomSource = DhaeNames;
        }

        public void LoadDhaeNames1()
        {
            AutoCompleteStringCollection DhaeNames = new AutoCompleteStringCollection();
            DataTable dt = db.GetAllDhaeNames();
            foreach (DataRow dr in dt.Rows)
            {
                DhaeNames.Add(dr[0].ToString());
            }
            FilterByDhaeName.AutoCompleteCustomSource = DhaeNames;
        }

        public void LoadCityNames()
        {
            AutoCompleteStringCollection CityNames = new AutoCompleteStringCollection();
            DataTable ctn = jr.GetCity();
            foreach (DataRow ct in ctn.Rows)
            {
                CityNames.Add(ct[1].ToString());
            }
            TxtCityNames.AutoCompleteCustomSource = CityNames;
        }

        public void LoadCityNames1()
        {
            AutoCompleteStringCollection CityNames = new AutoCompleteStringCollection();
            DataTable ctn = jr.GetCity();
            foreach (DataRow ct in ctn.Rows)
            {
                CityNames.Add(ct[1].ToString());
            }
            TxtCityNames1.AutoCompleteCustomSource = CityNames;
        }

        //Function to Load Dhae Report & JIP Report
        public void FormLoad()
        {
            dtDhaeReport.Columns.Add("Dhae_Contact", "Dhae Contact");
            dtDhaeReport.Columns.Add("Jummah_date", "Jummah Date, Branch ,JIP");

            dtInchargeReport.Columns.Add("Incharge_Contact", "Incharge Contact");
            dtInchargeReport.Columns.Add("Date", "Jummah Date ,Dhae Details ");
        }

        //Function to Relaod All DGV
        private void Reload()
        {
            try
            {
                //dtCityNames.DataSource = rb.GetCity();
                dtCityNames.Columns["City_ID"].Visible = false;
                AutoCompleteStringCollection DhaeNames = new AutoCompleteStringCollection();
                DataTable dt = db.GetAllDhaeNames();
                foreach (DataRow dr in dt.Rows)
                {
                    DhaeNames.Add(dr[0].ToString());
                }
                txtJummaDhaeName.AutoCompleteCustomSource = DhaeNames;

                AutoCompleteStringCollection BranchNames = new AutoCompleteStringCollection();
                DataTable dtb = bb.GetAllBranchNames();
                foreach (DataRow drb in dtb.Rows)
                {
                    BranchNames.Add(drb[0].ToString());
                }
                txtJummaBranchName.AutoCompleteCustomSource = BranchNames;
                lblMessage.Text = "";
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtAddNewCity.Visible == false && btnAddNewCity.Visible == false)
            {
                txtAddNewCity.Visible = true;
                btnAddNewCity.Visible = true;
                btnAddCity.Text = "-";
                txtAddNewCity.Focus();
            }
            else
            {
                txtAddNewCity.Visible = false;
                btnAddNewCity.Visible = false;
                btnAddCity.Text = "+";
            }
        }

        private void btnAddDhae_Click(object sender, EventArgs e)
        {
            if (txtDhaeID.Text.Trim() != "" && txtDhaeName.Text.Trim() != "" && txtDhaeContact.Text.Trim() != "")
            {
                try
                {
                    int Dhae_ID = Convert.ToInt32(txtDhaeID.Text);
                    string Dhae_Name = txtDhaeName.Text.Trim();
                    string DhaeContactNo = txtDhaeContact.Text.Trim();
                    string HouseNo = txtHouseNo.Text.Trim();
                    string StreetName = txtStreetName.Text.Trim();
                    string City = TxtCityNames.Text.Trim();
                    string District = TxtDistrictNames1.Text.Trim();
                    int result = db.AddDhae(Dhae_ID, Dhae_Name, DhaeContactNo, HouseNo, StreetName, City, District);
                    if (result == 1)
                    {
                        lblMessage.Text = "Successfully Added";
                        DataTable dtDhaes = db.GetAllDhaeNames();
                        if (dtDhaes.Rows.Count > 0)
                        {
                            LblTotalDhaeCount.Text = dtDhaes.Rows.Count.ToString();
                            DGVDhaeDetails.DataSource = db.LoadDhaes();
                        }
                        LoadDhaeNames();
                    }
                    else
                    {
                        lblMessage.Text = "Something Went wrong";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                if (txtDhaeID.Text.Trim() == "")
                {
                    lblMessage.Text = "Dhae ID Should not be blank";
                    txtDhaeID.Focus();
                }
                else if (txtDhaeName.Text.Trim() == "")
                {
                    lblMessage.Text = "Dhae Name Should not be blank";
                    txtDhaeName.Focus();
                }
                else if (txtDhaeContact.Text.Trim() == "")
                {
                    lblMessage.Text = "Dhae Contact Should not be blank";
                    txtDhaeContact.Focus();
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtBranchID.Text.Trim() != "" && txtBranchName.Text.Trim() != "" && txtJIT_Name.Text.Trim() != "" && txtJIT_Contact.Text.Trim() != "")
            {
                string Branch_ID = txtBranchID.Text.Trim();
                string Branch_Name = txtBranchName.Text.Trim();
                string JIT_Name = txtJIT_Name.Text.Trim();
                string JIT_Contact = txtJIT_Contact.Text.Trim();
                string BuildingNo = txtBuildingNo.Text.Trim();
                string StreetName = txtStreet.Text.Trim();
                string City = TxtCityNames1.Text.Trim();
                string District = TxtDistrictNames.Text.Trim();

                int result = bb.AddBranch(Branch_ID, Branch_Name, JIT_Name, JIT_Contact, BuildingNo, StreetName, City, District);
                if (result == 1)
                {
                    lblMessage.Text = "Successfully Added";
                    DataTable dtBranches = bb.LoadAllBraches();
                    DGVBranchDetails.DataSource = dtBranches;
                    if (dtBranches.Rows.Count > 0)
                    {
                        LblTotalBraches.Text = dtBranches.Rows.Count.ToString();
                    }
                    LoadBranchNames();
                }
                else
                {
                    lblMessage.Text = "Something Went wrong";
                }
            }
            else
            {
                if (txtBranchID.Text.Trim() == "")
                {
                    lblMessage.Text = "Branch ID Should not be Blank";
                    txtBranchID.Focus();
                }
                else if (txtBranchName.Text.Trim() == "")
                {
                    lblMessage.Text = "Branch Name Should not be Blank";
                    txtBranchName.Focus();
                }
                else if (txtJIT_Name.Text.Trim() == "")
                {
                    lblMessage.Text = "Jummah Incharge Person Name Should not be Blank";
                    txtJIT_Name.Focus();
                }
                else if (txtJIT_Contact.Text.Trim() == "")
                {
                    lblMessage.Text = "Jummah Incharge Person Contact Number should not be Blank";
                    txtJIT_Contact.Focus();
                }
            }
        }

        private void btnAddNewCity_Click(object sender, EventArgs e)
        {
            string City = txtAddNewCity.Text;
            int result = db.AddCity(City);
            if (result == 1)
            {
                lblMessage.Text = "Added";
                txtAddNewCity.Visible = false;
                btnAddNewCity.Visible = false;
                AutoCompleteStringCollection CityNames = new AutoCompleteStringCollection();
                DataTable ctn = jr.GetCity();
                foreach (DataRow ct in ctn.Rows)
                {
                    CityNames.Add(ct[1].ToString());
                }
                TxtCityNames.AutoCompleteCustomSource = CityNames;
                TxtCityNames.Text = txtAddNewCity.Text;
            }
            else
            {
                lblMessage.Text = "Not Added";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtAddNewCity1.Visible == false && btnAddNewCity1.Visible == false)
            {
                txtAddNewCity1.Visible = true;
                btnAddNewCity1.Visible = true;
                button2.Text = "-";
                txtAddNewCity1.Focus();
            }
            else
            {
                txtAddNewCity1.Visible = false;
                btnAddNewCity1.Visible = false;
                button2.Text = "+";
            }
        }

        private void btnAddNewCity1_Click(object sender, EventArgs e)
        {
            string City = txtAddNewCity1.Text;
            int result = db.AddCity(City);
            if (result == 1)
            {
                lblMessage.Text = "Added";
                txtAddNewCity1.Visible = false;
                btnAddNewCity1.Visible = false;
                AutoCompleteStringCollection CityNames = new AutoCompleteStringCollection();
                DataTable ctn = jr.GetCity();
                foreach (DataRow ct in ctn.Rows)
                {
                    CityNames.Add(ct[1].ToString());
                }
                TxtCityNames1.AutoCompleteCustomSource = CityNames;
                TxtCityNames1.Text = txtAddNewCity1.Text;
            }
            else
            {
                lblMessage.Text = "Not Added";
            }
        }

        private void txtDhaeIDforUpdate_Click(object sender, EventArgs e)
        {
            txtDhaeIDforUpdate.Text = "";
        }

        private void btnLoadDhae_Click(object sender, EventArgs e)
        {
            try
            {
                int DhaeID = Convert.ToInt32(txtDhaeIDforUpdate.Text);
                DataTable dt = db.LoadDhaeByDhaeID(DhaeID);
                foreach (DataRow dr in dt.Rows)
                {
                    txtUpdateDhaeName.Text = dr[1].ToString();
                    txtUpdateDhaeContactNo.Text = dr[2].ToString();
                    txtUpdateDhaeHouseNo.Text = dr[3].ToString();
                    txtUpdateDhaeStreetName.Text = dr[4].ToString();
                    txtUpdateDhaeCity.Text = dr[5].ToString();
                    txtUpdateDhaeDistrict.Text = dr[6].ToString();
                }

                if (txtUpdateDhaeName.Text != "")
                {
                    txtDhaeIDforUpdate.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void btnUpdateBranchdetails_Click(object sender, EventArgs e)
        {
            try
            {
                string BranchID = txtUpdateBranchID.Text;
                DataTable dt = bb.LoadBranchByBranchID(BranchID);
                foreach (DataRow dr in dt.Rows)
                {
                    txtUpdateBranchName.Text = dr[1].ToString();
                    txtUpdateJIPName.Text = dr[2].ToString();
                    txtUpdateJIPContact.Text = dr[3].ToString();
                    txtUpdateBuildingNo.Text = dr[4].ToString();
                    txtUpdateBranchStreetName.Text = dr[5].ToString();
                    txtUpdateBranchCity.Text = dr[6].ToString();
                    txtUpdateBranchDistrictName.Text = dr[7].ToString();
                }
                if (txtUpdateBranchName.Text != "")
                {
                    txtUpdateBranchID.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void txtUpdateBranchID_Click(object sender, EventArgs e)
        {
            txtUpdateBranchID.Text = "";
        }

        private void btnUpdateDhae_Click(object sender, EventArgs e)
        {
            try
            {
                int DhaeID = Convert.ToInt32(txtDhaeIDforUpdate.Text);
                string DhaeName = txtUpdateDhaeName.Text;
                string DhaeContact = txtUpdateDhaeContactNo.Text;
                string DhaeHouse = txtUpdateDhaeHouseNo.Text;
                string DhaeStreetName = txtUpdateDhaeStreetName.Text;
                string DhaeCity = txtUpdateDhaeCity.Text;
                string DhaeDistrict = txtUpdateDhaeDistrict.Text;

                if (txtUpdateDhaeName.Text != "")
                {
                    int result = db.UpdateDhaeDetails(DhaeID, DhaeName, DhaeContact, DhaeHouse, DhaeStreetName, DhaeCity, DhaeDistrict);
                    if (result == 1)
                    {
                        lblMessage.Text = "Dhae Details Successfully Updated";
                    }
                    else
                    {
                        lblMessage.Text = "Please Enter Valid Dhae ID to Update";
                    }
                }
                else
                {
                    lblMessage.Text = "Please Enter Valid Dhae ID to Update";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void btnDhaeDetailsReset_Click(object sender, EventArgs e)
        {
            txtUpdateDhaeName.Text = "";
            txtUpdateDhaeContactNo.Text = "";
            txtUpdateDhaeHouseNo.Text = "";
            txtUpdateDhaeStreetName.Text = "";
            txtUpdateDhaeCity.Text = "";
            txtUpdateDhaeDistrict.Text = "";
            txtDhaeIDforUpdate.Enabled = true;
        }

        private void btnResetBranchDetails_Click(object sender, EventArgs e)
        {
            txtUpdateBranchName.Text = "";
            txtUpdateJIPName.Text = "";
            txtUpdateJIPContact.Text = "";
            txtUpdateBuildingNo.Text = "";
            txtUpdateBranchStreetName.Text = "";
            txtUpdateBranchCity.Text = "";
            txtUpdateBranchDistrictName.Text = "";
            txtUpdateBranchID.Enabled = true;
        }

        private void btnUpdateBranchDetail_Click(object sender, EventArgs e)
        {
            try
            {
                string UpdateBranchID = txtUpdateBranchID.Text.Trim();
                string UpdateBranchName = txtUpdateBranchName.Text.Trim();
                string UpdateBranchJIPName = txtUpdateJIPName.Text.Trim();
                string UpdateBranchJIPContact = txtUpdateJIPContact.Text.Trim();
                string UpdateBranchBuildingNo = txtUpdateBuildingNo.Text.Trim();
                string UpdateBranchStreetName = txtUpdateBranchStreetName.Text.Trim();
                string UpdateBranchCity = txtUpdateBranchCity.Text.Trim();
                string UpdateBranchDistrict = txtUpdateBranchDistrictName.Text.Trim();
                int result = bb.UpdateBranchDetails(UpdateBranchID, UpdateBranchName, UpdateBranchJIPName, UpdateBranchJIPContact, UpdateBranchBuildingNo, UpdateBranchStreetName, UpdateBranchCity, UpdateBranchDistrict);
                if (result == 1)
                {
                    lblMessage.Text = "Branch Details Successfully Updated";
                }
                else
                {
                    lblMessage.Text = "Some thing went wrong";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void txtJummaBranchName_TextChanged(object sender, EventArgs e)
        {
            if (txtJummaBranchName.Text != "" && txtJummaDhaeName.Text != "")
            {
                btnAdd.Enabled = true;
            }
        }

        private void txtJummaDhaeName_TextChanged(object sender, EventArgs e)
        {
            if (txtJummaBranchName.Text != "" && txtJummaDhaeName.Text != "")
            {
                btnAdd.Enabled = true;
            }
        }

        //Function to Select Date from Date Picker to Generate Jummah Schedule
        private void JummaDtPicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LblOverDTPicker.Visible = true;
                LblSelectedJummahDate.Visible = true;
                JummaDtPicker.CustomFormat = "yyyy-MM-dd";
                string SelectedDate = JummaDtPicker.Value.ToShortDateString();
                lblSelectedDate.Text = SelectedDate;

                DateTime lastFriday = JummaDtPicker.Value.AddDays(-1);
                while (lastFriday.DayOfWeek != DayOfWeek.Friday)
                    lastFriday = lastFriday.AddDays(-1);
                string LFDay = lastFriday.Date.ToString("yyyy-MM-dd").Trim();
                label45.Text = LFDay;

                DateTime PreviousFriday = lastFriday.Date.AddDays(-1);
                while (PreviousFriday.DayOfWeek != DayOfWeek.Friday)
                    PreviousFriday = PreviousFriday.AddDays(-1);
                string PFDay = PreviousFriday.Date.ToString("yyyy-MM-dd").Trim();
                label46.Text = PFDay;

                DateTime ThirdFriday = PreviousFriday.Date.AddDays(-1);
                while (ThirdFriday.DayOfWeek != DayOfWeek.Friday)
                    ThirdFriday = ThirdFriday.AddDays(-1);
                string TFDay = ThirdFriday.Date.ToString("yyyy-MM-dd").Trim();
                label47.Text = TFDay;

                DateTime FourthFriday = ThirdFriday.Date.AddDays(-1);
                while (FourthFriday.DayOfWeek != DayOfWeek.Friday)
                    FourthFriday = FourthFriday.AddDays(-1);
                string FFDay = FourthFriday.Date.ToString("yyyy-MM-dd").Trim();
                label48.Text = FFDay;

                if (JummaDtPicker.Value.DayOfWeek == DayOfWeek.Friday)
                {
                    lblMessage.Text = "You have Selected Firday (Jummah Day)";
                }
                else
                {
                    lblMessage.Text = "Warning! .. You have Selected " + JummaDtPicker.Value.DayOfWeek;
                }

                txtJummaBranchName.Enabled = true;
                txtJummaDhaeName.Enabled = true;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        //Function to load temporary branches left table
        public void LoadTempBranchesLeft()
        {
            DataTable dtBranches = bb.GetRowCountForTempBranchTempTable();
            DGVBranchesLeft.DataSource = dtBranches;
            if (dtBranches.Rows.Count > 0)
            {
                LblBranchesLeft.Text = dtBranches.Rows.Count.ToString();
                TimerBranchCount.Enabled = true;
            }
        }

        //Function to Create Schedule List
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string DhaeName = txtJummaDhaeName.Text.Trim();
                db.DeleteDhaeFromTempTable(DhaeName);
                DataTable dt = db.LoadDhaeNoByDhaeName(DhaeName);
                foreach (DataRow dr in dt.Rows)
                {
                    lblDhaeContact.Text = dr[0].ToString();
                }
                string BranchName = txtJummaBranchName.Text.Trim();
                bb.DeleteBranchFromTempTable(BranchName);
                DataTable dt1 = bb.GetAllBranchIDByBranchName(BranchName);

                foreach (DataRow dr1 in dt1.Rows)
                {
                    string BranchID = dr1[0].ToString();
                    DataTable dt2 = bb.LoadBranchByBranchID(BranchID);
                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        lblJummaInchargeName.Text = dr2[2].ToString();
                        lblJummaInchargeNumber.Text = dr2[3].ToString();
                    }
                }
                int RowCount = dtJummaSchedule.RowCount;
                int result = rb.AddJummaSchedule(RowCount, txtJummaDhaeName.Text, lblDhaeContact.Text, BranchName, lblJummaInchargeName.Text, lblJummaInchargeNumber.Text, lblSelectedDate.Text);
                if (result == 1)
                {
                    btnAdd.Enabled = false;
                    txtJummaBranchName.Focus();
                    LoadDGVDtJummahSchedule();
                    LoadTempBranchesLeft();
                }
                else
                {
                    lblMessage.Text = "Please Try Again";
                    txtJummaBranchName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtAddNewCity_Click(object sender, EventArgs e)
        {
            txtAddNewCity.Text = "";
        }

        //Function to Save Jumma Schedule into main table
        private void btnSaveSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                DataCon newCon = new DataCon();
                for (int i = 0; i < dtJummaSchedule.RowCount - 1; i++)
                {
                    SqlCommand cmd = new SqlCommand("INSERT into tbl_Jummah_Schedule (Row_Count,Dhae_Name,Dhae_Contact,Branch_Name,JIP_Name,JIP_Contact,Date) Values ('" + dtJummaSchedule.Rows[i].Cells[1].Value + "','" + dtJummaSchedule.Rows[i].Cells[2].Value + "','" + dtJummaSchedule.Rows[i].Cells[3].Value + "','" + dtJummaSchedule.Rows[i].Cells[4].Value + "','" + dtJummaSchedule.Rows[i].Cells[5].Value + "','" + dtJummaSchedule.Rows[i].Cells[6].Value + "','" + dtJummaSchedule.Rows[i].Cells[7].Value + "' )", newCon.Con);
                    if (ConnectionState.Closed == newCon.Con.State)
                    {
                        newCon.Con.Open();
                    }
                    cmd.ExecuteNonQuery();
                    newCon.Con.Close();
                }
                lblMessage.Text = "Successfully Jummah Schedule Added";
                dd.CreateTempDhaeTable();
                bb.CreateTempBranchTable();
                jr.DropAndRecreate();
                string SelectedDate = JummaDtPicker.Value.ToShortDateString();
                dtJummaSchedule.DataSource = db.LoadDhaeReportByDate(SelectedDate);
                main jm = new main();
                jm.Show();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //function to view jummah schedule report
        private void dtJummahReport_ValueChanged(object sender, EventArgs e)
        {
            dtJummahReport.Format = DateTimePickerFormat.Custom;
            dtJummahReport.CustomFormat = "yyyy-MM-dd";
            dtDhaeReport.Rows.Clear();
            dtInchargeReport.Rows.Clear();
            string SelectedDate = dtJummahReport.Value.ToShortDateString();
            DataTable dt = db.LoadDhaeReportByDate(SelectedDate);
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    string DhaeNo = dr[3].ToString().Trim();
                    string Date = SelectedDate;
                    string BranchName = "Jummah.." + dr[4].ToString().Trim();
                    string Contact = dr[6].ToString().Trim();
                    string Incharge = "..(" + dr[5].ToString().Trim() + ")";
                    dtDhaeReport.Rows.Add(DhaeNo, Date + BranchName + Contact + Incharge);
                    dtDhaeReport.RowHeadersVisible = false;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }

            DataTable dt1 = db.LoadDhaeReportByDate(SelectedDate);

            foreach (DataRow dr1 in dt1.Rows)
            {
                try
                {
                    string Contact = dr1[6].ToString().Trim();
                    string Date = SelectedDate.Trim();
                    string DhaeData = "..Jummah.." + dr1[2].ToString().Trim() + "..(" + dr1[3].ToString().Trim() + ")";
                    dtInchargeReport.Rows.Add(Contact, Date + DhaeData);
                    dtInchargeReport.RowHeadersVisible = false;
                }
                catch (Exception d)
                {
                    label39.Text = d.Message;
                }
            }
        }

        //Class to copy all the data gird view data to clip board

        private void copyDhaeReport()
        {
            dtDhaeReport.SelectAll();
            DataObject dataObj = dtDhaeReport.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        //Class to Copy datagrid view to excell
        private void copyInchargeReport()
        {
            dtInchargeReport.SelectAll();
            DataObject dataObj = dtInchargeReport.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        //This class will copy all Dhae details from datagridview to excell
        private void pBoxDhaeReport_Click(object sender, EventArgs e)
        {
            try
            {
                copyDhaeReport();
                Excell.Application xlexcel;
                Excell.Workbook xlWorkBook;
                Excell.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Excell.Application
                {
                    Visible = true
                };
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Excell.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Excell.Range CR = (Excell.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        //This class will copy all Jumma Inchrage Person details data from datagridview to excell
        private void pBoxJummahInchargeReport_Click(object sender, EventArgs e)
        {
            try
            {
                copyInchargeReport();
                Excell.Application xlexcel;
                Excell.Workbook xlWorkBook;
                Excell.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Excell.Application
                {
                    Visible = true
                };
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Excell.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Excell.Range CR = (Excell.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        //Function to load city names to text box
        private void dtCityNames_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtCityNames.SelectedRows.Count > 0)
                {
                    City_ID = dtCityNames.SelectedRows[0].Cells[0].Value + string.Empty;
                    City = dtCityNames.SelectedRows[0].Cells[1].Value + string.Empty;
                    lblCityID.Text = City_ID;
                    lblCity.Text = City;
                    txtUpdateCity.Text = City;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //function to filter city names
        private void txtSearchCity_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                (dtCityNames.DataSource as DataTable).DefaultView.RowFilter = string.Format("City LIKE '{0}%' OR City LIKE '% {0}%'", txtSearchCity.Text);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        //Function to load Schedule Report by Date
        private void dtPickerScheduleReport_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadFilterByDhaeNameReport();
                LoadFilterByBranchNameReport();
                LoadFilterByDhaeContactNumber();
                LoadFilterByJummahInchargePerson();
                dtPickerScheduleReport.Format = DateTimePickerFormat.Custom;
                dtPickerScheduleReport.CustomFormat = "yyyy-MM-dd";
                string SelectedDate = dtPickerScheduleReport.Value.ToShortDateString();
                dtScheduleReport.DataSource = rb.JummaScheduleReportByDate(SelectedDate);
                dtScheduleReport.Columns["Row_count"].Visible = false;
            }
            catch (Exception)
            {
                lblMessage.Text = "Loading Error";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }

        private void txtFilterByDhaeName_Click(object sender, EventArgs e)
        {
            txtFilterByDhaeName.Text = "";
            txtFilterByDhaeName.Focus();
        }

        private void txtFilterByBranchName_Click(object sender, EventArgs e)
        {
            txtFilterByBranchName.Text = "";
            txtFilterByBranchName.Focus();
        }

        private void txtFilterByJIPName_Click(object sender, EventArgs e)
        {
            txtFilterByJIPName.Text = "";
            txtFilterByJIPName.Focus();
        }

        //Function to filter Schedule by Jumma Incharge Person Name
        private void txtFilterByJIPName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                BindingSource bsDvd = new BindingSource
                {
                    DataSource = dtJummaSchedule.DataSource,
                    Filter = string.Format("JIP_Name LIKE '{0}%' OR JIP_Name LIKE '% {0}%'", txtFilterByJIPName.Text)
                };
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        //Function to filter Schedule by Dhae Name
        private void txtFilterByDhaeName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                BindingSource bsDvd = new BindingSource
                {
                    DataSource = dtJummaSchedule.DataSource,
                    Filter = string.Format("Dhae_Name LIKE '{0}%' OR Dhae_Name LIKE '%{0}%'", txtFilterByDhaeName.Text)
                };
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        //Function to filter Schedule by Branch Name
        private void txtFilterByBranchName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                BindingSource bsDvd = new BindingSource();
                bsDvd.DataSource = dtJummaSchedule.DataSource;
                bsDvd.Filter = string.Format("Branch_Name LIKE '{0}%' OR Branch_Name LIKE '% {0}%'", txtFilterByBranchName.Text);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        //Function to Clear all the Temporary Schedule From Data grid view and Temp Table
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (dtJummaSchedule.Rows.Count > 1)
            {
                try
                {
                    switch (MessageBox.Show("Are you sure you want to clear all current Schedule list",
                          "Warning : This Task cannnot be Recalled",
                          MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            dd.CreateTempDhaeTable();
                            jr.DropAndRecreate();
                            bb.CreateTempBranchTable();
                            LoadDGVDtJummahSchedule();
                            LoanMainUIElements();
                            break;

                        case DialogResult.No:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
            else
            {
                lblMessage.Text = "Schedule List is Already Empty";
            }
        }

        //Function to Update City Names
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int CityID = Convert.ToInt32(lblCityID.Text);
            string City = txtUpdateCity.Text;
            int result = rb.UpdateCityName(CityID, City);
            if (result == 1)
            {
                lblMessage.Text = "City Name Updated Succesfully";
                dtCityNames.DataSource = rb.GetCity();
            }
            else
            {
                lblMessage.Text = "Oops! Something went wrong";
            }
            LoadCityNames();
            LoadCityNames1();
        }

        //Fucntion to Refersh all DGV
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtJummaSchedule.SelectedRows.Count > 0)
                {
                    int ID = Convert.ToInt32(Temp_Schedule_ID);
                    int result = rb.DeleteTempRow(ID);
                    db.InsertDhaeDetailsToTempTable(Temp_Dhae_Name);
                    string DhaeName = dtJummaSchedule.SelectedRows[0].Cells[1].Value + string.Empty;
                    string BranchName = dtJummaSchedule.SelectedRows[0].Cells[3].Value + string.Empty;

                    try
                    {
                        if (result == 1)
                        {
                            lblMessage.Text = "Selected Row Deleted";
                        }
                        else
                        {
                            lblMessage.Text = "Oops; Some thing went wrong";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = ex.Message;
                    }
                }
                else
                {
                    lblMessage.Text = "Please Select a row to Delete";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void DateTimePDFReportGenerator_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTimePDFReportGenerator.Format = DateTimePickerFormat.Custom;
                DateTimePDFReportGenerator.CustomFormat = "yyyy-MM-dd";
                string SelectedDate = DateTimePDFReportGenerator.Value.ToShortDateString();
                DGVPDFReport.DataSource = rb.PDFJummaScheduleReportByDate(SelectedDate);
                DGVPDFReport.RowHeadersVisible = false;
            }
            catch (Exception)
            {
                lblMessage.Text = "Loading...";
            }
        }

        private void PicBoxPDFExport_Click(object sender, EventArgs e)
        {
            string Date = DateTimePDFReportGenerator.Value.ToShortDateString();
            DataTable dt = rb.PDFJummaScheduleReportByDate(Date);
            ExportToPdf(dt, Date);
            lblMessage.Text = " PDF Created Successfully ";
        }

        public void ExportToPdf(DataTable dt, string Date)
        {
            Document document = new Document();
            string filename = "Jumma_Report.PDF".AppendTimeStamp();
            PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));
            document.Open();
            iTextSharp.text.Font font5 = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            PdfPTable table = new PdfPTable(dt.Columns.Count);
            float[] widths = new float[] { 4f, 4f };

            Paragraph header = new Paragraph("                           (" + Date + ") This week Jumma Branches and Dhae's List");
            Paragraph line1 = new Paragraph("          ____________________________________________________________________");
            Paragraph line2 = new Paragraph("                                                                          ");
            Paragraph footer = new Paragraph("                                                       Sri Lanka Thowheedh Jama'ath");

            table.SetWidths(widths);

            table.WidthPercentage = 100;

            foreach (DataRow r in dt.Rows)
            {
                if (dt.Rows.Count > 0)
                {
                    if (r[0] != null && r[1] != null)
                    {
                        table.AddCell(new Phrase(r[0].ToString(), font5));
                        table.AddCell(new Phrase(r[1].ToString(), font5));
                    }
                }
            }
            document.Add(header);
            document.Add(line1);
            document.Add(line2);
            document.Add(table);
            document.Add(footer);
            document.Close();
        }

        private static PdfPageTemplateElement CreateHeaderTemplate(Spire.Pdf.PdfDocument doc, PdfMargins margins)
        {
            //get page size
            SizeF pageSize = doc.PageSettings.Size;

            //create a PdfPageTemplateElement object as header space
            PdfPageTemplateElement headerSpace = new PdfPageTemplateElement(pageSize.Width, margins.Top);
            headerSpace.Foreground = false;

            //declare two float variables
            float x = margins.Left;
            float y = 0;

            //draw line in header space
            PdfPen pen = new PdfPen(PdfBrushes.Gray, 1);
            headerSpace.Graphics.DrawLine(pen, x, y + margins.Top - 2, pageSize.Width - x, y + margins.Top - 2);

            //draw text in header space
            PdfTrueTypeFont font = new PdfTrueTypeFont(new System.Drawing.Font("Impact", 25f, FontStyle.Bold));
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left);
            String headerText = "HEADER TEXT";
            SizeF size = font.MeasureString(headerText, format);
            headerSpace.Graphics.DrawString(headerText, font, PdfBrushes.Gray, pageSize.Width - x - size.Width - 2, margins.Top - (size.Height + 5), format);

            //return headerSpace
            return headerSpace;
        }

        private void FilterByDhaeName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                BindingSource bsDvd = new BindingSource
                {
                    DataSource = DGVDhaeDetails.DataSource,
                    Filter = string.Format("Dhae_Name LIKE '{0}%' OR Dhae_Name LIKE '% {0}%'", FilterByDhaeName.Text)
                };
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void FilterByBranchName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                BindingSource bsDvd = new BindingSource
                {
                    DataSource = DGVBranchDetails.DataSource,
                    Filter = string.Format("Branch_Name LIKE '{0}%' OR Branch_Name LIKE '% {0}%'", FilterByBranchName.Text)
                };
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void dtJummaSchedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtJummaSchedule.SelectedRows.Count > 0)
                {
                    Temp_Schedule_ID = dtJummaSchedule.SelectedRows[0].Cells[0].Value + string.Empty;
                    Temp_Dhae_Name = dtJummaSchedule.SelectedRows[0].Cells[1].Value + string.Empty;
                    label41.Text = Temp_Schedule_ID;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dtScheduleReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtScheduleReport.SelectedRows.Count > 0)
                {
                    Temp_ID = dtScheduleReport.SelectedRows[0].Cells[0].Value + string.Empty;
                    label44.Text = Temp_ID;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BtnDeleteFromCompletedSchedule_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Temp_ID);
            int result = rb.DeleteScheduleRow(ID);
            try
            {
                if (result == 1)
                {
                    lblMessage.Text = "Selected Row Deleted";
                    try
                    {
                        dtPickerScheduleReport.Format = DateTimePickerFormat.Custom;
                        dtPickerScheduleReport.CustomFormat = "yyyy-MM-dd";
                        string SelectedDate = dtPickerScheduleReport.Value.ToShortDateString();
                        dtScheduleReport.DataSource = rb.JummaScheduleReportByDate(SelectedDate);
                        dtScheduleReport.Columns["Row_count"].Visible = false;
                    }
                    catch (Exception)
                    {
                        lblMessage.Text = "Loading...";
                    }
                }
                else
                {
                    lblMessage.Text = "Oops; Some thing went wrong";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void FilterByDhaeNameReport_Click(object sender, EventArgs e)
        {
            if (FilterByDhaeNameReport.Focus() == true)
            {
                FilterByBranchNameReport.Text = "Filter by Branch Name";
                FilterByDhaeContactNumber.Text = "Filter by Dhae Contact Number";
                FilterByInchargePersonReport.Text = "Filter By Incharge Person Name";
                FilterByDhaeNameReport.Text = "";
                FilterByDhaeNameReport.Focus();
            }
        }

        private void FilterByDhaeContactNumber_Click(object sender, EventArgs e)
        {
            if (FilterByDhaeContactNumber.Focus() == true)
            {
                FilterByBranchNameReport.Text = "Filter by Branch Name";
                FilterByInchargePersonReport.Text = "Filter By Incharge Person Name";
                FilterByDhaeNameReport.Text = "Filter By Dhae Name Report";
                FilterByDhaeContactNumber.Text = "";
            }
        }

        private void FilterByBranchNameReport_Click(object sender, EventArgs e)
        {
            FilterByDhaeContactNumber.Text = "Filter by Dhae Contact Number";
            FilterByInchargePersonReport.Text = "Filter By Incharge Person Name";
            FilterByDhaeNameReport.Text = "Filter By Dhae Name Report";
            FilterByBranchNameReport.Focus();
            FilterByBranchNameReport.Text = "";
        }

        private void FilterByInchargePersonReport_Click(object sender, EventArgs e)
        {
            FilterByBranchNameReport.Text = "Filter by Branch Name";
            FilterByDhaeContactNumber.Text = "Filter by Dhae Contact Number";
            FilterByDhaeNameReport.Text = "Filter By Dhae Name Report";
            FilterByInchargePersonReport.Focus();
            FilterByInchargePersonReport.Text = "";
        }

        private void FilterByDhaeNameReport_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                BindingSource bsDvd = new BindingSource
                {
                    DataSource = dtScheduleReport.DataSource,
                    Filter = string.Format("Dhae_Name LIKE '{0}%' OR Dhae_Name LIKE '% {0}%'", FilterByDhaeNameReport.Text)
                };
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void FilterByDhaeContactNumber_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                BindingSource bsDvd = new BindingSource
                {
                    DataSource = dtScheduleReport.DataSource,
                    Filter = string.Format("Dhae_Contact LIKE '{0}%' OR Dhae_Contact LIKE '% {0}%'", FilterByDhaeContactNumber.Text)
                };
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void FilterByBranchNameReport_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                BindingSource bsDvd = new BindingSource
                {
                    DataSource = dtScheduleReport.DataSource,
                    Filter = string.Format("Branch_Name LIKE '{0}%' OR Branch_Name LIKE '% {0}%'", FilterByBranchNameReport.Text)
                };
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void FilterByInchargePersonReport_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                BindingSource bsDvd = new BindingSource
                {
                    DataSource = dtScheduleReport.DataSource,
                    Filter = string.Format("JIP_Name LIKE '{0}%' OR JIP_Name LIKE '% {0}%'", FilterByInchargePersonReport.Text)
                };
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void BtnCheckLastFourWeeks_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtJummaBranchName.Text != "")
                {
                    LblReport.Text = "Last 4 Weeks Jummah Dhae details for selected branch";
                    panel6.Visible = true;
                    string Friday1 = label45.Text;
                    string Friday2 = label46.Text;
                    string Friday3 = label47.Text;
                    string Friday4 = label48.Text;
                    DataTable dt1 = rb.LastMonthDhaeReportByDate(Friday1, txtJummaBranchName.Text.Trim());
                    DataTable dt2 = rb.LastMonthDhaeReportByDate(Friday2, txtJummaBranchName.Text.Trim());
                    DataTable dt3 = rb.LastMonthDhaeReportByDate(Friday3, txtJummaBranchName.Text.Trim());
                    DataTable dt4 = rb.LastMonthDhaeReportByDate(Friday4, txtJummaBranchName.Text.Trim());

                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        LblBranch1.Text = dr1[0].ToString().Trim();
                    }

                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        LblBranch2.Text = dr2[0].ToString().Trim();
                    }

                    foreach (DataRow dr3 in dt3.Rows)
                    {
                        LblBranch3.Text = dr3[0].ToString().Trim();
                    }

                    foreach (DataRow dr4 in dt4.Rows)
                    {
                        LblBranch4.Text = dr4[0].ToString().Trim();
                    }
                    DataSet SuggestedDhae = db.SuggestedDhaeList(LblBranch1.Text, LblBranch2.Text, LblBranch3.Text, LblBranch4.Text);
                    if (SuggestedDhae.Tables[0].Rows.Count > 0)
                    {
                        //Blink();
                        L1.Text = Convert.ToString(SuggestedDhae.Tables[0].Rows[0].Field<string>(0));
                        L2.Text = Convert.ToString(SuggestedDhae.Tables[0].Rows[1].Field<string>(0));
                        L3.Text = Convert.ToString(SuggestedDhae.Tables[0].Rows[2].Field<string>(0));
                        L4.Text = Convert.ToString(SuggestedDhae.Tables[0].Rows[3].Field<string>(0));
                    }
                    // Slider();
                }
                else
                {
                    lblMessage.Text = "Please Enter the Branch Name";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        //private async void Blink()
        //{
        //    while (true)
        //    {
        //        await Task.Delay(500);
        //        L1.BackColor = L1.BackColor == Color.White ? Color.Black : Color.White;
        //        L2.BackColor = L2.BackColor == Color.White ? Color.Black : Color.White;
        //        L3.BackColor = L3.BackColor == Color.White ? Color.Black : Color.White;
        //        L4.BackColor = L4.BackColor == Color.White ? Color.Black : Color.White;
        //    }
        //}

        public void Slider()
        {
            xpos = LabelSlider.Location.X;

            ypos = LabelSlider.Location.Y;

            mode = "Left-to-Right";

            TimerSlider.Start();
        }

        private void BtnViewAllReport_Click(object sender, EventArgs e)
        {
            dtScheduleReport.DataSource = rb.GetAll();
        }

        private void BtnGetBranchNames_Click(object sender, EventArgs e)
        {
            try
            {
                LblReport.Text = "Last 4 Weeks Jumma Branch details for selected Dhae";
                if (panel6.Visible == false)
                    panel6.Visible = true;
                string Friday1 = label45.Text;
                string Friday2 = label46.Text;
                string Friday3 = label47.Text;
                string Friday4 = label48.Text;
                DataTable dt1 = rb.LastMonthBranchReportByDate(Friday1, txtJummaDhaeName.Text.Trim());
                DataTable dt2 = rb.LastMonthBranchReportByDate(Friday2, txtJummaDhaeName.Text.Trim());
                DataTable dt3 = rb.LastMonthBranchReportByDate(Friday3, txtJummaDhaeName.Text.Trim());
                DataTable dt4 = rb.LastMonthBranchReportByDate(Friday4, txtJummaDhaeName.Text.Trim());

                foreach (DataRow dr1 in dt1.Rows)
                {
                    LblBranch1.Text = dr1[0].ToString().Trim();
                }

                foreach (DataRow dr2 in dt2.Rows)
                {
                    LblBranch2.Text = dr2[0].ToString().Trim();
                }

                foreach (DataRow dr3 in dt3.Rows)
                {
                    LblBranch3.Text = dr3[0].ToString().Trim();
                }

                foreach (DataRow dr4 in dt4.Rows)
                {
                    LblBranch4.Text = dr4[0].ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void TimerSlider_Tick(object sender, EventArgs e)
        {
            if (mode == "Left-to-Right")
            {
                if (Width == xpos)
                {
                    LabelSlider.Location = new Point(0, ypos);
                    xpos = 0;
                }
                else
                {
                    LabelSlider.Location = new Point(xpos, ypos);
                    xpos += 2;
                }
            }
        }

        private void FilterByDhaeNameReport_TextChanged(object sender, EventArgs e)
        {
            FilterByBranchNameReport.Text = "Filter by Branch Name";
            FilterByDhaeContactNumber.Text = "Filter by Dhae Contact Number";
            FilterByInchargePersonReport.Text = "Filter By Incharge Person Name";
        }

        private void SuggestedDhaeNames_Tick(object sender, EventArgs e)
        {
            try
            {
                if (txtJummaBranchName.Text != "")
                {
                    LblReport.Text = "Last 4 Weeks Jummah Dhae details for selected branch";
                    panel6.Visible = true;
                    string Friday1 = label45.Text;
                    string Friday2 = label46.Text;
                    string Friday3 = label47.Text;
                    string Friday4 = label48.Text;
                    DataTable dt1 = rb.LastMonthDhaeReportByDate(Friday1, txtJummaBranchName.Text.Trim());
                    DataTable dt2 = rb.LastMonthDhaeReportByDate(Friday2, txtJummaBranchName.Text.Trim());
                    DataTable dt3 = rb.LastMonthDhaeReportByDate(Friday3, txtJummaBranchName.Text.Trim());
                    DataTable dt4 = rb.LastMonthDhaeReportByDate(Friday4, txtJummaBranchName.Text.Trim());

                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        LblBranch1.Text = dr1[0].ToString().Trim();
                    }

                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        LblBranch2.Text = dr2[0].ToString().Trim();
                    }

                    foreach (DataRow dr3 in dt3.Rows)
                    {
                        LblBranch3.Text = dr3[0].ToString().Trim();
                    }

                    foreach (DataRow dr4 in dt4.Rows)
                    {
                        LblBranch4.Text = dr4[0].ToString().Trim();
                    }
                    DataSet SuggestedDhae = db.SuggestedDhaeList(LblBranch1.Text, LblBranch2.Text, LblBranch3.Text, LblBranch4.Text);
                    if (SuggestedDhae.Tables[0].Rows.Count > 0)
                    {
                        //Blink();
                        L1.Text = Convert.ToString(SuggestedDhae.Tables[0].Rows[0].Field<string>(0));
                        L2.Text = Convert.ToString(SuggestedDhae.Tables[0].Rows[1].Field<string>(0));
                        L3.Text = Convert.ToString(SuggestedDhae.Tables[0].Rows[2].Field<string>(0));
                        L4.Text = Convert.ToString(SuggestedDhae.Tables[0].Rows[3].Field<string>(0));
                    }
                    // Slider();
                }
                else
                {
                    lblMessage.Text = "Please Enter the Branch Name";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        //Class to Copy datagrid view to excell
        private void CopyReports()
        {
            dtScheduleReport.SelectAll();
            DataObject dataObj = dtScheduleReport.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void ExportExcelReport_Click(object sender, EventArgs e)
        {
            try
            {
                CopyReports();
                Excell.Application xlexcel;
                Excell.Workbook xlWorkBook;
                Excell.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Excell.Application
                {
                    Visible = true
                };
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Excell.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Excell.Range CR = (Excell.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void L1_Click(object sender, EventArgs e)
        {
            txtJummaDhaeName.Text = L1.Text.Trim();
        }

        private void L2_Click(object sender, EventArgs e)
        {
            txtJummaDhaeName.Text = L2.Text.Trim();
        }

        private void L3_Click(object sender, EventArgs e)
        {
            txtJummaDhaeName.Text = L3.Text.Trim();
        }

        private void L4_Click(object sender, EventArgs e)
        {
            txtJummaDhaeName.Text = L4.Text.Trim();
        }

        private void FilterByDhaeContactNumber_TextChanged(object sender, EventArgs e)
        {
            FilterByBranchNameReport.Text = "Filter by Branch Name";
            FilterByInchargePersonReport.Text = "Filter By Incharge Person Name";
            FilterByDhaeNameReport.Text = "Filter By Dhae Name Report";
        }

        private void FilterByBranchNameReport_TextChanged(object sender, EventArgs e)
        {
            FilterByDhaeContactNumber.Text = "Filter by Dhae Contact Number";
            FilterByInchargePersonReport.Text = "Filter By Incharge Person Name";
            FilterByDhaeNameReport.Text = "Filter By Dhae Name Report";
        }

        private void FilterByInchargePersonReport_TextChanged(object sender, EventArgs e)
        {
            FilterByBranchNameReport.Text = "Filter by Branch Name";
            FilterByDhaeContactNumber.Text = "Filter by Dhae Contact Number";
            FilterByDhaeNameReport.Text = "Filter By Dhae Name Report";
        }

        private void DGVDhaeDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DGVDhaeDetails.SelectedRows.Count > 0)
                {
                    string Dhae_ID = DGVDhaeDetails.SelectedRows[0].Cells[0].Value + string.Empty;
                    txtDhaeIDforUpdate.Text = Dhae_ID;
                    LblDeleteDhaeID.Visible = true;
                    LblSelectedDhaeIDNumber.Visible = true;
                    LblSelectedDhaeIDNumber.Text = Dhae_ID;
                    int DhaeID = Convert.ToInt32(Dhae_ID);
                    DataTable dt = db.LoadDhaeByDhaeID(DhaeID);
                    foreach (DataRow dr in dt.Rows)
                    {
                        txtUpdateDhaeName.Text = dr[1].ToString();
                        txtUpdateDhaeContactNo.Text = dr[2].ToString();
                        txtUpdateDhaeHouseNo.Text = dr[3].ToString();
                        txtUpdateDhaeStreetName.Text = dr[4].ToString();
                        txtUpdateDhaeCity.Text = dr[5].ToString();
                        txtUpdateDhaeDistrict.Text = dr[6].ToString();
                    }

                    if (txtUpdateDhaeName.Text != "")
                    {
                        txtDhaeIDforUpdate.Enabled = false;
                    }
                }
            }
            catch (Exception)
            {
                lblMessage.Text = "Empty Value";
            }
        }

        private void DGVBranchDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DGVBranchDetails.SelectedRows.Count > 0)
                {
                    string Branch_ID = DGVBranchDetails.SelectedRows[0].Cells[0].Value + string.Empty;
                    LblSelectedBranchIDToDelete.Text = Branch_ID;
                    LblSelectedBranchIDToDelete.Visible = true;
                    LblSelectedBID.Visible = true;
                    txtUpdateBranchID.Text = Branch_ID;
                    DataTable dt = bb.LoadBranchByBranchID(Branch_ID);
                    foreach (DataRow dr in dt.Rows)
                    {
                        txtUpdateBranchName.Text = dr[1].ToString();
                        txtUpdateJIPName.Text = dr[2].ToString();
                        txtUpdateJIPContact.Text = dr[3].ToString();
                        txtUpdateBuildingNo.Text = dr[4].ToString();
                        txtUpdateBranchStreetName.Text = dr[5].ToString();
                        txtUpdateBranchCity.Text = dr[6].ToString();
                        txtUpdateBranchDistrictName.Text = dr[7].ToString();
                    }
                    if (txtUpdateBranchName.Text != "")
                    {
                        txtBranchName.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void BtnReload_Click(object sender, EventArgs e)
        {
        }

        private void TimerShowBranches_Tick(object sender, EventArgs e)
        {
            PanelBranchesLeft.Height += 15;
            if (PanelBranchesLeft.Height >= 150)
            {
                BtnShowBranches.Text = "Hide";
                TimerShowBranches.Enabled = false;
            }
        }

        private void BtnShowBranches_Click(object sender, EventArgs e)
        {
            if (BtnShowBranches.Text == "Show")
            {
                TimerShowBranches.Enabled = true;
                TimerShowBranches1.Enabled = false;
            }
            else if (BtnShowBranches.Text == "Hide")
            {
                TimerShowBranches1.Enabled = true;
                TimerShowBranches.Enabled = false;
            }
        }

        private void TimerShowBranches1_Tick(object sender, EventArgs e)
        {
            PanelBranchesLeft.Height -= 15;
            if (PanelBranchesLeft.Height <= 50)
            {
                BtnShowBranches.Text = "Show";
                TimerShowBranches1.Enabled = false;
            }
        }

        private void DGVBranchesLeft_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DGVBranchesLeft.SelectedRows.Count > 0)
                {
                    string SelectedBranch = DGVBranchesLeft.SelectedRows[0].Cells[0].Value + string.Empty;
                    txtJummaBranchName.Text = SelectedBranch.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BranchCount_Tick(object sender, EventArgs e)
        {
            if (PanelBranchesLeft.Width <= 140)
            {
                PanelBranchesLeft.Width += 10;
            }
        }

        private void BtnShowPendingBranches_Click(object sender, EventArgs e)
        {
            TimerBranchCount.Enabled = true;
            DataTable dtBranches = bb.GetRowCountForTempBranchTempTable();
            if (dtBranches.Rows.Count > 0)
            {
                LblBranchesLeft.Text = dtBranches.Rows.Count.ToString();
            }
        }

        private void BtnDeleteDhae_Click(object sender, EventArgs e)
        {
            int Dhae_ID = Convert.ToInt32(LblSelectedDhaeIDNumber.Text.Trim());
            int result = db.InsertDhaeDetailsToDeleted(Dhae_ID);
            try
            {
                if (result == 1)
                {
                    int re = db.DeleteDhaeDetails(Dhae_ID);
                    if (re == 1)
                    {
                        lblMessage.Text = "Dhae Details Deleted Successfully";
                        DGVDhaeDetails.DataSource = db.LoadDhaes();
                    }
                    else
                    {
                        lblMessage.Text = "Something Went wrong";
                    }
                }
                else
                {
                    lblMessage.Text = "Oops! ... Something Went wrong";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void txtSearchCity_Click(object sender, EventArgs e)
        {
            txtSearchCity.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
            Close(); //to turn off current app
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {
        }

        private void CopyPDFReport()
        {
            DGVPDFReport.SelectAll();
            DataObject dataObj = DGVPDFReport.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void ExportExcellReport_Click(object sender, EventArgs e)
        {
            try
            {
                CopyPDFReport();
                Excell.Application xlexcel;
                Excell.Workbook xlWorkBook;
                Excell.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Excell.Application
                {
                    Visible = true
                };
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Excell.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Excell.Range CR = (Excell.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void BtnDeleteBranch_Click(object sender, EventArgs e)
        {
            string Branch_ID = LblSelectedBranchIDToDelete.Text.Trim();
            int result = bb.InsertBranchDetailsToDeleted(Branch_ID);
            try
            {
                if (result == 1)
                {
                    int re = bb.DeleteBranchDetails(Branch_ID);
                    if (re == 1)
                    {
                        lblMessage.Text = "Branch Details Deleted Successfully";
                        DGVBranchDetails.DataSource = bb.LoadAllBraches();
                    }
                    else
                    {
                        lblMessage.Text = "Something Went wrong";
                    }
                }
                else
                {
                    lblMessage.Text = "Oops! ... Something Went wrong";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void AddBranch_Click(object sender, EventArgs e)
        {
        }
    }

    public static class MyExtensions
    {
        public static string AppendTimeStamp(this string fileName)
        {
            return string.Concat(
                Path.GetFileNameWithoutExtension(fileName),
                DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                Path.GetExtension(fileName)
                );
        }
    }
}