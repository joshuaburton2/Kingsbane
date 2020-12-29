using Kingsbane.Database;
using Kingsbane.Database.Models;
using Kingsbane.Database.Enums;
using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Kingsbane.App
{
    public partial class formEditClasses : Form
    {
        private readonly KingsbaneContext _context;
        private readonly IServiceProvider _serviceProvider;

        private CardClass selectedClass;
        private Deck selectedDeck;

        private List<GroupBox> resourceGroupBoxes;
        private List<List<Label>> resourcePropertiesLabels;
        private List<List<TextBox>> resourcePropertiesTextBoxes;

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

            resourceGroupBoxes = new List<GroupBox> { grpResource1, grpResouce2 };
            resourcePropertiesLabels = new List<List<Label>> {
                new List<Label> { lblResource1Prop1, lblResource1Prop2 },
                new List<Label> { lblResource2Prop1, lblResource2Prop2 },
                };
            resourcePropertiesTextBoxes = new List<List<TextBox>> {
                new List<TextBox> { txtResource1Prop1, txtResource1Prop2 },
                new List<TextBox> { txtResource2Prop1, txtResource2Prop2 },
                };

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
                .Include(x => x.Decks)
                .Include(x => x.ClassResources).ThenInclude(x => x.Resource).ThenInclude(x => x.ResourceProperties)
                .Single(x => x.Id == classId);

            if (!selectedClass.ClassResources.Any())
            {
                _context.ClassResources.Add(new ClassResource()
                {
                    CardClass = selectedClass,
                    ClassResourceType = ClassResourceTypes.Dominant,
                    ResourceId = Resources.Neutral
                });
                _context.ClassResources.Add(new ClassResource()
                {
                    CardClass = selectedClass,
                    ClassResourceType = ClassResourceTypes.Secondary,
                    ResourceId = Resources.Neutral
                });

                _context.SaveChanges();
            }

            cmbDominant.SelectedItem = SetComboItem(cmbDominant, (int)(selectedClass.ClassResources
                .FirstOrDefault(x => x.ClassResourceType == ClassResourceTypes.Dominant).ResourceId));
            cmbSecondary.SelectedItem = SetComboItem(cmbSecondary, (int)(selectedClass.ClassResources
                .FirstOrDefault(x => x.ClassResourceType == ClassResourceTypes.Secondary).ResourceId));

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
                grpNPCProperties.Enabled = false;
                btnAddUpgrade.Enabled = false;
                btnAddCard.Enabled = false;
                lstUpgrades.Enabled = false;
            }
            else
            {
                var deckList = selectedClass.Decks.Select(x => new SelectListItem { Id = x.Id, Name = x.Name }).ToArray();

                cmbDeck.Enabled = true;
                btnDelete.Enabled = true;
                txtDeckName.Enabled = true;
                btnSaveDeck.Enabled = true;
                chkNPCDeck.Enabled = true;
                btnAddUpgrade.Enabled = true;
                btnAddCard.Enabled = true;
                lstUpgrades.Enabled = true;

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
            selectedDeck = _context.Decks
                .Include(x => x.ResourceProperties).ThenInclude(x => x.ResourceProperty)
                .Include(x => x.DeckUpgrades).ThenInclude(x => x.Upgrade)
                .Include(x => x.DeckCards).ThenInclude(x => x.Card)
                .Include(x => x.HeroCard)
                .FirstOrDefault(x => x.Id == selectedDeckId);

            txtDeckName.Text = selectedDeck.Name;
            chkNPCDeck.Checked = selectedDeck.NPCDeck;

            RefreshDeckCardList();

            RefreshDeckUpgradeList();

            LoadNPCDeckProperties();
        }

        private bool RefreshDeckCardList()
        {
            lstDeckList.Items.Clear();

            if (selectedDeck.DeckCards == null)
            {
                return false;
            }
            var cardList = selectedDeck.DeckCards.Select(x => new CardListItem
            {
                Id = x.Card.Id,
                Name = x.Card.Name,
                Count = x.Count,
                CardType = x.Card.CardTypeId,
                Class = x.Card.CardClassId,
                Rarity = x.Card.RarityId
            });

            foreach (var card in cardList)
            {
                var listItem = new ListViewItem(card.Id.ToString());
                listItem.SubItems.Add(card.Name);
                listItem.SubItems.Add(card.Count.ToString());
                listItem.SubItems.Add(card.CardType.ToString());
                listItem.SubItems.Add(card.Class.ToString());
                listItem.SubItems.Add(card.Rarity.ToString());
                lstDeckList.Items.Add(listItem);
                listItem.Tag = card.Id;
            }

            return true;
        }

        private bool RefreshDeckUpgradeList()
        {
            lstUpgrades.Items.Clear();

            if (selectedDeck.DeckUpgrades == null)
            {
                return false;
            }
            var upgradeList = selectedDeck.DeckUpgrades.Select(x => x.Upgrade).ToList();
            var selectUpgardeList = upgradeList.Select(x => new SelectListItem { Id = x.Id, Name = x.Name }).ToArray();

            lstUpgrades.Items.AddRange(selectUpgardeList);

            return true;
        }

        private void LoadNPCDeckProperties()
        {
            if (selectedDeck.NPCDeck)
            {
                txtHeroCard.Text = _context.Cards.FirstOrDefault(x => x.Id == selectedDeck.HeroCardId).Name;
                txtHeroCard.Tag = selectedDeck.HeroCardId;

                txtInitialMulligan.Text = selectedDeck.InitialHandSize.ToString();
            }
            else
            {
                txtHeroCard.Text = "";
                txtHeroCard.Tag = null;
                txtInitialMulligan.Text = "";

                txtResource1Prop1.Text = "";
                txtResource1Prop2.Text = "";
                txtResource2Prop1.Text = "";
                txtResource2Prop2.Text = "";
            }

            var resourceIndex = 0;
            foreach (var resource in selectedClass.ClassResources)
            {
                var propertyIndex = 0;

                resourceGroupBoxes[resourceIndex].Text = resource.Resource.Name;

                foreach (var resourceProp in resource.Resource.ResourceProperties)
                {
                    resourcePropertiesLabels[resourceIndex][propertyIndex].Text = resourceProp.Type.ToString();

                    if (selectedDeck.ResourceProperties.Any())
                    {
                        resourcePropertiesTextBoxes[resourceIndex][propertyIndex].Text = selectedDeck.ResourceProperties.ToList()[propertyIndex].Value.ToString();
                    }

                    propertyIndex++;
                }

                resourceIndex++;
            }
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
            selectedClass.ClassResources.FirstOrDefault(x => x.ClassResourceType == ClassResourceTypes.Dominant).ResourceId
                = (Resources)((SelectListItem)cmbDominant.SelectedItem).Id;
            selectedClass.ClassResources.FirstOrDefault(x => x.ClassResourceType == ClassResourceTypes.Secondary).ResourceId
                = (Resources)((SelectListItem)cmbSecondary.SelectedItem).Id;

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
            _context.DeckResourceProperties.RemoveRange(_context.DeckResourceProperties.Where(x => x.DeckId == selectedDeck.Id));
            _context.DeckCards.RemoveRange(_context.DeckCards.Where(x => x.DeckId == selectedDeck.Id));
            _context.DeckUpgrades.RemoveRange(_context.DeckUpgrades.Where(x => x.DeckId == selectedDeck.Id));
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

            var upgradeIds = lstUpgrades.Items.Cast<SelectListItem>().Select(x => x.Id).ToList();

            foreach (var upgradeId in upgradeIds)
            {
                var deckUpgrade = selectedDeck != null ? selectedDeck.DeckUpgrades.SingleOrDefault(x => x.UpgradeId == upgradeId) : null;
                if (deckUpgrade == null)
                    _context.DeckUpgrades.Add(new DeckUpgrade { Deck = selectedDeck, UpgradeId = upgradeId });
            }
            if (selectedDeck != null)
            {
                var deckUpgrades = selectedDeck.DeckUpgrades.Where(x => !upgradeIds.Contains(x.UpgradeId));
                _context.DeckUpgrades.RemoveRange(deckUpgrades);
            }

            if (selectedDeck.NPCDeck)
            {
                selectedDeck.HeroCardId = (int)txtHeroCard.Tag;
                selectedDeck.InitialHandSize = int.Parse(txtInitialMulligan.Text);

                var resourceIndex = 0;

                foreach (var resource in selectedClass.ClassResources)
                {
                    var propertyIndex = 0;

                    foreach (var property in resource.Resource.ResourceProperties)
                    {
                        var propertyValue = int.Parse(resourcePropertiesTextBoxes[resourceIndex][propertyIndex].Text);

                        if (selectedDeck.ResourceProperties.Where(x => x.ResourcePropertyId == property.Id).Any())
                        {
                            selectedDeck.ResourceProperties.FirstOrDefault(x => x.ResourcePropertyId == property.Id).Value = propertyValue;
                        }
                        else
                        {
                            _context.DeckResourceProperties.Add(new DeckResourceProperty()
                            {
                                Deck = selectedDeck,
                                ResourceProperty = property,
                                Value = propertyValue,
                            }); ;
                        }

                        propertyIndex++;
                    }

                    resourceIndex++;
                }
            }
            else
            {
                selectedDeck.ResourceProperties.Clear();
            }

            _context.SaveChanges();

            InitDeckList(selectedDeck.Id);
        }

        private void btnAddCard_Click(object sender, EventArgs e)
        {
            var formSelectionList = _serviceProvider.GetRequiredService<formSelectionList>();
            formSelectionList.selectionType = SelectionType.Cards;
            var result = formSelectionList.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                var newCard = _context.Cards.FirstOrDefault(x => x.Id == formSelectionList.selectionItem.Id);
                if (_context.DeckCards.Where(x => x.Deck == selectedDeck).Select(x => x.CardId).Contains(newCard.Id))
                {
                    _context.DeckCards.FirstOrDefault(x => x.CardId == newCard.Id && x.Deck == selectedDeck).Count += 1;
                }
                else
                {
                    _context.DeckCards.Add(new DeckCard { Card = newCard, Deck = selectedDeck, Count = 1 });
                }
                
                _context.SaveChanges();

                RefreshDeckCardList();
            }
        }

        private void lstDeckList_DoubleClick(object sender, EventArgs e)
        {
            var id = (int)lstDeckList.SelectedItems[0].Tag;
            var selectedDeckCard = selectedDeck.DeckCards.Single(x => x.CardId == id && x.Deck == selectedDeck);
            if (selectedDeckCard.Count == 1)
            {
                _context.DeckCards.Remove(selectedDeckCard);
            }
            else
            {
                _context.DeckCards.Single(x => x == selectedDeckCard).Count--;
            }
            
            _context.SaveChanges();
            RefreshDeckCardList();
        }

        private void chkNPCDeck_CheckedChanged(object sender, EventArgs e)
        {
            grpNPCProperties.Enabled = ((CheckBox)sender).Checked;
        }

        private void btnHeroCard_Click(object sender, EventArgs e)
        {
            var formSelectionList = _serviceProvider.GetRequiredService<formSelectionList>();
            formSelectionList.selectionType = SelectionType.NPCHero;
            var result = formSelectionList.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                txtHeroCard.Text = formSelectionList.selectionItem.Name;
                txtHeroCard.Tag = formSelectionList.selectionItem.Id;
            }
        }

        private void btnAddUpgrade_Click(object sender, EventArgs e)
        {
            var formSelectionList = _serviceProvider.GetRequiredService<formSelectionList>();
            formSelectionList.selectionType = SelectionType.Upgrades;
            var result = formSelectionList.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                if (!lstUpgrades.Items.Cast<SelectListItem>().Any(x => x.Id == formSelectionList.selectionItem.Id))
                {
                    lstUpgrades.Items.Add(formSelectionList.selectionItem);
                }
                else
                {
                    MessageBox.Show("Card already has that upgrade");
                }
            }
        }

        private void lstUpgrades_DoubleClick(object sender, EventArgs e)
        {
            var selectedRecord = lstUpgrades.SelectedItems.Cast<SelectListItem>().ToList()[0];

            var result = MessageBox.Show("Are you sure you want to remove " + selectedRecord.Name + " from the list?", "Remove record", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                lstUpgrades.Items.Remove(lstUpgrades.SelectedItems[0]);
            }
        }
    }
}
