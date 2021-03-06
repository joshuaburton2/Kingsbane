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
                    .Include(x => x.Units).ThenInclude(x => x.Abilities)
                    .Include(x => x.Units).ThenInclude(x => x.UnitKeywords).ThenInclude(x => x.Keyword)
                    .Include(x => x.Spells)
                    .Include(x => x.Items)
                    .Include(x => x.Tags).ThenInclude(x => x.Tag)
                    .Include(x => x.Synergies).ThenInclude(x => x.Synergy)
                    .Include(x => x.RelatedCards).ThenInclude(x => x.RelatedCard)
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

        private SelectListItem SetComboItem(ComboBox cmb, int Id)
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
                    txtProtected.Text = cardUnit.Protected.ToString();
                    txtEmpowered.Text = cardUnit.Empowered.ToString();
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
            //_context.CardTags.Where(x => x.CardId == card.Id)
            var tags = card.Tags.Select(x => new SelectListItem { Id = x.Tag.Id, Name = x.Tag.Name }).ToArray();
            lstTags.Items.Clear();
            lstTags.Items.AddRange(tags);

            //_context.CardSynergies.Where(x => x.CardId == card.Id).
            var synergies = card.Synergies.Select(x => new SelectListItem { Id = x.Synergy.Id, Name = x.Synergy.Name }).ToArray();
            lstSynergies.Items.Clear();
            lstSynergies.Items.AddRange(synergies);

            //_context.RelatedCards.Where(x => x.CardId == card.Id).
            var relatedCards = card.RelatedCards.Select(x => new SelectListItem { Id = x.RelatedCard.Id, Name = x.RelatedCard.Name }).ToArray();
            lstRelatedCards.Items.Clear();
            lstRelatedCards.Items.AddRange(relatedCards);

            lstAbilities.Items.Clear();
            lstKeywords.Items.Clear();
            if (card.CardTypeId == CardTypes.Unit)
            {
                RefreshAbilityList();

                var keywords = card.Units.FirstOrDefault().UnitKeywords.Select(x => new SelectListItem { Id = (int)x.KeywordId, Name = x.Keyword.Name }).ToArray();
                lstKeywords.Items.AddRange(keywords);
            }
        }

        private void RefreshAbilityList()
        {
            lstAbilities.Items.Clear();
            var abilities = card.Units.FirstOrDefault().Abilities.Select(x => new SelectListItem { Id = x.Id, Name = x.Name }).ToArray();
            lstAbilities.Items.AddRange(abilities);
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
                //var cardTag = Id.HasValue ? _context.CardTags.SingleOrDefault(x => x.CardId == Id.Value && x.TagId == tagId) : null;
                var cardTag = Id.HasValue ? card.Tags.SingleOrDefault(x => x.TagId == tagId) : null;
                if (cardTag == null)
                    _context.CardTags.Add(new CardTag { Card = card, TagId = tagId });
            }
            if (Id.HasValue)
            {
                //var cardTags = _context.CardTags.Where(x => x.CardId == Id.Value && !cardTagIDs.Contains(x.TagId));
                var cardTags = card.Tags.Where(x => !cardTagIDs.Contains(x.TagId));
                _context.CardTags.RemoveRange(cardTags);
            }
            #endregion

            #region AddCardSyngergies
            var cardSyngeryIDs = lstSynergies.Items.Cast<SelectListItem>().Select(x => x.Id).ToList();

            foreach (var synergyId in cardSyngeryIDs)
            {
                //var cardSynergy = Id.HasValue ? _context.CardSynergies.SingleOrDefault(x => x.CardId == Id.Value && x.SynergyId == synergyId) : null;
                var cardSynergy = Id.HasValue ? card.Synergies.SingleOrDefault(x => x.SynergyId == synergyId) : null;
                if (cardSynergy == null)
                    _context.CardSynergies.Add(new CardSynergy { Card = card, SynergyId = synergyId });
            }
            if (Id.HasValue)
            {
                //var cardSynergies = _context.CardSynergies.Where(x => x.CardId == Id.Value && !cardSyngeryIDs.Contains(x.SynergyId));
                var cardSynergies = card.Synergies.Where(x => !cardSyngeryIDs.Contains(x.SynergyId));
                _context.CardSynergies.RemoveRange(cardSynergies);
            }
            #endregion

            #region AddRelatedCards
            var relatedCardIDs = lstRelatedCards.Items.Cast<SelectListItem>().Select(x => x.Id).ToList();

            foreach (var relatedCardId in relatedCardIDs)
            {
                //var relatedCard = Id.HasValue ? _context.RelatedCards.SingleOrDefault(x => x.CardId == Id.Value && x.RelatedCardId == relatedCardId) : null;
                var relatedCard = Id.HasValue ? card.RelatedCards.SingleOrDefault(x => x.RelatedCardId == relatedCardId) : null;
                if (relatedCard == null)
                    _context.RelatedCards.Add(new RelatedCards { Card = card, RelatedCardId = relatedCardId });
            }
            if (Id.HasValue)
            {
                //var relatedCards = _context.RelatedCards.Where(x => x.CardId == Id.Value && !relatedCardIDs.Contains(x.RelatedCardId));
                var relatedCards = card.RelatedCards.Where(x => !relatedCardIDs.Contains(x.RelatedCardId));
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
                    cardUnit.Protected = GetStat(txtProtected);
                    cardUnit.Empowered = GetStat(txtEmpowered);
                    cardUnit.UnitTag = txtUnitTag.Text;

                    var abilityIds = lstAbilities.Items.Cast<SelectListItem>().Select(x => x.Id).ToList();
                    foreach (var abilityId in abilityIds)
                    {
                        var ability = _context.Abilities.FirstOrDefault(x => x.Id == abilityId);
                        ability.Card = cardUnit;
                        cardUnit.Abilities.Add(ability);
                    }

                    var keywordIds = lstKeywords.Items.Cast<SelectListItem>().Select(x => x.Id).ToList();
                    foreach (var keywordId in keywordIds)
                    {
                        var unitKeyword = Id.HasValue ? cardUnit.UnitKeywords.SingleOrDefault(x => x.KeywordId == (Keywords)keywordId) : null;
                        if (unitKeyword == null)
                            _context.UnitKeywords.Add(new UnitKeyword { CardUnit = cardUnit, KeywordId = (Keywords)keywordId });
                    }
                    if (Id.HasValue)
                    {
                        //var cardTags = _context.CardTags.Where(x => x.CardId == Id.Value && !cardTagIDs.Contains(x.TagId));
                        var unitKeywords = cardUnit.UnitKeywords.Where(x => !keywordIds.Contains((int)x.KeywordId));
                        _context.UnitKeywords.RemoveRange(unitKeywords);
                    }

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
                    _context.RelatedCards.RemoveRange(_context.RelatedCards.Where(x => x.CardId == card.Id || x.RelatedCardId == card.Id));
                    card.Units.Clear();
                    card.Spells.Clear();
                    card.Items.Clear();
                    card.Tags.Clear();
                    card.Synergies.Clear();
                    if (card.CardTypeId == CardTypes.Unit)
                    {
                        _context.Abilities.RemoveRange(_context.Abilities.Where(x => x.CardId == card.Id));
                    }
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
            SelectionForm(SelectionType.Cards);
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

            if (result == DialogResult.OK)
            {
                switch (selectionType)
                {
                    case SelectionType.Tag:
                        if (!lstTags.Items.Cast<SelectListItem>().Any(x => x.Id == formSelectionList.selectionItem.Id))
                        {
                            lstTags.Items.Add(formSelectionList.selectionItem);
                        }
                        else
                        {
                            MessageBox.Show("Card already has that tag");
                        }
                        break;
                    case SelectionType.Synergy:
                        if (!lstSynergies.Items.Cast<SelectListItem>().Any(x => x.Id == formSelectionList.selectionItem.Id))
                        {
                            lstSynergies.Items.Add(formSelectionList.selectionItem);
                        }
                        else
                        {
                            MessageBox.Show("Card already has that synergy");
                        }
                        break;
                    case SelectionType.Cards:
                        if (!lstRelatedCards.Items.Cast<SelectListItem>().Any(x => x.Id == formSelectionList.selectionItem.Id))
                        {
                            lstRelatedCards.Items.Add(formSelectionList.selectionItem);
                        }
                        else
                        {
                            MessageBox.Show("Card already has that related card");
                        }
                        break;
                    case SelectionType.Keywords:
                        if (!lstKeywords.Items.Cast<SelectListItem>().Any(x => x.Id == formSelectionList.selectionItem.Id))
                        {
                            lstKeywords.Items.Add(formSelectionList.selectionItem);
                        }
                        else
                        {
                            MessageBox.Show("Card already has that keyword");
                        }
                        break;
                }
            }
        }

        private void ClickListRecord(object sender, EventArgs e)
        {
            var listBox = (ListBox)sender;
            if (listBox.SelectedItems.Count == 1)
            {
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

        private void btnAddAbility_Click(object sender, EventArgs e)
        {
            EditAbility(null);
        }

        private void lstAbilities_DoubleClick(object sender, EventArgs e)
        {
            var listBox = (ListBox)sender;
            if (listBox.SelectedItems.Count == 1)
            {
                var selectedAbility = listBox.SelectedItems.Cast<SelectListItem>().ToList()[0];
                EditAbility(selectedAbility.Id);
            }
        }

        private void EditAbility(int? id)
        {
            var formEditAbility = _serviceProvider.GetRequiredService<formEditAbility>();
            formEditAbility.Id = id;
            formEditAbility.CardId = Id;
            var result = formEditAbility.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                if (!lstAbilities.Items.Cast<SelectListItem>().Any(x => x.Id == formEditAbility.selectionItem.Id))
                {
                    lstAbilities.Items.Add(formEditAbility.selectionItem);
                }
                else
                {
                    var selectedAbility = lstAbilities.Items.Cast<SelectListItem>().FirstOrDefault(x => x.Id == formEditAbility.selectionItem.Id);
                    lstAbilities.Items.Remove(selectedAbility);
                    selectedAbility.Name = formEditAbility.selectionItem.Name;
                    lstAbilities.Items.Add(selectedAbility);
                }
            }

            if(result == DialogResult.Abort)
            {
                var removeList = lstAbilities.Items.Cast<SelectListItem>().FirstOrDefault(x => x.Id == formEditAbility.selectionItem.Id);
                lstAbilities.Items.Remove(removeList);
            }
        }

        private void btnAddKeyword_Click(object sender, EventArgs e)
        {
            SelectionForm(SelectionType.Keywords);
        }
    }
}
