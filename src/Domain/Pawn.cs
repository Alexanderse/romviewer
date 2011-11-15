using System;
using System.Collections.Generic;

namespace RomViewer.Domain
{
    public class Pawn
    {
        public string Location { get; set; }
        public string Sex { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string Class1 { get; set; }
        public string Class2 { get; set; }
        public string Guild { get; set; }
        public int Level { get; set; }
        public int Level2 { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int MP { get; set; }
        public int MaxMP { get; set; }
        public int MP2 { get; set; }
        public int MaxMP2 { get; set; }
        public string Race { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public string Mounted { get; set; }
        public int LastExp { get; set; }

        public Pawn()
        {
        }

        public Pawn(string source)
        {
            string[] detail = source.Split((char)2);
            int idx = 0;

            Id = detail[idx]; idx++;
            Name = detail[idx]; idx++;
            Class1 = detail[idx]; idx++;
            Class2 = detail[idx]; idx++;
            Level = Convert.ToInt32(detail[idx]); idx++;
            Level2 = Convert.ToInt32(detail[idx]); idx++;
            HP = Convert.ToInt32(detail[idx]); idx++;
            MaxHP = Convert.ToInt32(detail[idx]); idx++;
            Race = detail[idx]; idx++;
            X = Convert.ToDouble(detail[idx]); idx++;
            Y = Convert.ToDouble(detail[idx]); idx++;
            Z = Convert.ToDouble(detail[idx]); idx++;
        }
    }
}