// Decompiled with JetBrains decompiler
// Type: AlertsProject.UserControl1
// Assembly: AlertsProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01CC30A2-D287-482E-A95A-AE835F91B86F
// Assembly location: C:\Users\Ofek Mula\Desktop\AlertsProject.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AlertsProject
{
  public class UserControl1 : UserControl
  {
    private IContainer components = (IContainer) null;
    private BackgroundWorker backgroundWorker1;
    private Button button1;
    private MyPanel myPanel1;

    public UserControl1()
    {
      this.InitializeComponent();
    }

    private void UserControl1_Load(object sender, EventArgs e)
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
      this.backgroundWorker1 = new BackgroundWorker();
      this.button1 = new Button();
      this.myPanel1 = new MyPanel();
      this.SuspendLayout();
      this.button1.Location = new Point(59, 85);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 0;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.myPanel1.Location = new Point(63, 155);
      this.myPanel1.Name = "myPanel1";
      this.myPanel1.Size = new Size(200, 100);
      this.myPanel1.TabIndex = 1;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.myPanel1);
      this.Controls.Add((Control) this.button1);
      this.Name = nameof (UserControl1);
      this.Size = new Size(322, 284);
      this.Load += new EventHandler(this.UserControl1_Load);
      this.ResumeLayout(false);
    }
  }
}
