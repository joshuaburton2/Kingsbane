namespace Kingsbane.App
{
    partial class formEditClasses
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.cmbDominant = new System.Windows.Forms.ComboBox();
            this.cmbSecondary = new System.Windows.Forms.ComboBox();
            this.lblDominant = new System.Windows.Forms.Label();
            this.lblSecondary = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.txtPlaystyle = new System.Windows.Forms.TextBox();
            this.lblPlaystyle = new System.Windows.Forms.Label();
            this.lblStrengths = new System.Windows.Forms.Label();
            this.lblWeaknesses = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtStrengths = new System.Windows.Forms.TextBox();
            this.txtWeaknesses = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(293, 502);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 42);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Location = new System.Drawing.Point(192, 502);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(95, 42);
            this.btnSaveAndClose.TabIndex = 1;
            this.btnSaveAndClose.Text = "Save and Close";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(87, 502);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 42);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbClass
            // 
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(87, 15);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(286, 33);
            this.cmbClass.TabIndex = 3;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            // 
            // cmbDominant
            // 
            this.cmbDominant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDominant.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbDominant.FormattingEnabled = true;
            this.cmbDominant.Location = new System.Drawing.Point(12, 78);
            this.cmbDominant.Name = "cmbDominant";
            this.cmbDominant.Size = new System.Drawing.Size(162, 23);
            this.cmbDominant.TabIndex = 3;
            // 
            // cmbSecondary
            // 
            this.cmbSecondary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSecondary.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbSecondary.FormattingEnabled = true;
            this.cmbSecondary.Location = new System.Drawing.Point(198, 78);
            this.cmbSecondary.Name = "cmbSecondary";
            this.cmbSecondary.Size = new System.Drawing.Size(175, 23);
            this.cmbSecondary.TabIndex = 3;
            // 
            // lblDominant
            // 
            this.lblDominant.AutoSize = true;
            this.lblDominant.Location = new System.Drawing.Point(12, 60);
            this.lblDominant.Name = "lblDominant";
            this.lblDominant.Size = new System.Drawing.Size(114, 15);
            this.lblDominant.TabIndex = 4;
            this.lblDominant.Text = "Dominant Resource:\r\n";
            // 
            // lblSecondary
            // 
            this.lblSecondary.AutoSize = true;
            this.lblSecondary.Location = new System.Drawing.Point(198, 60);
            this.lblSecondary.Name = "lblSecondary";
            this.lblSecondary.Size = new System.Drawing.Size(116, 15);
            this.lblSecondary.TabIndex = 5;
            this.lblSecondary.Text = "Secondary Resource:";
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblClass.Location = new System.Drawing.Point(12, 15);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(59, 25);
            this.lblClass.TabIndex = 6;
            this.lblClass.Text = "Class:";
            // 
            // txtPlaystyle
            // 
            this.txtPlaystyle.Location = new System.Drawing.Point(12, 135);
            this.txtPlaystyle.Name = "txtPlaystyle";
            this.txtPlaystyle.Size = new System.Drawing.Size(361, 23);
            this.txtPlaystyle.TabIndex = 7;
            // 
            // lblPlaystyle
            // 
            this.lblPlaystyle.AutoSize = true;
            this.lblPlaystyle.Location = new System.Drawing.Point(12, 117);
            this.lblPlaystyle.Name = "lblPlaystyle";
            this.lblPlaystyle.Size = new System.Drawing.Size(56, 15);
            this.lblPlaystyle.TabIndex = 8;
            this.lblPlaystyle.Text = "Playstyle:";
            // 
            // lblStrengths
            // 
            this.lblStrengths.AutoSize = true;
            this.lblStrengths.Location = new System.Drawing.Point(12, 170);
            this.lblStrengths.Name = "lblStrengths";
            this.lblStrengths.Size = new System.Drawing.Size(60, 15);
            this.lblStrengths.TabIndex = 9;
            this.lblStrengths.Text = "Strengths:";
            // 
            // lblWeaknesses
            // 
            this.lblWeaknesses.AutoSize = true;
            this.lblWeaknesses.Location = new System.Drawing.Point(12, 257);
            this.lblWeaknesses.Name = "lblWeaknesses";
            this.lblWeaknesses.Size = new System.Drawing.Size(73, 15);
            this.lblWeaknesses.TabIndex = 10;
            this.lblWeaknesses.Text = "Weaknesses:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 343);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(67, 15);
            this.lblDescription.TabIndex = 11;
            this.lblDescription.Text = "Description";
            // 
            // txtStrengths
            // 
            this.txtStrengths.Location = new System.Drawing.Point(12, 188);
            this.txtStrengths.Multiline = true;
            this.txtStrengths.Name = "txtStrengths";
            this.txtStrengths.Size = new System.Drawing.Size(361, 55);
            this.txtStrengths.TabIndex = 12;
            // 
            // txtWeaknesses
            // 
            this.txtWeaknesses.Location = new System.Drawing.Point(12, 275);
            this.txtWeaknesses.Multiline = true;
            this.txtWeaknesses.Name = "txtWeaknesses";
            this.txtWeaknesses.Size = new System.Drawing.Size(361, 55);
            this.txtWeaknesses.TabIndex = 12;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 361);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(361, 125);
            this.txtDescription.TabIndex = 12;
            // 
            // formEditClasses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 556);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtWeaknesses);
            this.Controls.Add(this.txtStrengths);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblWeaknesses);
            this.Controls.Add(this.lblStrengths);
            this.Controls.Add(this.lblPlaystyle);
            this.Controls.Add(this.txtPlaystyle);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.lblSecondary);
            this.Controls.Add(this.lblDominant);
            this.Controls.Add(this.cmbSecondary);
            this.Controls.Add(this.cmbDominant);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.btnClose);
            this.Name = "formEditClasses";
            this.Text = "formEditClasses";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formEditClasses_FormClosed);
            this.Load += new System.EventHandler(this.formEditClasses_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.ComboBox cmbDominant;
        private System.Windows.Forms.ComboBox cmbSecondary;
        private System.Windows.Forms.Label lblDominant;
        private System.Windows.Forms.Label lblSecondary;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.TextBox txtPlaystyle;
        private System.Windows.Forms.Label lblPlaystyle;
        private System.Windows.Forms.Label lblStrengths;
        private System.Windows.Forms.Label lblWeaknesses;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtStrengths;
        private System.Windows.Forms.TextBox txtWeaknesses;
        private System.Windows.Forms.TextBox txtDescription;
    }
}