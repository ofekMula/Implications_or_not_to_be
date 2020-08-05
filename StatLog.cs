

using System;
using System.Collections.Generic;

namespace AlertsProject
{
  [Serializable]
  public class StatLog
  {
    private string statsLogPath;
    private Dictionary<DateTime, Stats> statsRelativeToDate;

    public StatLog(string databasePath, Dictionary<DateTime, Stats> statsRelativeToDate)
    {
      this.statsLogPath = databasePath;
      this.statsRelativeToDate = statsRelativeToDate;
    }

    public StatLog()
    {
      this.statsLogPath = "";
      this.statsRelativeToDate = new Dictionary<DateTime, Stats>();
    }

    public string getStatsLogPath()
    {
      return this.statsLogPath;
    }

    public Dictionary<DateTime, Stats> getStatsRelativeToDate()
    {
      return this.statsRelativeToDate;
    }

    public void setStatsLogPath(string statsLogPath)
    {
      this.statsLogPath = statsLogPath;
    }

    public void setStatsRelativeToDate(Dictionary<DateTime, Stats> statsRelativeToDate)
    {
      this.statsRelativeToDate = statsRelativeToDate;
    }
  }
}
