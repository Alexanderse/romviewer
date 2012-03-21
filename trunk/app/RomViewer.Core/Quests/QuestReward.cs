using System;
using System.Collections.Generic;
using RomViewer.Core.Items;
using SharpLite.Domain;

namespace RomViewer.Core.Quests
{
    public class QuestReward : Entity
    {
        public virtual int RewardIndex { get; set; }
        public virtual string RewardType { get; set; }
        public virtual ItemDefinition Item { get; set; }
        public virtual QuestDefinition Quest { get; set; }
        public virtual int ItemCount { get; set; }
    

        public QuestReward() {}

        public QuestReward(string source, int delimiter, IItemRepository itemRepository)
        {
            char delim = (char)delimiter;
            string[] detail = source.Split(delim);
            int i = 0;
            RewardIndex = Convert.ToInt32(detail[i]); i++;
            string item = detail[i]; i++;
            Item = itemRepository.Get(item);
            if (Item != null)
            {
                RewardType = Item.ItemSubSubType;
            }
            ItemCount = Convert.ToInt32(detail[i]);i++;
        }

        public virtual string ToDelimitedString(int delimiter)
        {
            return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}", (char)delimiter, RewardIndex, RewardType, Item.Id, ItemCount, Item.Name, Item.Value);
        }

        public virtual string GetNullDefinitionString(int delimiter)
        {
            return string.Format("{0}{0}{0}{0}{0}", (char)delimiter);
        }

    }
}