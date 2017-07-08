using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatRoomAlyssaUpdated
{
    public class Message
    {
        int _messageID;
        string _message;
        User _user;
        DateTime _whenSent;

        public Message(int messageID, string message, User user, DateTime whenSent)
        {
            _messageID = messageID;
            _message = message;
            _user = user;
            _whenSent = whenSent;
        }
    }
}
