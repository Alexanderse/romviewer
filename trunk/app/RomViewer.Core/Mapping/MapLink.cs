using SharpLite.Domain;

namespace RomViewer.Core.Mapping
{
    public class MapLink : Entity
    {
        public virtual MapPoint Start { get; set; }
        public virtual MapPoint End { get; set; }
        public virtual LinkType LinkType { get; set; }
        public virtual string Script { get; set; }

        public virtual string ToDelimitedString(int delimiter)
        {
            char delim = (char) delimiter;
            string result = string.Format("{1}{0}{2}{0}{3}", delim, Start.X, Start.Y, Start.Z);
            result = string.Format("{1}{0}{2}", delim, result, Script);
            result = string.Format("{1}{0}{2}{0}{3}{0}{4}", delim, result, End.X, End.Y, End.Z);

            return result;
        }
    }
}