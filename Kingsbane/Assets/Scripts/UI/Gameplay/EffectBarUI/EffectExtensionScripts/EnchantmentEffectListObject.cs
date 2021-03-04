using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnchantmentEffectListObject : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI enchantmentText;

    private EnchantmentExtensionEffect enchantmentExtensionEffect;
    private EnchantmentExtensionEffect.EnchantmentType listType;

    /// <summary>
    /// 
    /// Initialise the list object
    /// 
    /// </summary>
    public void InitObject(EnchantmentExtensionEffect _enchantmentExtensionEffect, string objectValue, EnchantmentExtensionEffect.EnchantmentType _listType)
    {
        enchantmentExtensionEffect = _enchantmentExtensionEffect;
        listType = _listType;

        enchantmentText.text = objectValue;
    }

    /// <summary>
    /// 
    /// Removes the object from the list
    /// 
    /// </summary>
    public void RemoveButton()
    {
        enchantmentExtensionEffect.RemoveListObject(enchantmentText.text, listType);
    }
}
