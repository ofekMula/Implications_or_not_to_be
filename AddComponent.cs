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
        private PictureBox pictureBox2;
        private Button fileChoserButton;
        private Label label1;
        private OpenFileDialog openFileDialog1;

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



    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddComponent));
            this.descriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.componentNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FaultsView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.addNewFaultButton = new System.Windows.Forms.Button();
            this.addComponentButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.fileChoserButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FaultsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTextBox.Location = new System.Drawing.Point(766, 314);
            this.descriptionTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.descriptionTextBox.Size = new System.Drawing.Size(523, 152);
            this.descriptionTextBox.TabIndex = 34;
            this.descriptionTextBox.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(1053, 140);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(265, 69);
            this.label10.TabIndex = 35;
            this.label10.Text = "שם הרכיב:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(1068, 254);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(226, 55);
            this.label11.TabIndex = 36;
            this.label11.Text = "תיאור הרכיב:";
            // 
            // componentNameTextBox
            // 
            this.componentNameTextBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.componentNameTextBox.Location = new System.Drawing.Point(708, 165);
            this.componentNameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.componentNameTextBox.MaxLength = 3000;
            this.componentNameTextBox.Name = "componentNameTextBox";
            this.componentNameTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.componentNameTextBox.Size = new System.Drawing.Size(334, 37);
            this.componentNameTextBox.TabIndex = 37;
            this.componentNameTextBox.TextChanged += new System.EventHandler(this.componentNameTextBox_TextChanged_1);
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
            this.label2.Size = new System.Drawing.Size(581, 93);
            this.label2.TabIndex = 33;
            this.label2.Text = "הוספת רכיב חדש";
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
            this.FaultsView.Location = new System.Drawing.Point(525, 574);
            this.FaultsView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FaultsView.MultiSelect = false;
            this.FaultsView.Name = "FaultsView";
            this.FaultsView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FaultsView.RowHeadersVisible = false;
            this.FaultsView.RowHeadersWidth = 62;
            this.FaultsView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FaultsView.Size = new System.Drawing.Size(766, 271);
            this.FaultsView.TabIndex = 42;
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
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(896, 508);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(378, 43);
            this.label8.TabIndex = 43;
            this.label8.Text = "רשימת התקלות של הרכיב:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // addNewFaultButton
            // 
            this.addNewFaultButton.BackColor = System.Drawing.Color.Transparent;
            this.addNewFaultButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.addNewFaultButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addNewFaultButton.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewFaultButton.ForeColor = System.Drawing.Color.White;
            this.addNewFaultButton.Location = new System.Drawing.Point(18, 662);
            this.addNewFaultButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addNewFaultButton.Name = "addNewFaultButton";
            this.addNewFaultButton.Size = new System.Drawing.Size(255, 69);
            this.addNewFaultButton.TabIndex = 46;
            this.addNewFaultButton.Text = "תקלה חדשה";
            this.addNewFaultButton.UseVisualStyleBackColor = false;
            this.addNewFaultButton.Click += new System.EventHandler(this.addNewFaultButton_Click);
            // 
            // addComponentButton
            // 
            this.addComponentButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.addComponentButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addComponentButton.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addComponentButton.ForeColor = System.Drawing.Color.White;
            this.addComponentButton.Location = new System.Drawing.Point(18, 740);
            this.addComponentButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addComponentButton.Name = "addComponentButton";
            this.addComponentButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.addComponentButton.Size = new System.Drawing.Size(255, 108);
            this.addComponentButton.TabIndex = 45;
            this.addComponentButton.Text = "הוספת רכיב למאגר";
            this.addComponentButton.UseVisualStyleBackColor = true;
            this.addComponentButton.Click += new System.EventHandler(this.addComponentButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(18, 583);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(255, 69);
            this.button1.TabIndex = 47;
            this.button1.Text = "ניקוי שדות";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(424, 314);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(262, 224);
            this.pictureBox2.TabIndex = 51;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // fileChoserButton
            // 
            this.fileChoserButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileChoserButton.Location = new System.Drawing.Point(178, 269);
            this.fileChoserButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fileChoserButton.Name = "fileChoserButton";
            this.fileChoserButton.Size = new System.Drawing.Size(162, 40);
            this.fileChoserButton.TabIndex = 50;
            this.fileChoserButton.Text = "בחירת קובץ";
            this.fileChoserButton.UseVisualStyleBackColor = true;
            this.fileChoserButton.Click += new System.EventHandler(this.fileChoserButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(348, 254);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(348, 55);
            this.label1.TabIndex = 52;
            this.label1.Text = "הוספת תמונה לרכיב:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // AddComponent
            // 
            this.AcceptButton = this.addComponentButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1326, 863);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.fileChoserButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addNewFaultButton);
            this.Controls.Add(this.addComponentButton);
            this.Controls.Add(this.FaultsView);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.componentNameTextBox);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "AddComponent";
            this.Load += new System.EventHandler(this.AddComponent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FaultsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
                this.pictureBox2.Load(this.openFileDialog1.FileName);
                this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                this.componentImageUrl= this.openFileDialog1.FileName;
            }
            else
            {
                int num = (int)MessageBox.Show("יש לתת קישור לתמונות בלבד!");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
