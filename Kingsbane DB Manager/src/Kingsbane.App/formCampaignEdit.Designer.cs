
namespace Kingsbane.App
{
    partial class formCampaignEdit
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lstScenarios = new System.Windows.Forms.ListView();
            this.colId = new System.Windows.Forms.ColumnHeader();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colIndex = new System.Windows.Forms.ColumnHeader();
            this.lblScenarioList = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddScenario = new System.Windows.Forms.Button();
            this.btnIndexUp = new System.Windows.Forms.Button();
            this.btnIndexDown = new System.Windows.Forms.Button();
            this.lblIndexChange = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtName.Location = new System.Drawing.Point(102, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(341, 43);
            this.txtName.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(8, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(88, 37);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 81);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(431, 139);
            this.txtDescription.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 63);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(67, 15);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description";
            // 
            // lstScenarios
            // 
            this.lstScenarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstScenarios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colIndex,
            this.colName});
            this.lstScenarios.FullRowSelect = true;
            this.lstScenarios.GridLines = true;
            this.lstScenarios.HideSelection = false;
            this.lstScenarios.Location = new System.Drawing.Point(12, 262);
            this.lstScenarios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstScenarios.Name = "lstScenarios";
            this.lstScenarios.Size = new System.Drawing.Size(431, 218);
            this.lstScenarios.TabIndex = 6;
            this.lstScenarios.UseCompatibleStateImageBehavior = false;
            this.lstScenarios.View = System.Windows.Forms.View.Details;
            // 
            // colId
            // 
            this.colId.Name = "colId";
            this.colId.Text = "Id";
            // 
            // colName
            // 
            this.colName.Name = "colName";
            this.colName.Text = "Name";
            this.colName.Width = 300;
            // 
            // colIndex
            // 
            this.colIndex.Text = "Index";
            // 
            // lblScenarioList
            // 
            this.lblScenarioList.AutoSize = true;
            this.lblScenarioList.Location = new System.Drawing.Point(12, 236);
            this.lblScenarioList.Name = "lblScenarioList";
            this.lblScenarioList.Size = new System.Drawing.Size(73, 15);
            this.lblScenarioList.TabIndex = 7;
            this.lblScenarioList.Text = "Scenario List";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(361, 493);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(82, 22);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(273, 493);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 22);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(185, 493);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 22);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnAddScenario
            // 
            this.btnAddScenario.Location = new System.Drawing.Point(367, 236);
            this.btnAddScenario.Name = "btnAddScenario";
            this.btnAddScenario.Size = new System.Drawing.Size(75, 23);
            this.btnAddScenario.TabIndex = 11;
            this.btnAddScenario.Text = "Add";
            this.btnAddScenario.UseVisualStyleBackColor = true;
            // 
            // btnIndexUp
            // 
            this.btnIndexUp.Location = new System.Drawing.Point(236, 236);
            this.btnIndexUp.Name = "btnIndexUp";
            this.btnIndexUp.Size = new System.Drawing.Size(29, 23);
            this.btnIndexUp.TabIndex = 12;
            this.btnIndexUp.Text = "+";
            this.btnIndexUp.UseVisualStyleBackColor = true;
            // 
            // btnIndexDown
            // 
            this.btnIndexDown.Location = new System.Drawing.Point(271, 236);
            this.btnIndexDown.Name = "btnIndexDown";
            this.btnIndexDown.Size = new System.Drawing.Size(29, 23);
            this.btnIndexDown.TabIndex = 13;
            this.btnIndexDown.Text = "-";
            this.btnIndexDown.UseVisualStyleBackColor = true;
            // 
            // lblIndexChange
            // 
            this.lblIndexChange.AutoSize = true;
            this.lblIndexChange.Location = new System.Drawing.Point(194, 240);
            this.lblIndexChange.Name = "lblIndexChange";
            this.lblIndexChange.Size = new System.Drawing.Size(36, 15);
            this.lblIndexChange.TabIndex = 14;
            this.lblIndexChange.Text = "Index";
            // 
            // formCampaignEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 526);
            this.Controls.Add(this.lblIndexChange);
            this.Controls.Add(this.btnIndexDown);
            this.Controls.Add(this.btnIndexUp);
            this.Controls.Add(this.btnAddScenario);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblScenarioList);
            this.Controls.Add(this.lstScenarios);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Name = "formCampaignEdit";
            this.Text = "formCampaignEdit";
            this.Load += new System.EventHandler(this.formCampaignEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ListView lstScenarios;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.Label lblScenarioList;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ColumnHeader colIndex;
        private System.Windows.Forms.Button btnAddScenario;
        private System.Windows.Forms.Button btnIndexUp;
        private System.Windows.Forms.Button btnIndexDown;
        private System.Windows.Forms.Label lblIndexChange;
    }
}