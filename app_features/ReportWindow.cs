using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.CodeDom;

namespace AlertsProject
{
    public partial class ReportWindow : Form
    {
        
        private string componentName;
        private string faultName;
        private string implications;

        private readonly string MAIL_ADD = "ofekapp35@gmail.com";
        private readonly string MAIL_PASS = "pass1234!";
        private readonly string MAIL_SENT = "המייל נשלח בהצלחה!";
        private readonly string REPORT = "דיווח על  תקלה ברכיב:";
        private readonly string IMPLICATION = "משמעויות: ";
        private readonly string FAULT_NAME ="שם התקלה: ";

        public ReportWindow()
        {
            InitializeComponent();
        }
        public ReportWindow(string componentName,string faultName,string implications)
        {
            this.componentName = componentName;
            this.faultName = faultName;
            this.implications = implications;
            InitializeComponent();
        }

        private void addNewFaultButton_Click(object sender, EventArgs e)
        {
            MailMessage message = new MailMessage(MAIL_ADD, sendtoTextBox.Text);
            message.Subject = subjectTextBox.Text;
            message.Body = reportContent.Text;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            System.Net.NetworkCredential nc = new System.Net.NetworkCredential(MAIL_ADD, MAIL_PASS);
            smtp.Credentials = nc;
            smtp.EnableSsl = true;
           //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                smtp.Send(message);
                MessageBox.Show(MAIL_SENT);
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
       
        }

        private void ReportWindow_Load(object sender, EventArgs e)
        {
            this.sendtoTextBox.Text = MAIL_ADD;
            this.subjectTextBox.Text = REPORT + this.componentName;
            this.reportContent.Text = FAULT_NAME+ faultName + "\n" +IMPLICATION+ implications;
        }
    }
}
