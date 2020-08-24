

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
