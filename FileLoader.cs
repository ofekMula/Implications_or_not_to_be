// Decompiled with JetBrains decompiler
// Type: AlertsProject.FileLoader
// Assembly: AlertsProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01CC30A2-D287-482E-A95A-AE835F91B86F
// Assembly location: C:\Users\Ofek Mula\Desktop\AlertsProject.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AlertsProject
{
  public class FileLoader : Form
  {
    private IContainer components = (IContainer) null;
    private Form authentication;
    private Label label2;
    private Label label1;
    private TextBox fileDirectoryTextBox;
    private Button fileChoserButton;
    private Button loadExistsDbButton;
    private Button loadNewDbButton;
    private OpenFileDialog openFileDialog1;

    public FileLoader(Form authentication)
    {
      this.DoubleBuffered = true;
      this.InitializeComponent();
      this.authentication = authentication;
    }

    private void FileLoader_Load(object sender, EventArgs e)
    {
    }

    private void fileChoserButton_Click(object sender, EventArgs e)
    {
      this.openFileDialog1.Filter = "All files (*.*)|*.*";
      if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
        return;
      this.fileDirectoryTextBox.Text = this.openFileDialog1.FileName;
    }

    private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
    {
    }

    private void loadExistsDbButton_Click(object sender, EventArgs e)
    {
      if (Tools.isValidDataBaseDirectory(this.fileDirectoryTextBox.Text))
      {
        Tools.path = this.fileDirectoryTextBox.Text;
        this.updateLogFile();
        Tools.LoadNextWindow((Form) this, (Form) new Implications(this.authentication), true);
      }
      else
      {
        int num = (int) MessageBox.Show(Tools.DATABASE_DIRECTORY_ERROR, Tools.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void loadNewDbButton_Click(object sender, EventArgs e)
    {
      Tools.path = Environment.CurrentDirectory + Tools.PATH_DELIMETER + Tools.DEFAULT_FILENAME + Tools.DEFAULT_DATABASE_FILENAME_ENDING;
      this.updateLogFile();
      this.autoDefineNewDBFileName();
      Tools.LoadNextWindow((Form) this, (Form) new Implications(this.authentication), true);
    }

    private void FileLoader_FormClosed(object sender, FormClosedEventArgs e)
    {
      Application.Exit();
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void label2_Click(object sender, EventArgs e)
    {
    }

    private void fileDirectoryTextBox_TextChanged(object sender, EventArgs e)
    {
    }

    private void autoDefineNewDBFileName()
    {
      int num = 1;
      while (File.Exists(Tools.path))
      {
        Tools.path = Environment.CurrentDirectory + Tools.PATH_DELIMETER + Tools.DEFAULT_FILENAME + num.ToString() + Tools.DEFAULT_DATABASE_FILENAME_ENDING;
        ++num;
      }
    }

    private void updateLogFile()
    {
      if (!File.Exists(Tools.LOG_LAST_DB_FILE_PATH))
        File.Create(Tools.LOG_LAST_DB_FILE_PATH)?.Close();
      StreamWriter streamWriter = new StreamWriter(Tools.LOG_LAST_DB_FILE_PATH);
      streamWriter.WriteLine(Tools.path);
      streamWriter.Close();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FileLoader));
      this.label2 = new Label();
      this.label1 = new Label();
      this.fileDirectoryTextBox = new TextBox();
      this.fileChoserButton = new Button();
      this.loadExistsDbButton = new Button();
      this.loadNewDbButton = new Button();
      this.openFileDialog1 = new OpenFileDialog();
      this.SuspendLayout();
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Century Gothic", 48f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(290, 9);
      this.label2.Name = "label2";
      this.label2.RightToLeft = RightToLeft.Yes;
      this.label2.Size = new Size(482, 77);
      this.label2.TabIndex = 4;
      this.label2.Text = "טעינת בסיס נתונים";
      this.label2.Click += new EventHandler(this.label2_Click);
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Century Gothic", 26.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(453, 156);
      this.label1.Name = "label1";
      this.label1.RightToLeft = RightToLeft.Yes;
      this.label1.Size = new Size(313, 41);
      this.label1.TabIndex = 5;
      this.label1.Text = "נא לבחור מסד נתונים:";
      this.label1.Click += new EventHandler(this.label1_Click);
      this.fileDirectoryTextBox.Font = new Font("Century Gothic", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.fileDirectoryTextBox.Location = new Point(221, 213);
      this.fileDirectoryTextBox.Name = "fileDirectoryTextBox";
      this.fileDirectoryTextBox.Size = new Size(538, 26);
      this.fileDirectoryTextBox.TabIndex = 6;
      this.fileDirectoryTextBox.TextChanged += new EventHandler(this.fileDirectoryTextBox_TextChanged);
      this.fileChoserButton.Font = new Font("Century Gothic", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.fileChoserButton.Location = new Point(107, 213);
      this.fileChoserButton.Name = "fileChoserButton";
      this.fileChoserButton.Size = new Size(108, 26);
      this.fileChoserButton.TabIndex = 7;
      this.fileChoserButton.Text = "בחירת קובץ";
      this.fileChoserButton.UseVisualStyleBackColor = true;
      this.fileChoserButton.Click += new EventHandler(this.fileChoserButton_Click);
      this.loadExistsDbButton.FlatStyle = FlatStyle.System;
      this.loadExistsDbButton.Font = new Font("Century Gothic", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.loadExistsDbButton.ForeColor = Color.White;
      this.loadExistsDbButton.Location = new Point(610, 268);
      this.loadExistsDbButton.Name = "loadExistsDbButton";
      this.loadExistsDbButton.Size = new Size(150, 70);
      this.loadExistsDbButton.TabIndex = 8;
      this.loadExistsDbButton.Text = "טעינת מסד נתונים קיים";
      this.loadExistsDbButton.UseVisualStyleBackColor = true;
      this.loadExistsDbButton.Click += new EventHandler(this.loadExistsDbButton_Click);
      this.loadNewDbButton.FlatStyle = FlatStyle.System;
      this.loadNewDbButton.Font = new Font("Century Gothic", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.loadNewDbButton.ForeColor = Color.White;
      this.loadNewDbButton.Location = new Point(610, 354);
      this.loadNewDbButton.Name = "loadNewDbButton";
      this.loadNewDbButton.Size = new Size(150, 70);
      this.loadNewDbButton.TabIndex = 9;
      this.loadNewDbButton.Text = "יצירת מסד נתונים חדש";
      this.loadNewDbButton.UseVisualStyleBackColor = true;
      this.loadNewDbButton.Click += new EventHandler(this.loadNewDbButton_Click);
      this.openFileDialog1.FileName = "openFileDialog1";
      this.openFileDialog1.FileOk += new CancelEventHandler(this.openFileDialog1_FileOk);
      this.AcceptButton = (IButtonControl) this.loadExistsDbButton;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) componentResourceManager.GetObject("$this.BackgroundImage");
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(784, 461);
      this.Controls.Add((Control) this.loadNewDbButton);
      this.Controls.Add((Control) this.loadExistsDbButton);
      this.Controls.Add((Control) this.fileChoserButton);
      this.Controls.Add((Control) this.fileDirectoryTextBox);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.label2);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.Name = nameof (FileLoader);
      this.Text = "Delete";
      this.FormClosed += new FormClosedEventHandler(this.FileLoader_FormClosed);
      this.Load += new EventHandler(this.FileLoader_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
