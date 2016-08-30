using ChatApp.Models.Csharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Facades
{
    public static class MessageFacade
    {
        /// <summary>
        /// Returns the messages between the 2 users
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="u2"></param>
        /// <returns></returns>
        public static ObservableCollection<Message> GetMessages(User u1, User u2)
        {
            //dummy.
            var messages = new ObservableCollection<Message>();

            messages.Add(new Message
            {
                Sender = App.ThisUser,
                Receiver = App.AnotherUser,
                Content = "How are you doing nigga?",
                DateTime = DateTime.Now,
            });
            messages.Add(new Message
            {
                Sender = App.AnotherUser,
                Receiver = App.ThisUser,
                Content = "I dey bitch...",
                DateTime = DateTime.Now,
            });
            messages.Add(new Message
            {
                Sender = App.ThisUser,
                Receiver = App.AnotherUser,
                Content = "How are you doing nigga?",
                DateTime = DateTime.Now,
            });
            messages.Add(new Message
            {
                Sender = App.AnotherUser,
                Receiver = App.ThisUser,
                Content = "I dey bitch...",
                DateTime = DateTime.Now,
            });
            messages.Add(new Message
            {
                Sender = App.ThisUser,
                Receiver = App.AnotherUser,
                Content = "How are you doing nigga?",
                DateTime = DateTime.Now,
            });
            messages.Add(new Message
            {
                Sender = App.AnotherUser,
                Receiver = App.ThisUser,
                Content = "I dey bitch...",
                DateTime = DateTime.Now,
            });
            messages.Add(new Message
            {
                Sender = App.ThisUser,
                Receiver = App.AnotherUser,
                Content = "How are you doing nigga?",
                DateTime = DateTime.Now,
            });
            messages.Add(new Message
            {
                Sender = App.AnotherUser,
                Receiver = App.ThisUser,
                Content = "I dey bitch...",
                DateTime = DateTime.Now,
            });
            messages.Add(new Message
            {
                Sender = App.ThisUser,
                Receiver = App.AnotherUser,
                Content = "How are you doing nigga?",
                DateTime = DateTime.Now,
            });
            messages.Add(new Message
            {
                Sender = App.AnotherUser,
                Receiver = App.ThisUser,
                Content = "I dey bitch...",
                DateTime = DateTime.Now,
            });
            messages.Add(new Message
            {
                Sender = App.ThisUser,
                Receiver = App.AnotherUser,
                Content = "How are you doing nigga?",
                DateTime = DateTime.Now,
            });
            messages.Add(new Message
            {
                Sender = App.AnotherUser,
                Receiver = App.ThisUser,
                Content = "I dey bitch...",
                DateTime = DateTime.Now,
            });
            return messages;
        }
    }
}
