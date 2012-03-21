using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using RomViewer.Core.Mapping;
using RomViewer.Model;

namespace Focus.Tests.Tasks
{
    [TestFixture]
    internal class Tmp
    {
        [Test]
        public void TestA()
        {
            World.Initialise(@"E:\dev\romviewer\app\RomViewer\bin\Debug\");
            //OptimizationTask a = new 

            Hashtable zones = new Hashtable(World.Data.Zones.Count);
            foreach (Zone zone in World.Data.Zones)
            {
                MapZone z = new MapZone()
                                {
                                    IsPublic = true,
                                    RomId = zone.Id,
                                    Name = zone.Name
                                };
                zones.Add(z.RomId, z);
            }

            List<MapPoint> points = new List<MapPoint>(World.Data.Nodes.Count);
            foreach (GameNode node in World.Data.Nodes)
            {
                MapPoint pt = new MapPoint();
                pt.X = node.Coordinates.X;
                pt.Y = node.Coordinates.Y;
                pt.Z = node.Coordinates.Z;
                if (node.Zone != null)
                {
                    ((MapZone)zones[node.Zone.Id]).Points.Add(pt);
                }
                points.Add(pt);

            }
        }
    }
}