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
    public partial class adSalesOutlet : Form
    {
        AD_SalesOutlet ad_SalesOutlet = new AD_SalesOutlet();
        public adSalesOutlet()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtboxOutletName.Clear();
            txtboxAddressLine1.Clear();
            txtboxAddressLine2.Clear();
            txtboxPhoneNumber1.Clear();
            txtboxPhoneNumber2.Clear();
            rdoIsActiveYes.Checked = true;
            btnSave.Enabled = true;
            ad_SalesOutlet.Id = 0;

        }
        public void LoadDate()
        {
            Clear();
            dataGridView.AutoGenerateColumns = false;
            using (security_modulesEntities db = new security_modulesEntities())
            {
                dataGridView.DataSource = db.AD_SalesOutlet.ToList();
            }

        }
        private void adSalesOutlet_Load(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView.CurrentRow.Index != -1)
                {
                    ad_SalesOutlet.Id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
                    using (security_modulesEntities db = new security_modulesEntities())
                    {
                        ad_SalesOutlet = db.AD_SalesOutlet.Where(x => x.Id == ad_SalesOutlet.Id).FirstOrDefault();
                        
                        txtboxOutletName.Text = ad_SalesOutlet.OutletName;
                        txtboxAddressLine1.Text = ad_SalesOutlet.AddressLine1;
                        txtboxAddressLine2.Text = ad_SalesOutlet.AddressLine2;
                        txtboxPhoneNumber1.Text = ad_SalesOutlet.PhoneNumber1;
                        txtboxPhoneNumber2.Text = ad_SalesOutlet.PhoneNumber2;
                        

                        if (ad_SalesOutlet.IsActive == true)
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
                    
                    ad_SalesOutlet.OutletName = txtboxOutletName.Text.Trim();
                    ad_SalesOutlet.AddressLine1 = txtboxAddressLine1.Text.Trim();
                    ad_SalesOutlet.AddressLine2 = txtboxAddressLine2.Text.Trim();
                    ad_SalesOutlet.PhoneNumber1 = txtboxPhoneNumber1.Text.Trim();
                    ad_SalesOutlet.PhoneNumber2 = txtboxPhoneNumber2.Text.Trim();
                     
                    ad_SalesOutlet.CreationDate = DateTime.Now;
                    ad_SalesOutlet.CreatorId = 1;
                    ad_SalesOutlet.ModificationDate = DateTime.Now;
                    ad_SalesOutlet.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_SalesOutlet.IsActive = true;
                    }
                    else
                    {
                        ad_SalesOutlet.IsActive = false;
                    }
                    if (ad_SalesOutlet.Id == 0)
                    {
                        db.AD_SalesOutlet.Add(ad_SalesOutlet);
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

                    ad_SalesOutlet.OutletName = txtboxOutletName.Text.Trim();
                    ad_SalesOutlet.AddressLine1 = txtboxAddressLine1.Text.Trim();
                    ad_SalesOutlet.AddressLine2 = txtboxAddressLine2.Text.Trim();
                    ad_SalesOutlet.PhoneNumber1 = txtboxPhoneNumber1.Text.Trim();
                    ad_SalesOutlet.PhoneNumber2 = txtboxPhoneNumber2.Text.Trim();
                    ad_SalesOutlet.ModificationDate = DateTime.Now;
                    ad_SalesOutlet.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_SalesOutlet.IsActive = true;
                    }
                    else
                    {
                        ad_SalesOutlet.IsActive = false;
                    }
                    if (ad_SalesOutlet.Id > 0)
                    {
                        db.Entry(ad_SalesOutlet).State = EntityState.Modified;
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