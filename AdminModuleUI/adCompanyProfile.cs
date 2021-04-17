using AdminModuleEntitiy.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminModuleUI
{
    public partial class adCompanyProfile : Form
    {
        AD_CompanyProfile ad_CompanyProfile = new AD_CompanyProfile();
        public adCompanyProfile()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtboxAddressLine1.Clear();
            txtboxAddressLine2.Clear();
            txtboxBIN.Clear();
            txtboxCompanyName.Clear();
            txtboxContactPersion.Clear();
            txtboxIncorporationNumber.Clear();
            txtboxPhone.Clear();
            txtboxRemarks.Clear();
            txtboxTIN.Clear();
            btnSave.Enabled = true;
            ad_CompanyProfile.Id = 0;
        }
        public void LoadDate()
        {
            Clear();
            dataGridView.AutoGenerateColumns = false;
            using (security_modulesEntities db = new security_modulesEntities())
            {
                try
                {
                    var data = (from CP in db.AD_CompanyProfile
                                join BN in db.AD_BusinessNature
                                on CP.BusinessNatureId equals BN.Id
                                join BT in db.AD_BusinessType
                                on CP.BusinessTypeId equals BT.Id
                                select new
                                {
                                    Id = CP.Id,
                                    CompanyName = CP.CompanyName,
                                    BusinessTypeId = CP.BusinessTypeId,
                                    BusinessNatureId = CP.BusinessNatureId,
                                    BIN = CP.BIN,
                                    TIN = CP.TIN,
                                    AddressLine1 = CP.AddressLine1,
                                    AddressLine2 = CP.AddressLine2,
                                    Phone = CP.Phone,
                                    ContactPersion = CP.ContactPersion,
                                    IncorporationNumber = CP.IncorporationNumber,
                                    Remarks = CP.Remarks,
                                    BusinessType = BT.BusinessType,
                                    BusinessNature = BN.BusinessNature
                                }).ToList();
                    dataGridView.DataSource = data;
                    // var _Test = db.AD_CompanyProfile.Include(x => x.AD_BusinessNature).ToList();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            try
            {
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    cmbBusinessNatureId.DataSource = db.AD_BusinessNature.ToList();
                    cmbBusinessNatureId.DisplayMember = "BusinessNature";
                    cmbBusinessNatureId.ValueMember = "Id";
                     
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            try
            {
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    cmbBusinessTypeId.DataSource = db.AD_BusinessType.ToList();
                    cmbBusinessTypeId.DisplayMember = "BusinessType";
                    cmbBusinessTypeId.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void adCompanyProfile_Load(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // var rer =  Convert.ToInt32(cmbBusinessNatureId.Text.Substring(cmbBusinessNatureId.Text.IndexOf("(")+1, 1).Trim());
            try
            {
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    ad_CompanyProfile.AddressLine1 = txtboxAddressLine1.Text.Trim();
                    ad_CompanyProfile.AddressLine2 = txtboxAddressLine2.Text.Trim();
                    ad_CompanyProfile.BIN = txtboxBIN.Text.Trim();
                    ad_CompanyProfile.TIN = txtboxBIN.Text.Trim();
                    ad_CompanyProfile.CompanyName = txtboxCompanyName.Text.Trim();
                    ad_CompanyProfile.ContactPersion = txtboxContactPersion.Text.Trim();
                    ad_CompanyProfile.IncorporationNumber = txtboxIncorporationNumber.Text.Trim();
                    ad_CompanyProfile.Phone = txtboxPhone.Text.Trim();
                    ad_CompanyProfile.Remarks = txtboxRemarks.Text.Trim();
                    ad_CompanyProfile.BusinessNatureId = (int)cmbBusinessNatureId.SelectedValue;
                    ad_CompanyProfile.BusinessTypeId = (int)cmbBusinessTypeId.SelectedValue; 
                    ad_CompanyProfile.CreationDate = DateTime.Now;
                    ad_CompanyProfile.CreatorId = 1;
                    ad_CompanyProfile.ModificationDate = DateTime.Now;
                    ad_CompanyProfile.ModifierId = 1;

                    if (ad_CompanyProfile.Id == 0)
                    {
                        db.AD_CompanyProfile.Add(ad_CompanyProfile);
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
            try
            {
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    ad_CompanyProfile.AddressLine1 = txtboxAddressLine1.Text.Trim();
                    ad_CompanyProfile.AddressLine2 = txtboxAddressLine2.Text.Trim();
                    ad_CompanyProfile.BIN = txtboxBIN.Text.Trim();
                    ad_CompanyProfile.TIN = txtboxBIN.Text.Trim();
                    ad_CompanyProfile.CompanyName = txtboxCompanyName.Text.Trim();
                    ad_CompanyProfile.ContactPersion = txtboxContactPersion.Text.Trim();
                    ad_CompanyProfile.IncorporationNumber = txtboxIncorporationNumber.Text.Trim();
                    ad_CompanyProfile.Phone = txtboxPhone.Text.Trim();
                    ad_CompanyProfile.Remarks = txtboxRemarks.Text.Trim();
                    ad_CompanyProfile.BusinessNatureId = (int)cmbBusinessNatureId.SelectedValue;
                    ad_CompanyProfile.BusinessTypeId = (int)cmbBusinessTypeId.SelectedValue; 
                    ad_CompanyProfile.ModificationDate = DateTime.Now;
                    ad_CompanyProfile.ModifierId = 1;
                    if (ad_CompanyProfile.Id > 0)
                    {
                        db.Entry(ad_CompanyProfile).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                    LoadDate();
                    MessageBox.Show("Data Updated Successfuly");
                    Clear();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.CurrentRow.Index != -1)
            {
                ad_CompanyProfile.Id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    ad_CompanyProfile = db.AD_CompanyProfile.Where(x => x.Id == ad_CompanyProfile.Id).FirstOrDefault();

                    txtboxAddressLine1.Text = ad_CompanyProfile.AddressLine1;
                    txtboxAddressLine2.Text = ad_CompanyProfile.AddressLine2;
                    txtboxBIN.Text = ad_CompanyProfile.BIN;
                    txtboxTIN.Text = ad_CompanyProfile.TIN;
                    txtboxCompanyName.Text = ad_CompanyProfile.CompanyName;
                    txtboxContactPersion.Text = ad_CompanyProfile.ContactPersion;
                    txtboxIncorporationNumber.Text = ad_CompanyProfile.IncorporationNumber;
                    txtboxPhone.Text = ad_CompanyProfile.Phone;
                    txtboxRemarks.Text = ad_CompanyProfile.Remarks;
                     
                }

            }


            btnSave.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtboxSearch.Text.Trim() == "")
            {
                LoadDate();
            }
            else
            {
                dataGridView.AutoGenerateColumns = false;
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    try
                    {
                        var data = (from CP in db.AD_CompanyProfile
                                    join BN in db.AD_BusinessNature
                                    on CP.BusinessNatureId equals BN.Id
                                    join BT in db.AD_BusinessType
                                    on CP.BusinessTypeId equals BT.Id
                                    select new
                                    {
                                        Id = CP.Id,
                                        CompanyName = CP.CompanyName,
                                        BusinessTypeId = CP.BusinessTypeId,
                                        BusinessNatureId = CP.BusinessNatureId,
                                        BIN = CP.BIN,
                                        TIN = CP.TIN,
                                        AddressLine1 = CP.AddressLine1,
                                        AddressLine2 = CP.AddressLine2,
                                        Phone = CP.Phone,
                                        ContactPersion = CP.ContactPersion,
                                        IncorporationNumber = CP.IncorporationNumber,
                                        Remarks = CP.Remarks,
                                        BusinessType = BT.BusinessType,
                                        BusinessNature = BN.BusinessNature
                                    }).Where(x => x.CompanyName.Contains(txtboxSearch.Text.Trim())).ToList();
                        dataGridView.DataSource = data;

                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }
        }
    }
}
