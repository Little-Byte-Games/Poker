using Poker.Forms.Models;
using System;
using Xamarin.Forms;

namespace Poker.Forms.ViewModels
{
    public class ReminderSummaryViewModel
    {
        public event Action<Reminder> SelectEvent;

        private readonly Reminder reminder;

        public string Name => reminder.Name;
        public Color MainColor => reminder.Color;
        public string AlarmCounts => $"{reminder.CurrentAlarmCount}/{reminder.MaxAlarmCount}";
        public double Progress => (double)reminder.CurrentAlarmCount / reminder.MaxAlarmCount;
        public Command SelectReminder { get; }

        public ReminderSummaryViewModel(Reminder reminder)
        {
            this.reminder = reminder;

            SelectReminder = new Command(OnSelectReminder);
        }

        private void OnSelectReminder()
        {
            // TODO: Remove temp alarm progress.
            ++reminder.CurrentAlarmCount;
            SelectEvent?.Invoke(reminder);
        }
    }
}
