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
