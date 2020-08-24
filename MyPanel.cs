
using System.Windows.Forms;

namespace AlertsProject
{
  public class MyPanel : Panel
  {
    public MyPanel()
    {
      this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
      this.Invalidate();
      this.DoubleBuffered = true;
    }
  }
}
