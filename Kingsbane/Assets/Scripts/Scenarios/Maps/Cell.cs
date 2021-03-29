using CategoryEnums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private GameObject cellOccupant;
    [SerializeField]
    public UnitCounter occupantCounter;

    public GameplayUI gameplayUI;

    private void Start()
    {
        cellOccupant = null;
        occupantCounter = null;
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
                                    cellOccupant = GameManager.instance.effectManager.DeployUnit(this);
                                    break;
                                case EffectManager.ActiveEffectTypes.UnitCopyMode:
                                    if (occupantCounter != null)
                                        GameManager.instance.effectManager.SelectCopyUnit(occupantCounter.Unit);
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
        if (occupantCounter != null)
        {
            GameManager.instance.effectManager.SetCommandUnit(occupantCounter.Unit);
            gameplayUI.SetSelectedCommandUnit(occupantCounter.Unit);
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
}
