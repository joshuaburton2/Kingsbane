using Kingsbane.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Kingsbane.Database.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Kingsbane.Database.Enums;

namespace Kingsbane.App
{
    public enum SelectionType
    {
        Tag,
        Synergy,
        Cards,
        Upgrades,
        NPCHero,
        Keywords,
        Deck,
        ScenarioRules,
        Scenarios,
    }

    public partial class formSelectionList : Form
    {
        private readonly KingsbaneContext _context;

        public SelectionType selectionType;

        public SelectListItem selectionItem;

        public formSelectionList(KingsbaneContext context)
        {
            InitializeComponent();

            _context = context;
        }

        private void formSelectionList_Load(object sender, EventArgs e)
        {
            switch (selectionType)
            {
                case SelectionType.Tag:
                case SelectionType.Synergy:
                    btnAdd.Enabled = true;
                    txtAdd.Enabled = true;
                    break;
                case SelectionType.NPCHero:
                case SelectionType.Cards:
                case SelectionType.Upgrades:
                case SelectionType.Keywords:
                case SelectionType.Deck:
                case SelectionType.ScenarioRules:
                case SelectionType.Scenarios:
                    btnAdd.Enabled = false;
                    txtAdd.Enabled = false;
                    break;
            }

            RefreshList(selectionType);
        }

        private void RefreshList(SelectionType selectionType, string searchString = null)
        {
            var selectionList = GetSelectionList(selectionType, searchString);

            lstSelectionList.Items.Clear();
            foreach (var selection in selectionList)
            {
                var listItem = new ListViewItem(selection.Id.ToString());
                listItem.SubItems.Add(selection.Name.ToString());
                listItem.SubItems.Add(selection.Identifier.ToString());
                lstSelectionList.Items.Add(listItem);
                listItem.Tag = selection;
            }
        }

        private List<SelectionItem> GetSelectionList(SelectionType selectionType, string searchString = null)
        {
            IQueryable<SelectionItem> newQuery;

            switch (selectionType)
            {
                case SelectionType.Tag:
                    newQuery = _context.Tags.Select(x => new SelectionItem { Id = x.Id, Name = x.Name, Identifier = "" });
                    break;
                case SelectionType.Synergy:
                    newQuery = _context.Synergies.Select(x => new SelectionItem { Id = x.Id, Name = x.Name, Identifier = "" });
                    break;
                case SelectionType.Upgrades:
                    newQuery = _context.Upgrades.Select(x => new SelectionItem { Id = x.Id, Name = x.Name, Identifier = "" });
                    break;
                case SelectionType.NPCHero:
                    newQuery = _context.Cards.Where(x => x.RarityId == CardRarities.NPCHero).Select(x => new SelectionItem { Id = x.Id, Name = x.Name, Identifier = x.CardTypeId.ToString() });
                    break;
                case SelectionType.Keywords:
                    newQuery = _context.Keywords.Select(x => new SelectionItem { Id = (int)x.Id, Name = x.Name, Identifier = "" });
                    break;
                case SelectionType.Deck:
                    newQuery = _context.Decks.Where(x => x.NPCDeck).Select(x => new SelectionItem { Id = x.Id, Name = x.Name, Identifier = "" });
                    break;
                case SelectionType.ScenarioRules:
                    newQuery = _context.ScenarioRules.Select(x => new SelectionItem { Id = x.Id, Name = x.Name, Identifier = x.Description });
                    break;
                case SelectionType.Scenarios:
                    newQuery = _context.Scenarios.Where(x => !x.IsDefault && x.EnemyDeckId != null).Select(x => new SelectionItem { Id = x.Id, Name = x.Name, Identifier = x.CampaignId.HasValue ? x.Campaign.Name : "None" });
                    //newQuery = _context.Scenarios.Select(x => new SelectionItem { Id = x.Id, Name = x.Name, Identifier = x.CampaignId.HasValue ? x.Campaign.Name : "None" });
                    break;
                case SelectionType.Cards:
                default:
                    newQuery = _context.Cards.Select(x => new SelectionItem { Id = x.Id, Name = x.Name, Identifier = x.CardTypeId.ToString() });
                    break;
            }

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                newQuery = newQuery.Where(x => x.Name.Contains(searchString));
            }

            return newQuery.ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchString = txtSearch.Text;

            txtSearch.Text = "";

            RefreshList(selectionType, searchString);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string newName = txtAdd.Text;
            string selectionString = selectionType.ToString();
            DialogResult dialogResult = MessageBox.Show("Add a new " + selectionString + "?", "Add " + selectionString, MessageBoxButtons.YesNo);

            if(dialogResult == DialogResult.Yes)
            {
                switch (selectionType)
                {
                    case SelectionType.Synergy:
                        var syngergyList = _context.Synergies.Where(x => x.Name == newName);
                        if (!syngergyList.Any())
                        {
                            _context.Synergies.Add(new Synergy { Name = newName });
                            _context.SaveChanges();
                            var newItem = _context.Synergies.Where(x => x.Name == newName).FirstOrDefault();
                            selectionItem = new SelectListItem { Id = newItem.Id, Name = newItem.Name };

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            txtAdd.Text = "";
                            MessageBox.Show("Syngergy already exists.");
                        }

                        break;
                    case SelectionType.Tag:
                        var tagList = _context.Tags.Where(x => x.Name == newName);
                        if (!tagList.Any())
                        {
                            _context.Tags.Add(new Tag { Name = newName });
                            _context.SaveChanges();
                            var newItem = _context.Tags.Where(x => x.Name == newName).FirstOrDefault();
                            selectionItem = new SelectListItem { Id = newItem.Id, Name = newItem.Name };

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            txtAdd.Text = "";
                            MessageBox.Show("Tag already exists.");
                        }
                        
                        break;
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                txtAdd.Text = "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lstSelectionList_DoubleClick(object sender, EventArgs e)
        {
            var selectedItem = (SelectionItem)lstSelectionList.SelectedItems[0].Tag;
            selectionItem = new SelectListItem { Id = selectedItem.Id, Name = selectedItem.Name };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
