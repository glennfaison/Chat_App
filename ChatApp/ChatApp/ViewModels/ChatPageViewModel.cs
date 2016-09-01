
using ChatApp.Commands;
using ChatApp.Common;
using ChatApp.Facades;
using ChatApp.Models.Csharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatApp.ViewModels
{
    /// <summary>
    /// view model for the chat page.
    /// </summary>
    public class ChatPageViewModel : BindableBase
    {
        private ObservableCollection<Message> _messages;
        private string _text;
        private Profile _chatCorrespondent;

        /// <summary>
        /// The message text.
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
        public ObservableCollection<Message> Messages { get { return _messages; } }
        public ICommand SendMessage { get; set; }
        /// <summary>
        /// The chat correspondent.
        /// </summary>
        public Profile ChatCorrespondent
        {
            get { return _chatCorrespondent; }
            set { SetProperty(ref _chatCorrespondent, value); }
        }

        public ChatPageViewModel()
        {
            ChatCorrespondent = MessageFacade.Correspondent;
            SendMessage = new SendMessageCommand(this);
            _messages = MessageFacade.GetMessages(App.ThisUser, ChatCorrespondent.User);
        }

        /// <summary>
        /// Sets the message to text from the textbox.
        /// </summary>
        /// <param name="text"></param>
        internal void SetText(string text)
        {
            Text = text;
        }
    }
}
