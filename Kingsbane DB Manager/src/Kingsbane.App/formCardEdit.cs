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
            if (Id.HasValue)
            {
                this.Text = $"Edit Card: {Id}";
                card = _context.Cards.Single(x => x.Id == Id);

                textName.Text = card.Name;
            }
            else
            {
                this.Text = "Add Card";
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }
    }
}
