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
    public partial class adOpeningBalanceCompany : Form
    {
        AD_OpeningBalanceCompany aD_OpeningBalanceCompany = new AD_OpeningBalanceCompany();
        public adOpeningBalanceCompany()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtboxOpeningBalance.Clear();
           
            btnSave.Enabled = true;
            aD_OpeningBalanceCompany.Id = 0;
            try
            {
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    cmbPaymentMethord.DataSource = db.AD_PaymentMethod.ToList();
                    cmbPaymentMethord.DisplayMember = "PaymentType";
                    cmbPaymentMethord.ValueMember = "Id";

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
            try
            {
                dataGridView.AutoGenerateColumns = false;
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    var data = (from CP in db.AD_OpeningBalanceCompany
                                join BN in db.AD_PaymentMethod
                                on CP.PaymentMethordId equals BN.Id
                                select new
                                {
                                    Id = CP.Id,
                                    PaymentTypeId = CP.PaymentMethordId,
                                    PaymentType = BN.PaymentType,
                                    OpeningBalance=CP.OpeningBalance,
                                    OpeningDate=CP.OpeningDate

                                }).ToList();
                    dataGridView.DataSource = data;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
          

        }
        private void adOpeningBalanceCompany_Load(object sender, EventArgs e)
        {
            LoadDate();
        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView.CurrentRow.Index != -1)
                {
                    aD_OpeningBalanceCompany.Id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
                    using (security_modulesEntities db = new security_modulesEntities())
                    {
                        aD_OpeningBalanceCompany = db.AD_OpeningBalanceCompany.Where(x => x.Id == aD_OpeningBalanceCompany.Id).FirstOrDefault();

                        txtboxOpeningBalance.Text = aD_OpeningBalanceCompany.OpeningBalance;

                        
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
                    aD_OpeningBalanceCompany.OpeningBalance = txtboxOpeningBalance.Text.Trim();
                    aD_OpeningBalanceCompany.PaymentMethordId = (int)cmbPaymentMethord.SelectedValue;
                    aD_OpeningBalanceCompany.OpeningDate = DateTime.Now;
                    if (aD_OpeningBalanceCompany.Id == 0)
                    {
                        db.AD_OpeningBalanceCompany.Add(aD_OpeningBalanceCompany);
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

                    aD_OpeningBalanceCompany.OpeningBalance = txtboxOpeningBalance.Text.Trim();
                    aD_OpeningBalanceCompany.PaymentMethordId = (int)cmbPaymentMethord.SelectedValue;
                    //aD_OpeningBalanceCompany.OpeningDate = DateTime.Now;
                    if (aD_OpeningBalanceCompany.Id > 0)
                    {
                        db.Entry(aD_OpeningBalanceCompany).State = EntityState.Modified;
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
