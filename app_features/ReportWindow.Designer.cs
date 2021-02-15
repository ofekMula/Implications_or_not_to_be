namespace AlertsProject
{
    partial class ReportWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportWindow));
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.sendtoTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.subjectTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.reportContent = new System.Windows.Forms.RichTextBox();
            this.addNewFaultButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(477, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(393, 93);
            this.label2.TabIndex = 34;
            this.label2.Text = "דיווח תקלה";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(673, 123);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(181, 49);
            this.label10.TabIndex = 38;
            this.label10.Text = "מייל הנמען:";
            // 
            // sendtoTextBox
            // 
            this.sendtoTextBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendtoTextBox.Location = new System.Drawing.Point(331, 136);
            this.sendtoTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sendtoTextBox.MaxLength = 3000;
            this.sendtoTextBox.Name = "sendtoTextBox";
            this.sendtoTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.sendtoTextBox.Size = new System.Drawing.Size(334, 37);
            this.sendtoTextBox.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(758, 201);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(96, 49);
            this.label1.TabIndex = 40;
            this.label1.Text = "נושא:";
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectTextBox.Location = new System.Drawing.Point(331, 201);
            this.subjectTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.subjectTextBox.MaxLength = 3000;
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.subjectTextBox.Size = new System.Drawing.Size(334, 37);
            this.subjectTextBox.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(767, 278);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(87, 49);
            this.label3.TabIndex = 42;
            this.label3.Text = "תוכן:";
            // 
            // reportContent
            // 
            this.reportContent.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportContent.Location = new System.Drawing.Point(173, 332);
            this.reportContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.reportContent.Name = "reportContent";
            this.reportContent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reportContent.Size = new System.Drawing.Size(672, 179);
            this.reportContent.TabIndex = 43;
            this.reportContent.Text = "";
            // 
            // addNewFaultButton
            // 
            this.addNewFaultButton.BackColor = System.Drawing.Color.Transparent;
            this.addNewFaultButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.addNewFaultButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addNewFaultButton.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewFaultButton.ForeColor = System.Drawing.Color.White;
            this.addNewFaultButton.Location = new System.Drawing.Point(13, 561);
            this.addNewFaultButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addNewFaultButton.Name = "addNewFaultButton";
            this.addNewFaultButton.Size = new System.Drawing.Size(255, 69);
            this.addNewFaultButton.TabIndex = 47;
            this.addNewFaultButton.Text = "שליחת דו\"ח";
            this.addNewFaultButton.UseVisualStyleBackColor = false;
            this.addNewFaultButton.Click += new System.EventHandler(this.addNewFaultButton_Click);
            // 
            // ReportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(923, 644);
            this.Controls.Add(this.addNewFaultButton);
            this.Controls.Add(this.reportContent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.subjectTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.sendtoTextBox);
            this.Controls.Add(this.label2);
            this.Name = "ReportWindow";
            this.Text = "ReportWindow";
            this.Load += new System.EventHandler(this.ReportWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox sendtoTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox subjectTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox reportContent;
        private System.Windows.Forms.Button addNewFaultButton;
    }
}