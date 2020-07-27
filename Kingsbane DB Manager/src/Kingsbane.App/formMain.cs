using System;
using System.Windows.Forms;
using Kingsbane.Database;
using Microsoft.Extensions.DependencyInjection;

// ref: https://marcominerva.wordpress.com/2020/03/09/using-hostbuilder-serviceprovider-and-dependency-injection-with-windows-forms-on-net-core-3/

namespace Kingsbane.App
{
    public partial class formMain : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly KingsbaneContext _context;

        public formMain(
            IServiceProvider serviceProvider,
            KingsbaneContext context)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _context = context;
        }

        private void buttonCardList_Click(object sender, System.EventArgs e)
        {
            var formCardList = _serviceProvider.GetRequiredService<formCardList>();
            formCardList.Show();
        }
    }
}
