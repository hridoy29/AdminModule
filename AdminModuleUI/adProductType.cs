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
    public partial class adProductType : Form
    {
        AD_ProductType ad_ProductType = new AD_ProductType();
        public adProductType()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtboxProductType.Clear();
            rdoIsActiveYes.Checked = true;
            btnSave.Enabled = true;
            ad_ProductType.Id = 0;
        }
        public void LoadDate()
        {
            Clear();
            dataGridView.AutoGenerateColumns = false;
            using (security_modulesEntities db = new security_modulesEntities())
            {
                dataGridView.DataSource = db.AD_ProductType.ToList();
            }

        }
        private void adProductType_Load(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView.CurrentRow.Index != -1)
                {
                    ad_ProductType.Id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
                    using (security_modulesEntities db = new security_modulesEntities())
                    {
                        ad_ProductType = db.AD_ProductType.Where(x => x.Id == ad_ProductType.Id).FirstOrDefault();
                        txtboxProductType.Text = ad_ProductType.ProductType;
                        if (ad_ProductType.IsActive == true)
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
                    ad_ProductType.ProductType = txtboxProductType.Text.Trim();
                    ad_ProductType.CreationDate = DateTime.Now;
                    ad_ProductType.CreatorId = 1;
                    ad_ProductType.ModificationDate = DateTime.Now;
                    ad_ProductType.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_ProductType.IsActive = true;
                    }
                    else
                    {
                        ad_ProductType.IsActive = false;
                    }
                    if (ad_ProductType.Id == 0)
                    {
                        db.AD_ProductType.Add(ad_ProductType);
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

                    ad_ProductType.ProductType = txtboxProductType.Text.Trim();
                    ad_ProductType.ModificationDate = DateTime.Now;
                    ad_ProductType.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_ProductType.IsActive = true;
                    }
                    else
                    {
                        ad_ProductType.IsActive = false;
                    }
                    if (ad_ProductType.Id > 0)
                    {
                        db.Entry(ad_ProductType).State = EntityState.Modified;
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
