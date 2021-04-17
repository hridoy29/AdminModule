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
    public partial class adTerminal : Form
    {
        AD_Terminal ad_Terminal = new AD_Terminal();
        public adTerminal()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtboxTerminalName.Clear();
            txtboxTerminalIP.Clear();
            rdoIsActiveYes.Checked = true;
            btnSave.Enabled = true;
            ad_Terminal.Id = 0;
        }
        public void LoadDate()
        {
            Clear();
            dataGridView.AutoGenerateColumns = false;
            using (security_modulesEntities db = new security_modulesEntities())
            {
                dataGridView.DataSource = db.AD_Terminal.ToList();
            }

        }
        private void adTerminal_Load(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView.CurrentRow.Index != -1)
                {
                    ad_Terminal.Id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
                    using (security_modulesEntities db = new security_modulesEntities())
                    {
                        ad_Terminal = db.AD_Terminal.Where(x => x.Id == ad_Terminal.Id).FirstOrDefault();
                        txtboxTerminalName.Text = ad_Terminal.TerminalName;
                        txtboxTerminalIP.Text = ad_Terminal.TerminalIP;
                        if (ad_Terminal.IsActive == true)
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
                    ad_Terminal.TerminalName = txtboxTerminalName.Text.Trim();
                    ad_Terminal.TerminalIP = txtboxTerminalIP.Text.Trim();
                    ad_Terminal.CreationDate = DateTime.Now;
                    ad_Terminal.CreatorId = 1;
                    ad_Terminal.ModificationDate = DateTime.Now;
                    ad_Terminal.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_Terminal.IsActive = true;
                    }
                    else
                    {
                        ad_Terminal.IsActive = false;
                    }
                    if (ad_Terminal.Id == 0)
                    {
                        db.AD_Terminal.Add(ad_Terminal);
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

                    ad_Terminal.TerminalName = txtboxTerminalName.Text.Trim();
                    ad_Terminal.TerminalIP = txtboxTerminalIP.Text.Trim();
                    ad_Terminal.ModificationDate = DateTime.Now;
                    ad_Terminal.ModifierId = 1;
                    if (rdoIsActiveYes.Checked == true)
                    {
                        ad_Terminal.IsActive = true;
                    }
                    else
                    {
                        ad_Terminal.IsActive = false;
                    }
                    if (ad_Terminal.Id > 0)
                    {
                        db.Entry(ad_Terminal).State = EntityState.Modified;
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
