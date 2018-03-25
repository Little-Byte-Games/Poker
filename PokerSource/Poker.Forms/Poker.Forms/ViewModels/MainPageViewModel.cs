using Poker.Forms.Models;
using Poker.Forms.Views.Pages;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Poker.Forms.ViewModels
{
    public class MainPageViewModel
    {
        private readonly ReminderManager reminderManager;

        public IReadOnlyCollection<Reminder> Reminders => reminderManager.Reminders;
        public ICommand AddReminderCommand { get; set; }

        public MainPageViewModel(ReminderManager reminderManager)
        {
            this.reminderManager = reminderManager;

            AddReminderCommand = new Command(OnAddReminderClick);
        }

        private void OnAddReminderClick()
        {
            LoadReminderPage();
        }

        public void LoadReminderPage(Reminder reminder = null)
        {
            var reminderPage = new ReminderPage(reminderManager, reminder);
            Application.Current.MainPage = reminderPage;
        }
    }
}