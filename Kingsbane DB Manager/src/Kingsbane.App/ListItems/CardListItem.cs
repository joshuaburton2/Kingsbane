using Kingsbane.Database.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kingsbane.App
{
    class CardListItem
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public CardTypes CardType { get; internal set; }
        public CardClasses Class { get; internal set; }
        public CardRarities Rarity { get; internal set; }
    }
}
