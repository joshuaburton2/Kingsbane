using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Kingsbane.Database;
using Kingsbane.Database.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Kingsbane.App
{
    public partial class formUpgradeList: Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly KingsbaneContext _context;

        public formUpgradeList(
            IServiceProvider serviceProvider,
            KingsbaneContext context)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _context = context;
        }

        private void formCardList_Load(object sender, System.EventArgs e)
        {
            RefreshList();
        }

        private void listCards_DoubleClick(object sender, System.EventArgs e)
        {
            var id = listUpgrades.SelectedItems[0].Tag as int?;
            EditForm(id);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            EditForm(null);
        }

        private void EditForm(int? id)
        {
            var formEditUpgrades = _serviceProvider.GetRequiredService<formEditUpgrades>();
            formEditUpgrades.Id = id;
            var result = formEditUpgrades.ShowDialog(this);

            RefreshList();
        }


        private void RefreshList()
        {
            var upgradeList = GetUpgradeList(txtSearch.Text);

            listUpgrades.Items.Clear();
            foreach (var upgrade in upgradeList)
            {
                var listItem = new ListViewItem(upgrade.Id.ToString());
                listItem.SubItems.Add(upgrade.Name);
                listItem.SubItems.Add(upgrade.HonourPoints.ToString());
                listUpgrades.Items.Add(listItem);
                listItem.Tag = upgrade.Id;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            RefreshList();
        }

        private List<UpgradeListItem> GetUpgradeList(string nameSearch = null)
        {
            var upgradeQuery = _context.Upgrades.Select(x => new UpgradeListItem { Id = x.Id, Name = x.Name, HonourPoints = x.HonourPoints });

            if (!string.IsNullOrWhiteSpace(nameSearch))
            {
                upgradeQuery = upgradeQuery.Where(x => x.Name.Contains(nameSearch));
            }

            return upgradeQuery.ToList();
        }

        private void formCardList_FormClosed(object sender, FormClosedEventArgs e)
        {
            formMain formMain = new formMain(_serviceProvider, _context);
            formMain.Show();
        }
    }
}
