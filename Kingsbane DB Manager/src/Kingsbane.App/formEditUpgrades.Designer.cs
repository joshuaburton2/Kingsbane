namespace Kingsbane.App
{
    partial class formEditUpgrades
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.lblHonourPoints = new System.Windows.Forms.Label();
            this.txtHonourPoints = new System.Windows.Forms.TextBox();
            this.btnClassPrerequisite = new System.Windows.Forms.Button();
            this.lstClassPrerequisites = new System.Windows.Forms.ListBox();
            this.lblClassPrerequisite = new System.Windows.Forms.Label();
            this.cmbClassSelector = new System.Windows.Forms.ComboBox();
            this.cmbResourceSelector = new System.Windows.Forms.ComboBox();
            this.lblResourcePrerequisite = new System.Windows.Forms.Label();
            this.lstResourcePrerequisite = new System.Windows.Forms.ListBox();
            this.btnResourcePrerequisite = new System.Windows.Forms.Button();
            this.btnUpgradePrerequisite = new System.Windows.Forms.Button();
            this.lstUpgradePrerequisite = new System.Windows.Forms.ListBox();
            this.lblUpgradePrerequisite = new System.Windows.Forms.Label();
            this.cmbUpgradeSelector = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(12, 6);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(88, 37);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtName.Location = new System.Drawing.Point(106, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(324, 43);
            this.txtName.TabIndex = 1;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(12, 93);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(28, 15);
            this.lblText.TabIndex = 2;
            this.lblText.Text = "Text";
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(12, 111);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(418, 135);
            this.txtText.TabIndex = 3;
            // 
            // lblHonourPoints
            // 
            this.lblHonourPoints.AutoSize = true;
            this.lblHonourPoints.Location = new System.Drawing.Point(13, 61);
            this.lblHonourPoints.Name = "lblHonourPoints";
            this.lblHonourPoints.Size = new System.Drawing.Size(84, 15);
            this.lblHonourPoints.TabIndex = 4;
            this.lblHonourPoints.Text = "Honour Points";
            // 
            // txtHonourPoints
            // 
            this.txtHonourPoints.Location = new System.Drawing.Point(106, 58);
            this.txtHonourPoints.Name = "txtHonourPoints";
            this.txtHonourPoints.Size = new System.Drawing.Size(125, 23);
            this.txtHonourPoints.TabIndex = 5;
            // 
            // btnClassPrerequisite
            // 
            this.btnClassPrerequisite.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClassPrerequisite.Location = new System.Drawing.Point(389, 255);
            this.btnClassPrerequisite.Name = "btnClassPrerequisite";
            this.btnClassPrerequisite.Size = new System.Drawing.Size(41, 23);
            this.btnClassPrerequisite.TabIndex = 25;
            this.btnClassPrerequisite.Text = "+";
            this.btnClassPrerequisite.UseVisualStyleBackColor = true;
            // 
            // lstClassPrerequisites
            // 
            this.lstClassPrerequisites.FormattingEnabled = true;
            this.lstClassPrerequisites.ItemHeight = 15;
            this.lstClassPrerequisites.Location = new System.Drawing.Point(161, 284);
            this.lstClassPrerequisites.Name = "lstClassPrerequisites";
            this.lstClassPrerequisites.Size = new System.Drawing.Size(269, 64);
            this.lstClassPrerequisites.TabIndex = 19;
            // 
            // lblClassPrerequisite
            // 
            this.lblClassPrerequisite.AutoSize = true;
            this.lblClassPrerequisite.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblClassPrerequisite.Location = new System.Drawing.Point(12, 253);
            this.lblClassPrerequisite.Name = "lblClassPrerequisite";
            this.lblClassPrerequisite.Size = new System.Drawing.Size(144, 21);
            this.lblClassPrerequisite.TabIndex = 17;
            this.lblClassPrerequisite.Text = "Class Prerequisite";
            // 
            // cmbClassSelector
            // 
            this.cmbClassSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClassSelector.FormattingEnabled = true;
            this.cmbClassSelector.Location = new System.Drawing.Point(162, 255);
            this.cmbClassSelector.Name = "cmbClassSelector";
            this.cmbClassSelector.Size = new System.Drawing.Size(221, 23);
            this.cmbClassSelector.TabIndex = 26;
            // 
            // cmbResourceSelector
            // 
            this.cmbResourceSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResourceSelector.FormattingEnabled = true;
            this.cmbResourceSelector.Location = new System.Drawing.Point(193, 360);
            this.cmbResourceSelector.Name = "cmbResourceSelector";
            this.cmbResourceSelector.Size = new System.Drawing.Size(190, 23);
            this.cmbResourceSelector.TabIndex = 26;
            // 
            // lblResourcePrerequisite
            // 
            this.lblResourcePrerequisite.AutoSize = true;
            this.lblResourcePrerequisite.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblResourcePrerequisite.Location = new System.Drawing.Point(12, 360);
            this.lblResourcePrerequisite.Name = "lblResourcePrerequisite";
            this.lblResourcePrerequisite.Size = new System.Drawing.Size(175, 21);
            this.lblResourcePrerequisite.TabIndex = 17;
            this.lblResourcePrerequisite.Text = "Resource Prerequisite";
            // 
            // lstResourcePrerequisite
            // 
            this.lstResourcePrerequisite.FormattingEnabled = true;
            this.lstResourcePrerequisite.ItemHeight = 15;
            this.lstResourcePrerequisite.Location = new System.Drawing.Point(193, 389);
            this.lstResourcePrerequisite.Name = "lstResourcePrerequisite";
            this.lstResourcePrerequisite.Size = new System.Drawing.Size(237, 64);
            this.lstResourcePrerequisite.TabIndex = 19;
            // 
            // btnResourcePrerequisite
            // 
            this.btnResourcePrerequisite.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnResourcePrerequisite.Location = new System.Drawing.Point(389, 361);
            this.btnResourcePrerequisite.Name = "btnResourcePrerequisite";
            this.btnResourcePrerequisite.Size = new System.Drawing.Size(41, 23);
            this.btnResourcePrerequisite.TabIndex = 25;
            this.btnResourcePrerequisite.Text = "+";
            this.btnResourcePrerequisite.UseVisualStyleBackColor = true;
            // 
            // btnUpgradePrerequisite
            // 
            this.btnUpgradePrerequisite.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUpgradePrerequisite.Location = new System.Drawing.Point(389, 468);
            this.btnUpgradePrerequisite.Name = "btnUpgradePrerequisite";
            this.btnUpgradePrerequisite.Size = new System.Drawing.Size(41, 23);
            this.btnUpgradePrerequisite.TabIndex = 25;
            this.btnUpgradePrerequisite.Text = "+";
            this.btnUpgradePrerequisite.UseVisualStyleBackColor = true;
            // 
            // lstUpgradePrerequisite
            // 
            this.lstUpgradePrerequisite.FormattingEnabled = true;
            this.lstUpgradePrerequisite.ItemHeight = 15;
            this.lstUpgradePrerequisite.Location = new System.Drawing.Point(193, 496);
            this.lstUpgradePrerequisite.Name = "lstUpgradePrerequisite";
            this.lstUpgradePrerequisite.Size = new System.Drawing.Size(237, 64);
            this.lstUpgradePrerequisite.TabIndex = 19;
            // 
            // lblUpgradePrerequisite
            // 
            this.lblUpgradePrerequisite.AutoSize = true;
            this.lblUpgradePrerequisite.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUpgradePrerequisite.Location = new System.Drawing.Point(12, 467);
            this.lblUpgradePrerequisite.Name = "lblUpgradePrerequisite";
            this.lblUpgradePrerequisite.Size = new System.Drawing.Size(172, 21);
            this.lblUpgradePrerequisite.TabIndex = 17;
            this.lblUpgradePrerequisite.Text = "Upgrade Prerequisite";
            // 
            // cmbUpgradeSelector
            // 
            this.cmbUpgradeSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUpgradeSelector.FormattingEnabled = true;
            this.cmbUpgradeSelector.Location = new System.Drawing.Point(193, 468);
            this.cmbUpgradeSelector.Name = "cmbUpgradeSelector";
            this.cmbUpgradeSelector.Size = new System.Drawing.Size(190, 23);
            this.cmbUpgradeSelector.TabIndex = 26;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(172, 574);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 22);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(260, 574);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 22);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(348, 574);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(82, 22);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // formEditUpgrades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 602);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbUpgradeSelector);
            this.Controls.Add(this.lblUpgradePrerequisite);
            this.Controls.Add(this.lstUpgradePrerequisite);
            this.Controls.Add(this.btnUpgradePrerequisite);
            this.Controls.Add(this.btnResourcePrerequisite);
            this.Controls.Add(this.lstResourcePrerequisite);
            this.Controls.Add(this.lblResourcePrerequisite);
            this.Controls.Add(this.cmbResourceSelector);
            this.Controls.Add(this.cmbClassSelector);
            this.Controls.Add(this.lblClassPrerequisite);
            this.Controls.Add(this.lstClassPrerequisites);
            this.Controls.Add(this.btnClassPrerequisite);
            this.Controls.Add(this.txtHonourPoints);
            this.Controls.Add(this.lblHonourPoints);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Name = "formEditUpgrades";
            this.Text = "formEditUpgrades";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label lblHonourPoints;
        private System.Windows.Forms.TextBox txtHonourPoints;
        private System.Windows.Forms.Button btnClassPrerequisite;
        private System.Windows.Forms.ListBox lstClassPrerequisites;
        private System.Windows.Forms.Label lblClassPrerequisite;
        private System.Windows.Forms.ComboBox cmbClassSelector;
        private System.Windows.Forms.ComboBox cmbResourceSelector;
        private System.Windows.Forms.Label lblResourcePrerequisite;
        private System.Windows.Forms.ListBox lstResourcePrerequisite;
        private System.Windows.Forms.Button btnResourcePrerequisite;
        private System.Windows.Forms.Button btnUpgradePrerequisite;
        private System.Windows.Forms.ListBox lstUpgradePrerequisite;
        private System.Windows.Forms.Label lblUpgradePrerequisite;
        private System.Windows.Forms.ComboBox cmbUpgradeSelector;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
    }
}