using System;
using System.Collections.Generic;

namespace Poker.Forms.Models
{
    public class Reminder
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public HashSet<DayOfWeek> Days { get; set; } = new HashSet<DayOfWeek>();
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

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