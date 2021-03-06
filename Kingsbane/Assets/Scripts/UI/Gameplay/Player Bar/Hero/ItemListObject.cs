﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemListObject : MonoBehaviour, IPointerClickHandler
{
    private Item Item { get; set; }
    public bool IsEmptySlot { get; set; }
    private HeroUI HeroUI { get; set; }

    [SerializeField]
    private Image itemImage;
    [SerializeField]
    private Sprite emptyItemSlotImage;
    [SerializeField]
    private TextMeshProUGUI itemNameText;
    [SerializeField]
    private TextMeshProUGUI durabilityText;
    [SerializeField]
    private CanvasGroup buttonGroup;
    [SerializeField]
    private GameObject notesArea;
    [SerializeField]
    private TMP_InputField notesInput;

    private void Update()
    {
        buttonGroup.interactable = !GameManager.instance.effectManager.IsUILocked && !IsEmptySlot;

        if (notesArea.activeSelf && GameManager.instance.effectManager.IsUILocked)
            ShowNotesButton();
    }

    /// <summary>
    /// 
    /// Refreshes the item object with the item details
    /// 
    /// </summary>
    public void RefreshItemObject(HeroUI heroUI, Item _item = null)
    {
        HeroUI = heroUI;
        Item = _item;

        notesArea.SetActive(false);

        //If item is null, displays the empty item object
        if (Item == null)
        {
            IsEmptySlot = true;

            itemImage.sprite = emptyItemSlotImage;
            itemNameText.text = "Empty Item Slot";
            durabilityText.text = "Durability: 0";
            notesInput.text = "";
        }
        else
        {
            IsEmptySlot = false;

            itemImage.sprite = Item.CardArt;
            itemNameText.text = Item.Name;
            durabilityText.text = $"Durability: {Item.CurrentDurability}";
            notesInput.text = Item.ItemNotes;
        }
    }

    /// <summary>
    /// 
    /// Button click event for increasing item durability
    /// 
    /// </summary>
    public void IncreaseDurabilityButton()
    {
        Item.ModifyDurability(1);
        RefreshItemObject(HeroUI, Item);
    }

    /// <summary>
    /// 
    /// Button click event for decreasing item durability
    /// 
    /// </summary>
    public void DecreaseDurabilityButton()
    {
        var isDestroyed = Item.ModifyDurability(-1);
        if (isDestroyed)
        {
            HeroUI.RefreshHeroUI();
        }
        else
        {
            RefreshItemObject(HeroUI, Item);
        }
    }

    /// <summary>
    /// 
    /// Button click event for destroying the item
    /// 
    /// </summary>
    public void DestroyItemButton()
    {
        Item.DestroyItem();
        HeroUI.RefreshHeroUI();
    }

    public void ShowNotesButton()
    {
        if (notesArea.activeSelf)
        {
            Item.ItemNotes = notesInput.text;
            notesArea.SetActive(false);
        }
        else
        {
            notesArea.SetActive(true);
        }
    }

    /// <summary>
    /// 
    /// Click event handler. Right click actives card detail, left click equips an item to an empty slot if in the 
    /// 
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (Item != null)
            {
                GameManager.instance.uiManager.ActivateCardDetail(Item.CardData);
            }
        }
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (GameManager.instance.effectManager.ActiveEffect == EffectManager.ActiveEffectTypes.Equip ||
                GameManager.instance.effectManager.ActiveEffect == EffectManager.ActiveEffectTypes.ForceEquip)
            {
                GameManager.instance.effectManager.EquipItem(Item, HeroUI.Hero.Owner.Id);
            }
        }
    }
}
