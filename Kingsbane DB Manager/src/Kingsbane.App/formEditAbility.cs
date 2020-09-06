using Kingsbane.Database;
using Kingsbane.Database.Models;
using System;
using System.Windows.Forms;
using System.Linq;

namespace Kingsbane.App
{
    public partial class formEditAbility : Form
    {
        private readonly KingsbaneContext _context;

        public int? Id { get; set; }
        public int? CardId { get; set; }
        private Ability ability;

        public SelectListItem selectionItem;

        public formEditAbility(KingsbaneContext context)
        {
            InitializeComponent();

            _context = context;
        }

        private void formAddAbility_Load(object sender, EventArgs e)
        {
            if (Id.HasValue)
            {
                this.Text = $"Edit Ability: {Id}";

                ability = _context.Abilities.Single(x => x.Id == Id);

                txtName.Text = ability.Name;
                txtAbilityText.Text = ability.Text;
                chkAction.Checked = ability.CostsAction;

                UpdateResourceFields();
            }
            else
            {
                this.Text = "Add Ability";
            }
        }

        private void UpdateResourceFields()
        {
            UpdateResourceField(ability.ResourceDevotion, txtDevotion, chkDevotion);
            UpdateResourceField(ability.ResourceEnergy, txtEnergy, chkEnergy);
            UpdateResourceField(ability.ResourceGold, txtGold, chkGold);
            UpdateResourceField(ability.ResourceKnowledge, txtKnowledge, chkKnowledge);
            UpdateResourceField(ability.ResourceMana, txtMana, chkMana);
            UpdateResourceField(ability.ResourceWild, txtWild, chkWild);
            UpdateResourceField(ability.ResourceNeutral, txtNeutral, chkNeutral);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Id.HasValue)
            {
                ability = new Ability();
                _context.Abilities.Add(ability);
            }

            ability.Name = txtName.Text;
            ability.Text = txtAbilityText.Text;
            ability.CostsAction = chkAction.Checked;

            ability.ResourceDevotion = AddResource(chkDevotion, txtDevotion);
            ability.ResourceEnergy = AddResource(chkEnergy, txtEnergy);
            ability.ResourceGold = AddResource(chkGold, txtGold);
            ability.ResourceKnowledge = AddResource(chkKnowledge, txtKnowledge);
            ability.ResourceMana = AddResource(chkMana, txtMana);
            ability.ResourceWild = AddResource(chkWild, txtWild);
            ability.ResourceNeutral = AddResource(chkNeutral, txtNeutral);

            if (CardId.HasValue)
            {
                ability.CardId = CardId.Value;
            }
            else
            {
                ability.CardId = _context.Cards.FirstOrDefault().Id;
            }

            _context.SaveChanges();

            selectionItem = new SelectListItem() { Id = ability.Id, Name = ability.Name };

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this ability?", "Check Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                selectionItem = new SelectListItem() { Id = ability.Id, Name = ability.Name };

                if (Id.HasValue)
                {
                    _context.Remove(ability);
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
    }
}
