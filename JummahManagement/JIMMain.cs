using JummahManagement.Business;
using System;
using System.Windows.Forms;

namespace JummahManagement
{
    public partial class main : Form
    {
        DhaeBAL db = new DhaeBAL();
        BranchBAL bb = new BranchBAL();
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbJummah_ManagementDataSet2.tbl_Branches' table. You can move, or remove it, as needed.
            tbl_BranchesTableAdapter.Fill(this.dbJummah_ManagementDataSet2.tbl_Branches);
            // TODO: This line of code loads data into the 'dbJummah_ManagementDataSet1.tbl_Dhae' table. You can move, or remove it, as needed.
            tbl_DhaeTableAdapter.Fill(dbJummah_ManagementDataSet1.tbl_Dhae);
            // TODO: This line of code loads data into the 'dbJummah_ManagementDataSet.tbl_City' table. You can move, or remove it, as needed.
            tbl_CityTableAdapter.Fill(this.dbJummah_ManagementDataSet.tbl_City);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbl_CityTableAdapter.FillBy(this.dbJummah_ManagementDataSet.tbl_City);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                AddCity ac = new AddCity();
                ac.Show();
        }

        private void btnAddDhae_Click(object sender, EventArgs e)
        {
            int Dhae_ID = Convert.ToInt32(txtDhaeID.Text);
            string Dhae_Name = txtDhaeName.Text;
            string DhaeContactNo = txtDhaeContact.Text;
            string HouseNo = txtHouseNo.Text;
            string StreetName = txtStreetName.Text;
            string City = cmbCity.GetItemText(cmbCity.SelectedItem);
            string District = cmbDistrict.GetItemText(cmbDistrict.SelectedItem);
            int result = db.AddDhae(Dhae_ID,Dhae_Name,DhaeContactNo,HouseNo,StreetName,City,District);
                if (result == 1)
                {
                    MessageBox.Show("Successfully Added");
                    tbl_DhaeTableAdapter.Fill(dbJummah_ManagementDataSet1.tbl_Dhae);
                }
                else
                {
                    MessageBox.Show("Something Went wrong");
                }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string Branch_ID = txtBranchID.Text;
            string Branch_Name = txtBranchName.Text;
            string JIT_Name = txtJIT_Name.Text;
            string JIT_Contact = txtJIT_Contact.Text;
            string BuildingNo = txtBuildingNo.Text;
            string StreetName = txtStreet.Text;
            string City = cmbCityNames.GetItemText(cmbCityNames.SelectedItem);
            string District = cmbDistrictNames.GetItemText(cmbDistrictNames.SelectedItem);

            int result = bb.AddBranch(Branch_ID, Branch_Name, JIT_Name, JIT_Contact, BuildingNo, StreetName, City, District);
            if (result == 1)
            {
                MessageBox.Show("Successfully Added");
                tbl_BranchesTableAdapter.Fill(this.dbJummah_ManagementDataSet2.tbl_Branches);
            }
            else
            {
                MessageBox.Show("Something Went wrong");
            }
        }
    }
}
