// Decompiled with JetBrains decompiler
// Type: AlertsProject.Stats
// Assembly: AlertsProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01CC30A2-D287-482E-A95A-AE835F91B86F
// Assembly location: C:\Users\Ofek Mula\Desktop\AlertsProject.exe

using System;

namespace AlertsProject
{
  [Serializable]
  public class Stats
  {
    private int numberOfComponents;
    private int numberOfFaults;

    public Stats(int numberOfComponents, int numberOfFaults)
    {
      this.numberOfComponents = numberOfComponents;
      this.numberOfFaults = numberOfFaults;
    }

    public int getNumberOfComponents()
    {
      return this.numberOfComponents;
    }

    public int getNumberOfFaults()
    {
      return this.numberOfFaults;
    }

    public void setNumberOfComponents(int newNumberOfComponents)
    {
      this.numberOfComponents = newNumberOfComponents;
    }

    public void setNumberOfFaults(int newNumberOfFaults)
    {
      this.numberOfComponents = this.numberOfFaults;
    }
  }
}
