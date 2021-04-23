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
                    //var data = (from CP in db.AD_OpeningBalanceSupplier
                    //            join BN in db.AD_Customer
                    //            on CP.Cus equals BN.Id
                    //            select new
                    //            {
                    //                Id = CP.Id,
                    //                //PaymentTypeId = CP.PaymentMethordId,
                    //                //PaymentType = BN.PaymentType,
                    //                OpeningBalance = CP.OpeningBalance,
                    //                OpeningDate = CP.OpeningDate

                    //            }).ToList();
                  //  dataGridView.DataSource = data;
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

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}
