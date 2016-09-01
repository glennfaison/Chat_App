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
        public static Profile Correspondent { get; set; }
        static int i = 500;
        /// <summary>
        /// Returns the messages between the 2 users
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="u2"></param>
        /// <returns></returns>
        public static ObservableCollection<Message> GetMessages(User u1, User u2)
        {
            var messages = new ObservableCollection<Message>();
            //dummy.
            #region dummyRegion
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
            #endregion
            return messages;
        }
        public static void SendMessage(string text, Profile chatCorrespondent, out string error)
        {
            error = string.Empty;
            var message = new Message
            {
                Content = text,
                DateTime = DateTime.Now,
                Id = i++,
                Receiver = chatCorrespondent.User,
                Sender = App.ThisUser
            };
            var conversations = ContactFacade.RecentConversations;
            ContactFacade.InsertRecentConversation(message, ref conversations);
        }
    }
}
