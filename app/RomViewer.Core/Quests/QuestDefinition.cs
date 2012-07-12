using System;
using System.Collections.Generic;
using SharpLite.Domain;

namespace RomViewer.Core.Quests
{
    public class QuestDefinition : Entity
    {
        public virtual int RomId { get; set; }
        public virtual string Name { get; set; }

        public virtual int MinLevel { get; set; }
        public virtual int Level { get; set; }
        public virtual int StarterId { get; set; }
        public virtual int EnderId { get; set; }
        public virtual int Gold { get; set; }
        public virtual int XP { get; set; }
        public virtual int TP { get; set; }
        public virtual RewardCategory RewardCategory { get; set; }
        public virtual RewardSubCategory RewardSubCategory { get; set; }
        public virtual IList<QuestReward> Rewards { get; protected set; }
        public virtual QuestChain QuestChain { get; set; }
        public virtual int ChainIndex { get; set; }
        public virtual bool IsDaily { get; set; }

        public virtual string ToDelimitedString(int delimiter)
        {
            string rewards = "";
            foreach (QuestReward reward in Rewards)
            {
                if (rewards.Length > 0) rewards += (char) (delimiter+1);
                string r = reward.ToDelimitedString(delimiter + 2);
                rewards += r;
            }

            return
                string.Format(
                    "{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{0}{11}{0}{12}{0}{13}{0}{14}{0}{15}", (char)delimiter, RomId, Name, MinLevel, Level,
                    StarterId, EnderId, Gold, XP, TP, IsDaily, RewardCategory, RewardSubCategory, (QuestChain != null) ? QuestChain.ToDelimitedString(delimiter+1) : "", ChainIndex, rewards);
        }

        public static string GetNullDefinitionString(int delimiter)
        {
            return string.Format("{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}", (char)delimiter);
        }

        public QuestDefinition()
        {
            Rewards = new List<QuestReward>();
        }

        public QuestDefinition(string source, int delimiter): this()
        {
            char delim = (char) delimiter;
            string[] detail = source.Split(delim);
            int i = 0;
            RomId = Convert.ToInt32(detail[i]); i++;
            Name = detail[i]; i++;
            MinLevel = Convert.ToInt32(detail[i]); i++;
            Level = Convert.ToInt32(detail[i]); i++;
            StarterId = Convert.ToInt32(detail[i]); i++;
            EnderId = Convert.ToInt32(detail[i]); i++;
            Gold = Convert.ToInt32(detail[i]); i++;
            XP = Convert.ToInt32(detail[i]); i++;
            TP = Convert.ToInt32(detail[i]); i++;
            IsDaily = Convert.ToBoolean(detail[i]); i++;
            RewardCategory = (RewardCategory)Enum.Parse(typeof(RewardCategory), detail[i]); i++;
            RewardSubCategory = (RewardSubCategory)Enum.Parse(typeof(RewardSubCategory), detail[i]); i++;
            if (detail[i].Length > 0) this.QuestChain = new QuestChain(detail[i], delimiter + 1);
            i++;
            this.ChainIndex = Convert.ToInt32(detail[i]); i++;

            if (detail[i].Length > 0)
            {
                delim = (char) (delimiter + 1);
                string[] rewards = detail[i].Split(delim);
                for (int j = 0; j < rewards.Length; j++)
                {
                    //QuestReward reward = new QuestReward(rewards[j], delimiter + 2);
                    //Rewards.Add(reward);
                }
            }
        }
    }
}