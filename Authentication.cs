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
      else if (Tools.authenticationUser(userNameTextBox.Text, PasswordTextBox.Text))
            {
                Tools.adminMode = true;
                Tools.LoadNextWindow((Form)this, (Form)new FileLoader((Form)this), true);
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
            Tools.readUsersDB();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authentication));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.enter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(200, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(889, 112);
            this.label1.TabIndex = 0;
            this.label1.Text = "משמעויות או לא להיות!\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(906, 205);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(257, 66);
            this.label2.TabIndex = 1;
            this.label2.Text = "התחברות:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(952, 289);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(193, 43);
            this.label3.TabIndex = 2;
            this.label3.Text = "שם משתמש:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1041, 334);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(109, 43);
            this.label4.TabIndex = 3;
            this.label4.Text = "ססמא:";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameTextBox.Location = new System.Drawing.Point(735, 302);
            this.userNameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userNameTextBox.MaxLength = 10;
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.userNameTextBox.Size = new System.Drawing.Size(206, 31);
            this.userNameTextBox.TabIndex = 4;
            this.userNameTextBox.TextChanged += new System.EventHandler(this.userNameTextBox_TextChanged);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.Location = new System.Drawing.Point(735, 345);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PasswordTextBox.MaxLength = 10;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PasswordTextBox.Size = new System.Drawing.Size(206, 31);
            this.PasswordTextBox.TabIndex = 6;
            this.PasswordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBox_TextChanged);
            // 
            // enter
            // 
            this.enter.BackColor = System.Drawing.SystemColors.Control;
            this.enter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.enter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.enter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.enter.Font = new System.Drawing.Font("Century Gothic", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enter.ForeColor = System.Drawing.Color.Black;
            this.enter.Location = new System.Drawing.Point(1028, 412);
            this.enter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.enter.Name = "enter";
            this.enter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.enter.Size = new System.Drawing.Size(122, 51);
            this.enter.TabIndex = 8;
            this.enter.Text = "כניסה!";
            this.enter.UseVisualStyleBackColor = false;
            this.enter.Click += new System.EventHandler(this.enter_Click);
            // 
            // Authentication
            // 
            this.AcceptButton = this.enter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1176, 682);
            this.Controls.Add(this.enter);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Authentication";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Authentication_FormClosed);
            this.Load += new System.EventHandler(this.Authentication_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
  }
}
