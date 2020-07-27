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
            this.SuspendLayout();
            // 
            // buttonCardList
            // 
            this.buttonCardList.Location = new System.Drawing.Point(12, 12);
            this.buttonCardList.Name = "buttonCardList";
            this.buttonCardList.Size = new System.Drawing.Size(94, 29);
            this.buttonCardList.TabIndex = 0;
            this.buttonCardList.Text = "Cards";
            this.buttonCardList.UseVisualStyleBackColor = true;
            this.buttonCardList.Click += new System.EventHandler(this.buttonCardList_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCardList);
            this.Name = "formMain";
            this.Text = "formMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCardList;
    }
}

