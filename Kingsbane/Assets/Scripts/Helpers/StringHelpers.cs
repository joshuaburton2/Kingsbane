using System.Collections.Generic;

namespace Helpers
{
    class StringHelpers
    {
        /// <summary>
        /// 
        /// Update the resource text to include the resource words
        /// 
        /// </summary>
        public static string GenerateResourceText(List<Resource> resourceList)
        {
            string resourceString = "";

            foreach (var resource in resourceList)
            {
                var resourceVal = resource.Value.ToString().Replace("-", "");
                resourceString += $"{resourceVal} {resource.ResourceType},";
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
