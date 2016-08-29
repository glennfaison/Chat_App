using ChatApp.Commands;
using ChatApp.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ChatApp.Views;
using ChatApp.Storage;

namespace ChatApp.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private User currentCorrespondent;
        private string textBoxContent;
        private ObservableCollection<User> allContacts;

        public HomePage ParentPage { get; private set; }
        public User CurrentCorrespondent
        {
            get { return currentCorrespondent; }
            internal set
            {
                currentCorrespondent = value;
                OnPropertyChanged();
                LoadCurrentMessageThread();
            }
        }
        public string TextBoxContent
        {
            get { return textBoxContent; }
            internal set
            {
                textBoxContent = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<RecentlyContactedViewModel> RecentlyContacted { get; private set; } = new ObservableCollection<RecentlyContactedViewModel>();
        public ObservableCollection<Message> CurrentMessageThread { get; private set; } = new ObservableCollection<Message>();
        public ObservableCollection<User> AllContacts
        {
            get { return allContacts; }
            set
            {
                allContacts = value;
                foreach (var contact in AllContacts)
                {
                    ContactItems.Add(new ContactViewModel(contact));
                }
            }
        }
        public ObservableCollection<ContactViewModel> ContactItems { get; private set; } = new ObservableCollection<ContactViewModel>();
        public ICommand SendCurrentMessage { get; private set; }

        void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public HomeViewModel(HomePage parentPage)
        {
            ParentPage = parentPage;
            // Get dummy user
            GetThisUserDummy();
            // Get all contacts
            GetAllContacts();
            // Get all Recent Conversations
            GetAllRecentlyContacted();
            SendCurrentMessage = new SendMessageCommand(this);
        }
        void GetThisUserDummy()
        {
            App.ThisUser = new User
            {
                Username = "Glenn Faison",
                Email = "glennfaison@gmail.com",
                Id = GetHashCode(),
                ImagePath = string.Empty,
                Password = "password"
            };
        }
        void GetAllContacts()
        {
            string error;
            AllContacts = ChatAppDataModel.GetAllContacts(out error);
            if (error != string.Empty)
            {
                Common.ErrorDialog.ShowError(error);
            }
        }
        void GetAllRecentlyContacted()
        {
            string error;
            RecentlyContacted = ChatAppDataModel.GetAllRecentlyContacted(out error);
        }
        private void LoadCurrentMessageThread()
        {
            CurrentMessageThread = new ObservableCollection<Message>();
        }
        public void RemoveFromRecentlyContacted(User user)
        {
            foreach (var item in RecentlyContacted)
            {
                if (user.Id == item.CorrespondentId)
                {
                    RecentlyContacted.Remove(item);
                    break;
                }
            }
            if (RecentlyContacted == null)
            {
                RecentlyContacted = new ObservableCollection<RecentlyContactedViewModel>();
            }
        }
        public void AddToCurrentMessageThread(Message message, out string error)
        {
            error = string.Empty;
            if (CurrentCorrespondent != null)
            {
                CurrentMessageThread.Add(message);
            }
        }
        public void SendMessage(string content, User receiver, out string error)
        {
            error = string.Empty;
            Message currentMessage = new Message
            {
                Content = content,
                DateTime = DateTime.Now,
                Receiver = receiver,
                Sender = App.ThisUser
            };
            AddToCurrentMessageThread(currentMessage, out error);
            AddToRecentlyContacted(currentMessage);
        }
        public static User GetUserWithId(int id)
        {
            string error;
            var allContacts = ChatAppDataModel.GetAllContacts(out error);
            foreach (var contact in allContacts)
            {
                if (contact.Id == id)
                {
                    return contact;
                }
            }
            return null;
        }
        public void AddToRecentlyContacted(Message message)
        {
            string error;
            RemoveFromRecentlyContacted(ChatAppDataModel.GetCorrespondent(message, out error));
            RecentlyContacted.Insert(0, new RecentlyContactedViewModel(message));
        }
    }
}
