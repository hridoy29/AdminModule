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
    public partial class adStoreItemStatusDeclaration : Form
    {
        AD_StoreItemStatusDeclaration ad_StoreItemStatusDeclaration = new AD_StoreItemStatusDeclaration();
        public adStoreItemStatusDeclaration()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtboxDeclarationType.Clear();
            rdoIsActiveYes.Checked = true;
            btnSave.Enabled = true;
            ad_StoreItemStatusDeclaration.Id = 0;
        }
        public void LoadDate()
        {
            Clear();
            dataGridView.AutoGenerateColumns = false;
            using (security_modulesEntities db = new security_modulesEntities())
            {
                dataGridView.DataSource = db.AD_StoreItemStatusDeclaration.ToList();
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    ad_StoreItemStatusDeclaration.DeclarationType = txtboxDeclarationType.Text.Trim();
                    ad_StoreItemStatusDeclaration.CreationDate = DateTime.Now;
                    ad_StoreItemStatusDeclaration.CreatorId = 1;
                    ad_StoreItemStatusDeclaration.ModificationDate = DateTime.Now;
                    ad_StoreItemStatusDeclaration.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_StoreItemStatusDeclaration.IsActive = true;
                    }
                    else
                    {
                        ad_StoreItemStatusDeclaration.IsActive = false;
                    }
                    if (ad_StoreItemStatusDeclaration.Id == 0)
                    {
                        db.AD_StoreItemStatusDeclaration.Add(ad_StoreItemStatusDeclaration);
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

        private void adStoreItemStatusDeclaration_Load(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView.CurrentRow.Index != -1)
                {
                    ad_StoreItemStatusDeclaration.Id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
                    using (security_modulesEntities db = new security_modulesEntities())
                    {
                        ad_StoreItemStatusDeclaration = db.AD_StoreItemStatusDeclaration.Where(x => x.Id == ad_StoreItemStatusDeclaration.Id).FirstOrDefault();
                        txtboxDeclarationType.Text = ad_StoreItemStatusDeclaration.DeclarationType;
                        if (ad_StoreItemStatusDeclaration.IsActive == true)
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            try
            {
                using (security_modulesEntities db = new security_modulesEntities())
                {

                    ad_StoreItemStatusDeclaration.DeclarationType = txtboxDeclarationType.Text.Trim();
                    ad_StoreItemStatusDeclaration.ModificationDate = DateTime.Now;
                    ad_StoreItemStatusDeclaration.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_StoreItemStatusDeclaration.IsActive = true;
                    }
                    else
                    {
                        ad_StoreItemStatusDeclaration.IsActive = false;
                    }
                    if (ad_StoreItemStatusDeclaration.Id > 0)
                    {
                        db.Entry(ad_StoreItemStatusDeclaration).State = EntityState.Modified;
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
