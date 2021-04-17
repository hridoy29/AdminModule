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
    public partial class adBank : Form
    {
        AD_Bank ad_Bank = new AD_Bank();
        public adBank()
        {
            InitializeComponent();
        }

        private void adBank_Load(object sender, EventArgs e)
        {
            LoadDate();


        }
        public void Clear()
        {
            txtboxBankName.Clear();
            txtboxAccountNumber.Clear();
            rdoIsActiveYes.Checked = true;
            btnSave.Enabled = true;
            ad_Bank.Id = 0;

        }
        public void LoadDate()
        {
            Clear();
            dataGridView.AutoGenerateColumns = false;
            using (security_modulesEntities db = new security_modulesEntities())
            {
                dataGridView.DataSource = db.AD_Bank.ToList();
            }

        }

       

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView.CurrentRow.Index != -1)
                {
                    ad_Bank.Id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
                    using (security_modulesEntities db = new security_modulesEntities())
                    {
                        ad_Bank = db.AD_Bank.Where(x => x.Id == ad_Bank.Id).FirstOrDefault();
                        txtboxAccountNumber.Text = ad_Bank.AccountNumber;
                        txtboxBankName.Text = ad_Bank.BankName;

                        if (ad_Bank.IsActive == true)
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
                    ad_Bank.AccountNumber = txtboxAccountNumber.Text.Trim();
                    ad_Bank.BankName = txtboxBankName.Text.Trim();
                    ad_Bank.CreationDate = DateTime.Now;
                    ad_Bank.CreatorId = 1;
                    ad_Bank.ModificationDate = DateTime.Now;
                    ad_Bank.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_Bank.IsActive = true;
                    }
                    else
                    {
                        ad_Bank.IsActive = false;
                    }
                    if (ad_Bank.Id == 0)
                    {
                        db.AD_Bank.Add(ad_Bank);
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

                    ad_Bank.AccountNumber = txtboxAccountNumber.Text.Trim();
                    ad_Bank.BankName = txtboxBankName.Text.Trim();
                    ad_Bank.ModificationDate = DateTime.Now;
                    ad_Bank.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_Bank.IsActive = true;
                    }
                    else
                    {
                        ad_Bank.IsActive = false;
                    }
                    if (ad_Bank.Id > 0)
                    {
                        db.Entry(ad_Bank).State = EntityState.Modified;
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
