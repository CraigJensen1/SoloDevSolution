using System.Text.Json;

namespace SaveLogic
{
    public class Save
    {
        public Player Player { get; set; }
        public int StoryProgress { get; set; }
        public List<string> MapSecretsDiscovered { get; set; }

        public Save() { }

        public Save(Player player)
        {
            Player = player;
            StoryProgress = 0;
            MapSecretsDiscovered = new();
        }

        public void SaveProgress(int saveSlot, bool test = false)
        {
            var saveData = JsonSerializer.Serialize<Save>(
                new Save
                {
                    Player = Player,
                    StoryProgress = StoryProgress,
                    MapSecretsDiscovered = MapSecretsDiscovered,
                }
            );
            string fileName = $"file{saveSlot}.json";
            if (test)
            {
                File.WriteAllText(fileName, saveData);
                return;
            }
            File.WriteAllText($"./ClassLibrary/AstridClasses/SaveFiles/{fileName}", saveData);
        }

        public void LoadProgress(int saveSlot, bool test = false)
        {
            Save loadedSaveData = new();
            string fileName = $"file{saveSlot}.json";
            string fileData;
            if (test)
            {
                fileData = File.ReadAllText($"./{fileName}");
                loadedSaveData = JsonSerializer.Deserialize<Save>(fileData);
            }
            else
            {
                fileData = File.ReadAllText($"./ClassLibrary/AstridClasses/SaveFiles/{fileName}");
                loadedSaveData = JsonSerializer.Deserialize<Save>(fileData);
            }
            
            Player = loadedSaveData.Player;
            StoryProgress = loadedSaveData.StoryProgress;
            MapSecretsDiscovered = loadedSaveData.MapSecretsDiscovered;
        }
    }
}
