using Poker.Forms.Models;
using Poker.Forms.Views.Pages;
using System;
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
        public Command<int> SelectReminder { get; set; }

        public MainPageViewModel(ReminderManager reminderManager)
        {
            this.reminderManager = reminderManager;

            AddReminderCommand = new Command(OnAddReminderClick);
            SelectReminder = new Command<int>(OnReminderTap);
        }

        private void OnAddReminderClick()
        {
            var reminderPage = new ReminderPage(reminderManager);
            Application.Current.MainPage = reminderPage;
        }

        private void OnReminderTap(int id)
        {
            Console.WriteLine(id);
        }
    }
}