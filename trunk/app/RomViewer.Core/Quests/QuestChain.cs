using System;
using System.Collections.Generic;
using SharpLite.Domain;

namespace RomViewer.Core.Quests
{
    public class QuestChain : Entity
    {
        public virtual string Name { get; set; }

        public virtual IList<QuestDefinition> Quests { get; protected set; }

        public virtual string ToDelimitedString(int delimiter)
        {
            return
                string.Format("{1}{0}{2}", (char)delimiter, Id, Name);
        }

        public QuestChain()
        {
        }

        public QuestChain(string source, int delimiter)
        {
            char delim = (char)delimiter;
            string[] detail = source.Split(delim);
            int i = 0;
            Id = Convert.ToInt32(detail[i]); i++;
            Name = detail[i]; i++;
        }
    }
}