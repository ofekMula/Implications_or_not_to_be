

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
        private Button fileChoserButton;
        private OpenFileDialog openFileDialog1;
        private Button cancelUpdateButton;
        private Label label5;
        private PictureBox componentImage;
        private String componentImageUrl;

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
            this.componentImageUrl = Tools.DataBase[this.selectedComponentIndex].getImage();
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
            Tools.DataBase[this.selectedComponentIndex].setComponentImage(this.componentImageUrl);
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
            this.openFileDialog1.FileName = "";
            this.componentImageUrl = "";
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateComponent));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chooseComponentButton = new System.Windows.Forms.Button();
            this.componentsNameList = new System.Windows.Forms.ComboBox();
            this.updatedComponentNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.updateComponentButton = new System.Windows.Forms.Button();
            this.UpdatedDescriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.deleteFaultFromListButton = new System.Windows.Forms.Button();
            this.clearFaultsListButton = new System.Windows.Forms.Button();
            this.FaultsView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.updateFaultButton = new System.Windows.Forms.Button();
            this.addFaultButton = new System.Windows.Forms.Button();
            this.cancelUpdateButton = new System.Windows.Forms.Button();
            this.fileChoserButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.componentImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FaultsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.componentImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(795, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(524, 93);
            this.label2.TabIndex = 3;
            this.label2.Text = "עדכון רכיב קיים";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1116, 139);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(185, 51);
            this.label3.TabIndex = 6;
            this.label3.Text = "בחר רכיב:\r\n";
            // 
            // chooseComponentButton
            // 
            this.chooseComponentButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseComponentButton.Location = new System.Drawing.Point(659, 141);
            this.chooseComponentButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chooseComponentButton.Name = "chooseComponentButton";
            this.chooseComponentButton.Size = new System.Drawing.Size(112, 43);
            this.chooseComponentButton.TabIndex = 8;
            this.chooseComponentButton.Text = "הצגה";
            this.chooseComponentButton.UseVisualStyleBackColor = true;
            this.chooseComponentButton.Click += new System.EventHandler(this.chooseComponentButton_Click);
            // 
            // componentsNameList
            // 
            this.componentsNameList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.componentsNameList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.componentsNameList.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.componentsNameList.FormattingEnabled = true;
            this.componentsNameList.Location = new System.Drawing.Point(779, 148);
            this.componentsNameList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.componentsNameList.Name = "componentsNameList";
            this.componentsNameList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.componentsNameList.Size = new System.Drawing.Size(340, 35);
            this.componentsNameList.TabIndex = 7;
            this.componentsNameList.SelectedIndexChanged += new System.EventHandler(this.componentsNameList_SelectedIndexChanged);
            // 
            // updatedComponentNameTextBox
            // 
            this.updatedComponentNameTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updatedComponentNameTextBox.Location = new System.Drawing.Point(814, 217);
            this.updatedComponentNameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.updatedComponentNameTextBox.MaxLength = 3000;
            this.updatedComponentNameTextBox.Name = "updatedComponentNameTextBox";
            this.updatedComponentNameTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.updatedComponentNameTextBox.Size = new System.Drawing.Size(282, 31);
            this.updatedComponentNameTextBox.TabIndex = 10;
            this.updatedComponentNameTextBox.TextChanged += new System.EventHandler(this.componentNameTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1092, 205);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(208, 43);
            this.label1.TabIndex = 9;
            this.label1.Text = "שינוי שם רכיב:";
            // 
            // updateComponentButton
            // 
            this.updateComponentButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.updateComponentButton.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateComponentButton.ForeColor = System.Drawing.Color.White;
            this.updateComponentButton.Location = new System.Drawing.Point(18, 729);
            this.updateComponentButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.updateComponentButton.Name = "updateComponentButton";
            this.updateComponentButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.updateComponentButton.Size = new System.Drawing.Size(255, 108);
            this.updateComponentButton.TabIndex = 13;
            this.updateComponentButton.Text = "שמירת שינויים";
            this.updateComponentButton.UseVisualStyleBackColor = true;
            this.updateComponentButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // UpdatedDescriptionTextBox
            // 
            this.UpdatedDescriptionTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatedDescriptionTextBox.Location = new System.Drawing.Point(763, 433);
            this.UpdatedDescriptionTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UpdatedDescriptionTextBox.Name = "UpdatedDescriptionTextBox";
            this.UpdatedDescriptionTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UpdatedDescriptionTextBox.Size = new System.Drawing.Size(529, 112);
            this.UpdatedDescriptionTextBox.TabIndex = 26;
            this.UpdatedDescriptionTextBox.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1027, 385);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(273, 43);
            this.label4.TabIndex = 27;
            this.label4.Text = "עדכון לתאור הרכיב:";
            // 
            // deleteFaultFromListButton
            // 
            this.deleteFaultFromListButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.deleteFaultFromListButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteFaultFromListButton.Location = new System.Drawing.Point(430, 749);
            this.deleteFaultFromListButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deleteFaultFromListButton.Name = "deleteFaultFromListButton";
            this.deleteFaultFromListButton.Size = new System.Drawing.Size(150, 77);
            this.deleteFaultFromListButton.TabIndex = 43;
            this.deleteFaultFromListButton.Text = "מחק תקלה";
            this.deleteFaultFromListButton.UseVisualStyleBackColor = true;
            this.deleteFaultFromListButton.Click += new System.EventHandler(this.deleteFaultFromListButton_Click);
            // 
            // clearFaultsListButton
            // 
            this.clearFaultsListButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.clearFaultsListButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearFaultsListButton.Location = new System.Drawing.Point(430, 663);
            this.clearFaultsListButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clearFaultsListButton.Name = "clearFaultsListButton";
            this.clearFaultsListButton.Size = new System.Drawing.Size(150, 77);
            this.clearFaultsListButton.TabIndex = 42;
            this.clearFaultsListButton.Text = "איפוס רשימת תקלות";
            this.clearFaultsListButton.UseVisualStyleBackColor = true;
            this.clearFaultsListButton.Click += new System.EventHandler(this.clearFaultsListButton_Click);
            // 
            // FaultsView
            // 
            this.FaultsView.AllowUserToAddRows = false;
            this.FaultsView.AllowUserToDeleteRows = false;
            this.FaultsView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FaultsView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.FaultsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FaultsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.FaultsView.Location = new System.Drawing.Point(590, 555);
            this.FaultsView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FaultsView.MultiSelect = false;
            this.FaultsView.Name = "FaultsView";
            this.FaultsView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FaultsView.RowHeadersVisible = false;
            this.FaultsView.RowHeadersWidth = 62;
            this.FaultsView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FaultsView.Size = new System.Drawing.Size(702, 271);
            this.FaultsView.TabIndex = 40;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.HeaderText = "שם התקלה";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "משמעויות";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(896, 505);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(378, 43);
            this.label8.TabIndex = 41;
            this.label8.Text = "רשימת התקלות של הרכיב:";
            // 
            // updateFaultButton
            // 
            this.updateFaultButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.updateFaultButton.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateFaultButton.ForeColor = System.Drawing.Color.White;
            this.updateFaultButton.Location = new System.Drawing.Point(18, 651);
            this.updateFaultButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.updateFaultButton.Name = "updateFaultButton";
            this.updateFaultButton.Size = new System.Drawing.Size(255, 69);
            this.updateFaultButton.TabIndex = 45;
            this.updateFaultButton.Text = "לעדכון תקלה";
            this.updateFaultButton.UseVisualStyleBackColor = true;
            this.updateFaultButton.Click += new System.EventHandler(this.updateFaultButton_Click_1);
            // 
            // addFaultButton
            // 
            this.addFaultButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addFaultButton.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addFaultButton.ForeColor = System.Drawing.Color.White;
            this.addFaultButton.Location = new System.Drawing.Point(18, 572);
            this.addFaultButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addFaultButton.Name = "addFaultButton";
            this.addFaultButton.Size = new System.Drawing.Size(255, 69);
            this.addFaultButton.TabIndex = 44;
            this.addFaultButton.Text = "תקלה חדשה";
            this.addFaultButton.UseVisualStyleBackColor = true;
            this.addFaultButton.Click += new System.EventHandler(this.addFaultButton_Click);
            // 
            // cancelUpdateButton
            // 
            this.cancelUpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelUpdateButton.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelUpdateButton.ForeColor = System.Drawing.Color.White;
            this.cancelUpdateButton.Location = new System.Drawing.Point(18, 494);
            this.cancelUpdateButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelUpdateButton.Name = "cancelUpdateButton";
            this.cancelUpdateButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cancelUpdateButton.Size = new System.Drawing.Size(255, 69);
            this.cancelUpdateButton.TabIndex = 14;
            this.cancelUpdateButton.Text = "ניקוי שדות";
            this.cancelUpdateButton.UseVisualStyleBackColor = true;
            this.cancelUpdateButton.Click += new System.EventHandler(this.cancelUpdateButton_Click);
            // 
            // fileChoserButton
            // 
            this.fileChoserButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileChoserButton.Location = new System.Drawing.Point(857, 288);
            this.fileChoserButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fileChoserButton.Name = "fileChoserButton";
            this.fileChoserButton.Size = new System.Drawing.Size(162, 40);
            this.fileChoserButton.TabIndex = 53;
            this.fileChoserButton.Text = "בחירת קובץ";
            this.fileChoserButton.UseVisualStyleBackColor = true;
            this.fileChoserButton.Click += new System.EventHandler(this.fileChoserButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(1027, 285);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(276, 43);
            this.label5.TabIndex = 54;
            this.label5.Text = "עדכון תמונת הרכיב:";
            // 
            // componentImage
            // 
            this.componentImage.BackColor = System.Drawing.Color.Transparent;
            this.componentImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.componentImage.ErrorImage = null;
            this.componentImage.InitialImage = null;
            this.componentImage.Location = new System.Drawing.Point(448, 285);
            this.componentImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.componentImage.Name = "componentImage";
            this.componentImage.Size = new System.Drawing.Size(204, 185);
            this.componentImage.TabIndex = 55;
            this.componentImage.TabStop = false;
            // 
            // UpdateComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1326, 863);
            this.Controls.Add(this.componentImage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fileChoserButton);
            this.Controls.Add(this.updateFaultButton);
            this.Controls.Add(this.addFaultButton);
            this.Controls.Add(this.deleteFaultFromListButton);
            this.Controls.Add(this.clearFaultsListButton);
            this.Controls.Add(this.FaultsView);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UpdatedDescriptionTextBox);
            this.Controls.Add(this.cancelUpdateButton);
            this.Controls.Add(this.updateComponentButton);
            this.Controls.Add(this.updatedComponentNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chooseComponentButton);
            this.Controls.Add(this.componentsNameList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "UpdateComponent";
            this.Load += new System.EventHandler(this.UpdateComponent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FaultsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.componentImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

        private void fileChoserButton_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "All files (*.*)|*.*";
            if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            //this.fileDirectoryTextBox.Text = this.openFileDialog1.FileName;
            if (Tools.isUrlImage(this.openFileDialog1.FileName))
            {
                //this.pictureBox2.Load(this.openFileDialog1.FileName);
                this.componentImageUrl = this.openFileDialog1.FileName;
            }
            else
            {
                int num = (int)MessageBox.Show("יש לתת קישור לתמונות בלבד!");
            }
        }
    }
}
