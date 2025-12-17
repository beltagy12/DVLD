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
    public partial class MyUserControlPersonDetails : UserControl
    {
        private int _personID;

        public MyUserControlPersonDetails(int personID)
        {
            InitializeComponent();
            _personID = personID;
        }

        private void label10_Click(object sender, EventArgs e)
        {

            AddEditPersonInfo frm = new AddEditPersonInfo(_personID);
            frm.ShowDialog();
        }

        private void picPersonDetails_Click(object sender, EventArgs e)
        {

        }
    }
}
