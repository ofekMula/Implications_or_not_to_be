

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
        private RichTextBox solutionTextBox;
        private Label label3;
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
            this.currentFaultsList[this.selectedFaultIndex].setSolution(this.solutionTextBox.Text);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateFault));
            this.label4 = new System.Windows.Forms.Label();
            this.implicationsTextBox = new System.Windows.Forms.RichTextBox();
            this.FaultsNamesComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.updatedFaultNameTextBox = new System.Windows.Forms.TextBox();
            this.updateFaultButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.deleteAffectedComponentButton = new System.Windows.Forms.Button();
            this.resetAffectedComponentListButton = new System.Windows.Forms.Button();
            this.addAffectedComponentButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.affectedComponentsNameList = new System.Windows.Forms.ComboBox();
            this.affectedComponentsView = new System.Windows.Forms.DataGridView();
            this.FaultsHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.implicationsHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chooseFaultButton = new System.Windows.Forms.Button();
            this.cancelUpdateButton = new System.Windows.Forms.Button();
            this.solutionTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.affectedComponentsView)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(705, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(616, 93);
            this.label4.TabIndex = 21;
            this.label4.Text = "עדכון תקלה קיימת";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // implicationsTextBox
            // 
            this.implicationsTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.implicationsTextBox.Location = new System.Drawing.Point(820, 362);
            this.implicationsTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.implicationsTextBox.Name = "implicationsTextBox";
            this.implicationsTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.implicationsTextBox.Size = new System.Drawing.Size(470, 138);
            this.implicationsTextBox.TabIndex = 22;
            this.implicationsTextBox.Text = "";
            this.implicationsTextBox.TextChanged += new System.EventHandler(this.implicationsTextBox_TextChanged);
            // 
            // FaultsNamesComboBox
            // 
            this.FaultsNamesComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.FaultsNamesComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.FaultsNamesComboBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FaultsNamesComboBox.FormattingEnabled = true;
            this.FaultsNamesComboBox.Location = new System.Drawing.Point(642, 160);
            this.FaultsNamesComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FaultsNamesComboBox.Name = "FaultsNamesComboBox";
            this.FaultsNamesComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FaultsNamesComboBox.Size = new System.Drawing.Size(268, 38);
            this.FaultsNamesComboBox.TabIndex = 23;
            this.FaultsNamesComboBox.SelectedIndexChanged += new System.EventHandler(this.FaultsNamesComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(1071, 236);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(229, 43);
            this.label5.TabIndex = 24;
            this.label5.Text = "שינוי שם תקלה:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(907, 311);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(391, 43);
            this.label6.TabIndex = 26;
            this.label6.Text = "עדכון משמעויות של התקלה:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // updatedFaultNameTextBox
            // 
            this.updatedFaultNameTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updatedFaultNameTextBox.Location = new System.Drawing.Point(839, 248);
            this.updatedFaultNameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.updatedFaultNameTextBox.MaxLength = 3000;
            this.updatedFaultNameTextBox.Name = "updatedFaultNameTextBox";
            this.updatedFaultNameTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.updatedFaultNameTextBox.Size = new System.Drawing.Size(224, 31);
            this.updatedFaultNameTextBox.TabIndex = 25;
            this.updatedFaultNameTextBox.TextChanged += new System.EventHandler(this.updatedFaultNameTextBox_TextChanged);
            // 
            // updateFaultButton
            // 
            this.updateFaultButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.updateFaultButton.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateFaultButton.ForeColor = System.Drawing.Color.White;
            this.updateFaultButton.Location = new System.Drawing.Point(18, 725);
            this.updateFaultButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.updateFaultButton.Name = "updateFaultButton";
            this.updateFaultButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.updateFaultButton.Size = new System.Drawing.Size(255, 108);
            this.updateFaultButton.TabIndex = 28;
            this.updateFaultButton.Text = "עדכון תקלה";
            this.updateFaultButton.UseVisualStyleBackColor = true;
            this.updateFaultButton.Click += new System.EventHandler(this.updateFaultButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(921, 149);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(360, 51);
            this.label1.TabIndex = 29;
            this.label1.Text = "בחירת תקלה לעדכון:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // deleteAffectedComponentButton
            // 
            this.deleteAffectedComponentButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.deleteAffectedComponentButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteAffectedComponentButton.Location = new System.Drawing.Point(436, 746);
            this.deleteAffectedComponentButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deleteAffectedComponentButton.Name = "deleteAffectedComponentButton";
            this.deleteAffectedComponentButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.deleteAffectedComponentButton.Size = new System.Drawing.Size(142, 74);
            this.deleteAffectedComponentButton.TabIndex = 51;
            this.deleteAffectedComponentButton.Text = "מחיקת רכיב מהרשימה";
            this.deleteAffectedComponentButton.UseVisualStyleBackColor = true;
            this.deleteAffectedComponentButton.Click += new System.EventHandler(this.deleteAffectedComponentButton_Click);
            // 
            // resetAffectedComponentListButton
            // 
            this.resetAffectedComponentListButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.resetAffectedComponentListButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetAffectedComponentListButton.Location = new System.Drawing.Point(438, 663);
            this.resetAffectedComponentListButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.resetAffectedComponentListButton.Name = "resetAffectedComponentListButton";
            this.resetAffectedComponentListButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.resetAffectedComponentListButton.Size = new System.Drawing.Size(141, 74);
            this.resetAffectedComponentListButton.TabIndex = 50;
            this.resetAffectedComponentListButton.Text = "איפוס רכיבים מושפעים";
            this.resetAffectedComponentListButton.UseVisualStyleBackColor = true;
            this.resetAffectedComponentListButton.Click += new System.EventHandler(this.resetAffectedComponentListButton_Click);
            // 
            // addAffectedComponentButton
            // 
            this.addAffectedComponentButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addAffectedComponentButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAffectedComponentButton.Location = new System.Drawing.Point(592, 551);
            this.addAffectedComponentButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addAffectedComponentButton.Name = "addAffectedComponentButton";
            this.addAffectedComponentButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.addAffectedComponentButton.Size = new System.Drawing.Size(104, 37);
            this.addAffectedComponentButton.TabIndex = 49;
            this.addAffectedComponentButton.Text = "הוסף";
            this.addAffectedComponentButton.UseVisualStyleBackColor = true;
            this.addAffectedComponentButton.Click += new System.EventHandler(this.addAffectedComponentButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(994, 540);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(287, 43);
            this.label2.TabIndex = 48;
            this.label2.Text = "הוספת רכיב מושפע:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // affectedComponentsNameList
            // 
            this.affectedComponentsNameList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.affectedComponentsNameList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.affectedComponentsNameList.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.affectedComponentsNameList.FormattingEnabled = true;
            this.affectedComponentsNameList.Location = new System.Drawing.Point(705, 549);
            this.affectedComponentsNameList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.affectedComponentsNameList.Name = "affectedComponentsNameList";
            this.affectedComponentsNameList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.affectedComponentsNameList.Size = new System.Drawing.Size(289, 29);
            this.affectedComponentsNameList.TabIndex = 46;
            this.affectedComponentsNameList.SelectedIndexChanged += new System.EventHandler(this.affectedComponentsNameList_SelectedIndexChanged);
            // 
            // affectedComponentsView
            // 
            this.affectedComponentsView.AllowUserToAddRows = false;
            this.affectedComponentsView.AllowUserToDeleteRows = false;
            this.affectedComponentsView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.affectedComponentsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.affectedComponentsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FaultsHeader,
            this.implicationsHeader});
            this.affectedComponentsView.Location = new System.Drawing.Point(586, 617);
            this.affectedComponentsView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.affectedComponentsView.MultiSelect = false;
            this.affectedComponentsView.Name = "affectedComponentsView";
            this.affectedComponentsView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.affectedComponentsView.RowHeadersVisible = false;
            this.affectedComponentsView.RowHeadersWidth = 62;
            this.affectedComponentsView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.affectedComponentsView.Size = new System.Drawing.Size(706, 212);
            this.affectedComponentsView.TabIndex = 52;
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
            // chooseFaultButton
            // 
            this.chooseFaultButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseFaultButton.Location = new System.Drawing.Point(520, 160);
            this.chooseFaultButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chooseFaultButton.Name = "chooseFaultButton";
            this.chooseFaultButton.Size = new System.Drawing.Size(112, 45);
            this.chooseFaultButton.TabIndex = 53;
            this.chooseFaultButton.Text = "הצגה";
            this.chooseFaultButton.UseVisualStyleBackColor = true;
            this.chooseFaultButton.Click += new System.EventHandler(this.chooseFaultButton_Click);
            // 
            // cancelUpdateButton
            // 
            this.cancelUpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelUpdateButton.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelUpdateButton.ForeColor = System.Drawing.Color.White;
            this.cancelUpdateButton.Location = new System.Drawing.Point(18, 646);
            this.cancelUpdateButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelUpdateButton.Name = "cancelUpdateButton";
            this.cancelUpdateButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cancelUpdateButton.Size = new System.Drawing.Size(255, 69);
            this.cancelUpdateButton.TabIndex = 54;
            this.cancelUpdateButton.Text = "ניקוי שדות";
            this.cancelUpdateButton.UseVisualStyleBackColor = true;
            this.cancelUpdateButton.Click += new System.EventHandler(this.cancelUpdateButton_Click);
            // 
            // solutionTextBox
            // 
            this.solutionTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solutionTextBox.Location = new System.Drawing.Point(183, 362);
            this.solutionTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.solutionTextBox.Name = "solutionTextBox";
            this.solutionTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.solutionTextBox.Size = new System.Drawing.Size(470, 138);
            this.solutionTextBox.TabIndex = 55;
            this.solutionTextBox.Text = "";
            this.solutionTextBox.TextChanged += new System.EventHandler(this.solutionTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(380, 311);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(281, 43);
            this.label3.TabIndex = 56;
            this.label3.Text = "עדכון פתרון לתקלה:";
            // 
            // UpdateFault
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1326, 863);
            this.Controls.Add(this.solutionTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelUpdateButton);
            this.Controls.Add(this.chooseFaultButton);
            this.Controls.Add(this.affectedComponentsView);
            this.Controls.Add(this.deleteAffectedComponentButton);
            this.Controls.Add(this.resetAffectedComponentListButton);
            this.Controls.Add(this.addAffectedComponentButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.affectedComponentsNameList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.implicationsTextBox);
            this.Controls.Add(this.FaultsNamesComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.updatedFaultNameTextBox);
            this.Controls.Add(this.updateFaultButton);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "UpdateFault";
            this.Load += new System.EventHandler(this.UpdateFault_Load);
            ((System.ComponentModel.ISupportInitialize)(this.affectedComponentsView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

        private void solutionTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
