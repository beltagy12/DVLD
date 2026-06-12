using DVLD_BusinessAccsess;
using DVLD_Presentation.GlobalClasses;
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
    public partial class loginfrm : Form
    {
        bool isChecked = false;

        public loginfrm()
        {
            InitializeComponent();
           
             
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            

        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           


        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginfrm_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";
            clsGlobal.GetStoredCredential(ref UserName, ref Password);

            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtusername.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser User = clsUser.FindByUserNameAndPassword(txtusername.Text.Trim(), txtPassword.Text.Trim());
            if (User != null)
            {
                if (chkRememberMe.Checked)
                {
                    clsGlobal.RememberUsernameAndPassword(txtusername.Text.Trim(), txtPassword.Text.Trim());
                }

                else
                    clsGlobal.RememberUsernameAndPassword("", "");

                if (!User.IsActive)
                {

                    txtusername.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                clsGlobal.CurrentUser = User;
                this.Hide();
                frmMain frm = new frmMain(this);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid User Name Or Password");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
             
        }
    }
}
