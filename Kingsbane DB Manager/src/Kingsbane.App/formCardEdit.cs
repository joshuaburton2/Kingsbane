using System;
using System.Linq;
using System.Windows.Forms;
using Kingsbane.Database;
using Kingsbane.Database.Enums;
using Kingsbane.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Kingsbane.App
{
    public partial class formCardEdit : Form
    {
        private readonly KingsbaneContext _context;
        private readonly IServiceProvider _serviceProvider;

        public int? Id { get; set; }
        private Card card;

        public formCardEdit(
            IServiceProvider serviceProvider,
            KingsbaneContext context)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _context = context;
        }

        #region LoadData
        private void formCardEdit_Load(object sender, EventArgs e)
        {
            SetupComboBoxes();

            if (Id.HasValue)
            {
                this.Text = $"Edit Card: {Id}";
                card = _context.Cards
                    .Include(x => x.Units)
                    .Include(x => x.Spells)
                    .Include(x => x.Items)
                    .Single(x => x.Id == Id);

                switch (card.CardTypeId)
                {
                    case CardTypes.Unit:
                        if (!card.Units.Any())
                        {
                            card.CardTypeId = CardTypes.Default;
                        }
                        if (card.Spells.Any())
                        {
                            _context.CardSpells.Remove(card.Spells.FirstOrDefault());
                        }
                        if (card.Items.Any())
                        {
                            _context.CardItems.Remove(card.Items.FirstOrDefault());
                        }

                        break;
                    case CardTypes.Spell:
                        if (!card.Spells.Any())
                        {
                            card.CardTypeId = CardTypes.Default;
                        }
                        if (card.Units.Any())
                        {
                            _context.CardUnits.Remove(card.Units.FirstOrDefault());
                        }
                        if (card.Items.Any())
                        {
                            _context.CardItems.Remove(card.Items.FirstOrDefault());
                        }

                        break;
                    case CardTypes.Item:
                        if (!card.Items.Any())
                        {
                            card.CardTypeId = CardTypes.Default;
                        }
                        if (card.Units.Any())
                        {
                            _context.CardUnits.Remove(card.Units.FirstOrDefault());
                        }
                        if (card.Spells.Any())
                        {
                            _context.CardSpells.Remove(card.Spells.FirstOrDefault());
                        }

                        break;
                    case CardTypes.Default:
                    default:
                        break;
                }

                LoadCardData();
            }
            else
            {
                this.Text = "Add Card";

                SetActiveTypeFields(CardTypes.Default);
            }
        }

        private void SetupComboBoxes()
        {
            var classes = Enum.GetValues(typeof(CardClasses)).Cast<CardClasses>().Select(x => new SelectListItem { Id = (int)x, Name = x.ToString() }).ToArray();
            cmbClass.Items.AddRange(classes);

            var rarities = Enum.GetValues(typeof(CardRarities)).Cast<CardRarities>().Select(x => new SelectListItem { Id = (int)x, Name = x.ToString() }).ToArray();
            cmbRarity.Items.AddRange(rarities);

            var cardTypes = Enum.GetValues(typeof(CardTypes)).Cast<CardTypes>().Select(x => new SelectListItem { Id = (int)x, Name = x.ToString() }).ToArray();
            cmbType.Items.AddRange(cardTypes);

            var sets = _context.Set.Select(x => new SelectListItem { Id = x.Id, Name = x.Name }).ToArray();
            cmbSet.Items.AddRange(sets);
        }

        private void LoadCardData()
        {
            textName.Text = card.Name;
            txtImageName.Text = card.ImageLocation;

            txtCardText.Text = card.Text;
            txtLoreText.Text = card.LoreText;
            txtNotes.Text = card.Notes;

            cmbClass.SelectedItem = SetComboItem(cmbClass, (int)card.CardClassId);
            cmbRarity.SelectedItem = SetComboItem(cmbRarity, (int)card.RarityId);
            cmbSet.SelectedItem = SetComboItem(cmbSet, card.SetId);

            cmbType.SelectedItem = SetComboItem(cmbType, (int)card.CardTypeId);
            UpdateTypeFields(card.CardTypeId);

            UpdateResourceFields();

            UpdateListBoxes();
        }

        private SelectListItem SetComboItem (ComboBox cmb, int Id)
        {
            return cmb.Items.Cast<SelectListItem>().FirstOrDefault(x => x.Id == Id);
        }

        private void UpdateTypeFields(CardTypes cardType)
        {
            switch (cardType)
            {
                case CardTypes.Unit:
                    var cardUnit = card.Units.FirstOrDefault();

                    txtUnitTag.Text = cardUnit.UnitTag;
                    txtAttack.Text = cardUnit.Attack.ToString();
                    txtHealth.Text = cardUnit.Health.ToString();
                    txtRange.Text = cardUnit.Range.ToString();
                    txtSpeed.Text = cardUnit.Speed.ToString();
                    break;
                case CardTypes.Spell:
                    var cardSpell = card.Spells.FirstOrDefault();

                    txtSpellType.Text = cardSpell.SpellType;
                    txtSpellRange.Text = cardSpell.Range.ToString();
                    break;
                case CardTypes.Item:
                    var cardItem = card.Items.FirstOrDefault();

                    txtItemTag.Text = cardItem.ItemTag;
                    txtDurability.Text = cardItem.Durability.ToString();
                    break;
                case CardTypes.Default:
                default:
                    break;
            }

            SetActiveTypeFields(cardType);
        }

        private void SetActiveTypeFields(CardTypes cardType)
        {
            grpUnit.Enabled = false;
            grpSpell.Enabled = false;
            grpItem.Enabled = false;

            switch (cardType)
            {
                case CardTypes.Unit:
                    grpUnit.Enabled = true;
                    break;
                case CardTypes.Spell:
                    grpSpell.Enabled = true;
                    break;
                case CardTypes.Item:
                    grpItem.Enabled = true;
                    break;
                case CardTypes.Default:
                default:
                    break;
            }
        }

        private void UpdateResourceFields()
        {
            UpdateResourceField(card.ResourceDevotion, txtDevotion, chkDevotion);
            UpdateResourceField(card.ResourceEnergy, txtEnergy, chkEnergy);
            UpdateResourceField(card.ResourceGold, txtGold, chkGold);
            UpdateResourceField(card.ResourceKnowledge, txtKnowledge, chkKnowledge);
            UpdateResourceField(card.ResourceMana, txtMana, chkMana);
            UpdateResourceField(card.ResourceWild, txtWild, chkWild);
            UpdateResourceField(card.ResourceNeutral, txtNeutral, chkNeutral);
        }

        private void UpdateResourceField(int? resourceVal, TextBox resourceTxt, CheckBox resourceChk)
        {
            if (resourceVal.HasValue)
            {
                resourceChk.Checked = true;
                resourceTxt.Text = resourceVal.ToString();
            }
            else
            {
                resourceChk.Checked = false;
            }
        }


        private void UpdateListBoxes()
        {
            var tags = _context.CardTags.Where(x => x.CardId == card.Id).Select(x => new SelectListItem { Id = x.Tag.Id, Name = x.Tag.Name }).ToArray();
            lstTags.Items.Clear();
            lstTags.Items.AddRange(tags);

            var synergies = _context.CardSynergies.Where(x => x.CardId == card.Id).Select(x => new SelectListItem { Id = x.Synergy.Id, Name = x.Synergy.Name }).ToArray();
            lstSynergies.Items.Clear();
            lstSynergies.Items.AddRange(synergies);

            var relatedCards = _context.RelatedCards.Where(x => x.CardId == card.Id).Select(x => new SelectListItem { Id = x.RelatedCard.Id, Name = x.RelatedCard.Name }).ToArray();
            lstRelatedCards.Items.Clear();
            lstRelatedCards.Items.AddRange(relatedCards);
        }
        #endregion

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!Id.HasValue)
            {
                card = new Card();
                _context.Cards.Add(card);
            }

            card.Name = textName.Text;
            card.ImageLocation = txtImageName.Text;
            card.CardClassId = (CardClasses)((SelectListItem)cmbClass.SelectedItem).Id;
            card.RarityId = (CardRarities)((SelectListItem)cmbRarity.SelectedItem).Id;
            card.Text = txtCardText.Text;
            card.LoreText = txtLoreText.Text;
            card.Notes = txtNotes.Text;

            card.ResourceDevotion = AddResource(chkDevotion, txtDevotion);
            card.ResourceEnergy = AddResource(chkEnergy, txtEnergy);
            card.ResourceGold = AddResource(chkGold, txtGold);
            card.ResourceKnowledge = AddResource(chkKnowledge, txtKnowledge);
            card.ResourceMana = AddResource(chkMana, txtMana);
            card.ResourceWild = AddResource(chkWild, txtWild);
            card.ResourceNeutral = AddResource(chkNeutral, txtNeutral);

            card.SetId = ((SelectListItem)cmbSet.SelectedItem).Id;

            #region AddCardTags
            var cardTagIDs = lstTags.Items.Cast<SelectListItem>().Select(x => x.Id).ToList();

            foreach (var tagId in cardTagIDs)
            {
                var cardTag = Id.HasValue ? _context.CardTags.SingleOrDefault(x => x.CardId == Id.Value && x.TagId == tagId) : null;
                if (cardTag == null)
                    _context.CardTags.Add(new CardTag { Card = card, TagId = tagId });
            }
            if (Id.HasValue)
            {
                var cardTags = _context.CardTags.Where(x => x.CardId == Id.Value && !cardTagIDs.Contains(x.TagId));
                _context.CardTags.RemoveRange(cardTags);
            }
            #endregion

            #region AddCardSyngergies
            var cardSyngeryIDs = lstSynergies.Items.Cast<SelectListItem>().Select(x => x.Id).ToList();

            foreach (var synergyId in cardSyngeryIDs)
            {
                var cardSynergy = Id.HasValue ? _context.CardSynergies.SingleOrDefault(x => x.CardId == Id.Value && x.SynergyId == synergyId) : null;
                if (cardSynergy == null)
                    _context.CardSynergies.Add(new CardSynergy { Card = card, SynergyId = synergyId });
            }
            if (Id.HasValue)
            {
                var cardSynergies = _context.CardSynergies.Where(x => x.CardId == Id.Value && !cardSyngeryIDs.Contains(x.SynergyId));
                _context.CardSynergies.RemoveRange(cardSynergies);
            }
            #endregion

            #region AddRelatedCards
            var relatedCardIDs = lstRelatedCards.Items.Cast<SelectListItem>().Select(x => x.Id).ToList();

            foreach (var relatedCardId in relatedCardIDs)
            {
                var relatedCard = Id.HasValue ? _context.RelatedCards.SingleOrDefault(x => x.CardId == Id.Value && x.RelatedCardId == relatedCardId) : null;
                if (relatedCard == null)
                    _context.RelatedCards.Add(new RelatedCards { Card = card, CardId = relatedCardId });
            }
            if (Id.HasValue)
            {
                var relatedCards = _context.RelatedCards.Where(x => x.CardId == Id.Value && !relatedCardIDs.Contains(x.RelatedCardId));
                _context.RelatedCards.RemoveRange(relatedCards);
            }
            #endregion

            AddTypeProperties((CardTypes)((SelectListItem)cmbType.SelectedItem).Id);

            _context.SaveChanges();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private int? AddResource(CheckBox checkBox, TextBox textBox)
        {
            if (checkBox.Checked)
            {
                if (int.TryParse(textBox.Text, out int value))
                {
                    return value;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private void AddTypeProperties(CardTypes cardType)
        {
            card.CardTypeId = cardType;

            switch (cardType)
            {
                case CardTypes.Unit:
                    var cardUnit = new CardUnit();
                    if (card.Units.Any())
                    {
                        cardUnit = card.Units.FirstOrDefault();
                    }
                    else
                    {
                        card.Units.Add(cardUnit);
                    }

                    cardUnit.Attack = GetStat(txtAttack);
                    cardUnit.Health = GetStat(txtHealth);
                    cardUnit.Range = GetStat(txtRange);
                    cardUnit.Speed = GetStat(txtSpeed);
                    cardUnit.UnitTag = txtUnitTag.Text;

                    break;
                case CardTypes.Spell:
                    var cardSpell = new CardSpell();
                    if (card.Spells.Any())
                    {
                        cardSpell = card.Spells.FirstOrDefault();
                    }
                    else
                    {
                        card.Spells.Add(cardSpell);
                    }

                    cardSpell.Range = GetStat(txtSpellRange);
                    cardSpell.SpellType = txtSpellType.Text;

                    break;
                case CardTypes.Item:
                    var cardItem = new CardItem();
                    if (card.Items.Any())
                    {
                        cardItem = card.Items.FirstOrDefault();
                    }
                    else
                    {
                        card.Items.Add(cardItem);
                    }

                    cardItem.Durability = GetStat(txtDurability);
                    cardItem.ItemTag = txtItemTag.Text;

                    break;
                default:
                case CardTypes.Default:
                    break;
            }
        }

        private int GetStat(TextBox textBox)
        {
            if (int.TryParse(textBox.Text, out int result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this card?", "Check Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (Id.HasValue)
                {
                    card.Units.Clear();
                    card.Spells.Clear();
                    card.Items.Clear();
                    _context.Remove(card);
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void btnAddRelatedCard_Click(object sender, EventArgs e)
        {
            SelectionForm(SelectionType.RelatedCard);
        }

        private void btnAddTag_Click(object sender, EventArgs e)
        {
            SelectionForm(SelectionType.Tag);
        }

        private void btnAddSynergy_Click(object sender, EventArgs e)
        {
            SelectionForm(SelectionType.Synergy);
        }

        private void SelectionForm(SelectionType selectionType)
        {
            var formSelectionList = _serviceProvider.GetRequiredService<formSelectionList>();
            formSelectionList.selectionType = selectionType;
            var result = formSelectionList.ShowDialog(this);

            if(result == DialogResult.OK)
            {
                switch (selectionType)
                {
                    case SelectionType.Tag:
                        if (!lstTags.Items.Cast<SelectListItem>().ToList().Contains(formSelectionList.selectionItem))
                        {
                            lstTags.Items.Add(formSelectionList.selectionItem);
                        }
                        else
                        {
                            MessageBox.Show("Card already has that tag");
                        }

                        break;
                    case SelectionType.Synergy:
                        if (!lstSynergies.Items.Contains(formSelectionList.selectionItem))
                        {
                            lstSynergies.Items.Add(formSelectionList.selectionItem);
                        }
                        else
                        {
                            MessageBox.Show("Card already has that synergy");
                        }

                        break;
                    case SelectionType.RelatedCard:
                        if (!lstRelatedCards.Items.Contains(formSelectionList.selectionItem))
                        {
                            lstRelatedCards.Items.Add(formSelectionList.selectionItem);
                        }
                        else
                        {
                            MessageBox.Show("Card already has that related card");
                        }
                        

                        break;
                }
            }
        }

        private void ClickListRecord(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var listBox = (ListBox)sender;
                var selectedRecord = listBox.SelectedItems.Cast<SelectListItem>().ToList()[0];

                var result = MessageBox.Show("Are you sure you want to remove " + selectedRecord.Name + " from the list?", "Remove record", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    listBox.Items.Remove(listBox.SelectedItems[0]);
                }
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetActiveTypeFields((CardTypes)((SelectListItem)cmbType.SelectedItem).Id);
        }
    }
}
