using DVLD_BusinessAccsess;
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
                       get { return _PersonID; }
           
        }
        public clsPersonBusinessAccsess Person
        {
            get { return _Person; }
          
        }
        public PersonDetails()
        {
            InitializeComponent();
        }
        public void RestorePersonInfo()
        {
            lblID.Text = "???";
            lblID.Text = "???";
            lblID.Text = "???";
            lblID.Text = "???";
            lblID.Text = "???";
            lblID.Text = "???";
            lblID.Text = "???";
            lblID.Text = "???";
            picPersonDetails.Image = null;
        }
        public void LoadImage()
        {
            if(_Person.Gendor==0)
            {
                picPersonDetails.Image = Properties.Resources.Male; // للذكر
            }
            else
            {
                picPersonDetails.Image = Properties.Resources.Female; // للأنثى
            }
            string imagePath = _Person.ImagePath;
            if(imagePath!=null)
            {
               if(File.Exists(imagePath))
                {
                    picPersonDetails.ImageLocation = imagePath;
                }
                else
                {
                    MessageBox.Show("Image file not found. Using default image.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        public void FillPersoInfo()
        {
            LLEditPersonInfo.Visible = true;
            _PersonID = _Person.PersonID;
            lblID.Text = _Person.PersonID.ToString();
            lblAddress.Text = _Person.Address;
            lblName.Text = _Person.FullName;
            label17.Text = _Person.NationalNo;
            lblDate.Text = _Person.DateOfBirth.ToShortDateString();
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
            //FillPersoInfo();
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
    }
}
