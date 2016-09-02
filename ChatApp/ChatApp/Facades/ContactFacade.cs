using ChatApp.Common;
using ChatApp.Models.Csharp;
using ChatApp.ViewModels;
using ChatApp.Views;
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
        public static ContactsPage ContactPage { get; set; }
        public static ObservableCollection<RecentConversation> current_RecentConversations
        {
            get { return ContactsPageViewModel._recentConversations; }
        }
        public static ObservableCollection<User> current_AllFriends
        {
            get { return ContactsPageViewModel._allFriends; }
        }

        /// <summary>
        /// Returns all friends of the current user.
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<User> GetAllFriends(out string error)
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
            var allContacts = GetAllFriends(out error);
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
        /// <summary>
        /// Get Friends' Profiles, depending on their online status
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Profile> GetFriendProfiles(bool onlineOnly = false)
        {
            if(current_AllFriends == null)
            {
                return null;
            }
            var ret = new ObservableCollection<Profile>();
            foreach (var user in current_AllFriends)
            {
                ret.Add(new Profile
                {
                    LastActive = DateTime.Now,
                    User = user
                });
            }
            return ret;
        }
        /// <summary>
        /// Get profile of user from recent conversation.
        /// </summary>
        /// <param name="recentConversation"></param>
        /// <returns>Profile</returns>
        public static Profile GetProfile(RecentConversation recentConversation)
        {
            if (recentConversation == null)
            {
                return null;
            }
            return new Profile
            {
                User = recentConversation.User,
                LastActive = DateTime.Now,
            };
        }
        public static void InsertRecentConversation(Message message)
        {
            string error;
            User correspondent = GetCorrespondent(message, out error);
            if(error != string.Empty)
            {
                ErrorDialog.ShowError(error);
                return;
            }
            DeleteRecentConversation(correspondent, out error);
            var conversation = new RecentConversation
            {
                LastMessage = message,
                User = correspondent
            };
            current_RecentConversations.Insert(0, conversation);
        }
        public static bool MessageWasExchangedWith(Message message, User user)
        {
            return message.Sender.Equals(user) || message.Receiver.Equals(user);
        }
        public static void DeleteRecentConversation(User user, out string error)
        {
            error = string.Empty;
            foreach(var convo in current_RecentConversations)
            {
                if (user.Id == convo.User.Id)
                {
                    current_RecentConversations.Remove(convo);
                    break;
                }
            }
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
        public static void InsertFriend(User user, out string error)
        {
            error = string.Empty;
            if (!current_AllFriends.Contains(user))
            {
                current_AllFriends.Add(user);
            }
            // Insert into database here
        }
        public static void EditFriend(User user, out string error)
        {
            error = string.Empty;
        }
        public static void DeleteFriend(User user, out string error)
        {
            error = string.Empty;
            current_AllFriends.Remove(user);
        }
    }
}
