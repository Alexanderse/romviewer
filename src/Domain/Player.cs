﻿using System;

namespace RomViewer.Domain
{
    public class Player: Pawn
    {

        public Player(string source)
        {
            string[] detail = source.Split((char) 2);

            int idx = 0;

            Id = detail[idx]; idx++;
            Name = detail[idx]; idx++;
            Class1 = detail[idx]; idx++;
            Class2 = detail[idx]; idx++;
            Level = Convert.ToInt32(detail[idx]); idx++;
            Level2 = Convert.ToInt32(detail[idx]); idx++;
            Guild = detail[idx]; idx++;
            HP = Convert.ToInt32(detail[idx]); idx++;
            MaxHP = Convert.ToInt32(detail[idx]); idx++;
            MP = Convert.ToInt32(detail[idx]); idx++;
            MaxMP = Convert.ToInt32(detail[idx]); idx++;
            MP2 = Convert.ToInt32(detail[idx]); idx++;
            MaxMP2 = Convert.ToInt32(detail[idx]); idx++;
            Race = detail[idx]; idx++;
            X = Convert.ToDouble(detail[idx]); idx++;
            Y = Convert.ToDouble(detail[idx]); idx++;
            Z = Convert.ToDouble(detail[idx]); idx++;
            Mounted = detail[idx]; idx++;
            LastExp = Convert.ToInt32(detail[idx]); idx++;
        }
    }
}