using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUI : MonoBehaviour
{
    [SerializeField]
    private List<PlayerUIBar> playerUIBars;

    public void InitialiseUI()
    {
        foreach (var playerBar in playerUIBars)
            playerBar.InitialisePlayerBar();
    }
}
