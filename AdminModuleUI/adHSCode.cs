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
    public partial class adHSCode : Form
    {
        AD_HSCode ad_HSCode = new AD_HSCode();
        public adHSCode()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtboxAIT.Clear();
            txtboxAT.Clear();
            txtboxCD.Clear();
            txtboxDescription.Clear();
            txtboxHSCode.Clear();
            txtboxRD.Clear();
            txtboxSD.Clear();
            txtboxTTL.Clear();
            txtboxVAT.Clear();

            btnSave.Enabled = true;
            ad_HSCode.Id = 0;
        }
        public void LoadDate()
        {
            Clear();
            dataGridView.AutoGenerateColumns = false;
            using (security_modulesEntities db = new security_modulesEntities())
            {
                dataGridView.DataSource = db.AD_HSCode.ToList();
            }

        }
        private void adHSCode_Load(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView.CurrentRow.Index != -1)
                {
                    ad_HSCode.Id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
                    using (security_modulesEntities db = new security_modulesEntities())
                    {
                        ad_HSCode = db.AD_HSCode.Where(x => x.Id == ad_HSCode.Id).FirstOrDefault();
                        txtboxAIT.Text = ad_HSCode.AIT.ToString();
                        txtboxAT.Text = ad_HSCode.AT.ToString();
                        txtboxCD.Text = ad_HSCode.CD.ToString();
                        txtboxDescription.Text = ad_HSCode.Description;
                        txtboxHSCode.Text = ad_HSCode.HSCode.ToString();
                        txtboxRD.Text = ad_HSCode.RD.ToString();
                        txtboxSD.Text = ad_HSCode.SD.ToString();
                        txtboxTTL.Text = ad_HSCode.TTL.ToString();
                        txtboxVAT.Text = ad_HSCode.VAT.ToString();

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
                    ad_HSCode.AIT = Convert.ToDecimal(txtboxAIT.Text.Trim());
                    ad_HSCode.AT = Convert.ToDecimal(txtboxAT.Text.Trim());
                    ad_HSCode.CD = Convert.ToDecimal(txtboxCD.Text.Trim());
                    ad_HSCode.Description = txtboxDescription.Text.Trim();
                    ad_HSCode.HSCode = txtboxHSCode.Text.Trim();
                    ad_HSCode.RD = Convert.ToDecimal(txtboxRD.Text.Trim());
                    ad_HSCode.SD = Convert.ToDecimal(txtboxSD.Text.Trim());
                    ad_HSCode.TTL = Convert.ToDecimal(txtboxTTL.Text.Trim());
                    ad_HSCode.VAT = Convert.ToDecimal(txtboxVAT.Text.Trim());

                    if (ad_HSCode.Id == 0)
                    {
                        db.AD_HSCode.Add(ad_HSCode);
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

                    ad_HSCode.AIT = Convert.ToDecimal(txtboxAIT.Text.Trim());
                    ad_HSCode.AT = Convert.ToDecimal(txtboxAT.Text.Trim());
                    ad_HSCode.CD = Convert.ToDecimal(txtboxCD.Text.Trim());
                    ad_HSCode.Description = txtboxDescription.Text.Trim();
                    ad_HSCode.HSCode = txtboxHSCode.Text.Trim();
                    ad_HSCode.RD = Convert.ToDecimal(txtboxRD.Text.Trim());
                    ad_HSCode.SD = Convert.ToDecimal(txtboxSD.Text.Trim());
                    ad_HSCode.TTL = Convert.ToDecimal(txtboxTTL.Text.Trim());
                    ad_HSCode.VAT = Convert.ToDecimal(txtboxVAT.Text.Trim());

                    if (ad_HSCode.Id > 0)
                    {
                        db.Entry(ad_HSCode).State = EntityState.Modified;
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
