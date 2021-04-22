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


        private class ScenarioData
        {
            public int? Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int EnemyDeckId { get; set; }
            public string EnemyDeckName { get; set; }
            public List<List<int?>> DeploymentMap { get; set; }
            public List<List<int?>> ObjectiveMap { get; set; }
            public List<ObjectiveData> Objectives { get; set; }
            public List<ScenarioRuleData> ScenarioRules { get; set; }

            public ScenarioData()
            {
                DeploymentMap = new List<List<int?>>();
                ObjectiveMap = new List<List<int?>>();
                Objectives = new List<ObjectiveData>();
                ScenarioRules = new List<ScenarioRuleData>();
            }
        }

        private class ObjectiveData
        {
            public int? Id { get; set; }
            public string Name { get; set; }
            public Color Color { get; set; }
        }

        private class ScenarioRuleData
        {
            public int? Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

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
        private List<List<TerrainTypes>> terrainMap;
        private const string DEFAULT_SCENARIO_NAME = "Default Scenario";
        private List<ScenarioData> scenarioList;

        private List<Button> keyButtons;

        private KeyTypes selectedKey;
        private ScenarioData selectedScenario;

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

            mapButtons = new List<List<Button>>(GRID_SIZE);
            scenarioList = new List<ScenarioData>();

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

                CreateAddData();
            }

            cmbKeyType.SelectedIndex = 0;
        }

        private void CreateAddData()
        {
            terrainMap = new List<List<TerrainTypes>>();
            var defaultScenario = new ScenarioData()
            {
                Id = null,
                Name = DEFAULT_SCENARIO_NAME,
            };

            for (int y = 0; y < GRID_SIZE; y++)
            {
                terrainMap.Add(new List<TerrainTypes>());
                var deploymentMap = defaultScenario.DeploymentMap;
                var objectiveMap = defaultScenario.ObjectiveMap;

                deploymentMap.Add(new List<int?>());
                objectiveMap.Add(new List<int?>());
                for (int x = 0; x < GRID_SIZE; x++)
                {
                    terrainMap[y].Add(TerrainTypes.Regular);
                    objectiveMap[y].Add(null);
                    if (y == 0 || y == 1)
                        deploymentMap[y].Add(1);
                    else if (y == GRID_SIZE - 1 || y == GRID_SIZE - 2)
                        deploymentMap[y].Add(0);
                    else
                        deploymentMap[y].Add(null);
                }
            }

            selectedScenario = defaultScenario;
            scenarioList.Add(selectedScenario);
        }

        private void LoadMapData()
        {
            txtName.Text = map.Name;
            txtColourMap.Text = map.ColourMapName;
            txtDescription.Text = map.Decription;

            terrainMap = new List<List<TerrainTypes>>();
            for (int y = 0; y < GRID_SIZE; y++)
            {
                var row = new List<TerrainTypes>();
                terrainMap.Add(row);
                for (int x = 0; x < GRID_SIZE; x++)
                {
                    var cell = map.TerrainMap.Single(cell => cell.RowId == y && cell.ColumnId == y);
                    row.Add(cell.TerrainId);
                }
            }

            LoadScenarioData();
        }

        private void LoadScenarioData()
        {
            foreach (var scenario in map.Scenarios)
            {
                var scenarioData = new ScenarioData()
                {
                    Id = scenario.Id,
                    Name = scenario.Name,
                    Description = scenario.Decription,
                    EnemyDeckId = scenario.EnemyDeckId,
                    EnemyDeckName = scenario.EnemyDeck.Name,
                };

                foreach (var objective in scenario.Objectives)
                {
                    var objectiveData = new ObjectiveData()
                    {
                        Id = objective.Id,
                        Name = objective.Name,
                        Color = Color.FromArgb(objective.Red, objective.Green, objective.Blue),
                    };

                    scenarioData.Objectives.Add(objectiveData);
                }

                foreach (var scenarioRule in scenario.ScenarioRuleSet)
                {
                    var scenarioRuleData = new ScenarioRuleData()
                    {
                        Id = scenarioRule.RuleId,
                        Name = scenarioRule.Rule.Name,
                        Description = scenarioRule.Rule.Decription,
                    };

                    scenarioData.ScenarioRules.Add(scenarioRuleData);
                }

                scenarioData.DeploymentMap = new List<List<int?>>();
                scenarioData.ObjectiveMap = new List<List<int?>>();
                for (int y = 0; y < GRID_SIZE; y++)
                {
                    var deploymentRow = new List<int?>();
                    var objectiveRow = new List<int?>();
                    scenarioData.DeploymentMap.Add(deploymentRow);
                    scenarioData.ObjectiveMap.Add(objectiveRow);
                    for (int x = 0; x < GRID_SIZE; x++)
                    {
                        var deploymentCell = scenario.DeploymentMap.Single(cell => cell.RowId == y && cell.ColumnId == y);
                        var objectiveCell = scenario.ObjectiveMap.Single(cell => cell.RowId == y && cell.ColumnId == y);
                        deploymentRow.Add(deploymentCell.PlayerId);
                        objectiveRow.Add(scenarioData.Objectives.FindIndex(x => x.Id == objectiveCell.ObjectiveId));
                    }
                }

                scenarioList.Add(scenarioData);
            }

            cmbScenarioSelector.SelectedIndex = 0;
        }

        private void RefreshKeyItems()
        {
            foreach (var keyButton in keyButtons)
            {
                pnlKey.Controls.Remove(keyButton);
            }

            selectedKey = (KeyTypes)((SelectListItem)cmbKeyType.SelectedItem).Id;

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
                        var playerColour = playerColours[playerId];
                        CreateKeyItem(baseKeyPos, $"Player: {playerId + 1}", playerColour);
                        baseKeyPos.Y += keyItemDistance;
                    }
                    break;
                case KeyTypes.Objectives:
                    break;
            }

            RefreshMapFilter();
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

        private void RefreshMapFilter()
        {
            for (int y = 0; y < GRID_SIZE; y++)
            {
                for (int x = 0; x < GRID_SIZE; x++)
                {
                    Color colour = Color.White;
                    switch (selectedKey)
                    {
                        case KeyTypes.Terrain:
                            colour = terrainColours.GetValueOrDefault(terrainMap[y][x]);
                            break;
                        case KeyTypes.Deployment:
                            var deploymentCell = selectedScenario.DeploymentMap[y][x];
                            if (deploymentCell.HasValue)
                                colour = playerColours[deploymentCell.Value];
                            break;
                        case KeyTypes.Objectives:
                            var objectiveCell = selectedScenario.ObjectiveMap[y][x];
                            if (objectiveCell.HasValue)
                            {
                                colour = selectedScenario.Objectives[objectiveCell.Value].Color;
                            }
                            break;
                    }

                    mapButtons[y][x].BackColor = colour;
                }
            }
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

        private void cmbScenarioSelector_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
