using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlertsProject
{
    public partial class UserWindow : Form
    {
        public UserWindow()
        {
            InitializeComponent();
        }

        private void UserWindow_Load(object sender, EventArgs e)
        {
            Tools.readUsersDB();
        }

        private void updateFaultButton_Click(object sender, EventArgs e)
        {
            int pos = 0; ;
            if (Tools.isValidUser(nickNameTextBox.Text))
            {
                if (adminButton.Checked)
                {
                    pos = 1;
                }
                Tools.usersList.Add(new User(nickNameTextBox.Text, userNameTextBox.Text, passwordTextBox.Text, pos));
                Tools.writeToUsersDB();
                MessageBox.Show(" :משתמש " + nickNameTextBox.Text + "נוסף בהצלחה ");
                Tools.ResetAllControls(this);
            }
            else
            {
                MessageBox.Show("שגיאה: יש לרשום את כול הפרטים");
            }
        }
    }
}
