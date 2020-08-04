using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertsProject
{
    [Serializable]
    class User
    {
        private string nickName;
        private string userName;
        private string password;
        private int position;

        public static int ADMIN = 1;
        public static int USER = 0;

        public User (string name,string userName,string password,int pos)
        {
            this.nickName = name;
            this.userName = userName;
            this.password = password;
            this.position = pos;
        }
        public string getName()
        {
            return this.nickName;
        }
        public string getUserName()
        {
            return this.userName;
        }

        public string getpassword()
        {
            return this.password;
        }

        public int getPos()
        {
            return this.position;
        }

        public void setName(string name)
        {
            this.nickName = name;
        }
        public void setUserName(string userName)
        {
            this.userName = userName;
        }
        public void setPassword()
        {
            this.password = password;
        }

        public void setPosition(int pos)
        {
            this.position = pos;
        }
    }
}
