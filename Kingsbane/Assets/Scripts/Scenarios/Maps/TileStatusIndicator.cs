using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CategoryEnums;
using UnityEngine.UI;
using TMPro;

public class TileStatusIndicator : MonoBehaviour
{
    [SerializeField]
    private Image statusColour;
    [SerializeField]
    private TextMeshProUGUI sourcePlayerText;

    private TileStatuses tileStatus;

    /// <summary>
    /// 
    /// Initialises a status effect indicator on a unit counter
    /// 
    /// </summary>
    public void InitIndicator(TileStatuses _tileStatus, int sourcePlayerId)
    {
        tileStatus = _tileStatus;

        statusColour.color = GameManager.instance.colourManager.GetTileStatusColour(tileStatus);
        sourcePlayerText.text = sourcePlayerId.ToString();
    }
}
