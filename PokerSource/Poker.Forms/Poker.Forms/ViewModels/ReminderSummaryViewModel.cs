using Poker.Forms.Annotations;
using Poker.Forms.Global;
using Poker.Forms.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Poker.Forms.ViewModels
{
    public class ReminderSummaryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event Action<Reminder> SelectEvent;
        public event Action EnabledEvent;

        private readonly Reminder reminder;

        public string Name => reminder.Name;
        public Color MainColor => reminder.IsDisabled ? Color.Gray : !reminder.IsAvailable ? Color.Transparent : Colors.ThemeColors[reminder.Color];
        public Color BorderColor => reminder.IsAvailable ? Color.Transparent : Color.Black;
        public string AlarmCounts => $"{reminder.CurrentAlarmCount}/{reminder.MaxAlarmCount}";
        public double Progress => (double)reminder.CurrentAlarmCount / reminder.MaxAlarmCount;
        public Command SelectReminder { get; }

        public bool IsEnabled
        {
            get => !reminder.IsDisabled;
            set
            {
                if(reminder.IsDisabled != value)
                {
                    return;
                }

                reminder.IsDisabled = !value;
                OnPropertyChanged(nameof(MainColor));
                EnabledEvent?.Invoke();
            }
        }

        public ReminderSummaryViewModel(Reminder reminder)
        {
            this.reminder = reminder;

            SelectReminder = new Command(OnSelectReminder);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnSelectReminder()
        {
            // TODO: Remove temp alarm progress.
            ++reminder.CurrentAlarmCount;
            SelectEvent?.Invoke(reminder);
        }
    }
}