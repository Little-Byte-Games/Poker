using Poker.Forms.Annotations;
using Poker.Forms.Models;
using System;
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
        private readonly bool isNewReminder;

        public bool Monday
        {
            get => reminder.Days.Contains(DayOfWeek.Monday);
            set
            {
                ToggleDay(DayOfWeek.Monday, value);
                OnPropertyChanged(nameof(Monday));
            }
        }
        public bool Tuesday
        {
            get => reminder.Days.Contains(DayOfWeek.Tuesday);
            set
            {
                ToggleDay(DayOfWeek.Tuesday, value);
                OnPropertyChanged(nameof(Tuesday));
            }
        }
        public bool Wednesday
        {
            get => reminder.Days.Contains(DayOfWeek.Wednesday);
            set
            {
                ToggleDay(DayOfWeek.Wednesday, value);
                OnPropertyChanged(nameof(Wednesday));
            }
        }
        public bool Thursday
        {
            get => reminder.Days.Contains(DayOfWeek.Thursday);
            set
            {
                ToggleDay(DayOfWeek.Thursday, value);
                OnPropertyChanged(nameof(Thursday));
            }
        }
        public bool Friday
        {
            get => reminder.Days.Contains(DayOfWeek.Friday);
            set
            {
                ToggleDay(DayOfWeek.Friday, value);
                OnPropertyChanged(nameof(Friday));
            }
        }

        public ICommand CancelCommand { get; set; }
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

            isNewReminder = reminder == null;
            this.reminder = new Reminder();
            if(reminder != null)
            {
                reminder.CopyTo(this.reminder);
            }

            CancelCommand = new Command(OnCancel);
            SaveCommand = new Command(OnSave);
        }

        private void OnCancel()
        {
            LoadMainPage();
        }

        private void OnSave()
        {
            if(isNewReminder)
            {
                reminderManager.Add(reminder);
            }
            else
            {
                var oldReminder = reminderManager[reminder.ID];
                reminder.CopyTo(oldReminder);
            }

            reminderManager.Save();
            LoadMainPage();
        }

        private void LoadMainPage()
        {
            Application.Current.MainPage = new MainPage(reminderManager);
        }

        private void ToggleDay(DayOfWeek day, bool on)
        {
            if(on)
            {
                reminder.Days.Add(day);
            }
            else
            {
                reminder.Days.Remove(day);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}