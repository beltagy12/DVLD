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
    public partial class frmListApplicationTypes : Form
    {
        private DataTable _dtAllApplicationTypes;

        public frmListApplicationTypes()
        {
            InitializeComponent();
        }

        private void frmListApplicationTypes_Load(object sender, EventArgs e)
        {
         _dtAllApplicationTypes = clsApplicationType.GetAllApplicationTypes();
            dataGridView2.DataSource = _dtAllApplicationTypes;
            lblRecord.Text = dataGridView2.Rows.Count.ToString();


            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[0].Width = 110;

            dataGridView2.Columns[1].HeaderText = "Title";
            dataGridView2.Columns[1].Width = 350;
            
            dataGridView2.Columns[2].HeaderText = "Fees";
            dataGridView2.Columns[2].Width = 130;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationTypes frm = new frmEditApplicationTypes((int)dataGridView2.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
