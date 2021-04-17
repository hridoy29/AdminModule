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
    public partial class adBusinessNature : Form
    {
        AD_BusinessNature ad_BusinessNature = new AD_BusinessNature();
        public adBusinessNature()
        {
            InitializeComponent();


        }
        public void Clear()
        {
            txtboxBusinessName.Clear();
            rdoIsActiveYes.Checked = true;
            btnSave.Enabled = true;
            ad_BusinessNature.Id = 0;
        }
        public void LoadDate()
        {
            Clear();
            dataGridView.AutoGenerateColumns = false;
            using (security_modulesEntities db = new security_modulesEntities())
            {
                dataGridView.DataSource = db.AD_BusinessNature.ToList();
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            using (security_modulesEntities db = new security_modulesEntities())
            {
                ad_BusinessNature.BusinessNature = txtboxBusinessName.Text.Trim();
                ad_BusinessNature.CreationDate = DateTime.Now;
                ad_BusinessNature.CreatorId = 1;
                ad_BusinessNature.ModificationDate = DateTime.Now;
                ad_BusinessNature.ModifierId = 1;
                if (rdoIsActiveYes.Checked == true)
                {
                    ad_BusinessNature.IsActive = true;
                }
                else
                {
                    ad_BusinessNature.IsActive = false;
                }
                if (ad_BusinessNature.Id == 0)
                {
                    db.AD_BusinessNature.Add(ad_BusinessNature);
                    db.SaveChanges();
                }
                LoadDate();
                MessageBox.Show("Data Save Successfuly");
                Clear();
            }

        }

        private void adBusinessNature_Load(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView.CurrentRow.Index != -1)
            {
                ad_BusinessNature.Id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    ad_BusinessNature = db.AD_BusinessNature.Where(x => x.Id == ad_BusinessNature.Id).FirstOrDefault();
                    txtboxBusinessName.Text = ad_BusinessNature.BusinessNature;
                    if (ad_BusinessNature.IsActive == true)
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

                ad_BusinessNature.BusinessNature = txtboxBusinessName.Text.Trim();
                ad_BusinessNature.ModificationDate = DateTime.Now;
                ad_BusinessNature.ModifierId = 1;
                if (rdoIsActiveYes.Checked == true)
                {
                    ad_BusinessNature.IsActive = true;
                }
                else
                {
                    ad_BusinessNature.IsActive = false;
                }
                if (ad_BusinessNature.Id > 0)
                {
                    db.Entry(ad_BusinessNature).State = EntityState.Modified;
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
                    var entry = db.Entry(ad_BusinessNature);
                    if (entry.State == EntityState.Detached)
                        db.AD_BusinessNature.Attach(ad_BusinessNature);
                    db.AD_BusinessNature.Remove(ad_BusinessNature);
                    db.SaveChanges();
                    LoadDate();
                    MessageBox.Show("Deleted Successfully");
                }
            }
        }

    }
}
