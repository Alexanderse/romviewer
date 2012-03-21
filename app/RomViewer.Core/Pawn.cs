using System;

namespace RomViewer.Core
{
    public class Pawn
    {
        public virtual string Location { get; set; }
        public virtual string Sex { get; set; }
        public virtual string Name { get; set; }
        public virtual string Id { get; set; }
        public virtual int Class1 { get; set; }
        public virtual int Class2 { get; set; }
        public virtual int Class3 { get; set; }
        public virtual string Guild { get; set; }
        public virtual int Level { get; set; }
        public virtual int Level2 { get; set; }
        public virtual int Level3 { get; set; }
        public virtual int HP { get; set; }
        public virtual int MaxHP { get; set; }
        public virtual int MP { get; set; }
        public virtual int MaxMP { get; set; }
        public virtual int MP2 { get; set; }
        public virtual int MaxMP2 { get; set; }
        public virtual string Race { get; set; }
        public virtual double X { get; set; }
        public virtual double Y { get; set; }
        public virtual double Z { get; set; }
        public virtual string Mounted { get; set; }
        public virtual int LastExp { get; set; }

        public Pawn()
        {
        }

        public Pawn(string source, int delimiter)
        {
            string[] detail = source.Split((char)delimiter);
            int idx = 0;

            Id = detail[idx]; idx++;
            Name = detail[idx]; idx++;
            Class1 = Convert.ToInt32(detail[idx]); idx++;
            Class2 = Convert.ToInt32(detail[idx]); idx++;
            Class3 = Convert.ToInt32(detail[idx]); idx++;
            Level = Convert.ToInt32(detail[idx]); idx++;
            Level2 = Convert.ToInt32(detail[idx]); idx++;
            Level3 = Convert.ToInt32(detail[idx]); idx++;
            HP = Convert.ToInt32(detail[idx]); idx++;
            MaxHP = Convert.ToInt32(detail[idx]); idx++;
            Race = detail[idx]; idx++;
            X = Convert.ToDouble(detail[idx]); idx++;
            Y = Convert.ToDouble(detail[idx]); idx++;
            Z = Convert.ToDouble(detail[idx]); idx++;
        }
    }
}