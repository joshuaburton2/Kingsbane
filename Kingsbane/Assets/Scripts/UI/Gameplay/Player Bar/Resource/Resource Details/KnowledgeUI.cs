using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using CategoryEnums;
using System;

public class KnowledgeUI : ResourceDetailUI
{
    //Converts the player resource to knowledge
    private PlayerKnowledge ResourceKnowledge { get { return (PlayerKnowledge)playerResource; } }

    [SerializeField]
    private TMP_InputField studyInput;
    [SerializeField]
    private TMP_InputField stagnationInput;
    [SerializeField]
    private TMP_Dropdown studyClassDropdown;

    /// <summary>
    /// 
    /// Refreshes the resource details
    /// 
    /// </summary>
    public override void RefreshResourceDetailUI()
    {
        base.RefreshResourceDetailUI();

        valueText.text = $"{playerResource.ResourceType}: {playerResource.Value}/{ResourceKnowledge.BaseKnowledgeGain}";
        propertyText.text = $"Ignorance: {ResourceKnowledge.Ignorance}, {ResourceKnowledge.ExcessStagnation}/{ResourceKnowledge.IGNORANCE_THRESHOLD}";
        studyInput.text = "";
        stagnationInput.text = "";

        //Updates the dropdown for selecting which inspiration card to shuffle with study
        studyClassDropdown.ClearOptions();
        studyClassDropdown.AddOptions(
            new List<TMP_Dropdown.OptionData>()
            {
                new TMP_Dropdown.OptionData(){ text = Classes.ClassList.Agent.ToString() },
                new TMP_Dropdown.OptionData(){ text = Classes.ClassList.Arcanist.ToString() },
                new TMP_Dropdown.OptionData(){ text = Classes.ClassList.Captain.ToString() },
                new TMP_Dropdown.OptionData(){ text = Classes.ClassList.Lorekeeper.ToString() },
                new TMP_Dropdown.OptionData(){ text = Classes.ClassList.Luminist.ToString() },
            }
        );
    }

    /// <summary>
    /// 
    /// Button click event for triggering study effects
    /// 
    /// </summary>
    public void StudyButton()
    {
        if (int.TryParse(studyInput.text, out int studyVal))
        {
            //var selectedClass = (Classes.ClassList)Enum.Parse(typeof(Classes.ClassList), studyClassDropdown.options[studyClassDropdown.value].text);
            ResourceKnowledge.TriggerStudy(studyVal, ResourceKnowledge.Player().PlayerClass);
        }

        //Due to the deck lists needing to be refreshed when shuffling study cards. As such refreshes the whole UI, including the resource UI
        playerBar.RefreshPlayerBar();
    }

    /// <summary>
    /// 
    /// Button click event for increasing the players base knowledge gain
    /// 
    /// </summary>
    public void IncreaseButton()
    {
        ResourceKnowledge.UpdateBaseGain(1);
        RefreshResourceDetailUI();
    }

    /// <summary>
    /// 
    /// Button click event for refreshing the players knowledge
    /// 
    /// </summary>
    public void RefreshButton()
    {
        ResourceKnowledge.RefreshValue();
        RefreshResourceDetailUI();
    }

    /// <summary>
    /// 
    /// Button click event for modifying the players stagnation
    /// 
    /// </summary>
    public void StagnationButton()
    {
        if (int.TryParse(stagnationInput.text, out int stagnationVal))
            ResourceKnowledge.ModifyStagnation(stagnationVal);

        RefreshResourceDetailUI();
    }
}
