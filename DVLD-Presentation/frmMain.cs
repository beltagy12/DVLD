using DVLD_Presentation.Applications.Application_Types;
using DVLD_Presentation.GlobalClasses;
using DVLD_Presentation.Tests.Test_Types;
using DVLD_Presentation.Users;
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
    public partial class frmMain : Form
    {
        loginfrm _frmLogin;

       
        public frmMain(loginfrm frm)
        {
            InitializeComponent();
            _frmLogin = frm;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            frmManage_People frm =new frmManage_People();
            frm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManage_People frm = new frmManage_People();
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
            this.Close();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmListUserscs frm = new frmListUserscs();
            frm.ShowDialog();
        }

        private void driverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("We Work On This Right now");

        }

        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("We Work On This Right now");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //lblLoggedInUser.Text = "LoggedIn User: " + clsGlobal.CurrentUser.UserName;
            this.Refresh();
        }

        private void accountSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void currentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm=new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListApplicationTypes frm=new frmListApplicationTypes();
            frm.ShowDialog();
            
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestTypes frm=new frmListTestTypes();
            frm.ShowDialog();
        }
    }
}
