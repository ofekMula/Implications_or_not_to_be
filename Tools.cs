using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace AlertsProject
{
  internal class Tools
  {
    public static bool adminMode = false;
    public static readonly string Delimeter = "ASDF###@@@@ASDF";
    public static readonly string ADMIN_USERNAME = "admin";
    public static readonly string ADMIN_PASSWORD = "admin";
    public static readonly string REGULAR_USERNAME = "user";
    public static readonly string REGULAR_PASSWORD = "user";
    public static readonly string NO_FAULTS_IMPLICATION = "אין מידע עבור רכיב זה";
    public static readonly string DEAFULT_IMPLICATION = "יש לבחור תקלה כדי לראות מידע";
    public static readonly string NEED_TO_CHOOSE_COMPONENT_IMPLICATION = "יש לבחור רכיב כדי לראות מידע";
    public static readonly string DEAFULT_SYSTEMCOMPONENT = "";
    public static readonly string AUTHENTICATION_ERROR = "שם משתמש או ססמא אינם נכונים";
    public static readonly string ADD_COMPONENT_ERROR = "יש לרשום את שם הרכיב וגם את ההשלכות שלו!";
    public static readonly string ALREADY_EXISTS_COMPONENT_ERROR = "הרכיב קיים בכבר במאגר!";
    public static readonly string ADD_COMPONENT_SUCCEEDED = "הרכיב הוסף בהצלחה למאגר!";
    public static readonly string UPDATE_COMPONENT_SUCCEEDED = "הרכיב עודכן בהצלחה!";
    public static readonly string UPDATE_COMPONENT_ERROR = "יש לעדכן את אחד מפרטי הרכיב קודם";
    public static readonly string CHOOSE_COMPONENT_ERROR = "יש ראשית לבחור רכיב";
    public static readonly string DELETE_COMPONENT_ERROR = "יש לבחור רכיב למחיקה";
    public static readonly string DELETE_COMPONENT_SUCCEEDDED = "הפריטים נמחקו בהצלחה!";
    public static readonly string DELETE_COMPONENT_QUESTION = "האם אתה בטוח שברצונך למחוק פריטים אלו?";
    public static readonly string DATABASE_DIRECTORY_ERROR = "הקובץ אינו מסד נתונים. יש לבחור במסד נתונים אחר!";
    public static readonly string SEARCH_WORD_ERROR = "יש למלא את שורת הטקסט כדי לחפש התאמות";
    public static readonly string MATCHING_RESULT = "מספר ההתאמות שנמצאו: ";
    public static readonly string ADD_FAULT_SUCCEEDED = "התקלה נוספה בהצלחה!";
    public static readonly string ADD_FAULT_ERROR1 = "יש לרשום את שם התקלה ומה המשמעויות שלה";
    public static readonly string ADD_FAULT_ERROR2 = "תקלה זו קיימת כבר עבור רכיב זה!";
    public static readonly string UPDATE_FAULT_ERROR = "לא ניתן לעדכן תקלות לרכיב שאין לו תקלות!";
    public static readonly string PATH_DELIMETER = "\\";
    public static readonly string DEFAULT_FILENAME = "dataBase";
    public static readonly string DEFAULT_DATABASE_FILENAME_ENDING = ".om";
    public static readonly string INFORMATION = "מידע";
    public static readonly string WARNING = "אזהרה";
    public static readonly string ERROR = "שגיאה";
    public static readonly int DEAFULT_index = -1;
    public static readonly int COEFFICIENT = 1;
    public static readonly int FORM_WIDTH = 1100;
    public static readonly int FORM_HEIGHT = 40;
    public static readonly int MENU_WIDTH_SLIDE_MODE_OFF = 40;
    public static readonly int MENU_WIDTH_SLIDE_MODE_ON = 200;
    public static readonly int FORM_WIDTH_SLIDE_MODE_OFF = Tools.FORM_WIDTH - Tools.MENU_WIDTH_SLIDE_MODE_ON;
    public static readonly int FORM_WIDTH_SLIDE_MODE_ON = Tools.FORM_WIDTH;
    public static string LOG_LAST_DB_FILE_PATH = Environment.CurrentDirectory + Tools.PATH_DELIMETER + "logFile.txt";
    public static readonly int MINIMUM_VALUE_BAR = 0;
    public static readonly int MAXIMUM_VALUE_BAR = 100;
    public static readonly string BAR_MEASURE_BY = "%";
    public static readonly string STATS = "stats";
    public static int MAX_Length_STATS_DAYS = 5;
    public static List<SystemComponent> DataBase;
    public static List<string> componentsList;
    public static string path;
    public static StatLog statsForChart;
    public static string STATS_LOG_FILENAME;
    public static string DATABASE_FILENAME;
    public static string USER_DB_FILENAME = "users_db";
        public static string USER_DB_PATH ;
        public static List<User> usersList;

    public static void writeDB()
    {
      try
      {
        using (Stream serializationStream = (Stream) File.Open(Tools.path, FileMode.Create))
        {
          new BinaryFormatter().Serialize(serializationStream, (object) Tools.DataBase);
          serializationStream.Close();
        }
      }
      catch (Exception ex)
      {

      }
    }

    public static void readDB()
    {
      if (!File.Exists(Tools.path))
        File.Create(Tools.path)?.Close();
      Tools.DATABASE_FILENAME = Path.GetFileName(Tools.path);
      using (Stream serializationStream = (Stream) File.Open(Tools.path, FileMode.Open))
      {
        if (serializationStream.Length > 0L)
        {
          Tools.DataBase = (List<SystemComponent>) new BinaryFormatter().Deserialize(serializationStream);
        }
        else
        {
          Tools.DataBase = new List<SystemComponent>();
          Tools.componentsList = new List<string>();
        }
        serializationStream.Close();
      }
    }

    public static void createComponentsList()
    {
      List<string> stringList = new List<string>();
      for (int index = 0; index < Tools.DataBase.Count; ++index)
        stringList.Add(Tools.DataBase[index].getName());
      Tools.componentsList = stringList;
    }

    public static List<string> createFaultsNamesList(List<Fault> list)
    {
      List<string> stringList = new List<string>();
      for (int index = 0; index < list.Count; ++index)
        stringList.Add(list[index].getName());
      return stringList;
    }

    public static void ResetAllControls(Control form)
    {
      foreach (Control control in (ArrangedElementCollection) form.Controls)
      {
        if (control is TextBox)
          control.Text = "";
        if (control is RichTextBox)
          control.Text = "";
        if (control is ComboBox)
          ((ListControl) control).SelectedIndex = -1;
        if (control is DataGridView)
          ((DataGridView) control).Rows.Clear();
      }
    }

    public static string Encrypt(string line)
    {
      string str = "";
      foreach (uint num in line)
      {
        char ch = (char) (num + (uint) Tools.COEFFICIENT);
        str += ch.ToString();
      }
      return str;
    }

    public static string Decrypt(string line)
    {
      string str = "";
      foreach (uint num in line)
      {
        char ch = (char) (num - (uint) Tools.COEFFICIENT);
        str += ch.ToString();
      }
      return str;
    }

    public static bool onlySpaces(string word)
    {
      foreach (char ch in word)
      {
        if (ch != ' ')
          return false;
      }
      return true;
    }

    public static string fixedPath(string fileDirectory)
    {
      Regex.Split(fileDirectory, "");
      return fileDirectory;
    }

    public static bool isNotEmptyString(string word)
    {
      return word != null && (!Tools.onlySpaces(word) && word != "");
    }

    public static void DeleteFromDB(SystemComponent component)
    {
      for (int index = 0; index < Tools.DataBase.Count; ++index)
      {
        if (component.isEquals(Tools.DataBase[index]))
        {
          Tools.DataBase.RemoveAt(index);
          Tools.componentsList.RemoveAt(index);
        }
      }
    }

    public static void DeleteImplicationFromList(List<Fault> list, Fault implication)
    {
      for (int index = 0; index < list.Count; ++index)
      {
        if (implication.isEquals(list[index]))
          list.RemoveAt(index);
      }
    }

    public static void LoadNextWindow(Form currentWindow, Form nextWindow, bool hideFlage)
    {
      if (hideFlage)
        currentWindow.Hide();
      int num = (int) nextWindow.ShowDialog();
    }

    public static bool isValidComponent(string componentName)
    {
      if (Tools.isExistInDB(componentName))
      {
        int num = (int) MessageBox.Show(Tools.ALREADY_EXISTS_COMPONENT_ERROR, Tools.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return false;
      }
      if (!(componentName == "") && !string.IsNullOrWhiteSpace(componentName))
        return true;
      int num1 = (int) MessageBox.Show(Tools.ADD_COMPONENT_ERROR, Tools.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      return false;
    }

    public static bool isValidFault(
      List<Fault> FaultsList,
      string faultName,
      string implication,
      List<SystemComponent> affectedComponents)
    {
      if (faultName == "" || implication == "")
      {
        int num = (int) MessageBox.Show(Tools.ADD_FAULT_ERROR1, Tools.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return false;
      }
      if (string.IsNullOrWhiteSpace(faultName) || string.IsNullOrWhiteSpace(implication))
      {
        int num = (int) MessageBox.Show(Tools.ADD_FAULT_ERROR1, Tools.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return false;
      }
      if (FaultsList != null)
      {
        for (int index = 0; index < FaultsList.Count; ++index)
        {
          if (FaultsList[index].getName() == faultName)
          {
            int num = (int) MessageBox.Show(Tools.ADD_FAULT_ERROR2, Tools.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return false;
          }
        }
      }
      return true;
    }

    public static SystemComponent findComponentInListOfComponents(
      List<SystemComponent> list,
      string name)
    {
      if (list.Count > 0)
      {
        for (int index = 0; index < list.Count; ++index)
        {
          if (name == list[index].getName())
            return list[index];
        }
      }
      return (SystemComponent) null;
    }

    public static int findComponentIndexInListOfComponents(List<SystemComponent> list, string name)
    {
      if (list.Count > 0)
      {
        for (int index = 0; index < list.Count; ++index)
        {
          if (name == list[index].getName())
            return index;
        }
      }
      return -1;
    }

    public static Fault findFaultInListOfFaults(List<Fault> list, string name)
    {
      for (int index = 0; index < list.Count; ++index)
      {
        if (name == list[index].getName())
          return list[index];
      }
      return (Fault) null;
    }

    public static void loadListIntoDataGridView(
      List<SystemComponent> list,
      DataGridView componentsView,
      bool isCheckBoxselection)
    {
      componentsView.Rows.Clear();
      List<SystemComponent> systemComponentList = list;
      int num = 0;
      if (isCheckBoxselection)
        num = 1;
      for (int index = 0; index < systemComponentList.Count; ++index)
      {
        DataGridViewRow dataGridViewRow = new DataGridViewRow();
        componentsView.Rows.Add(dataGridViewRow);
        for (int i = num; i < componentsView.ColumnCount; ++i)
          componentsView.Rows[index].Cells[i].Value = (object) systemComponentList[index].getFieldByIndex(i, isCheckBoxselection);
      }
      componentsView.ClearSelection();
    }

    public static void loadFaultsIntoDataGridView(
      List<Fault> list,
      DataGridView faultsNamesView,
      bool isChekBoxSelection)
    {
      faultsNamesView.Rows.Clear();
      List<Fault> faultList = list;
      for (int index1 = 0; index1 < faultList.Count; ++index1)
      {
        DataGridViewRow dataGridViewRow = new DataGridViewRow();
        faultsNamesView.Rows.Add(dataGridViewRow);
        int index2;
        int index3;
        if (isChekBoxSelection)
        {
          index2 = 1;
          index3 = 2;
        }
        else
        {
          index2 = 0;
          index3 = 1;
        }
        faultsNamesView.Rows[index1].Cells[index2].Value = (object) faultList[index1].getName();
        faultsNamesView.Rows[index1].Cells[index3].Value = (object) faultList[index1].getimplication();
        faultsNamesView.ClearSelection();
      }
    }

    public static void searchAndDisplayComponent(
      string word,
      DataGridView componentsView,
      bool isCheckBoxSelection)
    {
      if (Tools.isNotEmptyString(word))
      {
        List<SystemComponent> matchedListByWord = Tools.createMatchedListByWord(word);
        componentsView.Rows.Clear();
        Tools.loadListIntoDataGridView(matchedListByWord, componentsView, isCheckBoxSelection);
        int count = matchedListByWord.Count;
        componentsView.ClearSelection();
        int num = (int) MessageBox.Show(Tools.MATCHING_RESULT + count.ToString(), Tools.INFORMATION, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        int num1 = (int) MessageBox.Show(Tools.SEARCH_WORD_ERROR, Tools.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    public static int countCheckedComponents(DataGridView componentsView)
    {
      int num = 0;
      for (int index = 0; index < componentsView.Rows.Count; ++index)
      {
        DataGridViewRow row = componentsView.Rows[index];
        if (row.Cells[0].Value != null && (bool) row.Cells[0].Value)
          ++num;
      }
      return num;
    }

    public static int findCheckedImplication(DataGridView implicationsView)
    {
      int num = -1;
      for (int index = 0; index < implicationsView.Rows.Count; ++index)
      {
        DataGridViewRow row = implicationsView.Rows[index];
        if (row.Cells[0].Value != null && (bool) row.Cells[0].Value)
          return index;
      }
      return num;
    }

    public static List<SystemComponent> selectedItemsList(
      DataGridView componentsView)
    {
      List<SystemComponent> systemComponentList = new List<SystemComponent>();
      for (int index = 0; index < componentsView.Rows.Count; ++index)
      {
        DataGridViewRow row = componentsView.Rows[index];
        if (row.Cells[0].Value != null && (bool) row.Cells[0].Value)
        {
          SystemComponent listOfComponents = Tools.findComponentInListOfComponents(Tools.DataBase, (string) row.Cells[1].Value);
          if (listOfComponents != null)
            systemComponentList.Add(listOfComponents);
        }
      }
      return systemComponentList;
    }

    public static List<Fault> selectedFaultsInDataView(
      DataGridView faultsView,
      List<Fault> FaultsToAdd,
      bool selectionByCheckBoxFlag)
    {
      List<Fault> faultList = new List<Fault>();
      for (int index = 0; index < faultsView.Rows.Count; ++index)
      {
        DataGridViewRow row = faultsView.Rows[index];
        if (selectionByCheckBoxFlag)
        {
          if (row.Cells[0].Value != null && (bool) row.Cells[0].Value)
          {
            Fault faultInListOfFaults = Tools.findFaultInListOfFaults(FaultsToAdd, (string) row.Cells[1].Value);
            if (faultInListOfFaults != null)
              faultList.Add(faultInListOfFaults);
          }
        }
        else if (row.Selected)
        {
          Fault faultInListOfFaults = Tools.findFaultInListOfFaults(FaultsToAdd, (string) row.Cells[0].Value);
          if (faultInListOfFaults != null)
            faultList.Add(faultInListOfFaults);
        }
      }
      return faultList;
    }

    public static void updateComboBox(ComboBox list, List<string> componentsNamesList)
    {
      list.DataSource = (object) null;
      list.Items.Clear();
      list.DataSource = (object) componentsNamesList;
      list.DisplayMember = Tools.DEAFULT_SYSTEMCOMPONENT;
      list.SelectedIndex = Tools.DEAFULT_index;
    }

    public static List<SystemComponent> createMatchedListByWord(string word)
    {
      List<SystemComponent> systemComponentList = new List<SystemComponent>();
      List<SystemComponent> dataBase = Tools.DataBase;
      for (int index = 0; index < dataBase.Count; ++index)
      {
        if (dataBase[index].getName().Contains(word) || dataBase[index].getDescription().Contains(word) || Tools.isFaultsListContainWord(dataBase[index].getFaultsList(), word))
          systemComponentList.Add(dataBase[index]);
      }
      return systemComponentList;
    }

    public static bool isFaultsListContainWord(List<Fault> faults, string word)
    {
      if (faults != null)
      {
        for (int index = 0; index < faults.Count; ++index)
        {
          if (faults[index].getName().Contains(word) || faults[index].getimplication().Contains(word) || Tools.isComponentsListContainWord(faults[index].getAffectedComponents(), word))
            return true;
        }
      }
      return false;
    }

    public static bool isComponentsListContainWord(List<SystemComponent> components, string word)
    {
      if (components != null)
      {
        for (int index = 0; index < components.Count; ++index)
        {
          if (components[index].getName().Contains(word))
            return true;
        }
      }
      return false;
    }

    public static List<SystemComponent> createMatchedListByList(
      List<SystemComponent> firstList,
      List<SystemComponent> secondList)
    {
      List<SystemComponent> systemComponentList = new List<SystemComponent>();
      foreach (SystemComponent first in firstList)
      {
        foreach (SystemComponent second in secondList)
        {
          if (first.isEquals(second))
            systemComponentList.Add(first);
        }
      }
      return systemComponentList;
    }

    public static bool isValidDataBaseDirectory(string path)
    {
      return path != null && (!Tools.onlySpaces(path) && path != "" && path.EndsWith(Tools.DEFAULT_DATABASE_FILENAME_ENDING) && File.Exists(path));
    }

    public static Button disableButton(Button button)
    {
      button.BackgroundImage = (Image) null;
      button.BackColor = Color.DarkGray;
      button.ForeColor = Color.DimGray;
      button.Enabled = false;
      return button;
    }

    public static bool isExistInDB(string name)
    {
      for (int index = 0; index < Tools.DataBase.Count; ++index)
      {
        if (name == Tools.DataBase[index].getName())
          return true;
      }
      return false;
    }

    public static string concatenatingFaultsList(List<Fault> list)
    {
      string str = "";
      for (int index = 0; index < list.Count; ++index)
        str = index != list.Count - 1 ? str + list[index].toString() + ". " : str + list[index].toString();
      return str;
    }

    public static bool isSlideModeOn(Panel menuPanel)
    {
      return menuPanel.Width == Tools.MENU_WIDTH_SLIDE_MODE_ON;
    }

    public static bool isSlideModeOff(Panel menuPanel)
    {
      return menuPanel.Width == Tools.MENU_WIDTH_SLIDE_MODE_OFF;
    }

    public static void readLog()
    {
      StreamReader streamReader = new StreamReader(Tools.LOG_LAST_DB_FILE_PATH);
      string str = streamReader.ReadLine();
      streamReader.Close();
      Tools.path = str;
    }

    public static int numberOfComponentsInDB()
    {
      return Tools.DataBase.Count;
    }

    public static int numberOfFaultsInDB()
    {
      int num = 0;
      for (int index = 0; index < Tools.DataBase.Count; ++index)
      {
        if (Tools.DataBase[index].getFaultsList() != null)
          num += Tools.DataBase[index].getFaultsList().Count;
      }
      return num;
    }

    public static int numberOfComponentsWithFaultsInDB()
    {
      int num = 0;
      for (int index = 0; index < Tools.DataBase.Count; ++index)
      {
        if (Tools.DataBase[index].getFaultsList() != null && Tools.DataBase[index].getFaultsList().Count > 0)
          ++num;
      }
      return num;
    }

    public static double componentDivisionRelativeToAll(int numberOfComponentsInDivision)
    {
      return (uint) Tools.DataBase.Count > 0U ? (double) numberOfComponentsInDivision / (double) Tools.DataBase.Count : 0.0;
    }

    public static int FractionToPercents(double fraction)
    {
      return (int) (fraction * 100.0);
    }

    public static double avgNumOfFaultsPerComponent()
    {
      return (uint) Tools.numberOfComponentsInDB() > 0U ? (double) Tools.numberOfFaultsInDB() / (double) Tools.numberOfComponentsInDB() : 0.0;
    }

    public static int numberOfAffectedComponentsInDB()
    {
      int num = 0;
      for (int index1 = 0; index1 < Tools.DataBase.Count; ++index1)
      {
        if (Tools.DataBase[index1].getFaultsList() != null && Tools.DataBase[index1].getFaultsList().Count > 0)
        {
          List<Fault> faultsList = Tools.DataBase[index1].getFaultsList();
          for (int index2 = 0; index2 < faultsList.Count; ++index2)
          {
            if (faultsList[index2].getAffectedComponents() != null)
              num += faultsList[index2].getAffectedComponents().Count;
          }
        }
      }
      return num;
    }

    public static double avgNumOfAffectedComponentPerFaults()
    {
      return (uint) Tools.numberOfFaultsInDB() > 0U ? (double) Tools.numberOfAffectedComponentsInDB() / (double) Tools.numberOfFaultsInDB() : 0.0;
    }

    public static void writeStatsFile()
    {
      Tools.updateStatsOfDB();
      try
      {
        using (Stream serializationStream = (Stream) File.Open(Tools.statsForChart.getStatsLogPath(), FileMode.Create))
        {
          new BinaryFormatter().Serialize(serializationStream, (object) Tools.statsForChart);
          serializationStream.Close();
        }
      }
      catch (Exception ex)
      {
      }
    }

    public static void readStatsFile(string statsPath)
    {
      if (!File.Exists(statsPath))
        File.Create(statsPath)?.Close();
      using (Stream serializationStream = (Stream) File.Open(statsPath, FileMode.Open))
      {
        Tools.statsForChart = serializationStream.Length <= 0L ? new StatLog() : (StatLog) new BinaryFormatter().Deserialize(serializationStream);
        Tools.statsForChart.setStatsLogPath(statsPath);
        serializationStream.Close();
      }
    }

    public static void updateStatsOfDB()
    {
      DateTime now = DateTime.Now;
      Dictionary<DateTime, Stats> statsRelativeToDate = Tools.statsForChart.getStatsRelativeToDate();
      if (statsRelativeToDate.Count < Tools.MAX_Length_STATS_DAYS)
      {
        Stats stats = new Stats(Tools.numberOfComponentsInDB(), Tools.numberOfFaultsInDB());
        statsRelativeToDate.Add(now, stats);
      }
      else
      {
        now.CompareTo(statsRelativeToDate.Keys.Max<DateTime>());
        DateTime key1 = statsRelativeToDate.Keys.Max<DateTime>();
        if (now.Day == key1.Day && now.Month == key1.Month && now.Year == key1.Year)
        {
          statsRelativeToDate.Remove(key1);
          statsRelativeToDate.Add(now, new Stats(Tools.numberOfComponentsInDB(), Tools.numberOfFaultsInDB()));
        }
        else
        {
          DateTime key2 = statsRelativeToDate.Keys.Min<DateTime>();
          statsRelativeToDate.Remove(key2);
          Stats stats = new Stats(Tools.numberOfComponentsInDB(), Tools.numberOfFaultsInDB());
          statsRelativeToDate.Add(now, stats);
        }
      }
      Tools.statsForChart.setStatsRelativeToDate(statsRelativeToDate);
    }

    public static string createDateLabelForChart(DateTime time)
    {
      int num = time.Day;
      string str1 = num.ToString();
      num = time.Month;
      string str2 = num.ToString();
      return str1 + "." + str2;
    }

    public static void getAffectingComponents(
      SystemComponent selectedComponent,
      List<SystemComponent> listOfAffectingComponents)
    {
      for (int index1 = 0; index1 < Tools.DataBase.Count; ++index1)
      {
        if (selectedComponent.getName() != Tools.DataBase[index1].getName())
        {
          for (int index2 = 0; index2 < Tools.DataBase[index1].getFaultsList().Count; ++index2)
          {
            for (int index3 = 0; index3 < Tools.DataBase[index1].getFaultsList()[index2].getAffectedComponents().Count; ++index3)
            {
              if (selectedComponent.getName() == Tools.DataBase[index1].getFaultsList()[index2].getAffectedComponents()[index3].getName() && Tools.findComponentInListOfComponents(listOfAffectingComponents, Tools.DataBase[index1].getName()) == null)
              {
                listOfAffectingComponents.Add(Tools.DataBase[index1]);
                if (!Tools.isComponentParentIsAlsoHisSon(Tools.DataBase[index1], selectedComponent))
                  Tools.getAffectingComponents(Tools.DataBase[index1], listOfAffectingComponents);
              }
            }
          }
        }
      }
    }

    public static void createAffectedComponentsList(
      SystemComponent selectedComponent,
      Fault selectedFault,
      List<SystemComponent> affectedComponents)
    {
      affectedComponents.Add(selectedComponent);
      Tools.getAffeectedComponents(selectedComponent.getName(), selectedFault, affectedComponents);
    }

    public static void getAffeectedComponents(
      string selectedComponentName,
      Fault selectedFault,
      List<SystemComponent> affectedComponents)
    {
      for (int index1 = 0; index1 < selectedFault.getAffectedComponents().Count; ++index1)
      {
        SystemComponent affectedComponent = selectedFault.getAffectedComponents()[index1];
        if (affectedComponent.getName() != selectedComponentName && Tools.findComponentInListOfComponents(affectedComponents, selectedComponentName) == null)
        {
          affectedComponents.Add(affectedComponent);
          for (int index2 = 0; index2 < affectedComponent.getFaultsList().Count; ++index2)
            Tools.getAffeectedComponents(affectedComponent.getName(), affectedComponent.getFaultsList()[index2], affectedComponents);
        }
      }
    }

    public static bool isComponentParentIsAlsoHisSon(
      SystemComponent parent,
      SystemComponent selectedComponent)
    {
      for (int index1 = 0; index1 < selectedComponent.getFaultsList().Count; ++index1)
      {
        for (int index2 = 0; index2 < selectedComponent.getFaultsList()[index1].getAffectedComponents().Count; ++index2)
        {
          if (parent.getName() == selectedComponent.getFaultsList()[index1].getAffectedComponents()[index2].getName())
            return true;
        }
      }
      return false;
    }

    public static bool isUrlImage(string url)
    {
      try
      {
        url.IndexOf(".");
        int num = url.Length - 1;
        string str = url.Substring(url.IndexOf("."));
        return str == ".jpg" || str == ".png" || str == ".gif";
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
    }

        public static void readUsersDB()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\" + Tools.USER_DB_FILENAME))
                File.Create(Directory.GetCurrentDirectory() + "\\" + Tools.USER_DB_FILENAME);
            Tools.USER_DB_PATH = Path.GetFileName(Directory.GetCurrentDirectory() + "\\" + Tools.USER_DB_FILENAME);
            using (Stream serializationStream = (Stream)File.Open(Tools.USER_DB_PATH, FileMode.Open))
            {
                if (serializationStream.Length > 0L)
                {
                    Tools.usersList = (List<User>)new BinaryFormatter().Deserialize(serializationStream);
                }
                else
                {
              
                    Tools.usersList = new List<User>();
                }
                serializationStream.Close();
            }
        }
        public static void writeToUsersDB()
        {
            try
                {
                    using (Stream serializationStream = (Stream)File.Open(Tools.USER_DB_PATH, FileMode.Create))
                    {
                        new BinaryFormatter().Serialize(serializationStream, (object)Tools.usersList);
                        serializationStream.Close();
                    }
                }
                catch (Exception ex)
                {
                }
        }

        public static Boolean isValidUser(string nickName)
        {
            for (int index = 0; index < Tools.usersList.Count; index++)
            {
                if (Tools.usersList[index].getName() == nickName)
                {
                    return false;
                }
            }
            return true;
        }
        public static Boolean authenticationUser(string userName,string password)
        {
            for (int index = 0; index < Tools.usersList.Count; index++)
            {
                if (Tools.usersList[index].getUserName() == userName && Tools.usersList[index].getpassword()==password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
