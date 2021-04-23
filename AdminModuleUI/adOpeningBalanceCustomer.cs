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
    public partial class adOpeningBalanceCustomer : Form
    {
        AD_OpeningBalanceCustomer ad_OpeningBalanceCustomer = new AD_OpeningBalanceCustomer();
        public adOpeningBalanceCustomer()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtboxOpeningBalance.Clear();
            btnSave.Enabled = true;
            ad_OpeningBalanceCustomer.Id = 0;
            try
            {
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    cmbCustomerName.DataSource = db.AD_Customer.ToList();
                    cmbCustomerName.DisplayMember = "CustomerName";
                    cmbCustomerName.ValueMember = "Id";

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
                    var data = (from CP in db.AD_OpeningBalanceCustomer
                                join BN in db.AD_Customer
                                on CP.CustomerId equals BN.Id
                                select new
                                {
                                    Id = CP.Id,
                                    CustomerId = CP.CustomerId,
                                    CustomerName = BN.CustomerName,
                                    OpeningBalance = CP.OpeningBalance,
                                    OpeningDate = CP.OpeningDate

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
                    ad_OpeningBalanceCustomer.Id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
                    using (security_modulesEntities db = new security_modulesEntities())
                    {
                        ad_OpeningBalanceCustomer = db.AD_OpeningBalanceCustomer.Where(x => x.Id == ad_OpeningBalanceCustomer.Id).FirstOrDefault();

                        txtboxOpeningBalance.Text = ad_OpeningBalanceCustomer.OpeningBalance;


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
                    ad_OpeningBalanceCustomer.OpeningBalance = txtboxOpeningBalance.Text.Trim();
                    ad_OpeningBalanceCustomer.CustomerId = (int)cmbCustomerName.SelectedValue;
                    ad_OpeningBalanceCustomer.OpeningDate = dateTimePicker.Value;
                    if (ad_OpeningBalanceCustomer.Id == 0)
                    {
                        db.AD_OpeningBalanceCustomer.Add(ad_OpeningBalanceCustomer);
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

                    ad_OpeningBalanceCustomer.OpeningBalance = txtboxOpeningBalance.Text.Trim();
                    ad_OpeningBalanceCustomer.CustomerId = (int)cmbCustomerName.SelectedValue;
                    ad_OpeningBalanceCustomer.OpeningDate = dateTimePicker.Value;
                    if (ad_OpeningBalanceCustomer.Id > 0)
                    {
                        db.Entry(ad_OpeningBalanceCustomer).State = EntityState.Modified;
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
