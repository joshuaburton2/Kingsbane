namespace Kingsbane.App
{
    partial class formMapEdit
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
            this.txtColourMap = new System.Windows.Forms.TextBox();
            this.lblColourMap = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.pnlMap = new System.Windows.Forms.Panel();
            this.lblScenario = new System.Windows.Forms.Label();
            this.cmbScenarioSelector = new System.Windows.Forms.ComboBox();
            this.btnAddScenario = new System.Windows.Forms.Button();
            this.txtScenarioName = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblScenarioDescription = new System.Windows.Forms.Label();
            this.lblScenarioRules = new System.Windows.Forms.Label();
            this.lstScenarioRules = new System.Windows.Forms.ListBox();
            this.lblEnemyDeck = new System.Windows.Forms.Label();
            this.txtEnemyDeck = new System.Windows.Forms.TextBox();
            this.btnSetEnemyDeck = new System.Windows.Forms.Button();
            this.btnDeleteScenario = new System.Windows.Forms.Button();
            this.pnlKey = new System.Windows.Forms.Panel();
            this.lblKeyTitle = new System.Windows.Forms.Label();
            this.cmbKeyType = new System.Windows.Forms.ComboBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.pnlKey.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtColourMap
            // 
            this.txtColourMap.Location = new System.Drawing.Point(12, 77);
            this.txtColourMap.Name = "txtColourMap";
            this.txtColourMap.Size = new System.Drawing.Size(276, 23);
            this.txtColourMap.TabIndex = 5;
            // 
            // lblColourMap
            // 
            this.lblColourMap.AutoSize = true;
            this.lblColourMap.Location = new System.Drawing.Point(11, 59);
            this.lblColourMap.Name = "lblColourMap";
            this.lblColourMap.Size = new System.Drawing.Size(105, 15);
            this.lblColourMap.TabIndex = 4;
            this.lblColourMap.Text = "Colour Map Name";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtName.Location = new System.Drawing.Point(88, 11);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(388, 35);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(11, 11);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(71, 30);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 103);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(94, 15);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Map Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 121);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(276, 74);
            this.txtDescription.TabIndex = 7;
            // 
            // pnlMap
            // 
            this.pnlMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMap.Location = new System.Drawing.Point(294, 77);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(400, 400);
            this.pnlMap.TabIndex = 8;
            // 
            // lblScenario
            // 
            this.lblScenario.AutoSize = true;
            this.lblScenario.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblScenario.Location = new System.Drawing.Point(11, 205);
            this.lblScenario.Name = "lblScenario";
            this.lblScenario.Size = new System.Drawing.Size(97, 30);
            this.lblScenario.TabIndex = 0;
            this.lblScenario.Text = "Scenario";
            // 
            // cmbScenarioSelector
            // 
            this.cmbScenarioSelector.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbScenarioSelector.FormattingEnabled = true;
            this.cmbScenarioSelector.Location = new System.Drawing.Point(11, 238);
            this.cmbScenarioSelector.Name = "cmbScenarioSelector";
            this.cmbScenarioSelector.Size = new System.Drawing.Size(208, 36);
            this.cmbScenarioSelector.TabIndex = 9;
            // 
            // btnAddScenario
            // 
            this.btnAddScenario.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddScenario.Location = new System.Drawing.Point(225, 279);
            this.btnAddScenario.Name = "btnAddScenario";
            this.btnAddScenario.Size = new System.Drawing.Size(63, 37);
            this.btnAddScenario.TabIndex = 10;
            this.btnAddScenario.Text = "+";
            this.btnAddScenario.UseVisualStyleBackColor = true;
            // 
            // txtScenarioName
            // 
            this.txtScenarioName.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtScenarioName.Location = new System.Drawing.Point(11, 279);
            this.txtScenarioName.Name = "txtScenarioName";
            this.txtScenarioName.Size = new System.Drawing.Size(208, 34);
            this.txtScenarioName.TabIndex = 11;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 334);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(276, 82);
            this.textBox2.TabIndex = 12;
            // 
            // lblScenarioDescription
            // 
            this.lblScenarioDescription.AutoSize = true;
            this.lblScenarioDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblScenarioDescription.Location = new System.Drawing.Point(12, 316);
            this.lblScenarioDescription.Name = "lblScenarioDescription";
            this.lblScenarioDescription.Size = new System.Drawing.Size(115, 15);
            this.lblScenarioDescription.TabIndex = 13;
            this.lblScenarioDescription.Text = "Scenario Description";
            // 
            // lblScenarioRules
            // 
            this.lblScenarioRules.AutoSize = true;
            this.lblScenarioRules.Location = new System.Drawing.Point(12, 449);
            this.lblScenarioRules.Name = "lblScenarioRules";
            this.lblScenarioRules.Size = new System.Drawing.Size(83, 15);
            this.lblScenarioRules.TabIndex = 14;
            this.lblScenarioRules.Text = "Scenario Rules";
            // 
            // lstScenarioRules
            // 
            this.lstScenarioRules.FormattingEnabled = true;
            this.lstScenarioRules.ItemHeight = 15;
            this.lstScenarioRules.Location = new System.Drawing.Point(11, 467);
            this.lstScenarioRules.Name = "lstScenarioRules";
            this.lstScenarioRules.Size = new System.Drawing.Size(276, 79);
            this.lstScenarioRules.TabIndex = 15;
            // 
            // lblEnemyDeck
            // 
            this.lblEnemyDeck.AutoSize = true;
            this.lblEnemyDeck.Location = new System.Drawing.Point(12, 426);
            this.lblEnemyDeck.Name = "lblEnemyDeck";
            this.lblEnemyDeck.Size = new System.Drawing.Size(72, 15);
            this.lblEnemyDeck.TabIndex = 16;
            this.lblEnemyDeck.Text = "Enemy Deck";
            // 
            // txtEnemyDeck
            // 
            this.txtEnemyDeck.Location = new System.Drawing.Point(90, 423);
            this.txtEnemyDeck.Name = "txtEnemyDeck";
            this.txtEnemyDeck.ReadOnly = true;
            this.txtEnemyDeck.Size = new System.Drawing.Size(129, 23);
            this.txtEnemyDeck.TabIndex = 17;
            // 
            // btnSetEnemyDeck
            // 
            this.btnSetEnemyDeck.Location = new System.Drawing.Point(225, 422);
            this.btnSetEnemyDeck.Name = "btnSetEnemyDeck";
            this.btnSetEnemyDeck.Size = new System.Drawing.Size(62, 23);
            this.btnSetEnemyDeck.TabIndex = 18;
            this.btnSetEnemyDeck.Text = "Set Deck";
            this.btnSetEnemyDeck.UseVisualStyleBackColor = true;
            // 
            // btnDeleteScenario
            // 
            this.btnDeleteScenario.Location = new System.Drawing.Point(225, 238);
            this.btnDeleteScenario.Name = "btnDeleteScenario";
            this.btnDeleteScenario.Size = new System.Drawing.Size(62, 36);
            this.btnDeleteScenario.TabIndex = 19;
            this.btnDeleteScenario.Text = "Delete";
            this.btnDeleteScenario.UseVisualStyleBackColor = true;
            // 
            // pnlKey
            // 
            this.pnlKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKey.Controls.Add(this.lblKeyTitle);
            this.pnlKey.Controls.Add(this.cmbKeyType);
            this.pnlKey.Location = new System.Drawing.Point(700, 77);
            this.pnlKey.Name = "pnlKey";
            this.pnlKey.Size = new System.Drawing.Size(200, 400);
            this.pnlKey.TabIndex = 20;
            // 
            // lblKeyTitle
            // 
            this.lblKeyTitle.AutoSize = true;
            this.lblKeyTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKeyTitle.Location = new System.Drawing.Point(10, 10);
            this.lblKeyTitle.Name = "lblKeyTitle";
            this.lblKeyTitle.Size = new System.Drawing.Size(44, 25);
            this.lblKeyTitle.TabIndex = 1;
            this.lblKeyTitle.Text = "Key";
            // 
            // cmbKeyType
            // 
            this.cmbKeyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKeyType.FormattingEnabled = true;
            this.cmbKeyType.Location = new System.Drawing.Point(10, 38);
            this.cmbKeyType.Name = "cmbKeyType";
            this.cmbKeyType.Size = new System.Drawing.Size(180, 23);
            this.cmbKeyType.TabIndex = 0;
            this.cmbKeyType.SelectedIndexChanged += new System.EventHandler(this.cmbKeyType_SelectedIndexChanged);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(820, 524);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(82, 22);
            this.buttonDelete.TabIndex = 22;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(732, 524);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(82, 22);
            this.buttonCancel.TabIndex = 24;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(644, 524);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(82, 22);
            this.buttonSave.TabIndex = 23;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // formMapEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 555);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.pnlKey);
            this.Controls.Add(this.btnDeleteScenario);
            this.Controls.Add(this.btnSetEnemyDeck);
            this.Controls.Add(this.txtEnemyDeck);
            this.Controls.Add(this.lblEnemyDeck);
            this.Controls.Add(this.lstScenarioRules);
            this.Controls.Add(this.lblScenarioRules);
            this.Controls.Add(this.lblScenarioDescription);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtScenarioName);
            this.Controls.Add(this.btnAddScenario);
            this.Controls.Add(this.cmbScenarioSelector);
            this.Controls.Add(this.lblScenario);
            this.Controls.Add(this.pnlMap);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblColourMap);
            this.Controls.Add(this.txtColourMap);
            this.Name = "formMapEdit";
            this.Text = "formMapEdit";
            this.Load += new System.EventHandler(this.formMapEdit_Load);
            this.pnlKey.ResumeLayout(false);
            this.pnlKey.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtColourMap;
        private System.Windows.Forms.Label lblColourMap;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Panel pnlMap;
        private System.Windows.Forms.Label lblScenario;
        private System.Windows.Forms.ComboBox cmbScenarioSelector;
        private System.Windows.Forms.Button btnAddScenario;
        private System.Windows.Forms.TextBox txtScenarioName;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblScenarioDescription;
        private System.Windows.Forms.Label lblScenarioRules;
        private System.Windows.Forms.ListBox lstScenarioRules;
        private System.Windows.Forms.Label lblEnemyDeck;
        private System.Windows.Forms.TextBox txtEnemyDeck;
        private System.Windows.Forms.Button btnSetEnemyDeck;
        private System.Windows.Forms.Button btnDeleteScenario;
        private System.Windows.Forms.Panel pnlKey;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox cmbKeyType;
        private System.Windows.Forms.Label lblKeyTitle;
    }
}