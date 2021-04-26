using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static Kingsbane.App.formMapEdit;

namespace Kingsbane.App
{
    public partial class formEditObjective : Form
    {
        public ObjectiveData objectiveData;

        public formEditObjective()
        {
            InitializeComponent();
        }

        private void formEditObjective_Load(object sender, EventArgs e)
        {
            txtName.Text = objectiveData.Name;
            txtRed.Text = objectiveData.Color.R.ToString();
            txtGreen.Text = objectiveData.Color.G.ToString();
            txtBlue.Text = objectiveData.Color.B.ToString();
            txtColour.BackColor = objectiveData.Color;
        }

        private void ChangeColourValues(object sender, EventArgs e)
        {
            if (int.TryParse(txtRed.Text, out int red) && int.TryParse(txtGreen.Text, out int green) && int.TryParse(txtBlue.Text, out int blue))
            {
                var redVal = Math.Clamp(red, 0, 255);
                txtRed.Text = redVal.ToString();
                var greenVal = Math.Clamp(green, 0, 255);
                txtGreen.Text = greenVal.ToString();
                var blueVal = Math.Clamp(blue, 0, 255);
                txtBlue.Text = blueVal.ToString();

                objectiveData.Color = Color.FromArgb(redVal, greenVal, blueVal);
                txtColour.BackColor = objectiveData.Color;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            objectiveData.Name = txtName.Text;
            ChangeColourValues(null, null);

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            Close();
        }
    }
}
