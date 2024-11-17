using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Rendering;

public class SaveManager : MonoBehaviour
{
    public string SavePath => Application.persistentDataPath + Path.AltDirectorySeparatorChar;

    public void CreateNewSave(string saveName)
    {
        SaveFile saveFile = new();
        saveFile.saveName = saveName;
        UpdateSave(saveFile);
    }

    public void UpdateSave(SaveFile saveFile)
    {
        saveFile.UpdateSaveMetadata();
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
