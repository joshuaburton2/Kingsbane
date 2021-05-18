using Kingsbane.App.ListItems;
using Kingsbane.Database;
using Kingsbane.Database.Models;
using Microsoft.EntityFrameworkCore;
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
            }
        }

        private void LoadCampaignData()
        {
            txtName.Text = campaign.Name;
            txtDescription.Text = campaign.Description;

            var scenarioQuery = campaign.Scenarios.Select(x => new ScenarioListItem() { Id = x.Id, Index = x.CampaignIndex.Value, Name = x.Name }).ToArray();
            lstScenarios.Clear();
            foreach (var scenario in scenarioQuery)
            {
                AddScenarioToList(scenario);
            }
        }

        private void AddScenarioToList(ScenarioListItem scenario)
        {
            var listItem = new ListViewItem(scenario.Id.ToString());
            listItem.SubItems.Add(scenario.Index.ToString());
            listItem.SubItems.Add(scenario.Name);
            lstScenarios.Items.Add(listItem);
            listItem.Tag = scenario.Id;
        }
    }
}
