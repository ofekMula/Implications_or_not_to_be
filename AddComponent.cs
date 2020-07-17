// Decompiled with JetBrains decompiler
// Type: AlertsProject.AddComponent
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
  public class AddComponent : Form
  {
    private IContainer components = (IContainer) null;
    private ComboBox componentsNames;
    private List<Fault> currentFaultsList;
    private Form implicationWindow;
    private string componentImageUrl;
    private string componentType;
    private RichTextBox descriptionTextBox;
    private Label label10;
    private Label label11;
    private TextBox componentNameTextBox;
    private Label label2;
    private DataGridView FaultsView;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private Label label8;
    private Button addNewFaultButton;
    private Button addComponentButton;
    private Button button1;
    private Button addImageButton;

    public AddComponent(ComboBox componentsNames, Form implicationWindow)
    {
      this.DoubleBuffered = true;
      this.InitializeComponent();
      this.componentsNames = componentsNames;
      this.implicationWindow = implicationWindow;
    }

    private void addComponentButton_Click(object sender, EventArgs e)
    {
      if (!Tools.isValidComponent(this.componentNameTextBox.Text))
        return;
      this.addComponentToDB(this.componentNameTextBox.Text, this.descriptionTextBox.Text, this.currentFaultsList, this.componentImageUrl, this.componentType);
      Tools.updateComboBox(this.componentsNames, Tools.componentsList);
      Tools.ResetAllControls((Control) this.implicationWindow);
      this.currentFaultsList = new List<Fault>();
      int num = (int) MessageBox.Show(Tools.ADD_COMPONENT_SUCCEEDED, Tools.INFORMATION, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    private void componentImplicationsRichTextBox_TextChanged(object sender, EventArgs e)
    {
    }

    private void addComponentToDB(string name, string description, List<Fault> faults)
    {
      if (faults == null)
        faults = new List<Fault>();
      Tools.DataBase.Add(new SystemComponent(name, description, faults));
      Tools.componentsList.Add(name);
      Tools.writeDB();
      Tools.ResetAllControls((Control) this);
    }

    private void addComponentToDB(
      string name,
      string description,
      List<Fault> faults,
      string imageUrl,
      string componentType)
    {
      if (faults == null)
        faults = new List<Fault>();
      Tools.DataBase.Add(new SystemComponent(name, description, faults, (List<InfoFile>) null, imageUrl, componentType));
      Tools.componentsList.Add(name);
      Tools.writeDB();
      Tools.ResetAllControls((Control) this);
    }

    private void componentNameTextBox_TextChanged(object sender, EventArgs e)
    {
    }

    private void AddComponent_Load(object sender, EventArgs e)
    {
    }

    private void resetFaultViewButton_Click(object sender, EventArgs e)
    {
      this.FaultsView.Rows.Clear();
      this.currentFaultsList = (List<Fault>) null;
    }

    private void resetAllFieldsButton_Click(object sender, EventArgs e)
    {
      Tools.ResetAllControls((Control) this);
      this.FaultsView.Rows.Clear();
      this.currentFaultsList = (List<Fault>) null;
    }

    private void deleteFaultsButton_Click(object sender, EventArgs e)
    {
      List<Fault> faultList = Tools.selectedFaultsInDataView(this.FaultsView, this.currentFaultsList, false);
      if (faultList.Count > 0)
      {
        if (MessageBox.Show(Tools.DELETE_COMPONENT_QUESTION, Tools.INFORMATION, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
          return;
        for (int index = 0; index < faultList.Count; ++index)
          Tools.DeleteImplicationFromList(this.currentFaultsList, faultList[index]);
        Tools.loadFaultsIntoDataGridView(this.currentFaultsList, this.FaultsView, false);
      }
      else
      {
        int num = (int) MessageBox.Show(Tools.DELETE_COMPONENT_ERROR, Tools.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void FaultsView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void loadExistsDbButton_Click(object sender, EventArgs e)
    {
      int num = (int) new AddFault(this.currentFaultsList, this.FaultsView).ShowDialog();
    }

    private void AddComponent_Load_1(object sender, EventArgs e)
    {
    }

    private void updateComponentButton_Click(object sender, EventArgs e)
    {
    }

    private void addNewFaultButton_Click(object sender, EventArgs e)
    {
      if (this.currentFaultsList == null)
        this.currentFaultsList = new List<Fault>();
      int num = (int) new AddFault(this.currentFaultsList, this.FaultsView).ShowDialog();
    }

    private void componentNameTextBox_TextChanged_1(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Tools.ResetAllControls((Control) this);
      this.currentFaultsList = new List<Fault>();
    }

    private void label8_Click(object sender, EventArgs e)
    {
    }

    private void addImageButton_Click(object sender, EventArgs e)
    {
      int num = (int) new AddImageUrl(this.componentImageUrl).ShowDialog();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AddComponent));
      this.descriptionTextBox = new RichTextBox();
      this.label10 = new Label();
      this.label11 = new Label();
      this.componentNameTextBox = new TextBox();
      this.label2 = new Label();
      this.FaultsView = new DataGridView();
      this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      this.label8 = new Label();
      this.addNewFaultButton = new Button();
      this.addComponentButton = new Button();
      this.button1 = new Button();
      this.addImageButton = new Button();
      ((ISupportInitialize) this.FaultsView).BeginInit();
      this.SuspendLayout();
      this.descriptionTextBox.Font = new Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.descriptionTextBox.Location = new Point(511, 204);
      this.descriptionTextBox.Name = "descriptionTextBox";
      this.descriptionTextBox.RightToLeft = RightToLeft.Yes;
      this.descriptionTextBox.Size = new Size(350, 100);
      this.descriptionTextBox.TabIndex = 34;
      this.descriptionTextBox.Text = "";
      this.label10.AutoSize = true;
      this.label10.BackColor = Color.Transparent;
      this.label10.Font = new Font("Century Gothic", 27.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label10.ForeColor = Color.Black;
      this.label10.Location = new Point(702, 91);
      this.label10.Name = "label10";
      this.label10.RightToLeft = RightToLeft.Yes;
      this.label10.Size = new Size(167, 44);
      this.label10.TabIndex = 35;
      this.label10.Text = "שם הרכיב:";
      this.label11.AutoSize = true;
      this.label11.BackColor = Color.Transparent;
      this.label11.Font = new Font("Century Gothic", 21.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label11.ForeColor = Color.Black;
      this.label11.Location = new Point(712, 165);
      this.label11.Name = "label11";
      this.label11.RightToLeft = RightToLeft.Yes;
      this.label11.Size = new Size(155, 36);
      this.label11.TabIndex = 36;
      this.label11.Text = "תיאור הרכיב:";
      this.componentNameTextBox.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.componentNameTextBox.Location = new Point(472, 107);
      this.componentNameTextBox.MaxLength = 3000;
      this.componentNameTextBox.Name = "componentNameTextBox";
      this.componentNameTextBox.RightToLeft = RightToLeft.Yes;
      this.componentNameTextBox.Size = new Size(224, 27);
      this.componentNameTextBox.TabIndex = 37;
      this.componentNameTextBox.TextChanged += new EventHandler(this.componentNameTextBox_TextChanged_1);
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Century Gothic", 39.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(495, 9);
      this.label2.Name = "label2";
      this.label2.RightToLeft = RightToLeft.Yes;
      this.label2.Size = new Size(377, 63);
      this.label2.TabIndex = 33;
      this.label2.Text = "הוספת רכיב חדש";
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
      this.FaultsView.Location = new Point(350, 373);
      this.FaultsView.MultiSelect = false;
      this.FaultsView.Name = "FaultsView";
      this.FaultsView.RightToLeft = RightToLeft.Yes;
      this.FaultsView.RowHeadersVisible = false;
      this.FaultsView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.FaultsView.Size = new Size(511, 176);
      this.FaultsView.TabIndex = 42;
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
      this.label8.ForeColor = Color.Black;
      this.label8.Location = new Point(597, 330);
      this.label8.Name = "label8";
      this.label8.RightToLeft = RightToLeft.Yes;
      this.label8.Size = new Size(269, 30);
      this.label8.TabIndex = 43;
      this.label8.Text = "רשימת התקלות של הרכיב:";
      this.label8.Click += new EventHandler(this.label8_Click);
      this.addNewFaultButton.BackColor = Color.Transparent;
      this.addNewFaultButton.BackgroundImageLayout = ImageLayout.Center;
      this.addNewFaultButton.FlatStyle = FlatStyle.System;
      this.addNewFaultButton.Font = new Font("Century Gothic", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.addNewFaultButton.ForeColor = Color.White;
      this.addNewFaultButton.Location = new Point(12, 430);
      this.addNewFaultButton.Name = "addNewFaultButton";
      this.addNewFaultButton.Size = new Size(170, 45);
      this.addNewFaultButton.TabIndex = 46;
      this.addNewFaultButton.Text = "תקלה חדשה";
      this.addNewFaultButton.UseVisualStyleBackColor = false;
      this.addNewFaultButton.Click += new EventHandler(this.addNewFaultButton_Click);
      this.addComponentButton.BackgroundImageLayout = ImageLayout.Center;
      this.addComponentButton.FlatStyle = FlatStyle.System;
      this.addComponentButton.Font = new Font("Century Gothic", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.addComponentButton.ForeColor = Color.White;
      this.addComponentButton.Location = new Point(12, 481);
      this.addComponentButton.Name = "addComponentButton";
      this.addComponentButton.RightToLeft = RightToLeft.Yes;
      this.addComponentButton.Size = new Size(170, 70);
      this.addComponentButton.TabIndex = 45;
      this.addComponentButton.Text = "הוספת רכיב למאגר";
      this.addComponentButton.UseVisualStyleBackColor = true;
      this.addComponentButton.Click += new EventHandler(this.addComponentButton_Click);
      this.button1.BackColor = Color.Transparent;
      this.button1.BackgroundImageLayout = ImageLayout.Center;
      this.button1.FlatStyle = FlatStyle.System;
      this.button1.Font = new Font("Century Gothic", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.button1.ForeColor = Color.White;
      this.button1.Location = new Point(12, 330);
      this.button1.Name = "button1";
      this.button1.Size = new Size(170, 45);
      this.button1.TabIndex = 47;
      this.button1.Text = "ניקוי שדות";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.addImageButton.BackColor = Color.Transparent;
      this.addImageButton.BackgroundImageLayout = ImageLayout.Center;
      this.addImageButton.FlatStyle = FlatStyle.System;
      this.addImageButton.Font = new Font("Century Gothic", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.addImageButton.ForeColor = Color.White;
      this.addImageButton.Location = new Point(12, 379);
      this.addImageButton.Name = "addImageButton";
      this.addImageButton.Size = new Size(170, 45);
      this.addImageButton.TabIndex = 48;
      this.addImageButton.Text = "הוספת תמונה";
      this.addImageButton.UseVisualStyleBackColor = false;
      this.addImageButton.Click += new EventHandler(this.addImageButton_Click);
      this.AcceptButton = (IButtonControl) this.addComponentButton;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) componentResourceManager.GetObject("$this.BackgroundImage");
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(884, 561);
      this.Controls.Add((Control) this.addImageButton);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.addNewFaultButton);
      this.Controls.Add((Control) this.addComponentButton);
      this.Controls.Add((Control) this.FaultsView);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.descriptionTextBox);
      this.Controls.Add((Control) this.label10);
      this.Controls.Add((Control) this.label11);
      this.Controls.Add((Control) this.componentNameTextBox);
      this.Controls.Add((Control) this.label2);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = nameof (AddComponent);
      this.Text = "AddComponent2";
      this.Load += new EventHandler(this.AddComponent_Load);
      ((ISupportInitialize) this.FaultsView).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
