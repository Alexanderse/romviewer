using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Threading;
using System.Xml.Serialization;
using RomViewer.Model;

namespace RomViewer
{
    public static class ObjectSaver
    {
        public static Hashtable _filenames = new Hashtable();
        private static Thread _writeThread = null;
        private static Queue<FoundObject> _queue = new Queue<FoundObject>();
        private static ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
        private static ManualResetEvent _runHandle = new ManualResetEvent(false);
        private static List<NPCRecord> _npcs = new List<NPCRecord>();
        public static bool Started = false;

        public static void Start()
        {
            if (_filenames.Count < 1) throw new Exception("No filenames for logging objects defined");
            
            _writeThread = new Thread(ProcessQueue);
            _npcs.Clear();
            _runHandle.Reset();
            _writeThread.Start();
            Started = true;
        }

        private static void ProcessQueue()
        {
            LoadNPCs();

            while (!_runHandle.WaitOne(100))
            {
                FoundObject o;
                _lock.EnterWriteLock();
                try
                {
                    if (_queue.Count < 1) continue;

                    o = _queue.Dequeue();
                }
                finally
                {
                    _lock.ExitWriteLock();
                }

                string filename = (string) _filenames[o.ObjectType];

                if (string.IsNullOrEmpty(filename)) continue;
                if (o.Id < 1) continue;

                if (_npcs.Find(f => (f.id == o.Id) && (f.guid == o.Guid) && (f.zoneid == o.ZoneId) && (new Vector3(f.x, f.y, f.z).Distance(o.Coordinates) < 100)) == null)
                {
                    string s;
                    if ((o.ObjectType == 4) && (o.Name.Length > 0))
                    {
                        _npcs.Add(new NPCRecord(o));


                        if ((_npcs.Count%50) == 0)
                        {
                            SaveNPCs();
                        }

                    }

                }
            }
        }

        private static void SaveNPCs()
        {
            string filename = (string)_filenames[4];
            if (_npcs.Count < 1) return;

            if (File.Exists(filename)) File.Delete(filename);
            using (FileStream stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<NPCRecord>));
                ser.Serialize(stream, _npcs);
            }            
        }
        
        private static void LoadNPCs()
        {
            string filename = (string)_filenames[4];

            if (File.Exists(filename))
            {
                using (FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    XmlSerializer ser = new XmlSerializer(typeof (List<NPCRecord>));
                    _npcs = (List<NPCRecord>) ser.Deserialize(stream);
                }
            }
        }

        public static void Stop()
        {
            if (_writeThread != null)
            {
                _runHandle.Set();
                _writeThread.Join(5000);
                _writeThread.Abort();
                _writeThread = null;
                SaveNPCs();
            }
            Started = false;
        }
    
        public static void Add(FoundObject o)
        {
            _lock.EnterWriteLock();
            try
            {
                _queue.Enqueue(o);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
    }

    [Serializable]
    public class NPCRecord
    {
        [XmlAttribute]
        public string name;
        [XmlAttribute]
        public int id;
        [XmlAttribute]
        public int guid;
        [XmlAttribute]
        public int x;
        [XmlAttribute]
        public int z;
        [XmlAttribute]
        public int y;
        [XmlAttribute]
        public int zoneid;

        public NPCRecord()
        {
        }

        public NPCRecord(FoundObject o)
        {
            name = o.Name;
            id = o.Id;
            guid = o.Guid;
            x = (int)o.Coordinates.X;
            z = (int)o.Coordinates.Z;
            y = (int)o.Coordinates.Y;
            zoneid = o.ZoneId;
        }
    }
}