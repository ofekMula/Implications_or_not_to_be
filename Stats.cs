

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
