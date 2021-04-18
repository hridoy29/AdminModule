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
    public partial class adSupplier : Form
    {
        AD_Supplier ad_Supplier = new AD_Supplier();
        public adSupplier()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            txtboxSupplierName.Clear();
            txtboxEmail.Clear();
            txtboxBIN.Clear();
            txtboxTIN.Clear();
            txtboxNID.Clear();
            txtboxAddressLine1.Clear();
            txtboxAddressLine2.Clear();
            txtboxPhoneNumber1.Clear();
            txtboxPhoneNumber2.Clear();
            txtboxRemarks.Clear();
            rdoIsActiveYes.Checked = true;
            btnSave.Enabled = true;
            ad_Supplier.Id = 0;

        }
        public void LoadDate()
        {
            Clear();
            dataGridView.AutoGenerateColumns = false;
            using (security_modulesEntities db = new security_modulesEntities())
            {
                dataGridView.DataSource = db.AD_Supplier.ToList();
            }

        }
        private void adSupplier_Load(object sender, EventArgs e)
        {
            LoadDate();
        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView.CurrentRow.Index != -1)
                {
                    ad_Supplier.Id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
                    using (security_modulesEntities db = new security_modulesEntities())
                    {
                        ad_Supplier = db.AD_Supplier.Where(x => x.Id == ad_Supplier.Id).FirstOrDefault();

                        txtboxSupplierName.Text = ad_Supplier.SupplierName;
                        txtboxEmail.Text = ad_Supplier.Email;
                        txtboxBIN.Text = ad_Supplier.BIN;
                        txtboxTIN.Text = ad_Supplier.TIN;
                        txtboxNID.Text = ad_Supplier.NID;
                        txtboxAddressLine1.Text = ad_Supplier.AddressLine1;
                        txtboxAddressLine2.Text = ad_Supplier.AddressLine2;                     
                        txtboxPhoneNumber1.Text = ad_Supplier.PhoneNo1;
                        txtboxPhoneNumber2.Text = ad_Supplier.PhoneNo2;
                        txtboxRemarks.Text = ad_Supplier.Remarks;


                        if (ad_Supplier.VATAppliable == true)
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

                    ad_Supplier.SupplierName = txtboxSupplierName.Text.Trim();
                    ad_Supplier.Email = txtboxEmail.Text.Trim();
                    ad_Supplier.BIN = txtboxBIN.Text.Trim();
                    ad_Supplier.TIN = txtboxTIN.Text.Trim();
                    ad_Supplier.NID = txtboxNID.Text.Trim();
                    ad_Supplier.AddressLine1 = txtboxAddressLine1.Text.Trim();
                    ad_Supplier.AddressLine2 = txtboxAddressLine2.Text.Trim();
                    ad_Supplier.PhoneNo1 = txtboxPhoneNumber1.Text.Trim();
                    ad_Supplier.PhoneNo2 = txtboxPhoneNumber2.Text.Trim();
                    ad_Supplier.Remarks = txtboxRemarks.Text.Trim();
                    ad_Supplier.CreationDate = DateTime.Now;
                    ad_Supplier.CreatorId = 1;
                    ad_Supplier.ModificationDate = DateTime.Now;
                    ad_Supplier.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_Supplier.VATAppliable = true;
                    }
                    else
                    {
                        ad_Supplier.VATAppliable = false;
                    }
                    if (ad_Supplier.Id == 0)
                    {
                        db.AD_Supplier.Add(ad_Supplier);
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

                    ad_Supplier.SupplierName = txtboxSupplierName.Text.Trim();
                    ad_Supplier.Email = txtboxEmail.Text.Trim();
                    ad_Supplier.BIN = txtboxBIN.Text.Trim();
                    ad_Supplier.TIN = txtboxTIN.Text.Trim();
                    ad_Supplier.NID = txtboxNID.Text.Trim();
                    ad_Supplier.AddressLine1 = txtboxAddressLine1.Text.Trim();
                    ad_Supplier.AddressLine2 = txtboxAddressLine2.Text.Trim();
                    ad_Supplier.PhoneNo1 = txtboxPhoneNumber1.Text.Trim();
                    ad_Supplier.PhoneNo2 = txtboxPhoneNumber2.Text.Trim();
                    ad_Supplier.Remarks = txtboxRemarks.Text.Trim();
                    ad_Supplier.ModificationDate = DateTime.Now;
                    ad_Supplier.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_Supplier.VATAppliable = true;
                    }
                    else
                    {
                        ad_Supplier.VATAppliable = false;
                    }
                    if (ad_Supplier.Id > 0)
                    {
                        db.Entry(ad_Supplier).State = EntityState.Modified;
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
