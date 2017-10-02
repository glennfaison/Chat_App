using ChatApp.Common;
using ChatApp.Facades;
using ChatApp.Models.Csharp;
using System.Collections.ObjectModel;

namespace ChatApp.ViewModels
{

    /// <summary>
    /// View model for contacts page.
    /// </summary>
    public class ContactsPageViewModel : BindableBase
    {
        private readonly string error;
        public static ObservableCollection<User> _allFriends;
        public static ObservableCollection<RecentConversation> _recentConversations;

        public ObservableCollection<User> AllFriends => _allFriends;
        public ObservableCollection<RecentConversation> RecentConversations => _recentConversations;
        public ObservableCollection<Profile> Friends { get; }

        public ContactsPageViewModel()
        {
            _allFriends = ContactFacade.GetAllFriends(out error);
            _recentConversations = ContactFacade.GetRecentConversations(out error);
            Friends = ContactFacade.GetFriendProfiles();
        }
    }
}
