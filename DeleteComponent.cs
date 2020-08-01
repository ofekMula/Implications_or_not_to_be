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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteComponent));
            this.label2 = new System.Windows.Forms.Label();
            this.componentsView = new System.Windows.Forms.DataGridView();
            this.chooseHeader = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.componentNameHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.componentImplicationsHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchWord = new System.Windows.Forms.TextBox();
            this.searchComponentsButton = new System.Windows.Forms.Button();
            this.showFullList = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.componentsView)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(742, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(577, 93);
            this.label2.TabIndex = 4;
            this.label2.Text = "מחיקת רכיב קיים";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // componentsView
            // 
            this.componentsView.AllowUserToAddRows = false;
            this.componentsView.AllowUserToDeleteRows = false;
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
            this.componentsView.Location = new System.Drawing.Point(106, 386);
            this.componentsView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.componentsView.Name = "componentsView";
            this.componentsView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.componentsView.RowHeadersVisible = false;
            this.componentsView.RowHeadersWidth = 62;
            this.componentsView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.componentsView.Size = new System.Drawing.Size(1185, 386);
            this.componentsView.TabIndex = 5;
            this.componentsView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.componentsView_CellContentClick);
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
            this.componentNameHeader.MinimumWidth = 2;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(784, 171);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(518, 63);
            this.label3.TabIndex = 10;
            this.label3.Text = "בחירת רכיב/ים למחיקה:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(975, 275);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(301, 43);
            this.label1.TabIndex = 11;
            this.label1.Text = "חיפוש רכיב לפי מילה:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // SearchWord
            // 
            this.SearchWord.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchWord.Location = new System.Drawing.Point(590, 275);
            this.SearchWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SearchWord.Name = "SearchWord";
            this.SearchWord.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SearchWord.Size = new System.Drawing.Size(374, 37);
            this.SearchWord.TabIndex = 12;
            this.SearchWord.TextChanged += new System.EventHandler(this.SearchWord_TextChanged);
            // 
            // searchComponentsButton
            // 
            this.searchComponentsButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchComponentsButton.Location = new System.Drawing.Point(441, 271);
            this.searchComponentsButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchComponentsButton.Name = "searchComponentsButton";
            this.searchComponentsButton.Size = new System.Drawing.Size(122, 46);
            this.searchComponentsButton.TabIndex = 13;
            this.searchComponentsButton.Text = "חיפוש";
            this.searchComponentsButton.UseVisualStyleBackColor = true;
            this.searchComponentsButton.Click += new System.EventHandler(this.searchComponentsButton_Click);
            // 
            // showFullList
            // 
            this.showFullList.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showFullList.Location = new System.Drawing.Point(106, 271);
            this.showFullList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.showFullList.Name = "showFullList";
            this.showFullList.Size = new System.Drawing.Size(248, 46);
            this.showFullList.TabIndex = 14;
            this.showFullList.Text = "הצגת הרשימה המלאה";
            this.showFullList.UseVisualStyleBackColor = true;
            this.showFullList.Click += new System.EventHandler(this.showFullList_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.deleteButton.Font = new System.Drawing.Font("Century Gothic", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(1086, 782);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.deleteButton.Size = new System.Drawing.Size(206, 48);
            this.deleteButton.TabIndex = 15;
            this.deleteButton.Text = "מחיקת רכיב";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // DeleteComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1326, 863);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.showFullList);
            this.Controls.Add(this.searchComponentsButton);
            this.Controls.Add(this.SearchWord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.componentsView);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "DeleteComponent";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DeleteTrial_FormClosed);
            this.Load += new System.EventHandler(this.DeleteTrial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.componentsView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
  }
}
