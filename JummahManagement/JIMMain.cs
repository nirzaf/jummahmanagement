using JummahManagement.Business;
using JummahManagement.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excell = Microsoft.Office.Interop.Excel;

namespace JummahManagement
{
    public partial class main : Form
    {
        DhaeBAL db = new DhaeBAL();
        BranchBAL bb = new BranchBAL();
        ReportsBAL rb = new ReportsBAL();
        JummahReports jr = new JummahReports();
        public string City_ID;
        public string City;
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbJummah_ManagementDataSet3.tbl_Jummah_Schedule_temp' table. You can move, or remove it, as needed.
            tbl_Jummah_Schedule_tempTableAdapter.Fill(dbJummah_ManagementDataSet3.tbl_Jummah_Schedule_temp);
            try
            {
                dtCityNames.DataSource = rb.GetCity();
                dtCityNames.Columns["City_ID"].Visible = false;
                // TODO: This line of code loads data into the 'dbJummah_ManagementDataSet2.tbl_Branches' table. You can move, or remove it, as needed.
                tbl_BranchesTableAdapter.Fill(this.dbJummah_ManagementDataSet2.tbl_Branches);
                // TODO: This line of code loads data into the 'dbJummah_ManagementDataSet1.tbl_Dhae' table. You can move, or remove it, as needed.
                tbl_DhaeTableAdapter.Fill(dbJummah_ManagementDataSet1.tbl_Dhae);
                // TODO: This line of code loads data into the 'dbJummah_ManagementDataSet.tbl_City' table. You can move, or remove it, as needed.
                tbl_CityTableAdapter.Fill(this.dbJummah_ManagementDataSet.tbl_City);
                FormLoad();
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
            // TODO: This line of code loads data into the 'dbJummah_ManagementDataSet3.tbl_Jummah_Schedule_temp' table. You can move, or remove it, as needed.
            tbl_Jummah_Schedule_tempTableAdapter.Fill(dbJummah_ManagementDataSet3.tbl_Jummah_Schedule_temp);
            try
            {
                dtCityNames.DataSource = rb.GetCity();
                dtCityNames.Columns["City_ID"].Visible = false;
                // TODO: This line of code loads data into the 'dbJummah_ManagementDataSet2.tbl_Branches' table. You can move, or remove it, as needed.
                tbl_BranchesTableAdapter.Fill(this.dbJummah_ManagementDataSet2.tbl_Branches);
                // TODO: This line of code loads data into the 'dbJummah_ManagementDataSet1.tbl_Dhae' table. You can move, or remove it, as needed.
                tbl_DhaeTableAdapter.Fill(dbJummah_ManagementDataSet1.tbl_Dhae);
                // TODO: This line of code loads data into the 'dbJummah_ManagementDataSet.tbl_City' table. You can move, or remove it, as needed.
                tbl_CityTableAdapter.Fill(this.dbJummah_ManagementDataSet.tbl_City);

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

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbl_CityTableAdapter.FillBy(this.dbJummah_ManagementDataSet.tbl_City);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }


        private void comboBox2_TextUpdate(object sender, EventArgs e)
        {
            cmbCity.DropDownStyle = ComboBoxStyle.DropDown;
            cmbCity.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCity.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtAddNewCity.Visible = true;
            btnAddNewCity.Visible = true;
        }

        private void btnAddDhae_Click(object sender, EventArgs e)
        {
            int Dhae_ID = Convert.ToInt32(txtDhaeID.Text);
            string Dhae_Name = txtDhaeName.Text.Trim();
            string DhaeContactNo = txtDhaeContact.Text.Trim();
            string HouseNo = txtHouseNo.Text.Trim();
            string StreetName = txtStreetName.Text.Trim();
            string City = cmbCity.GetItemText(cmbCity.SelectedItem);
            string District = cmbDistrict.GetItemText(cmbDistrict.SelectedItem);
            int result = db.AddDhae(Dhae_ID,Dhae_Name,DhaeContactNo,HouseNo,StreetName,City,District);
                if (result == 1)
                {
                    lblMessage.Text = "Successfully Added";
                    tbl_DhaeTableAdapter.Fill(dbJummah_ManagementDataSet1.tbl_Dhae);
                }
                else
                {
                    lblMessage.Text = "Something Went wrong";
                }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string Branch_ID = txtBranchID.Text.Trim();
            string Branch_Name = txtBranchName.Text.Trim();
            string JIT_Name = txtJIT_Name.Text.Trim();
            string JIT_Contact = txtJIT_Contact.Text.Trim();
            string BuildingNo = txtBuildingNo.Text.Trim();
            string StreetName = txtStreet.Text.Trim();
            string City = cmbCityNames.GetItemText(cmbCityNames.SelectedItem);
            string District = cmbDistrictNames.GetItemText(cmbDistrictNames.SelectedItem);

            int result = bb.AddBranch(Branch_ID, Branch_Name, JIT_Name, JIT_Contact, BuildingNo, StreetName, City, District);
            if (result == 1)
            {
                lblMessage.Text =  "Successfully Added";
                tbl_BranchesTableAdapter.Fill(this.dbJummah_ManagementDataSet2.tbl_Branches);
            }
            else
            {
                lblMessage.Text =  "Something Went wrong";
            }
        }

        private void btnAddNewCity_Click(object sender, EventArgs e)
        {
            string City = txtAddNewCity.Text;
            int result = db.AddCity(City);
            if (result == 1)
            {
                lblMessage.Text =  "Added";
                txtAddNewCity.Visible = false;
                btnAddNewCity.Visible = false;
                tbl_CityTableAdapter.Fill(dbJummah_ManagementDataSet.tbl_City);
            }
            else
            {
                lblMessage.Text = "Not Added";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtAddnewCity1.Visible = true;
            btnAddNewCity1.Visible = true;
        }

        private void btnAddNewCity1_Click(object sender, EventArgs e)
        {
            string City = txtAddnewCity1.Text;
            int result = db.AddCity(City);
            if (result == 1)
            {
                lblMessage.Text = "Added";
                txtAddNewCity.Visible = false;
                btnAddNewCity.Visible = false;
                tbl_CityTableAdapter.Fill(dbJummah_ManagementDataSet.tbl_City);
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
                    lblMessage.Text = "Updated Successfully";
                }

                if (txtUpdateDhaeName.Text != "")
                {
                    txtDhaeIDforUpdate.Enabled = false;
                }
            }
            catch (Exception ex)
            {
               lblMessage.Text= ex.Message;
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
                    lblMessage.Text = "Updated Successfully";
                }
                if (txtUpdateBranchName.Text != "")
                {
                    txtBranchName.Enabled = false;
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
                string UpdateBranchName = txtUpdateBranchName.Text;
                string UpdateBranchJIPName = txtUpdateJIPName.Text;
                string UpdateBranchJIPContact = txtUpdateJIPContact.Text;
                string UpdateBranchBuildingNo = txtUpdateBuildingNo.Text;
                string UpdateBranchStreetName = txtUpdateBranchStreetName.Text;
                string UpdateBranchCity = txtUpdateBranchCity.Text;
                string UpdateBranchDistrict = txtUpdateBranchDistrictName.Text;


                if (txtUpdateBranchName.Text != "")
                {
                    int result = bb.UpdateBranchDetails(UpdateBranchID, UpdateBranchName, UpdateBranchJIPName, UpdateBranchJIPContact, UpdateBranchBuildingNo, UpdateBranchStreetName, UpdateBranchCity, UpdateBranchDistrict);
                    if (result == 1)
                    {
                        lblMessage.Text = "Branch Details Successfully Updated";
                    }
                    else
                    {
                        lblMessage.Text = "Please Enter Valid Branch ID to Update";
                    }
                }
                else
                {
                    lblMessage.Text = "Please Enter Valid Branch ID to Update";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message; 
            }
            
        }

        //Function to Delete Dhae details
        private void btnDeleteDhaeDetails_Click(object sender, EventArgs e)
        {
            int Dhae_ID = Convert.ToInt32(txtDeleteDhaeByID.Text);
            DataTable dt = db.LoadDhaeByDhaeID(Dhae_ID);
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string UpdateDhaeName = dr[1].ToString();
                    string UpdateDhaeContactNo = dr[2].ToString();
                    string UpdateDhaeHouseNo = dr[3].ToString();
                    string UpdateDhaeStreetName = dr[4].ToString();
                    string UpdateDhaeCity = dr[5].ToString();
                    string UpdateDhaeDistrict = dr[6].ToString();

                    int result = db.AddDhaeToDeleted(Dhae_ID, UpdateDhaeName, UpdateDhaeContactNo, UpdateDhaeHouseNo, UpdateDhaeStreetName, UpdateDhaeCity, UpdateDhaeDistrict);

                    if (result == 1)
                    {
                        int re = db.DeleteDhaeDetails(Dhae_ID);
                        if (re == 1)
                        {
                            lblMessage.Text = "Dhae Details Deleted Successfully";
                            tbl_DhaeTableAdapter.Fill(dbJummah_ManagementDataSet1.tbl_Dhae);
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
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }

        }

        private void txtDeleteDhaeByID_Click(object sender, EventArgs e)
        {
            txtDeleteDhaeByID.Text = "";
        }

        private void txtDeleteBranchByID_Click(object sender, EventArgs e)
        {
            txtDeleteBranchByID.Text = "";
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
                JummaDtPicker.CustomFormat = "dd/MM/yyyy";
                string SelectedDate = JummaDtPicker.Value.ToShortDateString();
                lblSelectedDate.Text = SelectedDate;
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

        //Function to Create Schedule List
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string DhaeName = txtJummaDhaeName.Text.Trim();
                DataTable dt = db.LoadDhaeNoByDhaeName(DhaeName);
                foreach (DataRow dr in dt.Rows)
                {
                    lblDhaeContact.Text = dr[0].ToString();
                }
                string BranchName = txtJummaBranchName.Text.Trim();
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
                //dtJummaSchedule.Rows.Add(dtJummaSchedule.RowCount, txtJummaDhaeName.Text, lblDhaeContact.Text, BranchName, lblJummaInchargeName.Text, lblJummaInchargeNumber.Text, lblSelectedDate.Text);
                int result = rb.AddJummaSchedule(RowCount, txtJummaDhaeName.Text, lblDhaeContact.Text, BranchName, lblJummaInchargeName.Text, lblJummaInchargeNumber.Text, lblSelectedDate.Text);
                if (result == 1)
                {
                    btnAdd.Enabled = false;
                    txtJummaBranchName.Focus();
                    tbl_Jummah_Schedule_tempTableAdapter.Fill(dbJummah_ManagementDataSet3.tbl_Jummah_Schedule_temp);
                }
                else
                {
                    lblMessage.Text = "Something went wrong";
                }
               
            }
            catch (Exception)
            {
                throw;
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
                    SqlCommand cmd = new SqlCommand("INSERT into tbl_Jummah_Schedule (Row_Count,Dhae_Name,Dhae_Contact,Branch_Name,JIP_Name,JIP_Contact,Date) Values ('" + dtJummaSchedule.Rows[i].Cells[0].Value + "','" + dtJummaSchedule.Rows[i].Cells[1].Value + "','" + dtJummaSchedule.Rows[i].Cells[2].Value + "','" + dtJummaSchedule.Rows[i].Cells[3].Value + "','" + dtJummaSchedule.Rows[i].Cells[4].Value + "','" + dtJummaSchedule.Rows[i].Cells[5].Value + "','" + dtJummaSchedule.Rows[i].Cells[6].Value + "' )", newCon.Con);
                    if (ConnectionState.Closed == newCon.Con.State)
                    {
                        newCon.Con.Open();
                    }
                    cmd.ExecuteNonQuery();
                    newCon.Con.Close();
                }
                lblMessage.Text = "Successfully Jummah Schedule Added";
                jr.DropAndRecreate();
                string SelectedDate = JummaDtPicker.Value.ToShortDateString();
                dtJummaSchedule.DataSource = db.LoadDhaeReportByDate(SelectedDate);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        //function to view jummah schedule report
        private void dtJummahReport_ValueChanged(object sender, EventArgs e)
        {
            dtJummahReport.CustomFormat = "mm/DD/yyyy";
            dtDhaeReport.Rows.Clear();
            dtInchargeReport.Rows.Clear();
            string SelectedDate = dtJummahReport.Value.ToShortDateString();
            DataTable dt = db.LoadDhaeReportByDate(SelectedDate);
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    string DhaeNo = dr[3].ToString();
                    string Date = SelectedDate;
                    string BranchName = "Jummah_" + dr[4].ToString();
                    string Contact = dr[6].ToString();
                    string Incharge = "_(" + dr[5].ToString() + ")";
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
                    string Contact = dr1[6].ToString();
                    string Date = SelectedDate;
                    string DhaeData = "_Jummah_" + dr1[2].ToString() + "_(" + dr1[3].ToString() + ")";
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
                xlexcel = new Excell.Application();
                xlexcel.Visible = true;
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
                xlexcel = new Excell.Application();
                xlexcel.Visible = true;
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
            catch (Exception)
            {
                throw;
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
                dtPickerScheduleReport.CustomFormat = "mm/DD/yyyy";
                string SelectedDate = dtPickerScheduleReport.Value.ToShortDateString();
                dtScheduleReport.DataSource = rb.JummaScheduleReportByDate(SelectedDate);
                dtScheduleReport.Columns["ID"].Visible = false;
                dtScheduleReport.Columns["Row_count"].Visible = false;
            }
            catch (Exception)
            {
                lblMessage.Text = "Loading...";
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
                BindingSource bsDvd = new BindingSource();
                bsDvd.DataSource = dtJummaSchedule.DataSource;
                bsDvd.Filter = string.Format("JIP_Name LIKE '{0}%' OR JIP_Name LIKE '% {0}%'", txtFilterByJIPName.Text);
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
                BindingSource bsDvd = new BindingSource();
                bsDvd.DataSource = dtJummaSchedule.DataSource;
                bsDvd.Filter = string.Format("Dhae_Name LIKE '{0}%' OR Dhae_Name LIKE '% {0}%'", txtFilterByDhaeName.Text);
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
                            jr.DropAndRecreate();
                            tbl_Jummah_Schedule_tempTableAdapter.Fill(dbJummah_ManagementDataSet3.tbl_Jummah_Schedule_temp);
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
            }
            else
            {
                lblMessage.Text = "Oops! Something went wrong";
            }
            tbl_CityTableAdapter.Fill(this.dbJummah_ManagementDataSet.tbl_City);
        }

        //Fucntion to Refersh all DGV
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reload();
        }
    }
}
