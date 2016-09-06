using ChatApp.Facades;
using ChatApp.Models.Csharp;
using ChatApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ChatApp.Views
{
    /// <summary>
    /// Chat page.
    /// </summary>
    public sealed partial class ContactsPage : Page
    {
        private ContactsPageViewModel _vm;
        public ListView RecentConversationsListView { get { return recentConversationsListView; } }
        public ContactsPage()
        {
            this.InitializeComponent();

            _vm = new ContactsPageViewModel();
            DataContext = _vm;
            ContactFacade.ContactPage = this;
        }
        /// <summary>
        /// Invoked when an item on the recentConversationsListView is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void recentConversationsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //profile to use for 'currentCorrespondentButton' in chatpage.
            Profile _profile = ContactFacade.GetProfile(e.ClickedItem as RecentConversation);
            if (AppShellNavigation.AppShell.IsInMobileMode)
            {
                AppShellNavigation.AppShell.ShowChatPageOnly();
            }
            if (_profile != null)
            {
                if (MessageFacade.Correspondent == null || MessageFacade.Correspondent.User.Id != _profile.User.Id)
                {
                    MessageFacade.Correspondent = _profile;
                    AppShellNavigation.ChatFrame.Navigate(typeof(ChatPage), _profile);
                }
            }
        }
        /// <summary>
        /// Invoked when an item on the friendsListView is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void friendsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //profile to use for 'currentCorrespondentButton' in chatpage.
            Profile _profile = e.ClickedItem as Profile;
            if (AppShellNavigation.AppShell.IsInMobileMode)
            {
                AppShellNavigation.AppShell.ShowChatPageOnly();
            }
            if (_profile != null)
            {
                if (MessageFacade.Correspondent == null || MessageFacade.Correspondent.User.Id != _profile.User.Id)
                {
                    MessageFacade.Correspondent = _profile;
                    AppShellNavigation.ChatFrame.Navigate(typeof(ChatPage), _profile);
                }
            }
        }

        #region Tab navigations.
        private void recentConversationButton_Click(object sender, RoutedEventArgs e)
        {
            recentConversationsTab.IsSelected = true;
        }
        private void friendsButton_Click(object sender, RoutedEventArgs e)
        {
            friendsTab.IsSelected = true;
        }
        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            settingsTab.IsSelected = true;
        }
        #endregion End of tab navigations.
    }
}
