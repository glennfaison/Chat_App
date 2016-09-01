using ChatApp.Common;
using ChatApp.Facades;
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
            _allFriends = ContactFacade.GetAllFriends(out error);
            _recentConversations = ContactFacade.GetRecentConversations(out error);
            _friends = ContactFacade.GetFriendProfiles(ref _allFriends);
            ContactFacade.RecentConversations = _recentConversations;
        }
    }
}
