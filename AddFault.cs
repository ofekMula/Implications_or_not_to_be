// Decompiled with JetBrains decompiler
// Type: AlertsProject.AddFault
// Assembly: AlertsProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01CC30A2-D287-482E-A95A-AE835F91B86F
// Assembly location: C:\Users\Ofek Mula\Desktop\AlertsProject.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AlertsProject
{
  public class AddFault : Form
  {
    private IContainer components = (IContainer) null;
    private string newComponentName;
    private int currentSelectedComponent;
    private List<Fault> currentFaultsList;
    private SystemComponent currentAffectedComponent;
    private List<SystemComponent> currentAffectedComponentsList;
    private DataGridView componentsFaultsView;
    private Label label2;
    private Button addAffectedComponentButton;
    private Label label4;
    private ComboBox affectedComponentsNameList;
    private RichTextBox implicationDataRichTextBox;
    private Button addFaultnToComponentButton;
    private Label label10;
    private Label label11;
    private TextBox FaultNameTextBox;
    private Button deleteComponentButton;
    private Button resetListButton;
    private DataGridView affectedComponentsView;
    private DataGridViewTextBoxColumn FaultsHeader;
    private DataGridViewTextBoxColumn implicationsHeader;
    private Button button1;

    public AddFault()
    {
      this.DoubleBuffered = true;
      this.InitializeComponent();
    }

    public AddFault(string newComponentName)
    {
      this.InitializeComponent();
      this.newComponentName = newComponentName;
    }

    public AddFault(List<Fault> currentFaultsList, DataGridView componentsFaultsView)
    {
      this.InitializeComponent();
      this.currentFaultsList = currentFaultsList;
      this.componentsFaultsView = componentsFaultsView;
    }

    private void AddFault_Load(object sender, EventArgs e)
    {
      Tools.updateComboBox(this.affectedComponentsNameList, Tools.componentsList);
      this.currentAffectedComponentsList = new List<SystemComponent>();
    }

    private void addAffectedComponentButton_Click(object sender, EventArgs e)
    {
      int selectedIndex = this.affectedComponentsNameList.SelectedIndex;
      if (this.affectedComponentsNameList.SelectedIndex == -1)
        return;
      this.currentAffectedComponent = Tools.DataBase[selectedIndex];
      if (this.currentAffectedComponentsList == null)
      {
        this.currentAffectedComponentsList = new List<SystemComponent>();
        this.currentAffectedComponentsList.Add(this.currentAffectedComponent);
        Tools.loadListIntoDataGridView(this.currentAffectedComponentsList, this.affectedComponentsView, false);
      }
      else if (Tools.findComponentInListOfComponents(this.currentAffectedComponentsList, this.currentAffectedComponent.getName()) == null)
      {
        this.currentAffectedComponentsList.Add(this.currentAffectedComponent);
        Tools.loadListIntoDataGridView(this.currentAffectedComponentsList, this.affectedComponentsView, false);
      }
      else
      {
        int num = (int) MessageBox.Show(Tools.ALREADY_EXISTS_COMPONENT_ERROR, Tools.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void addFaultnToComponentButton_Click(object sender, EventArgs e)
    {
      if (!Tools.isValidFault(this.currentFaultsList, this.FaultNameTextBox.Text, this.implicationDataRichTextBox.Text, this.currentAffectedComponentsList))
        return;
      this.currentFaultsList.Add(new Fault(this.FaultNameTextBox.Text, this.implicationDataRichTextBox.Text, this.currentAffectedComponentsList));
      Tools.loadFaultsIntoDataGridView(this.currentFaultsList, this.componentsFaultsView, false);
      int num = (int) MessageBox.Show("התקלה נוספה בהצלחה!", Tools.INFORMATION, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      Tools.ResetAllControls((Control) this);
      this.currentAffectedComponentsList = new List<SystemComponent>();
    }

    private void resetListButton_Click(object sender, EventArgs e)
    {
      this.affectedComponentsView.Rows.Clear();
      this.currentAffectedComponentsList = new List<SystemComponent>();
    }

    private void affectedComponentsView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void deleteComponentButton_Click(object sender, EventArgs e)
    {
      this.currentAffectedComponentsList.Remove(Tools.findComponentInListOfComponents(this.currentAffectedComponentsList, (string) this.affectedComponentsView.Rows[this.affectedComponentsView.CurrentCell.RowIndex].Cells[0].Value));
      Tools.loadListIntoDataGridView(this.currentAffectedComponentsList, this.affectedComponentsView, false);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Tools.ResetAllControls((Control) this);
      this.currentAffectedComponentsList = new List<SystemComponent>();
    }

    private void fileListBox1_SelectedIndexChanged(object sender, EventArgs e)
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
      DataGridViewCellStyle gridViewCellStyle = new DataGridViewCellStyle();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AddFault));
      this.label2 = new Label();
      this.addAffectedComponentButton = new Button();
      this.label4 = new Label();
      this.affectedComponentsNameList = new ComboBox();
      this.implicationDataRichTextBox = new RichTextBox();
      this.addFaultnToComponentButton = new Button();
      this.label10 = new Label();
      this.label11 = new Label();
      this.FaultNameTextBox = new TextBox();
      this.deleteComponentButton = new Button();
      this.resetListButton = new Button();
      this.affectedComponentsView = new DataGridView();
      this.FaultsHeader = new DataGridViewTextBoxColumn();
      this.implicationsHeader = new DataGridViewTextBoxColumn();
      this.button1 = new Button();
      ((ISupportInitialize) this.affectedComponentsView).BeginInit();
      this.SuspendLayout();
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Century Gothic", 39.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(437, 9);
      this.label2.Name = "label2";
      this.label2.RightToLeft = RightToLeft.Yes;
      this.label2.Size = new Size(435, 63);
      this.label2.TabIndex = 4;
      this.label2.Text = "הוספת תקלה חדשה";
      this.addAffectedComponentButton.FlatStyle = FlatStyle.System;
      this.addAffectedComponentButton.Font = new Font("Century Gothic", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.addAffectedComponentButton.Location = new Point(384, 342);
      this.addAffectedComponentButton.Name = "addAffectedComponentButton";
      this.addAffectedComponentButton.RightToLeft = RightToLeft.Yes;
      this.addAffectedComponentButton.Size = new Size(69, 24);
      this.addAffectedComponentButton.TabIndex = 42;
      this.addAffectedComponentButton.Text = "הוסף";
      this.addAffectedComponentButton.UseVisualStyleBackColor = true;
      this.addAffectedComponentButton.Click += new EventHandler(this.addAffectedComponentButton_Click);
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.Font = new Font("Century Gothic", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.Black;
      this.label4.Location = new Point(652, 333);
      this.label4.Name = "label4";
      this.label4.RightToLeft = RightToLeft.Yes;
      this.label4.Size = new Size(216, 33);
      this.label4.TabIndex = 41;
      this.label4.Text = "הוספת רכיב מושפע:";
      this.affectedComponentsNameList.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.affectedComponentsNameList.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.affectedComponentsNameList.Font = new Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.affectedComponentsNameList.FormattingEnabled = true;
      this.affectedComponentsNameList.Location = new Point(459, 342);
      this.affectedComponentsNameList.Name = "affectedComponentsNameList";
      this.affectedComponentsNameList.RightToLeft = RightToLeft.Yes;
      this.affectedComponentsNameList.Size = new Size(194, 25);
      this.affectedComponentsNameList.TabIndex = 39;
      this.implicationDataRichTextBox.Font = new Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.implicationDataRichTextBox.Location = new Point(507, 233);
      this.implicationDataRichTextBox.Name = "implicationDataRichTextBox";
      this.implicationDataRichTextBox.RightToLeft = RightToLeft.Yes;
      this.implicationDataRichTextBox.Size = new Size(354, 73);
      this.implicationDataRichTextBox.TabIndex = 29;
      this.implicationDataRichTextBox.Text = "";
      this.addFaultnToComponentButton.FlatStyle = FlatStyle.System;
      this.addFaultnToComponentButton.Font = new Font("Century Gothic", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.addFaultnToComponentButton.ForeColor = Color.White;
      this.addFaultnToComponentButton.Location = new Point(12, 477);
      this.addFaultnToComponentButton.Name = "addFaultnToComponentButton";
      this.addFaultnToComponentButton.RightToLeft = RightToLeft.Yes;
      this.addFaultnToComponentButton.Size = new Size(170, 70);
      this.addFaultnToComponentButton.TabIndex = 33;
      this.addFaultnToComponentButton.Text = "הוספת תקלה לרכיב";
      this.addFaultnToComponentButton.UseVisualStyleBackColor = true;
      this.addFaultnToComponentButton.Click += new EventHandler(this.addFaultnToComponentButton_Click);
      this.label10.AutoSize = true;
      this.label10.BackColor = Color.Transparent;
      this.label10.Font = new Font("Century Gothic", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label10.ForeColor = Color.Black;
      this.label10.Location = new Point(731, 129);
      this.label10.Name = "label10";
      this.label10.RightToLeft = RightToLeft.Yes;
      this.label10.Size = new Size(136, 33);
      this.label10.TabIndex = 30;
      this.label10.Text = "שם התקלה:";
      this.label11.AutoSize = true;
      this.label11.BackColor = Color.Transparent;
      this.label11.Font = new Font("Century Gothic", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label11.ForeColor = Color.Black;
      this.label11.Location = new Point(661, 186);
      this.label11.Name = "label11";
      this.label11.RightToLeft = RightToLeft.Yes;
      this.label11.Size = new Size(206, 33);
      this.label11.TabIndex = 31;
      this.label11.Text = "מה הן המשמעויות?";
      this.FaultNameTextBox.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 177);
      this.FaultNameTextBox.Location = new Point(536, 136);
      this.FaultNameTextBox.MaxLength = 3000;
      this.FaultNameTextBox.Name = "FaultNameTextBox";
      this.FaultNameTextBox.RightToLeft = RightToLeft.Yes;
      this.FaultNameTextBox.Size = new Size(189, 26);
      this.FaultNameTextBox.TabIndex = 32;
      this.deleteComponentButton.FlatStyle = FlatStyle.System;
      this.deleteComponentButton.Font = new Font("Century Gothic", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.deleteComponentButton.Location = new Point(289, 477);
      this.deleteComponentButton.Name = "deleteComponentButton";
      this.deleteComponentButton.RightToLeft = RightToLeft.Yes;
      this.deleteComponentButton.Size = new Size(95, 48);
      this.deleteComponentButton.TabIndex = 44;
      this.deleteComponentButton.Text = "מחיקת רכיב מהרשימה";
      this.deleteComponentButton.UseVisualStyleBackColor = true;
      this.deleteComponentButton.Click += new EventHandler(this.deleteComponentButton_Click);
      this.resetListButton.FlatStyle = FlatStyle.System;
      this.resetListButton.Font = new Font("Century Gothic", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.resetListButton.Location = new Point(289, 423);
      this.resetListButton.Name = "resetListButton";
      this.resetListButton.RightToLeft = RightToLeft.Yes;
      this.resetListButton.Size = new Size(94, 48);
      this.resetListButton.TabIndex = 43;
      this.resetListButton.Text = "איפוס רכיבים מושפעים";
      this.resetListButton.UseVisualStyleBackColor = true;
      this.resetListButton.Click += new EventHandler(this.resetListButton_Click);
      this.affectedComponentsView.AllowUserToAddRows = false;
      this.affectedComponentsView.AllowUserToDeleteRows = false;
      this.affectedComponentsView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
      gridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle.BackColor = SystemColors.Control;
      gridViewCellStyle.Font = new Font("Century Gothic", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle.ForeColor = SystemColors.WindowText;
      gridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle.WrapMode = DataGridViewTriState.True;
      this.affectedComponentsView.ColumnHeadersDefaultCellStyle = gridViewCellStyle;
      this.affectedComponentsView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.affectedComponentsView.Columns.AddRange((DataGridViewColumn) this.FaultsHeader, (DataGridViewColumn) this.implicationsHeader);
      this.affectedComponentsView.Location = new Point(390, 389);
      this.affectedComponentsView.MultiSelect = false;
      this.affectedComponentsView.Name = "affectedComponentsView";
      this.affectedComponentsView.RightToLeft = RightToLeft.Yes;
      this.affectedComponentsView.RowHeadersVisible = false;
      this.affectedComponentsView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.affectedComponentsView.Size = new Size(471, 138);
      this.affectedComponentsView.TabIndex = 53;
      this.affectedComponentsView.CellContentClick += new DataGridViewCellEventHandler(this.affectedComponentsView_CellContentClick);
      this.FaultsHeader.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
      this.FaultsHeader.HeaderText = "שם הרכיב";
      this.FaultsHeader.MinimumWidth = 150;
      this.FaultsHeader.Name = "FaultsHeader";
      this.FaultsHeader.Width = 150;
      this.implicationsHeader.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.implicationsHeader.HeaderText = "תיאור הרכיב";
      this.implicationsHeader.Name = "implicationsHeader";
      this.button1.BackColor = Color.Transparent;
      this.button1.BackgroundImageLayout = ImageLayout.Center;
      this.button1.FlatStyle = FlatStyle.System;
      this.button1.Font = new Font("Century Gothic", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.button1.ForeColor = Color.White;
      this.button1.Location = new Point(12, 426);
      this.button1.Name = "button1";
      this.button1.Size = new Size(170, 45);
      this.button1.TabIndex = 54;
      this.button1.Text = "ניקוי שדות";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.AcceptButton = (IButtonControl) this.addFaultnToComponentButton;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) componentResourceManager.GetObject("$this.BackgroundImage");
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(884, 561);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.affectedComponentsView);
      this.Controls.Add((Control) this.deleteComponentButton);
      this.Controls.Add((Control) this.resetListButton);
      this.Controls.Add((Control) this.addAffectedComponentButton);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.affectedComponentsNameList);
      this.Controls.Add((Control) this.implicationDataRichTextBox);
      this.Controls.Add((Control) this.addFaultnToComponentButton);
      this.Controls.Add((Control) this.label10);
      this.Controls.Add((Control) this.label11);
      this.Controls.Add((Control) this.FaultNameTextBox);
      this.Controls.Add((Control) this.label2);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = nameof (AddFault);
      this.Text = nameof (AddFault);
      this.Load += new EventHandler(this.AddFault_Load);
      ((ISupportInitialize) this.affectedComponentsView).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
