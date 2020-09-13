using Kingsbane.Database;
using Kingsbane.Database.Models;
using Kingsbane.Database.Enums;
using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kingsbane.App
{
    public partial class formEditClasses : Form
    {
        private readonly KingsbaneContext _context;
        private readonly IServiceProvider _serviceProvider;

        private CardClass selectedClass;
        private Deck selectedDeck;

        public formEditClasses(
            IServiceProvider serviceProvider,
            KingsbaneContext context)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _context = context;
        }

        private void formEditClasses_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();

            cmbClass.SelectedIndex = 0;

            RefreshFields();
        }

        private void LoadComboBoxes()
        {
            var classes = Enum.GetValues(typeof(CardClasses)).Cast<CardClasses>().Select(x => new SelectListItem { Id = (int)x, Name = x.ToString() }).ToArray();
            cmbClass.Items.AddRange(classes);

            var resources = Enum.GetValues(typeof(Resources)).Cast<Resources>().Select(x => new SelectListItem { Id = (int)x, Name = x.ToString() }).ToArray();
            cmbDominant.Items.AddRange(resources);
            cmbSecondary.Items.AddRange(resources);
        }

        private void RefreshFields()
        {
            var classId = (CardClasses)((SelectListItem)cmbClass.SelectedItem).Id;
            selectedClass = _context.CardClasses
                .Include(x => x.Decks).ThenInclude(x => x.DeckCards).ThenInclude(x => x.Card)
                .Single(x => x.Id == classId);

            cmbDominant.SelectedItem = SetComboItem(cmbDominant, (int)selectedClass.DominantResource);
            cmbSecondary.SelectedItem = SetComboItem(cmbSecondary, (int)selectedClass.SecondaryResource);

            txtPlaystyle.Text = selectedClass.Playstyle;
            txtStrengths.Text = selectedClass.Strengths;
            txtWeaknesses.Text = selectedClass.Weaknesses;
            txtDescription.Text = selectedClass.Description;

            chkPlayable.Checked = selectedClass.IsPlayable;

            InitDeckList();
        }

        private void InitDeckList(int? selectedDeckId = null)
        {
            cmbDeck.Items.Clear();
            lstDeckList.Items.Clear();
            txtDeckName.Text = "";
            chkNPCDeck.Checked = false;

            if (!selectedClass.Decks.Any())
            {
                cmbDeck.Enabled = false;
                btnDelete.Enabled = false;
                txtDeckName.Enabled = false;
                btnSaveDeck.Enabled = false;
                chkNPCDeck.Enabled = false;
            }
            else
            {
                var deckList = selectedClass.Decks.Select(x => new SelectListItem { Id = x.Id, Name = x.Name }).ToArray();

                cmbDeck.Enabled = true;
                btnDelete.Enabled = true;
                txtDeckName.Enabled = true;
                btnSaveDeck.Enabled = true;
                chkNPCDeck.Enabled = true;

                cmbDeck.Items.AddRange(deckList);

                if (selectedDeckId.HasValue)
                {
                    cmbDeck.SelectedItem = SetComboItem(cmbDeck, selectedDeckId.Value);
                }
                else
                {
                    cmbDeck.SelectedIndex = 0;
                }               

                LoadDeckInfo();
            }
        }

        private void LoadDeckInfo()
        {
            var selectedDeckId = ((SelectListItem)cmbDeck.SelectedItem).Id;
            selectedDeck = selectedClass.Decks.FirstOrDefault(x => x.Id == selectedDeckId);

            txtDeckName.Text = selectedDeck.Name;
            chkNPCDeck.Checked = selectedDeck.NPCDeck;

            RefreshDeckCardList();
        }

        private bool RefreshDeckCardList()
        {
            lstDeckList.Items.Clear();

            if (selectedDeck.DeckCards == null)
            {
                return false;
            }
            var deckList = selectedDeck.DeckCards.Select(x => x.Card).ToList();
            var cardList = deckList.Select(x => new CardListItem { Id = x.Id, Name = x.Name, CardType = x.CardTypeId, Class = x.CardClassId, Rarity = x.RarityId });

            foreach (var card in cardList)
            {
                var listItem = new ListViewItem(card.Id.ToString());
                listItem.SubItems.Add(card.Name);
                listItem.SubItems.Add(card.CardType.ToString());
                listItem.SubItems.Add(card.Class.ToString());
                listItem.SubItems.Add(card.Rarity.ToString());
                lstDeckList.Items.Add(listItem);
                listItem.Tag = card.Id;
            }

            return true;
        }

        private SelectListItem SetComboItem(ComboBox cmb, int Id)
        {
            return cmb.Items.Cast<SelectListItem>().FirstOrDefault(x => x.Id == Id);
        }

        private void formEditClasses_FormClosed(object sender, FormClosedEventArgs e)
        {
            formMain formMain = new formMain(_serviceProvider, _context);
            formMain.Show();
        }

        private void SaveClass()
        {
            selectedClass.DominantResource = (Resources)((SelectListItem)cmbDominant.SelectedItem).Id;
            selectedClass.SecondaryResource = (Resources)((SelectListItem)cmbSecondary.SelectedItem).Id;
            selectedClass.Playstyle = txtPlaystyle.Text;
            selectedClass.Strengths = txtStrengths.Text;
            selectedClass.Weaknesses = txtWeaknesses.Text;
            selectedClass.Description = txtDescription.Text;
            selectedClass.IsPlayable = chkPlayable.Checked;

            _context.SaveChanges();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveClass();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            SaveClass();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshFields();
        }

        private void btnAddDeck_Click(object sender, EventArgs e)
        {
            selectedDeck = new Deck() { Name = txtNewDeckName.Text, DeckClassId = selectedClass.Id, NPCDeck = false };
            _context.Decks.Add(selectedDeck);
            _context.SaveChanges();

            txtNewDeckName.Text = "";
            InitDeckList(selectedDeck.Id);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _context.Remove(selectedDeck);
            _context.SaveChanges();
            InitDeckList();
        }

        private void cmbDeck_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDeckInfo();
        }

        private void btnSaveDeck_Click(object sender, EventArgs e)
        {
            selectedDeck.Name = txtDeckName.Text;
            selectedDeck.NPCDeck = chkNPCDeck.Checked;
            _context.SaveChanges();

            InitDeckList();
        }

        private void btnAddCard_Click(object sender, EventArgs e)
        {
            var formSelectionList = _serviceProvider.GetRequiredService<formSelectionList>();
            formSelectionList.selectionType = SelectionType.Cards;
            var result = formSelectionList.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                var newCard = _context.Cards.FirstOrDefault(x => x.Id == formSelectionList.selectionItem.Id);
                _context.DeckCards.Add(new DeckCard { Card = newCard, Deck = selectedDeck });
                _context.SaveChanges();

                RefreshDeckCardList();
            }
        }

        private void lstDeckList_DoubleClick(object sender, EventArgs e)
        {
            var id = (int)lstDeckList.SelectedItems[0].Tag;
            var selectedDeckCard = selectedDeck.DeckCards.Single(x => x.CardId == id);
            _context.DeckCards.Remove(selectedDeckCard);
            _context.SaveChanges();
            RefreshDeckCardList();
        }
    }
}
