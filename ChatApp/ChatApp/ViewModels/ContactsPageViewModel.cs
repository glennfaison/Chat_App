using ChatApp.Common;
using ChatApp.Models.Csharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.ViewModels
{

    /// <summary>
    /// View model for contacts page.
    /// </summary>
    public class ContactsPageViewModel : BindableBase
    {
        private string error;
        private ObservableCollection<User> _allFriends;
        private ObservableCollection<RecentConversation> _recentConversations;
        private ObservableCollection<Profile> _friends;

        public ObservableCollection<User> AllFriends { get { return _allFriends; } }
        public ObservableCollection<RecentConversation> RecentConversations { get { return _recentConversations; } }
        public ObservableCollection<Profile> Friends { get { return _friends; } }
        
        public ContactsPageViewModel()
        {
            _allFriends = Facades.ContactFacade.GetAllContacts(out error);
            _recentConversations = Facades.ContactFacade.GetRecentConversations(out error);
            _friends = GetFriendProfiles();
        }
        /// <summary>
        /// Get Friends' Profiles, depending on the selection parameters
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<Profile> GetFriendProfiles(bool onlineOnly = false)
        {
            var ret = new ObservableCollection<Profile>();
            foreach(var user in _allFriends)
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
        /// <returns></returns>
        public Profile GetProfile(RecentConversation recentConversation)
        {
            //dummy
            return new Profile
            {
                User = recentConversation.User,
                LastActive = DateTime.Now,
            };
        }
    }
}
