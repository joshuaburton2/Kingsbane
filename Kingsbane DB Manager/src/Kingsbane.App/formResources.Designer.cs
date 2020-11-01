namespace Kingsbane.App
{
    partial class formResources
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
            this.cmbResource = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.cmbProperty1 = new System.Windows.Forms.ComboBox();
            this.cmbProperty2 = new System.Windows.Forms.ComboBox();
            this.lblProperty1 = new System.Windows.Forms.Label();
            this.lblProperty2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbResource
            // 
            this.cmbResource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResource.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbResource.FormattingEnabled = true;
            this.cmbResource.Location = new System.Drawing.Point(13, 13);
            this.cmbResource.Name = "cmbResource";
            this.cmbResource.Size = new System.Drawing.Size(305, 33);
            this.cmbResource.TabIndex = 0;
            this.cmbResource.SelectedIndexChanged += new System.EventHandler(this.cmbResource_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(249, 321);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(60, 321);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDescription
            // 
            this.btnDescription.AutoSize = true;
            this.btnDescription.Location = new System.Drawing.Point(13, 53);
            this.btnDescription.Name = "btnDescription";
            this.btnDescription.Size = new System.Drawing.Size(67, 15);
            this.btnDescription.TabIndex = 3;
            this.btnDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(13, 72);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(305, 183);
            this.txtDescription.TabIndex = 4;
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Location = new System.Drawing.Point(141, 321);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(102, 23);
            this.btnSaveAndClose.TabIndex = 5;
            this.btnSaveAndClose.Text = "Save and Close";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // cmbProperty1
            // 
            this.cmbProperty1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProperty1.FormattingEnabled = true;
            this.cmbProperty1.Location = new System.Drawing.Point(83, 262);
            this.cmbProperty1.Name = "cmbProperty1";
            this.cmbProperty1.Size = new System.Drawing.Size(234, 23);
            this.cmbProperty1.TabIndex = 6;
            // 
            // cmbProperty2
            // 
            this.cmbProperty2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProperty2.FormattingEnabled = true;
            this.cmbProperty2.Location = new System.Drawing.Point(83, 292);
            this.cmbProperty2.Name = "cmbProperty2";
            this.cmbProperty2.Size = new System.Drawing.Size(233, 23);
            this.cmbProperty2.TabIndex = 7;
            // 
            // lblProperty1
            // 
            this.lblProperty1.AutoSize = true;
            this.lblProperty1.Location = new System.Drawing.Point(13, 265);
            this.lblProperty1.Name = "lblProperty1";
            this.lblProperty1.Size = new System.Drawing.Size(64, 15);
            this.lblProperty1.TabIndex = 8;
            this.lblProperty1.Text = "Property 1:";
            // 
            // lblProperty2
            // 
            this.lblProperty2.AutoSize = true;
            this.lblProperty2.Location = new System.Drawing.Point(13, 291);
            this.lblProperty2.Name = "lblProperty2";
            this.lblProperty2.Size = new System.Drawing.Size(64, 15);
            this.lblProperty2.TabIndex = 9;
            this.lblProperty2.Text = "Property 2:";
            // 
            // formResources
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 354);
            this.Controls.Add(this.lblProperty2);
            this.Controls.Add(this.lblProperty1);
            this.Controls.Add(this.cmbProperty2);
            this.Controls.Add(this.cmbProperty1);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnDescription);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbResource);
            this.Name = "formResources";
            this.Text = "formResources";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formResources_FormClosed);
            this.Load += new System.EventHandler(this.formResources_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbResource;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label btnDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.ComboBox cmbProperty1;
        private System.Windows.Forms.ComboBox cmbProperty2;
        private System.Windows.Forms.Label lblProperty1;
        private System.Windows.Forms.Label lblProperty2;
    }
}