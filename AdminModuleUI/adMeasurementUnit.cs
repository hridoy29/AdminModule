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
    public partial class adMeasurementUnit : Form
    {
        AD_MeasurementUnit ad_MeasurementUnit = new AD_MeasurementUnit();
        public adMeasurementUnit()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtboxDescription.Clear();
            rdoIsActiveYes.Checked = true;
            btnSave.Enabled = true;
            ad_MeasurementUnit.Id = 0;
        }
        public void LoadDate()
        {
            Clear();
            dataGridView.AutoGenerateColumns = false;
            using (security_modulesEntities db = new security_modulesEntities())
            {
                dataGridView.DataSource = db.AD_MeasurementUnit.ToList();
            }

        }

        private void adMeasurementUnit_Load(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void adBusinessNature_Load(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView.CurrentRow.Index != -1)
                {
                    ad_MeasurementUnit.Id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
                    using (security_modulesEntities db = new security_modulesEntities())
                    {
                        ad_MeasurementUnit = db.AD_MeasurementUnit.Where(x => x.Id == ad_MeasurementUnit.Id).FirstOrDefault();
                        txtboxDescription.Text = ad_MeasurementUnit.Description;
                        if (ad_MeasurementUnit.IsActive == true)
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
                    ad_MeasurementUnit.Description = txtboxDescription.Text.Trim();
                    ad_MeasurementUnit.CreationDate = DateTime.Now;
                    ad_MeasurementUnit.CreatorId = 1;
                    ad_MeasurementUnit.ModificationDate = DateTime.Now;
                    ad_MeasurementUnit.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_MeasurementUnit.IsActive = true;
                    }
                    else
                    {
                        ad_MeasurementUnit.IsActive = false;
                    }
                    if (ad_MeasurementUnit.Id == 0)
                    {
                        db.AD_MeasurementUnit.Add(ad_MeasurementUnit);
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

                    ad_MeasurementUnit.Description = txtboxDescription.Text.Trim();
                    ad_MeasurementUnit.ModificationDate = DateTime.Now;
                    ad_MeasurementUnit.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_MeasurementUnit.IsActive = true;
                    }
                    else
                    {
                        ad_MeasurementUnit.IsActive = false;
                    }
                    if (ad_MeasurementUnit.Id > 0)
                    {
                        db.Entry(ad_MeasurementUnit).State = EntityState.Modified;
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
