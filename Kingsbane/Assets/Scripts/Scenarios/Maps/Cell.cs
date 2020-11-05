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
}
