using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminModuleEntitiy.Model;

namespace AdminModuleUI
{
    public partial class adReason : Form
    {
        AD_Reason ad_Reason = new AD_Reason();

        public adReason()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtboxReason.Clear();
            rdoIsActiveYes.Checked = true;
            btnSave.Enabled = true;
            ad_Reason.Id = 0;
        }
        public void LoadDate()
        {
            Clear();
            dataGridView.AutoGenerateColumns = false;
            using (security_modulesEntities db = new security_modulesEntities())
            {
                dataGridView.DataSource = db.AD_Reason.ToList();
            }

        }
        private void adReason_Load(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView.CurrentRow.Index != -1)
                {
                    ad_Reason.Id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
                    using (security_modulesEntities db = new security_modulesEntities())
                    {
                        ad_Reason = db.AD_Reason.Where(x => x.Id == ad_Reason.Id).FirstOrDefault();
                        txtboxReason.Text = ad_Reason.Reason;
                        if (ad_Reason.IsActive == true)
                        {
                            rdoIsActiveYes.Checked = true;
                        }
                        else
                        {

                            rdoIsActiveNo.Checked = true;
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            btnSave.Enabled = false;


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    ad_Reason.Reason = txtboxReason.Text.Trim();
                    ad_Reason.CreationDate = DateTime.Now;
                    ad_Reason.CreatorId = 1;
                    ad_Reason.ModificationDate = DateTime.Now;
                    ad_Reason.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_Reason.IsActive = true;
                    }
                    else
                    {
                        ad_Reason.IsActive = false;
                    }
                    if (ad_Reason.Id == 0)
                    {
                        db.AD_Reason.Add(ad_Reason);
                        db.SaveChanges();
                    }
                    LoadDate();
                    MessageBox.Show("Data Save Successfuly");
                    Clear();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            try
            {
                using (security_modulesEntities db = new security_modulesEntities())
                {

                    ad_Reason.Reason = txtboxReason.Text.Trim();
                    ad_Reason.ModificationDate = DateTime.Now;
                    ad_Reason.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_Reason.IsActive = true;
                    }
                    else
                    {
                        ad_Reason.IsActive = false;
                    }
                    if (ad_Reason.Id > 0)
                    {
                        db.Entry(ad_Reason).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                LoadDate();
                MessageBox.Show("Data Updated Successfuly");
                Clear();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            Clear();
        }
    }
}
