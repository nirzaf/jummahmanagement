using JummahManagement.Business;
using System;
using System.Windows.Forms;

namespace JummahManagement
{
    public partial class AddCity : Form
    {
        DhaeBAL db = new DhaeBAL();
        public AddCity()
        {
            InitializeComponent();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            txtAddCityName.Text = "";
        }

        private void btn_Add_City_Click(object sender, EventArgs e)
        {
            string City = txtAddCityName.Text;
            int result = db.AddCity(City);
            if (result == 1)
            {
                MessageBox.Show("Added");
            }
            else
            {
                MessageBox.Show("Not Added");
            }
        }
    }
}
