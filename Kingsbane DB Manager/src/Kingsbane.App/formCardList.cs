using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Kingsbane.Database;
using Kingsbane.Database.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Kingsbane.App
{
    public partial class formCardList : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly KingsbaneContext _context;

        public formCardList(
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
            var id = listCards.SelectedItems[0].Tag as int?;
            EditForm(id);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            EditForm(null);
        }

        private void EditForm(int? id)
        {
            var formCardEdit = _serviceProvider.GetRequiredService<formCardEdit>();
            formCardEdit.Id = id;
            var result = formCardEdit.ShowDialog(this);

            RefreshList();
        }


        private void RefreshList(string nameSearch = null)
        {
            var cardList = GetCardList(nameSearch);

            listCards.Items.Clear();
            foreach (var card in cardList)
            {
                var listItem = new ListViewItem(card.Id.ToString());
                listItem.SubItems.Add(card.Name);
                listItem.SubItems.Add(card.CardType.ToString());
                listItem.SubItems.Add(card.Class.ToString());
                listItem.SubItems.Add(card.Rarity.ToString());
                listCards.Items.Add(listItem);
                listItem.Tag = card.Id;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;

            txtSearch.Text = "";

            RefreshList(searchString);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private List<CardListItem> GetCardList(string nameSearch = null)
        {
            var cardQuery = _context.Cards.Select(x => new CardListItem { Id = x.Id, Name = x.Name, CardType = x.CardType.Id, Class = x.CardClass.Id, Rarity = x.Rarity.Id });

            if (!string.IsNullOrWhiteSpace(nameSearch))
            {
                cardQuery = cardQuery.Where(x => x.Name.Contains(nameSearch));
            }

            return cardQuery.ToList();
        }

        private void formCardList_FormClosed(object sender, FormClosedEventArgs e)
        {
            formMain formMain = new formMain(_serviceProvider, _context);
            formMain.Show();
        }
    }
}
