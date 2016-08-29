using ChatApp.Models;
using ChatApp.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace ChatApp.Storage
{
    public class ChatAppDataModel
    {
        public static ObservableCollection<User> GetAllContacts(out string error)
        {
            error = string.Empty;
            ObservableCollection<User> ret = new ObservableCollection<User>();
            // Query the database for all Contacts
            #region dummyRegion
            for (int i = 0; i < 10; i++)
            {
                ret.Add(new User
                {
                    Email = "email@example.com",
                    Id = 2 * i,
                    ImagePath = string.Empty,
                    Password = "password",
                    Username = "User Name" + i
                });
            }
            #endregion
            return ret;
        }
        public static ObservableCollection<RecentlyContactedViewModel> GetAllRecentlyContacted(out string error)
        {
            error = string.Empty;
            ObservableCollection<RecentlyContactedViewModel> ret = new ObservableCollection<RecentlyContactedViewModel>();
            // Query the database for all Contacts
            #region dummyRegion
            var AllContacts = GetAllContacts(out error);
            for (int i = 0; i < 10; i++)
            {
                ret.Add(new RecentlyContactedViewModel(new Message
                {
                    Content = "Lorem Ipsum rectifius dolor. Esta la primera dos rios dos Camerones!",
                    DateTime = DateTime.Now,
                    Id = i,
                    Receiver = AllContacts[i],
                    Sender = App.ThisUser
                }));
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
            return message.Sender.Is(user) || message.Receiver.Is(user);
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
            else if (!message.Receiver.Is(App.ThisUser))
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
