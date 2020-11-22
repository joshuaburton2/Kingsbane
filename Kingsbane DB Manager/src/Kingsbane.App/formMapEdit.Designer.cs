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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnAddScenario = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtColourMap
            // 
            this.txtColourMap.Location = new System.Drawing.Point(12, 77);
            this.txtColourMap.Name = "txtColourMap";
            this.txtColourMap.Size = new System.Drawing.Size(263, 23);
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
            this.txtDescription.Size = new System.Drawing.Size(276, 111);
            this.txtDescription.TabIndex = 7;
            // 
            // pnlMap
            // 
            this.pnlMap.Location = new System.Drawing.Point(294, 77);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(400, 400);
            this.pnlMap.TabIndex = 8;
            // 
            // lblScenario
            // 
            this.lblScenario.AutoSize = true;
            this.lblScenario.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblScenario.Location = new System.Drawing.Point(11, 242);
            this.lblScenario.Name = "lblScenario";
            this.lblScenario.Size = new System.Drawing.Size(97, 30);
            this.lblScenario.TabIndex = 0;
            this.lblScenario.Text = "Scenario";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(11, 275);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(231, 36);
            this.comboBox1.TabIndex = 9;
            // 
            // btnAddScenario
            // 
            this.btnAddScenario.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddScenario.Location = new System.Drawing.Point(248, 274);
            this.btnAddScenario.Name = "btnAddScenario";
            this.btnAddScenario.Size = new System.Drawing.Size(44, 37);
            this.btnAddScenario.TabIndex = 10;
            this.btnAddScenario.Text = "+";
            this.btnAddScenario.UseVisualStyleBackColor = true;
            // 
            // formMapEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 568);
            this.Controls.Add(this.btnAddScenario);
            this.Controls.Add(this.comboBox1);
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnAddScenario;
    }
}