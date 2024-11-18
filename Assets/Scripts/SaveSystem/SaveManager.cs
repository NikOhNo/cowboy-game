using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public string SavePath => Application.persistentDataPath + Path.AltDirectorySeparatorChar;

    public SaveFile CreateNewSave(string saveName)
    {
        SaveFile saveFile = new();
        saveFile.saveName = saveName;
        saveFile.lastScene = "Town Scene";
        UpdateSave(saveFile, false);
        return saveFile;
    }

    public void UpdateSave(SaveFile saveFile, bool recordScene)
    {
        saveFile.UpdateSaveMetadata();
        if (recordScene) saveFile.lastScene = SceneManager.GetActiveScene().name;
        string saveJson = JsonConvert.SerializeObject(saveFile, Formatting.Indented);
        File.WriteAllText(SavePath + saveFile.saveName + ".json", saveJson);
    }

    public List<SaveFile> LoadSaves()
    {
        List<SaveFile> saveFiles = new();
        string[] saveFilePaths = Directory.GetFiles(SavePath, "*.json");

        foreach (string saveFilePath in saveFilePaths)
        {
            string saveJson = File.ReadAllText(saveFilePath);
            SaveFile saveFile = JsonConvert.DeserializeObject<SaveFile>(saveJson);

            if (saveFile != null)
            {
                saveFiles.Add(saveFile);
            }
        }

        return saveFiles;
    }
}
