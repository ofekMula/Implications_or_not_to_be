// Decompiled with JetBrains decompiler
// Type: AlertsProject.AdvancedSearch
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
  public class AdvancedSearch : Form
  {
    private IContainer components = (IContainer) null;
    private int currentRowIndex;
    private ComboBox componentsSelection;
    private Form implicationsWindow;
    private Button showFullList;
    private Button searchComponentsButton;
    private Label label3;
    private DataGridView componentsView;
    private Label label2;
    private Label label4;
    private TextBox searchByWordTextBox;
    private Button searchByChoiceButton;
    private DataGridViewCheckBoxColumn chooseHeader;
    private DataGridViewTextBoxColumn componentNameHeader;
    private DataGridViewTextBoxColumn componentImplicationsHeader;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem expandedDataToolStripMenuItem;

    public AdvancedSearch()
    {
      this.DoubleBuffered = true;
      this.InitializeComponent();
    }

    public AdvancedSearch(ComboBox componentsSelection)
    {
      this.DoubleBuffered = true;
      this.InitializeComponent();
      this.componentsSelection = componentsSelection;
    }

    public AdvancedSearch(Form implicationsWindow, ComboBox componentsSelection)
    {
      this.DoubleBuffered = true;
      this.InitializeComponent();
      this.implicationsWindow = implicationsWindow;
      this.componentsSelection = componentsSelection;
    }

    private void AdvancedSearch_Load(object sender, EventArgs e)
    {
      Tools.loadListIntoDataGridView(Tools.DataBase, this.componentsView, true);
    }

    private void searchComponentsButton_Click(object sender, EventArgs e)
    {
      this.searchAndDisplayComponent(this.searchByWordTextBox.Text);
    }

    private void searchAndDisplayComponent(string word)
    {
      if (Tools.isNotEmptyString(word))
      {
        List<SystemComponent> matchedListByWord = Tools.createMatchedListByWord(word);
        this.componentsView.Rows.Clear();
        Tools.loadListIntoDataGridView(matchedListByWord, this.componentsView, true);
        int count = matchedListByWord.Count;
        this.componentsView.ClearSelection();
        int num = (int) MessageBox.Show(Tools.MATCHING_RESULT + count.ToString(), Tools.INFORMATION, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        int num1 = (int) MessageBox.Show(Tools.SEARCH_WORD_ERROR, Tools.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void showFullList_Click(object sender, EventArgs e)
    {
      Tools.loadListIntoDataGridView(Tools.DataBase, this.componentsView, true);
    }

    private void searchByChoiceButton_Click(object sender, EventArgs e)
    {
      if (Tools.countCheckedComponents(this.componentsView) > 0)
      {
        Tools.loadListIntoDataGridView(Tools.selectedItemsList(this.componentsView), this.componentsView, true);
      }
      else
      {
        int num = (int) MessageBox.Show(Tools.CHOOSE_COMPONENT_ERROR, Tools.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void componentsView_MouseClick(object sender, MouseEventArgs e)
    {
    }

    private void componentsView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;
      this.componentsView.Rows[e.RowIndex].Selected = true;
      this.currentRowIndex = e.RowIndex;
      this.componentsView.CurrentCell = this.componentsView.Rows[e.RowIndex].Cells[1];
      this.contextMenuStrip1.Show((Control) this.componentsView, e.Location);
      this.contextMenuStrip1.Show(Cursor.Position);
    }

    private void expandedDataToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string name = (string) this.componentsView.Rows[this.currentRowIndex].Cells[1].Value;
      int listOfComponents = Tools.findComponentIndexInListOfComponents(Tools.DataBase, name);
      Tools.ResetAllControls((Control) this.implicationsWindow);
      this.componentsSelection.SelectedIndex = listOfComponents;
      this.Close();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AdvancedSearch));
      this.showFullList = new Button();
      this.searchComponentsButton = new Button();
      this.label3 = new Label();
      this.componentsView = new DataGridView();
      this.chooseHeader = new DataGridViewCheckBoxColumn();
      this.componentNameHeader = new DataGridViewTextBoxColumn();
      this.componentImplicationsHeader = new DataGridViewTextBoxColumn();
      this.label2 = new Label();
      this.label4 = new Label();
      this.searchByWordTextBox = new TextBox();
      this.searchByChoiceButton = new Button();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.expandedDataToolStripMenuItem = new ToolStripMenuItem();
      ((ISupportInitialize) this.componentsView).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.showFullList.BackColor = SystemColors.Control;
      this.showFullList.Font = new Font("Century Gothic", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.showFullList.ForeColor = Color.Black;
      this.showFullList.Location = new Point(231, 177);
      this.showFullList.Name = "showFullList";
      this.showFullList.Size = new Size(158, 30);
      this.showFullList.TabIndex = 21;
      this.showFullList.Text = "הצגת כול הרכיבים";
      this.showFullList.UseVisualStyleBackColor = false;
      this.showFullList.Click += new EventHandler(this.showFullList_Click);
      this.searchComponentsButton.Font = new Font("Century Gothic", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.searchComponentsButton.Location = new Point(406, 177);
      this.searchComponentsButton.Name = "searchComponentsButton";
      this.searchComponentsButton.Size = new Size(81, 30);
      this.searchComponentsButton.TabIndex = 20;
      this.searchComponentsButton.Text = "חיפוש";
      this.searchComponentsButton.UseVisualStyleBackColor = true;
      this.searchComponentsButton.Click += new EventHandler(this.searchComponentsButton_Click);
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Century Gothic", 24.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.Black;
      this.label3.Location = new Point(679, 98);
      this.label3.Name = "label3";
      this.label3.RightToLeft = RightToLeft.Yes;
      this.label3.Size = new Size(289, 39);
      this.label3.TabIndex = 17;
      this.label3.Text = "בחירת רכיב/ים לתצוגה:";
      this.componentsView.AllowUserToAddRows = false;
      this.componentsView.AllowUserToDeleteRows = false;
      this.componentsView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle1.BackColor = SystemColors.Control;
      gridViewCellStyle1.Font = new Font("Century Gothic", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle1.ForeColor = SystemColors.WindowText;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.componentsView.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.componentsView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.componentsView.Columns.AddRange((DataGridViewColumn) this.chooseHeader, (DataGridViewColumn) this.componentNameHeader, (DataGridViewColumn) this.componentImplicationsHeader);
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = SystemColors.Window;
      gridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 177);
      gridViewCellStyle2.ForeColor = SystemColors.ControlText;
      gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.True;
      this.componentsView.DefaultCellStyle = gridViewCellStyle2;
      this.componentsView.Location = new Point(231, 246);
      this.componentsView.Name = "componentsView";
      this.componentsView.RightToLeft = RightToLeft.Yes;
      this.componentsView.RowHeadersVisible = false;
      this.componentsView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.componentsView.Size = new Size(730, 222);
      this.componentsView.TabIndex = 16;
      this.componentsView.CellMouseUp += new DataGridViewCellMouseEventHandler(this.componentsView_CellMouseUp);
      this.componentsView.MouseClick += new MouseEventHandler(this.componentsView_MouseClick);
      this.chooseHeader.HeaderText = "בחירה";
      this.chooseHeader.Name = "chooseHeader";
      this.chooseHeader.SortMode = DataGridViewColumnSortMode.Automatic;
      this.chooseHeader.Width = 70;
      this.componentNameHeader.HeaderText = "שם הרכיב";
      this.componentNameHeader.Name = "componentNameHeader";
      this.componentNameHeader.Resizable = DataGridViewTriState.True;
      this.componentNameHeader.Width = 150;
      this.componentImplicationsHeader.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.componentImplicationsHeader.HeaderText = "תאור הרכיב";
      this.componentImplicationsHeader.Name = "componentImplicationsHeader";
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Century Gothic", 39.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(657, 9);
      this.label2.Name = "label2";
      this.label2.RightToLeft = RightToLeft.Yes;
      this.label2.Size = new Size(315, 63);
      this.label2.TabIndex = 15;
      this.label2.Text = "חיפוש מתקדם";
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.Font = new Font("Century Gothic", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.Black;
      this.label4.Location = new Point(750, 172);
      this.label4.Name = "label4";
      this.label4.RightToLeft = RightToLeft.Yes;
      this.label4.Size = new Size(216, 30);
      this.label4.TabIndex = 22;
      this.label4.Text = "חיפוש רכיב לפי מילה:";
      this.searchByWordTextBox.Font = new Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.searchByWordTextBox.Location = new Point(493, 177);
      this.searchByWordTextBox.Name = "searchByWordTextBox";
      this.searchByWordTextBox.RightToLeft = RightToLeft.Yes;
      this.searchByWordTextBox.Size = new Size(251, 27);
      this.searchByWordTextBox.TabIndex = 23;
      this.searchByChoiceButton.Font = new Font("Century Gothic", 17.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.searchByChoiceButton.ForeColor = Color.Black;
      this.searchByChoiceButton.Location = new Point(783, 492);
      this.searchByChoiceButton.Name = "searchByChoiceButton";
      this.searchByChoiceButton.Size = new Size(178, 33);
      this.searchByChoiceButton.TabIndex = 24;
      this.searchByChoiceButton.Text = "הצגה לפי בחירה";
      this.searchByChoiceButton.UseVisualStyleBackColor = true;
      this.searchByChoiceButton.Click += new EventHandler(this.searchByChoiceButton_Click);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.expandedDataToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(153, 26);
      this.expandedDataToolStripMenuItem.Name = "expandedDataToolStripMenuItem";
      this.expandedDataToolStripMenuItem.RightToLeft = RightToLeft.Yes;
      this.expandedDataToolStripMenuItem.Size = new Size(152, 22);
      this.expandedDataToolStripMenuItem.Text = "פרוט על הרכיב";
      this.expandedDataToolStripMenuItem.Click += new EventHandler(this.expandedDataToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) componentResourceManager.GetObject("$this.BackgroundImage");
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(984, 561);
      this.Controls.Add((Control) this.searchByChoiceButton);
      this.Controls.Add((Control) this.searchByWordTextBox);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.showFullList);
      this.Controls.Add((Control) this.searchComponentsButton);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.componentsView);
      this.Controls.Add((Control) this.label2);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.Name = nameof (AdvancedSearch);
      this.Text = nameof (AdvancedSearch);
      this.Load += new EventHandler(this.AdvancedSearch_Load);
      ((ISupportInitialize) this.componentsView).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
