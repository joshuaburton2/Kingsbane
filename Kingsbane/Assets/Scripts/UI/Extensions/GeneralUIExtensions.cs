using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public static class GeneralUIExtensions
{
    /// <summary>
    /// 
    /// Initialise a given dropdowns options using an enum of type T. Removes a given set of values from the enum as options
    /// 
    /// </summary>
    public static void InitDropdownOfType<T>(TMP_Dropdown dropdown, List<T> removedList, string defaultString, bool orderAlphabetical = false) where T : Enum
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(new List<string> { defaultString });

        //Get the string values of the enum
        var dropDownNames = Enum.GetValues(typeof(T)).Cast<T>().Select(x => x.GetEnumDescription()).ToList();

        if (orderAlphabetical)
            dropDownNames = dropDownNames.OrderBy(x => x.FirstOrDefault()).ToList();

        //Removes the necessary values from the list
        foreach (var removeItem in removedList)
        {
            var removeString = removeItem.GetEnumDescription();
            dropDownNames.Remove(removeString);
        }
        //Add the options to the dropdown box
        dropdown.AddOptions(dropDownNames);

        dropdown.value = 0;
    }
}
