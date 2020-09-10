using Kingsbane.Database;
using Kingsbane.Database.Models;
using Kingsbane.Database.Enums;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Kingsbane.App
{
    public partial class formEditClasses : Form
    {
        private readonly KingsbaneContext _context;
        private readonly IServiceProvider _serviceProvider;

        private CardClass selectedClass;

        public formEditClasses(
            IServiceProvider serviceProvider,
            KingsbaneContext context)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _context = context;
        }

        private void formEditClasses_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();

            cmbClass.SelectedIndex = 0;

            RefreshFields();
        }

        private void LoadComboBoxes()
        {
            var classes = Enum.GetValues(typeof(CardClasses)).Cast<CardClasses>().Select(x => new SelectListItem { Id = (int)x, Name = x.ToString() }).ToArray();
            cmbClass.Items.AddRange(classes);

            var resources = Enum.GetValues(typeof(Resources)).Cast<Resources>().Select(x => new SelectListItem { Id = (int)x, Name = x.ToString() }).ToArray();
            cmbDominant.Items.AddRange(resources);
            cmbSecondary.Items.AddRange(resources);
        }

        private void RefreshFields()
        {
            var classId = (CardClasses)((SelectListItem)cmbClass.SelectedItem).Id;
            selectedClass = _context.CardClasses.Single(x => x.Id == classId);

            cmbDominant.SelectedItem = SetComboItem(cmbDominant, (int)selectedClass.DominantResource);
            cmbSecondary.SelectedItem = SetComboItem(cmbSecondary, (int)selectedClass.SecondaryResource);

            txtPlaystyle.Text = selectedClass.Playstyle;
            txtStrengths.Text = selectedClass.Strengths;
            txtWeaknesses.Text = selectedClass.Weaknesses;
            txtDescription.Text = selectedClass.Description;

            chkPlayable.Checked = selectedClass.IsPlayable;
        }

        private SelectListItem SetComboItem(ComboBox cmb, int Id)
        {
            return cmb.Items.Cast<SelectListItem>().FirstOrDefault(x => x.Id == Id);
        }

        private void formEditClasses_FormClosed(object sender, FormClosedEventArgs e)
        {
            formMain formMain = new formMain(_serviceProvider, _context);
            formMain.Show();
        }

        private void SaveClass()
        {
            selectedClass.DominantResource = (Resources)((SelectListItem)cmbDominant.SelectedItem).Id;
            selectedClass.SecondaryResource = (Resources)((SelectListItem)cmbSecondary.SelectedItem).Id;
            selectedClass.Playstyle = txtPlaystyle.Text;
            selectedClass.Strengths = txtStrengths.Text;
            selectedClass.Weaknesses = txtWeaknesses.Text;
            selectedClass.Description = txtDescription.Text;
            selectedClass.IsPlayable = chkPlayable.Checked;

            _context.SaveChanges();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveClass();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            SaveClass();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshFields();
        }
    }
}
