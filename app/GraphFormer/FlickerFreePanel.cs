using System.Windows.Forms;

namespace GraphViewer
{
	/// <summary>
	/// Summary description for FlickerFreePanel.
	/// </summary>
	public class FlickerFreePanel : Panel
	{
		public FlickerFreePanel()
		{
			SetStyle(ControlStyles.ResizeRedraw, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.UserPaint, true);
		}
	}
}
