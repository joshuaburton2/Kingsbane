using CategoryEnums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> adjCell;
    [SerializeField]
    public Vector2 gridIndex;
    [SerializeField]
    private SpriteRenderer backgroundImage;
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

    private void Start()
    {
        cellOccupant = null;
        occupantCounter = null;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == transform.name)
                {
                    switch (GameManager.instance.effectManager.activeEffect)
                    {
                        case EffectManager.ActiveEffectTypes.Deployment:
                            cellOccupant = GameManager.instance.effectManager.DeploySelectedUnit(backgroundImage.transform);
                            occupantCounter = cellOccupant.GetComponent<UnitCounter>();
                            break;
                        case EffectManager.ActiveEffectTypes.None:
                        default:
                            break;
                    }
                }
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
}
