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
    public partial class formKeywordList : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly KingsbaneContext _context;

        public formKeywordList(
            IServiceProvider serviceProvider,
            KingsbaneContext context)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _context = context;
        }

        private void formKeywordList_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void listKeywords_DoubleClick(object sender, EventArgs e)
        {
            var id = listKeywords.SelectedItems[0].Tag as int?;
            EditForm(id);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            EditForm(null);
        }

        private void EditForm(int? id)
        {
            var formKeywordEdit = _serviceProvider.GetRequiredService<formKeywordEdit>();
            formKeywordEdit.Id = id;
            var result = formKeywordEdit.ShowDialog(this);

            RefreshList();
        }

        private void RefreshList()
        {
            var campaignList = GetKeywordList(txtSearch.Text);

            listKeywords.Items.Clear();
            foreach (var campaign in campaignList)
            {
                var listItem = new ListViewItem(campaign.Id.ToString());
                listItem.SubItems.Add(campaign.Name);
                listKeywords.Items.Add(listItem);
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

        private List<KeywordListItem> GetKeywordList(string nameSearch = null)
        {
            var keywordQuery = _context.Keywords.Select(x => new KeywordListItem { Id = x.Id, Name = x.Name });

            if (!string.IsNullOrWhiteSpace(nameSearch))
            {
                keywordQuery = keywordQuery.Where(x => x.Name.Contains(nameSearch));
            }

            return keywordQuery.ToList();
        }

        private void formKeywordList_FormClosed(object sender, FormClosedEventArgs e)
        {
            formMain formMain = new formMain(_serviceProvider, _context);
            formMain.Show();
        }
    }
}
