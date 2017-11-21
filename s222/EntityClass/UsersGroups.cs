using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClass
{
    public class UsersGroups
    {
        private string id;
        private string name; 
        private string pid;
        private string order_id;
        private string phone;
        private string fax;
        private string enable;
        private string note;
        private string add_user_id;
        private string update_user_id;
        private string add_time;
        private string update_time;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }

        public string Order_ID
        {
            get { return order_id; }
            set { order_id = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        public string Enable
        {
            get { return enable; }
            set { enable = value; }
        }

        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        public string Add_User_ID
        {
            get { return add_user_id; }
            set { add_user_id = value; }
        }

        public string Update_User_ID
        {
            get { return update_user_id; }
            set { update_user_id = value; }
        }

        public string Add_Time
        {
            get { return add_time; }
            set { add_time = value; }
        }

        public string Update_Time
        {
            get { return update_time; }
            set { update_time = value; }
        }
    }
}
