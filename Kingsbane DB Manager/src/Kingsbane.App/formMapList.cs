using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Kingsbane.Database;
using Kingsbane.Database.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Kingsbane.App
{
    public partial class formMapList : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly KingsbaneContext _context;

        public formMapList(
            IServiceProvider serviceProvider,
            KingsbaneContext context)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _context = context;
        }

        private void formMapList_Load(object sender, System.EventArgs e)
        {
            RefreshList();
        }

        private void lstMaps_DoubleClick(object sender, System.EventArgs e)
        {
            var id = lstMaps.SelectedItems[0].Tag as int?;
            EditForm(id);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            EditForm(null);
        }

        private void EditForm(int? id)
        {
            var formMapEdit = _serviceProvider.GetRequiredService<formMapEdit>();
            formMapEdit.Id = id;
            var result = formMapEdit.ShowDialog(this);

            RefreshList();
        }


        private void RefreshList()
        {
            var mapList = GetMapLst(txtSearch.Text);

            lstMaps.Items.Clear();
            foreach (var map in mapList)
            {
                var listItem = new ListViewItem(map.Id.ToString());
                listItem.SubItems.Add(map.Name);
                lstMaps.Items.Add(listItem);
                listItem.Tag = map.Id;
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

        private List<MapListItem> GetMapLst(string nameSearch = null)
        {
            var mapQuery = _context.Maps.Select(x => new MapListItem { Id = x.Id, Name = x.Name });

            if (!string.IsNullOrWhiteSpace(nameSearch))
            {
                mapQuery = mapQuery.Where(x => x.Name.Contains(nameSearch));
            }

            return mapQuery.ToList();
        }

        private void formCardList_FormClosed(object sender, FormClosedEventArgs e)
        {
            formMain formMain = new formMain(_serviceProvider, _context);
            formMain.Show();
        }
    }
}
