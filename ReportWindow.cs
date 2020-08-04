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
namespace AlertsProject
{
    public partial class ReportWindow : Form
    {
        private string componentName;
        private string faultName;
        private string implications;
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
            MailMessage message = new MailMessage("ofekapp35@gmail.com", sendtoTextBox.Text);
            message.Subject = subjectTextBox.Text;
            message.Body = reportContent.Text;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            System.Net.NetworkCredential nc = new System.Net.NetworkCredential("ofekapp35@gmail.com", "pass1234!");
            smtp.Credentials = nc;
            smtp.EnableSsl = true;
           //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                smtp.Send(message);
                MessageBox.Show("youe mail has sent!");
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
       
        }

        private void ReportWindow_Load(object sender, EventArgs e)
        {
            this.sendtoTextBox.Text = "ofekapp35@gmail.com";
            this.subjectTextBox.Text = "דיווח תקלה ברכיב:" + this.componentName;
            this.reportContent.Text = faultName + "\n" + implications;
        }
    }
}
