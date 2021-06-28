using CategoryEnums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Cell : MonoBehaviour
{
    [SerializeField]
    public List<Cell> adjCell;
    [SerializeField]
    public Vector2 gridIndex;
    [SerializeField]
    public SpriteRenderer backgroundImage;
    [SerializeField]
    private float defaultAlpha;
    [SerializeField]
    public TerrainTypes terrainType;
    [SerializeField]
    public int? playerDeploymentId;
    [SerializeField]
    public Objective objective;
    [SerializeField]
    public UnitCounter occupantCounter;

    [Header("Tile Status Area")]
    [SerializeField]
    private Canvas tileStatusCanvas;
    [SerializeField]
    private GameObject tileStatusParent;
    [SerializeField]
    private GameObject tileStatusPrefab;

    public GameplayUI gameplayUI;

    private List<KeyValuePair<TileStatuses, int>> cellTileStatuses;

    private const int WALL_OF_FIRE_DAMAGE = 5;
    private const int CONSECREATE_DAMAGE = 2;
    private const int EARTHQUAKE_DAMAGE = 4;
    private const int SANCTUARY_HEAL = 4;

    private void Start()
    {
        occupantCounter = null;

        tileStatusCanvas.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        ClearTileStatuses();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == transform.name)
                {
                    if (GameManager.instance.uiManager.OverGameplayArea)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            switch (GameManager.instance.effectManager.ActiveEffect)
                            {
                                case EffectManager.ActiveEffectTypes.Deployment:
                                case EffectManager.ActiveEffectTypes.ForceDeployment:
                                    GameManager.instance.effectManager.DeployUnit(this);
                                    break;
                                case EffectManager.ActiveEffectTypes.UnitCopyMode:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.SelectCopyUnit(occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.SelectCaster:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.SelectCaster(occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.Spell:
                                    GameManager.instance.effectManager.CastSpell(this);
                                    break;
                                case EffectManager.ActiveEffectTypes.UnitCommand:
                                    SelectCommandUnit();
                                    break;
                                case EffectManager.ActiveEffectTypes.UnitMove:
                                case EffectManager.ActiveEffectTypes.UnitDisengage:
                                case EffectManager.ActiveEffectTypes.UnitForceMove:
                                    GameManager.instance.effectManager.MoveCommandUnit(this);
                                    break;
                                case EffectManager.ActiveEffectTypes.UnitAttack:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.UseAttack(occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.UnitAbility:
                                    GameManager.instance.effectManager.UseAbility();
                                    break;
                                case EffectManager.ActiveEffectTypes.DealDamage:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.DealDamage(occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.HealUnit:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.HealUnit(occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.Protected:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.ProtectUnit(occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.DestroyUnit:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.DestroyUnit(occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.RemoveUnit:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.RemoveUnit(occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.EnchantUnit:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.EnchantUnit(occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.RootUnit:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.RootUnit(occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.StunUnit:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.StunUnit(occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.Spellbind:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.SpellbindUnit(occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.RestoreEnchantment:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.RestoreUnitEnchantments(occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.MindControl:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.MindControlUnit(occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.Recruit:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.RecruitUnit(occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.Madness:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.TriggerMadness(occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.ReturnToHand:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.ReturnToHand(occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.Redeploy:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.Redeploy(occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.TileStatus:
                                    GameManager.instance.effectManager.AddTileStatus(this);
                                    break;
                                case EffectManager.ActiveEffectTypes.Transform:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.TransformUnit(this, occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.ImmuneUnit:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.ImmuneUnit(occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.IndestructibleUnit:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.IndestructibleUnit(occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.Confiscate:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.Confiscate(occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.SelectImprisonCaster:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.SetImprisonCaster(occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.Imprison:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.Imprison(occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.SpymasterLurenSource:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.SpymasterLurenEffect(occupantCounter.Unit);
                                    break;
                                case EffectManager.ActiveEffectTypes.None:
                                    SelectCommandUnit();
                                    break;
                            }
                        }
                        else if (Input.GetMouseButtonDown(1))
                        {
                            if (occupantCounter != null)
                            {
                                occupantCounter.ShowCardDetail();
                            }
                        }
                    }
                }
            }
        }
    }

    private void SelectCommandUnit()
    {
        if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay)
        {
            if (occupantCounter != null)
            {
                GameManager.instance.effectManager.SetCommandUnit(occupantCounter.Unit);
                gameplayUI.SetSelectedCommandUnit(occupantCounter.Unit);
            }
        }
    }

    public void SetBackgroundColour(Color colour, bool isTransparent)
    {
        colour.a = isTransparent ? defaultAlpha : 1.0f;
        backgroundImage.color = colour;
    }

    public void HideBackground()
    {
        backgroundImage.color = new Color(0f, 0f, 0f, 0f);
    }

    public void CellStartOfTurn(int activePlayerId)
    {
        cellTileStatuses.RemoveAll(x => x.Value == activePlayerId);

        RefreshTileStatus();
    }

    public void ClearTileStatuses()
    {
        cellTileStatuses = new List<KeyValuePair<TileStatuses, int>>();

        RefreshTileStatus();
    }

    public void AddTileStatus(TileStatuses tileStatus, int sourcePlayerId)
    {
        if (!cellTileStatuses.Any(x => x.Key == tileStatus && x.Value == sourcePlayerId))
        {
            cellTileStatuses.Add(new KeyValuePair<TileStatuses, int>(tileStatus, sourcePlayerId));

            RefreshTileStatus();

            switch (tileStatus)
            {
                case TileStatuses.Survey:
                    if (occupantCounter != null)
                        occupantCounter.Unit.Unstealth();
                    GameManager.instance.CheckWarden();
                    break;
                case TileStatuses.Earthquake:
                    if (occupantCounter != null)
                        occupantCounter.Unit.DamageUnit(GameManager.instance.GetPlayer(sourcePlayerId), EARTHQUAKE_DAMAGE);
                    //Need to add movement cost modifier in here
                    break;
                case TileStatuses.WallOfFire:
                    if (occupantCounter != null)
                        occupantCounter.Unit.DamageUnit(GameManager.instance.GetPlayer(sourcePlayerId), WALL_OF_FIRE_DAMAGE);
                    break;
                case TileStatuses.Sanctuary:
                    if (occupantCounter != null)
                        if (occupantCounter.Unit.Owner.Id == sourcePlayerId)
                            occupantCounter.Unit.HealUnit(SANCTUARY_HEAL);
                    break;
                case TileStatuses.Consecrate:
                    if (occupantCounter != null)
                        if (occupantCounter.Unit.Owner.Id != sourcePlayerId)
                            occupantCounter.Unit.DamageUnit(GameManager.instance.GetPlayer(sourcePlayerId), CONSECREATE_DAMAGE);
                    break;
            }
        }
    }

    private void RefreshTileStatus()
    {
        GameManager.DestroyAllChildren(tileStatusParent);
        foreach (var tileStatus in cellTileStatuses)
        {
            var tileStatusObject = Instantiate(tileStatusPrefab, tileStatusParent.transform);
            var tileStatusScript = tileStatusObject.GetComponent<TileStatusIndicator>();
            tileStatusScript.InitIndicator(tileStatus.Key, tileStatus.Value);
        }
    }


    public void CheckTileStatusOnEntry(Unit unit)
    {
        //This will need to be applied when pathfinding is added- so that on entry is applied to all tiles passed through

        foreach (var tileStatus in cellTileStatuses)
        {
            switch (tileStatus.Key)
            {
                case TileStatuses.WallOfFire:
                    unit.DamageUnit(GameManager.instance.GetPlayer(tileStatus.Value), WALL_OF_FIRE_DAMAGE);
                    break;
                case TileStatuses.Sanctuary:
                    if (unit.Owner.Id == tileStatus.Value)
                        unit.HealUnit(SANCTUARY_HEAL);
                    break;
                case TileStatuses.Consecrate:
                    if (unit.Owner.Id != tileStatus.Value)
                        unit.DamageUnit(GameManager.instance.GetPlayer(tileStatus.Value), CONSECREATE_DAMAGE);
                    break;
            }
        }
    }

    public bool IsSurveyed(int ownerId)
    {
        return cellTileStatuses.Any(x => x.Key == TileStatuses.Survey && x.Value == ownerId);
    }

    public List<Cell> GetRadiusTiles(int radius, bool)
}
