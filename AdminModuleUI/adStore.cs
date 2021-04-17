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
    public partial class adStore : Form
    {
        AD_Store ad_Store = new AD_Store();
        public adStore()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtboxStorelName.Clear();
            txtboxLocation.Clear();
            rdoIsActiveYes.Checked = true;
            btnSave.Enabled = true;
            ad_Store.Id = 0;

        }
        public void LoadDate()
        {
            Clear();
            dataGridView.AutoGenerateColumns = false;
            using (security_modulesEntities db = new security_modulesEntities())
            {
                dataGridView.DataSource = db.AD_Store.ToList();
            }

        }
        private void adStore_Load(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView.CurrentRow.Index != -1)
                {
                    ad_Store.Id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
                    using (security_modulesEntities db = new security_modulesEntities())
                    {
                        ad_Store = db.AD_Store.Where(x => x.Id == ad_Store.Id).FirstOrDefault();
                        txtboxLocation.Text = ad_Store.Location;
                        txtboxStorelName.Text = ad_Store.StoreName;

                        if (ad_Store.IsActive == true)
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
                    ad_Store.Location = txtboxLocation.Text.Trim();
                    ad_Store.StoreName = txtboxStorelName.Text.Trim();
                    ad_Store.CreationDate = DateTime.Now;
                    ad_Store.CreatorId = 1;
                    ad_Store.ModificationDate = DateTime.Now;
                    ad_Store.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_Store.IsActive = true;
                    }
                    else
                    {
                        ad_Store.IsActive = false;
                    }
                    if (ad_Store.Id == 0)
                    {
                        db.AD_Store.Add(ad_Store);
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

                    ad_Store.Location = txtboxLocation.Text.Trim();
                    ad_Store.StoreName = txtboxStorelName.Text.Trim();
                    ad_Store.ModificationDate = DateTime.Now;
                    ad_Store.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_Store.IsActive = true;
                    }
                    else
                    {
                        ad_Store.IsActive = false;
                    }
                    if (ad_Store.Id > 0)
                    {
                        db.Entry(ad_Store).State = EntityState.Modified;
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
