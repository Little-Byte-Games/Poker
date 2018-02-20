using Poker.Forms.ViewModels;

namespace Poker.Forms
{
    public partial class MainPage
    {
        public MainPage(ReminderManager reminderManager)
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel(reminderManager);
        }
    }
}