// Decompiled with JetBrains decompiler
// Type: AlertsProject.Implications
// Assembly: AlertsProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01CC30A2-D287-482E-A95A-AE835F91B86F
// Assembly location: C:\Users\Ofek Mula\Desktop\AlertsProject.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AlertsProject
{
  public class Implications : Form
  {
    private bool hideMenu = true;
    private int stepSize = 100;
    private int currentSelectIndex = -1;
    private IContainer components = (IContainer) null;
    private Form authentication;
    private SystemComponent selectedComponent;
    private Label label3;
    private ComboBox componentsNameList;
    private Label label2;
    private RichTextBox implicationsTextBox;
    private Label label1;
    private Button deleteComponentButton;
    private Button logOutButton;
    private Button updateComponentButton;
    private Button advancedSearchButton;
    private Label label5;
    private ComboBox FaultsNamesComboBox;
    private Label label6;
    private DataGridView affectedComponentsView;
    private Label label7;
    private RichTextBox componentDescriptionTextBox;
    private DataGridViewTextBoxColumn FaultsHeader;
    private DataGridViewTextBoxColumn implicationsHeader;
    private Button addNewComponentButton;
    private MyPanel menuPanel;
    private Button slideMenuButton;
    private PictureBox pictureBox1;
    private Timer slideMenuTimer;
    private ContextMenuStrip contextMenuStrip1;
    private Button statisticsButton;
    private Label label4;

    private DataGridView affectingComponentsDataGrid;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private Label label8;
    private PictureBox pictureBox2;

    public Implications(Form authentication)
    {
      this.DoubleBuffered = true;
      this.InitializeComponent();
      this.authentication = authentication;
    }

    private void Implications_Load(object sender, EventArgs e)
    {
      this.DoubleBuffered = true;
      if (!Tools.adminMode)
        this.setSlideMenuForNotAdmin();
      if (!File.Exists(Tools.path))
        File.Create(Tools.path)?.Close();
      Tools.readDB();
      Tools.createComponentsList();
      Tools.updateComboBox(this.componentsNameList, Tools.componentsList);
      this.implicationsTextBox.Text = Tools.NEED_TO_CHOOSE_COMPONENT_IMPLICATION;
      this.componentDescriptionTextBox.Text = Tools.NEED_TO_CHOOSE_COMPONENT_IMPLICATION;
      this.loadStats();
      Tools.writeStatsFile();
    }

    private void Implications_FormClosed(object sender, FormClosedEventArgs e)
    {
      Application.Exit();
    }

    private void showImplications_Click(object sender, EventArgs e)
    {
    }

    private void label2_Click(object sender, EventArgs e)
    {
    }

    private void componentsNameList_SelectedIndexChanged(object sender, EventArgs e)
    {
      int selectedIndex = this.componentsNameList.SelectedIndex;
      List<SystemComponent> systemComponentList = new List<SystemComponent>();
      if (selectedIndex != -1)
      {
        this.selectedComponent = Tools.DataBase[selectedIndex];
        List<Fault> faultsList = this.selectedComponent.getFaultsList();
        this.componentDescriptionTextBox.Text = this.selectedComponent.getDescription();
        Tools.getAffectingComponents(this.selectedComponent, systemComponentList);
        Tools.loadListIntoDataGridView(systemComponentList, this.affectingComponentsDataGrid, false);
        if (faultsList == null)
          return;
        List<string> componentsNamesList = new List<string>();
        List<SystemComponent> list = new List<SystemComponent>();
        if (faultsList.Count > 0)
        {
          Tools.updateComboBox(this.FaultsNamesComboBox, Tools.createFaultsNamesList(faultsList));
          this.implicationsTextBox.Text = Tools.DEAFULT_IMPLICATION;
          Tools.loadListIntoDataGridView(list, this.affectedComponentsView, false);
        }
        else
        {
          this.implicationsTextBox.Text = Tools.NO_FAULTS_IMPLICATION;
          Tools.updateComboBox(this.FaultsNamesComboBox, componentsNamesList);
        }
      }
      else
      {
        Tools.ResetAllControls((Control) this);
        List<Fault> faultList = new List<Fault>();
      }
    }

    private void implicationsTextBox_TextChanged(object sender, EventArgs e)
    {
    }

    private void addNewComponentButton_Click(object sender, EventArgs e)
    {
      int num = (int) new AddComponent(this.componentsNameList, (Form) this).ShowDialog();
    }

    private void updateComponentButton_Click(object sender, EventArgs e)
    {
      int num = (int) new UpdateComponent(this.componentsNameList, (Form) this).ShowDialog();
    }

    private void deleteComponentButton_Click(object sender, EventArgs e)
    {
      int num = (int) new DeleteComponent(this.componentsNameList, (Form) this).ShowDialog();
    }

    private void logOutButton_Click(object sender, EventArgs e)
    {
      Tools.adminMode = false;
      this.Hide();
      Tools.ResetAllControls((Control) this.authentication);
      this.authentication.Show();
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void advancedSearchButton_Click(object sender, EventArgs e)
    {
      int num = (int) new AdvancedSearch((Form) this, this.componentsNameList).ShowDialog();
    }

    private void panel2_Paint(object sender, PaintEventArgs e)
    {
    }

    private void label4_Click(object sender, EventArgs e)
    {
    }

    private void faultsNamesComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      int selectedIndex = this.FaultsNamesComboBox.SelectedIndex;
      if (selectedIndex == -1)
        this.implicationsTextBox.Text = Tools.DEAFULT_IMPLICATION;
      else
        this.displaySelectedFault(selectedIndex);
    }

    private void slideMenuButton_Click(object sender, EventArgs e)
    {
      this.hideMenu = !this.hideMenu;
      this.slideMenuTimer.Start();
    }

    private void slideMenuTimer_Tick(object sender, EventArgs e)
    {
      if (!this.hideMenu)
      {
        this.menuPanel.Width += this.stepSize;
        if (this.menuPanel.Width < Tools.MENU_WIDTH_SLIDE_MODE_ON)
          return;
        this.menuPanel.Width = Tools.MENU_WIDTH_SLIDE_MODE_ON;
        this.slideMenuTimer.Stop();
        this.Refresh();
      }
      else
      {
        this.menuPanel.Width -= this.stepSize;
        if (this.menuPanel.Width <= Tools.MENU_WIDTH_SLIDE_MODE_OFF)
        {
          this.slideMenuTimer.Stop();
          this.menuPanel.Width = Tools.MENU_WIDTH_SLIDE_MODE_OFF;
          this.Refresh();
        }
      }
    }

    private void setSlideMenuForNotAdmin()
    {
      this.advancedSearchButton.Location = this.addNewComponentButton.Location;
      this.statisticsButton.Location = this.updateComponentButton.Location;
      this.logOutButton.Location = this.deleteComponentButton.Location;
      this.addNewComponentButton.Visible = false;
      this.updateComponentButton.Visible = false;
      this.deleteComponentButton.Visible = false;
    }

    private void displaySelectedFault(int selectedFaultIndex)
    {
      List<SystemComponent> systemComponentList = new List<SystemComponent>();
      SystemComponent selectedComponent = Tools.DataBase[this.componentsNameList.SelectedIndex];
      List<Fault> faultsList = selectedComponent.getFaultsList();
      Tools.createAffectedComponentsList(selectedComponent, faultsList[selectedFaultIndex], systemComponentList);
      Tools.loadListIntoDataGridView(systemComponentList, this.affectedComponentsView, false);
      this.implicationsTextBox.Text = faultsList[selectedFaultIndex].getimplication();
    }

    private void menuPanel_Paint(object sender, PaintEventArgs e)
    {
    }

    private void affectedComponentsView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void statisticsButton_Click(object sender, EventArgs e)
    {
      int num = (int) new Features().ShowDialog();
    }

    private void loadStats()
    {
      Tools.STATS_LOG_FILENAME = Tools.STATS + Tools.DATABASE_FILENAME;
      Tools.readStatsFile(Path.GetDirectoryName(Tools.path) + Tools.PATH_DELIMETER + Tools.STATS_LOG_FILENAME);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      int num = (int) new FilesListWindow().ShowDialog();
    }

    private void button2_Click(object sender, EventArgs e)
    {
    }

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams createParams = base.CreateParams;
        createParams.ExStyle |= 33554432;
        return createParams;
      }
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle6 = new DataGridViewCellStyle();
      ComponentResourceManager resources = new ComponentResourceManager(typeof (Implications));
      this.label3 = new Label();
      this.componentsNameList = new ComboBox();
      this.label2 = new Label();
      this.implicationsTextBox = new RichTextBox();
      this.label1 = new Label();
      this.label5 = new Label();
      this.FaultsNamesComboBox = new ComboBox();
      this.label6 = new Label();
      this.affectedComponentsView = new DataGridView();
      this.FaultsHeader = new DataGridViewTextBoxColumn();
      this.implicationsHeader = new DataGridViewTextBoxColumn();
      this.label7 = new Label();
      this.componentDescriptionTextBox = new RichTextBox();
      this.slideMenuTimer = new Timer(this.components);
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.label4 = new Label();
      this.affectingComponentsDataGrid = new DataGridView();
      this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      this.label8 = new Label();
      this.pictureBox2 = new PictureBox();
      this.menuPanel = new MyPanel();
      this.statisticsButton = new Button();
      this.slideMenuButton = new Button();
      this.pictureBox1 = new PictureBox();
      this.addNewComponentButton = new Button();
      this.updateComponentButton = new Button();
      this.advancedSearchButton = new Button();
      this.deleteComponentButton = new Button();
      this.logOutButton = new Button();
      ((ISupportInitialize) this.affectedComponentsView).BeginInit();
      ((ISupportInitialize) this.affectingComponentsDataGrid).BeginInit();
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      this.menuPanel.SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Century Gothic", 21.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.Black;
      this.label3.Location = new Point(807, 121);
      this.label3.Name = "label3";
      this.label3.RightToLeft = RightToLeft.Yes;
      this.label3.Size = new Size(187, 36);
      this.label3.TabIndex = 3;
      this.label3.Text = "נא לבחור רכיב:";
      this.componentsNameList.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.componentsNameList.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.componentsNameList.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.componentsNameList.FormattingEnabled = true;
      this.componentsNameList.Location = new Point(565, 128);
      this.componentsNameList.Name = "componentsNameList";
      this.componentsNameList.RightToLeft = RightToLeft.Yes;
      this.componentsNameList.Size = new Size(236, 29);
      this.componentsNameList.TabIndex = 4;
      this.componentsNameList.SelectedIndexChanged += new EventHandler(this.componentsNameList_SelectedIndexChanged);
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Century Gothic", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(341, 287);
      this.label2.Name = "label2";
      this.label2.RightToLeft = RightToLeft.Yes;
      this.label2.Size = new Size(190, 30);
      this.label2.TabIndex = 5;
      this.label2.Text = "משמעויות התקלה:";
      this.label2.Click += new EventHandler(this.label2_Click);
      this.implicationsTextBox.Font = new Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.implicationsTextBox.Location = new Point(112, 321);
      this.implicationsTextBox.MaxLength = 10000000;
      this.implicationsTextBox.Name = "implicationsTextBox";
      this.implicationsTextBox.ReadOnly = true;
      this.implicationsTextBox.RightToLeft = RightToLeft.Yes;
      this.implicationsTextBox.Size = new Size(414, 112);
      this.implicationsTextBox.TabIndex = 7;
      this.implicationsTextBox.Text = "";
      this.implicationsTextBox.TextChanged += new EventHandler(this.implicationsTextBox_TextChanged);
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Century Gothic", 48f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(407, 9);
      this.label1.Name = "label1";
      this.label1.RightToLeft = RightToLeft.Yes;
      this.label1.Size = new Size(583, 77);
      this.label1.TabIndex = 10;
      this.label1.Text = "משמעויות או לא להיות!\r\n";
      this.label1.Click += new EventHandler(this.label1_Click);
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.Transparent;
      this.label5.Font = new Font("Century Gothic", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.Black;
      this.label5.Location = new Point(850, 166);
      this.label5.Name = "label5";
      this.label5.RightToLeft = RightToLeft.Yes;
      this.label5.Size = new Size(143, 30);
      this.label5.TabIndex = 18;
      this.label5.Text = "בחירת תקלה:";
      this.FaultsNamesComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.FaultsNamesComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.FaultsNamesComboBox.Font = new Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FaultsNamesComboBox.FormattingEnabled = true;
      this.FaultsNamesComboBox.Location = new Point(599, 171);
      this.FaultsNamesComboBox.Name = "FaultsNamesComboBox";
      this.FaultsNamesComboBox.RightToLeft = RightToLeft.Yes;
      this.FaultsNamesComboBox.Size = new Size(245, 25);
      this.FaultsNamesComboBox.TabIndex = 20;
      this.FaultsNamesComboBox.SelectedIndexChanged += new EventHandler(this.faultsNamesComboBox_SelectedIndexChanged);
      this.label6.AutoSize = true;
      this.label6.BackColor = Color.Transparent;
      this.label6.Font = new Font("Century Gothic", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = Color.Black;
      this.label6.Location = new Point(824, 448);
      this.label6.Name = "label6";
      this.label6.RightToLeft = RightToLeft.Yes;
      this.label6.Size = new Size(169, 30);
      this.label6.TabIndex = 21;
      this.label6.Text = "רכיבים משפיעים";
      this.affectedComponentsView.AllowUserToAddRows = false;
      this.affectedComponentsView.AllowUserToDeleteRows = false;
      this.affectedComponentsView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle1.BackColor = SystemColors.Control;
      gridViewCellStyle1.Font = new Font("Century Gothic", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle1.ForeColor = SystemColors.WindowText;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.affectedComponentsView.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.affectedComponentsView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.affectedComponentsView.Columns.AddRange((DataGridViewColumn) this.FaultsHeader, (DataGridViewColumn) this.implicationsHeader);
      this.affectedComponentsView.Location = new Point(112, 484);
      this.affectedComponentsView.MultiSelect = false;
      this.affectedComponentsView.Name = "affectedComponentsView";
      this.affectedComponentsView.RightToLeft = RightToLeft.Yes;
      this.affectedComponentsView.RowHeadersVisible = false;
      this.affectedComponentsView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.affectedComponentsView.Size = new Size(414, 157);
      this.affectedComponentsView.TabIndex = 22;
      this.affectedComponentsView.CellContentClick += new DataGridViewCellEventHandler(this.affectedComponentsView_CellContentClick);
      this.FaultsHeader.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
      gridViewCellStyle2.Font = new Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FaultsHeader.DefaultCellStyle = gridViewCellStyle2;
      this.FaultsHeader.HeaderText = "שם הרכיב";
      this.FaultsHeader.MinimumWidth = 150;
      this.FaultsHeader.Name = "FaultsHeader";
      this.FaultsHeader.Width = 150;
      this.implicationsHeader.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      gridViewCellStyle3.Font = new Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.implicationsHeader.DefaultCellStyle = gridViewCellStyle3;
      this.implicationsHeader.HeaderText = "תיאור הרכיב";
      this.implicationsHeader.Name = "implicationsHeader";
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Century Gothic", 18.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.Black;
      this.label7.Location = new Point(862, 287);
      this.label7.Name = "label7";
      this.label7.RightToLeft = RightToLeft.Yes;
      this.label7.Size = new Size(132, 31);
      this.label7.TabIndex = 23;
      this.label7.Text = "תיאור הרכיב:";
      this.componentDescriptionTextBox.Font = new Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.componentDescriptionTextBox.Location = new Point(574, 321);
      this.componentDescriptionTextBox.MaxLength = 10000000;
      this.componentDescriptionTextBox.Name = "componentDescriptionTextBox";
      this.componentDescriptionTextBox.ReadOnly = true;
      this.componentDescriptionTextBox.RightToLeft = RightToLeft.Yes;
      this.componentDescriptionTextBox.Size = new Size(414, 112);
      this.componentDescriptionTextBox.TabIndex = 24;
      this.componentDescriptionTextBox.Text = "";
      this.slideMenuTimer.Interval = 1;
      this.slideMenuTimer.Tick += new EventHandler(this.slideMenuTimer_Tick);
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(61, 4);
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.Font = new Font("Century Gothic", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.White;
      this.label4.Location = new Point(803, 544);
      this.label4.Name = "label4";
      this.label4.RightToLeft = RightToLeft.Yes;
      this.label4.Size = new Size(0, 30);
      this.label4.TabIndex = 44;
      this.affectingComponentsDataGrid.AllowUserToAddRows = false;
      this.affectingComponentsDataGrid.AllowUserToDeleteRows = false;
      this.affectingComponentsDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
      gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle4.BackColor = SystemColors.Control;
      gridViewCellStyle4.Font = new Font("Century Gothic", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle4.ForeColor = SystemColors.WindowText;
      gridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle4.WrapMode = DataGridViewTriState.True;
      this.affectingComponentsDataGrid.ColumnHeadersDefaultCellStyle = gridViewCellStyle4;
      this.affectingComponentsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.affectingComponentsDataGrid.Columns.AddRange((DataGridViewColumn) this.dataGridViewTextBoxColumn1, (DataGridViewColumn) this.dataGridViewTextBoxColumn2);
      this.affectingComponentsDataGrid.Location = new Point(565, 484);
      this.affectingComponentsDataGrid.MultiSelect = false;
      this.affectingComponentsDataGrid.Name = "affectingComponentsDataGrid";
      this.affectingComponentsDataGrid.RightToLeft = RightToLeft.Yes;
      this.affectingComponentsDataGrid.RowHeadersVisible = false;
      this.affectingComponentsDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.affectingComponentsDataGrid.Size = new Size(423, 157);
      this.affectingComponentsDataGrid.TabIndex = 47;
      this.affectingComponentsDataGrid.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
      this.dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
      gridViewCellStyle5.Font = new Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dataGridViewTextBoxColumn1.DefaultCellStyle = gridViewCellStyle5;
      this.dataGridViewTextBoxColumn1.HeaderText = "שם הרכיב";
      this.dataGridViewTextBoxColumn1.MinimumWidth = 150;
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      this.dataGridViewTextBoxColumn1.Width = 150;
      this.dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      gridViewCellStyle6.Font = new Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dataGridViewTextBoxColumn2.DefaultCellStyle = gridViewCellStyle6;
      this.dataGridViewTextBoxColumn2.HeaderText = "תיאור הרכיב";
      this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
      this.label8.AutoSize = true;
      this.label8.BackColor = Color.Transparent;
      this.label8.Font = new Font("Century Gothic", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.ForeColor = Color.Black;
      this.label8.Location = new Point(357, 448);
      this.label8.Name = "label8";
      this.label8.RightToLeft = RightToLeft.Yes;
      this.label8.Size = new Size(174, 30);
      this.label8.TabIndex = 49;
      this.label8.Text = "רכיבים מושפעים:";
      this.pictureBox2.BackColor = Color.Transparent;
      this.pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
      this.pictureBox2.Image = (Image) resources.GetObject("pictureBox2.Image");
      this.pictureBox2.Location = new Point(43, 59);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(267, 195);
      this.pictureBox2.TabIndex = 46;
      this.pictureBox2.TabStop = false;
      this.menuPanel.BackColor = Color.Transparent;
      this.menuPanel.BackgroundImage = (Image) resources.GetObject("menuPanel.BackgroundImage");
      this.menuPanel.BackgroundImageLayout = ImageLayout.Center;
      this.menuPanel.Controls.Add((Control) this.statisticsButton);
      this.menuPanel.Controls.Add((Control) this.slideMenuButton);
      this.menuPanel.Controls.Add((Control) this.pictureBox1);
      this.menuPanel.Controls.Add((Control) this.addNewComponentButton);
      this.menuPanel.Controls.Add((Control) this.updateComponentButton);
      this.menuPanel.Controls.Add((Control) this.advancedSearchButton);
      this.menuPanel.Controls.Add((Control) this.deleteComponentButton);
      this.menuPanel.Controls.Add((Control) this.logOutButton);
      this.menuPanel.Dock = DockStyle.Right;
      this.menuPanel.ForeColor = Color.Black;
      this.menuPanel.Location = new Point(1040, 0);
      this.menuPanel.Name = "menuPanel";
      this.menuPanel.Size = new Size(44, 661);
      this.menuPanel.TabIndex = 43;
      this.menuPanel.Paint += new PaintEventHandler(this.menuPanel_Paint);
      this.statisticsButton.BackColor = Color.Transparent;
      this.statisticsButton.FlatAppearance.BorderSize = 0;
      this.statisticsButton.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
      this.statisticsButton.FlatStyle = FlatStyle.Flat;
      this.statisticsButton.Font = new Font("Century Gothic", 20.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.statisticsButton.ForeColor = Color.Black;
      this.statisticsButton.Image = (Image) resources.GetObject("statisticsButton.Image");
      this.statisticsButton.ImageAlign = ContentAlignment.MiddleLeft;
      this.statisticsButton.Location = new Point(0, 423);
      this.statisticsButton.Name = "statisticsButton";
      this.statisticsButton.RightToLeft = RightToLeft.No;
      this.statisticsButton.Size = new Size(207, 55);
      this.statisticsButton.TabIndex = 44;
      this.statisticsButton.Text = "סטטיסטיקות";
      this.statisticsButton.TextAlign = ContentAlignment.MiddleRight;
      this.statisticsButton.UseVisualStyleBackColor = false;
      this.statisticsButton.Click += new EventHandler(this.statisticsButton_Click);
      this.slideMenuButton.BackColor = Color.Transparent;
      this.slideMenuButton.BackgroundImageLayout = ImageLayout.None;
      this.slideMenuButton.FlatAppearance.BorderSize = 0;
      this.slideMenuButton.FlatAppearance.MouseOverBackColor = Color.LightGray;
      this.slideMenuButton.FlatStyle = FlatStyle.Flat;
      this.slideMenuButton.Font = new Font("Century Gothic", 20.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.slideMenuButton.ForeColor = Color.Black;
      this.slideMenuButton.Image = (Image) resources.GetObject("slideMenuButton.Image");
      this.slideMenuButton.ImageAlign = ContentAlignment.MiddleLeft;
      this.slideMenuButton.Location = new Point(0, 0);
      this.slideMenuButton.Name = "slideMenuButton";
      this.slideMenuButton.RightToLeft = RightToLeft.No;
      this.slideMenuButton.Size = new Size(200, 48);
      this.slideMenuButton.TabIndex = 43;
      this.slideMenuButton.Text = "תפריט";
      this.slideMenuButton.TextAlign = ContentAlignment.MiddleRight;
      this.slideMenuButton.UseVisualStyleBackColor = false;
      this.slideMenuButton.Click += new EventHandler(this.slideMenuButton_Click);
      this.pictureBox1.BackColor = Color.Transparent;
      this.pictureBox1.BackgroundImage = (Image) resources.GetObject("pictureBox1.BackgroundImage");
      this.pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
      this.pictureBox1.Location = new Point(-17, 70);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(265, 108);
      this.pictureBox1.TabIndex = 42;
      this.pictureBox1.TabStop = false;
      this.addNewComponentButton.BackColor = Color.Transparent;
      this.addNewComponentButton.FlatAppearance.BorderSize = 0;
      this.addNewComponentButton.FlatAppearance.MouseOverBackColor = Color.LightGray;
      this.addNewComponentButton.FlatStyle = FlatStyle.Flat;
      this.addNewComponentButton.Font = new Font("Century Gothic", 20.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.addNewComponentButton.ForeColor = Color.Black;
      this.addNewComponentButton.Image = (Image) resources.GetObject("addNewComponentButton.Image");
      this.addNewComponentButton.ImageAlign = ContentAlignment.MiddleLeft;
      this.addNewComponentButton.Location = new Point(0, 171);
      this.addNewComponentButton.Name = "addNewComponentButton";
      this.addNewComponentButton.RightToLeft = RightToLeft.No;
      this.addNewComponentButton.Size = new Size(200, 55);
      this.addNewComponentButton.TabIndex = 0;
      this.addNewComponentButton.Text = "רכיב חדש";
      this.addNewComponentButton.TextAlign = ContentAlignment.MiddleRight;
      this.addNewComponentButton.UseVisualStyleBackColor = false;
      this.addNewComponentButton.Click += new EventHandler(this.addNewComponentButton_Click);
      this.updateComponentButton.BackColor = Color.Transparent;
      this.updateComponentButton.FlatAppearance.BorderSize = 0;
      this.updateComponentButton.FlatAppearance.MouseOverBackColor = Color.LightGray;
      this.updateComponentButton.FlatStyle = FlatStyle.Flat;
      this.updateComponentButton.Font = new Font("Century Gothic", 20.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.updateComponentButton.ForeColor = Color.Black;
      this.updateComponentButton.Image = (Image) resources.GetObject("updateComponentButton.Image");
      this.updateComponentButton.ImageAlign = ContentAlignment.MiddleLeft;
      this.updateComponentButton.Location = new Point(0, 235);
      this.updateComponentButton.Name = "updateComponentButton";
      this.updateComponentButton.RightToLeft = RightToLeft.No;
      this.updateComponentButton.Size = new Size(200, 55);
      this.updateComponentButton.TabIndex = 1;
      this.updateComponentButton.Text = "עדכון רכיב";
      this.updateComponentButton.TextAlign = ContentAlignment.MiddleRight;
      this.updateComponentButton.UseVisualStyleBackColor = false;
      this.updateComponentButton.Click += new EventHandler(this.updateComponentButton_Click);
      this.advancedSearchButton.BackColor = Color.Transparent;
      this.advancedSearchButton.FlatAppearance.BorderSize = 0;
      this.advancedSearchButton.FlatAppearance.MouseOverBackColor = Color.LightGray;
      this.advancedSearchButton.FlatStyle = FlatStyle.Flat;
      this.advancedSearchButton.Font = new Font("Century Gothic", 20.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.advancedSearchButton.ForeColor = Color.Black;
      this.advancedSearchButton.Image = (Image) resources.GetObject("advancedSearchButton.Image");
      this.advancedSearchButton.ImageAlign = ContentAlignment.MiddleLeft;
      this.advancedSearchButton.Location = new Point(0, 357);
      this.advancedSearchButton.Name = "advancedSearchButton";
      this.advancedSearchButton.RightToLeft = RightToLeft.No;
      this.advancedSearchButton.Size = new Size(207, 55);
      this.advancedSearchButton.TabIndex = 4;
      this.advancedSearchButton.Text = "חיפוש מתקדם";
      this.advancedSearchButton.TextAlign = ContentAlignment.MiddleRight;
      this.advancedSearchButton.UseVisualStyleBackColor = false;
      this.advancedSearchButton.Click += new EventHandler(this.advancedSearchButton_Click);
      this.deleteComponentButton.BackColor = Color.Transparent;
      this.deleteComponentButton.FlatAppearance.BorderSize = 0;
      this.deleteComponentButton.FlatAppearance.MouseOverBackColor = Color.LightGray;
      this.deleteComponentButton.FlatStyle = FlatStyle.Flat;
      this.deleteComponentButton.Font = new Font("Century Gothic", 20.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.deleteComponentButton.ForeColor = Color.Black;
      this.deleteComponentButton.Image = (Image) resources.GetObject("deleteComponentButton.Image");
      this.deleteComponentButton.ImageAlign = ContentAlignment.MiddleLeft;
      this.deleteComponentButton.Location = new Point(0, 296);
      this.deleteComponentButton.Name = "deleteComponentButton";
      this.deleteComponentButton.RightToLeft = RightToLeft.No;
      this.deleteComponentButton.Size = new Size(207, 55);
      this.deleteComponentButton.TabIndex = 3;
      this.deleteComponentButton.Text = "מחיקת רכיב";
      this.deleteComponentButton.TextAlign = ContentAlignment.MiddleRight;
      this.deleteComponentButton.UseVisualStyleBackColor = false;
      this.deleteComponentButton.Click += new EventHandler(this.deleteComponentButton_Click);
      this.logOutButton.BackColor = Color.Transparent;
      this.logOutButton.FlatAppearance.BorderSize = 0;
      this.logOutButton.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
      this.logOutButton.FlatStyle = FlatStyle.Flat;
      this.logOutButton.Font = new Font("Century Gothic", 20.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.logOutButton.ForeColor = Color.Black;
      this.logOutButton.Image = (Image) resources.GetObject("logOutButton.Image");
      this.logOutButton.ImageAlign = ContentAlignment.MiddleLeft;
      this.logOutButton.Location = new Point(0, 484);
      this.logOutButton.Name = "logOutButton";
      this.logOutButton.RightToLeft = RightToLeft.No;
      this.logOutButton.Size = new Size(207, 55);
      this.logOutButton.TabIndex = 2;
      this.logOutButton.Text = "התנתקות";
      this.logOutButton.TextAlign = ContentAlignment.MiddleRight;
      this.logOutButton.UseVisualStyleBackColor = false;
      this.logOutButton.Click += new EventHandler(this.logOutButton_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.BackgroundImage = (Image) resources.GetObject("$this.BackgroundImage");
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(1084, 661);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.pictureBox2);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.menuPanel);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.affectingComponentsDataGrid);
      this.Controls.Add((Control) this.componentDescriptionTextBox);
      this.Controls.Add((Control) this.affectedComponentsView);
      this.Controls.Add((Control) this.FaultsNamesComboBox);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.implicationsTextBox);
      this.Controls.Add((Control) this.componentsNameList);
      this.Controls.Add((Control) this.label3);
      this.DoubleBuffered = true;
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) resources.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.FormClosed += new FormClosedEventHandler(this.Implications_FormClosed);
      this.Load += new EventHandler(this.Implications_Load);
      ((ISupportInitialize) this.affectedComponentsView).EndInit();
      ((ISupportInitialize) this.affectingComponentsDataGrid).EndInit();
      ((ISupportInitialize) this.pictureBox2).EndInit();
      this.menuPanel.ResumeLayout(false);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
