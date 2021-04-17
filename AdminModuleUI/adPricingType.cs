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
    public partial class adPricingType : Form
    {
        AD_PricingType ad_PricingType = new AD_PricingType();
        public adPricingType()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtboxPricingType.Clear();
            rdoIsActiveYes.Checked = true;
            btnSave.Enabled = true;
            ad_PricingType.Id = 0;
        }
        public void LoadDate()
        {
            Clear();
            dataGridView.AutoGenerateColumns = false;
            using (security_modulesEntities db = new security_modulesEntities())
            {
                dataGridView.DataSource = db.AD_PricingType.ToList();
            }

        }
        private void adPricingType_Load(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void adBusinessNature_Load(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView.CurrentRow.Index != -1)
                {
                    ad_PricingType.Id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
                    using (security_modulesEntities db = new security_modulesEntities())
                    {
                        ad_PricingType = db.AD_PricingType.Where(x => x.Id == ad_PricingType.Id).FirstOrDefault();
                        txtboxPricingType.Text = ad_PricingType.PricingType;
                        if (ad_PricingType.IsActive == true)
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
                    ad_PricingType.PricingType = txtboxPricingType.Text.Trim();
                    ad_PricingType.CreationDate = DateTime.Now;
                    ad_PricingType.CreatorId = 1;
                    ad_PricingType.ModificationDate = DateTime.Now;
                    ad_PricingType.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_PricingType.IsActive = true;
                    }
                    else
                    {
                        ad_PricingType.IsActive = false;
                    }
                    if (ad_PricingType.Id == 0)
                    {
                        db.AD_PricingType.Add(ad_PricingType);
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

                    ad_PricingType.PricingType = txtboxPricingType.Text.Trim();
                    ad_PricingType.ModificationDate = DateTime.Now;
                    ad_PricingType.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_PricingType.IsActive = true;
                    }
                    else
                    {
                        ad_PricingType.IsActive = false;
                    }
                    if (ad_PricingType.Id > 0)
                    {
                        db.Entry(ad_PricingType).State = EntityState.Modified;
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
