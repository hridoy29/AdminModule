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
    public partial class adProductGroup : Form
    {
        AD_ProductGroup ad_ProductGroup = new AD_ProductGroup();
        public adProductGroup()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtboxProductGroup.Clear();
            rdoIsActiveYes.Checked = true;
            btnSave.Enabled = true;
            ad_ProductGroup.Id = 0;
            try
            {
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    cmbValuationType.DataSource = db.AD_ValuationType.ToList();
                    cmbValuationType.DisplayMember = "ValuationType";
                    cmbValuationType.ValueMember = "Id";

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void LoadDate()
        {
            Clear();
            dataGridView.AutoGenerateColumns = false;
            using (security_modulesEntities db = new security_modulesEntities())
            {
                var data = (from CP in db.AD_ProductGroup
                            join BN in db.AD_ValuationType
                            on CP.ValuationTypeId equals BN.Id
                            select new
                            {
                                Id = CP.Id,
                                ProductGroup = CP.ProductGroup,
                                ValuationType = BN.ValuationType,
                                ValuationTypeId=CP.ValuationTypeId,
                                IsActive = CP.IsActive
                            }).ToList();
                dataGridView.DataSource = data;
                //dataGridView.DataSource = db.AD_ProductGroup.ToList();
            }

        }

        private void adProductGroup_Load(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView.CurrentRow.Index != -1)
                {
                    ad_ProductGroup.Id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
                    using (security_modulesEntities db = new security_modulesEntities())
                    {
                        ad_ProductGroup = db.AD_ProductGroup.Where(x => x.Id == ad_ProductGroup.Id).FirstOrDefault();
                        txtboxProductGroup.Text = ad_ProductGroup.ProductGroup;
                        if (ad_ProductGroup.IsActive == true)
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
                    ad_ProductGroup.ProductGroup = txtboxProductGroup.Text.Trim();
                    ad_ProductGroup.ValuationTypeId = (int)cmbValuationType.SelectedValue;
                    ad_ProductGroup.CreationDate = DateTime.Now;
                    ad_ProductGroup.CreatorId = 1;
                    ad_ProductGroup.ModificationDate = DateTime.Now;
                    ad_ProductGroup.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_ProductGroup.IsActive = true;
                    }
                    else
                    {
                        ad_ProductGroup.IsActive = false;
                    }
                    if (ad_ProductGroup.Id == 0)
                    {
                        db.AD_ProductGroup.Add(ad_ProductGroup);
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

                    ad_ProductGroup.ProductGroup = txtboxProductGroup.Text.Trim();
                    ad_ProductGroup.ValuationTypeId = (int)cmbValuationType.SelectedValue;
                    ad_ProductGroup.ModificationDate = DateTime.Now;
                    ad_ProductGroup.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_ProductGroup.IsActive = true;
                    }
                    else
                    {
                        ad_ProductGroup.IsActive = false;
                    }
                    if (ad_ProductGroup.Id > 0)
                    {
                        db.Entry(ad_ProductGroup).State = EntityState.Modified;
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
