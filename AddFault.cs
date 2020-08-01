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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFault));
            this.label2 = new System.Windows.Forms.Label();
            this.addAffectedComponentButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.affectedComponentsNameList = new System.Windows.Forms.ComboBox();
            this.implicationDataRichTextBox = new System.Windows.Forms.RichTextBox();
            this.addFaultnToComponentButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.FaultNameTextBox = new System.Windows.Forms.TextBox();
            this.deleteComponentButton = new System.Windows.Forms.Button();
            this.resetListButton = new System.Windows.Forms.Button();
            this.affectedComponentsView = new System.Windows.Forms.DataGridView();
            this.FaultsHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.implicationsHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.affectedComponentsView)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(656, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(670, 93);
            this.label2.TabIndex = 4;
            this.label2.Text = "הוספת תקלה חדשה";
            // 
            // addAffectedComponentButton
            // 
            this.addAffectedComponentButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addAffectedComponentButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAffectedComponentButton.Location = new System.Drawing.Point(576, 526);
            this.addAffectedComponentButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addAffectedComponentButton.Name = "addAffectedComponentButton";
            this.addAffectedComponentButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.addAffectedComponentButton.Size = new System.Drawing.Size(104, 37);
            this.addAffectedComponentButton.TabIndex = 42;
            this.addAffectedComponentButton.Text = "הוסף";
            this.addAffectedComponentButton.UseVisualStyleBackColor = true;
            this.addAffectedComponentButton.Click += new System.EventHandler(this.addAffectedComponentButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(978, 512);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(307, 50);
            this.label4.TabIndex = 41;
            this.label4.Text = "הוספת רכיב מושפע:";
            // 
            // affectedComponentsNameList
            // 
            this.affectedComponentsNameList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.affectedComponentsNameList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.affectedComponentsNameList.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.affectedComponentsNameList.FormattingEnabled = true;
            this.affectedComponentsNameList.Location = new System.Drawing.Point(688, 526);
            this.affectedComponentsNameList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.affectedComponentsNameList.Name = "affectedComponentsNameList";
            this.affectedComponentsNameList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.affectedComponentsNameList.Size = new System.Drawing.Size(289, 31);
            this.affectedComponentsNameList.TabIndex = 39;
            // 
            // implicationDataRichTextBox
            // 
            this.implicationDataRichTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.implicationDataRichTextBox.Location = new System.Drawing.Point(760, 358);
            this.implicationDataRichTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.implicationDataRichTextBox.Name = "implicationDataRichTextBox";
            this.implicationDataRichTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.implicationDataRichTextBox.Size = new System.Drawing.Size(529, 110);
            this.implicationDataRichTextBox.TabIndex = 29;
            this.implicationDataRichTextBox.Text = "";
            // 
            // addFaultnToComponentButton
            // 
            this.addFaultnToComponentButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addFaultnToComponentButton.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addFaultnToComponentButton.ForeColor = System.Drawing.Color.White;
            this.addFaultnToComponentButton.Location = new System.Drawing.Point(18, 734);
            this.addFaultnToComponentButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addFaultnToComponentButton.Name = "addFaultnToComponentButton";
            this.addFaultnToComponentButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.addFaultnToComponentButton.Size = new System.Drawing.Size(255, 108);
            this.addFaultnToComponentButton.TabIndex = 33;
            this.addFaultnToComponentButton.Text = "הוספת תקלה לרכיב";
            this.addFaultnToComponentButton.UseVisualStyleBackColor = true;
            this.addFaultnToComponentButton.Click += new System.EventHandler(this.addFaultnToComponentButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(1096, 198);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(194, 50);
            this.label10.TabIndex = 30;
            this.label10.Text = "שם התקלה:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(992, 286);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(293, 50);
            this.label11.TabIndex = 31;
            this.label11.Text = "מה הן המשמעויות?";
            // 
            // FaultNameTextBox
            // 
            this.FaultNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FaultNameTextBox.Location = new System.Drawing.Point(804, 209);
            this.FaultNameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FaultNameTextBox.MaxLength = 3000;
            this.FaultNameTextBox.Name = "FaultNameTextBox";
            this.FaultNameTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FaultNameTextBox.Size = new System.Drawing.Size(282, 35);
            this.FaultNameTextBox.TabIndex = 32;
            // 
            // deleteComponentButton
            // 
            this.deleteComponentButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.deleteComponentButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteComponentButton.Location = new System.Drawing.Point(434, 734);
            this.deleteComponentButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deleteComponentButton.Name = "deleteComponentButton";
            this.deleteComponentButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.deleteComponentButton.Size = new System.Drawing.Size(142, 74);
            this.deleteComponentButton.TabIndex = 44;
            this.deleteComponentButton.Text = "מחיקת רכיב מהרשימה";
            this.deleteComponentButton.UseVisualStyleBackColor = true;
            this.deleteComponentButton.Click += new System.EventHandler(this.deleteComponentButton_Click);
            // 
            // resetListButton
            // 
            this.resetListButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.resetListButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetListButton.Location = new System.Drawing.Point(434, 651);
            this.resetListButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.resetListButton.Name = "resetListButton";
            this.resetListButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.resetListButton.Size = new System.Drawing.Size(141, 74);
            this.resetListButton.TabIndex = 43;
            this.resetListButton.Text = "איפוס רכיבים מושפעים";
            this.resetListButton.UseVisualStyleBackColor = true;
            this.resetListButton.Click += new System.EventHandler(this.resetListButton_Click);
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
            this.affectedComponentsView.Location = new System.Drawing.Point(585, 598);
            this.affectedComponentsView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.affectedComponentsView.MultiSelect = false;
            this.affectedComponentsView.Name = "affectedComponentsView";
            this.affectedComponentsView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.affectedComponentsView.RowHeadersVisible = false;
            this.affectedComponentsView.RowHeadersWidth = 62;
            this.affectedComponentsView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.affectedComponentsView.Size = new System.Drawing.Size(706, 212);
            this.affectedComponentsView.TabIndex = 53;
            this.affectedComponentsView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.affectedComponentsView_CellContentClick);
            // 
            // FaultsHeader
            // 
            this.FaultsHeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FaultsHeader.HeaderText = "שם הרכיב";
            this.FaultsHeader.MinimumWidth = 150;
            this.FaultsHeader.Name = "FaultsHeader";
            this.FaultsHeader.Width = 150;
            // 
            // implicationsHeader
            // 
            this.implicationsHeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.implicationsHeader.HeaderText = "תיאור הרכיב";
            this.implicationsHeader.MinimumWidth = 8;
            this.implicationsHeader.Name = "implicationsHeader";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(18, 655);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(255, 69);
            this.button1.TabIndex = 54;
            this.button1.Text = "ניקוי שדות";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddFault
            // 
            this.AcceptButton = this.addFaultnToComponentButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1326, 863);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.affectedComponentsView);
            this.Controls.Add(this.deleteComponentButton);
            this.Controls.Add(this.resetListButton);
            this.Controls.Add(this.addAffectedComponentButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.affectedComponentsNameList);
            this.Controls.Add(this.implicationDataRichTextBox);
            this.Controls.Add(this.addFaultnToComponentButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.FaultNameTextBox);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "AddFault";
            this.Load += new System.EventHandler(this.AddFault_Load);
            ((System.ComponentModel.ISupportInitialize)(this.affectedComponentsView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
  }
}
