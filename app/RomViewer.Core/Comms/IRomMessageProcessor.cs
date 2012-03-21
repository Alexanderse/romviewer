namespace RomViewer.Core.Comms
{
    public interface IRomMessageProcessor
    {
        string GetDelimiter();
        string HandleMessage(string message);
    }
}