using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class EffectsBarUI : MonoBehaviour
{
    public enum EffectTypes
    {
        Default,
        [Description("Play Hero")]
        PlayHero,
    }

    [Serializable]
    private class EffectObject
    {
        public EffectTypes effectType;
        public GameManager.GamePhases activeGamePhase;
        public GameObject effectPrefab;
    }

    [SerializeField]
    private GameObject effectListParent;
    [SerializeField]
    private List<EffectObject> effectObjects;
    [SerializeField]
    private GameplayUI gameplayUI;

    public void RefreshEffectList()
    {
        GameManager.DestroyAllChildren(effectListParent);

        var phaseEffectList = effectObjects.Where(x => x.activeGamePhase == GameManager.instance.CurrentGamePhase).ToList();

        foreach (var effect in phaseEffectList)
        {
            var effectObject = Instantiate(effect.effectPrefab, effectListParent.transform);
            effectObject.GetComponent<EffectUI>().InitialiseEffectUI(effect.effectType, gameplayUI);
        }
    }
}
