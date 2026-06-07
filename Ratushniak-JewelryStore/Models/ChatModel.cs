using System;
using System.Collections.Generic;

namespace JewelryStore.Models
{
    public class ChatModel
    {
        public List<ChatUser> Users;
        public List<ChatMessage> Messages;

        public ChatModel()
        {
            Users = new List<ChatUser>();
            Messages = new List<ChatMessage>();
            Messages.Add(new ChatMessage()
            {
                Text = "Чат розпочато " + DateTime.Now
            });
        }
    }
}