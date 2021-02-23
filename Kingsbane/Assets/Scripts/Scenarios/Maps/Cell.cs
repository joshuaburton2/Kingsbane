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
                    if (Input.GetMouseButtonDown(0))
                    {
                        switch (GameManager.instance.effectManager.ActiveEffect)
                        {
                            case EffectManager.ActiveEffectTypes.Deployment:
                                cellOccupant = GameManager.instance.effectManager.DeploySelectedUnit(this);
                                break;
                            case EffectManager.ActiveEffectTypes.Spell:
                                GameManager.instance.effectManager.CastSpell(this);
                                break;
                            case EffectManager.ActiveEffectTypes.UnitCommand:
                                SelectCommandUnit();
                                break;
                            case EffectManager.ActiveEffectTypes.UnitMove:
                                GameManager.instance.effectManager.MoveSelectedUnit(this);
                                break;
                            case EffectManager.ActiveEffectTypes.UnitForceMove:
                                GameManager.instance.effectManager.MoveSelectedUnit(this);
                                break;
                            case EffectManager.ActiveEffectTypes.UnitAttack:
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

    private void SelectCommandUnit()
    {
        if (occupantCounter != null)
        {
            GameManager.instance.effectManager.SetSelectedUnitCommand(occupantCounter.Unit);
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
