using System.Collections.Generic;
using System.Linq;

namespace CategoryEnums
{


    public class ClassResourceType
    {
        public enum ResourceTypes
        {
            Dominant,
            Secondary
        }

        public ResourceTypes ResourceType { get; internal set; }
        public CardResources CardResource { get; internal set; }
    }

    public static class Classes
    {
        public const int NUM_CLASSES = 16; //This will always be equal to the number of actual classes plus one
        public enum ClassList
        {
            Default,
            Abyssal,
            Agent,
            Arcanist,
            Captain,
            Elementalist,
            Grovewatcher,
            Lifebringer,
            Lorekeeper,
            Luminist,
            Mercenary,
            Oathknight,
            Runeblade,
            Trickster,
            Waystalker,
            Wildkin
        };

        /// <summary>
        /// 
        /// Retrive the data of a particular class
        /// 
        /// </summary>
        public static ClassData GetClassData(ClassList neededClass)
        {
            return ClassDataList.FirstOrDefault(x => x.ThisClass == neededClass);
        }

        /// <summary>
        /// 
        /// List of the default class data. Pregenerated code
        /// 
        /// </summary>
        internal static List<ClassData> ClassDataList = new List<ClassData>()
        {
                //Default       (Dominant:Neutral, Secondary:Neutral)
                new ClassData(ClassList.Default)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Neutral },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Neutral },
                    },
                    IsPlayable = false,
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "" },
                        { ClassData.ClassDataFields.Playstyle, "-" },
                        { ClassData.ClassDataFields.Strengths, "-" },
                        { ClassData.ClassDataFields.Weaknesses, "-" },
                    },
                    },
                //Abyssal       (Dominant:Devotion, Secondary:Mana)
                new ClassData(ClassList.Abyssal)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Devotion },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Mana },
                    },
                    IsPlayable = true,
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "The Abyssal are descendants of humans who long ago tried to harness the power who’s only goal is to wipe out or conquer all living things. The process backfired on these people and the energy twisted them and all their descendants into monsters. Shunned by society, the Abyssal lived at the fringes of civilization, scrapping for work wherever they could find it. But while they lost their societal status, their transformation gave them a unique bond with the creatures of the Abyss, giving them the ability to use their powers and summon them to their side; however unlike their ancestors, the Abyssal of today understand that there is always a price for this power, and many are eager to pay it in exchange, whether that be their loyalty to these creatures, their health, their minions or their soul. While most Abyssal turn down dark paths due to their social isolation, some seek to aid others so that they may redeem their people in the eyes of others and undo the damage their ancestors did long ago. " },
                        { ClassData.ClassDataFields.Playstyle, "Aggressive to Mid-range" },
                        { ClassData.ClassDataFields.Strengths, "Powerful damage spells, strong but cheap minions, decent healing for hero, constant protection from a familiar" },
                        { ClassData.ClassDataFields.Weaknesses, "Non-resource costs (discard, hero health, sacrifices), slow units, limited direct removal" },
                    },
                    },
                //Agent       (Dominant:Gold, Secondary:Knowledge)
                new ClassData(ClassList.Agent)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Gold },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Knowledge },
                    },
                    IsPlayable = false,
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "While the utilisation of subterfuge is not something many would boast about, many understand its necessity to maintain order. That is where the Agents of Rudelia come into play. Masters of subtlety and spycraft, the Agent utilises their knowledge and understanding of the enemy against them, stealing and destroying their cards. While much more professional than other roguish types, the Agent isn’t against utilising underhanded tactics to gain an advantage, or hiring those who do. The Agent’s goal is not to win through force, but to control and manipulate the situation to gain the ultimate advantage before going in for the kill." },
                        { ClassData.ClassDataFields.Playstyle, "Mid-range to Control" },
                        { ClassData.ClassDataFields.Strengths, "Excellent removal tools, manipulation of enemy decks, good value generation" },
                        { ClassData.ClassDataFields.Weaknesses, "Limited and weak minions, limited escape tools" },
                    },
                    },
                //Arcanist       (Dominant:Knowledge, Secondary:Mana)
                new ClassData(ClassList.Arcanist)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Knowledge },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Mana },
                    },
                    IsPlayable = true,
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "Arcanists are arcane spellcasters who seek to understand and control the strange energies of magic that suffuse the world. Through patience and study, the Arcanist believes they can become masters of the arcane and the most powerful spellcasters in the world. Their allies are those who seek a fraction of such knowledge and will serve their masters in exchange for such power. While the Arcanist is a valuable on the field for their immense magical power, they are also extremely vulnerable to their foe, and those who are able to get in close quarters with the Arcanist will find them quite easy prey; the issue is getting close enough before being worn down by the arcane magic the Arcanist wields. " },
                        { ClassData.ClassDataFields.Playstyle, "Mid-range" },
                        { ClassData.ClassDataFields.Strengths, "Strong chip damage spells, good value generation, good ranged units" },
                        { ClassData.ClassDataFields.Weaknesses, "Limited defensive tools, no healing, slow units" },
                    },
                    },
                //Captain       (Dominant:Energy, Secondary:Knowledge)
                new ClassData(ClassList.Captain)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Energy },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Knowledge },
                    },
                    IsPlayable = true,
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "Battle-worn and experienced, the Captains or Rudellia are master tacticians who have studied the battlefield and learned how to control it and their foe to gain the upper hand. Beyond their skills in tactics, Captains are also skilled warriors, peerless in their mastery of the blade and are able to stand toe to toe with any who dare face them. Their armies are the most professional in Rudellia, with skills wide and varied to suit any situation. While this versatility is useful, it does mean that they are not particularly focused on any particular strategy. The Captain looks to find the weakness of the enemy and change their strategy on the fly to counter it as best they can. " },
                        { ClassData.ClassDataFields.Playstyle, "Versatile" },
                        { ClassData.ClassDataFields.Strengths, "Strong unit base and hero, versatile units (choose mechanics), ability to manipulate the battlefield, wide buffs" },
                        { ClassData.ClassDataFields.Weaknesses, "Limited damage or removal spells, versatility makes units quite unfocused" },
                    },
                    },
                //Elementalist       (Dominant:Mana, Secondary:Wild)
                new ClassData(ClassList.Elementalist)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Mana },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Wild },
                    },
                    IsPlayable = true,
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "Elementalists are masters of the four elements; air, earth, fire and water. They seek to utilise the explosive power of the elements against their foe, assaulting them with strong area of effect spells to prevent them from gaining the upper hand. By connecting with the wild magics of the world, they look to empower and enhance their spells in order to gain the upper hand. However their physical form is quite weak and it would not take much to overwhelm and eliminate them. As such, they have the ability to summon powerful elemental spirits to protect them, each mirroring themselves after one of the four elements. The Elementalist seeks to eliminate their foe quickly and prevent them from gaining the upper hand, for fear that they will be overwhelmed." },
                        { ClassData.ClassDataFields.Playstyle, "Aggressive" },
                        { ClassData.ClassDataFields.Strengths, "High damage area of effect spells, good empowered synergies, spell cost reductions, Manipulation of enemy positions" },
                        { ClassData.ClassDataFields.Weaknesses, "Vulnerable hero, limited units, weak single target damage" },
                    },
                    },
                //Grovewatcher       (Dominant:Wild, Secondary:Devotion)
                new ClassData(ClassList.Grovewatcher)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Wild },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Devotion },
                    },
                    IsPlayable = true,
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "Grovewatchers are the wardens of the natural world; they seek a balance of nature and will do anything they can to protect such a balance. Their faith in the old gods gives them their strength, providing them with control over powerful spirits of natures such as faeries and the mysterious treants of the Worldroot. Their powers also provide them with spells to control and slow the enemy, bringing them in pace with the Grovewatchers. For while strong, they are a slow and patient group, and their foes will seek to use that against them, crushing the Grovewatcher before they are able to respond. But do not take this as complacency on the Grovewatchers part; for when that which they protect is disturbed, they will fight as fiercely as any soldier." },
                        { ClassData.ClassDataFields.Playstyle, "Mid-range to Control" },
                        { ClassData.ClassDataFields.Strengths, "Strong resource growth and card draw, powerful units, tools to slow the enemy, ability to continually play powerful units" },
                        { ClassData.ClassDataFields.Weaknesses, "Limited early game presence, very expensive units, relies on trades for removal" },
                    },
                    },
                //Lifebringer       (Dominant:Devotion, Secondary:Gold)
                new ClassData(ClassList.Lifebringer)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Devotion },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Gold },
                    },
                    IsPlayable = true,
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "Lifebringers are the healers and priests who wander the lands of Rudelia, tending to the sick and wounded. They seek to spread the light of the gods and restore hope to a world wrought with peril. Their conviction to their faith and morals provides them with their strength, giving them powerful healing spells and abilities in order to keep their units alive. They are also skilled in alchemy, using their various potions to aid their allies and hinder their foes. But their reliance on aid and defence means that they have limited means of proactively dealing with their foe, relying instead upon their armies to protect them and their healing to recover. Lifebringers desire peace for all living things, but understand that there must be those willing to fight to defend that peace, or else it will all be for naught. " },
                        { ClassData.ClassDataFields.Playstyle, "Mid-range to Control" },
                        { ClassData.ClassDataFields.Strengths, "Excellent healing, multiple high health minions, resurrection effects, good comeback tools" },
                        { ClassData.ClassDataFields.Weaknesses, "Situational removal, low damage output, no card draw" },
                    },
                    },
                //Lorekeeper       (Dominant:Knowledge, Secondary:Devotion)
                new ClassData(ClassList.Lorekeeper)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Knowledge },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Devotion },
                    },
                    IsPlayable = true,
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "Devoted to learning and preserving knowledge of the world, Lorekeepers are those devoted to such tasks, travelling the world to learn as much as they can and returning it to be recorded in their mighty vaults. While many see Lorekeepers as little more than librarians or scholars, they have a much more important task; preventing those who would use powerful knowledge to harm others. As such, they use the knowledge they have gathered to take to the field, battling against those who would misuse knowledge for their own gain. While not a strict faith, Lorekeepers almost consider their task a divine duty, and they will take to it in earnest. However they have very few strong fighters, relying on their powerful spells to contest with the enemies best fighters, while the few fighters they have contest the field. The Lorekeeper works to turn the enemy’s strength against them, utilising all their knowledge, both powerful and maddening, to fend off their foes." },
                        { ClassData.ClassDataFields.Playstyle, "Control" },
                        { ClassData.ClassDataFields.Strengths, "Excellent value generation, good high end removal, tools to slow enemy plays, good tutored draws" },
                        { ClassData.ClassDataFields.Weaknesses, "No area of effect damage spells, limited high end units" },
                    },
                    },
                //Luminist       (Dominant:Knowledge, Secondary:Wild)
                new ClassData(ClassList.Luminist)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Knowledge },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Wild },
                    },
                    IsPlayable = false,
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "Fortune-tellers and mystics, Luminists are powerful spellweavers who utilise the energies of the moon and stars, providing them with visions of the future and powerful spells of light. Luminists are famous storytellers and they are often seen on the roadside trading stories with groups who encounter them wandering through the wilds. While they are normally a peaceful group, when innocents are in peril they will be quickly roused to aid them, turning their magic against the enemy. With this magic, they are able to learn more about the enemy deck and their own, foretelling what is to come, while devastating them with their spells. They are followed by the mystical elves, who’s bond with the night sky allows them to tap into the luminist’s power. However, they are not the strongest of fighters and rely on the power of the night sky to protect them. The Luminist uses their knowledge of the enemy to modify their strategy, while using their powers of the night sky to control and eliminate the enemy." },
                        { ClassData.ClassDataFields.Playstyle, "Control" },
                        { ClassData.ClassDataFields.Strengths, "Good deck manipulation and knowledge tools, Strong damage and removal spells/abilities, damage avoidance, lots of spellbind" },
                        { ClassData.ClassDataFields.Weaknesses, "Units have low stats (rely on abilities), resource intensive" },
                    },
                    },
                //Mercenary       (Dominant:Gold, Secondary:Energy)
                new ClassData(ClassList.Mercenary)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Gold },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Energy },
                    },
                    IsPlayable = false,
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "The Mercenaries of Rudelia are cutthroat soldiers who will do anything for a bit of coin. Ruthless and intimidating, these mercenaries charge quickly into battle, aiming to overwhelm the enemy and gain control of the board with their horde of units. With one of the strongest melee heroes in the land, the mercenary will find this an easy task. However, despite their strong numbers, their soldiers are not willing to die for the cause and if under significant stress, may just run from the field. Their numbers also make them vulnerable to large area damage and their melee forces can easily be outranged by archers and casters. The Mercenary’s goal is to force the fight to the enemy, charging across the field and overwhelming the foe with numbers before they have time to respond." },
                        { ClassData.ClassDataFields.Playstyle, "Aggressive to Mid-range" },
                        { ClassData.ClassDataFields.Strengths, "Many and fast units, strong hero, Under-cost minions for their stats" },
                        { ClassData.ClassDataFields.Weaknesses, "Limited range, routing units, vulnerable to area of effect damage" },
                    },
                    },
                //Oathknight       (Dominant:Devotion, Secondary:Energy)
                new ClassData(ClassList.Oathknight)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Devotion },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Energy },
                    },
                    IsPlayable = true,
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "Oathknights are powerful knights who are empowered by divine oaths. Utterly devoted to their oath, Oathknights will stop at nothing to ensure that it is fulfilled, whether it be to protect the innocent, heal the lands or seek revenge on those who wrong them or their allies. Those who follow the Oathknight into battle are powerful knights in their own right who are also devoted to a righteous cause. If an Oathknight’s devotion is strong enough, they may even be able to seek aid of the mighty angels, who fly into battle with righteous fury. Their strength also allows them to enchant their allies, providing them with the strength to stand toe-to-toe with the most powerful of enemies. Despite their purity and strength, the Oathknight finds it difficult to contend with those at range and they have no way to deal with large enemies without using their own units strength. The Oathknight is a powerful minion-based class with the goal of keeping their units alive with healing and enchantments in order to control the battlefield. " },
                        { ClassData.ClassDataFields.Playstyle, "Mid-range" },
                        { ClassData.ClassDataFields.Strengths, "Strong units, flying units, well defended hero, multiple buff enchantments" },
                        { ClassData.ClassDataFields.Weaknesses, "Situational range, no hard removal" },
                    },
                    },
                //Runeblade       (Dominant:Energy, Secondary:Mana)
                new ClassData(ClassList.Runeblade)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Energy },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Mana },
                    },
                    IsPlayable = true,
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "Long ago, the dwarves discovered techniques to use powerful magic runes in order to enchant and empower their weapons. These techniques were highly secretive and only a few were ever taught how to make these weapons, let alone utilise them. Those who do however, are known as Runeblades. Runeblades are skilled blademasters who have learned to use the power of their arcane runes to blend the arcane with the blade. This arcane power allows them to greatly improve their attack power while also protecting them from harm and allowing them to manoeuvre quickly around the battlefield. However their focus on the blade makes them quite melee oriented, and requires them to make aggressive use of their hero and units into order to be effective. They also have few ways of generating value or drawing cards, as such meaning that if they are held off in their initial wave, they are unable to come back into the fight. Runeblades are very aggressive fighters who look to burn down the enemy quickly and efficiently, using their arcane and blade skills to protect them from harm and overwhelm the enemy." },
                        { ClassData.ClassDataFields.Playstyle, "Aggressive" },
                        { ClassData.ClassDataFields.Strengths, "High attack units, multiple enchantments for casters, Good manoeuvrability" },
                        { ClassData.ClassDataFields.Weaknesses, "Requires aggressive use of hero, limited card draw, limited range" },
                    },
                    },
                //Trickster       (Dominant:Gold, Secondary:Mana)
                new ClassData(ClassList.Trickster)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Gold },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Mana },
                    },
                    IsPlayable = true,
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "Tricksters are roguish types who have learned how to use arcane powers in order to become masters of stealth and subterfuge. Lurking in the shadowy underworld, the Trickster looks for any opportunity to make a profit, no matter what the work may entail. The goal of the Trickster is to find their quarry, eliminate them and then quickly leave without anyone the wiser. This provides them with many strong and quick answers to the enemy tactics as well as excellent tools to avoid and outmanoeuvre the enemy. However, their focus on swiftness means they are quite vulnerable and their aggressive units struggle to hold onto a position for long before being destroyed. However, their strong damage and removal spells allow them to assault the enemy from relative safety, giving the hero the opportunity to come back into the game if they lose their forces. The Trickster are masters of the underworld, providing them with efficient means of destroying and escaping from the enemy. With the shadows on their side, nothing will be able to stop the Trickster." },
                        { ClassData.ClassDataFields.Playstyle, "Aggressive to midrange" },
                        { ClassData.ClassDataFields.Strengths, "Fast units, good escape tools, strong direct damage spells, some removal" },
                        { ClassData.ClassDataFields.Weaknesses, "Vulnerable hero, weak board control from units" },
                    },
                    },
                //Waystalker       (Dominant:Wild, Secondary:Gold)
                new ClassData(ClassList.Waystalker)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Wild },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Gold },
                    },
                    IsPlayable = false,
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "Waystalkers are hunters and rangers who live on the fringes of society; protecting those within from the terrors of the wild. Master bowman, the Waystalkers field some of the best ranged units in Rudelia. Their connection with the wild also allows them to call upon powerful beasts, who they use to protect their rangers and hold back the foe. Their units are also extremely quick and not hindered by the terrain they pass through, for they are masters of travelling through the wilds. However if they are not careful to protect themselves, the Waystalker can be eliminated quite quickly. They also have few large units to support them in the late game, relying on quantity over quality. However, their early units are meant to be protected and aggressive enough that this doesn’t become an issue. The Waystalker fields a well rounded army, with a good mix of ranged and melee units to support them as they look to whither down the enemy with their ferocious beasts and devastating arrows." },
                        { ClassData.ClassDataFields.Playstyle, "Mid-range" },
                        { ClassData.ClassDataFields.Strengths, "Enhancements to hero attacks, strong early to mid-game beast units, fast ranged hero, fast units" },
                        { ClassData.ClassDataFields.Weaknesses, "Low-health hero, few late-game units" },
                    },
                    },
                //Wildkin       (Dominant:Energy, Secondary:Wild)
                new ClassData(ClassList.Wildkin)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Energy },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Wild },
                    },
                    IsPlayable = false,
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "The Wildkin are fierce barbarians from the cold wastes in the north of Rudellia. Wildkin have been isolated from society for so long that many see them as little more than animals- and they are not far from the truth. For the Wildkin have learned the art of shapechanging, becoming wild beasts who overwhelm their foes with their mighty strength. Their rage is fearsome to behold and few would stand before the onslaught of a Wildkin. Despite their ferocity however, they are an isolated breed and few would follow them into battle- those who do being other Wildkin. They also struggle with resource generation and it is common to see a Wildkin burn themselves out with their rage. However their durability allows them to come back from the brink and many have made the mistake of thinking they defeated a Wildkin, right before the raged Wildkin charged into the fray again. The Wildkin is a highly versatile class, with the ability to last well into the late game, but also can use their hero and units aggressively in order to command the field." },
                        { ClassData.ClassDataFields.Playstyle, "Versatile" },
                        { ClassData.ClassDataFields.Strengths, "Very durable hero, can take upon powerful beastly aspects, strong but few units, self-damage synergies" },
                        { ClassData.ClassDataFields.Weaknesses, "Weak board presence, weak resource generation and card draw" },
                    },
                    },
        };

    }
}
