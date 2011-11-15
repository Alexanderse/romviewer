using System.IO;
using System.Xml;
using System.Xml.Serialization;
using RomViewer;

namespace RomViewer
{
    //this is a WIP - was supposed to be able to load and save all these but have never got around to it
    public class GameCommand
    {
        public string CommandName { get; set; }
        public string CommandText { get; set; }
        public bool AutoRun { get; set; }
    

        public GameCommand(string commandName, string commandText)
        {
            CommandName = commandName;
            CommandText = commandText;
            AutoRun = false;
        }

        public GameCommand(string commandName, string commandText, bool autoRun)
        {
            CommandName = commandName;
            CommandText = commandText;
            AutoRun = autoRun;
        }
    }


    public class CommandList
    {
        public BindingListEx<GameCommand> Commands = new BindingListEx<GameCommand>();

        public static CommandList LoadFromFile(string filename)
        {
            CommandList result = new CommandList();

            if (File.Exists(filename))
            {
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                try
                {

                    XmlSerializer ser = new XmlSerializer(typeof (CommandList));
                    result = (CommandList) ser.Deserialize(fs);
                }
                finally
                {
                    fs.Close();
                }
            }

            return result;
        }

        public void WriteToFile(string filename)
        {
            return;

        }

    }
}
