using Newtonsoft.Json;
using PCLStorage;
using Poker.Forms.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Poker.Forms
{
    public partial class MainPage
    {
        private const string SaveFile = "Reminders.json";
        public ObservableCollection<Reminder> Reminders { get; set; } = new ObservableCollection<Reminder>();
        public ICommand AddReminderCommand { get; set; }

        public MainPage()
        {
            InitializeComponent();

            AddReminderCommand = new Command(async () => await OnAddReminderClick());

            BindingContext = this;

            Task.Factory.StartNew(LoadReminders);
        }

        public async Task OnAddReminderClick()
        {
            Reminders.Add(new Reminder());
            var savedReminders = new List<Reminder>(Reminders);
            var saveData = JsonConvert.SerializeObject(savedReminders);

            IFolder root = FileSystem.Current.LocalStorage;
            var remindersFile = await root.GetFileAsync(SaveFile);
            await remindersFile.WriteAllTextAsync(saveData);
        }

        public async Task LoadReminders()
        {
            IFolder root = FileSystem.Current.LocalStorage;
            var remindersFile = await root.CreateFileAsync(SaveFile, CreationCollisionOption.OpenIfExists);

            var text = await remindersFile.ReadAllTextAsync();

            List<Reminder> savedReminders = JsonConvert.DeserializeObject<List<Reminder>>(text);
            foreach(var savedReminder in savedReminders)
            {
                Reminders.Add(savedReminder);
            }
        }
    }
}