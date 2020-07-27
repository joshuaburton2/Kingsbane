using System;
using System.Linq;
using System.Windows.Forms;
using Kingsbane.Database;
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

            if (result == DialogResult.OK)
                RefreshList();
        }


        private void RefreshList()
        {
            listCards.Items.Clear();
            foreach (var card in _context.Cards.Select(x => new { x.Id, x.Name }))
            {
                var listItem = new ListViewItem(card.Id.ToString());
                listItem.SubItems.Add(card.Name);
                listCards.Items.Add(listItem);
                listItem.Tag = card.Id;
            }
        }
    }
}
