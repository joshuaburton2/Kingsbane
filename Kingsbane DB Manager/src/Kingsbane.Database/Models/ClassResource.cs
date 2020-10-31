using Kingsbane.Database.Enums;

namespace Kingsbane.Database.Models
{
    public class ClassResource
    {
        public CardClasses CardClassId { get; set; }
        public virtual CardClass CardClass { get; set; }

        public Resources ResourceId { get; set; }
        public virtual Resource Resource { get; set; }

        public ClassResourceTypes ClassResourceType { get; set; }
    }
}
