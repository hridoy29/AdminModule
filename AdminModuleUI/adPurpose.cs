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
    public partial class adPurpose : Form
    {
        AD_Purpose ad_Purpose = new AD_Purpose();
        public adPurpose()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtboxPurpose.Clear();
            rdoIsActiveYes.Checked = true;
            btnSave.Enabled = true;
            ad_Purpose.Id = 0;
        }
        public void LoadDate()
        {
            Clear();
            dataGridView.AutoGenerateColumns = false;
            using (security_modulesEntities db = new security_modulesEntities())
            {
                dataGridView.DataSource = db.AD_Purpose.ToList();
            }

        }
        private void adPurpose_Load(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView.CurrentRow.Index != -1)
                {
                    ad_Purpose.Id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
                    using (security_modulesEntities db = new security_modulesEntities())
                    {
                        ad_Purpose = db.AD_Purpose.Where(x => x.Id == ad_Purpose.Id).FirstOrDefault();
                        txtboxPurpose.Text = ad_Purpose.Purpose;
                        if (ad_Purpose.IsActive == true)
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
                    ad_Purpose.Purpose = txtboxPurpose.Text.Trim();
                    ad_Purpose.CreationDate = DateTime.Now;
                    ad_Purpose.CreatorId = 1;
                    ad_Purpose.ModificationDate = DateTime.Now;
                    ad_Purpose.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_Purpose.IsActive = true;
                    }
                    else
                    {
                        ad_Purpose.IsActive = false;
                    }
                    if (ad_Purpose.Id == 0)
                    {
                        db.AD_Purpose.Add(ad_Purpose);
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

                    ad_Purpose.Purpose = txtboxPurpose.Text.Trim();
                    ad_Purpose.ModificationDate = DateTime.Now;
                    ad_Purpose.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_Purpose.IsActive = true;
                    }
                    else
                    {
                        ad_Purpose.IsActive = false;
                    }
                    if (ad_Purpose.Id > 0)
                    {
                        db.Entry(ad_Purpose).State = EntityState.Modified;
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
