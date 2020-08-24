
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
    private int stepSize = 25;
    //private int currentSelectIndex = -1;
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
    private Timer slideMenuTimer;
    private ContextMenuStrip contextMenuStrip1;
    private Button statisticsButton;
    private Label label4;

    private DataGridView affectingComponentsDataGrid;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private Label label8;
        private Label label9;
        private RichTextBox solutionTextBox;
        private Button addNewFaultButton;
        private Button usersButton;
        private PictureBox pictureBox1;
        private PictureBox componentImage;

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
            this.componentsNameList.SelectedIndex = -1;
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
                if (this.selectedComponent != null)
                {
                    if (this.selectedComponent.getImage() != null)
                    {
                        this.componentImage.Load(this.selectedComponent.getImage());
                        this.componentImage.SizeMode = PictureBoxSizeMode.StretchImage;
                        
                    }
                    else
                    {
                        this.componentImage.Image = null;
                    }
                }
                else
                {
                    this.componentImage.Image=null;
                }
              
                if (faultsList == null)
          return;
        List<string> componentsNamesList = new List<string>();
        List<SystemComponent> list = new List<SystemComponent>();
        if (faultsList.Count > 0)
        {
          Tools.updateComboBox(this.FaultsNamesComboBox, Tools.createFaultsNamesList(faultsList));
          this.implicationsTextBox.Text = Tools.DEAFULT_IMPLICATION;
          this.solutionTextBox.Text = Tools.DEAFULT_IMPLICATION;
          Tools.loadListIntoDataGridView(list, this.affectedComponentsView, false);
        }
        else
        {
          this.implicationsTextBox.Text = Tools.NO_FAULTS_IMPLICATION;
          this.solutionTextBox.Text=Tools.NO_FAULTS_IMPLICATION;
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
            this.solutionTextBox.Text = faultsList[selectedFaultIndex].getSolution();
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Implications));
            this.label3 = new System.Windows.Forms.Label();
            this.componentsNameList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.implicationsTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FaultsNamesComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.affectedComponentsView = new System.Windows.Forms.DataGridView();
            this.FaultsHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.implicationsHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.componentDescriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.slideMenuTimer = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.affectingComponentsDataGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.componentImage = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.solutionTextBox = new System.Windows.Forms.RichTextBox();
            this.addNewFaultButton = new System.Windows.Forms.Button();
            this.menuPanel = new AlertsProject.MyPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.usersButton = new System.Windows.Forms.Button();
            this.statisticsButton = new System.Windows.Forms.Button();
            this.slideMenuButton = new System.Windows.Forms.Button();
            this.addNewComponentButton = new System.Windows.Forms.Button();
            this.updateComponentButton = new System.Windows.Forms.Button();
            this.advancedSearchButton = new System.Windows.Forms.Button();
            this.deleteComponentButton = new System.Windows.Forms.Button();
            this.logOutButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.affectedComponentsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.affectingComponentsDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.componentImage)).BeginInit();
            this.menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1212, 164);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(267, 51);
            this.label3.TabIndex = 3;
            this.label3.Text = "נא לבחור רכיב:";
            // 
            // componentsNameList
            // 
            this.componentsNameList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.componentsNameList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.componentsNameList.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.componentsNameList.FormattingEnabled = true;
            this.componentsNameList.Location = new System.Drawing.Point(850, 177);
            this.componentsNameList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.componentsNameList.Name = "componentsNameList";
            this.componentsNameList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.componentsNameList.Size = new System.Drawing.Size(352, 38);
            this.componentsNameList.TabIndex = 1;
            this.componentsNameList.SelectedIndexChanged += new System.EventHandler(this.componentsNameList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1210, 525);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(268, 43);
            this.label2.TabIndex = 5;
            this.label2.Text = "משמעויות התקלה:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // implicationsTextBox
            // 
            this.implicationsTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.implicationsTextBox.Location = new System.Drawing.Point(888, 573);
            this.implicationsTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.implicationsTextBox.MaxLength = 10000000;
            this.implicationsTextBox.Name = "implicationsTextBox";
            this.implicationsTextBox.ReadOnly = true;
            this.implicationsTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.implicationsTextBox.Size = new System.Drawing.Size(582, 131);
            this.implicationsTextBox.TabIndex = 7;
            this.implicationsTextBox.Text = "";
            this.implicationsTextBox.TextChanged += new System.EventHandler(this.implicationsTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(612, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(889, 112);
            this.label1.TabIndex = 10;
            this.label1.Text = "משמעויות או לא להיות!\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(1268, 438);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(210, 43);
            this.label5.TabIndex = 18;
            this.label5.Text = "בחירת תקלה:";
            // 
            // FaultsNamesComboBox
            // 
            this.FaultsNamesComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.FaultsNamesComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.FaultsNamesComboBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FaultsNamesComboBox.FormattingEnabled = true;
            this.FaultsNamesComboBox.Location = new System.Drawing.Point(899, 451);
            this.FaultsNamesComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FaultsNamesComboBox.Name = "FaultsNamesComboBox";
            this.FaultsNamesComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FaultsNamesComboBox.Size = new System.Drawing.Size(366, 31);
            this.FaultsNamesComboBox.TabIndex = 2;
            this.FaultsNamesComboBox.SelectedIndexChanged += new System.EventHandler(this.faultsNamesComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(1239, 729);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(239, 43);
            this.label6.TabIndex = 21;
            this.label6.Text = "רכיבים משפיעים";
            // 
            // affectedComponentsView
            // 
            this.affectedComponentsView.AllowUserToAddRows = false;
            this.affectedComponentsView.AllowUserToDeleteRows = false;
            this.affectedComponentsView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.affectedComponentsView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.affectedComponentsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.affectedComponentsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FaultsHeader,
            this.implicationsHeader});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.affectedComponentsView.DefaultCellStyle = dataGridViewCellStyle4;
            this.affectedComponentsView.Location = new System.Drawing.Point(188, 775);
            this.affectedComponentsView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.affectedComponentsView.MultiSelect = false;
            this.affectedComponentsView.Name = "affectedComponentsView";
            this.affectedComponentsView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.affectedComponentsView.RowHeadersVisible = false;
            this.affectedComponentsView.RowHeadersWidth = 62;
            this.affectedComponentsView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.affectedComponentsView.Size = new System.Drawing.Size(608, 213);
            this.affectedComponentsView.TabIndex = 22;
            this.affectedComponentsView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.affectedComponentsView_CellContentClick);
            // 
            // FaultsHeader
            // 
            this.FaultsHeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FaultsHeader.DefaultCellStyle = dataGridViewCellStyle2;
            this.FaultsHeader.HeaderText = "שם הרכיב";
            this.FaultsHeader.MinimumWidth = 150;
            this.FaultsHeader.Name = "FaultsHeader";
            this.FaultsHeader.Width = 150;
            // 
            // implicationsHeader
            // 
            this.implicationsHeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.implicationsHeader.DefaultCellStyle = dataGridViewCellStyle3;
            this.implicationsHeader.HeaderText = "תיאור הרכיב";
            this.implicationsHeader.MinimumWidth = 8;
            this.implicationsHeader.Name = "implicationsHeader";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(1275, 234);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(203, 45);
            this.label7.TabIndex = 23;
            this.label7.Text = "תיאור הרכיב:";
            // 
            // componentDescriptionTextBox
            // 
            this.componentDescriptionTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.componentDescriptionTextBox.Location = new System.Drawing.Point(851, 284);
            this.componentDescriptionTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.componentDescriptionTextBox.MaxLength = 10000000;
            this.componentDescriptionTextBox.Name = "componentDescriptionTextBox";
            this.componentDescriptionTextBox.ReadOnly = true;
            this.componentDescriptionTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.componentDescriptionTextBox.Size = new System.Drawing.Size(619, 132);
            this.componentDescriptionTextBox.TabIndex = 24;
            this.componentDescriptionTextBox.Text = "";
            // 
            // slideMenuTimer
            // 
            this.slideMenuTimer.Interval = 1;
            this.slideMenuTimer.Tick += new System.EventHandler(this.slideMenuTimer_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1206, 838);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(0, 43);
            this.label4.TabIndex = 44;
            // 
            // affectingComponentsDataGrid
            // 
            this.affectingComponentsDataGrid.AllowUserToAddRows = false;
            this.affectingComponentsDataGrid.AllowUserToDeleteRows = false;
            this.affectingComponentsDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.affectingComponentsDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.affectingComponentsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.affectingComponentsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.affectingComponentsDataGrid.DefaultCellStyle = dataGridViewCellStyle8;
            this.affectingComponentsDataGrid.Location = new System.Drawing.Point(888, 777);
            this.affectingComponentsDataGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.affectingComponentsDataGrid.MultiSelect = false;
            this.affectingComponentsDataGrid.Name = "affectingComponentsDataGrid";
            this.affectingComponentsDataGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.affectingComponentsDataGrid.RowHeadersVisible = false;
            this.affectingComponentsDataGrid.RowHeadersWidth = 62;
            this.affectingComponentsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.affectingComponentsDataGrid.Size = new System.Drawing.Size(582, 211);
            this.affectingComponentsDataGrid.TabIndex = 47;
            this.affectingComponentsDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.HeaderText = "שם הרכיב";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn2.HeaderText = "תיאור הרכיב";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(558, 729);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(246, 43);
            this.label8.TabIndex = 49;
            this.label8.Text = "רכיבים מושפעים:";
            // 
            // componentImage
            // 
            this.componentImage.BackColor = System.Drawing.Color.Transparent;
            this.componentImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.componentImage.ErrorImage = null;
            this.componentImage.ImageLocation = "center";
            this.componentImage.InitialImage = null;
            this.componentImage.Location = new System.Drawing.Point(428, 164);
            this.componentImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.componentImage.Name = "componentImage";
            this.componentImage.Size = new System.Drawing.Size(324, 225);
            this.componentImage.TabIndex = 46;
            this.componentImage.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(592, 525);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(212, 43);
            this.label9.TabIndex = 50;
            this.label9.Text = "פתרון התקלה:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // solutionTextBox
            // 
            this.solutionTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solutionTextBox.Location = new System.Drawing.Point(218, 573);
            this.solutionTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.solutionTextBox.MaxLength = 10000000;
            this.solutionTextBox.Name = "solutionTextBox";
            this.solutionTextBox.ReadOnly = true;
            this.solutionTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.solutionTextBox.Size = new System.Drawing.Size(578, 131);
            this.solutionTextBox.TabIndex = 51;
            this.solutionTextBox.Text = "";
            // 
            // addNewFaultButton
            // 
            this.addNewFaultButton.BackColor = System.Drawing.Color.Transparent;
            this.addNewFaultButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.addNewFaultButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addNewFaultButton.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewFaultButton.ForeColor = System.Drawing.Color.White;
            this.addNewFaultButton.Location = new System.Drawing.Point(715, 451);
            this.addNewFaultButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addNewFaultButton.Name = "addNewFaultButton";
            this.addNewFaultButton.Size = new System.Drawing.Size(166, 66);
            this.addNewFaultButton.TabIndex = 3;
            this.addNewFaultButton.Text = "דיווח תקלה במייל";
            this.addNewFaultButton.UseVisualStyleBackColor = false;
            this.addNewFaultButton.Click += new System.EventHandler(this.addNewFaultButton_Click);
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.White;
            this.menuPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuPanel.BackgroundImage")));
            this.menuPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuPanel.Controls.Add(this.pictureBox1);
            this.menuPanel.Controls.Add(this.usersButton);
            this.menuPanel.Controls.Add(this.statisticsButton);
            this.menuPanel.Controls.Add(this.slideMenuButton);
            this.menuPanel.Controls.Add(this.addNewComponentButton);
            this.menuPanel.Controls.Add(this.updateComponentButton);
            this.menuPanel.Controls.Add(this.advancedSearchButton);
            this.menuPanel.Controls.Add(this.deleteComponentButton);
            this.menuPanel.Controls.Add(this.logOutButton);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.menuPanel.ForeColor = System.Drawing.Color.Black;
            this.menuPanel.Location = new System.Drawing.Point(1623, 0);
            this.menuPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(55, 1017);
            this.menuPanel.TabIndex = 43;
            this.menuPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.menuPanel_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 74);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 169);
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // usersButton
            // 
            this.usersButton.BackColor = System.Drawing.Color.Transparent;
            this.usersButton.FlatAppearance.BorderSize = 0;
            this.usersButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.usersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.usersButton.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersButton.ForeColor = System.Drawing.Color.Black;
            this.usersButton.Image = ((System.Drawing.Image)(resources.GetObject("usersButton.Image")));
            this.usersButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.usersButton.Location = new System.Drawing.Point(0, 742);
            this.usersButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.usersButton.Name = "usersButton";
            this.usersButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.usersButton.Size = new System.Drawing.Size(310, 85);
            this.usersButton.TabIndex = 45;
            this.usersButton.Text = "משתמשים";
            this.usersButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.usersButton.UseVisualStyleBackColor = false;
            this.usersButton.Click += new System.EventHandler(this.usersButton_Click);
            // 
            // statisticsButton
            // 
            this.statisticsButton.BackColor = System.Drawing.Color.Transparent;
            this.statisticsButton.FlatAppearance.BorderSize = 0;
            this.statisticsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.statisticsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statisticsButton.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statisticsButton.ForeColor = System.Drawing.Color.Black;
            this.statisticsButton.Image = ((System.Drawing.Image)(resources.GetObject("statisticsButton.Image")));
            this.statisticsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statisticsButton.Location = new System.Drawing.Point(0, 651);
            this.statisticsButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statisticsButton.Size = new System.Drawing.Size(310, 85);
            this.statisticsButton.TabIndex = 44;
            this.statisticsButton.Text = "סטטיסטיקות";
            this.statisticsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.statisticsButton.UseVisualStyleBackColor = false;
            this.statisticsButton.Click += new System.EventHandler(this.statisticsButton_Click);
            // 
            // slideMenuButton
            // 
            this.slideMenuButton.BackColor = System.Drawing.Color.Transparent;
            this.slideMenuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.slideMenuButton.FlatAppearance.BorderSize = 0;
            this.slideMenuButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.slideMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.slideMenuButton.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slideMenuButton.ForeColor = System.Drawing.Color.Black;
            this.slideMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("slideMenuButton.Image")));
            this.slideMenuButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.slideMenuButton.Location = new System.Drawing.Point(0, 0);
            this.slideMenuButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.slideMenuButton.Name = "slideMenuButton";
            this.slideMenuButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.slideMenuButton.Size = new System.Drawing.Size(300, 74);
            this.slideMenuButton.TabIndex = 43;
            this.slideMenuButton.Text = "תפריט";
            this.slideMenuButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.slideMenuButton.UseVisualStyleBackColor = false;
            this.slideMenuButton.Click += new System.EventHandler(this.slideMenuButton_Click);
            // 
            // addNewComponentButton
            // 
            this.addNewComponentButton.BackColor = System.Drawing.Color.Transparent;
            this.addNewComponentButton.FlatAppearance.BorderSize = 0;
            this.addNewComponentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.addNewComponentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addNewComponentButton.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewComponentButton.ForeColor = System.Drawing.Color.Black;
            this.addNewComponentButton.Image = ((System.Drawing.Image)(resources.GetObject("addNewComponentButton.Image")));
            this.addNewComponentButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addNewComponentButton.Location = new System.Drawing.Point(0, 263);
            this.addNewComponentButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addNewComponentButton.Name = "addNewComponentButton";
            this.addNewComponentButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.addNewComponentButton.Size = new System.Drawing.Size(300, 85);
            this.addNewComponentButton.TabIndex = 0;
            this.addNewComponentButton.Text = "רכיב חדש";
            this.addNewComponentButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addNewComponentButton.UseVisualStyleBackColor = false;
            this.addNewComponentButton.Click += new System.EventHandler(this.addNewComponentButton_Click);
            // 
            // updateComponentButton
            // 
            this.updateComponentButton.BackColor = System.Drawing.Color.Transparent;
            this.updateComponentButton.FlatAppearance.BorderSize = 0;
            this.updateComponentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.updateComponentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateComponentButton.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateComponentButton.ForeColor = System.Drawing.Color.Black;
            this.updateComponentButton.Image = ((System.Drawing.Image)(resources.GetObject("updateComponentButton.Image")));
            this.updateComponentButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.updateComponentButton.Location = new System.Drawing.Point(0, 362);
            this.updateComponentButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.updateComponentButton.Name = "updateComponentButton";
            this.updateComponentButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.updateComponentButton.Size = new System.Drawing.Size(300, 85);
            this.updateComponentButton.TabIndex = 1;
            this.updateComponentButton.Text = "עדכון רכיב";
            this.updateComponentButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.updateComponentButton.UseVisualStyleBackColor = false;
            this.updateComponentButton.Click += new System.EventHandler(this.updateComponentButton_Click);
            // 
            // advancedSearchButton
            // 
            this.advancedSearchButton.BackColor = System.Drawing.Color.Transparent;
            this.advancedSearchButton.FlatAppearance.BorderSize = 0;
            this.advancedSearchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.advancedSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.advancedSearchButton.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advancedSearchButton.ForeColor = System.Drawing.Color.Black;
            this.advancedSearchButton.Image = ((System.Drawing.Image)(resources.GetObject("advancedSearchButton.Image")));
            this.advancedSearchButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.advancedSearchButton.Location = new System.Drawing.Point(0, 549);
            this.advancedSearchButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.advancedSearchButton.Name = "advancedSearchButton";
            this.advancedSearchButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedSearchButton.Size = new System.Drawing.Size(310, 85);
            this.advancedSearchButton.TabIndex = 4;
            this.advancedSearchButton.Text = "חיפוש מתקדם";
            this.advancedSearchButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.advancedSearchButton.UseVisualStyleBackColor = false;
            this.advancedSearchButton.Click += new System.EventHandler(this.advancedSearchButton_Click);
            // 
            // deleteComponentButton
            // 
            this.deleteComponentButton.BackColor = System.Drawing.Color.Transparent;
            this.deleteComponentButton.FlatAppearance.BorderSize = 0;
            this.deleteComponentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.deleteComponentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteComponentButton.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteComponentButton.ForeColor = System.Drawing.Color.Black;
            this.deleteComponentButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteComponentButton.Image")));
            this.deleteComponentButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteComponentButton.Location = new System.Drawing.Point(0, 455);
            this.deleteComponentButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deleteComponentButton.Name = "deleteComponentButton";
            this.deleteComponentButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.deleteComponentButton.Size = new System.Drawing.Size(310, 85);
            this.deleteComponentButton.TabIndex = 3;
            this.deleteComponentButton.Text = "מחיקת רכיב";
            this.deleteComponentButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteComponentButton.UseVisualStyleBackColor = false;
            this.deleteComponentButton.Click += new System.EventHandler(this.deleteComponentButton_Click);
            // 
            // logOutButton
            // 
            this.logOutButton.BackColor = System.Drawing.Color.Transparent;
            this.logOutButton.FlatAppearance.BorderSize = 0;
            this.logOutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.logOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logOutButton.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutButton.ForeColor = System.Drawing.Color.Black;
            this.logOutButton.Image = ((System.Drawing.Image)(resources.GetObject("logOutButton.Image")));
            this.logOutButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logOutButton.Location = new System.Drawing.Point(0, 837);
            this.logOutButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.logOutButton.Size = new System.Drawing.Size(310, 85);
            this.logOutButton.TabIndex = 2;
            this.logOutButton.Text = "התנתקות";
            this.logOutButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.logOutButton.UseVisualStyleBackColor = false;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // Implications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1678, 1017);
            this.Controls.Add(this.addNewFaultButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.solutionTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.componentImage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.affectingComponentsDataGrid);
            this.Controls.Add(this.componentDescriptionTextBox);
            this.Controls.Add(this.affectedComponentsView);
            this.Controls.Add(this.FaultsNamesComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.implicationsTextBox);
            this.Controls.Add(this.componentsNameList);
            this.Controls.Add(this.label3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Implications";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Implications_FormClosed);
            this.Load += new System.EventHandler(this.Implications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.affectedComponentsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.affectingComponentsDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.componentImage)).EndInit();
            this.menuPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

        private void addNewFaultButton_Click(object sender, EventArgs e)
        {
            if (FaultsNamesComboBox.SelectedIndex != -1)
            {
                int num = (int)new ReportWindow(this.componentsNameList.SelectedItem.ToString()
                    ,this.FaultsNamesComboBox.SelectedItem.ToString(),
                    this.implicationsTextBox.Text).ShowDialog();
            }
            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void usersButton_Click(object sender, EventArgs e)
        {
            int num = (int)new UserWindow().ShowDialog();
        }
    }
}
