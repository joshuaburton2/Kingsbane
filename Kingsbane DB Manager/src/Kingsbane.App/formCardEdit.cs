using System;
using System.Linq;
using System.Windows.Forms;
using Kingsbane.Database;
using Kingsbane.Database.Enums;
using Kingsbane.Database.Models;

namespace Kingsbane.App
{
    public partial class formCardEdit : Form
    {
        private readonly KingsbaneContext _context;

        public int? Id { get; set; }
        private Card card;

        public formCardEdit(KingsbaneContext context)
        {
            InitializeComponent();

            _context = context;
        }

        private void formCardEdit_Load(object sender, EventArgs e)
        {
            SetupComboBoxes();

            if (Id.HasValue)
            {
                this.Text = $"Edit Card: {Id}";
                card = _context.Cards.Single(x => x.Id == Id);

                textName.Text = card.Name;
                txtImageName.Text = card.ImageLocation;
            }
            else
            {
                this.Text = "Add Card";
            }
        }

        private void SetupComboBoxes()
        {
            string[] classes = Enum.GetValues(typeof(Classes)).Cast<Classes>().Select(x => x.ToString()).ToArray();
            cmbClass.Items.AddRange(classes);

            string[] rarities = Enum.GetValues(typeof(Rarity)).Cast<Rarity>().Select(x => x.ToString()).ToArray();
            cmbRarity.Items.AddRange(rarities);

            string[] cardTypes = Enum.GetValues(typeof(CardType)).Cast<CardType>().Select(x => x.ToString()).ToArray();
            cmbType.Items.AddRange(cardTypes);

            Set[] sets = _context.Set.ToArray();
            string[] setString = new string[sets.Length];
            for (int i = 0; i < sets.Length; i++)
            {
                setString[i] = sets[i].Name;
            }
            cmbSet.Items.AddRange(setString);
        }

        private void SetActiveTypeFields(CardType cardType)
        {
            grpUnit.Enabled = false;
            grpSpell.Enabled = false;
            grpItem.Enabled = false;

            switch (cardType)
            {
                case CardType.Default:
                    break;
                case CardType.Unit:
                    grpUnit.Enabled = true;
                    break;
                case CardType.Spell:
                    grpSpell.Enabled = true;
                    break;
                case CardType.Item:
                    grpItem.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (Id.HasValue)
            {
                card.Name = textName.Text;
            }
            else
            {
                card = new Card
                {
                    Name = textName.Text,
                    ImageLocation = "xxxx",
                    Classes = Classes.Abyssal,
                    Rarity = Rarity.Hero,
                    SetId = 1
                };
                _context.Cards.Add(card);
            }

            _context.SaveChanges();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this card?", "Check Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (Id.HasValue)
                {
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
    }
}
