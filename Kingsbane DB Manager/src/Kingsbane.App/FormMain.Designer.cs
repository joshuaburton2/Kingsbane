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
            this.SuspendLayout();
            // 
            // buttonCardList
            // 
            this.buttonCardList.Location = new System.Drawing.Point(193, 69);
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
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 132);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.buttonCardList);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "formMain";
            this.Text = "formMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCardList;
        private System.Windows.Forms.Label lblTitle;
    }
}

