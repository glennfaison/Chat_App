using ChatApp.ViewModels;
using System;
using System.Windows.Input;

namespace ChatApp.Commands
{
    public class SendMessageCommand : ICommand
    {
        public HomeViewModel ParentModel { get; private set; }

        public event EventHandler CanExecuteChanged;

        public SendMessageCommand(HomeViewModel parentModel)
        {
            ParentModel = parentModel;
            ParentModel.PropertyChanged += delegate { CanExecuteChanged?.Invoke(this, EventArgs.Empty); };
        }
        public bool CanExecute(object parameter)
        {
            return (ParentModel.CurrentCorrespondent != null)
                && !string.IsNullOrWhiteSpace(ParentModel.TextBoxContent);
        }
        public void Execute(object parameter)
        {
            string error;
            ParentModel.SendMessage(ParentModel.TextBoxContent, ParentModel.CurrentCorrespondent, out error);
            ParentModel.ParentPage.RecentlyContactedList.SelectedIndex = 0;
            ParentModel.ParentPage.TextBox1.Text = string.Empty;
        }
    }
}
