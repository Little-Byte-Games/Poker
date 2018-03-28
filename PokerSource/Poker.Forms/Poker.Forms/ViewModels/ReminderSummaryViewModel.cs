using System;
using Poker.Forms.Models;
using Xamarin.Forms;

namespace Poker.Forms.ViewModels
{
    public class ReminderSummaryViewModel
    {
        public event Action<Reminder> SelectEvent;

        private readonly Reminder reminder;

        public string Name => reminder.Name;
        public Color MainColor { get; }
        public string AlarmCounts => $"{reminder.CurrentAlarmCount}/{reminder.MaxAlarmCount}";
        public double Progress => (double)reminder.CurrentAlarmCount / reminder.MaxAlarmCount;
        public Command SelectReminder { get; }

        public ReminderSummaryViewModel(Reminder reminder)
        {
            this.reminder = reminder;
            var random = new Random();
            MainColor = new Color(random.NextDouble(), random.NextDouble(), random.NextDouble());

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
