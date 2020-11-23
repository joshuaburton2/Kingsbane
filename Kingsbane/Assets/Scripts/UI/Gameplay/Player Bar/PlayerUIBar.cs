using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIBar : MonoBehaviour
{
    public int id;
    private Player Player { get { return GameManager.instance.GetPlayer(id); } }
}
