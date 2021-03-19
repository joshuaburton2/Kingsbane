using System.Collections.Generic;
using CategoryEnums;

namespace Helpers
{
    class StringHelpers
    {
        /// <summary>
        /// 
        /// Update the resource text to include the resource words
        /// 
        /// </summary>
        public static string GenerateResourceText(List<Resource> resourceList, List<string> resourceColours = null)
        {
            if (resourceColours == null)
            {
                resourceColours = new List<string>();
                for (int i = 0; i < resourceList.Count; i++)
                    resourceColours.Add("");
            }
            string resourceString = "";

            foreach (var resource in resourceList)
            {
                var resourceVal = resource.Value.ToString().Replace("-", "");
                var resourceColour = resourceColours[resourceList.IndexOf(resource)];
                resourceString += $@"{resourceColour}{resourceVal}<color=""black""> {resource.ResourceType},";
            }

            // Remove the first space last comma from the resource text
            if (resourceString.Length != 0)
            {
                resourceString = resourceString.Remove(resourceString.Length - 1);
            }

            resourceString = resourceString.Replace(",", ", ");

            return resourceString;
        }
    }
}
