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
    }
}
