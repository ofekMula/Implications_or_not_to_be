// Decompiled with JetBrains decompiler
// Type: AlertsProject.UpdateComponent
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
  public class UpdateComponent : Form
  {
    private int selectedComponentIndex = -1;
    private IContainer components = (IContainer) null;
    private ComboBox componentsNamesOfImplicationWindow;
    private List<Fault> currentFaultsList;
    private Form implicationWindow;
    private Label label2;
    private Label label3;
    private Button chooseComponentButton;
    private ComboBox componentsNameList;
    private TextBox updatedComponentNameTextBox;
    private Label label1;
    private Button updateComponentButton;
    private RichTextBox UpdatedDescriptionTextBox;
    private Label label4;
    private Button deleteFaultFromListButton;
    private Button clearFaultsListButton;
    private DataGridView FaultsView;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private Label label8;
    private Button updateFaultButton;
    private Button addFaultButton;
    private Button cancelUpdateButton;

    public UpdateComponent(ComboBox componentsNames, Form implicationWindow)
    {
      this.DoubleBuffered = true;
      this.InitializeComponent();
      this.componentsNamesOfImplicationWindow = componentsNames;
      this.implicationWindow = implicationWindow;
    }

    private void label4_Click(object sender, EventArgs e)
    {
    }

    private void componentImplicationsRichTextBox_TextChanged(object sender, EventArgs e)
    {
    }

    private void componentsNameList_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void UpdateComponent_Load(object sender, EventArgs e)
    {
      this.componentsNameList.DataSource = (object) Tools.componentsList;
      this.componentsNameList.SelectedIndex = -1;
    }

    private void chooseComponentButton_Click(object sender, EventArgs e)
    {
      this.selectedComponentIndex = this.componentsNameList.SelectedIndex;
      if (this.selectedComponentIndex == -1)
        return;
      this.updatedComponentNameTextBox.Text = Tools.DataBase[this.selectedComponentIndex].getName();
      this.UpdatedDescriptionTextBox.Text = Tools.DataBase[this.selectedComponentIndex].getDescription();
      this.currentFaultsList = Tools.DataBase[this.selectedComponentIndex].getFaultsList();
      if (this.currentFaultsList == null)
        this.currentFaultsList = new List<Fault>();
      Tools.loadFaultsIntoDataGridView(this.currentFaultsList, this.FaultsView, false);
    }

    private void componentNameTextBox_TextChanged(object sender, EventArgs e)
    {
    }

    private void updateButton_Click(object sender, EventArgs e)
    {
      if (this.selectedComponentIndex != -1)
      {
        if (Tools.DataBase[this.selectedComponentIndex].getName() == this.updatedComponentNameTextBox.Text)
        {
          this.updateWindowAfterComponentSelection();
        }
        else
        {
          if (!Tools.isValidComponent(this.updatedComponentNameTextBox.Text))
            return;
          this.updateWindowAfterComponentSelection();
        }
      }
      else
      {
        int num = (int) MessageBox.Show(Tools.CHOOSE_COMPONENT_ERROR, Tools.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void updateWindowAfterComponentSelection()
    {
      Tools.DataBase[this.selectedComponentIndex].setName(this.updatedComponentNameTextBox.Text);
      Tools.DataBase[this.selectedComponentIndex].setDescription(this.UpdatedDescriptionTextBox.Text);
      Tools.DataBase[this.selectedComponentIndex].setFaultsList(this.currentFaultsList);
      Tools.componentsList[this.selectedComponentIndex] = Tools.DataBase[this.selectedComponentIndex].getName();
      Tools.updateComboBox(this.componentsNameList, Tools.componentsList);
      Tools.updateComboBox(this.componentsNamesOfImplicationWindow, Tools.componentsList);
      this.cleanFieldsAfterUpdate();
      Tools.writeDB();
      Tools.ResetAllControls((Control) this.implicationWindow);
      int num = (int) MessageBox.Show(Tools.UPDATE_COMPONENT_SUCCEEDED, Tools.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    private void cancelUpdateButton_Click(object sender, EventArgs e)
    {
      this.cleanFieldsAfterUpdate();
      this.componentsNameList.DataSource = (object) Tools.componentsList;
      this.componentsNameList.SelectedIndex = -1;
      this.currentFaultsList = (List<Fault>) null;
    }

    private void deleteCurrentFaultButton_Click(object sender, EventArgs e)
    {
    }

    private void addNewFaultButton_Click(object sender, EventArgs e)
    {
    }

    private void cleanFieldsAfterUpdate()
    {
      Tools.ResetAllControls((Control) this);
      this.updatedComponentNameTextBox.Text = "";
      this.UpdatedDescriptionTextBox.Text = "";
      this.currentFaultsList = (List<Fault>) null;
      this.selectedComponentIndex = -1;
      Tools.updateComboBox(this.componentsNameList, Tools.componentsList);
    }

    private void clearFaultsListButton_Click(object sender, EventArgs e)
    {
      this.FaultsView.Rows.Clear();
      this.currentFaultsList = new List<Fault>();
    }

    private void addFaultButton_Click(object sender, EventArgs e)
    {
      if (this.currentFaultsList == null)
        this.currentFaultsList = new List<Fault>();
      int num = (int) new AddFault(this.currentFaultsList, this.FaultsView).ShowDialog();
    }

    private void updateFaultButton_Click_1(object sender, EventArgs e)
    {
      if (this.currentFaultsList == null)
        this.currentFaultsList = new List<Fault>();
      if (this.currentFaultsList.Count > 0)
      {
        int num1 = (int) new UpdateFault(this.currentFaultsList, this.FaultsView).ShowDialog();
      }
      else
      {
        int num2 = (int) MessageBox.Show(Tools.UPDATE_FAULT_ERROR, Tools.INFORMATION, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void deleteFaultFromListButton_Click(object sender, EventArgs e)
    {
      this.currentFaultsList.Remove(Tools.findFaultInListOfFaults(this.currentFaultsList, (string) this.FaultsView.Rows[this.FaultsView.CurrentCell.RowIndex].Cells[0].Value));
      Tools.loadFaultsIntoDataGridView(this.currentFaultsList, this.FaultsView, false);
      this.cleanFieldsAfterUpdate();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (UpdateComponent));
      this.label2 = new Label();
      this.label3 = new Label();
      this.chooseComponentButton = new Button();
      this.componentsNameList = new ComboBox();
      this.updatedComponentNameTextBox = new TextBox();
      this.label1 = new Label();
      this.updateComponentButton = new Button();
      this.UpdatedDescriptionTextBox = new RichTextBox();
      this.label4 = new Label();
      this.deleteFaultFromListButton = new Button();
      this.clearFaultsListButton = new Button();
      this.FaultsView = new DataGridView();
      this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      this.label8 = new Label();
      this.updateFaultButton = new Button();
      this.addFaultButton = new Button();
      this.cancelUpdateButton = new Button();
      ((ISupportInitialize) this.FaultsView).BeginInit();
      this.SuspendLayout();
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Century Gothic", 39.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(530, 9);
      this.label2.Name = "label2";
      this.label2.RightToLeft = RightToLeft.Yes;
      this.label2.Size = new Size(342, 63);
      this.label2.TabIndex = 3;
      this.label2.Text = "עדכון רכיב קיים";
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Century Gothic", 21.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.Black;
      this.label3.Location = new Point(738, 107);
      this.label3.Name = "label3";
      this.label3.RightToLeft = RightToLeft.Yes;
      this.label3.Size = new Size(129, 36);
      this.label3.TabIndex = 6;
      this.label3.Text = "בחר רכיב:\r\n";
      this.chooseComponentButton.Font = new Font("Century Gothic", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.chooseComponentButton.Location = new Point(423, 116);
      this.chooseComponentButton.Name = "chooseComponentButton";
      this.chooseComponentButton.Size = new Size(75, 28);
      this.chooseComponentButton.TabIndex = 8;
      this.chooseComponentButton.Text = "הצגה";
      this.chooseComponentButton.UseVisualStyleBackColor = true;
      this.chooseComponentButton.Click += new EventHandler(this.chooseComponentButton_Click);
      this.componentsNameList.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.componentsNameList.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.componentsNameList.Font = new Font("Century Gothic", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.componentsNameList.FormattingEnabled = true;
      this.componentsNameList.Location = new Point(504, 115);
      this.componentsNameList.Name = "componentsNameList";
      this.componentsNameList.RightToLeft = RightToLeft.Yes;
      this.componentsNameList.Size = new Size(228, 28);
      this.componentsNameList.TabIndex = 7;
      this.componentsNameList.SelectedIndexChanged += new EventHandler(this.componentsNameList_SelectedIndexChanged);
      this.updatedComponentNameTextBox.Font = new Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.updatedComponentNameTextBox.Location = new Point(522, 175);
      this.updatedComponentNameTextBox.MaxLength = 3000;
      this.updatedComponentNameTextBox.Name = "updatedComponentNameTextBox";
      this.updatedComponentNameTextBox.RightToLeft = RightToLeft.Yes;
      this.updatedComponentNameTextBox.Size = new Size(189, 23);
      this.updatedComponentNameTextBox.TabIndex = 10;
      this.updatedComponentNameTextBox.TextChanged += new EventHandler(this.componentNameTextBox_TextChanged);
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Century Gothic", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(717, 168);
      this.label1.Name = "label1";
      this.label1.RightToLeft = RightToLeft.Yes;
      this.label1.Size = new Size(149, 30);
      this.label1.TabIndex = 9;
      this.label1.Text = "שינוי שם רכיב:";
      this.updateComponentButton.FlatStyle = FlatStyle.System;
      this.updateComponentButton.Font = new Font("Century Gothic", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.updateComponentButton.ForeColor = Color.White;
      this.updateComponentButton.Location = new Point(12, 474);
      this.updateComponentButton.Name = "updateComponentButton";
      this.updateComponentButton.RightToLeft = RightToLeft.Yes;
      this.updateComponentButton.Size = new Size(170, 70);
      this.updateComponentButton.TabIndex = 13;
      this.updateComponentButton.Text = "שמירת שינויים";
      this.updateComponentButton.UseVisualStyleBackColor = true;
      this.updateComponentButton.Click += new EventHandler(this.updateButton_Click);
      this.UpdatedDescriptionTextBox.Font = new Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.UpdatedDescriptionTextBox.Location = new Point(311, 233);
      this.UpdatedDescriptionTextBox.Name = "UpdatedDescriptionTextBox";
      this.UpdatedDescriptionTextBox.RightToLeft = RightToLeft.Yes;
      this.UpdatedDescriptionTextBox.Size = new Size(354, 74);
      this.UpdatedDescriptionTextBox.TabIndex = 26;
      this.UpdatedDescriptionTextBox.Text = "";
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.Font = new Font("Century Gothic", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.Black;
      this.label4.Location = new Point(671, 233);
      this.label4.Name = "label4";
      this.label4.RightToLeft = RightToLeft.Yes;
      this.label4.Size = new Size(195, 30);
      this.label4.TabIndex = 27;
      this.label4.Text = "עדכון לתאור הרכיב:";
      this.deleteFaultFromListButton.FlatStyle = FlatStyle.System;
      this.deleteFaultFromListButton.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.deleteFaultFromListButton.Location = new Point(287, 487);
      this.deleteFaultFromListButton.Name = "deleteFaultFromListButton";
      this.deleteFaultFromListButton.Size = new Size(100, 50);
      this.deleteFaultFromListButton.TabIndex = 43;
      this.deleteFaultFromListButton.Text = "מחק תקלה";
      this.deleteFaultFromListButton.UseVisualStyleBackColor = true;
      this.deleteFaultFromListButton.Click += new EventHandler(this.deleteFaultFromListButton_Click);
      this.clearFaultsListButton.FlatStyle = FlatStyle.System;
      this.clearFaultsListButton.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.clearFaultsListButton.Location = new Point(287, 431);
      this.clearFaultsListButton.Name = "clearFaultsListButton";
      this.clearFaultsListButton.Size = new Size(100, 50);
      this.clearFaultsListButton.TabIndex = 42;
      this.clearFaultsListButton.Text = "איפוס רשימת תקלות";
      this.clearFaultsListButton.UseVisualStyleBackColor = true;
      this.clearFaultsListButton.Click += new EventHandler(this.clearFaultsListButton_Click);
      this.FaultsView.AllowUserToAddRows = false;
      this.FaultsView.AllowUserToDeleteRows = false;
      this.FaultsView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
      gridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle.BackColor = SystemColors.Control;
      gridViewCellStyle.Font = new Font("Century Gothic", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle.ForeColor = SystemColors.WindowText;
      gridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle.WrapMode = DataGridViewTriState.True;
      this.FaultsView.ColumnHeadersDefaultCellStyle = gridViewCellStyle;
      this.FaultsView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.FaultsView.Columns.AddRange((DataGridViewColumn) this.dataGridViewTextBoxColumn1, (DataGridViewColumn) this.dataGridViewTextBoxColumn2);
      this.FaultsView.Location = new Point(393, 361);
      this.FaultsView.MultiSelect = false;
      this.FaultsView.Name = "FaultsView";
      this.FaultsView.RightToLeft = RightToLeft.Yes;
      this.FaultsView.RowHeadersVisible = false;
      this.FaultsView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.FaultsView.Size = new Size(468, 176);
      this.FaultsView.TabIndex = 40;
      this.dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
      this.dataGridViewTextBoxColumn1.HeaderText = "שם התקלה";
      this.dataGridViewTextBoxColumn1.MinimumWidth = 150;
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      this.dataGridViewTextBoxColumn1.Width = 150;
      this.dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.dataGridViewTextBoxColumn2.HeaderText = "משמעויות";
      this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
      this.label8.AutoSize = true;
      this.label8.BackColor = Color.Transparent;
      this.label8.Font = new Font("Century Gothic", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.ForeColor = Color.White;
      this.label8.Location = new Point(597, 328);
      this.label8.Name = "label8";
      this.label8.RightToLeft = RightToLeft.Yes;
      this.label8.Size = new Size(269, 30);
      this.label8.TabIndex = 41;
      this.label8.Text = "רשימת התקלות של הרכיב:";
      this.updateFaultButton.FlatStyle = FlatStyle.System;
      this.updateFaultButton.Font = new Font("Century Gothic", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.updateFaultButton.ForeColor = Color.White;
      this.updateFaultButton.Location = new Point(12, 423);
      this.updateFaultButton.Name = "updateFaultButton";
      this.updateFaultButton.Size = new Size(170, 45);
      this.updateFaultButton.TabIndex = 45;
      this.updateFaultButton.Text = "לעדכון תקלה";
      this.updateFaultButton.UseVisualStyleBackColor = true;
      this.updateFaultButton.Click += new EventHandler(this.updateFaultButton_Click_1);
      this.addFaultButton.FlatStyle = FlatStyle.System;
      this.addFaultButton.Font = new Font("Century Gothic", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.addFaultButton.ForeColor = Color.White;
      this.addFaultButton.Location = new Point(12, 372);
      this.addFaultButton.Name = "addFaultButton";
      this.addFaultButton.Size = new Size(170, 45);
      this.addFaultButton.TabIndex = 44;
      this.addFaultButton.Text = "תקלה חדשה";
      this.addFaultButton.UseVisualStyleBackColor = true;
      this.addFaultButton.Click += new EventHandler(this.addFaultButton_Click);
      this.cancelUpdateButton.FlatStyle = FlatStyle.System;
      this.cancelUpdateButton.Font = new Font("Century Gothic", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cancelUpdateButton.ForeColor = Color.White;
      this.cancelUpdateButton.Location = new Point(12, 321);
      this.cancelUpdateButton.Name = "cancelUpdateButton";
      this.cancelUpdateButton.RightToLeft = RightToLeft.Yes;
      this.cancelUpdateButton.Size = new Size(170, 45);
      this.cancelUpdateButton.TabIndex = 14;
      this.cancelUpdateButton.Text = "ניקוי שדות";
      this.cancelUpdateButton.UseVisualStyleBackColor = true;
      this.cancelUpdateButton.Click += new EventHandler(this.cancelUpdateButton_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) componentResourceManager.GetObject("$this.BackgroundImage");
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(884, 561);
      this.Controls.Add((Control) this.updateFaultButton);
      this.Controls.Add((Control) this.addFaultButton);
      this.Controls.Add((Control) this.deleteFaultFromListButton);
      this.Controls.Add((Control) this.clearFaultsListButton);
      this.Controls.Add((Control) this.FaultsView);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.UpdatedDescriptionTextBox);
      this.Controls.Add((Control) this.cancelUpdateButton);
      this.Controls.Add((Control) this.updateComponentButton);
      this.Controls.Add((Control) this.updatedComponentNameTextBox);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.chooseComponentButton);
      this.Controls.Add((Control) this.componentsNameList);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.Name = nameof (UpdateComponent);
      this.Text = nameof (UpdateComponent);
      this.Load += new EventHandler(this.UpdateComponent_Load);
      ((ISupportInitialize) this.FaultsView).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
