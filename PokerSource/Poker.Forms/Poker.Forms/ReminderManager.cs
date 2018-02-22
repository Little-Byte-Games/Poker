using Newtonsoft.Json;
using Plugin.NetStandardStorage.Abstractions.Interfaces;
using Plugin.NetStandardStorage.Abstractions.Types;
using Plugin.NetStandardStorage.Implementations;
using Poker.Forms.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Poker.Forms
{
    public class ReminderManager
    {
        private const string SaveFile = "Reminders.json";

        private readonly FileSystem fileSystem;
        private readonly List<Reminder> reminders = new List<Reminder>();

        public ReminderManager()
        {
            fileSystem = new FileSystem();
        }

        public IReadOnlyCollection<Reminder> Reminders => reminders;

        public Reminder this[int id] => reminders.First(r => r.ID == id);

        public void Load()
        {
            IFolder root = fileSystem.LocalStorage;
            var remindersFile = root.CreateFile(SaveFile, CreationCollisionOption.OpenIfExists);

            byte[] buffer;
            using(var stream = remindersFile.Open(FileAccess.Read))
            {
                buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
            }

            var text = Encoding.Default.GetString(buffer);
            List<Reminder> savedReminders = JsonConvert.DeserializeObject<List<Reminder>>(text);
            if(savedReminders != null)
            {
                reminders.AddRange(savedReminders);
            }
        }

        public void Add(Reminder reminder)
        {
            reminders.Add(reminder);
            Save();
        }

        public void Save()
        {
            var saveData = JsonConvert.SerializeObject(reminders);

            IFolder root = fileSystem.LocalStorage;
            var remindersFile = root.GetFile(SaveFile);
            remindersFile.WriteAllText(saveData);
        }
    }
}