using ChatApp.Facades;
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
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppShell : Page
    {
        private static bool isInMobileMode = false;
        private GridLength contactColumnWidth = new GridLength(350);
        private GridLength chatColumnWidth = new GridLength(1 ,GridUnitType.Star);

        public bool IsFullScreen { get; set; }
        public bool IsInMobileMode
        {
            get { return isInMobileMode; }
            set
            {
                if(value != isInMobileMode)
                {
                    isInMobileMode = value;
                    ShowContactPage();
                }
            }
        }

        public AppShell()
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                AppShellNavigation.ChatFrame = chatFrame;
                AppShellNavigation.ContactsFrame = contactsFrame;
                AppShellNavigation.AppShell = this;
                AppShellNavigation.ContactsFrame.Navigate(typeof(ContactsPage));
            };
        }
        public void ShowChatPageOnly()
        {
            contactColumn.Width = new GridLength(0);
            chatColumn.Width = chatColumnWidth;
            IsFullScreen = true;
        }
        public void ShowContactPage()
        {
            if (IsInMobileMode)
            {
                contactColumn.Width = chatColumnWidth;
                chatColumn.Width = new GridLength(0);
            }
            else
            {
                contactColumn.Width = contactColumnWidth;
                chatColumn.Width = chatColumnWidth;
            }
            IsFullScreen = false;
        }
        private void page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var newWidth = e.NewSize.Width;
            if(newWidth < 550)
            {
                IsInMobileMode = true;
            }
            else if(newWidth >= 550)
            {
                IsInMobileMode = false;
            }
        }
    }
}
