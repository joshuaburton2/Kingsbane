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
            this.chkPlayable = new System.Windows.Forms.CheckBox();
            this.cmbDeck = new System.Windows.Forms.ComboBox();
            this.btnAddDeck = new System.Windows.Forms.Button();
            this.txtDeckName = new System.Windows.Forms.TextBox();
            this.lstDeckList = new System.Windows.Forms.ListView();
            this.colId = new System.Windows.Forms.ColumnHeader();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colType = new System.Windows.Forms.ColumnHeader();
            this.colClass = new System.Windows.Forms.ColumnHeader();
            this.colRarity = new System.Windows.Forms.ColumnHeader();
            this.chkNPCDeck = new System.Windows.Forms.CheckBox();
            this.btnSaveDeck = new System.Windows.Forms.Button();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtNewDeckName = new System.Windows.Forms.TextBox();
            this.btnAddCard = new System.Windows.Forms.Button();
            this.grpNPCProperties = new System.Windows.Forms.GroupBox();
            this.grpResouce2 = new System.Windows.Forms.GroupBox();
            this.txtResource2Prop2 = new System.Windows.Forms.TextBox();
            this.txtResource2Prop1 = new System.Windows.Forms.TextBox();
            this.lblResource2Prop2 = new System.Windows.Forms.Label();
            this.lblResource2Prop1 = new System.Windows.Forms.Label();
            this.grpResource1 = new System.Windows.Forms.GroupBox();
            this.txtResource1Prop2 = new System.Windows.Forms.TextBox();
            this.txtResource1Prop1 = new System.Windows.Forms.TextBox();
            this.lblResource1Prop2 = new System.Windows.Forms.Label();
            this.lblResource1Prop1 = new System.Windows.Forms.Label();
            this.lblInitialMulligan = new System.Windows.Forms.Label();
            this.lblHeroCard = new System.Windows.Forms.Label();
            this.txtInitialMulligan = new System.Windows.Forms.TextBox();
            this.btnHeroCard = new System.Windows.Forms.Button();
            this.txtHeroCard = new System.Windows.Forms.TextBox();
            this.lstUpgrades = new System.Windows.Forms.ListBox();
            this.btnAddUpgrade = new System.Windows.Forms.Button();
            this.lblUpgrades = new System.Windows.Forms.Label();
            this.grpNPCProperties.SuspendLayout();
            this.grpResouce2.SuspendLayout();
            this.grpResource1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(783, 559);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 42);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Location = new System.Drawing.Point(682, 559);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(95, 42);
            this.btnSaveAndClose.TabIndex = 1;
            this.btnSaveAndClose.Text = "Save and Close";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(577, 559);
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
            this.cmbClass.Size = new System.Drawing.Size(289, 33);
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
            this.txtStrengths.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStrengths.Size = new System.Drawing.Size(361, 55);
            this.txtStrengths.TabIndex = 12;
            // 
            // txtWeaknesses
            // 
            this.txtWeaknesses.Location = new System.Drawing.Point(12, 275);
            this.txtWeaknesses.Multiline = true;
            this.txtWeaknesses.Name = "txtWeaknesses";
            this.txtWeaknesses.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWeaknesses.Size = new System.Drawing.Size(361, 55);
            this.txtWeaknesses.TabIndex = 12;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 361);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(361, 125);
            this.txtDescription.TabIndex = 12;
            // 
            // chkPlayable
            // 
            this.chkPlayable.AutoSize = true;
            this.chkPlayable.Location = new System.Drawing.Point(13, 493);
            this.chkPlayable.Name = "chkPlayable";
            this.chkPlayable.Size = new System.Drawing.Size(86, 19);
            this.chkPlayable.TabIndex = 13;
            this.chkPlayable.Text = "Is Playable?";
            this.chkPlayable.UseVisualStyleBackColor = true;
            // 
            // cmbDeck
            // 
            this.cmbDeck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeck.FormattingEnabled = true;
            this.cmbDeck.Location = new System.Drawing.Point(394, 75);
            this.cmbDeck.Name = "cmbDeck";
            this.cmbDeck.Size = new System.Drawing.Size(326, 23);
            this.cmbDeck.TabIndex = 14;
            this.cmbDeck.SelectedIndexChanged += new System.EventHandler(this.cmbDeck_SelectedIndexChanged);
            // 
            // btnAddDeck
            // 
            this.btnAddDeck.Location = new System.Drawing.Point(645, 46);
            this.btnAddDeck.Name = "btnAddDeck";
            this.btnAddDeck.Size = new System.Drawing.Size(75, 23);
            this.btnAddDeck.TabIndex = 15;
            this.btnAddDeck.Text = "Add";
            this.btnAddDeck.UseVisualStyleBackColor = true;
            this.btnAddDeck.Click += new System.EventHandler(this.btnAddDeck_Click);
            // 
            // txtDeckName
            // 
            this.txtDeckName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDeckName.Location = new System.Drawing.Point(394, 103);
            this.txtDeckName.Name = "txtDeckName";
            this.txtDeckName.Size = new System.Drawing.Size(326, 29);
            this.txtDeckName.TabIndex = 16;
            // 
            // lstDeckList
            // 
            this.lstDeckList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colName,
            this.colType,
            this.colClass,
            this.colRarity});
            this.lstDeckList.FullRowSelect = true;
            this.lstDeckList.GridLines = true;
            this.lstDeckList.HideSelection = false;
            this.lstDeckList.Location = new System.Drawing.Point(394, 143);
            this.lstDeckList.MultiSelect = false;
            this.lstDeckList.Name = "lstDeckList";
            this.lstDeckList.Size = new System.Drawing.Size(464, 187);
            this.lstDeckList.TabIndex = 17;
            this.lstDeckList.UseCompatibleStateImageBehavior = false;
            this.lstDeckList.View = System.Windows.Forms.View.Details;
            this.lstDeckList.DoubleClick += new System.EventHandler(this.lstDeckList_DoubleClick);
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
            this.colName.Width = 120;
            // 
            // colType
            // 
            this.colType.Name = "colType";
            this.colType.Text = "Type";
            this.colType.Width = 80;
            // 
            // colClass
            // 
            this.colClass.Name = "colClass";
            this.colClass.Text = "Class";
            this.colClass.Width = 100;
            // 
            // colRarity
            // 
            this.colRarity.Name = "colRarity";
            this.colRarity.Text = "Rarity";
            this.colRarity.Width = 100;
            // 
            // chkNPCDeck
            // 
            this.chkNPCDeck.AutoSize = true;
            this.chkNPCDeck.Location = new System.Drawing.Point(394, 372);
            this.chkNPCDeck.Name = "chkNPCDeck";
            this.chkNPCDeck.Size = new System.Drawing.Size(84, 19);
            this.chkNPCDeck.TabIndex = 18;
            this.chkNPCDeck.Text = "NPC Deck?";
            this.chkNPCDeck.UseVisualStyleBackColor = true;
            this.chkNPCDeck.CheckedChanged += new System.EventHandler(this.chkNPCDeck_CheckedChanged);
            // 
            // btnSaveDeck
            // 
            this.btnSaveDeck.Location = new System.Drawing.Point(783, 103);
            this.btnSaveDeck.Name = "btnSaveDeck";
            this.btnSaveDeck.Size = new System.Drawing.Size(75, 29);
            this.btnSaveDeck.TabIndex = 19;
            this.btnSaveDeck.Text = "Save Deck";
            this.btnSaveDeck.UseVisualStyleBackColor = true;
            this.btnSaveDeck.Click += new System.EventHandler(this.btnSaveDeck_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(726, 103);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(51, 29);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtNewDeckName
            // 
            this.txtNewDeckName.Location = new System.Drawing.Point(394, 46);
            this.txtNewDeckName.Name = "txtNewDeckName";
            this.txtNewDeckName.Size = new System.Drawing.Size(245, 23);
            this.txtNewDeckName.TabIndex = 21;
            // 
            // btnAddCard
            // 
            this.btnAddCard.Location = new System.Drawing.Point(394, 343);
            this.btnAddCard.Name = "btnAddCard";
            this.btnAddCard.Size = new System.Drawing.Size(75, 23);
            this.btnAddCard.TabIndex = 22;
            this.btnAddCard.Text = "Add Card";
            this.btnAddCard.UseVisualStyleBackColor = true;
            this.btnAddCard.Click += new System.EventHandler(this.btnAddCard_Click);
            // 
            // grpNPCProperties
            // 
            this.grpNPCProperties.Controls.Add(this.grpResouce2);
            this.grpNPCProperties.Controls.Add(this.grpResource1);
            this.grpNPCProperties.Controls.Add(this.lblInitialMulligan);
            this.grpNPCProperties.Controls.Add(this.lblHeroCard);
            this.grpNPCProperties.Controls.Add(this.txtInitialMulligan);
            this.grpNPCProperties.Controls.Add(this.btnHeroCard);
            this.grpNPCProperties.Controls.Add(this.txtHeroCard);
            this.grpNPCProperties.Location = new System.Drawing.Point(394, 397);
            this.grpNPCProperties.Name = "grpNPCProperties";
            this.grpNPCProperties.Size = new System.Drawing.Size(463, 156);
            this.grpNPCProperties.TabIndex = 23;
            this.grpNPCProperties.TabStop = false;
            this.grpNPCProperties.Text = "NPC Deck Properties";
            // 
            // grpResouce2
            // 
            this.grpResouce2.Controls.Add(this.txtResource2Prop2);
            this.grpResouce2.Controls.Add(this.txtResource2Prop1);
            this.grpResouce2.Controls.Add(this.lblResource2Prop2);
            this.grpResouce2.Controls.Add(this.lblResource2Prop1);
            this.grpResouce2.Location = new System.Drawing.Point(235, 68);
            this.grpResouce2.Name = "grpResouce2";
            this.grpResouce2.Size = new System.Drawing.Size(215, 76);
            this.grpResouce2.TabIndex = 6;
            this.grpResouce2.TabStop = false;
            this.grpResouce2.Text = "Resource 2";
            // 
            // txtResource2Prop2
            // 
            this.txtResource2Prop2.Location = new System.Drawing.Point(74, 50);
            this.txtResource2Prop2.Name = "txtResource2Prop2";
            this.txtResource2Prop2.Size = new System.Drawing.Size(135, 23);
            this.txtResource2Prop2.TabIndex = 2;
            // 
            // txtResource2Prop1
            // 
            this.txtResource2Prop1.Location = new System.Drawing.Point(74, 20);
            this.txtResource2Prop1.Name = "txtResource2Prop1";
            this.txtResource2Prop1.Size = new System.Drawing.Size(135, 23);
            this.txtResource2Prop1.TabIndex = 1;
            // 
            // lblResource2Prop2
            // 
            this.lblResource2Prop2.AutoSize = true;
            this.lblResource2Prop2.Location = new System.Drawing.Point(7, 53);
            this.lblResource2Prop2.Name = "lblResource2Prop2";
            this.lblResource2Prop2.Size = new System.Drawing.Size(61, 15);
            this.lblResource2Prop2.TabIndex = 0;
            this.lblResource2Prop2.Text = "Property 2";
            // 
            // lblResource2Prop1
            // 
            this.lblResource2Prop1.AutoSize = true;
            this.lblResource2Prop1.Location = new System.Drawing.Point(7, 23);
            this.lblResource2Prop1.Name = "lblResource2Prop1";
            this.lblResource2Prop1.Size = new System.Drawing.Size(61, 15);
            this.lblResource2Prop1.TabIndex = 0;
            this.lblResource2Prop1.Text = "Property 1";
            // 
            // grpResource1
            // 
            this.grpResource1.Controls.Add(this.txtResource1Prop2);
            this.grpResource1.Controls.Add(this.txtResource1Prop1);
            this.grpResource1.Controls.Add(this.lblResource1Prop2);
            this.grpResource1.Controls.Add(this.lblResource1Prop1);
            this.grpResource1.Location = new System.Drawing.Point(6, 65);
            this.grpResource1.Name = "grpResource1";
            this.grpResource1.Size = new System.Drawing.Size(215, 76);
            this.grpResource1.TabIndex = 6;
            this.grpResource1.TabStop = false;
            this.grpResource1.Text = "Resource 1";
            // 
            // txtResource1Prop2
            // 
            this.txtResource1Prop2.Location = new System.Drawing.Point(74, 50);
            this.txtResource1Prop2.Name = "txtResource1Prop2";
            this.txtResource1Prop2.Size = new System.Drawing.Size(135, 23);
            this.txtResource1Prop2.TabIndex = 2;
            // 
            // txtResource1Prop1
            // 
            this.txtResource1Prop1.Location = new System.Drawing.Point(74, 20);
            this.txtResource1Prop1.Name = "txtResource1Prop1";
            this.txtResource1Prop1.Size = new System.Drawing.Size(135, 23);
            this.txtResource1Prop1.TabIndex = 1;
            // 
            // lblResource1Prop2
            // 
            this.lblResource1Prop2.AutoSize = true;
            this.lblResource1Prop2.Location = new System.Drawing.Point(7, 53);
            this.lblResource1Prop2.Name = "lblResource1Prop2";
            this.lblResource1Prop2.Size = new System.Drawing.Size(61, 15);
            this.lblResource1Prop2.TabIndex = 0;
            this.lblResource1Prop2.Text = "Property 2";
            // 
            // lblResource1Prop1
            // 
            this.lblResource1Prop1.AutoSize = true;
            this.lblResource1Prop1.Location = new System.Drawing.Point(7, 23);
            this.lblResource1Prop1.Name = "lblResource1Prop1";
            this.lblResource1Prop1.Size = new System.Drawing.Size(61, 15);
            this.lblResource1Prop1.TabIndex = 0;
            this.lblResource1Prop1.Text = "Property 1";
            // 
            // lblInitialMulligan
            // 
            this.lblInitialMulligan.AutoSize = true;
            this.lblInitialMulligan.Location = new System.Drawing.Point(313, 19);
            this.lblInitialMulligan.Name = "lblInitialMulligan";
            this.lblInitialMulligan.Size = new System.Drawing.Size(86, 15);
            this.lblInitialMulligan.TabIndex = 4;
            this.lblInitialMulligan.Text = "Initial Mulligan";
            // 
            // lblHeroCard
            // 
            this.lblHeroCard.AutoSize = true;
            this.lblHeroCard.Location = new System.Drawing.Point(6, 19);
            this.lblHeroCard.Name = "lblHeroCard";
            this.lblHeroCard.Size = new System.Drawing.Size(61, 15);
            this.lblHeroCard.TabIndex = 3;
            this.lblHeroCard.Text = "Hero Card";
            // 
            // txtInitialMulligan
            // 
            this.txtInitialMulligan.Location = new System.Drawing.Point(313, 39);
            this.txtInitialMulligan.Name = "txtInitialMulligan";
            this.txtInitialMulligan.Size = new System.Drawing.Size(144, 23);
            this.txtInitialMulligan.TabIndex = 2;
            // 
            // btnHeroCard
            // 
            this.btnHeroCard.Location = new System.Drawing.Point(211, 37);
            this.btnHeroCard.Name = "btnHeroCard";
            this.btnHeroCard.Size = new System.Drawing.Size(96, 23);
            this.btnHeroCard.TabIndex = 1;
            this.btnHeroCard.Text = "Add Hero Card";
            this.btnHeroCard.UseVisualStyleBackColor = true;
            // 
            // txtHeroCard
            // 
            this.txtHeroCard.Location = new System.Drawing.Point(6, 37);
            this.txtHeroCard.Name = "txtHeroCard";
            this.txtHeroCard.ReadOnly = true;
            this.txtHeroCard.Size = new System.Drawing.Size(199, 23);
            this.txtHeroCard.TabIndex = 0;
            // 
            // lstUpgrades
            // 
            this.lstUpgrades.FormattingEnabled = true;
            this.lstUpgrades.ItemHeight = 15;
            this.lstUpgrades.Location = new System.Drawing.Point(636, 336);
            this.lstUpgrades.Name = "lstUpgrades";
            this.lstUpgrades.Size = new System.Drawing.Size(222, 49);
            this.lstUpgrades.TabIndex = 24;
            // 
            // btnAddUpgrade
            // 
            this.btnAddUpgrade.Location = new System.Drawing.Point(597, 336);
            this.btnAddUpgrade.Name = "btnAddUpgrade";
            this.btnAddUpgrade.Size = new System.Drawing.Size(33, 23);
            this.btnAddUpgrade.TabIndex = 25;
            this.btnAddUpgrade.Text = "+";
            this.btnAddUpgrade.UseVisualStyleBackColor = true;
            // 
            // lblUpgrades
            // 
            this.lblUpgrades.AutoSize = true;
            this.lblUpgrades.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUpgrades.Location = new System.Drawing.Point(515, 338);
            this.lblUpgrades.Name = "lblUpgrades";
            this.lblUpgrades.Size = new System.Drawing.Size(76, 20);
            this.lblUpgrades.TabIndex = 26;
            this.lblUpgrades.Text = "Upgrades";
            // 
            // formEditClasses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 609);
            this.Controls.Add(this.lblUpgrades);
            this.Controls.Add(this.btnAddUpgrade);
            this.Controls.Add(this.lstUpgrades);
            this.Controls.Add(this.grpNPCProperties);
            this.Controls.Add(this.btnAddCard);
            this.Controls.Add(this.txtNewDeckName);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSaveDeck);
            this.Controls.Add(this.chkNPCDeck);
            this.Controls.Add(this.lstDeckList);
            this.Controls.Add(this.txtDeckName);
            this.Controls.Add(this.btnAddDeck);
            this.Controls.Add(this.cmbDeck);
            this.Controls.Add(this.chkPlayable);
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
            this.grpNPCProperties.ResumeLayout(false);
            this.grpNPCProperties.PerformLayout();
            this.grpResouce2.ResumeLayout(false);
            this.grpResouce2.PerformLayout();
            this.grpResource1.ResumeLayout(false);
            this.grpResource1.PerformLayout();
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
        private System.Windows.Forms.CheckBox chkPlayable;
        private System.Windows.Forms.ComboBox cmbDeck;
        private System.Windows.Forms.Button btnAddDeck;
        private System.Windows.Forms.TextBox txtDeckName;
        private System.Windows.Forms.ListView lstDeckList;
        private System.Windows.Forms.CheckBox chkNPCDeck;
        private System.Windows.Forms.Button btnSaveDeck;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colRarity;
        private System.Windows.Forms.ColumnHeader colClass;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtNewDeckName;
        private System.Windows.Forms.Button btnAddCard;
        private System.Windows.Forms.GroupBox grpNPCProperties;
        private System.Windows.Forms.Label lblInitialMulligan;
        private System.Windows.Forms.Label lblHeroCard;
        private System.Windows.Forms.TextBox txtInitialMulligan;
        private System.Windows.Forms.Button btnHeroCard;
        private System.Windows.Forms.TextBox txtHeroCard;
        private System.Windows.Forms.GroupBox grpResource1;
        private System.Windows.Forms.Label lblResource1Prop1;
        private System.Windows.Forms.GroupBox grpResouce2;
        private System.Windows.Forms.TextBox txtResource2Prop2;
        private System.Windows.Forms.TextBox txtResource2Prop1;
        private System.Windows.Forms.Label lblResource2Prop2;
        private System.Windows.Forms.Label lblResource2Prop1;
        private System.Windows.Forms.TextBox txtResource1Prop2;
        private System.Windows.Forms.TextBox txtResource1Prop1;
        private System.Windows.Forms.Label lblResource1Prop2;
        private System.Windows.Forms.ListBox lstUpgrades;
        private System.Windows.Forms.Button btnAddUpgrade;
        private System.Windows.Forms.Label lblUpgrades;
    }
}