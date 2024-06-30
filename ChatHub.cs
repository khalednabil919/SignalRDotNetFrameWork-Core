using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SignalRDotNetFrameWork
{
    [HubName("chat")]
    public class ChatHub:Hub
    {
        public void sendMessage(string name,string message)
        {
            Clients.All.newMessage(name, message); //RPC
        }
        public void joinGroup(string gname,string name)
        {
            Groups.Add(Context.ConnectionId, gname);
            Clients.OthersInGroup(gname).newMember(name, gname);
        }
        public void sendGroup(string name, string gname , string message)
        {
            Clients.Group(gname).sendToAllMemberInGroup(name , gname, message);
        }
    }
}