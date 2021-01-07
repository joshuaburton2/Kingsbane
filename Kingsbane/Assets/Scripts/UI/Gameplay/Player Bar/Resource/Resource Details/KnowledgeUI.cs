using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using CategoryEnums;
using System;

public class KnowledgeUI : ResourceDetailUI
{
    private PlayerKnowledge ResourceKnowledge { get { return (PlayerKnowledge)playerResource; } }

    [SerializeField]
    private TMP_InputField studyInput;
    [SerializeField]
    private TMP_InputField stagnationInput;
    [SerializeField]
    private TMP_Dropdown studyClassDropdown;

    public override void RefreshResourceDetailUI()
    {
        base.RefreshResourceDetailUI();

        valueText.text = $"{playerResource.ResourceType}: {playerResource.Value}/{ResourceKnowledge.BaseKnowledgeGain}";
        propertyText.text = $"Ignorance: {ResourceKnowledge.Ignorance}, {ResourceKnowledge.ExcessStagnation}/{ResourceKnowledge.IGNORANCE_THRESHOLD}";
        studyInput.text = "";
        stagnationInput.text = "";

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

    public void StudyButton()
    {
        if (int.TryParse(studyInput.text, out int studyVal))
        {
            var selectedClass = (Classes.ClassList)Enum.Parse(typeof(Classes.ClassList), studyClassDropdown.options[studyClassDropdown.value].text);
            ResourceKnowledge.TriggerStudy(studyVal, selectedClass);
        }

        RefreshResourceDetailUI();            
    }

    public void IncreaseButton()
    {
        ResourceKnowledge.UpdateBaseGain(1);
        RefreshResourceDetailUI();
    }

    public void RefreshButton()
    {
        ResourceKnowledge.RefreshValue();
        RefreshResourceDetailUI();
    }

    public void StagnationButton()
    {
        if (int.TryParse(stagnationInput.text, out int stagnationVal))
            ResourceKnowledge.ModifyStagnation(stagnationVal);

        RefreshResourceDetailUI();
    }
}
