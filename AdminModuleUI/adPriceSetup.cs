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
    public partial class adPriceSetup : Form
    {
        List<AD_ProductPricing> AD_ProductPricing = new List<AD_ProductPricing>();
        AD_Product aD_Product = new AD_Product();
        AD_ProductCodeIntegration aD_ProductCodeIntegration = new AD_ProductCodeIntegration();
        DataTable table = new DataTable();
        public adPriceSetup()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtboxRate.Clear();
            txtboxROI.Clear();
            txtboxSD.Clear();
            txtboxDescription.Clear();
            txtboxSD.Clear();
            txtboxVAT.Clear();
            txtboxHScode.Clear();
            txtboxHScode.Clear();
            txtboxAccountCode.Clear();
            txtboxBarCode.Clear();
            btnSave.Enabled = true;
            aD_Product.Id = 0;
            aD_ProductCodeIntegration.Id = 0;
            AD_ProductPricing.Clear();
            table.Clear();
        }
        private void LoadDataTable()
        {
            try
            {
                table.Columns.Add("PricingType", typeof(int));
                table.Columns.Add("ProductId", typeof(int));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void LoadDate()
        {
            Clear();

            try
            {
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    cmbGroup.DataSource = db.AD_ProductGroup.ToList();
                    cmbGroup.DisplayMember = "ProductGroup";
                    cmbGroup.ValueMember = "Id";

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            try
            {
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    cmbProductType.DataSource = db.AD_ProductType.ToList();
                    cmbProductType.DisplayMember = "ProductType";
                    cmbProductType.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            try
            {
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    cmbUnit.DataSource = db.AD_MeasurementUnit.ToList();
                    cmbUnit.DisplayMember = "Description";
                    cmbUnit.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            try
            {
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    cmbPriceType.DataSource = db.AD_PricingType.ToList();
                    cmbPriceType.DisplayMember = "PricingType";
                    cmbPriceType.ValueMember = "Id";

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            try
            {
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    cmbProduct.DataSource = db.AD_Product.ToList();
                    cmbProduct.DisplayMember = "Description";
                    cmbProduct.ValueMember = "Id";

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            try
            {
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    cmbProductCode.DataSource = db.AD_Product.ToList();
                    cmbProductCode.DisplayMember = "Description";
                    cmbProductCode.ValueMember = "Id";

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private void adPriceSetup_Load(object sender, EventArgs e)
        {
            LoadDate();
            LoadDataTable();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    aD_Product.Description = txtboxDescription.Text.Trim();
                    aD_Product.ProductGroup = (int)cmbGroup.SelectedValue;
                    aD_Product.ProductType = (int)cmbProductType.SelectedValue;
                    aD_Product.MeasurementUnit = (int)cmbUnit.SelectedValue;
                    aD_Product.ExpieryDate = dateTimePicker.Value.Date;
                    aD_Product.Rate = Convert.ToDecimal(txtboxRate.Text.Trim());
                    aD_Product.ROL = Convert.ToDecimal(txtboxROI.Text.Trim());
                    aD_Product.SD = Convert.ToDecimal(txtboxSD.Text.Trim());
                    aD_Product.VAT = Convert.ToDecimal(txtboxVAT.Text.Trim());
                    aD_Product.CreationDate = DateTime.Now;
                    aD_Product.CreatorId = 1;
                    aD_Product.ModificationDate = DateTime.Now;
                    aD_Product.ModifierId = 1;
                    if (aD_Product.Id == 0)
                    {
                        db.AD_Product.Add(aD_Product);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AD_ProductPricing aD_ProductPricing = new AD_ProductPricing();
                table.Rows.Add(cmbProduct.SelectedValue, cmbPriceType.SelectedValue);
                dataGridView.DataSource = table;
                aD_ProductPricing.PricingType = (int)cmbPriceType.SelectedValue;
                aD_ProductPricing.ProductId = (int)cmbProduct.SelectedValue;
                AD_ProductPricing.Add(aD_ProductPricing);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void btnSavePrice_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in AD_ProductPricing)
                {
                    try
                    {
                        AD_ProductPricing ad_ProductPricing = new AD_ProductPricing();
                        using (security_modulesEntities db = new security_modulesEntities())
                        {
                            ad_ProductPricing.ProductId = item.ProductId;
                            ad_ProductPricing.PricingType = item.PricingType;

                            if (ad_ProductPricing.Id == 0)
                            {
                                db.AD_ProductPricing.Add(ad_ProductPricing);
                                db.SaveChanges();
                            }
                        }
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
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void btnSaveCodeIntegration_Click(object sender, EventArgs e)
        {
            try
            {
                using (security_modulesEntities db = new security_modulesEntities())
                {
                    aD_ProductCodeIntegration.ProductId = (int)cmbProductCode.SelectedValue;
                    aD_ProductCodeIntegration.HSCode = txtboxHScode.Text.Trim();                    
                    aD_ProductCodeIntegration.ProductCode = txtboxHScode.Text.Trim();
                    aD_ProductCodeIntegration.AccountsCode = txtboxAccountCode.Text.Trim();                    
                    aD_ProductCodeIntegration.Barcode = Encoding.UTF8.GetBytes(txtboxBarCode.Text.Trim());
                    if (aD_ProductCodeIntegration.Id == 0)
                    {
                        db.AD_ProductCodeIntegration.Add(aD_ProductCodeIntegration);
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
    }
}
