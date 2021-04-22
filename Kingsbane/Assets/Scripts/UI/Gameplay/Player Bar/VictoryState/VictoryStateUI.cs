using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryStateUI : MonoBehaviour
{
    [SerializeField]
    private GameObject victoryText;
    [SerializeField]
    private GameObject loseText;

    public void InitVictoryStateUI()
    {
        victoryText.SetActive(false);
        loseText.SetActive(true);
    }

    public void ShowVictoryState(bool isVictory)
    {
        victoryText.SetActive(isVictory);
        loseText.SetActive(!isVictory);
    }
}
