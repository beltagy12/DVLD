using DVLD_BusinessAccsess;
using DVLD_Presentation.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class PersonDetails : UserControl
    {

        private clsPersonBusinessAccsess _Person;
        

        private int _PersonID;

        public int PersonID
        {
            //
                       get { return _PersonID; }
           //
        }
        public clsPersonBusinessAccsess SelextedPersonInfo
        {
            //
            get { return _Person; }
           //
        }
        public PersonDetails()
        {
            InitializeComponent();
        }
        public void RestorePersonInfo()
        {
            lblPersonID.Text = "???";
            lblPersonID.Text = "???";
            lblPersonID.Text = "???";
            lblPersonID.Text = "???";
            lblPersonID.Text = "???";
            lblPersonID.Text = "???";
            lblPersonID.Text = "???";
            lblPersonID.Text = "???";
            pbPersonImage.Image = null;
        }
        public void LoadImage()
        {
            if(_Person.Gendor==0)
            {
               //--------------------------------------------------------
                pbPersonImage.Image = Properties.Resources.Male; // للذكر
               //--------------------------------------------------------
            }
            else
            {
                pbPersonImage.Image = Properties.Resources.Female; // للأنثى
            }
            string imagePath = _Person.ImagePath;
            if(imagePath!=null)
            {

               if(File.Exists(imagePath))
                {

                    pbPersonImage.ImageLocation = imagePath;
                }
                
            }
        }
        public void FillPersoInfo()
        {
            llEditPersonInfo.Visible = true;
            _PersonID = _Person.PersonID;
            lblPersonID.Text = _Person.PersonID.ToString();
            lblAddress.Text = _Person.Address;
            lblFullName.Text = _Person.FullName;
            lblNationalNo.Text = _Person.NationalNo;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.Phone;
            lblGendor.Text = _Person.Gendor== 0?"Male": "FeMale";
            lblCountry.Text = Country.Find(_Person.NationalityCountryID).CountryName;
             LoadImage();
        }

          
        public void LoadPersonInfo(int personID)
        {
           _Person=clsPersonBusinessAccsess.Find(personID);
          if(_Person==null)
            {
               RestorePersonInfo();
                MessageBox.Show("Person not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          FillPersoInfo();
        }
        public void LoadPersonInfo(string NationalNo)
        {
           _Person=clsPersonBusinessAccsess.Find(NationalNo);
            if (_Person == null)
            {
                // RestorePersonInfo();
                MessageBox.Show("Person not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FillPersoInfo();
        }
        private void label10_Click(object sender, EventArgs e)
        {
            AddEditPersonInfo frm = new AddEditPersonInfo(_PersonID);
            frm.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddEditPersonInfo frm = new AddEditPersonInfo(_PersonID);
            frm.ShowDialog();
            LoadPersonInfo(_PersonID);
        }

        private void picPersonDetails_Click(object sender, EventArgs e)
        {

        }

        private void PersonDetails_Load(object sender, EventArgs e)
        {
            if (_PersonID > 0)
                LoadPersonInfo(_PersonID);
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddEditPersonInfo frm = new AddEditPersonInfo(_PersonID);
            frm.ShowDialog();
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }
    }
}
