// Decompiled with JetBrains decompiler
// Type: AlertsProject.UpdateFault
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
  public class UpdateFault : Form
  {
    private IContainer components = (IContainer) null;
    private List<Fault> currentFaultsList;
    private SystemComponent currentAffectedComponent;
    private List<SystemComponent> currentAffectedComponentsList;
    private DataGridView componentsFaultsView;
    private int selectedFaultIndex;
    private Fault currentFault;
    private Label label4;
    private RichTextBox implicationsTextBox;
    private ComboBox FaultsNamesComboBox;
    private Label label5;
    private Label label6;
    private TextBox updatedFaultNameTextBox;
    private Button updateFaultButton;
    private Label label1;
    private Button deleteAffectedComponentButton;
    private Button resetAffectedComponentListButton;
    private Button addAffectedComponentButton;
    private Label label2;
    private ComboBox affectedComponentsNameList;
    private DataGridView affectedComponentsView;
    private DataGridViewTextBoxColumn FaultsHeader;
    private DataGridViewTextBoxColumn implicationsHeader;
    private Button chooseFaultButton;
    private Button cancelUpdateButton;

    public UpdateFault()
    {
      this.DoubleBuffered = true;
      this.InitializeComponent();
    }

    public UpdateFault(List<Fault> currentFaultsList, DataGridView componentsFaultsView)
    {
      this.InitializeComponent();
      this.currentFaultsList = currentFaultsList;
      this.componentsFaultsView = componentsFaultsView;
    }

    private void FaultsNamesComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void UpdateFault_Load(object sender, EventArgs e)
    {
      Tools.updateComboBox(this.FaultsNamesComboBox, Tools.createFaultsNamesList(this.currentFaultsList));
      this.FaultsNamesComboBox.SelectedIndex = -1;
      Tools.updateComboBox(this.affectedComponentsNameList, Tools.componentsList);
      this.affectedComponentsNameList.SelectedIndex = -1;
    }

    private void chooseFaultButton_Click(object sender, EventArgs e)
    {
      this.selectedFaultIndex = this.FaultsNamesComboBox.SelectedIndex;
      if (this.selectedFaultIndex == -1)
        return;
      this.currentFault = this.currentFaultsList[this.selectedFaultIndex];
      this.updatedFaultNameTextBox.Text = this.currentFault.getName();
      this.implicationsTextBox.Text = this.currentFault.getimplication();
      this.currentAffectedComponentsList = this.currentFault.getAffectedComponents();
      if (this.currentAffectedComponentsList == null)
        this.currentAffectedComponentsList = new List<SystemComponent>();
      Tools.loadListIntoDataGridView(this.currentAffectedComponentsList, this.affectedComponentsView, false);
      Tools.loadFaultsIntoDataGridView(this.currentFaultsList, this.componentsFaultsView, false);
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

    private void resetAffectedComponentListButton_Click(object sender, EventArgs e)
    {
      this.affectedComponentsView.Rows.Clear();
      this.currentAffectedComponentsList = new List<SystemComponent>();
    }

    private void updateFaultButton_Click(object sender, EventArgs e)
    {
      if (this.currentFaultsList[this.selectedFaultIndex].getName() == this.updatedFaultNameTextBox.Text)
      {
        this.updateFault();
      }
      else
      {
        if (!Tools.isValidFault(this.currentFaultsList, this.updatedFaultNameTextBox.Text, this.implicationsTextBox.Text, this.currentAffectedComponentsList))
          return;
        this.updateFault();
      }
    }

    private void deleteAffectedComponentButton_Click(object sender, EventArgs e)
    {
      this.currentAffectedComponentsList.Remove(Tools.findComponentInListOfComponents(this.currentAffectedComponentsList, (string) this.affectedComponentsView.Rows[this.affectedComponentsView.CurrentCell.RowIndex].Cells[0].Value));
      Tools.loadListIntoDataGridView(this.currentAffectedComponentsList, this.affectedComponentsView, false);
    }

    private void cleanFieldsAfterUpdate()
    {
      Tools.ResetAllControls((Control) this);
      this.updatedFaultNameTextBox.Text = "";
      this.implicationsTextBox.Text = "";
      this.selectedFaultIndex = -1;
      Tools.updateComboBox(this.FaultsNamesComboBox, Tools.componentsList);
    }

    private void updateFault()
    {
      this.currentFaultsList[this.selectedFaultIndex].setName(this.updatedFaultNameTextBox.Text);
      this.currentFaultsList[this.selectedFaultIndex].setImplications(this.implicationsTextBox.Text);
      this.currentFaultsList[this.selectedFaultIndex].setAffectedComponents(this.currentAffectedComponentsList);
      Tools.loadFaultsIntoDataGridView(this.currentFaultsList, this.componentsFaultsView, false);
      int num = (int) MessageBox.Show("התקלה עודכנה בהצלחה!", Tools.INFORMATION, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void label5_Click(object sender, EventArgs e)
    {
    }

    private void updatedFaultNameTextBox_TextChanged(object sender, EventArgs e)
    {
    }

    private void label6_Click(object sender, EventArgs e)
    {
    }

    private void implicationsTextBox_TextChanged(object sender, EventArgs e)
    {
    }

    private void label2_Click(object sender, EventArgs e)
    {
    }

    private void label4_Click(object sender, EventArgs e)
    {
    }

    private void affectedComponentsNameList_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void affectedComponentsView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void cancelUpdateButton_Click(object sender, EventArgs e)
    {
      Tools.ResetAllControls((Control) this);
      this.currentAffectedComponentsList = new List<SystemComponent>();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (UpdateFault));
      this.label4 = new Label();
      this.implicationsTextBox = new RichTextBox();
      this.FaultsNamesComboBox = new ComboBox();
      this.label5 = new Label();
      this.label6 = new Label();
      this.updatedFaultNameTextBox = new TextBox();
      this.updateFaultButton = new Button();
      this.label1 = new Label();
      this.deleteAffectedComponentButton = new Button();
      this.resetAffectedComponentListButton = new Button();
      this.addAffectedComponentButton = new Button();
      this.label2 = new Label();
      this.affectedComponentsNameList = new ComboBox();
      this.affectedComponentsView = new DataGridView();
      this.FaultsHeader = new DataGridViewTextBoxColumn();
      this.implicationsHeader = new DataGridViewTextBoxColumn();
      this.chooseFaultButton = new Button();
      this.cancelUpdateButton = new Button();
      ((ISupportInitialize) this.affectedComponentsView).BeginInit();
      this.SuspendLayout();
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.Font = new Font("Century Gothic", 39.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = SystemColors.ActiveCaptionText;
      this.label4.Location = new Point(470, 9);
      this.label4.Name = "label4";
      this.label4.RightToLeft = RightToLeft.Yes;
      this.label4.Size = new Size(402, 63);
      this.label4.TabIndex = 21;
      this.label4.Text = "עדכון תקלה קיימת";
      this.label4.Click += new EventHandler(this.label4_Click);
      this.implicationsTextBox.Font = new Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.implicationsTextBox.Location = new Point(547, 235);
      this.implicationsTextBox.Name = "implicationsTextBox";
      this.implicationsTextBox.RightToLeft = RightToLeft.Yes;
      this.implicationsTextBox.Size = new Size(315, 91);
      this.implicationsTextBox.TabIndex = 22;
      this.implicationsTextBox.Text = "";
      this.implicationsTextBox.TextChanged += new EventHandler(this.implicationsTextBox_TextChanged);
      this.FaultsNamesComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.FaultsNamesComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.FaultsNamesComboBox.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FaultsNamesComboBox.FormattingEnabled = true;
      this.FaultsNamesComboBox.Location = new Point(428, 104);
      this.FaultsNamesComboBox.Name = "FaultsNamesComboBox";
      this.FaultsNamesComboBox.RightToLeft = RightToLeft.Yes;
      this.FaultsNamesComboBox.Size = new Size(180, 29);
      this.FaultsNamesComboBox.TabIndex = 23;
      this.FaultsNamesComboBox.SelectedIndexChanged += new EventHandler(this.FaultsNamesComboBox_SelectedIndexChanged);
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.Transparent;
      this.label5.Font = new Font("Century Gothic", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = SystemColors.ActiveCaptionText;
      this.label5.Location = new Point(704, 154);
      this.label5.Name = "label5";
      this.label5.RightToLeft = RightToLeft.Yes;
      this.label5.Size = new Size(163, 30);
      this.label5.TabIndex = 24;
      this.label5.Text = "שינוי שם תקלה:";
      this.label5.Click += new EventHandler(this.label5_Click);
      this.label6.AutoSize = true;
      this.label6.BackColor = Color.Transparent;
      this.label6.Font = new Font("Century Gothic", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = SystemColors.ActiveCaptionText;
      this.label6.Location = new Point(588, 202);
      this.label6.Name = "label6";
      this.label6.RightToLeft = RightToLeft.Yes;
      this.label6.Size = new Size(279, 30);
      this.label6.TabIndex = 26;
      this.label6.Text = "עדכון משמעויות של התקלה:";
      this.label6.Click += new EventHandler(this.label6_Click);
      this.updatedFaultNameTextBox.Font = new Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.updatedFaultNameTextBox.Location = new Point(557, 161);
      this.updatedFaultNameTextBox.MaxLength = 3000;
      this.updatedFaultNameTextBox.Name = "updatedFaultNameTextBox";
      this.updatedFaultNameTextBox.RightToLeft = RightToLeft.Yes;
      this.updatedFaultNameTextBox.Size = new Size(151, 23);
      this.updatedFaultNameTextBox.TabIndex = 25;
      this.updatedFaultNameTextBox.TextChanged += new EventHandler(this.updatedFaultNameTextBox_TextChanged);
      this.updateFaultButton.FlatStyle = FlatStyle.System;
      this.updateFaultButton.Font = new Font("Century Gothic", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.updateFaultButton.ForeColor = Color.White;
      this.updateFaultButton.Location = new Point(12, 471);
      this.updateFaultButton.Name = "updateFaultButton";
      this.updateFaultButton.RightToLeft = RightToLeft.Yes;
      this.updateFaultButton.Size = new Size(170, 70);
      this.updateFaultButton.TabIndex = 28;
      this.updateFaultButton.Text = "עדכון תקלה";
      this.updateFaultButton.UseVisualStyleBackColor = true;
      this.updateFaultButton.Click += new EventHandler(this.updateFaultButton_Click);
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Century Gothic", 21.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = SystemColors.ActiveCaptionText;
      this.label1.Location = new Point(614, 97);
      this.label1.Name = "label1";
      this.label1.RightToLeft = RightToLeft.Yes;
      this.label1.Size = new Size(252, 36);
      this.label1.TabIndex = 29;
      this.label1.Text = "בחירת תקלה לעדכון:";
      this.label1.Click += new EventHandler(this.label1_Click);
      this.deleteAffectedComponentButton.FlatStyle = FlatStyle.System;
      this.deleteAffectedComponentButton.Font = new Font("Century Gothic", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.deleteAffectedComponentButton.Location = new Point(291, 485);
      this.deleteAffectedComponentButton.Name = "deleteAffectedComponentButton";
      this.deleteAffectedComponentButton.RightToLeft = RightToLeft.Yes;
      this.deleteAffectedComponentButton.Size = new Size(95, 48);
      this.deleteAffectedComponentButton.TabIndex = 51;
      this.deleteAffectedComponentButton.Text = "מחיקת רכיב מהרשימה";
      this.deleteAffectedComponentButton.UseVisualStyleBackColor = true;
      this.deleteAffectedComponentButton.Click += new EventHandler(this.deleteAffectedComponentButton_Click);
      this.resetAffectedComponentListButton.FlatStyle = FlatStyle.System;
      this.resetAffectedComponentListButton.Font = new Font("Century Gothic", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.resetAffectedComponentListButton.Location = new Point(292, 431);
      this.resetAffectedComponentListButton.Name = "resetAffectedComponentListButton";
      this.resetAffectedComponentListButton.RightToLeft = RightToLeft.Yes;
      this.resetAffectedComponentListButton.Size = new Size(94, 48);
      this.resetAffectedComponentListButton.TabIndex = 50;
      this.resetAffectedComponentListButton.Text = "איפוס רכיבים מושפעים";
      this.resetAffectedComponentListButton.UseVisualStyleBackColor = true;
      this.resetAffectedComponentListButton.Click += new EventHandler(this.resetAffectedComponentListButton_Click);
      this.addAffectedComponentButton.FlatStyle = FlatStyle.System;
      this.addAffectedComponentButton.Font = new Font("Century Gothic", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.addAffectedComponentButton.Location = new Point(395, 358);
      this.addAffectedComponentButton.Name = "addAffectedComponentButton";
      this.addAffectedComponentButton.RightToLeft = RightToLeft.Yes;
      this.addAffectedComponentButton.Size = new Size(69, 24);
      this.addAffectedComponentButton.TabIndex = 49;
      this.addAffectedComponentButton.Text = "הוסף";
      this.addAffectedComponentButton.UseVisualStyleBackColor = true;
      this.addAffectedComponentButton.Click += new EventHandler(this.addAffectedComponentButton_Click);
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Century Gothic", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = SystemColors.ActiveCaptionText;
      this.label2.Location = new Point(663, 351);
      this.label2.Name = "label2";
      this.label2.RightToLeft = RightToLeft.Yes;
      this.label2.Size = new Size(204, 30);
      this.label2.TabIndex = 48;
      this.label2.Text = "הוספת רכיב מושפע:";
      this.label2.Click += new EventHandler(this.label2_Click);
      this.affectedComponentsNameList.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.affectedComponentsNameList.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.affectedComponentsNameList.Font = new Font("Century Gothic", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.affectedComponentsNameList.FormattingEnabled = true;
      this.affectedComponentsNameList.Location = new Point(470, 357);
      this.affectedComponentsNameList.Name = "affectedComponentsNameList";
      this.affectedComponentsNameList.RightToLeft = RightToLeft.Yes;
      this.affectedComponentsNameList.Size = new Size(194, 24);
      this.affectedComponentsNameList.TabIndex = 46;
      this.affectedComponentsNameList.SelectedIndexChanged += new EventHandler(this.affectedComponentsNameList_SelectedIndexChanged);
      this.affectedComponentsView.AllowUserToAddRows = false;
      this.affectedComponentsView.AllowUserToDeleteRows = false;
      this.affectedComponentsView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
      this.affectedComponentsView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.affectedComponentsView.Columns.AddRange((DataGridViewColumn) this.FaultsHeader, (DataGridViewColumn) this.implicationsHeader);
      this.affectedComponentsView.Location = new Point(391, 401);
      this.affectedComponentsView.MultiSelect = false;
      this.affectedComponentsView.Name = "affectedComponentsView";
      this.affectedComponentsView.RightToLeft = RightToLeft.Yes;
      this.affectedComponentsView.RowHeadersVisible = false;
      this.affectedComponentsView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.affectedComponentsView.Size = new Size(471, 138);
      this.affectedComponentsView.TabIndex = 52;
      this.affectedComponentsView.CellContentClick += new DataGridViewCellEventHandler(this.affectedComponentsView_CellContentClick);
      this.FaultsHeader.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
      this.FaultsHeader.HeaderText = "שם הרכיב";
      this.FaultsHeader.MinimumWidth = 150;
      this.FaultsHeader.Name = "FaultsHeader";
      this.FaultsHeader.Width = 150;
      this.implicationsHeader.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.implicationsHeader.HeaderText = "תיאור הרכיב";
      this.implicationsHeader.Name = "implicationsHeader";
      this.chooseFaultButton.Font = new Font("Century Gothic", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.chooseFaultButton.Location = new Point(347, 104);
      this.chooseFaultButton.Name = "chooseFaultButton";
      this.chooseFaultButton.Size = new Size(75, 29);
      this.chooseFaultButton.TabIndex = 53;
      this.chooseFaultButton.Text = "הצגה";
      this.chooseFaultButton.UseVisualStyleBackColor = true;
      this.chooseFaultButton.Click += new EventHandler(this.chooseFaultButton_Click);
      this.cancelUpdateButton.FlatStyle = FlatStyle.System;
      this.cancelUpdateButton.Font = new Font("Century Gothic", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cancelUpdateButton.ForeColor = Color.White;
      this.cancelUpdateButton.Location = new Point(12, 420);
      this.cancelUpdateButton.Name = "cancelUpdateButton";
      this.cancelUpdateButton.RightToLeft = RightToLeft.Yes;
      this.cancelUpdateButton.Size = new Size(170, 45);
      this.cancelUpdateButton.TabIndex = 54;
      this.cancelUpdateButton.Text = "ניקוי שדות";
      this.cancelUpdateButton.UseVisualStyleBackColor = true;
      this.cancelUpdateButton.Click += new EventHandler(this.cancelUpdateButton_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) componentResourceManager.GetObject("$this.BackgroundImage");
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(884, 561);
      this.Controls.Add((Control) this.cancelUpdateButton);
      this.Controls.Add((Control) this.chooseFaultButton);
      this.Controls.Add((Control) this.affectedComponentsView);
      this.Controls.Add((Control) this.deleteAffectedComponentButton);
      this.Controls.Add((Control) this.resetAffectedComponentListButton);
      this.Controls.Add((Control) this.addAffectedComponentButton);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.affectedComponentsNameList);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.implicationsTextBox);
      this.Controls.Add((Control) this.FaultsNamesComboBox);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.updatedFaultNameTextBox);
      this.Controls.Add((Control) this.updateFaultButton);
      this.ForeColor = SystemColors.ActiveCaptionText;
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = nameof (UpdateFault);
      this.Text = nameof (UpdateFault);
      this.Load += new EventHandler(this.UpdateFault_Load);
      ((ISupportInitialize) this.affectedComponentsView).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
