using ChatApp.Models.Csharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The Facade design pattern simplifies the interface to a complex system; 
/// because it is usually composed of all the classes which make up the subsystems of the complex system. 
/// A Facade shields the user from the complex details of the system and provides them with a simplified view of it which is easy to use.
/// It also decouples the code that uses the system from the details of the subsystems, making it easier to modify the system later.
/// </summary>
namespace ChatApp.Facades
{
    public static class ContactFacade
    {
       
        /// <summary>
        /// Returns all friends of the current user.
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<User> GetAllContacts(out string error)
        {
            error = null;
            ObservableCollection<User> ret = new ObservableCollection<User>();
            // Query the database for all Contacts
            #region dummyRegion
            for (int i = 0; i < 10; i++)
            {
                ret.Add(new User
                {
                    Email = "email@example.com",
                    Id = 2 * i,
                    ImagePath = App.AnotherUser.ImagePath,
                    Password = "password",
                    Username = "User Name" + i
                });
            }
            #endregion
            return ret;
        }
        public static ObservableCollection<RecentConversation> GetRecentConversations(out string error)
        {
            error = string.Empty;
            ObservableCollection<RecentConversation> ret = new ObservableCollection<RecentConversation>();
            // Query the database for all Contacts
            #region dummyRegion
            var allContacts = GetAllContacts(out error);
            for (int i = 0; i < 10; i++)
            {
                ret.Add(new RecentConversation
                {
                    LastMessage = new Message
                    {
                        Content = "Lorem Ipsum rectifius dolor. Esta la primera dos rios dos Camerones!",
                        DateTime = DateTime.Now,
                        Id = i,
                        Receiver = App.AnotherUser,
                        Sender = App.ThisUser
                    },
                    User = allContacts.ElementAt(i),
                });
            }
            #endregion
            return ret;
        }
        public static void AddToRecentlyContacted(Message message)
        {
            string error;
            RemoveFromRecentlyContacted(GetCorrespondent(message, out error), out error);
        }
        public static bool MessageWasExchangedWith(Message message, User user)
        {
            return message.Sender.Equals(user) || message.Receiver.Equals(user);
        }
        public static void RemoveFromRecentlyContacted(User user, out string error)
        {
            error = string.Empty;
        }
        public static User GetCorrespondent(Message message, out string error)
        {
            error = string.Empty;

            if (!MessageWasExchangedWith(message, App.ThisUser))
            {
                error = "Message incorrectly accessed!";
                return null;
            }
            else if (!message.Receiver.Equals(App.ThisUser))
            {
                return message.Receiver;
            }
            else
            {
                return message.Sender;
            }
        }
        public static void InsertContact(User user, out string error)
        {
            error = string.Empty;
        }
        public static void EditContact(User user, out string error)
        {
            error = string.Empty;
        }
        public static void DeleteContact(User user, out string error)
        {
            error = string.Empty;
        }
    }
}
