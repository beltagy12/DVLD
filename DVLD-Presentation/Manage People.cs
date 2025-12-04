using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessAccsess;

namespace DVLD_Presentation
{
    public partial class frmManage_People : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        private void _FillPersonCoulmnInCompoBox()
        {
            DataTable dataTable = new DataTable();
            dataTable = clsPersonBusinessAccsess.GetAllPerson();
            cbfilter.Items.Add("None");
            cbfilter.SelectedIndex = 0;

            foreach (DataColumn Column in dataTable.Columns)
            {
                cbfilter.Items.Add(Column.ColumnName );
            }
          

        }
        private void _RefreachPersonsList()
        {
            dgvAllPeople.DataSource = clsPersonBusinessAccsess.GetAllPerson();
        }
     
        public frmManage_People()
        {
            InitializeComponent();
        }

        private void _Filter()
        {
            string col = cbfilter.SelectedItem.ToString();
            string val = txtValue.Text;
            DataTable dt = clsPersonBusinessAccsess.Filter(col,val);

          
            dgvAllPeople.DataSource = dt;
        }

        private void frmManage_People_Load(object sender, EventArgs e)
        {

            _RefreachPersonsList();
            

            _FillPersonCoulmnInCompoBox();
            lblSizedgv.Text=dgvAllPeople.RowCount .ToString();

        }

        private void dgvAllPeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            _Filter();
        }

        private void cbfilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbfilter.SelectedItem != null && cbfilter.SelectedItem.ToString() == "None")
            {
                txtValue.Visible = false;
            }
            else
            {
                txtValue.Visible = true;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AddEditPersonInfo frm = new AddEditPersonInfo(-1);

            frm.ShowDialog();
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditPersonInfo frm = new AddEditPersonInfo(-1);

            frm.ShowDialog();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddEditPersonInfo frm=new AddEditPersonInfo((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete person [" +
              dgvAllPeople.CurrentRow.Cells[0].Value + "]", "Confirm Delete",
              MessageBoxButtons.OKCancel) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsPersonBusinessAccsess.DeletePerson((int)dgvAllPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Contact Deleted Successfully.");
                    _RefreachPersonsList();
                }

                else
                    MessageBox.Show("Contact is not deleted.");

            }

        }
    }
}
