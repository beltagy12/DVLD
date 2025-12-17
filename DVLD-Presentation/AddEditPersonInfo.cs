using DVLD_BusinessAccsess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DVLD_Presentation
{

    public partial class AddEditPersonInfo : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        clsPersonBusinessAccsess _PersonBusinessAccsess;

        private int _PersonID;


        public AddEditPersonInfo(int PersonID)
        {

            InitializeComponent();
            _PersonID = PersonID;
            if (PersonID == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
                _Mode = enMode.Update;
        }
        private void FillAllCountriesInCb()
        {
            DataTable dt = new DataTable();
            dt = Country.GetAllCountries();
            foreach (DataRow dr in dt.Rows)
            {
                cbCountry.Items.Add(dr["CountryName"].ToString());
            }

        }

        private void _LoadData()
        {
            FillAllCountriesInCb();
            cbCountry.SelectedIndex = 0;
            if (_Mode == enMode.AddNew)
            {
                cbCountry.SelectedIndex = 0;

                lblMode.Text = "Add New Person";
                label15.Visible = false;
                _PersonBusinessAccsess = new clsPersonBusinessAccsess();
                return;

            }
            lblMode.Text = "Update Person";
            label15.Visible = true;
            label15.Text = _PersonID.ToString();
            // lblMode.Text=
            _PersonBusinessAccsess = clsPersonBusinessAccsess.Find(_PersonID);
            if (_PersonBusinessAccsess != null)
            {

                cbCountry.Text = Country.Find(_PersonBusinessAccsess.NationalityCountryID).CountryName;

                txtFirstName.Text = _PersonBusinessAccsess.FirstName;
                txtSecondName.Text = _PersonBusinessAccsess.SecondName;
                if (_PersonBusinessAccsess.ThirdName != "")
                {
                    txtThirdName.Text = _PersonBusinessAccsess.ThirdName;

                }
                else
                {
                    txtThirdName.Text = "";
                }

                if (_PersonBusinessAccsess.Email != "")
                {
                    txtEmail.Text = _PersonBusinessAccsess.Email;

                }
                else
                {
                    txtEmail.Text = "";
                }
                txtLastName.Text = _PersonBusinessAccsess.LastName;
                txtnational.Text = _PersonBusinessAccsess.NationalNo;
                txtAddress.Text = _PersonBusinessAccsess.Address;
                txtPhone.Text = _PersonBusinessAccsess.Phone;
                dateTimePicker1.Value = _PersonBusinessAccsess.DateOfBirth;
                if (_PersonBusinessAccsess.Gendor == 0)
                    radioButton1.Checked = true;
                else if (_PersonBusinessAccsess.Gendor == 1)
                    radioButton2.Checked = true;

                if (_PersonBusinessAccsess.ImagePath != "")
                {
                    MainPic.ImageLocation = _PersonBusinessAccsess.ImagePath;
                    lblRemove.Visible = true;

                }
                else
                    lblRemove.Visible = false;

            }
        }
        private void AddEditPersonInfo_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            MainPic.Image = Image.FromFile(@"C:\Users\karee\Downloads\Male.png");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            MainPic.Image = Image.FromFile(@"C:\Users\karee\Downloads\Female.png");

        }

        private void label10_Click(object sender, EventArgs e)


        {

            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;

                MainPic.Load(selectedFilePath);
                _PersonBusinessAccsess.ImagePath = selectedFilePath;
                


            }
        }



        private void button1_Click(object sender, EventArgs e)
        {


            //_PersonBusinessAccsess.FirstName = txtFirstName.Text;
            //_PersonBusinessAccsess.SecondName = txtSecondName.Text;
            //_PersonBusinessAccsess.ThirdName = txtThirdName.Text;
            //_PersonBusinessAccsess.LastName = txtLastName.Text;
            //_PersonBusinessAccsess.NationalNo = txtnational.Text;
            //_PersonBusinessAccsess.Email = txtEmail.Text;
            //_PersonBusinessAccsess.Address = txtAddress.Text;
            //_PersonBusinessAccsess.DateOfBirth = dateTimePicker1.Value;
            //_PersonBusinessAccsess.Phone = txtPhone.Text;
            //_PersonBusinessAccsess.NationalityCountryID = Convert.ToInt32(cbCountry.SelectedValue);



            //if (radioButton1.Checked)
            //    _PersonBusinessAccsess.Gendor = 0;
            //else
            //    _PersonBusinessAccsess.Gendor = 1;


            //if (MainPic.Image != null)
            //{
            //    _PersonBusinessAccsess.ImagePath = MainPic.ImageLocation;
            //}
            //else
            //{
            //    _PersonBusinessAccsess.ImagePath = "";
            //}

            //try
            //{
            //    if (_PersonBusinessAccsess.Save())
            //        MessageBox.Show("Saved Successfully");
            //    else
            //        MessageBox.Show("Save Failed!");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: " + ex.Message);
            //}





            //_Mode = enMode.Update;
            //lblMode.Text = "Update Person ";

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Today.AddYears(-18);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            _PersonBusinessAccsess.FirstName = txtFirstName.Text;
            _PersonBusinessAccsess.SecondName = txtSecondName.Text;
            _PersonBusinessAccsess.ThirdName = txtThirdName.Text;
            _PersonBusinessAccsess.LastName = txtLastName.Text;
            _PersonBusinessAccsess.NationalNo = txtnational.Text;
            _PersonBusinessAccsess.Email = txtEmail.Text;
            _PersonBusinessAccsess.Address = txtAddress.Text;
            _PersonBusinessAccsess.DateOfBirth = dateTimePicker1.Value;
            _PersonBusinessAccsess.Phone = txtPhone.Text;
            int NationalityCountryID = Country.Find(cbCountry.Text).CountryID;
            _PersonBusinessAccsess.NationalityCountryID = NationalityCountryID;






            if (radioButton1.Checked)
                _PersonBusinessAccsess.Gendor = 0;
            else
                _PersonBusinessAccsess.Gendor = 1;


            if (MainPic.Image != null)
            {
                _PersonBusinessAccsess.ImagePath = MainPic.ImageLocation;
            }
            else
            {
                _PersonBusinessAccsess.ImagePath = "";
            }

            try
            {
                if (_PersonBusinessAccsess.Save())
                    MessageBox.Show("Saved Successfully");
                else
                    MessageBox.Show("Save Failed!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }





            _Mode = enMode.Update;
            lblMode.Text = "Update Person ";
        }

        private void lblRemove_Click(object sender, EventArgs e)
        {
            MainPic.ImageLocation = "";
            if (_PersonBusinessAccsess.Gendor == 0)
            {
                radioButton1.Checked = true;
                MainPic.Image = Image.FromFile(@"C:\Users\karee\Downloads\Male.png");


            }
            else
            {
                radioButton2.Checked = true;
                MainPic.Image = Image.FromFile(@"C:\Users\karee\Downloads\Female.png");

            }
        }

        private void txtnational_TextChanged(object sender, EventArgs e)
        {
            if(_Mode== enMode.AddNew)
            {
                if (clsPersonBusinessAccsess.IsPersonExist(txtnational.Text))
                {
                    errorProvider1.SetError(txtnational, "National No already exists.");
                }
                if (txtnational.Text == "")
                {
                    errorProvider1.SetError(txtLastName, "First Name cannot be empty.");
                }
            }
           


        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "")
            {
                errorProvider1.SetError(txtFirstName, "First Name cannot be empty.");
            }

        }

        private void txtSecondName_TextChanged(object sender, EventArgs e)
        {
            if (txtSecondName.Text == "")
            {
                errorProvider1.SetError(txtSecondName, "First Name cannot be empty.");
            }
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if (txtLastName.Text == "")
            {
                errorProvider1.SetError(txtLastName, "First Name cannot be empty.");
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
           if(!IsValidEmail(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "please enter valid Email");
               
            }
            else if(txtEmail.Text =="")
            {
                errorProvider1.SetError(txtEmail, ""); // يمسح الخطأ لو صح
            }
           else
            {
                errorProvider1.SetError(txtEmail, ""); // يمسح الخطأ لو صح
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (txtPhone.Text == "")
            {
                errorProvider1.SetError(txtPhone, "First Name cannot be empty.");
            }
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtAddress.Text == "")
            {
                errorProvider1.SetError(txtAddress, "First Name cannot be empty.");
            }
        }
    }
}
