

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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedSearch));
            this.showFullList = new System.Windows.Forms.Button();
            this.searchComponentsButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.componentsView = new System.Windows.Forms.DataGridView();
            this.chooseHeader = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.componentNameHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.componentImplicationsHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.searchByWordTextBox = new System.Windows.Forms.TextBox();
            this.searchByChoiceButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.expandedDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.componentsView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // showFullList
            // 
            this.showFullList.BackColor = System.Drawing.SystemColors.Control;
            this.showFullList.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showFullList.ForeColor = System.Drawing.Color.Black;
            this.showFullList.Location = new System.Drawing.Point(346, 272);
            this.showFullList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.showFullList.Name = "showFullList";
            this.showFullList.Size = new System.Drawing.Size(237, 46);
            this.showFullList.TabIndex = 21;
            this.showFullList.Text = "הצגת כול הרכיבים";
            this.showFullList.UseVisualStyleBackColor = false;
            this.showFullList.Click += new System.EventHandler(this.showFullList_Click);
            // 
            // searchComponentsButton
            // 
            this.searchComponentsButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchComponentsButton.Location = new System.Drawing.Point(609, 272);
            this.searchComponentsButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchComponentsButton.Name = "searchComponentsButton";
            this.searchComponentsButton.Size = new System.Drawing.Size(122, 46);
            this.searchComponentsButton.TabIndex = 20;
            this.searchComponentsButton.Text = "חיפוש";
            this.searchComponentsButton.UseVisualStyleBackColor = true;
            this.searchComponentsButton.Click += new System.EventHandler(this.searchComponentsButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(972, 149);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(479, 59);
            this.label3.TabIndex = 17;
            this.label3.Text = "בחירת רכיב/ים לתצוגה:";
            // 
            // componentsView
            // 
            this.componentsView.AllowUserToAddRows = false;
            this.componentsView.AllowUserToDeleteRows = false;
            this.componentsView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.componentsView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.componentsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.componentsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chooseHeader,
            this.componentNameHeader,
            this.componentImplicationsHeader});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.componentsView.DefaultCellStyle = dataGridViewCellStyle2;
            this.componentsView.Location = new System.Drawing.Point(346, 378);
            this.componentsView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.componentsView.Name = "componentsView";
            this.componentsView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.componentsView.RowHeadersVisible = false;
            this.componentsView.RowHeadersWidth = 62;
            this.componentsView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.componentsView.Size = new System.Drawing.Size(1095, 342);
            this.componentsView.TabIndex = 16;
            this.componentsView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.componentsView_CellMouseUp);
            this.componentsView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.componentsView_MouseClick);
            // 
            // chooseHeader
            // 
            this.chooseHeader.HeaderText = "בחירה";
            this.chooseHeader.MinimumWidth = 8;
            this.chooseHeader.Name = "chooseHeader";
            this.chooseHeader.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.chooseHeader.Width = 70;
            // 
            // componentNameHeader
            // 
            this.componentNameHeader.HeaderText = "שם הרכיב";
            this.componentNameHeader.MinimumWidth = 8;
            this.componentNameHeader.Name = "componentNameHeader";
            this.componentNameHeader.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.componentNameHeader.Width = 150;
            // 
            // componentImplicationsHeader
            // 
            this.componentImplicationsHeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.componentImplicationsHeader.HeaderText = "תאור הרכיב";
            this.componentImplicationsHeader.MinimumWidth = 8;
            this.componentImplicationsHeader.Name = "componentImplicationsHeader";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(972, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(483, 93);
            this.label2.TabIndex = 15;
            this.label2.Text = "חיפוש מתקדם";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1125, 265);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(301, 43);
            this.label4.TabIndex = 22;
            this.label4.Text = "חיפוש רכיב לפי מילה:";
            // 
            // searchByWordTextBox
            // 
            this.searchByWordTextBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchByWordTextBox.Location = new System.Drawing.Point(740, 272);
            this.searchByWordTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchByWordTextBox.Name = "searchByWordTextBox";
            this.searchByWordTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.searchByWordTextBox.Size = new System.Drawing.Size(374, 37);
            this.searchByWordTextBox.TabIndex = 23;
            // 
            // searchByChoiceButton
            // 
            this.searchByChoiceButton.Font = new System.Drawing.Font("Century Gothic", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchByChoiceButton.ForeColor = System.Drawing.Color.Black;
            this.searchByChoiceButton.Location = new System.Drawing.Point(1174, 757);
            this.searchByChoiceButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchByChoiceButton.Name = "searchByChoiceButton";
            this.searchByChoiceButton.Size = new System.Drawing.Size(267, 51);
            this.searchByChoiceButton.TabIndex = 24;
            this.searchByChoiceButton.Text = "הצגה לפי בחירה";
            this.searchByChoiceButton.UseVisualStyleBackColor = true;
            this.searchByChoiceButton.Click += new System.EventHandler(this.searchByChoiceButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expandedDataToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(201, 36);
            // 
            // expandedDataToolStripMenuItem
            // 
            this.expandedDataToolStripMenuItem.Name = "expandedDataToolStripMenuItem";
            this.expandedDataToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.expandedDataToolStripMenuItem.Size = new System.Drawing.Size(200, 32);
            this.expandedDataToolStripMenuItem.Text = "פרוט על הרכיב";
            this.expandedDataToolStripMenuItem.Click += new System.EventHandler(this.expandedDataToolStripMenuItem_Click);
            // 
            // AdvancedSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1476, 863);
            this.Controls.Add(this.searchByChoiceButton);
            this.Controls.Add(this.searchByWordTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.showFullList);
            this.Controls.Add(this.searchComponentsButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.componentsView);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "AdvancedSearch";
            this.Load += new System.EventHandler(this.AdvancedSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.componentsView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
  }
}
