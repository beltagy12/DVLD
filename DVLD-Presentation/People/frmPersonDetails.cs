using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class frmPersonDetails : Form
    {
        private int _PersonID;
        public frmPersonDetails(int personID)
        {
            InitializeComponent();
            personDetails1.LoadPersonInfo(personID);
        }
        public frmPersonDetails(string NationalNo)
        {
            InitializeComponent();
            personDetails1.LoadPersonInfo(NationalNo);
        }

        private void personDetails1_Load(object sender, EventArgs e)
        {

        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void personDetails1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
