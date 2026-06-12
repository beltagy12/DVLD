using DVLD_BusinessAccsess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.Users
{
    public partial class ctrlUserCard : UserControl
    {
        clsUser _User;
        private int _UserID = -1;

        public ctrlUserCard()
        {
            InitializeComponent();
        }
        public void LoadUserInfo(int UserID)
        {
            _User = clsUser.FindUserByID(UserID);

            if(_User==null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
        }

        private void _FillUserInfo()
        {
            personDetails1.LoadPersonInfo(_User.PersonID);
           lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName.ToString();

            if (_User.IsActive)
                lblIsActive.Text = "YES";
            else
                lblIsActive.Text = "NO";
        }


        private void _ResetPersonInfo()
        {

            personDetails1.RestorePersonInfo();
            lblUserID.Text = "[???]";
            lblUserName.Text = "[???]";
            lblIsActive.Text = "[???]";
        }
        private void ctrlUserCard_Load(object sender, EventArgs e)
        {

        }

        private void personDetails1_Load(object sender, EventArgs e)
        {

        }
    }
}
