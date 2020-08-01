// Decompiled with JetBrains decompiler
// Type: AlertsProject.FilesListWindow
// Assembly: AlertsProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01CC30A2-D287-482E-A95A-AE835F91B86F
// Assembly location: C:\Users\Ofek Mula\Desktop\AlertsProject.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AlertsProject
{
  public class FilesListWindow : Form
  {
    private IContainer components = (IContainer) null;
    private Label label2;
    private Button addNewComponentButton;
    private MyPanel myPanel1;
    private Button button2;
    private Button button1;
    private Button button4;

    public FilesListWindow()
    {
      this.InitializeComponent();
    }

    private void FilesListWindow_FormClosed(object sender, FormClosedEventArgs e)
    {
      Application.Exit();
    }

    private void FilesListWindow_Load(object sender, EventArgs e)
    {
    }

    private void button2_Click(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
    }

    private void addNewComponentButton_Click(object sender, EventArgs e)
    {
    }

    private void myPanel1_Paint(object sender, PaintEventArgs e)
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
      ComponentResourceManager resources = new ComponentResourceManager(typeof (FilesListWindow));
      this.label2 = new Label();
      this.button4 = new Button();
      this.myPanel1 = new MyPanel();
      this.button2 = new Button();
      this.button1 = new Button();
      this.addNewComponentButton = new Button();
      this.myPanel1.SuspendLayout();
      this.SuspendLayout();
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Century Gothic", 26.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(104, 0);
      this.label2.Name = "label2";
      this.label2.RightToLeft = RightToLeft.Yes;
      this.label2.Size = new Size(208, 41);
      this.label2.TabIndex = 5;
      this.label2.Text = "רשימת קבצים";
      this.button4.FlatStyle = FlatStyle.System;
      this.button4.Font = new Font("Century Gothic", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button4.Location = new Point(150, 116);
      this.button4.Name = "button4";
      this.button4.Size = new Size(121, 33);
      this.button4.TabIndex = 46;
      this.button4.Text = "קובץ חדש";
      this.button4.UseVisualStyleBackColor = true;
      this.myPanel1.AutoScroll = true;
      this.myPanel1.BackColor = Color.Transparent;
      this.myPanel1.Controls.Add((Control) this.button2);
      this.myPanel1.Controls.Add((Control) this.button1);
      this.myPanel1.Controls.Add((Control) this.addNewComponentButton);
      this.myPanel1.Location = new Point(1, 173);
      this.myPanel1.Name = "myPanel1";
      this.myPanel1.Size = new Size(393, 380);
      this.myPanel1.TabIndex = 7;
      this.myPanel1.Paint += new PaintEventHandler(this.myPanel1_Paint);
      this.button2.BackColor = Color.Transparent;
      this.button2.FlatAppearance.BorderSize = 0;
      this.button2.FlatAppearance.MouseOverBackColor = Color.DimGray;
      this.button2.FlatStyle = FlatStyle.Flat;
      this.button2.Font = new Font("Century Gothic", 20.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button2.ForeColor = Color.Black;
      this.button2.Image = (Image) resources.GetObject("button2.Image");
      this.button2.ImageAlign = ContentAlignment.MiddleLeft;
      this.button2.Location = new Point(100, 129);
      this.button2.Name = "button2";
      this.button2.RightToLeft = RightToLeft.No;
      this.button2.Size = new Size(200, 55);
      this.button2.TabIndex = 8;
      this.button2.Text = "רכיב חדש";
      this.button2.TextAlign = ContentAlignment.MiddleRight;
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.button1.BackColor = Color.Transparent;
      this.button1.FlatAppearance.BorderSize = 0;
      this.button1.FlatAppearance.MouseOverBackColor = Color.DimGray;
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.Font = new Font("Century Gothic", 20.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button1.ForeColor = Color.Black;
      this.button1.Image = (Image) resources.GetObject("button1.Image");
      this.button1.ImageAlign = ContentAlignment.MiddleLeft;
      this.button1.Location = new Point(100, 68);
      this.button1.Name = "button1";
      this.button1.RightToLeft = RightToLeft.No;
      this.button1.Size = new Size(200, 55);
      this.button1.TabIndex = 7;
      this.button1.Text = "log.txt";
      this.button1.TextAlign = ContentAlignment.MiddleRight;
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.addNewComponentButton.BackColor = Color.Transparent;
      this.addNewComponentButton.FlatAppearance.BorderSize = 0;
      this.addNewComponentButton.FlatAppearance.MouseOverBackColor = Color.DimGray;
      this.addNewComponentButton.FlatStyle = FlatStyle.Flat;
      this.addNewComponentButton.Font = new Font("Century Gothic", 20.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.addNewComponentButton.ForeColor = Color.Black;
      this.addNewComponentButton.Image = (Image) resources.GetObject("addNewComponentButton.Image");
      this.addNewComponentButton.ImageAlign = ContentAlignment.MiddleLeft;
      this.addNewComponentButton.Location = new Point(103, 3);
      this.addNewComponentButton.Name = "addNewComponentButton";
      this.addNewComponentButton.RightToLeft = RightToLeft.No;
      this.addNewComponentButton.Size = new Size(200, 55);
      this.addNewComponentButton.TabIndex = 6;
      this.addNewComponentButton.Text = "תחקיר.doc";
      this.addNewComponentButton.TextAlign = ContentAlignment.MiddleRight;
      this.addNewComponentButton.UseVisualStyleBackColor = false;
      this.addNewComponentButton.Click += new EventHandler(this.addNewComponentButton_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) resources.GetObject("$this.BackgroundImage");
      this.BackgroundImageLayout = ImageLayout.Center;
      this.ClientSize = new Size(402, 549);
      this.Controls.Add((Control) this.button4);
      this.Controls.Add((Control) this.myPanel1);
      this.Controls.Add((Control) this.label2);
      this.FormClosed += new FormClosedEventHandler(this.FilesListWindow_FormClosed);
      this.Load += new EventHandler(this.FilesListWindow_Load);
      this.myPanel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
