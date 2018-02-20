using System.Collections.Generic;
using Poker.Forms.Views.Pages;
using System.Windows.Input;
using Poker.Forms.Models;
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
            Application.Current.MainPage = new ReminderPage(reminderManager);
        }
    }
}
