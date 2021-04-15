using AdminModuleEntitiy.Model;
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

namespace AdminModuleUI
{
    public partial class adBusinessType : Form
    {


        AD_BusinessType ad_BusinessType = new AD_BusinessType();
        public adBusinessType()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtboxBusinessType.Clear();
            rdoIsActiveYes.Checked = true;
            btnSave.Enabled = true;
            ad_BusinessType.Id = 0;


        }
        public void LoadDate()
        {
            Clear();
            dataGridView.AutoGenerateColumns = false;
            using (security_modulesEntities db = new security_modulesEntities())
            {
                dataGridView.DataSource = db.AD_BusinessType.ToList();
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            using (security_modulesEntities db = new security_modulesEntities())
            {
                ad_BusinessType.BusinessType = txtboxBusinessType.Text.Trim();
                ad_BusinessType.CreationDate = DateTime.Now;
                ad_BusinessType.CreatorId = 1;
                ad_BusinessType.ModificationDate = DateTime.Now;
                ad_BusinessType.ModifierId = 1;
                if (rdoIsActiveYes.Checked == true)
                {
                    ad_BusinessType.IsActive = true;
                }
                else
                {
                    ad_BusinessType.IsActive = false;
                }

                if (ad_BusinessType.Id == 0)
                {
                    try
                    {
                        db.AD_BusinessType.Add(ad_BusinessType);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                   
                }
                LoadDate();
                MessageBox.Show("Data Save Successfuly");
                Clear();
            }

        }

        private void BusinessType_Load(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView.CurrentRow.Index != -1)
            {
                ad_BusinessType.Id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    ad_BusinessType = db.AD_BusinessType.Where(x => x.Id == ad_BusinessType.Id).FirstOrDefault();
                    txtboxBusinessType.Text = ad_BusinessType.BusinessType;
                    if (ad_BusinessType.IsActive == true)
                    {
                        rdoIsActiveYes.Checked = true;
                    }
                    else
                    {

                        rdoIsActiveNo.Checked = true;
                    }
                }

            }


            btnSave.Enabled = false;


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            using (security_modulesEntities db = new security_modulesEntities())
            {

                ad_BusinessType.BusinessType = txtboxBusinessType.Text.Trim();
                ad_BusinessType.ModificationDate = DateTime.Now;
                ad_BusinessType.ModifierId = 1;
                if (rdoIsActiveYes.Checked == true)
                {
                    ad_BusinessType.IsActive = true;
                }
                else
                {
                    ad_BusinessType.IsActive = false;
                }
                if (ad_BusinessType.Id > 0)
                {
                    db.Entry(ad_BusinessType).State = EntityState.Modified;
                    db.SaveChanges();
                }

            }
            LoadDate();
            MessageBox.Show("Data Updated Successfuly");
            Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            Clear();
        }

        private void Delete()
        {
            if (MessageBox.Show("Are You Sure to Delete this Record ?", "Business Nature", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    var entry = db.Entry(ad_BusinessType);
                    if (entry.State == EntityState.Detached)
                        db.AD_BusinessType.Attach(ad_BusinessType);
                    db.AD_BusinessType.Remove(ad_BusinessType);
                    db.SaveChanges();
                    LoadDate();
                    MessageBox.Show("Deleted Successfully");
                }
            }
        }
    }
}
