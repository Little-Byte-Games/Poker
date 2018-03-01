using System;

namespace Poker.Forms.Models
{
    public class Reminder
    {
        public int ID { get; set; }
        public string Name { get; set; }

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
