using Kingsbane.Database;
using Kingsbane.Database.Enums;
using Kingsbane.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
            public bool IsDefault { get; set; }
            public int? EnemyDeckId { get; set; }
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

        public class ObjectiveData
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
        private int? selectedKeyIndex;
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
            Color.White,
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
                    gridButton.Click += ClickCell;
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
                    .Include(x => x.Scenarios)
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
                this.Text = "Add Map";

                CreateAddData();
            }

            cmbKeyType.SelectedIndex = 0;
            RefreshScenarioList();
        }

        private void CreateAddData()
        {
            terrainMap = new List<List<TerrainTypes>>();
            var defaultScenario = new ScenarioData()
            {
                Id = null,
                Name = DEFAULT_SCENARIO_NAME,
                IsDefault = true,
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
                    CreateScenarioTile(y, deploymentMap, objectiveMap);
                }
            }

            scenarioList.Add(defaultScenario);
        }

        private void CreateScenarioTile(int y, List<List<int?>> deploymentMap, List<List<int?>> objectiveMap)
        {
            objectiveMap[y].Add(null);
            if (y == 0)
                // || y == 1
                deploymentMap[y].Add(1);
            else if (y == GRID_SIZE - 1)
                // || y == GRID_SIZE - 2
                deploymentMap[y].Add(0);
            else
                deploymentMap[y].Add(null);
        }

        private void LoadMapData()
        {
            txtName.Text = map.Name;
            txtColourMap.Text = map.ColourMapName;
            txtDescription.Text = map.Description;

            terrainMap = new List<List<TerrainTypes>>();
            for (int y = 0; y < GRID_SIZE; y++)
            {
                var row = new List<TerrainTypes>();
                terrainMap.Add(row);
                for (int x = 0; x < GRID_SIZE; x++)
                {
                    var cell = map.TerrainMap.Single(cell => cell.RowId == y && cell.ColumnId == x);
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
                    Description = scenario.Description,
                    IsDefault = scenario.IsDefault,
                    EnemyDeckId = scenario.EnemyDeckId,
                };
                if (scenario.EnemyDeckId.HasValue)
                    scenarioData.EnemyDeckName = scenario.EnemyDeck.Name;

                foreach (var objective in scenario.ObjectiveMap.Where(x => x.ObjectiveId.HasValue).Select(x => x.Objective).Distinct())
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
                        Description = scenarioRule.Rule.Description,
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
                        var deploymentCell = scenario.DeploymentMap.Single(cell => cell.RowId == y && cell.ColumnId == x);
                        var objectiveCell = scenario.ObjectiveMap.Single(cell => cell.RowId == y && cell.ColumnId == x);
                        deploymentRow.Add(deploymentCell.PlayerId);
                        int? objectiveIndex = scenarioData.Objectives.FindIndex(x => x.Id == objectiveCell.ObjectiveId);
                        if (objectiveIndex == -1)
                            objectiveIndex = null;
                        objectiveRow.Add(objectiveIndex);
                    }
                }

                scenarioList.Add(scenarioData);
            }
            scenarioList = scenarioList.OrderByDescending(x => x.IsDefault).ThenBy(x => x.Name).ToList();
        }

        private void RefreshScenarioList()
        {
            cmbScenarioSelector.Items.Clear();
            var scenarioItems = scenarioList.Select(x => new SelectListItem() { Id = scenarioList.IndexOf(x), Name = x.Name }).ToArray();
            cmbScenarioSelector.Items.AddRange(scenarioItems);

            cmbScenarioSelector.SelectedIndex = 0;
        }

        private void RefreshKeyItems()
        {
            foreach (var keyButton in keyButtons)
            {
                pnlKey.Controls.Remove(keyButton);
            }

            selectedKey = (KeyTypes)((SelectListItem)cmbKeyType.SelectedItem).Id;
            selectedKeyIndex = null;

            var baseKeyPos = new Vector2(5, 70);
            var keyItemDistance = 35;
            int index = 0;

            switch (selectedKey)
            {
                case KeyTypes.Terrain:
                    foreach (var terrainType in Enum.GetValues(typeof(TerrainTypes)).Cast<TerrainTypes>())
                    {
                        var terrainColour = terrainColours.GetValueOrDefault(terrainType);
                        CreateKeyItem(baseKeyPos, terrainType.ToString(), terrainColour, index);
                        baseKeyPos.Y += keyItemDistance;
                        index++;
                    }
                    break;
                case KeyTypes.Deployment:
                    var numPlayers = 2;
                    for (int playerId = 0; playerId < numPlayers + 1; playerId++)
                    {
                        var playerColour = playerColours[playerId];
                        var playerText = playerId == numPlayers ? "Clear Deployment" : $"Player: {playerId + 1}";
                        var value = index == numPlayers ? -1 : index;
                        CreateKeyItem(baseKeyPos, playerText, playerColour, value);
                        baseKeyPos.Y += keyItemDistance;
                        index++;
                    }
                    break;
                case KeyTypes.Objectives:
                    foreach (var objective in selectedScenario.Objectives)
                    {
                        var objectiveColour = objective.Color;
                        var keyButton = CreateKeyItem(baseKeyPos, $"Objective: {objective.Name}", objectiveColour, index);
                        keyButton.MouseDown += EditObjectiveButton;
                        baseKeyPos.Y += keyItemDistance;
                        index++;
                    }
                    CreateKeyItem(baseKeyPos, "Clear Objective", Color.White, -1);

                    baseKeyPos.Y += keyItemDistance;
                    var addObjectiveButton = new Button()
                    {
                        Location = new Point((int)baseKeyPos.X, (int)baseKeyPos.Y),
                        Name = $"Add Objective",
                        Size = new Size(190, 35),
                        TabIndex = 0,
                        Text = "Add Objective +",
                        UseVisualStyleBackColor = true,
                    };
                    addObjectiveButton.Click += AddObjectiveButton;
                    addObjectiveButton.BackColor = Color.White;

                    keyButtons.Add(addObjectiveButton);
                    pnlKey.Controls.Add(addObjectiveButton);
                    break;
            }

            RefreshMapFilter();
        }

        private Button CreateKeyItem(Vector2 pos, string itemText, Color itemColour, int? index)
        {
            var keyButton = new Button()
            {
                Location = new Point((int)pos.X, (int)pos.Y),
                Name = $"Key Item: {itemText}",
                Size = new Size(190, 35),
                TabIndex = 0,
                Text = itemText,
                UseVisualStyleBackColor = true,
                Tag = index,
            };
            keyButton.Click += SelectKeyItem;
            keyButton.BackColor = itemColour;

            keyButtons.Add(keyButton);
            pnlKey.Controls.Add(keyButton);

            return keyButton;
        }

        private void SelectKeyItem(object sender, EventArgs e)
        {
            foreach (var keyButton in keyButtons)
            {
                keyButton.ForeColor = Color.Black;
            }

            var button = (Button)sender;

            if (selectedKeyIndex != (int)button.Tag)
            {
                selectedKeyIndex = (int)button.Tag;
                if (selectedKeyIndex == -1)
                {
                    button.ForeColor = Color.Red;
                }
                else
                {
                    button.ForeColor = Color.White;
                }
            }
            else
            {
                selectedKeyIndex = null;
            }
        }

        private void AddObjectiveButton(object sender, EventArgs e)
        {
            var newObjective = new ObjectiveData();
            EditObjective(newObjective);
        }

        private void EditObjectiveButton(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var button = (Button)sender;
                var objective = selectedScenario.Objectives[(int)button.Tag];
                EditObjective(objective);
            }
        }

        private void EditObjective(ObjectiveData objective)
        {
            var formEditObjective = _serviceProvider.GetRequiredService<formEditObjective>();
            formEditObjective.objectiveData = objective;
            var result = formEditObjective.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                if (!selectedScenario.Objectives.Contains(objective))
                    selectedScenario.Objectives.Add(objective);
            }
            else if (result == DialogResult.Abort)
            {
                var index = selectedScenario.Objectives.IndexOf(objective);
                selectedScenario.Objectives.Remove(objective);
                for (int y = 0; y < GRID_SIZE; y++)
                {
                    for (int x = 0; x < GRID_SIZE; x++)
                    {
                        var cell = selectedScenario.ObjectiveMap[y][x];
                        if (cell.HasValue)
                        {
                            if (cell.Value == index)
                            {
                                selectedScenario.ObjectiveMap[y][x] = null;
                            }
                            else if (cell.Value > index)
                            {
                                selectedScenario.ObjectiveMap[y][x]--;
                            }
                        }
                    }
                }
            }

            RefreshKeyItems();
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

        private void ClickCell(object sender, EventArgs e)
        {
            if (selectedKeyIndex.HasValue)
            {
                var button = (Button)sender;
                var cellPos = (List<int>)button.Tag;

                int? value = selectedKeyIndex.Value;
                if (selectedKeyIndex == -1)
                {
                    value = null;
                }

                switch (selectedKey)
                {
                    case KeyTypes.Terrain:
                        terrainMap[cellPos[1]][cellPos[0]] = (TerrainTypes)value;
                        break;
                    case KeyTypes.Deployment:
                        selectedScenario.DeploymentMap[cellPos[1]][cellPos[0]] = value;
                        break;
                    case KeyTypes.Objectives:
                        selectedScenario.ObjectiveMap[cellPos[1]][cellPos[0]] = value;
                        break;
                }

                RefreshMapFilter();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveRule();
            SaveScenario();

            if (!Id.HasValue)
            {
                map = new Map();
                _context.Maps.Add(map);
            }

            map.Name = txtName.Text;
            map.ColourMapName = txtColourMap.Text;
            map.Description = txtDescription.Text;

            for (int y = 0; y < GRID_SIZE; y++)
            {
                for (int x = 0; x < GRID_SIZE; x++)
                {
                    var cell = _context.TerrainMaps.SingleOrDefault(cell => cell.Map == map && cell.RowId == y && cell.ColumnId == x);
                    if (cell == null)
                    {
                        cell = new MapTerrain()
                        {
                            RowId = y,
                            ColumnId = x,
                            Map = map,
                        };
                        _context.TerrainMaps.Add(cell);
                    }
                    cell.TerrainId = terrainMap[y][x];
                }
            }

            foreach (var scenarioData in scenarioList)
            {
                var scenario = _context.Scenarios.SingleOrDefault(x => x.Id == scenarioData.Id);
                if (scenario == null)
                {
                    scenario = new Scenario()
                    {
                        Map = map,
                    };
                    _context.Scenarios.Add(scenario);

                }
                scenario.Name = scenarioData.Name;
                scenario.Description = scenarioData.Description;
                scenario.IsDefault = scenarioData.IsDefault;
                scenario.EnemyDeckId = scenarioData.EnemyDeckId;

                _context.SaveChanges();

                if (scenarioData.Id == null)
                {
                    scenarioList.Single(x => x == scenarioData).Id = scenario.Id;
                }

                foreach (var ruleData in scenarioData.ScenarioRules)
                {
                    var rule = _context.ScenarioRules.SingleOrDefault(x => x.Id == ruleData.Id);
                    if (rule == null)
                    {
                        rule = new ScenarioRule();
                        _context.ScenarioRules.Add(rule);
                    }
                    rule.Name = ruleData.Name;
                    rule.Description = ruleData.Description;

                    var scenarioRuleSet = _context.ScenarioRuleSets.SingleOrDefault(x => x.Scenario == scenario && x.Rule == rule);
                    if (scenarioRuleSet == null)
                    {
                        scenarioRuleSet = new ScenarioRuleSet();

                        rule.ScenarioRules.Add(scenarioRuleSet);
                        scenario.ScenarioRuleSet.Add(scenarioRuleSet);
                        _context.ScenarioRuleSets.Add(scenarioRuleSet);
                    }
                }

                var objectiveList = new List<Objective>();
                foreach (var objectiveData in scenarioData.Objectives)
                {
                    var objective = _context.Objectives.SingleOrDefault(x => x.Id == objectiveData.Id);
                    if (objective == null)
                    {
                        objective = new Objective();
                        _context.Objectives.Add(objective);
                    }
                    objective.Name = objectiveData.Name;
                    objective.Red = objectiveData.Color.R;
                    objective.Green = objectiveData.Color.G;
                    objective.Blue = objectiveData.Color.B;

                    objectiveList.Add(objective);
                }

                for (int y = 0; y < GRID_SIZE; y++)
                {
                    for (int x = 0; x < GRID_SIZE; x++)
                    {
                        var deploymentCell = _context.DeploymentMaps.SingleOrDefault(cell => cell.Scenario == scenario && cell.RowId == y && cell.ColumnId == x);
                        if (deploymentCell == null)
                        {
                            deploymentCell = new MapDeployment()
                            {
                                RowId = y,
                                ColumnId = x,
                                Scenario = scenario,
                            };
                            _context.DeploymentMaps.Add(deploymentCell);
                        }
                        deploymentCell.PlayerId = scenarioData.DeploymentMap[y][x];

                        var objectiveCell = _context.ObjectiveMaps.SingleOrDefault(cell => cell.Scenario == scenario && cell.RowId == y && cell.ColumnId == x);
                        if (objectiveCell == null)
                        {
                            objectiveCell = new MapObjective()
                            {
                                RowId = y,
                                ColumnId = x,
                                Scenario = scenario,
                            };
                            _context.ObjectiveMaps.Add(objectiveCell);
                        }
                        var objectiveIndex = scenarioData.ObjectiveMap[y][x];
                        if (!objectiveIndex.HasValue)
                            objectiveCell.ObjectiveId = null;
                        else
                            objectiveCell.Objective = objectiveList[objectiveIndex.Value];
                    }
                }
            }

            if (Id.HasValue)
            {
                var removeScenarios = map.Scenarios.Where(x => !scenarioList.Select(y => y.Id).Contains(x.Id));
                foreach (var removeScenario in removeScenarios)
                {
                    removeScenario.DeploymentMap.Clear();
                    removeScenario.ScenarioRuleSet.Clear();
                    var removeObjectives = removeScenario.ObjectiveMap.Where(x => x.ObjectiveId.HasValue).Select(x => x.Objective);
                    _context.Objectives.RemoveRange(removeObjectives);
                    removeScenario.ObjectiveMap.Clear();
                }
                _context.Scenarios.RemoveRange(removeScenarios);

                foreach (var scenario in map.Scenarios)
                {
                    var scenarioData = scenarioList.Single(x => x.Id == scenario.Id);

                    var removeRuleSets = scenario.ScenarioRuleSet.Where(x => !scenarioData.ScenarioRules.Any(y => y.Id == x.RuleId));
                    _context.ScenarioRuleSets.RemoveRange(removeRuleSets);

                    var removeObjectives = _context.Objectives.Where(x => !x.MapObjectives.Any());
                    _context.Objectives.RemoveRange(removeObjectives);
                }
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this card?", "Check Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (Id.HasValue)
                {
                    map.TerrainMap.Clear();
                    foreach (var scenario in map.Scenarios)
                    {
                        scenario.DeploymentMap.Clear();
                        scenario.ScenarioRuleSet.Clear();
                        var removeObjectives = scenario.ObjectiveMap.Where(x => x.ObjectiveId.HasValue).Select(x => x.Objective);
                        _context.Objectives.RemoveRange(removeObjectives);
                        scenario.ObjectiveMap.Clear();
                        _context.Scenarios.Remove(scenario);
                    }
                    _context.Maps.Remove(map);

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
            var comboBox = (ComboBox)sender;
            selectedScenario = scenarioList[comboBox.SelectedIndex];

            txtScenarioName.Text = selectedScenario.Name;
            txtScenarioDescription.Text = selectedScenario.Description;
            txtEnemyDeck.Text = selectedScenario.EnemyDeckName;

            RefreshRuleList();
            if (lstScenarioRules.Items.Count > 0)
                lstScenarioRules.SelectedIndex = 0;

            btnDeleteScenario.Enabled = !selectedScenario.IsDefault;
            btnSetEnemyDeck.Enabled = !selectedScenario.IsDefault;

            RefreshKeyItems();
        }

        private void btnDeleteScenario_Click(object sender, EventArgs e)
        {
            scenarioList.Remove(selectedScenario);
            RefreshScenarioList();
        }

        private void btnAddScenario_Click(object sender, EventArgs e)
        {
            var newScenarion = new ScenarioData()
            {
                Id = null,
                Name = txtScenarioName.Text,
                IsDefault = false,
            };

            for (int y = 0; y < GRID_SIZE; y++)
            {
                var deploymentMap = newScenarion.DeploymentMap;
                var objectiveMap = newScenarion.ObjectiveMap;

                deploymentMap.Add(new List<int?>());
                objectiveMap.Add(new List<int?>());
                for (int x = 0; x < GRID_SIZE; x++)
                {
                    CreateScenarioTile(y, deploymentMap, objectiveMap);
                }
            }

            scenarioList.Add(newScenarion);
            scenarioList = scenarioList.OrderByDescending(x => x.IsDefault).ThenBy(x => x.Name).ToList();
            RefreshScenarioList();
            cmbScenarioSelector.SelectedIndex = scenarioList.Count - 1;
        }

        private void btnSetEnemyDeck_Click(object sender, EventArgs e)
        {
            var formSelectionList = _serviceProvider.GetRequiredService<formSelectionList>();
            formSelectionList.selectionType = SelectionType.Deck;
            var result = formSelectionList.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                selectedScenario.EnemyDeckId = formSelectionList.selectionItem.Id;
                selectedScenario.EnemyDeckName = formSelectionList.selectionItem.Name;
                txtEnemyDeck.Text = selectedScenario.EnemyDeckName;
            }
        }

        private void btnAddNewRule_Click(object sender, EventArgs e)
        {
            var newRule = new ScenarioRuleData()
            {
                Name = "New Rule",
            };

            selectedScenario.ScenarioRules.Add(newRule);
            RefreshRuleList();
            lstScenarioRules.SelectedIndex = lstScenarioRules.Items.Count - 1;

            LoadRuleData();
        }

        private void btnAddRule_Click(object sender, EventArgs e)
        {
            var formSelectionList = _serviceProvider.GetRequiredService<formSelectionList>();
            formSelectionList.selectionType = SelectionType.ScenarioRules;
            var result = formSelectionList.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                if (selectedScenario.ScenarioRules.Any(x => x.Id == formSelectionList.selectionItem.Id))
                {
                    MessageBox.Show("Scenario already has that rule");
                }
                else
                {
                    var scenarioRule = _context.ScenarioRules.SingleOrDefault(x => x.Id == formSelectionList.selectionItem.Id);
                    var scenarionRuleData = new ScenarioRuleData()
                    {
                        Id = scenarioRule.Id,
                        Name = scenarioRule.Name,
                        Description = scenarioRule.Description,
                    };

                    selectedScenario.ScenarioRules.Add(scenarionRuleData);
                    RefreshRuleList();
                    lstScenarioRules.SelectedIndex = lstScenarioRules.Items.Count - 1;

                    LoadRuleData();
                }
            }
        }

        private void btnSaveScenario_Click(object sender, EventArgs e)
        {
            var currentIndex = cmbScenarioSelector.SelectedIndex;
            SaveScenario();
            RefreshScenarioList();
            cmbScenarioSelector.SelectedIndex = currentIndex;
        }

        private void SaveScenario()
        {
            selectedScenario.Name = txtScenarioName.Text;
            selectedScenario.Description = txtScenarioDescription.Text;
        }

        private void txtEnemyDeck_DoubleClick(object sender, EventArgs e)
        {
            selectedScenario.EnemyDeckId = null;
            selectedScenario.EnemyDeckName = "";
            txtEnemyDeck.Text = selectedScenario.EnemyDeckName;
        }

        private void btnSaveRule_Click(object sender, EventArgs e)
        {
            SaveRule();
        }

        private void SaveRule()
        {
            if (selectedScenario.ScenarioRules.Count > 0)
            {
                var selectedIndex = lstScenarioRules.SelectedIndex;
                var selectedRule = selectedScenario.ScenarioRules[selectedIndex];

                selectedRule.Name = txtRuleName.Text;
                selectedRule.Description = txtRuleDescription.Text;

                var relatedRules = scenarioList.SelectMany(x => x.ScenarioRules).Where(x => x.Id != null && x.Id == selectedRule.Id);
                foreach (var relatedRule in relatedRules)
                {
                    relatedRule.Name = txtRuleName.Text;
                    relatedRule.Description = txtRuleDescription.Text;
                }

                RefreshRuleList();
                lstScenarioRules.SelectedIndex = selectedIndex;
            }
        }

        private void lstScenarioRules_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadRuleData();
        }

        private void LoadRuleData()
        {
            var index = lstScenarioRules.SelectedIndex;
            var selectedRule = selectedScenario.ScenarioRules[index];

            txtRuleName.Text = selectedRule.Name;
            txtRuleDescription.Text = selectedRule.Description;
        }

        private void lstScenarioRules_DoubleClick(object sender, EventArgs e)
        {
            var index = lstScenarioRules.SelectedIndex;
            selectedScenario.ScenarioRules.RemoveAt(index);
            RefreshRuleList();
            if (lstScenarioRules.Items.Count > 0)
            {
                lstScenarioRules.SelectedIndex = 0;
            }
            else
            {
                txtRuleName.Text = "";
                txtRuleDescription.Text = "";
            }
        }

        private void RefreshRuleList()
        {
            lstScenarioRules.Items.Clear();
            var rules = selectedScenario.ScenarioRules.Select(x => new SelectListItem { Id = x.Id.HasValue ? x.Id.Value : 0, Name = x.Name }).ToArray();
            lstScenarioRules.Items.Clear();
            lstScenarioRules.Items.AddRange(rules);

            btnSaveRule.Enabled = lstScenarioRules.Items.Count != 0;
        }
    }
}
