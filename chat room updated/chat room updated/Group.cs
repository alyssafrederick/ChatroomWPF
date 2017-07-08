using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatRoomAlyssaUpdated
{
    public class Group
    {
        int _groupID;
        public int GroupID
        {
            get
            {
                return _groupID;
            }
        }


        string _groupName;
        List<Message> _messages = new List<Message>();
        Dictionary<int, User> _chatAccess = new Dictionary<int, User>();

        public Dictionary<int, User> ChatAccess
        {
            get
            {
                return _chatAccess;
            }
        }

        public Group(int groupID, string groupName)
        {
            _groupID = groupID;
            _groupName = groupName;
        }
    }
}
