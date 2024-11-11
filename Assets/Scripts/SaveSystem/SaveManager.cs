using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public string savePath;
    public SaveFile saveFile;

    private void Awake()
    {
        savePath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveFile.json";

        if (File.Exists(savePath))
        {
            LoadGame();   
        }
        else
        {
            Debug.LogError("SaveFile not found, creating new save");
            saveFile = new();
            SaveGame();
        }
    }

    public void SaveGame()
    {
        File.WriteAllBytes(savePath, Encoding.UTF8.GetBytes(JsonUtility.ToJson(saveFile, true)));
    }

    public void LoadGame()
    {
        byte[] jsonData = File.ReadAllBytes(savePath);
        string json = Encoding.UTF8.GetString(jsonData);
        saveFile = JsonUtility.FromJson<SaveFile>(json);
    }
}
