using System;
using System.Collections.Generic;

namespace AlertsProject
{
  [Serializable]
  public class SystemComponent
  {
    public static readonly int NUM_OF_FIELDS = 2;
    private string name;
    private string description;
    private List<Fault> faultsList;
    private List<InfoFile> filesList;
    private string componentImageUrl;
    private string componentType;

    public SystemComponent(string name, string description)
    {
      this.name = name;
      this.description = description;
    }

    public SystemComponent(string name, List<Fault> faultsList)
    {
      this.name = name;
      this.faultsList = faultsList;
    }

    public SystemComponent(string name, string description, List<Fault> faultsList)
    {
      this.name = name;
      this.description = description;
      this.faultsList = faultsList;
    }

    public SystemComponent(
      string name,
      string description,
      List<Fault> faultsList,
      List<InfoFile> files)
    {
      this.name = name;
      this.description = description;
      this.faultsList = faultsList;
      this.filesList = files;
    }

    public SystemComponent(
      string name,
      string description,
      List<Fault> faultsList,
      List<InfoFile> files,
      string componentImageUrl,
      string componentType)
    {
      this.name = name;
      this.description = description;
      this.faultsList = faultsList;
      this.filesList = files;
      this.componentImageUrl = componentImageUrl;
      this.componentType = componentType;
    }

    public SystemComponent()
    {
      this.name = "";
      this.description = "";
      this.faultsList = new List<Fault>();
    }

    public string getName()
    {
      return this.name;
    }

    public string getDescription()
    {
      return this.description;
    }

    public List<Fault> getFaultsList()
    {
      return this.faultsList;
    }

    public List<InfoFile> getFilesList()
    {
      return this.filesList;
    }

    public string getImage()
    {
      return this.componentImageUrl;
    }

    public string getComponentType()
    {
      return this.componentType;
    }

    public void setName(string name)
    {
      this.name = name;
    }

    public void setDescription(string description)
    {
      this.description = description;
    }

    public void setFaultsList(List<Fault> faultsList)
    {
      this.faultsList = faultsList;
    }

    public void setFielsList(List<InfoFile> files)
    {
      this.filesList = files;
    }

    public void setComponentImage(string newImageUrl)
    {
      this.componentImageUrl = newImageUrl;
    }

    public string getFieldByIndex(int i, bool isCheckBoxSelection)
    {
      if (isCheckBoxSelection)
      {
        if (i == 1)
          return this.name;
        return i == 2 ? this.description : "";
      }
      if (i == 0)
        return this.name;
      return i == 1 ? this.description : "";
    }

    public bool isEquals(SystemComponent component)
    {
      return this.name == component.getName();
    }

    public bool isEqualsFaultsList(List<Fault> list1, List<Fault> list2)
    {
      for (int index1 = 0; index1 < list1.Count; ++index1)
      {
        for (int index2 = 0; index2 < list2.Count; ++index2)
        {
          if (!list1[index1].isEquals(list2[index2]))
            return false;
        }
      }
      return true;
    }

    public string toString()
    {
      return "שם הרכיב הוא: " + this.name + "משמעויות: " + this.faultsList.ToString();
    }
  }
}
