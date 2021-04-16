using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class EffectsBarUI : MonoBehaviour
{
    //List of all possible effects
    public enum EffectTypes
    {
        Default,
        [Description("Play Hero")]
        PlayHero,
        [Description("Mulligan Hand")]
        MulliganHand,
        [Description("Deal Damage")]
        DealDamage,
        [Description("Heal Unit")]
        HealUnit,
        [Description("Protected")]
        Protected,
        [Description("Destroy Unit")]
        DestroyUnit,
        [Description("Enchantment")]
        Enchantment,
        [Description("Crowd Control")]
        CrowdControl,
        [Description("Deploy Unit")]
        DeployUnit,
        [Description("Modify Cost")]
        ModifyCost,
        [Description("Spellbind")]
        Spellbind,
        [Description("Graveyard")]
        Graveyard,
        [Description("Divinate")]
        Divinate,
        [Description("Equip")]
        Equip,
        [Description("Mind Control")]
        MindControl,
        [Description("Recruit")]
        Recruit,
        [Description("Madness")]
        Madness,
        [Description("Bounce")]
        Bounce,
        [Description("Foretelling")]
        Foretelling,
        [Description("Tile Status")]
        TileStatus,
        [Description("Transform")]
        Transform,
        [Description("Immune")]
        Immune,
        [Description("Captain of the Guard")]
        CaptainOfTheGuard,
    }

    [Serializable]
    private class EffectObject
    {
        public EffectTypes effectType;
        public GameManager.GamePhases activeGamePhase;
        public GameObject effectPrefab;
    }

    [Serializable]
    private class EffectExtension
    {
        public EffectTypes effectType;
        public GameObject effectArea;
    }

    [SerializeField]
    private GameObject effectListParent;
    [SerializeField]
    private List<EffectObject> effectObjects;
    [SerializeField]
    private List<EffectExtension> effectExtensions;
    [SerializeField]
    private GameplayUI gameplayUI;

    private bool effectExtensionsShown;

    private void Update()
    {
        if (effectExtensionsShown && GameManager.instance.effectManager.IsUILocked)
        {
            HideEffectExtensions();
        }

        if (Input.GetMouseButtonDown(1))
        {
            HideEffectExtensions();
        }
    }

    /// <summary>
    /// 
    /// Refresh the Effect List
    /// 
    /// </summary>
    public void RefreshEffectList()
    {
        GameManager.DestroyAllChildren(effectListParent);

        var phaseEffectList = effectObjects.Where(x => x.activeGamePhase == GameManager.instance.CurrentGamePhase).OrderBy(x => x.effectType.GetEnumDescription());

        foreach (var effect in phaseEffectList)
        {
            var effectObject = Instantiate(effect.effectPrefab, effectListParent.transform);
            effectObject.GetComponent<EffectUI>().InitialiseEffectUI(effect.effectType, gameplayUI, this);
        }

        HideEffectExtensions();
    }

    public void HideEffectExtensions()
    {
        effectExtensionsShown = false;

        foreach (var effectExtension in effectExtensions)
            effectExtension.effectArea.SetActive(false);
    }

    public void ShowEffectExtension(EffectTypes effectType, EffectUI currentEffect)
    {
        HideEffectExtensions();

        effectExtensionsShown = true;

        var effectExtension = effectExtensions.SingleOrDefault(x => x.effectType == effectType);
        if (effectExtension == null)
            throw new Exception("Effect type does not have an extension");

        effectExtension.effectArea.SetActive(true);
        effectExtension.effectArea.GetComponent<EffectExtensionUI>().RefreshEffectExtension(currentEffect);
    }
}
