﻿using Poker.Forms.Annotations;
using Poker.Forms.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Poker.Forms.ViewModels
{
    public class ReminderPageViewModel : INotifyPropertyChanged
    {
        private readonly ReminderManager reminderManager;
        private readonly Reminder reminder;

        public ICommand SaveCommand { get; set; }
        public string Name
        {
            get => reminder.Name;
            set
            {
                if(value != reminder.Name)
                {
                    reminder.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public ReminderPageViewModel(ReminderManager reminderManager, Reminder reminder)
        {
            this.reminderManager = reminderManager;
            this.reminder = reminder ?? new Reminder();

            SaveCommand = new Command(OnSave);
        }

        private void OnSave()
        {
            reminderManager.Add(reminder).Wait();

            Application.Current.MainPage = new MainPage(reminderManager);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
