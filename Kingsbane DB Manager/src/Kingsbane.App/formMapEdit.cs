using Kingsbane.Database;
using Kingsbane.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kingsbane.App
{
    public partial class formMapEdit : Form
    {
        private readonly KingsbaneContext _context;
        private readonly IServiceProvider _serviceProvider;

        public int? Id { get; set; }
        private Map card;

        public formMapEdit(
            IServiceProvider serviceProvider,
            KingsbaneContext context)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _context = context;
        }

        private void formMapEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
