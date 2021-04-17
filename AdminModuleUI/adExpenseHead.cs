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
    public partial class adExpenseHead : Form
    {
        AD_ExpenseHead ad_ExpenseHead = new AD_ExpenseHead();
        public adExpenseHead()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtboxHead.Clear();
            rdoIsActiveYes.Checked = true;
            btnSave.Enabled = true;
            ad_ExpenseHead.Id = 0;
        }
        public void LoadDate()
        {
            Clear();
            dataGridView.AutoGenerateColumns = false;
            using (security_modulesEntities db = new security_modulesEntities())
            {
                dataGridView.DataSource = db.AD_ExpenseHead.ToList();
            }

        }
        private void adExpenseHead_Load(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView.CurrentRow.Index != -1)
                {
                    ad_ExpenseHead.Id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
                    using (security_modulesEntities db = new security_modulesEntities())
                    {
                        ad_ExpenseHead = db.AD_ExpenseHead.Where(x => x.Id == ad_ExpenseHead.Id).FirstOrDefault();
                        txtboxHead.Text = ad_ExpenseHead.Head;
                        if (ad_ExpenseHead.IsActive == true)
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
                    ad_ExpenseHead.Head = txtboxHead.Text.Trim();
                    ad_ExpenseHead.CreationDate = DateTime.Now;
                    ad_ExpenseHead.CreatorId = 1;
                    ad_ExpenseHead.ModificationDate = DateTime.Now;
                    ad_ExpenseHead.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_ExpenseHead.IsActive = true;
                    }
                    else
                    {
                        ad_ExpenseHead.IsActive = false;
                    }
                    if (ad_ExpenseHead.Id == 0)
                    {
                        db.AD_ExpenseHead.Add(ad_ExpenseHead);
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

                    ad_ExpenseHead.Head = txtboxHead.Text.Trim();
                    ad_ExpenseHead.ModificationDate = DateTime.Now;
                    ad_ExpenseHead.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_ExpenseHead.IsActive = true;
                    }
                    else
                    {
                        ad_ExpenseHead.IsActive = false;
                    }
                    if (ad_ExpenseHead.Id > 0)
                    {
                        db.Entry(ad_ExpenseHead).State = EntityState.Modified;
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
