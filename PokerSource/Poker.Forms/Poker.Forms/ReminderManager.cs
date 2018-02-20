using Poker.Forms.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PCLStorage;

namespace Poker.Forms
{
    public class ReminderManager
    {
        private const string SaveFile = "Reminders.json";

        private readonly List<Reminder> reminders = new List<Reminder>();

        public IReadOnlyCollection<Reminder> Reminders => reminders;

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
            //await Save();
            await Task.CompletedTask;
        }

        private async Task Save()
        {
            var saveData = JsonConvert.SerializeObject(reminders);

            IFolder root = FileSystem.Current.LocalStorage;
            var remindersFile = await root.GetFileAsync(SaveFile);
            await remindersFile.WriteAllTextAsync(saveData);
        }
    }
}