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
        /// Invoked when the selection on the recentConversationsListView is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void recentConversationsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //profile to use for 'currentCorrespondentButton' in chatpage.
            Profile _profile = ContactFacade.GetProfile(recentConversationsListView.SelectedItem as RecentConversation);
            if(_profile != null)
            {
                MessageFacade.Correspondent = _profile;
                AppShellNavigation.ChatFrame.Navigate(typeof(ChatPage), _profile);
            }
        }
        /// <summary>
        /// Invoked when the selection on the friendsListView is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void friendsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //profile to use for 'currentCorrespondentButton' in chatpage.
            Profile _profile = friendsListView.SelectedItem as Profile;
            if (_profile != null)
            {
                MessageFacade.Correspondent = _profile;
                AppShellNavigation.ChatFrame.Navigate(typeof(ChatPage), _profile);
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
