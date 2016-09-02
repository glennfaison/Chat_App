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
        static int i = 500;

        public static Profile Correspondent { get; set; }

        /// <summary>
        /// Returns the messages between the 2 users
        /// </summary>
        /// <param name="Correspondent"></param>
        /// <param name="u2"></param>
        /// <returns></returns>
        public static ObservableCollection<Message> GetMessages()
        {
            var messages = new ObservableCollection<Message>();
            // Get message thread with Correspondent
            #region dummyRegion
            for(int i = 0; i < 10; i++)
            {
                messages.Add(new Message
                {
                    Sender = App.ThisUser,
                    Receiver = App.AnotherUser,
                    Content = "How are you doing? How are you doing? How are you doing? How are you doing? How are you doing? How are you doing?",
                    DateTime = DateTime.Now,
                });
                messages.Add(new Message
                {
                    Sender = App.AnotherUser,
                    Receiver = App.ThisUser,
                    Content = "I dey ok. I am deying",
                    DateTime = DateTime.Now,
                });
            }
            #endregion
            return messages;
        }
        public static void SendMessage(string text,
            ref ObservableCollection<Message> messageThread, out string error)
        {
            error = string.Empty;
            var message = new Message
            {
                Content = text,
                DateTime = DateTime.Now,
                Id = i++,
                Receiver = Correspondent.User,
                Sender = App.ThisUser
            };
            var allFriends = ContactFacade.current_RecentConversations;
            InsertMessage(message, ref messageThread, out error);
        }
        public static void InsertMessage(Message message,
            ref ObservableCollection<Message> messageThread, out string error)
        {
            error = string.Empty;
            messageThread.Add(message);
            ContactFacade.InsertRecentConversation(message);
            // Insert message into the database here
        }
        public static void DeleteMessage(Message message,
            ref ObservableCollection<Message> messageThread, out string error)
        {
            error = string.Empty;
            messageThread.Remove(message);
            var correspondent = ContactFacade.GetCorrespondent(message, out error);
            ContactFacade.DeleteRecentConversation(correspondent, out error);
            // Delete message from the database here
        }
    }
}
