using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.Applications.Application_Types
{
    public partial class frmEditApplicationTypes : Form
    {
        private int _ApplicationTypeID = -1;

        private clsApplicationType _ApplicationType;


        public frmEditApplicationTypes(int typeID)
        {
            InitializeComponent();
            _ApplicationTypeID = typeID;
        }

        private void frmEditApplicationTypes_Load(object sender, EventArgs e)
        {
            lblApplicationTypeID.Text = _ApplicationTypeID.ToString();
            _ApplicationType = clsApplicationType.Find(_ApplicationTypeID);


            if (_ApplicationType != null)
            {
                txtTitle.Text = _ApplicationType.Title;
                txtFees.Text=_ApplicationType.Fees.ToString();
            }

        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            }
            ;
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtFees.Text.Trim()))
            {

                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Fees cannot be empty!");
            }
            else
            {
                errorProvider1.SetError (txtFees, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("مانت نسيها يا علق");
        }
    }
}
