using ChatApp.Facades;
using ChatApp.ViewModels;
using System;
using System.Windows.Input;

namespace ChatApp.Commands
{
    public class SendMessageCommand : ICommand
    {
        public ChatPageViewModel ParentModel { get; set; }
        public event EventHandler CanExecuteChanged;

        public SendMessageCommand(ChatPageViewModel parentModel)
        {
            ParentModel = parentModel;
            parentModel.PropertyChanged += delegate { CanExecuteChanged?.Invoke(this, EventArgs.Empty); };
        }
        public bool CanExecute(object parameter)
        {
            return (ParentModel.ChatCorrespondent != null)
                && !string.IsNullOrWhiteSpace(ParentModel.Text);
        }
        public void Execute(object parameter)
        {
            string error;
            var messageThread = ParentModel.MessageThread;
            MessageFacade.SendMessage(ParentModel.Text, ref messageThread, out error);
            ContactFacade.ContactPage.RecentConversationsListView.SelectedIndex = 0;
            ParentModel.Text = string.Empty;
            MessageFacade.ChatPage.ClearTextBox();
        }
    }
}
