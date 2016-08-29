using ChatApp.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ChatApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        static public int MinViewWidth { get; set; } = 620;
        static public int PaneWidth { get; set; } = 330;
        internal ListView RecentlyContactedList
        {
            get { return recentlyContactedList; }
        }
        internal TextBox TextBox1
        {
            get { return textBox; }
        }

        public HomePage()
        {
            DataContext = new HomeViewModel(this);
            InitializeComponent();
        }
        void fullScreenButton_Click(object sender, RoutedEventArgs e)
        {
            if (retractibleColumnDefinition.Width != new GridLength(PaneWidth, GridUnitType.Pixel))
            {
                retractibleColumnDefinition.Width = new GridLength(PaneWidth, GridUnitType.Pixel);
                visualStateTrigger.MinWindowWidth = MinViewWidth + PaneWidth;
            }
            else
            {
                retractibleColumnDefinition.Width = new GridLength(0, GridUnitType.Pixel);
                visualStateTrigger.MinWindowWidth = MinViewWidth;
            }
        }
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ((HomeViewModel)DataContext).TextBoxContent = ((TextBox)sender).Text;
            if (!string.IsNullOrEmpty(textBox.Text) && !string.IsNullOrWhiteSpace(textBox.Text))
            {
                likeButton.Visibility = Visibility.Collapsed;
                sendButton.Visibility = Visibility.Visible;
            }
            else
            {
                likeButton.Visibility = Visibility.Visible;
                sendButton.Visibility = Visibility.Collapsed;
            }
        }
        private void recentlyContactedList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedContact = (RecentlyContactedViewModel)recentlyContactedList.SelectedItem;
            ((HomeViewModel)DataContext).CurrentCorrespondent =
                (selectedContact == null) ? null : HomeViewModel.GetUserWithId(selectedContact.CorrespondentId);
        }
        private void contactList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedContact = (ContactViewModel)contactList.SelectedItem;
            ((HomeViewModel)DataContext).CurrentCorrespondent =
                (selectedContact == null) ? null : selectedContact.Contact;
        }
        private void recentlyContactedButton_Click(object sender, RoutedEventArgs e)
        {
            recentlyContactedTab.IsSelected = true;
        }
        private void contactsButton_Click(object sender, RoutedEventArgs e)
        {
            contactsTab.IsSelected = true;
        }
        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            settingsTab.IsSelected = true;
        }
    }
}
