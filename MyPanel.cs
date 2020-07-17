// Decompiled with JetBrains decompiler
// Type: AlertsProject.MyPanel
// Assembly: AlertsProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01CC30A2-D287-482E-A95A-AE835F91B86F
// Assembly location: C:\Users\Ofek Mula\Desktop\AlertsProject.exe

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
