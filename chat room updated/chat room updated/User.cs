using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatRoomAlyssaUpdated
{
    public class User
    {
        int _accountID;
        string _name;
        //string _username;
        //string _password;
        //string _email;
        //DateTime _birthday;
        bool _isOnline;

        public User(int accountID, string name, bool isOnline)
        {
            _accountID = accountID;
            _name = name;
            //_username = username;
            //_email = email;
            //_birthday = birthday;
            _isOnline = isOnline;
        }
    }
}
