using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Poker.Forms.Models
{
    public class Reminder
    {
        private uint maxAlarmCount = 1;
        private uint currentAlarmCount;

        public int ID { get; set; }
        public string Name { get; set; }
        public HashSet<DayOfWeek> Days { get; set; } = new HashSet<DayOfWeek>();
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Color Color { get; set; }

        public uint MaxAlarmCount
        {
            get => maxAlarmCount;
            set => maxAlarmCount = value > 0 ? value : 1;
        }
        
        public uint CurrentAlarmCount
        {
            get => currentAlarmCount;
            set => currentAlarmCount = value > maxAlarmCount ? maxAlarmCount : value;
        }


        public Reminder()
        {
            ID = Guid.NewGuid().GetHashCode();
        }

        public void CopyTo(Reminder otherReminder)
        {
            var properties = GetType().GetProperties();
            foreach(var property in properties)
            {
                var value = property.GetValue(this);
                property.SetValue(otherReminder, value);
            }
        }
    }
}