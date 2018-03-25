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
            SelectEvent?.Invoke(reminder);
        }
    }
}
