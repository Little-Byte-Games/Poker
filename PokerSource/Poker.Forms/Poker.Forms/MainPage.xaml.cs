using Poker.Forms.ViewModels;
using Poker.Forms.Views;
using Xamarin.Forms;
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

            var reminderCount = reminderManager.Reminders.Count;
            var columnCount = ReminderGrid.ColumnDefinitions.Count;
            var rowCount = reminderCount / columnCount + reminderCount % 2;

            for (int i = 0; i < rowCount; i++)
            {
                    var rowDefinition = new RowDefinition { Height = GridLength.Auto };
                    ReminderGrid.RowDefinitions.Add(rowDefinition);

                    for (int j = 0; j < columnCount; j++)
                    {
                        var reminderIndex = columnCount * i + j;
                        if (reminderIndex >= reminderManager.Reminders.Count)
                        {
                            break;
                        }

                        var reminder = reminderManager.Reminders[reminderIndex];
                        var summaryViewModel = new ReminderSummaryViewModel(reminder);
                        var summaryView = new ReminderSummaryView(summaryViewModel);
                        summaryViewModel.SelectEvent += viewModel.LoadReminderPage;
                        summaryViewModel.EnabledEvent += reminderManager.Save;
                        reminderCount--;

                        ReminderGrid.Children.Add(summaryView);
                        Grid.SetRow(summaryView, i);
                        Grid.SetColumn(summaryView, j);
                    }
               
            }
        }
    }
}