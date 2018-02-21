using Newtonsoft.Json;
using PCLStorage;
using Poker.Forms.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poker.Forms
{
    public class ReminderManager
    {
        private const string SaveFile = "Reminders.json";

        private readonly List<Reminder> reminders = new List<Reminder>();

        public IReadOnlyCollection<Reminder> Reminders => reminders;

        public Reminder this[int id] => reminders.First(r => r.ID == id);

        public async Task Load()
        {
            IFolder root = FileSystem.Current.LocalStorage;
            var remindersFile = await root.CreateFileAsync(SaveFile, CreationCollisionOption.OpenIfExists);

            var text = await remindersFile.ReadAllTextAsync();

            List<Reminder> savedReminders = JsonConvert.DeserializeObject<List<Reminder>>(text);
            reminders.AddRange(savedReminders);
        }

        public async Task Add(Reminder reminder)
        {
            reminders.Add(reminder);
            await Save();
        }

        public async Task Save()
        {
            await Task.CompletedTask;
            //var saveData = JsonConvert.SerializeObject(reminders);

            //IFolder root = FileSystem.Current.LocalStorage;
            //var remindersFile = await root.GetFileAsync(SaveFile);
            //await remindersFile.WriteAllTextAsync(saveData);
        }
    }
}