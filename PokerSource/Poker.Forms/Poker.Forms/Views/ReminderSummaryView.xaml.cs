using Poker.Forms.ViewModels;
using Xamarin.Forms.Xaml;

namespace Poker.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReminderSummaryView
    {
        public ReminderSummaryView(ReminderSummaryViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}