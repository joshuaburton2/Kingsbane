using Kingsbane.App.ListItems;
using Kingsbane.Database;
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
    public partial class formCampaignList : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly KingsbaneContext _context;

        public formCampaignList(
            IServiceProvider serviceProvider,
            KingsbaneContext context)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _context = context;
        }

        private void formCampaignList_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void listCampaigns_DoubleClick(object sender, EventArgs e)
        {
            var id = listCampaigns.SelectedItems[0].Tag as int?;
            EditForm(id);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            EditForm(null);
        }

        private void EditForm(int? id)
        {
            var formCampaignEdit = _serviceProvider.GetRequiredService<formCampaignEdit>();
            formCampaignEdit.Id = id;
            var result = formCampaignEdit.ShowDialog(this);

            RefreshList();
        }

        private void RefreshList()
        {
            var campaignList = GetCampaignList(txtSearch.Text);

            listCampaigns.Items.Clear();
            foreach (var campaign in campaignList)
            {
                var listItem = new ListViewItem(campaign.Id.ToString());
                listItem.SubItems.Add(campaign.Name);
                listCampaigns.Items.Add(listItem);
                listItem.Tag = campaign.Id;
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

        private List<CampaignListItem> GetCampaignList(string nameSearch = null)
        {
            var campaignQuery = _context.Campaigns.Select(x => new CampaignListItem { Id = x.Id, Name = x.Name });

            if (!string.IsNullOrWhiteSpace(nameSearch))
            {
                campaignQuery = campaignQuery.Where(x => x.Name.Contains(nameSearch));
            }

            return campaignQuery.ToList();
        }

        private void formCampaignList_FormClosed(object sender, FormClosedEventArgs e)
        {
            formMain formMain = new formMain(_serviceProvider, _context);
            formMain.Show();
        }
    }
}
