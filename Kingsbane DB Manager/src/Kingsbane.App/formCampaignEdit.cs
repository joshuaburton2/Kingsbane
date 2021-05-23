using Kingsbane.App.ListItems;
using Kingsbane.Database;
using Kingsbane.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kingsbane.App
{
    public partial class formCampaignEdit : Form
    {
        private readonly KingsbaneContext _context;
        private readonly IServiceProvider _serviceProvider;

        public int? Id { get; set; }
        private Campaign campaign;

        private List<ScenarioListItem> scenarioList;

        public formCampaignEdit(
            IServiceProvider serviceProvider,
            KingsbaneContext context)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _context = context;
        }

        private void formCampaignEdit_Load(object sender, EventArgs e)
        {
            if (Id.HasValue)
            {
                Text = $"Edit Campaign: {Id}";
                campaign = _context.Campaigns
                    .Include(x => x.Scenarios)
                    .Single(x => x.Id == Id);

                LoadCampaignData();
            }
            else
            {
                Text = "Add Campaign";

                scenarioList = new List<ScenarioListItem>();
                RefreshScenarioList();
            }
        }

        private void LoadCampaignData()
        {
            txtName.Text = campaign.Name;
            txtDescription.Text = campaign.Description;

            scenarioList = campaign.Scenarios.Select(x => new ScenarioListItem() { Id = x.Id, Index = x.CampaignIndex.Value, Name = x.Name }).OrderBy(x => x.Index).ToList();
            RefreshScenarioList();
        }

        private void RefreshScenarioList(int? selectedId = null)
        {
            ListViewItem selectedItem = null;
            lstScenarios.Items.Clear();
            foreach (var scenario in scenarioList)
            {
                var listItem = new ListViewItem(scenario.Id.ToString());
                listItem.SubItems.Add(scenario.Index.ToString());
                listItem.SubItems.Add(scenario.Name);
                lstScenarios.Items.Add(listItem);
                listItem.Tag = scenario.Id;

                if (selectedId.HasValue)
                {
                    if (selectedId.Value == scenario.Id)
                    {
                        selectedItem = listItem;
                    }
                }
            }

            if (selectedItem != null)
            {
                selectedItem.Selected = true;
                lstScenarios.Select();
            }

            btnIndexUp.Enabled = lstScenarios.SelectedItems.Count == 1 && scenarioList.Count != 0;
            btnIndexDown.Enabled = lstScenarios.SelectedItems.Count == 1 && scenarioList.Count != 0;
        }

        private void lstScenarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstScenarios.SelectedItems.Count == 1)
            {
                var selectedItem = lstScenarios.SelectedItems[0];
                var selectedScenario = scenarioList.Single(x => x.Id == (int)selectedItem.Tag);

                btnIndexUp.Enabled = lstScenarios.SelectedItems.Count == 1 && selectedScenario.Index != lstScenarios.Items.Count - 1;
                btnIndexDown.Enabled = lstScenarios.SelectedItems.Count == 1 && selectedScenario.Index != 0;
            }
        }

        private void btnAddScenario_Click(object sender, EventArgs e)
        {
            var formSelectionList = _serviceProvider.GetRequiredService<formSelectionList>();
            formSelectionList.selectionType = SelectionType.Scenarios;
            var result = formSelectionList.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                if (!scenarioList.Any(x => x.Id == formSelectionList.selectionItem.Id))
                {
                    var scenarioItem = new ScenarioListItem() { Id = formSelectionList.selectionItem.Id, Name = formSelectionList.selectionItem.Name, Index = lstScenarios.Items.Count };
                    scenarioList.Add(scenarioItem);
                    RefreshScenarioList();
                }
                else
                {
                    MessageBox.Show("Scenario already exists in the campaign");
                }
            }
        }

        private void btnIndexUp_Click(object sender, EventArgs e)
        {
            ShiftIndex(1);
        }

        private void btnIndexDown_Click(object sender, EventArgs e)
        {
            ShiftIndex(-1);
        }

        private void ShiftIndex(int indexShift)
        {
            if (lstScenarios.SelectedItems.Count == 1)
            {
                var selectedItem = lstScenarios.SelectedItems[0];
                var selectedScenario = scenarioList.Single(x => x.Id == (int)selectedItem.Tag);
                var switchScenario = scenarioList.Single(x => x.Index == selectedScenario.Index + indexShift);

                selectedScenario.Index += indexShift;
                switchScenario.Index -= indexShift;

                scenarioList = scenarioList.OrderBy(x => x.Index).ToList();

                RefreshScenarioList(selectedScenario.Id);
            }
        }

        private void lstScenarios_DoubleClick(object sender, EventArgs e)
        {
            if (lstScenarios.SelectedItems.Count == 1)
            {
                var selectedItem = lstScenarios.SelectedItems[0];
                var selectedScenario = scenarioList.Single(x => x.Id == (int)selectedItem.Tag);

                var result = MessageBox.Show("Are you sure you want to remove " + selectedScenario.Name + " from the list?", "Remove record", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    scenarioList.Remove(selectedScenario);
                    RefreshScenarioList();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Id.HasValue)
            {
                campaign = new Campaign();
                _context.Campaigns.Add(campaign);
            }

            campaign.Name = txtName.Text;
            campaign.Description = txtDescription.Text;

            foreach (var scenarioItem in scenarioList)
            {
                var scenario = _context.Scenarios.Single(x => x.Id == scenarioItem.Id);
                scenario.Campaign = campaign;
                scenario.CampaignIndex = scenarioItem.Index;
            }
            if (Id.HasValue)
            {
                var removeScenarios = campaign.Scenarios.Where(x => !scenarioList.Select(x => x.Id).Contains(x.Id));
                foreach (var scenario in removeScenarios)
                    scenario.CampaignId = null;
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
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this campaign?", "Check Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (Id.HasValue)
                {
                    foreach (var scenario in campaign.Scenarios)
                    {
                        scenario.CampaignId = null;
                        scenario.CampaignIndex = null;
                    }
                    _context.Remove(campaign);
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
    }
}
