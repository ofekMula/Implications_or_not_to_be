// Decompiled with JetBrains decompiler
// Type: AlertsProject.InfoFile
// Assembly: AlertsProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01CC30A2-D287-482E-A95A-AE835F91B86F
// Assembly location: C:\Users\Ofek Mula\Desktop\AlertsProject.exe

namespace AlertsProject
{
  public class InfoFile
  {
    private string fileName;
    private string filePath;

    public InfoFile()
    {
      this.fileName = "";
      this.filePath = "";
    }

    public InfoFile(string fileName, string filePath)
    {
      this.fileName = fileName;
      this.filePath = filePath;
    }

    public string getFilePath()
    {
      return this.filePath;
    }

    public string getFileName()
    {
      return this.fileName;
    }

    public void setFilePath(string filePath)
    {
      this.filePath = filePath;
    }

    public void setFileName(string fileName)
    {
      this.fileName = fileName;
    }
  }
}
