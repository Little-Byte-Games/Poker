using Poker.Forms.ViewModels;
using Xamarin.Forms.Xaml;

namespace Poker.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage
    {
        public MainPage(ReminderManager reminderManager)
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel(reminderManager);
        }
    }
}