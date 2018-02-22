using Xamarin.Forms;
#if !DEBUG
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
#endif

namespace Poker.Forms
{
    public partial class App : Application
    {
        public ReminderManager Reminders { get; }

        public App()
        {
            InitializeComponent();

            Reminders = new ReminderManager();

        }

        protected override void OnStart()
        {
#if !DEBUG
            AppCenter.Start("android=7dfc628b-a3ef-4e07-92c3-7abe7a646971;", typeof(Analytics), typeof(Crashes)); 
#endif

            Reminders.Load();
            MainPage = new MainPage(Reminders);
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}