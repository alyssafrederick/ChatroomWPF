using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatRoomAlyssaUpdated
{
    public static class Global
    {
        public static Dictionary<int, User> Users = new Dictionary<int, User>();

        public static Dictionary<int, Group> Groups = new Dictionary<int, Group>();
    }
}
