using Kingsbane.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Kingsbane.Database.Enums;
using System.Linq;
using Kingsbane.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Kingsbane.App
{
    public partial class formResources : Form
    {
        private readonly KingsbaneContext _context;
        private readonly IServiceProvider _serviceProvider;

        private Resource selectedResource;

        public formResources(IServiceProvider serviceProvider, KingsbaneContext context)
        {
            InitializeComponent();

            _context = context;
            _serviceProvider = serviceProvider;
        }

        private void formResources_Load(object sender, EventArgs e)
        {
            var resources = Enum.GetValues(typeof(Resources)).Cast<Resources>().Select(x => new SelectListItem() { Id = (int)x, Name = x.ToString() }).ToArray();
            cmbResource.Items.AddRange(resources);

            cmbResource.SelectedIndex = 0;

            var resourceProps = Enum.GetValues(typeof(ResourcePropertyList)).Cast<ResourcePropertyList>().Select(x => new SelectListItem() { Id = (int)x, Name = x.ToString() }).ToArray();
            cmbProperty1.Items.AddRange(resourceProps);
            cmbProperty2.Items.AddRange(resourceProps);

            RefreshFields();
        }

        private void RefreshFields()
        {
            var resourceId = (Resources)((SelectListItem)cmbResource.SelectedItem).Id;
            selectedResource = _context.Resources.Include(x => x.ResourceProperties).Single(x => x.Id == resourceId);

            txtDescription.Text = selectedResource.Description;

            var resourceProperties = _context.ResourceProps.Where(x => x.ResourceId == resourceId).ToList();
            if (!resourceProperties.Any())
            {
                _context.ResourceProps.Add(new ResourceProperty() { Type = ResourcePropertyList.Default, Resource = selectedResource });
                _context.ResourceProps.Add(new ResourceProperty() { Type = ResourcePropertyList.Default, Resource = selectedResource });

                _context.SaveChanges();

                resourceProperties = _context.ResourceProps.Where(x => x.ResourceId == resourceId).ToList();
            }
            cmbProperty1.SelectedItem = SetComboItem(cmbProperty1, (int)resourceProperties[0].Type);
            cmbProperty2.SelectedItem = SetComboItem(cmbProperty1, (int)resourceProperties[1].Type);
        }

        private SelectListItem SetComboItem(ComboBox cmb, int Id)
        {
            return cmb.Items.Cast<SelectListItem>().FirstOrDefault(x => x.Id == Id);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveResource();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            SaveResource();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SaveResource()
        {
            selectedResource.Description = txtDescription.Text;

            selectedResource.ResourceProperties.ToList()[0].Type = (ResourcePropertyList)((SelectListItem)cmbProperty1.SelectedItem).Id;
            selectedResource.ResourceProperties.ToList()[1].Type = (ResourcePropertyList)((SelectListItem)cmbProperty2.SelectedItem).Id;

            _context.SaveChanges();
        }

        private void formResources_FormClosed(object sender, FormClosedEventArgs e)
        {
            formMain formMain = new formMain(_serviceProvider, _context);
            formMain.Show();
        }

        private void cmbResource_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshFields();
        }
    }
}
