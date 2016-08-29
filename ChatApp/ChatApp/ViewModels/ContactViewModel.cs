using ChatApp.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ChatApp.ViewModels
{
    public class ContactViewModel : INotifyPropertyChanged
    {
        public ContactViewModel(User contact)
        {
            Contact = contact;
        }
        public User Contact { get; set; }
        public int Id
        {
            get { return Contact.Id; }
        }
        public string UserName
        {
            get { return Contact.Username; }
        }
        public string Email
        {
            get { return Contact.Email; }
        }
        public string ImagePath
        {
            get { return Contact.ImagePath; }
        }
        public string LastSeen
        {
            get { return "online"; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
