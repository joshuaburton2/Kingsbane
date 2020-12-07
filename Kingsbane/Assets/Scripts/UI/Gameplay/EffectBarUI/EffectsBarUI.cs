using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EffectsBarUI : MonoBehaviour
{
    public enum EffectTypes
    {
        Default,
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

    public void RefreshEffectList()
    {
        var phaseEffectList = effectObjects.Where(x => x.activeGamePhase == GameManager.instance.CurrentGamePhase).ToList();

        foreach (var effect in phaseEffectList)
        {
            var effectObject = Instantiate(effect.effectPrefab, effectListParent.transform);
        }
    }
}
