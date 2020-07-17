// Decompiled with JetBrains decompiler
// Type: AlertsProject.Authentication
// Assembly: AlertsProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01CC30A2-D287-482E-A95A-AE835F91B86F
// Assembly location: C:\Users\Ofek Mula\Desktop\AlertsProject.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AlertsProject
{
  public class Authentication : Form
  {
    private IContainer components = (IContainer) null;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private TextBox userNameTextBox;
    private TextBox PasswordTextBox;
    private Button enter;

    public Authentication()
    {
      this.DoubleBuffered = true;
      this.InitializeComponent();
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void enter_Click(object sender, EventArgs e)
    {
      if (this.userNameTextBox.Text == Tools.ADMIN_USERNAME && this.PasswordTextBox.Text == Tools.ADMIN_PASSWORD)
      {
        Tools.adminMode = true;
        Tools.LoadNextWindow((Form) this, (Form) new FileLoader((Form) this), true);
      }
      else if (this.userNameTextBox.Text == Tools.REGULAR_USERNAME && this.PasswordTextBox.Text == Tools.REGULAR_PASSWORD)
      {
        Tools.readLog();
        Tools.LoadNextWindow((Form) this, (Form) new Implications((Form) this), true);
      }
      else
      {
        int num = (int) MessageBox.Show(Tools.AUTHENTICATION_ERROR, Tools.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void label2_Click(object sender, EventArgs e)
    {
    }

    private void userNameTextBox_TextChanged(object sender, EventArgs e)
    {
    }

    private void PasswordTextBox_TextChanged(object sender, EventArgs e)
    {
    }

    private void Authentication_Load(object sender, EventArgs e)
    {
    }

    private void Authentication_FormClosed(object sender, FormClosedEventArgs e)
    {
      Application.Exit();
    }

    private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
    }

    private void enter_Click_1(object sender, EventArgs e)
    {
    }

    private void button1_Click_2(object sender, EventArgs e)
    {
    }

    private void circularProgressBar1_Click(object sender, EventArgs e)
    {
    }

    private void button1_Click_3(object sender, EventArgs e)
    {
      Features features = new Features();
      this.Hide();
      int num = (int) features.ShowDialog();
    }

    private void button1_Click_4(object sender, EventArgs e)
    {
      int num = (int) new FilesListWindow().ShowDialog();
      this.Hide();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void button1_Click_5(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Minimized;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Authentication));
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.userNameTextBox = new TextBox();
      this.PasswordTextBox = new TextBox();
      this.enter = new Button();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Century Gothic", 48f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(133, 19);
      this.label1.Name = "label1";
      this.label1.RightToLeft = RightToLeft.Yes;
      this.label1.Size = new Size(583, 77);
      this.label1.TabIndex = 0;
      this.label1.Text = "משמעויות או לא להיות!\r\n";
      this.label1.Click += new EventHandler(this.label1_Click);
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Century Gothic", 27.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(604, 133);
      this.label2.Name = "label2";
      this.label2.RightToLeft = RightToLeft.Yes;
      this.label2.Size = new Size(170, 44);
      this.label2.TabIndex = 1;
      this.label2.Text = "התחברות:";
      this.label2.Click += new EventHandler(this.label2_Click);
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Century Gothic", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.Black;
      this.label3.Location = new Point(635, 188);
      this.label3.Name = "label3";
      this.label3.RightToLeft = RightToLeft.Yes;
      this.label3.Size = new Size(136, 30);
      this.label3.TabIndex = 2;
      this.label3.Text = "שם משתמש:";
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.Font = new Font("Century Gothic", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = Color.Black;
      this.label4.Location = new Point(694, 217);
      this.label4.Name = "label4";
      this.label4.RightToLeft = RightToLeft.Yes;
      this.label4.Size = new Size(77, 30);
      this.label4.TabIndex = 3;
      this.label4.Text = "ססמא:";
      this.userNameTextBox.Font = new Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.userNameTextBox.Location = new Point(490, 196);
      this.userNameTextBox.MaxLength = 10;
      this.userNameTextBox.Name = "userNameTextBox";
      this.userNameTextBox.RightToLeft = RightToLeft.Yes;
      this.userNameTextBox.Size = new Size(139, 23);
      this.userNameTextBox.TabIndex = 4;
      this.userNameTextBox.TextChanged += new EventHandler(this.userNameTextBox_TextChanged);
      this.PasswordTextBox.Font = new Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.PasswordTextBox.Location = new Point(490, 224);
      this.PasswordTextBox.MaxLength = 10;
      this.PasswordTextBox.Name = "PasswordTextBox";
      this.PasswordTextBox.PasswordChar = '*';
      this.PasswordTextBox.RightToLeft = RightToLeft.Yes;
      this.PasswordTextBox.Size = new Size(139, 23);
      this.PasswordTextBox.TabIndex = 6;
      this.PasswordTextBox.TextChanged += new EventHandler(this.PasswordTextBox_TextChanged);
      this.enter.BackColor = SystemColors.Control;
      this.enter.BackgroundImageLayout = ImageLayout.None;
      this.enter.Cursor = Cursors.Hand;
      this.enter.FlatStyle = FlatStyle.System;
      this.enter.Font = new Font("Century Gothic", 17.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.enter.ForeColor = Color.Black;
      this.enter.Location = new Point(685, 268);
      this.enter.Name = "enter";
      this.enter.RightToLeft = RightToLeft.Yes;
      this.enter.Size = new Size(81, 33);
      this.enter.TabIndex = 8;
      this.enter.Text = "כניסה!";
      this.enter.UseVisualStyleBackColor = false;
      this.enter.Click += new EventHandler(this.enter_Click);
      this.AcceptButton = (IButtonControl) this.enter;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) componentResourceManager.GetObject("$this.BackgroundImage");
      this.BackgroundImageLayout = ImageLayout.Center;
      this.ClientSize = new Size(784, 443);
      this.Controls.Add((Control) this.enter);
      this.Controls.Add((Control) this.PasswordTextBox);
      this.Controls.Add((Control) this.userNameTextBox);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.ForeColor = Color.Black;
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.Name = nameof (Authentication);
      this.Text = "Form1";
      this.FormClosed += new FormClosedEventHandler(this.Authentication_FormClosed);
      this.Load += new EventHandler(this.Authentication_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
