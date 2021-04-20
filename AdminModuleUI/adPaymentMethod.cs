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
{//PaymentType
    public partial class adPaymentMethod : Form
    {
        AD_PaymentMethod ad_PaymentMethod = new AD_PaymentMethod();
        public adPaymentMethod()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtboxPaymentType.Clear();            
            rdoIsActiveYes.Checked = true;
            btnSave.Enabled = true;
            ad_PaymentMethod.Id = 0;
            try
            {
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    cmbMethodType.DataSource = db.AD_PaymentMethodType.ToList();
                    cmbMethodType.DisplayMember = "TypeDescription";
                    cmbMethodType.ValueMember = "Id";

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
                var data = (from CP in db.AD_PaymentMethod
                            join BN in db.AD_PaymentMethodType
                            on CP.MethodTypeId equals BN.Id                          
                            select new
                            {
                                Id = CP.Id,
                                PaymentType = CP.PaymentType,
                                TypeDescription = BN.TypeDescription,
                                IsActive = CP.IsActive
                            }).ToList();
                dataGridView.DataSource = data;
               // dataGridView.DataSource = db.AD_PaymentMethod.ToList();
            }

        }
        private void adPaymentMethod_Load(object sender, EventArgs e)
        {
            LoadDate(); 
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView.CurrentRow.Index != -1)
                {
                    ad_PaymentMethod.Id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
                    using (security_modulesEntities db = new security_modulesEntities())
                    {
                        ad_PaymentMethod = db.AD_PaymentMethod.Where(x => x.Id == ad_PaymentMethod.Id).FirstOrDefault();
                         
                        txtboxPaymentType.Text = ad_PaymentMethod.PaymentType;

                        if (ad_PaymentMethod.IsActive == true)
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
                    ad_PaymentMethod.PaymentType = txtboxPaymentType.Text.Trim();
                    ad_PaymentMethod.MethodTypeId = (int)cmbMethodType.SelectedValue;
                    ad_PaymentMethod.CreationDate = DateTime.Now;
                    ad_PaymentMethod.CreatorId = 1;
                    ad_PaymentMethod.ModificationDate = DateTime.Now;
                    ad_PaymentMethod.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_PaymentMethod.IsActive = true;
                    }
                    else
                    {
                        ad_PaymentMethod.IsActive = false;
                    }
                    if (ad_PaymentMethod.Id == 0)
                    {
                        db.AD_PaymentMethod.Add(ad_PaymentMethod);
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

                    ad_PaymentMethod.PaymentType = txtboxPaymentType.Text.Trim();
                    ad_PaymentMethod.MethodTypeId = (int)cmbMethodType.SelectedValue;
                    ad_PaymentMethod.ModificationDate = DateTime.Now;
                    ad_PaymentMethod.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_PaymentMethod.IsActive = true;
                    }
                    else
                    {
                        ad_PaymentMethod.IsActive = false;
                    }
                    if (ad_PaymentMethod.Id > 0)
                    {
                        db.Entry(ad_PaymentMethod).State = EntityState.Modified;
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
