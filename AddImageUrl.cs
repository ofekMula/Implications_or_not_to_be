// Decompiled with JetBrains decompiler
// Type: AlertsProject.AddImageUrl
// Assembly: AlertsProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01CC30A2-D287-482E-A95A-AE835F91B86F
// Assembly location: C:\Users\Ofek Mula\Desktop\AlertsProject.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AlertsProject
{
  public class AddImageUrl : Form
  {
    private IContainer components = (IContainer) null;
    private string componentImage;
    private Label label2;
    private Button addImageUrlButton;
    private Button fileChoserButton;
    private TextBox fileDirectoryTextBox;
    private PictureBox pictureBox2;
    private OpenFileDialog openFileDialog1;

    public AddImageUrl()
    {
      this.InitializeComponent();
    }

    public AddImageUrl(string componentImage)
    {
      this.componentImage = componentImage;
      this.InitializeComponent();
    }

    private void fileChoserButton_Click(object sender, EventArgs e)
    {
      this.openFileDialog1.Filter = "All files (*.*)|*.*";
      if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
        return;
      this.fileDirectoryTextBox.Text = this.openFileDialog1.FileName;
      if (Tools.isUrlImage(this.openFileDialog1.FileName))
      {
        this.pictureBox2.Load(this.openFileDialog1.FileName);
      }
      else
      {
        int num = (int) MessageBox.Show("יש לתת קישור לתמונות בלבד!");
      }
    }

    private void AddImageUrl_Load(object sender, EventArgs e)
    {
    }

    private void addImageUrlButton_Click(object sender, EventArgs e)
    {
      this.componentImage = this.fileDirectoryTextBox.Text;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AddImageUrl));
      this.label2 = new Label();
      this.addImageUrlButton = new Button();
      this.fileChoserButton = new Button();
      this.fileDirectoryTextBox = new TextBox();
      this.pictureBox2 = new PictureBox();
      this.openFileDialog1 = new OpenFileDialog();
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      this.SuspendLayout();
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Century Gothic", 39.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(427, 26);
      this.label2.Name = "label2";
      this.label2.RightToLeft = RightToLeft.Yes;
      this.label2.Size = new Size(441, 63);
      this.label2.TabIndex = 5;
      this.label2.Text = "הוספת תמונה לרכיב";
      this.addImageUrlButton.FlatStyle = FlatStyle.System;
      this.addImageUrlButton.Font = new Font("Century Gothic", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.addImageUrlButton.ForeColor = Color.White;
      this.addImageUrlButton.Location = new Point(12, 369);
      this.addImageUrlButton.Name = "addImageUrlButton";
      this.addImageUrlButton.Size = new Size(150, 70);
      this.addImageUrlButton.TabIndex = 11;
      this.addImageUrlButton.Text = "הוספת תמונה לרכיב";
      this.addImageUrlButton.UseVisualStyleBackColor = true;
      this.addImageUrlButton.Click += new EventHandler(this.addImageUrlButton_Click);
      this.fileChoserButton.Font = new Font("Century Gothic", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.fileChoserButton.Location = new Point(205, 172);
      this.fileChoserButton.Name = "fileChoserButton";
      this.fileChoserButton.Size = new Size(108, 26);
      this.fileChoserButton.TabIndex = 10;
      this.fileChoserButton.Text = "בחירת קובץ";
      this.fileChoserButton.UseVisualStyleBackColor = true;
      this.fileChoserButton.Click += new EventHandler(this.fileChoserButton_Click);
      this.fileDirectoryTextBox.Font = new Font("Century Gothic", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.fileDirectoryTextBox.Location = new Point(319, 173);
      this.fileDirectoryTextBox.Name = "fileDirectoryTextBox";
      this.fileDirectoryTextBox.Size = new Size(538, 26);
      this.fileDirectoryTextBox.TabIndex = 9;
      this.pictureBox2.BackColor = Color.Transparent;
      this.pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
      this.pictureBox2.Location = new Point(438, 244);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(267, 195);
      this.pictureBox2.TabIndex = 47;
      this.pictureBox2.TabStop = false;
      this.openFileDialog1.FileName = "openFileDialog1";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) componentResourceManager.GetObject("$this.BackgroundImage");
      this.ClientSize = new Size(884, 462);
      this.Controls.Add((Control) this.pictureBox2);
      this.Controls.Add((Control) this.addImageUrlButton);
      this.Controls.Add((Control) this.fileChoserButton);
      this.Controls.Add((Control) this.fileDirectoryTextBox);
      this.Controls.Add((Control) this.label2);
      this.Name = nameof (AddImageUrl);
      this.Text = nameof (AddImageUrl);
      this.Load += new EventHandler(this.AddImageUrl_Load);
      ((ISupportInitialize) this.pictureBox2).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
