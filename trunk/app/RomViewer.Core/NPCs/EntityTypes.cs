using System;

namespace RomViewer.Core.NPCs
{
    [Flags]
    public enum EntityTypes: byte
    {
        Teleporter=1,
        Vendor=2,
        PetHunter=4,
        AuctionHouse=8,
        Bank=16,
        Housemaid=32,
        Mailbox=64
    }
}