

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileLoader));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fileDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.fileChoserButton = new System.Windows.Forms.Button();
            this.loadExistsDbButton = new System.Windows.Forms.Button();
            this.loadNewDbButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(435, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(739, 112);
            this.label2.TabIndex = 4;
            this.label2.Text = "טעינת בסיס נתונים";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(680, 240);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(469, 63);
            this.label1.TabIndex = 5;
            this.label1.Text = "נא לבחור מסד נתונים:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // fileDirectoryTextBox
            // 
            this.fileDirectoryTextBox.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileDirectoryTextBox.Location = new System.Drawing.Point(332, 328);
            this.fileDirectoryTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fileDirectoryTextBox.Name = "fileDirectoryTextBox";
            this.fileDirectoryTextBox.Size = new System.Drawing.Size(805, 35);
            this.fileDirectoryTextBox.TabIndex = 6;
            this.fileDirectoryTextBox.TextChanged += new System.EventHandler(this.fileDirectoryTextBox_TextChanged);
            // 
            // fileChoserButton
            // 
            this.fileChoserButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileChoserButton.Location = new System.Drawing.Point(160, 328);
            this.fileChoserButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fileChoserButton.Name = "fileChoserButton";
            this.fileChoserButton.Size = new System.Drawing.Size(162, 40);
            this.fileChoserButton.TabIndex = 7;
            this.fileChoserButton.Text = "בחירת קובץ";
            this.fileChoserButton.UseVisualStyleBackColor = true;
            this.fileChoserButton.Click += new System.EventHandler(this.fileChoserButton_Click);
            // 
            // loadExistsDbButton
            // 
            this.loadExistsDbButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.loadExistsDbButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadExistsDbButton.ForeColor = System.Drawing.Color.White;
            this.loadExistsDbButton.Location = new System.Drawing.Point(915, 412);
            this.loadExistsDbButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loadExistsDbButton.Name = "loadExistsDbButton";
            this.loadExistsDbButton.Size = new System.Drawing.Size(225, 108);
            this.loadExistsDbButton.TabIndex = 8;
            this.loadExistsDbButton.Text = "טעינת מסד נתונים קיים";
            this.loadExistsDbButton.UseVisualStyleBackColor = true;
            this.loadExistsDbButton.Click += new System.EventHandler(this.loadExistsDbButton_Click);
            // 
            // loadNewDbButton
            // 
            this.loadNewDbButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.loadNewDbButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadNewDbButton.ForeColor = System.Drawing.Color.White;
            this.loadNewDbButton.Location = new System.Drawing.Point(915, 545);
            this.loadNewDbButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loadNewDbButton.Name = "loadNewDbButton";
            this.loadNewDbButton.Size = new System.Drawing.Size(225, 108);
            this.loadNewDbButton.TabIndex = 9;
            this.loadNewDbButton.Text = "יצירת מסד נתונים חדש";
            this.loadNewDbButton.UseVisualStyleBackColor = true;
            this.loadNewDbButton.Click += new System.EventHandler(this.loadNewDbButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // FileLoader
            // 
            this.AcceptButton = this.loadExistsDbButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1176, 709);
            this.Controls.Add(this.loadNewDbButton);
            this.Controls.Add(this.loadExistsDbButton);
            this.Controls.Add(this.fileChoserButton);
            this.Controls.Add(this.fileDirectoryTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FileLoader";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FileLoader_FormClosed);
            this.Load += new System.EventHandler(this.FileLoader_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
  }
}
