using System;
using SharpLite.Domain;
using SharpLite.Domain.Validators;

namespace RomViewer.Core.Items
{
    //[HasUniqueDomainSignature]
    public class ItemDefinition: Entity
    {
        //[DomainSignature]
        public virtual int RomId { get; set; }
        public virtual string Name { get; set; }
        public virtual int Value { get; set; }
        public virtual string ItemType { get; set; }
        public virtual string ItemSubType { get; set; }
        public virtual string ItemSubSubType { get; set; }
        public virtual int RequiredLevel { get; set; }

        public virtual string ToDelimitedString(int delimiter)
        {
            return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}", (char)delimiter, RomId, Name, Value, ItemType, ItemSubType, ItemSubSubType, RequiredLevel);
        }

        public static string GetNullDefinitionString(int delimiter)
        {
            return string.Format("{0}{0}{0}{0}{0}{0}", (char)delimiter);
        }

        public ItemDefinition()
        {
        }

        public ItemDefinition(string source, int delimiter)
        {
            char delim = (char)delimiter;
            string[] detail = source.Split(delim);
            int i = 0;
            RomId = Convert.ToInt32(detail[i]); i++;
            Name = detail[i]; i++;
            Value = Convert.ToInt32(detail[i]); i++;
            ItemType = detail[i]; i++;
            ItemSubType = detail[i]; i++;
            ItemSubSubType = detail[i]; i++;
            RequiredLevel = Convert.ToInt32(detail[i]); i++;
        }
    }

}