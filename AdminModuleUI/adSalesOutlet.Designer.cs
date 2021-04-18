namespace AdminModuleUI
{
    partial class adSalesOutlet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.txtboxPhoneNumber1 = new System.Windows.Forms.TextBox();
            this.txtboxAddressLine1 = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.txtboxPhoneNumber2 = new System.Windows.Forms.TextBox();
            this.txtboxAddressLine2 = new System.Windows.Forms.TextBox();
            this.txtboxOutletName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxActive = new System.Windows.Forms.GroupBox();
            this.rdoIsActiveNo = new System.Windows.Forms.RadioButton();
            this.rdoIsActiveYes = new System.Windows.Forms.RadioButton();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutletName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressLine1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressLine2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBoxActive.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(16, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 19);
            this.label7.TabIndex = 18;
            this.label7.Text = "Phone Number2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 19);
            this.label2.TabIndex = 17;
            this.label2.Text = "Phone Number1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(16, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "AddressLine2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "Address Line1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView);
            this.panel2.Location = new System.Drawing.Point(406, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(690, 437);
            this.panel2.TabIndex = 9;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(46)))), ((int)(((byte)(107)))));
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.OutletName,
            this.AddressLine1,
            this.AddressLine2,
            this.PhoneNumber1,
            this.PhoneNumber2,
            this.IsActive});
            this.dataGridView.Location = new System.Drawing.Point(1, -1);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(686, 435);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // txtboxPhoneNumber1
            // 
            this.txtboxPhoneNumber1.Location = new System.Drawing.Point(132, 140);
            this.txtboxPhoneNumber1.Name = "txtboxPhoneNumber1";
            this.txtboxPhoneNumber1.Size = new System.Drawing.Size(234, 23);
            this.txtboxPhoneNumber1.TabIndex = 9;
            // 
            // txtboxAddressLine1
            // 
            this.txtboxAddressLine1.Location = new System.Drawing.Point(132, 66);
            this.txtboxAddressLine1.Name = "txtboxAddressLine1";
            this.txtboxAddressLine1.Size = new System.Drawing.Size(234, 23);
            this.txtboxAddressLine1.TabIndex = 8;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(126)))), ((int)(((byte)(1)))));
            this.btnClear.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClear.Location = new System.Drawing.Point(295, 350);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(74, 43);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.btnUpdate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnUpdate.Location = new System.Drawing.Point(214, 350);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(74, 43);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(81)))), ((int)(((byte)(250)))));
            this.btnSave.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.Location = new System.Drawing.Point(132, 350);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 43);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.ForeColor = System.Drawing.Color.White;
            this.lblCompanyName.Location = new System.Drawing.Point(16, 29);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(92, 19);
            this.lblCompanyName.TabIndex = 1;
            this.lblCompanyName.Text = "Outlet Name";
            // 
            // txtboxPhoneNumber2
            // 
            this.txtboxPhoneNumber2.Location = new System.Drawing.Point(132, 176);
            this.txtboxPhoneNumber2.Name = "txtboxPhoneNumber2";
            this.txtboxPhoneNumber2.Size = new System.Drawing.Size(234, 23);
            this.txtboxPhoneNumber2.TabIndex = 10;
            // 
            // txtboxAddressLine2
            // 
            this.txtboxAddressLine2.Location = new System.Drawing.Point(132, 102);
            this.txtboxAddressLine2.Name = "txtboxAddressLine2";
            this.txtboxAddressLine2.Size = new System.Drawing.Size(234, 23);
            this.txtboxAddressLine2.TabIndex = 7;
            // 
            // txtboxOutletName
            // 
            this.txtboxOutletName.Location = new System.Drawing.Point(132, 29);
            this.txtboxOutletName.Name = "txtboxOutletName";
            this.txtboxOutletName.Size = new System.Drawing.Size(234, 23);
            this.txtboxOutletName.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(46)))), ((int)(((byte)(107)))));
            this.panel1.Controls.Add(this.groupBoxActive);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtboxPhoneNumber2);
            this.panel1.Controls.Add(this.txtboxPhoneNumber1);
            this.panel1.Controls.Add(this.txtboxAddressLine1);
            this.panel1.Controls.Add(this.txtboxAddressLine2);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.lblCompanyName);
            this.panel1.Controls.Add(this.txtboxOutletName);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 443);
            this.panel1.TabIndex = 8;
            // 
            // groupBoxActive
            // 
            this.groupBoxActive.Controls.Add(this.rdoIsActiveNo);
            this.groupBoxActive.Controls.Add(this.rdoIsActiveYes);
            this.groupBoxActive.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxActive.ForeColor = System.Drawing.Color.White;
            this.groupBoxActive.Location = new System.Drawing.Point(132, 220);
            this.groupBoxActive.Name = "groupBoxActive";
            this.groupBoxActive.Size = new System.Drawing.Size(237, 116);
            this.groupBoxActive.TabIndex = 19;
            this.groupBoxActive.TabStop = false;
            this.groupBoxActive.Text = "Active";
            // 
            // rdoIsActiveNo
            // 
            this.rdoIsActiveNo.AutoSize = true;
            this.rdoIsActiveNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoIsActiveNo.ForeColor = System.Drawing.Color.White;
            this.rdoIsActiveNo.Location = new System.Drawing.Point(106, 44);
            this.rdoIsActiveNo.Name = "rdoIsActiveNo";
            this.rdoIsActiveNo.Size = new System.Drawing.Size(45, 23);
            this.rdoIsActiveNo.TabIndex = 2;
            this.rdoIsActiveNo.TabStop = true;
            this.rdoIsActiveNo.Text = "No";
            this.rdoIsActiveNo.UseVisualStyleBackColor = true;
            // 
            // rdoIsActiveYes
            // 
            this.rdoIsActiveYes.AutoSize = true;
            this.rdoIsActiveYes.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoIsActiveYes.ForeColor = System.Drawing.Color.White;
            this.rdoIsActiveYes.Location = new System.Drawing.Point(15, 44);
            this.rdoIsActiveYes.Name = "rdoIsActiveYes";
            this.rdoIsActiveYes.Size = new System.Drawing.Size(49, 23);
            this.rdoIsActiveYes.TabIndex = 1;
            this.rdoIsActiveYes.TabStop = true;
            this.rdoIsActiveYes.Text = "Yes";
            this.rdoIsActiveYes.UseVisualStyleBackColor = true;
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // OutletName
            // 
            this.OutletName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OutletName.DataPropertyName = "OutletName";
            this.OutletName.HeaderText = "Outlet Name";
            this.OutletName.Name = "OutletName";
            this.OutletName.ReadOnly = true;
            // 
            // AddressLine1
            // 
            this.AddressLine1.DataPropertyName = "AddressLine1";
            this.AddressLine1.HeaderText = "Address Line1";
            this.AddressLine1.Name = "AddressLine1";
            this.AddressLine1.ReadOnly = true;
            // 
            // AddressLine2
            // 
            this.AddressLine2.DataPropertyName = "AddressLine2";
            this.AddressLine2.HeaderText = "AddressLine2";
            this.AddressLine2.Name = "AddressLine2";
            this.AddressLine2.ReadOnly = true;
            // 
            // PhoneNumber1
            // 
            this.PhoneNumber1.DataPropertyName = "PhoneNumber1";
            this.PhoneNumber1.HeaderText = "Phone Number1";
            this.PhoneNumber1.Name = "PhoneNumber1";
            this.PhoneNumber1.ReadOnly = true;
            // 
            // PhoneNumber2
            // 
            this.PhoneNumber2.DataPropertyName = "PhoneNumber2";
            this.PhoneNumber2.HeaderText = "Phone Number2";
            this.PhoneNumber2.Name = "PhoneNumber2";
            this.PhoneNumber2.ReadOnly = true;
            // 
            // IsActive
            // 
            this.IsActive.DataPropertyName = "IsActive";
            this.IsActive.HeaderText = "Active";
            this.IsActive.Name = "IsActive";
            this.IsActive.ReadOnly = true;
            this.IsActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // adSalesOutlet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 446);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "adSalesOutlet";
            this.Text = "Sales Outlet";
            this.Load += new System.EventHandler(this.adSalesOutlet_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxActive.ResumeLayout(false);
            this.groupBoxActive.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox txtboxPhoneNumber1;
        private System.Windows.Forms.TextBox txtboxAddressLine1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.TextBox txtboxPhoneNumber2;
        private System.Windows.Forms.TextBox txtboxAddressLine2;
        private System.Windows.Forms.TextBox txtboxOutletName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxActive;
        private System.Windows.Forms.RadioButton rdoIsActiveNo;
        private System.Windows.Forms.RadioButton rdoIsActiveYes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutletName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressLine1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressLine2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsActive;
    }
}