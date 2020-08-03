namespace Kingsbane.App
{
    partial class formCardEdit
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
            this.labelName = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.lblImage = new System.Windows.Forms.Label();
            this.txtImageName = new System.Windows.Forms.TextBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.lblRarity = new System.Windows.Forms.Label();
            this.cmbRarity = new System.Windows.Forms.ComboBox();
            this.lblResourceHeader = new System.Windows.Forms.Label();
            this.lblDevotion = new System.Windows.Forms.Label();
            this.txtDevotion = new System.Windows.Forms.TextBox();
            this.lblEnergy = new System.Windows.Forms.Label();
            this.txtEnergy = new System.Windows.Forms.TextBox();
            this.lblGold = new System.Windows.Forms.Label();
            this.txtGold = new System.Windows.Forms.TextBox();
            this.lblKnowledge = new System.Windows.Forms.Label();
            this.txtKnowledge = new System.Windows.Forms.TextBox();
            this.lblMana = new System.Windows.Forms.Label();
            this.txtMana = new System.Windows.Forms.TextBox();
            this.lblWild = new System.Windows.Forms.Label();
            this.txtWild = new System.Windows.Forms.TextBox();
            this.lblNeutral = new System.Windows.Forms.Label();
            this.txtNeutral = new System.Windows.Forms.TextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.txtCardText = new System.Windows.Forms.TextBox();
            this.lblLoreText = new System.Windows.Forms.Label();
            this.txtLoreText = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.cmbSet = new System.Windows.Forms.ComboBox();
            this.lblSet = new System.Windows.Forms.Label();
            this.lblTags = new System.Windows.Forms.Label();
            this.lstTags = new System.Windows.Forms.ListBox();
            this.lblSynergies = new System.Windows.Forms.Label();
            this.lstSynergies = new System.Windows.Forms.ListBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.grpUnit = new System.Windows.Forms.GroupBox();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.txtRange = new System.Windows.Forms.TextBox();
            this.lblRange = new System.Windows.Forms.Label();
            this.txtHealth = new System.Windows.Forms.TextBox();
            this.lblHealth = new System.Windows.Forms.Label();
            this.txtAttack = new System.Windows.Forms.TextBox();
            this.lblAttack = new System.Windows.Forms.Label();
            this.txtUnitTag = new System.Windows.Forms.TextBox();
            this.lblUnitTag = new System.Windows.Forms.Label();
            this.grpItem = new System.Windows.Forms.GroupBox();
            this.txtDurability = new System.Windows.Forms.TextBox();
            this.lblDurability = new System.Windows.Forms.Label();
            this.txtItemTag = new System.Windows.Forms.TextBox();
            this.lblItemTag = new System.Windows.Forms.Label();
            this.grpSpell = new System.Windows.Forms.GroupBox();
            this.txtSpellRange = new System.Windows.Forms.TextBox();
            this.lblSpellRange = new System.Windows.Forms.Label();
            this.txtSpellType = new System.Windows.Forms.TextBox();
            this.lblSpellType = new System.Windows.Forms.Label();
            this.chkDevotion = new System.Windows.Forms.CheckBox();
            this.chkEnergy = new System.Windows.Forms.CheckBox();
            this.chkGold = new System.Windows.Forms.CheckBox();
            this.chkKnowledge = new System.Windows.Forms.CheckBox();
            this.chkMana = new System.Windows.Forms.CheckBox();
            this.chkWild = new System.Windows.Forms.CheckBox();
            this.chkNeutral = new System.Windows.Forms.CheckBox();
            this.btnAddTag = new System.Windows.Forms.Button();
            this.btnAddSynergy = new System.Windows.Forms.Button();
            this.lblRelatedCards = new System.Windows.Forms.Label();
            this.lstRelatedCards = new System.Windows.Forms.ListBox();
            this.btnAddRelatedCard = new System.Windows.Forms.Button();
            this.grpUnit.SuspendLayout();
            this.grpItem.SuspendLayout();
            this.grpSpell.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelName.Location = new System.Drawing.Point(12, 12);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(71, 30);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            // 
            // textName
            // 
            this.textName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textName.Location = new System.Drawing.Point(117, 12);
            this.textName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(571, 35);
            this.textName.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(430, 964);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(82, 22);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(518, 964);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(82, 22);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(606, 964);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(82, 22);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(12, 60);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(75, 15);
            this.lblImage.TabIndex = 4;
            this.lblImage.Text = "Image Name";
            // 
            // txtImageName
            // 
            this.txtImageName.Location = new System.Drawing.Point(117, 60);
            this.txtImageName.Name = "txtImageName";
            this.txtImageName.Size = new System.Drawing.Size(263, 23);
            this.txtImageName.TabIndex = 5;
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(12, 93);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(34, 15);
            this.lblClass.TabIndex = 6;
            this.lblClass.Text = "Class";
            // 
            // cmbClass
            // 
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(117, 93);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(159, 23);
            this.cmbClass.TabIndex = 7;
            // 
            // lblRarity
            // 
            this.lblRarity.AutoSize = true;
            this.lblRarity.Location = new System.Drawing.Point(297, 93);
            this.lblRarity.Name = "lblRarity";
            this.lblRarity.Size = new System.Drawing.Size(37, 15);
            this.lblRarity.TabIndex = 8;
            this.lblRarity.Text = "Rarity";
            // 
            // cmbRarity
            // 
            this.cmbRarity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRarity.FormattingEnabled = true;
            this.cmbRarity.Location = new System.Drawing.Point(356, 93);
            this.cmbRarity.Name = "cmbRarity";
            this.cmbRarity.Size = new System.Drawing.Size(148, 23);
            this.cmbRarity.TabIndex = 9;
            // 
            // lblResourceHeader
            // 
            this.lblResourceHeader.AutoSize = true;
            this.lblResourceHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblResourceHeader.Location = new System.Drawing.Point(12, 126);
            this.lblResourceHeader.Name = "lblResourceHeader";
            this.lblResourceHeader.Size = new System.Drawing.Size(86, 21);
            this.lblResourceHeader.TabIndex = 10;
            this.lblResourceHeader.Text = "Resources";
            // 
            // lblDevotion
            // 
            this.lblDevotion.AutoSize = true;
            this.lblDevotion.Location = new System.Drawing.Point(12, 160);
            this.lblDevotion.Name = "lblDevotion";
            this.lblDevotion.Size = new System.Drawing.Size(55, 15);
            this.lblDevotion.TabIndex = 11;
            this.lblDevotion.Text = "Devotion";
            // 
            // txtDevotion
            // 
            this.txtDevotion.Location = new System.Drawing.Point(107, 157);
            this.txtDevotion.Name = "txtDevotion";
            this.txtDevotion.Size = new System.Drawing.Size(100, 23);
            this.txtDevotion.TabIndex = 12;
            // 
            // lblEnergy
            // 
            this.lblEnergy.AutoSize = true;
            this.lblEnergy.Location = new System.Drawing.Point(12, 189);
            this.lblEnergy.Name = "lblEnergy";
            this.lblEnergy.Size = new System.Drawing.Size(43, 15);
            this.lblEnergy.TabIndex = 11;
            this.lblEnergy.Text = "Energy";
            // 
            // txtEnergy
            // 
            this.txtEnergy.Location = new System.Drawing.Point(107, 186);
            this.txtEnergy.Name = "txtEnergy";
            this.txtEnergy.Size = new System.Drawing.Size(100, 23);
            this.txtEnergy.TabIndex = 12;
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Location = new System.Drawing.Point(12, 218);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(32, 15);
            this.lblGold.TabIndex = 11;
            this.lblGold.Text = "Gold";
            // 
            // txtGold
            // 
            this.txtGold.Location = new System.Drawing.Point(107, 215);
            this.txtGold.Name = "txtGold";
            this.txtGold.Size = new System.Drawing.Size(100, 23);
            this.txtGold.TabIndex = 12;
            // 
            // lblKnowledge
            // 
            this.lblKnowledge.AutoSize = true;
            this.lblKnowledge.Location = new System.Drawing.Point(12, 247);
            this.lblKnowledge.Name = "lblKnowledge";
            this.lblKnowledge.Size = new System.Drawing.Size(66, 15);
            this.lblKnowledge.TabIndex = 11;
            this.lblKnowledge.Text = "Knowledge";
            // 
            // txtKnowledge
            // 
            this.txtKnowledge.Location = new System.Drawing.Point(107, 244);
            this.txtKnowledge.Name = "txtKnowledge";
            this.txtKnowledge.Size = new System.Drawing.Size(100, 23);
            this.txtKnowledge.TabIndex = 12;
            // 
            // lblMana
            // 
            this.lblMana.AutoSize = true;
            this.lblMana.Location = new System.Drawing.Point(12, 276);
            this.lblMana.Name = "lblMana";
            this.lblMana.Size = new System.Drawing.Size(37, 15);
            this.lblMana.TabIndex = 11;
            this.lblMana.Text = "Mana";
            // 
            // txtMana
            // 
            this.txtMana.Location = new System.Drawing.Point(107, 273);
            this.txtMana.Name = "txtMana";
            this.txtMana.Size = new System.Drawing.Size(100, 23);
            this.txtMana.TabIndex = 12;
            // 
            // lblWild
            // 
            this.lblWild.AutoSize = true;
            this.lblWild.Location = new System.Drawing.Point(12, 305);
            this.lblWild.Name = "lblWild";
            this.lblWild.Size = new System.Drawing.Size(31, 15);
            this.lblWild.TabIndex = 11;
            this.lblWild.Text = "Wild";
            // 
            // txtWild
            // 
            this.txtWild.Location = new System.Drawing.Point(107, 302);
            this.txtWild.Name = "txtWild";
            this.txtWild.Size = new System.Drawing.Size(100, 23);
            this.txtWild.TabIndex = 12;
            // 
            // lblNeutral
            // 
            this.lblNeutral.AutoSize = true;
            this.lblNeutral.Location = new System.Drawing.Point(12, 334);
            this.lblNeutral.Name = "lblNeutral";
            this.lblNeutral.Size = new System.Drawing.Size(46, 15);
            this.lblNeutral.TabIndex = 11;
            this.lblNeutral.Text = "Neutral";
            // 
            // txtNeutral
            // 
            this.txtNeutral.Location = new System.Drawing.Point(107, 331);
            this.txtNeutral.Name = "txtNeutral";
            this.txtNeutral.Size = new System.Drawing.Size(100, 23);
            this.txtNeutral.TabIndex = 12;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblText.Location = new System.Drawing.Point(222, 126);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(81, 21);
            this.lblText.TabIndex = 13;
            this.lblText.Text = "Card Text";
            // 
            // txtCardText
            // 
            this.txtCardText.Location = new System.Drawing.Point(222, 151);
            this.txtCardText.Multiline = true;
            this.txtCardText.Name = "txtCardText";
            this.txtCardText.Size = new System.Drawing.Size(439, 80);
            this.txtCardText.TabIndex = 14;
            // 
            // lblLoreText
            // 
            this.lblLoreText.AutoSize = true;
            this.lblLoreText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLoreText.Location = new System.Drawing.Point(222, 234);
            this.lblLoreText.Name = "lblLoreText";
            this.lblLoreText.Size = new System.Drawing.Size(79, 21);
            this.lblLoreText.TabIndex = 13;
            this.lblLoreText.Text = "Lore Text";
            // 
            // txtLoreText
            // 
            this.txtLoreText.Location = new System.Drawing.Point(222, 258);
            this.txtLoreText.Multiline = true;
            this.txtLoreText.Name = "txtLoreText";
            this.txtLoreText.Size = new System.Drawing.Size(439, 80);
            this.txtLoreText.TabIndex = 14;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNotes.Location = new System.Drawing.Point(224, 341);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(55, 21);
            this.lblNotes.TabIndex = 13;
            this.lblNotes.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(224, 365);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(439, 80);
            this.txtNotes.TabIndex = 14;
            // 
            // cmbSet
            // 
            this.cmbSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSet.FormattingEnabled = true;
            this.cmbSet.Location = new System.Drawing.Point(74, 393);
            this.cmbSet.Name = "cmbSet";
            this.cmbSet.Size = new System.Drawing.Size(133, 23);
            this.cmbSet.TabIndex = 15;
            // 
            // lblSet
            // 
            this.lblSet.AutoSize = true;
            this.lblSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSet.Location = new System.Drawing.Point(12, 393);
            this.lblSet.Name = "lblSet";
            this.lblSet.Size = new System.Drawing.Size(34, 21);
            this.lblSet.TabIndex = 16;
            this.lblSet.Text = "Set";
            // 
            // lblTags
            // 
            this.lblTags.AutoSize = true;
            this.lblTags.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTags.Location = new System.Drawing.Point(12, 469);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(44, 21);
            this.lblTags.TabIndex = 17;
            this.lblTags.Text = "Tags";
            // 
            // lstTags
            // 
            this.lstTags.FormattingEnabled = true;
            this.lstTags.ItemHeight = 15;
            this.lstTags.Items.AddRange(new object[] {
            ""});
            this.lstTags.Location = new System.Drawing.Point(75, 498);
            this.lstTags.Name = "lstTags";
            this.lstTags.Size = new System.Drawing.Size(228, 94);
            this.lstTags.TabIndex = 19;
            this.lstTags.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickListRecord);
            // 
            // lblSynergies
            // 
            this.lblSynergies.AutoSize = true;
            this.lblSynergies.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSynergies.Location = new System.Drawing.Point(344, 469);
            this.lblSynergies.Name = "lblSynergies";
            this.lblSynergies.Size = new System.Drawing.Size(84, 21);
            this.lblSynergies.TabIndex = 17;
            this.lblSynergies.Text = "Synergies";
            // 
            // lstSynergies
            // 
            this.lstSynergies.FormattingEnabled = true;
            this.lstSynergies.ItemHeight = 15;
            this.lstSynergies.Items.AddRange(new object[] {
            ""});
            this.lstSynergies.Location = new System.Drawing.Point(435, 496);
            this.lstSynergies.Name = "lstSynergies";
            this.lstSynergies.Size = new System.Drawing.Size(228, 94);
            this.lstSynergies.TabIndex = 19;
            this.lstSynergies.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickListRecord);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblType.Location = new System.Drawing.Point(12, 724);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(46, 21);
            this.lblType.TabIndex = 20;
            this.lblType.Text = "Type";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(75, 726);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(120, 23);
            this.cmbType.TabIndex = 21;
            // 
            // grpUnit
            // 
            this.grpUnit.Controls.Add(this.txtSpeed);
            this.grpUnit.Controls.Add(this.lblSpeed);
            this.grpUnit.Controls.Add(this.txtRange);
            this.grpUnit.Controls.Add(this.lblRange);
            this.grpUnit.Controls.Add(this.txtHealth);
            this.grpUnit.Controls.Add(this.lblHealth);
            this.grpUnit.Controls.Add(this.txtAttack);
            this.grpUnit.Controls.Add(this.lblAttack);
            this.grpUnit.Controls.Add(this.txtUnitTag);
            this.grpUnit.Controls.Add(this.lblUnitTag);
            this.grpUnit.Enabled = false;
            this.grpUnit.Location = new System.Drawing.Point(12, 755);
            this.grpUnit.Name = "grpUnit";
            this.grpUnit.Size = new System.Drawing.Size(651, 61);
            this.grpUnit.TabIndex = 22;
            this.grpUnit.TabStop = false;
            this.grpUnit.Text = "Unit Fields";
            // 
            // txtSpeed
            // 
            this.txtSpeed.Location = new System.Drawing.Point(557, 26);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(44, 23);
            this.txtSpeed.TabIndex = 3;
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(512, 29);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(39, 15);
            this.lblSpeed.TabIndex = 2;
            this.lblSpeed.Text = "Speed";
            // 
            // txtRange
            // 
            this.txtRange.Location = new System.Drawing.Point(462, 26);
            this.txtRange.Name = "txtRange";
            this.txtRange.Size = new System.Drawing.Size(44, 23);
            this.txtRange.TabIndex = 3;
            // 
            // lblRange
            // 
            this.lblRange.AutoSize = true;
            this.lblRange.Location = new System.Drawing.Point(416, 29);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(40, 15);
            this.lblRange.TabIndex = 2;
            this.lblRange.Text = "Range";
            // 
            // txtHealth
            // 
            this.txtHealth.Location = new System.Drawing.Point(366, 26);
            this.txtHealth.Name = "txtHealth";
            this.txtHealth.Size = new System.Drawing.Size(44, 23);
            this.txtHealth.TabIndex = 3;
            // 
            // lblHealth
            // 
            this.lblHealth.AutoSize = true;
            this.lblHealth.Location = new System.Drawing.Point(318, 29);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(42, 15);
            this.lblHealth.TabIndex = 2;
            this.lblHealth.Text = "Health";
            // 
            // txtAttack
            // 
            this.txtAttack.Location = new System.Drawing.Point(268, 26);
            this.txtAttack.Name = "txtAttack";
            this.txtAttack.Size = new System.Drawing.Size(44, 23);
            this.txtAttack.TabIndex = 3;
            // 
            // lblAttack
            // 
            this.lblAttack.AutoSize = true;
            this.lblAttack.Location = new System.Drawing.Point(226, 29);
            this.lblAttack.Name = "lblAttack";
            this.lblAttack.Size = new System.Drawing.Size(41, 15);
            this.lblAttack.TabIndex = 2;
            this.lblAttack.Text = "Attack";
            // 
            // txtUnitTag
            // 
            this.txtUnitTag.Location = new System.Drawing.Point(83, 26);
            this.txtUnitTag.Name = "txtUnitTag";
            this.txtUnitTag.Size = new System.Drawing.Size(135, 23);
            this.txtUnitTag.TabIndex = 1;
            // 
            // lblUnitTag
            // 
            this.lblUnitTag.AutoSize = true;
            this.lblUnitTag.Location = new System.Drawing.Point(8, 29);
            this.lblUnitTag.Name = "lblUnitTag";
            this.lblUnitTag.Size = new System.Drawing.Size(50, 15);
            this.lblUnitTag.TabIndex = 0;
            this.lblUnitTag.Text = "Unit Tag";
            // 
            // grpItem
            // 
            this.grpItem.Controls.Add(this.txtDurability);
            this.grpItem.Controls.Add(this.lblDurability);
            this.grpItem.Controls.Add(this.txtItemTag);
            this.grpItem.Controls.Add(this.lblItemTag);
            this.grpItem.Location = new System.Drawing.Point(10, 889);
            this.grpItem.Name = "grpItem";
            this.grpItem.Size = new System.Drawing.Size(651, 61);
            this.grpItem.TabIndex = 22;
            this.grpItem.TabStop = false;
            this.grpItem.Text = "Item Fields";
            // 
            // txtDurability
            // 
            this.txtDurability.Location = new System.Drawing.Point(293, 22);
            this.txtDurability.Name = "txtDurability";
            this.txtDurability.Size = new System.Drawing.Size(44, 23);
            this.txtDurability.TabIndex = 3;
            // 
            // lblDurability
            // 
            this.lblDurability.AutoSize = true;
            this.lblDurability.Location = new System.Drawing.Point(229, 25);
            this.lblDurability.Name = "lblDurability";
            this.lblDurability.Size = new System.Drawing.Size(58, 15);
            this.lblDurability.TabIndex = 2;
            this.lblDurability.Text = "Durability";
            // 
            // txtItemTag
            // 
            this.txtItemTag.Location = new System.Drawing.Point(85, 22);
            this.txtItemTag.Name = "txtItemTag";
            this.txtItemTag.Size = new System.Drawing.Size(135, 23);
            this.txtItemTag.TabIndex = 1;
            // 
            // lblItemTag
            // 
            this.lblItemTag.AutoSize = true;
            this.lblItemTag.Location = new System.Drawing.Point(10, 30);
            this.lblItemTag.Name = "lblItemTag";
            this.lblItemTag.Size = new System.Drawing.Size(52, 15);
            this.lblItemTag.TabIndex = 0;
            this.lblItemTag.Text = "Item Tag";
            // 
            // grpSpell
            // 
            this.grpSpell.Controls.Add(this.txtSpellRange);
            this.grpSpell.Controls.Add(this.lblSpellRange);
            this.grpSpell.Controls.Add(this.txtSpellType);
            this.grpSpell.Controls.Add(this.lblSpellType);
            this.grpSpell.Location = new System.Drawing.Point(12, 822);
            this.grpSpell.Name = "grpSpell";
            this.grpSpell.Size = new System.Drawing.Size(651, 61);
            this.grpSpell.TabIndex = 22;
            this.grpSpell.TabStop = false;
            this.grpSpell.Text = "Spell Fields";
            // 
            // txtSpellRange
            // 
            this.txtSpellRange.Location = new System.Drawing.Point(272, 25);
            this.txtSpellRange.Name = "txtSpellRange";
            this.txtSpellRange.Size = new System.Drawing.Size(44, 23);
            this.txtSpellRange.TabIndex = 3;
            // 
            // lblSpellRange
            // 
            this.lblSpellRange.AutoSize = true;
            this.lblSpellRange.Location = new System.Drawing.Point(226, 28);
            this.lblSpellRange.Name = "lblSpellRange";
            this.lblSpellRange.Size = new System.Drawing.Size(40, 15);
            this.lblSpellRange.TabIndex = 2;
            this.lblSpellRange.Text = "Range";
            // 
            // txtSpellType
            // 
            this.txtSpellType.Location = new System.Drawing.Point(83, 25);
            this.txtSpellType.Name = "txtSpellType";
            this.txtSpellType.Size = new System.Drawing.Size(135, 23);
            this.txtSpellType.TabIndex = 1;
            // 
            // lblSpellType
            // 
            this.lblSpellType.AutoSize = true;
            this.lblSpellType.Location = new System.Drawing.Point(9, 28);
            this.lblSpellType.Name = "lblSpellType";
            this.lblSpellType.Size = new System.Drawing.Size(59, 15);
            this.lblSpellType.TabIndex = 0;
            this.lblSpellType.Text = "Spell Type";
            // 
            // chkDevotion
            // 
            this.chkDevotion.AutoSize = true;
            this.chkDevotion.Location = new System.Drawing.Point(83, 161);
            this.chkDevotion.Name = "chkDevotion";
            this.chkDevotion.Size = new System.Drawing.Size(15, 14);
            this.chkDevotion.TabIndex = 23;
            this.chkDevotion.UseVisualStyleBackColor = true;
            // 
            // chkEnergy
            // 
            this.chkEnergy.AutoSize = true;
            this.chkEnergy.Location = new System.Drawing.Point(83, 190);
            this.chkEnergy.Name = "chkEnergy";
            this.chkEnergy.Size = new System.Drawing.Size(15, 14);
            this.chkEnergy.TabIndex = 23;
            this.chkEnergy.UseVisualStyleBackColor = true;
            // 
            // chkGold
            // 
            this.chkGold.AutoSize = true;
            this.chkGold.Location = new System.Drawing.Point(83, 219);
            this.chkGold.Name = "chkGold";
            this.chkGold.Size = new System.Drawing.Size(15, 14);
            this.chkGold.TabIndex = 23;
            this.chkGold.UseVisualStyleBackColor = true;
            // 
            // chkKnowledge
            // 
            this.chkKnowledge.AutoSize = true;
            this.chkKnowledge.Location = new System.Drawing.Point(83, 248);
            this.chkKnowledge.Name = "chkKnowledge";
            this.chkKnowledge.Size = new System.Drawing.Size(15, 14);
            this.chkKnowledge.TabIndex = 23;
            this.chkKnowledge.UseVisualStyleBackColor = true;
            // 
            // chkMana
            // 
            this.chkMana.AutoSize = true;
            this.chkMana.Location = new System.Drawing.Point(83, 277);
            this.chkMana.Name = "chkMana";
            this.chkMana.Size = new System.Drawing.Size(15, 14);
            this.chkMana.TabIndex = 23;
            this.chkMana.UseVisualStyleBackColor = true;
            // 
            // chkWild
            // 
            this.chkWild.AutoSize = true;
            this.chkWild.Location = new System.Drawing.Point(83, 306);
            this.chkWild.Name = "chkWild";
            this.chkWild.Size = new System.Drawing.Size(15, 14);
            this.chkWild.TabIndex = 23;
            this.chkWild.UseVisualStyleBackColor = true;
            // 
            // chkNeutral
            // 
            this.chkNeutral.AutoSize = true;
            this.chkNeutral.Location = new System.Drawing.Point(83, 335);
            this.chkNeutral.Name = "chkNeutral";
            this.chkNeutral.Size = new System.Drawing.Size(15, 14);
            this.chkNeutral.TabIndex = 23;
            this.chkNeutral.UseVisualStyleBackColor = true;
            // 
            // btnAddTag
            // 
            this.btnAddTag.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddTag.Location = new System.Drawing.Point(74, 469);
            this.btnAddTag.Name = "btnAddTag";
            this.btnAddTag.Size = new System.Drawing.Size(41, 23);
            this.btnAddTag.TabIndex = 25;
            this.btnAddTag.Text = "+";
            this.btnAddTag.UseVisualStyleBackColor = true;
            this.btnAddTag.Click += new System.EventHandler(this.btnAddTag_Click);
            // 
            // btnAddSynergy
            // 
            this.btnAddSynergy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddSynergy.Location = new System.Drawing.Point(435, 467);
            this.btnAddSynergy.Name = "btnAddSynergy";
            this.btnAddSynergy.Size = new System.Drawing.Size(41, 23);
            this.btnAddSynergy.TabIndex = 25;
            this.btnAddSynergy.Text = "+";
            this.btnAddSynergy.UseVisualStyleBackColor = true;
            this.btnAddSynergy.Click += new System.EventHandler(this.btnAddSynergy_Click);
            // 
            // lblRelatedCards
            // 
            this.lblRelatedCards.AutoSize = true;
            this.lblRelatedCards.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRelatedCards.Location = new System.Drawing.Point(12, 609);
            this.lblRelatedCards.Name = "lblRelatedCards";
            this.lblRelatedCards.Size = new System.Drawing.Size(114, 21);
            this.lblRelatedCards.TabIndex = 17;
            this.lblRelatedCards.Text = "Related Cards";
            // 
            // lstRelatedCards
            // 
            this.lstRelatedCards.FormattingEnabled = true;
            this.lstRelatedCards.ItemHeight = 15;
            this.lstRelatedCards.Location = new System.Drawing.Point(103, 645);
            this.lstRelatedCards.Name = "lstRelatedCards";
            this.lstRelatedCards.Size = new System.Drawing.Size(560, 64);
            this.lstRelatedCards.TabIndex = 28;
            this.lstRelatedCards.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickListRecord);
            // 
            // btnAddRelatedCard
            // 
            this.btnAddRelatedCard.Location = new System.Drawing.Point(12, 645);
            this.btnAddRelatedCard.Name = "btnAddRelatedCard";
            this.btnAddRelatedCard.Size = new System.Drawing.Size(75, 64);
            this.btnAddRelatedCard.TabIndex = 29;
            this.btnAddRelatedCard.Text = "Add";
            this.btnAddRelatedCard.UseVisualStyleBackColor = true;
            this.btnAddRelatedCard.Click += new System.EventHandler(this.btnAddRelatedCard_Click);
            // 
            // formCardEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 998);
            this.Controls.Add(this.btnAddRelatedCard);
            this.Controls.Add(this.lstRelatedCards);
            this.Controls.Add(this.lblRelatedCards);
            this.Controls.Add(this.btnAddSynergy);
            this.Controls.Add(this.btnAddTag);
            this.Controls.Add(this.chkNeutral);
            this.Controls.Add(this.chkWild);
            this.Controls.Add(this.chkMana);
            this.Controls.Add(this.chkKnowledge);
            this.Controls.Add(this.chkGold);
            this.Controls.Add(this.chkEnergy);
            this.Controls.Add(this.chkDevotion);
            this.Controls.Add(this.grpSpell);
            this.Controls.Add(this.grpItem);
            this.Controls.Add(this.grpUnit);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lstSynergies);
            this.Controls.Add(this.lblSynergies);
            this.Controls.Add(this.lstTags);
            this.Controls.Add(this.lblTags);
            this.Controls.Add(this.lblSet);
            this.Controls.Add(this.cmbSet);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtLoreText);
            this.Controls.Add(this.lblLoreText);
            this.Controls.Add(this.txtCardText);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.txtNeutral);
            this.Controls.Add(this.lblNeutral);
            this.Controls.Add(this.txtWild);
            this.Controls.Add(this.lblWild);
            this.Controls.Add(this.txtMana);
            this.Controls.Add(this.lblMana);
            this.Controls.Add(this.txtKnowledge);
            this.Controls.Add(this.lblKnowledge);
            this.Controls.Add(this.txtGold);
            this.Controls.Add(this.lblGold);
            this.Controls.Add(this.txtEnergy);
            this.Controls.Add(this.lblEnergy);
            this.Controls.Add(this.txtDevotion);
            this.Controls.Add(this.lblDevotion);
            this.Controls.Add(this.lblResourceHeader);
            this.Controls.Add(this.cmbRarity);
            this.Controls.Add(this.lblRarity);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.txtImageName);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.labelName);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "formCardEdit";
            this.Text = "Edit Card";
            this.Load += new System.EventHandler(this.formCardEdit_Load);
            this.grpUnit.ResumeLayout(false);
            this.grpUnit.PerformLayout();
            this.grpItem.ResumeLayout(false);
            this.grpItem.PerformLayout();
            this.grpSpell.ResumeLayout(false);
            this.grpSpell.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.TextBox txtImageName;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label lblRarity;
        private System.Windows.Forms.ComboBox cmbRarity;
        private System.Windows.Forms.Label lblResourceHeader;
        private System.Windows.Forms.Label lblDevotion;
        private System.Windows.Forms.TextBox txtDevotion;
        private System.Windows.Forms.Label lblEnergy;
        private System.Windows.Forms.TextBox txtEnergy;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.TextBox txtGold;
        private System.Windows.Forms.Label lblKnowledge;
        private System.Windows.Forms.TextBox txtKnowledge;
        private System.Windows.Forms.Label lblMana;
        private System.Windows.Forms.TextBox txtMana;
        private System.Windows.Forms.Label lblWild;
        private System.Windows.Forms.TextBox txtWild;
        private System.Windows.Forms.Label lblNeutral;
        private System.Windows.Forms.TextBox txtNeutral;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox txtCardText;
        private System.Windows.Forms.Label lblLoreText;
        private System.Windows.Forms.TextBox txtLoreText;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.ComboBox cmbSet;
        private System.Windows.Forms.Label lblSet;
        private System.Windows.Forms.Label lblTags;
        private System.Windows.Forms.ListBox lstTags;
        private System.Windows.Forms.Label lblSynergies;
        private System.Windows.Forms.ListBox lstSynergies;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.GroupBox grpUnit;
        private System.Windows.Forms.GroupBox grpItem;
        private System.Windows.Forms.GroupBox grpSpell;
        private System.Windows.Forms.Label lblUnitTag;
        private System.Windows.Forms.TextBox txtUnitTag;
        private System.Windows.Forms.Label lblAttack;
        private System.Windows.Forms.TextBox txtAttack;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.TextBox txtRange;
        private System.Windows.Forms.Label lblRange;
        private System.Windows.Forms.TextBox txtHealth;
        private System.Windows.Forms.Label lblHealth;
        private System.Windows.Forms.TextBox txtSpellRange;
        private System.Windows.Forms.Label lblSpellRange;
        private System.Windows.Forms.TextBox txtSpellType;
        private System.Windows.Forms.Label lblSpellType;
        private System.Windows.Forms.TextBox txtDurability;
        private System.Windows.Forms.Label lblDurability;
        private System.Windows.Forms.TextBox txtItemTag;
        private System.Windows.Forms.Label lblItemTag;
        private System.Windows.Forms.CheckBox chkDevotion;
        private System.Windows.Forms.CheckBox chkEnergy;
        private System.Windows.Forms.CheckBox chkGold;
        private System.Windows.Forms.CheckBox chkKnowledge;
        private System.Windows.Forms.CheckBox chkMana;
        private System.Windows.Forms.CheckBox chkWild;
        private System.Windows.Forms.CheckBox chkNeutral;
        private System.Windows.Forms.Button btnAddTag;
        private System.Windows.Forms.Button btnAddSynergy;
        private System.Windows.Forms.Label lblRelatedCards;
        private System.Windows.Forms.ListBox lstRelatedCards;
        private System.Windows.Forms.Button btnAddRelatedCard;
    }
}