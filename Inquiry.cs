// Decompiled with JetBrains decompiler
// Type: AlertsProject.Inquiry
// Assembly: AlertsProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01CC30A2-D287-482E-A95A-AE835F91B86F
// Assembly location: C:\Users\Ofek Mula\Desktop\AlertsProject.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AlertsProject
{
  public class Inquiry : Form
  {
    private string targetPath = "";
    private IContainer components = (IContainer) null;
    private LinkLabel linkLabel1;
    private Button saveDirectory;
    private OpenFileDialog openFileDialog1;
    private TextBox textBox1;
    private Label label2;
    private Label label1;
    private Button button1;
    private Button button2;

    public Inquiry()
    {
      this.InitializeComponent();
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (!File.Exists(this.targetPath))
        return;
      Process.Start(this.targetPath);
    }

    private void button1_Click(object sender, EventArgs e)
    {
    }

    private void Inquiry_FormClosed(object sender, FormClosedEventArgs e)
    {
      Application.Exit();
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.openFileDialog1.Filter = "All files (*.*)|*.*";
      if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
        return;
      this.targetPath = Path.Combine(Environment.CurrentDirectory, Path.GetFileName(this.openFileDialog1.FileName));
      File.Copy(this.openFileDialog1.FileName, this.targetPath, true);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Inquiry));
      this.linkLabel1 = new LinkLabel();
      this.saveDirectory = new Button();
      this.openFileDialog1 = new OpenFileDialog();
      this.textBox1 = new TextBox();
      this.label2 = new Label();
      this.label1 = new Label();
      this.button1 = new Button();
      this.button2 = new Button();
      this.SuspendLayout();
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Location = new Point(863, 336);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(98, 13);
      this.linkLabel1.TabIndex = 0;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "תחקיר תקרית 10.9";
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      this.saveDirectory.Location = new Point(26, 307);
      this.saveDirectory.Name = "saveDirectory";
      this.saveDirectory.Size = new Size(75, 23);
      this.saveDirectory.TabIndex = 1;
      this.saveDirectory.Text = "בחירה";
      this.saveDirectory.UseVisualStyleBackColor = true;
      this.saveDirectory.Click += new EventHandler(this.button1_Click);
      this.openFileDialog1.FileName = "openFileDialog1";
      this.textBox1.Location = new Point(468, 207);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(493, 20);
      this.textBox1.TabIndex = 2;
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Century Gothic", 39.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.White;
      this.label2.Location = new Point(571, 9);
      this.label2.Name = "label2";
      this.label2.RightToLeft = RightToLeft.Yes;
      this.label2.Size = new Size(401, 63);
      this.label2.TabIndex = 34;
      this.label2.Text = "העלאת קבצי מידע";
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Century Gothic", 26.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.White;
      this.label1.Location = new Point(695, 135);
      this.label1.Name = "label1";
      this.label1.RightToLeft = RightToLeft.Yes;
      this.label1.Size = new Size(273, 41);
      this.label1.TabIndex = 35;
      this.label1.Text = "בחר קובץ להעלאה";
      this.button1.Location = new Point(859, 247);
      this.button1.Name = "button1";
      this.button1.Size = new Size(102, 47);
      this.button1.TabIndex = 36;
      this.button1.Text = "העלאה למאגר";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click_1);
      this.button2.Location = new Point(387, 207);
      this.button2.Name = "button2";
      this.button2.Size = new Size(75, 23);
      this.button2.TabIndex = 37;
      this.button2.Text = "בחירה";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) componentResourceManager.GetObject("$this.BackgroundImage");
      this.ClientSize = new Size(984, 561);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.saveDirectory);
      this.Controls.Add((Control) this.linkLabel1);
      this.Name = nameof (Inquiry);
      this.Text = "'";
      this.FormClosed += new FormClosedEventHandler(this.Inquiry_FormClosed);
      this.Load += new EventHandler(this.button1_Click);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
