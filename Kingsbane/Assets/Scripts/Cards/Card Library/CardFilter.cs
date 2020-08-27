using CategoryEnums;
using System.Collections.Generic;
using System.Linq;

public class CardFilter
{
    public string SearchString { get; set; }

    public List<CardTypes> CardTypes { get; set; }
    public List<Rarity> Rarities { get; set; }
    public List<Sets> Sets { get; set; }

    public List<string> SearchStrings
    {
        get
        {
            SearchString = SearchString.Replace(" ", "");
            return SearchString.Split(',').ToList();
        }
    }

    CardFilter()
    {
        SearchString = "";
        CardTypes = new List<CardTypes>();
        Rarities = new List<Rarity>();
        Sets = new List<Sets>();
    }
}
