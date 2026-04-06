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
            if((txtusername.Text== "Msaqer77") && (txtPassword.Text == "1234")) 
            {
                if (checkBox1.Checked)
                {

                    txtusername.Tag = txtusername.Text;
                    txtPassword.Tag = txtPassword.Text;
                }
                Form1 frm=new Form1();
                frm.ShowDialog();
               
            }
            else if ((txtusername.Text == "user4") && (txtPassword.Text == "1234"))
            {
                if (checkBox1.Checked)
                {

                    txtusername.Tag = txtusername.Text;
                    txtPassword.Tag = txtPassword.Text;
                }
                Form1 frm = new Form1();
                frm.ShowDialog();
            }
            else
            {
                txtusername.Tag = "";
                txtPassword.Tag = "";
                MessageBox.Show("Invalid Username or Password");
            }

           

        }
        //private bool ischecked()
        //{
        //    bool ischecked = false;
        //    if (checkBox1.Checked)
        //    {
        //        ischecked = true;
        //        txtusername.Tag=txtusername.Text;
        //        txtPassword.Tag= txtPassword.Text;
        //    }
        //    else
        //    {
        //        ischecked = false;
        //    }
        //    return ischecked;
        //}

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           


        }
    }
}
