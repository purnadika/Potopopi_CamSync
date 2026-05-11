using System;
using System.IO;
using System.Text.Json;
using PotopopiCamSync.Models;

namespace PotopopiCamSync.Repositories
{
    public class JsonSettingsRepository : ISettingsRepository
    {
        private readonly string _configFilePath;
        private readonly string _stateFilePath;

        public AppConfigModel Config { get; private set; } = null!;
        public SyncStateModel State { get; private set; } = null!;

        public JsonSettingsRepository(string? customBasePath = null)
        {
            string appData = customBasePath ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PotopopiCamSync");
            if (!Directory.Exists(appData))
            {
                Directory.CreateDirectory(appData);
            }

            _configFilePath = Path.Combine(appData, "config.json");
            _stateFilePath = Path.Combine(appData, "syncstate.json");

            Load();
        }

        public void Load()
        {
            if (File.Exists(_configFilePath))
            {
                string json = File.ReadAllText(_configFilePath);
                Config = JsonSerializer.Deserialize(json, SourceGenerationContext.Default.AppConfigModel) ?? new AppConfigModel();
            }
            else
            {
                Config = new AppConfigModel();
            }

            if (File.Exists(_stateFilePath))
            {
                string json = File.ReadAllText(_stateFilePath);
                State = JsonSerializer.Deserialize(json, SourceGenerationContext.Default.SyncStateModel) ?? new SyncStateModel();
            }
            else
            {
                State = new SyncStateModel();
            }
        }

        public void SaveConfig()
        {
            string json = JsonSerializer.Serialize(Config, SourceGenerationContext.Default.AppConfigModel);
            File.WriteAllText(_configFilePath, json);
        }

        public void SaveState()
        {
            string json = JsonSerializer.Serialize(State, SourceGenerationContext.Default.SyncStateModel);
            File.WriteAllText(_stateFilePath, json);
        }
    }
}
