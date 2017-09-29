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
    /// Chat Page.
    /// </summary>
    public sealed partial class ChatPage : Page
    {
        private ChatPageViewModel _vm;

        public ChatPage()
        {
            InitializeComponent();
            _vm = new ChatPageViewModel();
            DataContext = _vm;
            MessageFacade.ChatPage = this;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _vm.ChatCorrespondent = e.Parameter as Profile;
        }
        public void ClearTextBox()
        {
            textBox.Text = string.Empty;
        }        
        /// <summary>
        /// Occures when the full screen button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        /// It would make more sense for this to be a toggle button.
        void fullScreenButton_Click(object sender, RoutedEventArgs e)
        {
            if (!AppShellNavigation.AppShell.IsFullScreen)
            {
                AppShellNavigation.AppShell.ShowChatPageOnly();
            }
            else
            {
                AppShellNavigation.AppShell.ShowContactPage();
            }
        }
        /// <summary>
        /// Sets the current message text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _vm.Text = textBox.Text;
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
        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if(e.NewSize.Width < 620)
            {
                Grid.SetRow(appBarButtons, 1);
                Grid.SetColumn(appBarButtons, 0);
            }
            else
            {
                Grid.SetRow(appBarButtons, 0);
                Grid.SetColumn(appBarButtons, 1);
            }
        }
        private void scrollViewer_Loaded(object sender, object e)
        {
            this.scrollViewer.ChangeView(null, this.scrollViewer.ScrollableHeight, null, false);
        }
    }
}
