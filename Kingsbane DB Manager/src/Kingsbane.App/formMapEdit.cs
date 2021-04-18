using Kingsbane.Database;
using Kingsbane.Database.Enums;
using Kingsbane.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace Kingsbane.App
{
    public partial class formMapEdit : Form
    {
        private enum KeyTypes
        {
            Terrain,
            Deployment,
            Objectives,
        }

        private readonly KingsbaneContext _context;
        private readonly IServiceProvider _serviceProvider;

        public int? Id { get; set; }
        private Map map;

        private const int GRID_SIZE = 10;
        private List<List<Button>> mapButtons;

        private List<Button> keyButtons;

        private readonly Dictionary<TerrainTypes, Color> terrainColours = new Dictionary<TerrainTypes, Color>()
        {
            { TerrainTypes.Regular, Color.FromArgb(67, 166, 37) },
            { TerrainTypes.Difficult, Color.FromArgb(224, 169, 52) },
            { TerrainTypes.Obstacle, Color.FromArgb(185, 89, 38) },
            { TerrainTypes.Impassable, Color.FromArgb(171, 0, 0) },
            { TerrainTypes.TallObstacle, Color.FromArgb(65, 65, 65) },
            { TerrainTypes.Chasm, Color.FromArgb(18, 122, 204) },
        };

        private readonly List<Color> playerColours = new List<Color>()
        {
            Color.FromArgb(26, 48, 236),
            Color.FromArgb(204, 36, 36),
        };
        
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
            var keyTypes = Enum.GetValues(typeof(KeyTypes)).Cast<KeyTypes>().Select(x => new SelectListItem { Id = (int)x, Name = x.ToString() }).ToArray();
            cmbKeyType.Items.AddRange(keyTypes);
            keyButtons = new List<Button>();
            cmbKeyType.SelectedIndex = 0;

            mapButtons = new List<List<Button>>(GRID_SIZE);

            var cellSize = 37;
            var currentRowPos = 15;

            for (int y = 0; y < GRID_SIZE; y++)
            {
                var rowButtons = new List<Button>(GRID_SIZE);
                mapButtons.Add(rowButtons);

                var rowOffset = cellSize / 2;
                var baseColumnPos = 5;
                var currentColumnPos = y % 2 == 0 ? baseColumnPos : rowOffset + baseColumnPos;

                for (int x = 0; x < GRID_SIZE; x++)
                {
                    var gridButton = new Button()
                    {
                        Location = new Point(currentColumnPos, currentRowPos),
                        Name = $"Cell{y}.{x}",
                        Size = new Size(cellSize, cellSize),
                        TabIndex = 0,
                        Text = "",
                        UseVisualStyleBackColor = true,
                        Tag = new List<int> { x, y },
                    };

                    rowButtons.Add(gridButton);
                    pnlMap.Controls.Add(gridButton);

                    currentColumnPos += cellSize;
                }

                currentRowPos += cellSize;
            }

            if (Id.HasValue)
            {
                Text = $"Edit Map: {Id}";

                map = _context.Maps
                    .Include(x => x.Scenarios).ThenInclude(x => x.DeploymentMap)
                    .Include(x => x.Scenarios).ThenInclude(x => x.ObjectiveMap).ThenInclude(x => x.Objective)
                    .Include(x => x.Scenarios).ThenInclude(x => x.ScenarioRuleSet).ThenInclude(x => x.Rule)
                    .Include(x => x.Scenarios).ThenInclude(x => x.EnemyDeck)
                    .Include(x => x.TerrainMap)
                    .Single(x => x.Id == Id);

                LoadMapData();
            }
            else
            {
                this.Text = "Add Card";
            }
        }

        private void LoadMapData()
        {
            txtName.Text = map.Name;
            txtColourMap.Text = map.ColourMapName;
            txtDescription.Text = map.Decription;

            LoadScenarioData();
        }

        private void LoadScenarioData()
        {

        }

        private void RefreshKeyItems()
        {
            foreach (var keyButton in keyButtons)
            {
                Controls.Remove(keyButton);
            }

            var selectedKey = (KeyTypes)((SelectListItem)cmbKeyType.SelectedItem).Id;

            var baseKeyPos = new Vector2(5, 70);
            var keyItemDistance = 35;

            switch (selectedKey)
            {
                case KeyTypes.Terrain:
                    foreach (var terrainType in Enum.GetValues(typeof(TerrainTypes)).Cast<TerrainTypes>())
                    {
                        var terrainColour = terrainColours.GetValueOrDefault(terrainType);
                        CreateKeyItem(baseKeyPos, terrainType.ToString(), terrainColour);
                        baseKeyPos.Y += keyItemDistance;
                    }
                    break;
                case KeyTypes.Deployment:
                    for (int playerId = 0; playerId < 2; playerId++)
                    {

                    }
                    break;
                case KeyTypes.Objectives:
                    break;
            }
        }

        private void CreateKeyItem(Vector2 pos, string itemText, Color itemColour)
        {
            var keyButton = new Button()
            {
                Location = new Point((int)pos.X, (int)pos.Y),
                Name = $"Key Item: {itemText}",
                Size = new Size(190, 35),
                TabIndex = 0,
                Text = itemText,
                UseVisualStyleBackColor = true,
            };

            keyButton.BackColor = itemColour;

            keyButtons.Add(keyButton);
            pnlKey.Controls.Add(keyButton);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this card?", "Check Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (Id.HasValue)
                {
                    foreach (var scenario in map.Scenarios)
                    {

                    }

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

        private void cmbKeyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshKeyItems();
        }
    }
}
