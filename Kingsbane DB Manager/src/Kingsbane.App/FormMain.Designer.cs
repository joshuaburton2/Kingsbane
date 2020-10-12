namespace Kingsbane.App
{
    partial class formMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCardList = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClassList = new System.Windows.Forms.Button();
            this.btnExportClasses = new System.Windows.Forms.Button();
            this.btnUpgrades = new System.Windows.Forms.Button();
            this.btnExportUpgrades = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCardList
            // 
            this.buttonCardList.Location = new System.Drawing.Point(12, 65);
            this.buttonCardList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCardList.Name = "buttonCardList";
            this.buttonCardList.Size = new System.Drawing.Size(116, 52);
            this.buttonCardList.TabIndex = 0;
            this.buttonCardList.Text = "Card Library";
            this.buttonCardList.UseVisualStyleBackColor = true;
            this.buttonCardList.Click += new System.EventHandler(this.buttonCardList_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 50);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Kingsbane Library Manager";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(12, 121);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(116, 52);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClassList
            // 
            this.btnClassList.Location = new System.Drawing.Point(372, 65);
            this.btnClassList.Name = "btnClassList";
            this.btnClassList.Size = new System.Drawing.Size(120, 52);
            this.btnClassList.TabIndex = 2;
            this.btnClassList.Text = "Classes";
            this.btnClassList.UseVisualStyleBackColor = true;
            this.btnClassList.Click += new System.EventHandler(this.btnClassList_Click);
            // 
            // btnExportClasses
            // 
            this.btnExportClasses.Location = new System.Drawing.Point(372, 124);
            this.btnExportClasses.Name = "btnExportClasses";
            this.btnExportClasses.Size = new System.Drawing.Size(120, 49);
            this.btnExportClasses.TabIndex = 3;
            this.btnExportClasses.Text = "Export";
            this.btnExportClasses.UseVisualStyleBackColor = true;
            this.btnExportClasses.Click += new System.EventHandler(this.btnExportClasses_Click);
            // 
            // btnUpgrades
            // 
            this.btnUpgrades.Location = new System.Drawing.Point(192, 65);
            this.btnUpgrades.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpgrades.Name = "btnUpgrades";
            this.btnUpgrades.Size = new System.Drawing.Size(116, 52);
            this.btnUpgrades.TabIndex = 0;
            this.btnUpgrades.Text = "Upgrades";
            this.btnUpgrades.UseVisualStyleBackColor = true;
            this.btnUpgrades.Click += new System.EventHandler(this.btnUpgrades_Click);
            // 
            // btnExportUpgrades
            // 
            this.btnExportUpgrades.Location = new System.Drawing.Point(192, 121);
            this.btnExportUpgrades.Name = "btnExportUpgrades";
            this.btnExportUpgrades.Size = new System.Drawing.Size(116, 52);
            this.btnExportUpgrades.TabIndex = 4;
            this.btnExportUpgrades.Text = "Export";
            this.btnExportUpgrades.UseVisualStyleBackColor = true;
            this.btnExportUpgrades.Click += new System.EventHandler(this.btnExportUpgrades_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 188);
            this.Controls.Add(this.btnExportUpgrades);
            this.Controls.Add(this.btnUpgrades);
            this.Controls.Add(this.btnExportClasses);
            this.Controls.Add(this.btnClassList);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.buttonCardList);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "formMain";
            this.Text = "formMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formMain_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCardList;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClassList;
        private System.Windows.Forms.Button btnExportClasses;
        private System.Windows.Forms.Button btnUpgrades;
        private System.Windows.Forms.Button btnExportUpgrades;
    }
}

