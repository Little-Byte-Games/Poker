using Poker.Forms.ViewModels;
using Poker.Forms.Views;
using Xamarin.Forms.Xaml;

namespace Poker.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage
    {
        public MainPage(ReminderManager reminderManager)
        {
            InitializeComponent();

            var viewModel = new MainPageViewModel(reminderManager);
            BindingContext = viewModel;

            foreach(var reminder in reminderManager.Reminders)
            {
                var summaryViewModel = new ReminderSummaryViewModel(reminder);
                var summaryView = new ReminderSummaryView(summaryViewModel);
                summaryViewModel.SelectEvent += viewModel.LoadReminderPage;
                summaryViewModel.EnabledEvent += reminderManager.Save;
                ReminderList.Children.Add(summaryView);
            }
        }
    }
}