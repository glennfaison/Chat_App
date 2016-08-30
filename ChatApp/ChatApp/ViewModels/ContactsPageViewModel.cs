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

        public ObservableCollection<User> AllFriends { get { return _allFriends; } }
        public ObservableCollection<RecentConversation> RecentConversations { get { return _recentConversations; } }


        public ContactsPageViewModel()
        {
            _allFriends = Facades.ContactFacade.GetAllContacts(out error);
            _recentConversations = Facades.ContactFacade.GetRecentConversations(out error);
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
