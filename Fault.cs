// Decompiled with JetBrains decompiler
// Type: AlertsProject.Fault
// Assembly: AlertsProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01CC30A2-D287-482E-A95A-AE835F91B86F
// Assembly location: C:\Users\Ofek Mula\Desktop\AlertsProject.exe

using System;
using System.Collections.Generic;

namespace AlertsProject
{
  [Serializable]
  public class Fault
  {
    private string name;
    private string implication;
    private List<SystemComponent> affectedComponents;

    public Fault(string name, string implication)
    {
      this.name = name;
      this.implication = implication;
    }

    public Fault(string name, string implication, List<SystemComponent> affectedComponents)
    {
      this.name = name;
      this.implication = implication;
      this.affectedComponents = affectedComponents;
    }

    public Fault()
    {
      this.name = "";
      this.implication = "";
      this.affectedComponents = new List<SystemComponent>();
    }

    public string getName()
    {
      return this.name;
    }

    public string getimplication()
    {
      return this.implication;
    }

    public List<SystemComponent> getAffectedComponents()
    {
      return this.affectedComponents;
    }

    public void setName(string name)
    {
      this.name = name;
    }

    public void setImplications(string implication)
    {
      this.implication = implication;
    }

    public void setAffectedComponents(List<SystemComponent> affectedComponents)
    {
      this.affectedComponents = affectedComponents;
    }

    public bool isEquals(Fault fault)
    {
      return this.name == fault.getName() && this.implication == fault.getimplication() && this.isEqualSystemComponentLists(fault.getAffectedComponents(), this.affectedComponents);
    }

    public bool isEqualSystemComponentLists(
      List<SystemComponent> list1,
      List<SystemComponent> list2)
    {
      if (list1 == null || list2 == null || list1.Count != list2.Count)
        return false;
      if (list1.Count == 0)
        return true;
      for (int index = 0; index < list1.Count; ++index)
      {
        if (list1[index].getName() != list2[index].getName())
          return false;
      }
      return true;
    }

    public string toString()
    {
      return "שם התקלה: " + this.name + ",משמעויות: " + this.implication;
    }
  }
}
