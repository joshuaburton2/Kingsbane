using Kingsbane.Database;
using Kingsbane.Database.Enums;
using Kingsbane.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Kingsbane.App
{
    public partial class formEditUpgrades : Form
    {
        private readonly KingsbaneContext _context;
        private readonly IServiceProvider _serviceProvider;

        public int? Id { get; set; }
        private Upgrade upgrade;

        public formEditUpgrades(
            IServiceProvider serviceProvider,
            KingsbaneContext context)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _context = context;
        }

        private void formEditUpgrades_Load(object sender, EventArgs e)
        {
            SetupComboBoxes();

            if (Id.HasValue)
            {
                this.Text = $"Edit Upgrade: {Id}";
                upgrade = _context.Upgrades
                    .Include(x => x.ClassPrerequisites)
                    .Include(x => x.ResourcePrerequisites)
                    .Include(x => x.UpgradePrerequisites).ThenInclude(x => x.UpgradePrequisite)
                    .Single(x => x.Id == Id);

                LoadUpgradeData();
            }
            else
            {
                this.Text = "Add Upgrade";
            }
        }

        private void SetupComboBoxes()
        {
            var classes = Enum.GetValues(typeof(CardClasses)).Cast<CardClasses>().Select(x => new SelectListItem { Id = (int)x, Name = x.ToString() }).ToArray();
            cmbClassSelector.Items.AddRange(classes);
            cmbClassSelector.SelectedIndex = 0;

            var resources = Enum.GetValues(typeof(Resources)).Cast<Resources>().Select(x => new SelectListItem { Id = (int)x, Name = x.ToString() }).ToArray();
            cmbResourceSelector.Items.AddRange(resources);
            cmbResourceSelector.SelectedIndex = 0;
        }

        private void LoadUpgradeData()
        {
            txtName.Text = upgrade.Name;
            txtHonourPoints.Text = upgrade.HonourPoints.ToString();
            chkIsRepeatable.Checked = upgrade.IsRepeatable;
            chkIsTierUpgrade.Checked = upgrade.IsTierUpgrade;
            txtText.Text = upgrade.Text;
            txtTierLevel.Text = upgrade.TierLevel.ToString();

            var classPrerequisites = upgrade.ClassPrerequisites.Select(x => new SelectListItem { Id = (int)x.CardClassId, Name = x.CardClassId.ToString() }).ToArray();
            lstClassPrerequisites.Items.Clear();
            lstClassPrerequisites.Items.AddRange(classPrerequisites);

            var resourcePrerequisites = upgrade.ResourcePrerequisites.Select(x => new SelectListItem { Id = (int)x.ResourceId, Name = x.ResourceId.ToString() }).ToArray();
            lstResourcePrerequisite.Items.Clear();
            lstResourcePrerequisite.Items.AddRange(resourcePrerequisites);

            var upgradePrerequisites = upgrade.UpgradePrerequisites.Select(x => new SelectListItem { Id = x.UpgradePrequisite.Id, Name = x.UpgradePrequisite.Name }).ToArray();
            lstUpgradePrerequisite.Items.Clear();
            lstUpgradePrerequisite.Items.AddRange(upgradePrerequisites);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Id.HasValue)
            {
                upgrade = new Upgrade();
                _context.Upgrades.Add(upgrade);
            }

            upgrade.Name = txtName.Text;
            if (int.TryParse(txtHonourPoints.Text, out int honourPoints))
            {
                upgrade.HonourPoints = honourPoints;
            }
            upgrade.IsRepeatable = chkIsRepeatable.Checked;
            upgrade.IsTierUpgrade = chkIsTierUpgrade.Checked;
            if (int.TryParse(txtTierLevel.Text, out int tierLevel))
            {
                upgrade.TierLevel = tierLevel;
            }
            upgrade.Text = txtText.Text;

            var classPrerequisiteIds = lstClassPrerequisites.Items.Cast<SelectListItem>().Select(x => x.Id).ToList();
            foreach (var classPrerequisiteId in classPrerequisiteIds)
            {
                var classPrerequisite = Id.HasValue ? upgrade.ClassPrerequisites.SingleOrDefault(x => x.CardClassId == (CardClasses)classPrerequisiteId) : null;
                if (classPrerequisite == null)
                    _context.ClassPrerequisites.Add(new ClassPrerequisite { Upgrade = upgrade, CardClassId = (CardClasses)classPrerequisiteId });
            }
            if (Id.HasValue)
            {
                var upgradeClassPrerequisites = upgrade.ClassPrerequisites.Where(x => !classPrerequisiteIds.Contains((int)x.CardClassId));
                _context.ClassPrerequisites.RemoveRange(upgradeClassPrerequisites);
            }

            var resourcePrerequisiteIds = lstResourcePrerequisite.Items.Cast<SelectListItem>().Select(x => x.Id).ToList();
            foreach (var resourcePrerequisiteId in resourcePrerequisiteIds)
            {
                var resourcePrerequisite = Id.HasValue ? upgrade.ResourcePrerequisites.SingleOrDefault(x => x.ResourceId == (Resources)resourcePrerequisiteId) : null;
                if (resourcePrerequisite == null)
                    _context.ResourcePrerequisites.Add(new ResourcePrerequisite { Upgrade = upgrade, ResourceId = (Resources)resourcePrerequisiteId });
            }
            if (Id.HasValue)
            {
                var upgradeResourcePrerequisites = upgrade.ResourcePrerequisites.Where(x => !resourcePrerequisiteIds.Contains((int)x.ResourceId));
                _context.ResourcePrerequisites.RemoveRange(upgradeResourcePrerequisites);
            }

            var upgradePrerequisiteIds = lstUpgradePrerequisite.Items.Cast<SelectListItem>().Select(x => x.Id).ToList();
            foreach (var upgradePrerequisiteId in upgradePrerequisiteIds)
            {
                var upgradePrerequisite = Id.HasValue ? upgrade.UpgradePrerequisites.SingleOrDefault(x => x.UpgradePrequisiteId == upgradePrerequisiteId) : null;
                if (upgradePrerequisite == null)
                    _context.UpgradePrerequisites.Add(new UpgradePrerequisite { Upgrade = upgrade, UpgradePrequisiteId = upgradePrerequisiteId });
            }
            if (Id.HasValue)
            {
                var upgradePrerequisites = upgrade.UpgradePrerequisites.Where(x => !upgradePrerequisiteIds.Contains((int)x.UpgradePrequisiteId));
                _context.UpgradePrerequisites.RemoveRange(upgradePrerequisites);
            }

            _context.SaveChanges();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this upgrade?", "Check Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (Id.HasValue)
                {
                    _context.UpgradePrerequisites.RemoveRange(_context.UpgradePrerequisites.Where(x => x.UpgradeId == upgrade.Id || x.UpgradePrequisiteId == upgrade.Id));
                    upgrade.ClassPrerequisites.Clear();
                    upgrade.ResourcePrerequisites.Clear();
                    _context.Remove(upgrade);
                    _context.SaveChanges();
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
        }

        private void btnClassPrerequisite_Click(object sender, EventArgs e)
        {
            var selectedClass = ((SelectListItem)cmbClassSelector.SelectedItem).Id;

            if (!lstClassPrerequisites.Items.Cast<SelectListItem>().Any(x => x.Id == selectedClass))
            {
                var classString = ((CardClasses)selectedClass).ToString();
                lstClassPrerequisites.Items.Add(new SelectListItem() { Id = selectedClass, Name = classString });
            }
            else
            {
                MessageBox.Show("Upgrade already has that class prerequisite");
            }
        }

        private void btnResourcePrerequisite_Click(object sender, EventArgs e)
        {
            var selectedResource = ((SelectListItem)cmbResourceSelector.SelectedItem).Id;

            if (!lstResourcePrerequisite.Items.Cast<SelectListItem>().Any(x => x.Id == selectedResource))
            {
                var classString = ((Resources)selectedResource).ToString();
                lstResourcePrerequisite.Items.Add(new SelectListItem() { Id = selectedResource, Name = classString });
            }
            else
            {
                MessageBox.Show("Upgrade already has that resource prerequisite");
            }
        }

        private void btnUpgradePrerequisite_Click(object sender, EventArgs e)
        {
            var formSelectionList = _serviceProvider.GetRequiredService<formSelectionList>();
            formSelectionList.selectionType = SelectionType.Upgrades;
            var result = formSelectionList.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                if (!lstUpgradePrerequisite.Items.Cast<SelectListItem>().Any(x => x.Id == formSelectionList.selectionItem.Id))
                {
                    lstUpgradePrerequisite.Items.Add(formSelectionList.selectionItem);
                }
                else
                {
                    MessageBox.Show("Upgrade already has that resource prerequisite");
                }
            }
        }

        private void ClickListRecord(object sender, EventArgs e)
        {
            var listBox = (ListBox)sender;
            var selectedRecord = listBox.SelectedItems.Cast<SelectListItem>().ToList()[0];

            var result = MessageBox.Show("Are you sure you want to remove " + selectedRecord.Name + " from the list?", "Remove record", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                listBox.Items.Remove(listBox.SelectedItems[0]);
            }
        }
    }
}
