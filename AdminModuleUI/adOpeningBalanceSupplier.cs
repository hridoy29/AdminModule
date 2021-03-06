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
    public partial class adOpeningBalanceSupplier : Form
    {
        AD_OpeningBalanceSupplier ad_OpeningBalanceSupplier = new AD_OpeningBalanceSupplier();
        public adOpeningBalanceSupplier()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtboxOpeningBalance.Clear();
            btnSave.Enabled = true;
            ad_OpeningBalanceSupplier.Id = 0;
            try
            {
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    cmbSupplierName.DataSource = db.AD_Supplier.ToList();
                    cmbSupplierName.DisplayMember = "SupplierName";
                    cmbSupplierName.ValueMember = "Id";

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
                    var data = (from CP in db.AD_OpeningBalanceSupplier
                                join BN in db.AD_Supplier
                                on CP.SupplierId equals BN.Id
                                select new
                                {
                                    Id = CP.Id,
                                    SupplierId = CP.SupplierId,
                                    SupplierName = BN.SupplierName,
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
        private void adOpeningBalanceSupplier_Load(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView.CurrentRow.Index != -1)
                {
                    ad_OpeningBalanceSupplier.Id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
                    using (security_modulesEntities db = new security_modulesEntities())
                    {
                        ad_OpeningBalanceSupplier = db.AD_OpeningBalanceSupplier.Where(x => x.Id == ad_OpeningBalanceSupplier.Id).FirstOrDefault();

                        txtboxOpeningBalance.Text = ad_OpeningBalanceSupplier.OpeningBalance;


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
                    ad_OpeningBalanceSupplier.OpeningBalance = txtboxOpeningBalance.Text.Trim();
                    ad_OpeningBalanceSupplier.SupplierId = (int)cmbSupplierName.SelectedValue;
                    ad_OpeningBalanceSupplier.OpeningDate = dateTimePicker.Value;
                    if (ad_OpeningBalanceSupplier.Id == 0)
                    {
                        db.AD_OpeningBalanceSupplier.Add(ad_OpeningBalanceSupplier);
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

                    ad_OpeningBalanceSupplier.OpeningBalance = txtboxOpeningBalance.Text.Trim();
                    ad_OpeningBalanceSupplier.SupplierId = (int)cmbSupplierName.SelectedValue;
                    ad_OpeningBalanceSupplier.OpeningDate = dateTimePicker.Value;
                    if (ad_OpeningBalanceSupplier.Id > 0)
                    {
                        db.Entry(ad_OpeningBalanceSupplier).State = EntityState.Modified;
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
