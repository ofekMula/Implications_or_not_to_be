// Decompiled with JetBrains decompiler
// Type: AlertsProject.DeleteComponent
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
  public class DeleteComponent : Form
  {
    private IContainer components = (IContainer) null;
    private ComboBox componentsNames;
    private Form implicationWindow;
    private Label label2;
    private DataGridView componentsView;
    private Label label3;
    private Label label1;
    private TextBox SearchWord;
    private Button searchComponentsButton;
    private Button showFullList;
    private Button deleteButton;
    private DataGridViewCheckBoxColumn chooseHeader;
    private DataGridViewTextBoxColumn componentNameHeader;
    private DataGridViewTextBoxColumn componentImplicationsHeader;

    public DeleteComponent(ComboBox componentsNames, Form implicationWindow)
    {
      this.DoubleBuffered = true;
      this.InitializeComponent();
      this.componentsNames = componentsNames;
      this.implicationWindow = implicationWindow;
    }

    private void DeleteTrial_Load(object sender, EventArgs e)
    {
      Tools.loadListIntoDataGridView(Tools.DataBase, this.componentsView, true);
    }

    private void DeleteTrial_FormClosed(object sender, FormClosedEventArgs e)
    {
    }

    private void componentsView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void searchComponentsButton_Click(object sender, EventArgs e)
    {
      Tools.searchAndDisplayComponent(this.SearchWord.Text, this.componentsView, true);
    }

    private void SearchWord_TextChanged(object sender, EventArgs e)
    {
    }

    private void showFullList_Click(object sender, EventArgs e)
    {
      Tools.loadListIntoDataGridView(Tools.DataBase, this.componentsView, true);
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void deleteButton_Click(object sender, EventArgs e)
    {
      List<SystemComponent> systemComponentList = Tools.selectedItemsList(this.componentsView);
      if (systemComponentList.Count > 0)
      {
        if (MessageBox.Show(Tools.DELETE_COMPONENT_QUESTION, Tools.INFORMATION, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
          return;
        for (int index = 0; index < systemComponentList.Count; ++index)
          Tools.DeleteFromDB(systemComponentList[index]);
        Tools.loadListIntoDataGridView(Tools.DataBase, this.componentsView, true);
        Tools.writeDB();
        Tools.updateComboBox(this.componentsNames, Tools.componentsList);
        Tools.ResetAllControls((Control) this.implicationWindow);
        int num = (int) MessageBox.Show(Tools.DELETE_COMPONENT_SUCCEEDDED, Tools.INFORMATION, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        int num1 = (int) MessageBox.Show(Tools.DELETE_COMPONENT_ERROR, Tools.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void label3_Click(object sender, EventArgs e)
    {
    }

    private void label2_Click(object sender, EventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DeleteComponent));
      this.label2 = new Label();
      this.componentsView = new DataGridView();
      this.chooseHeader = new DataGridViewCheckBoxColumn();
      this.componentNameHeader = new DataGridViewTextBoxColumn();
      this.componentImplicationsHeader = new DataGridViewTextBoxColumn();
      this.label3 = new Label();
      this.label1 = new Label();
      this.SearchWord = new TextBox();
      this.searchComponentsButton = new Button();
      this.showFullList = new Button();
      this.deleteButton = new Button();
      ((ISupportInitialize) this.componentsView).BeginInit();
      this.SuspendLayout();
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Century Gothic", 39.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(495, 9);
      this.label2.Name = "label2";
      this.label2.RightToLeft = RightToLeft.Yes;
      this.label2.Size = new Size(377, 63);
      this.label2.TabIndex = 4;
      this.label2.Text = "מחיקת רכיב קיים";
      this.label2.Click += new EventHandler(this.label2_Click);
      this.componentsView.AllowUserToAddRows = false;
      this.componentsView.AllowUserToDeleteRows = false;
      gridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle.BackColor = SystemColors.Control;
      gridViewCellStyle.Font = new Font("Century Gothic", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle.ForeColor = SystemColors.WindowText;
      gridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle.WrapMode = DataGridViewTriState.True;
      this.componentsView.ColumnHeadersDefaultCellStyle = gridViewCellStyle;
      this.componentsView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.componentsView.Columns.AddRange((DataGridViewColumn) this.chooseHeader, (DataGridViewColumn) this.componentNameHeader, (DataGridViewColumn) this.componentImplicationsHeader);
      this.componentsView.Location = new Point(71, 251);
      this.componentsView.Name = "componentsView";
      this.componentsView.RightToLeft = RightToLeft.Yes;
      this.componentsView.RowHeadersVisible = false;
      this.componentsView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.componentsView.Size = new Size(790, 251);
      this.componentsView.TabIndex = 5;
      this.componentsView.CellContentClick += new DataGridViewCellEventHandler(this.componentsView_CellContentClick);
      this.chooseHeader.HeaderText = "בחירה";
      this.chooseHeader.Name = "chooseHeader";
      this.chooseHeader.SortMode = DataGridViewColumnSortMode.Automatic;
      this.chooseHeader.Width = 70;
      this.componentNameHeader.HeaderText = "שם הרכיב";
      this.componentNameHeader.MinimumWidth = 2;
      this.componentNameHeader.Name = "componentNameHeader";
      this.componentNameHeader.Resizable = DataGridViewTriState.True;
      this.componentNameHeader.Width = 150;
      this.componentImplicationsHeader.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.componentImplicationsHeader.HeaderText = "תאור הרכיב";
      this.componentImplicationsHeader.Name = "componentImplicationsHeader";
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Century Gothic", 26.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.Black;
      this.label3.Location = new Point(523, 111);
      this.label3.Name = "label3";
      this.label3.RightToLeft = RightToLeft.Yes;
      this.label3.Size = new Size(345, 41);
      this.label3.TabIndex = 10;
      this.label3.Text = "בחירת רכיב/ים למחיקה:";
      this.label3.Click += new EventHandler(this.label3_Click);
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Century Gothic", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(650, 179);
      this.label1.Name = "label1";
      this.label1.RightToLeft = RightToLeft.Yes;
      this.label1.Size = new Size(216, 30);
      this.label1.TabIndex = 11;
      this.label1.Text = "חיפוש רכיב לפי מילה:";
      this.label1.Click += new EventHandler(this.label1_Click);
      this.SearchWord.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.SearchWord.Location = new Point(393, 179);
      this.SearchWord.Name = "SearchWord";
      this.SearchWord.RightToLeft = RightToLeft.Yes;
      this.SearchWord.Size = new Size(251, 27);
      this.SearchWord.TabIndex = 12;
      this.SearchWord.TextChanged += new EventHandler(this.SearchWord_TextChanged);
      this.searchComponentsButton.Font = new Font("Century Gothic", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.searchComponentsButton.Location = new Point(294, 176);
      this.searchComponentsButton.Name = "searchComponentsButton";
      this.searchComponentsButton.Size = new Size(81, 30);
      this.searchComponentsButton.TabIndex = 13;
      this.searchComponentsButton.Text = "חיפוש";
      this.searchComponentsButton.UseVisualStyleBackColor = true;
      this.searchComponentsButton.Click += new EventHandler(this.searchComponentsButton_Click);
      this.showFullList.Font = new Font("Century Gothic", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.showFullList.Location = new Point(71, 176);
      this.showFullList.Name = "showFullList";
      this.showFullList.Size = new Size(165, 30);
      this.showFullList.TabIndex = 14;
      this.showFullList.Text = "הצגת הרשימה המלאה";
      this.showFullList.UseVisualStyleBackColor = true;
      this.showFullList.Click += new EventHandler(this.showFullList_Click);
      this.deleteButton.Cursor = Cursors.Hand;
      this.deleteButton.FlatStyle = FlatStyle.System;
      this.deleteButton.Font = new Font("Century Gothic", 17.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.deleteButton.Location = new Point(724, 508);
      this.deleteButton.Name = "deleteButton";
      this.deleteButton.RightToLeft = RightToLeft.Yes;
      this.deleteButton.Size = new Size(137, 31);
      this.deleteButton.TabIndex = 15;
      this.deleteButton.Text = "מחיקת רכיב";
      this.deleteButton.UseVisualStyleBackColor = true;
      this.deleteButton.Click += new EventHandler(this.deleteButton_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) componentResourceManager.GetObject("$this.BackgroundImage");
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(884, 561);
      this.Controls.Add((Control) this.deleteButton);
      this.Controls.Add((Control) this.showFullList);
      this.Controls.Add((Control) this.searchComponentsButton);
      this.Controls.Add((Control) this.SearchWord);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.componentsView);
      this.Controls.Add((Control) this.label2);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.Name = nameof (DeleteComponent);
      this.Text = "DeleteTrial";
      this.FormClosed += new FormClosedEventHandler(this.DeleteTrial_FormClosed);
      this.Load += new EventHandler(this.DeleteTrial_Load);
      ((ISupportInitialize) this.componentsView).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
