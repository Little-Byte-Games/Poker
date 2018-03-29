using Poker.Forms.Models;
using Poker.Forms.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Poker.Forms.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReminderPage
    {
        private readonly ReminderPageViewModel viewModel;

        public ReminderPage(ReminderManager reminderManager, Reminder reminder = null)
        {
            InitializeComponent();

            viewModel = new ReminderPageViewModel(reminderManager, reminder);
            BindingContext = viewModel;
        }

        private void OnRepeatCountChanged(object sender, TextChangedEventArgs args)
        {
            viewModel.OnRepeatCountChanged(args.NewTextValue);
        }

        private void OnMinimumTimeBetweenChanged(object sender, TextChangedEventArgs args)
        {
            viewModel.OnMinimumTimeBetweenChanged(args.NewTextValue);
        }
    }
}