using Poker.Forms.Models;
using Poker.Forms.ViewModels;
using Xamarin.Forms.Xaml;

namespace Poker.Forms.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReminderPage
    {
        public ReminderPage(ReminderManager reminderManager, Reminder reminder = null)
        {
            InitializeComponent();

            BindingContext = new ReminderPageViewModel(reminderManager, reminder);
        }
    }
}