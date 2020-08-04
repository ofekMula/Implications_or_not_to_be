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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddImageUrl));
            this.label2 = new System.Windows.Forms.Label();
            this.addImageUrlButton = new System.Windows.Forms.Button();
            this.fileChoserButton = new System.Windows.Forms.Button();
            this.fileDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(640, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(677, 93);
            this.label2.TabIndex = 5;
            this.label2.Text = "הוספת תמונה לרכיב";
            // 
            // addImageUrlButton
            // 
            this.addImageUrlButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addImageUrlButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addImageUrlButton.ForeColor = System.Drawing.Color.White;
            this.addImageUrlButton.Location = new System.Drawing.Point(18, 568);
            this.addImageUrlButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addImageUrlButton.Name = "addImageUrlButton";
            this.addImageUrlButton.Size = new System.Drawing.Size(225, 108);
            this.addImageUrlButton.TabIndex = 11;
            this.addImageUrlButton.Text = "הוספת תמונה לרכיב";
            this.addImageUrlButton.UseVisualStyleBackColor = true;
            this.addImageUrlButton.Click += new System.EventHandler(this.addImageUrlButton_Click);
            // 
            // fileChoserButton
            // 
            this.fileChoserButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileChoserButton.Location = new System.Drawing.Point(308, 265);
            this.fileChoserButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fileChoserButton.Name = "fileChoserButton";
            this.fileChoserButton.Size = new System.Drawing.Size(162, 40);
            this.fileChoserButton.TabIndex = 10;
            this.fileChoserButton.Text = "בחירת קובץ";
            this.fileChoserButton.UseVisualStyleBackColor = true;
            this.fileChoserButton.Click += new System.EventHandler(this.fileChoserButton_Click);
            // 
            // fileDirectoryTextBox
            // 
            this.fileDirectoryTextBox.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileDirectoryTextBox.Location = new System.Drawing.Point(478, 266);
            this.fileDirectoryTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fileDirectoryTextBox.Name = "fileDirectoryTextBox";
            this.fileDirectoryTextBox.Size = new System.Drawing.Size(805, 35);
            this.fileDirectoryTextBox.TabIndex = 9;
            this.fileDirectoryTextBox.TextChanged += new System.EventHandler(this.fileDirectoryTextBox_TextChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(657, 375);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(400, 300);
            this.pictureBox2.TabIndex = 47;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AddImageUrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1326, 711);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.addImageUrlButton);
            this.Controls.Add(this.fileChoserButton);
            this.Controls.Add(this.fileDirectoryTextBox);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AddImageUrl";
            this.Load += new System.EventHandler(this.AddImageUrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

        private void fileDirectoryTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
