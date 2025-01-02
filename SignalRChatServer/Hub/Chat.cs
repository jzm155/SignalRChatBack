using Microsoft.AspNetCore.SignalR;

namespace SignalRChatServer
{
    public class Chat : Hub
    {
        public static List<Message> Messages;
        public Chat()
        {
            if(Messages == null)
                Messages = new List<Message>();
        }
        public void NewMessage(string userName,string text)
        {
            Clients.All.SendAsync("newMessage",userName, text);
            Messages.Add(new Message()
            {
                Text = text,
                Username = userName,
            });
        }

        public void NewUser(string userName,string connectionId)
        {
            Clients.Client(connectionId).SendAsync("previousMessages", Messages);
            Clients.All.SendAsync("newUser", userName);
        }
    }

    public class Message
    {
        public string Username { get; set; }

        public string Text { get; set; }
    }
}
