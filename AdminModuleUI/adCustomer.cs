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
    public partial class adCustomer : Form
    {
        AD_Customer ad_Customer = new AD_Customer();
        public adCustomer()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtboxCustomerName.Clear();
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
            ad_Customer.Id = 0;

        }
        public void LoadDate()
        {
            Clear();
            dataGridView.AutoGenerateColumns = false;
            using (security_modulesEntities db = new security_modulesEntities())
            {
                dataGridView.DataSource = db.AD_Customer.ToList();
            }

        }
        private void adCustomer_Load(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView.CurrentRow.Index != -1)
                {
                    ad_Customer.Id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
                    using (security_modulesEntities db = new security_modulesEntities())
                    {
                        ad_Customer = db.AD_Customer.Where(x => x.Id == ad_Customer.Id).FirstOrDefault();

                        txtboxCustomerName.Text = ad_Customer.CustomerName;
                        txtboxEmail.Text = ad_Customer.Email;
                        txtboxBIN.Text = ad_Customer.BIN;
                        txtboxTIN.Text = ad_Customer.TIN;
                        txtboxNID.Text = ad_Customer.NID;
                        txtboxAddressLine1.Text = ad_Customer.AddressLine1;
                        txtboxAddressLine2.Text = ad_Customer.AddressLine2;
                        txtboxPhoneNumber1.Text = ad_Customer.PhoneNo1;
                        txtboxPhoneNumber2.Text = ad_Customer.PhoneNo2;
                        txtboxRemarks.Text = ad_Customer.Remarks;


                        if (ad_Customer.VATAppliable == true)
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

                    ad_Customer.CustomerName = txtboxCustomerName.Text.Trim();
                    ad_Customer.Email = txtboxEmail.Text.Trim();
                    ad_Customer.BIN = txtboxBIN.Text.Trim();
                    ad_Customer.TIN = txtboxTIN.Text.Trim();
                    ad_Customer.NID = txtboxNID.Text.Trim();
                    ad_Customer.AddressLine1 = txtboxAddressLine1.Text.Trim();
                    ad_Customer.AddressLine2 = txtboxAddressLine2.Text.Trim();
                    ad_Customer.PhoneNo1 = txtboxPhoneNumber1.Text.Trim();
                    ad_Customer.PhoneNo2 = txtboxPhoneNumber2.Text.Trim();
                    ad_Customer.Remarks = txtboxRemarks.Text.Trim();
                    ad_Customer.CreationDate = DateTime.Now;
                    ad_Customer.CreatorId = 1;
                    ad_Customer.ModificationDate = DateTime.Now;
                    ad_Customer.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_Customer.VATAppliable = true;
                    }
                    else
                    {
                        ad_Customer.VATAppliable = false;
                    }
                    if (ad_Customer.Id == 0)
                    {
                        db.AD_Customer.Add(ad_Customer);
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

                    ad_Customer.CustomerName = txtboxCustomerName.Text.Trim();
                    ad_Customer.Email = txtboxEmail.Text.Trim();
                    ad_Customer.BIN = txtboxBIN.Text.Trim();
                    ad_Customer.TIN = txtboxTIN.Text.Trim();
                    ad_Customer.NID = txtboxNID.Text.Trim();
                    ad_Customer.AddressLine1 = txtboxAddressLine1.Text.Trim();
                    ad_Customer.AddressLine2 = txtboxAddressLine2.Text.Trim();
                    ad_Customer.PhoneNo1 = txtboxPhoneNumber1.Text.Trim();
                    ad_Customer.PhoneNo2 = txtboxPhoneNumber2.Text.Trim();
                    ad_Customer.Remarks = txtboxRemarks.Text.Trim();
                    ad_Customer.ModificationDate = DateTime.Now;
                    ad_Customer.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_Customer.VATAppliable = true;
                    }
                    else
                    {
                        ad_Customer.VATAppliable = false;
                    }
                    if (ad_Customer.Id > 0)
                    {
                        db.Entry(ad_Customer).State = EntityState.Modified;
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
