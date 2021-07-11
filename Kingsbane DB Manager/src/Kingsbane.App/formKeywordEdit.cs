using Kingsbane.Database;
using Kingsbane.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kingsbane.App
{
    public partial class formKeywordEdit : Form
    {
        private readonly KingsbaneContext _context;
        private readonly IServiceProvider _serviceProvider;

        public int? Id { get; set; }
        private Keyword keyword;

        public formKeywordEdit(
            IServiceProvider serviceProvider,
            KingsbaneContext context)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _context = context;
        }

        private void formKeywordEdit_Load(object sender, EventArgs e)
        {
            if (Id.HasValue)
            {
                Text = $"Edit Campaign: {Id}";
                keyword = _context.Keywords
                    .Single(x => x.Id == Id);

                LoadCampaignData();
            }
            else
            {
                Text = "Add Campaign";
            }
        }

        private void LoadCampaignData()
        {
            txtName.Text = keyword.Name;
            txtDescription.Text = keyword.Description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Id.HasValue)
            {
                keyword = new Keyword();
                _context.Keywords.Add(keyword);
            }

            keyword.Name = txtName.Text;
            keyword.Description = txtDescription.Text;

            _context.SaveChanges();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this campaign?", "Check Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (Id.HasValue)
                {
                    _context.UnitKeywords.RemoveRange(_context.UnitKeywords.Where(x => x.Keyword == keyword));
                    _context.Remove(keyword);
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
