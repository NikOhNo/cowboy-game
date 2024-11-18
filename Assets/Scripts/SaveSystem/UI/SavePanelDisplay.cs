using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SavePanelDisplay : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] List<SaveFileDisplay> saveDisplays = new();
    [SerializeField] SaveManager saveManager;
    [SerializeField] SceneSwitcher sceneSwitcher;

    public void OpenDisplay()
    {
        gameObject.SetActive(true);
        List<SaveFile> saveFiles = saveManager.LoadSaves();

        for (int i = 0; i < saveDisplays.Count; i++)
        {
            int index = i;

            saveDisplays[index].SetSave(saveFiles.ElementAtOrDefault(index));
            saveDisplays[index].Button.onClick.RemoveAllListeners();
            saveDisplays[index].Button.onClick.AddListener(() => OnSaveFilePressed(saveDisplays[index]));
        }
    }

    public void CloseDisplay()
    {
        gameObject.SetActive(false);
    }

    public void OnSaveFilePressed(SaveFileDisplay saveDisplay)
    {
        // TODO: load saves & start game

        if (saveDisplay.SaveFile == null)
        {
            Debug.Log($"Creating save: {saveDisplay.SaveName}");
            SaveFile newSave = saveManager.CreateNewSave(saveDisplay.SaveName);
            gameManager.SetSave(newSave);
        }
        else
        {
            gameManager.SetSave(saveDisplay.SaveFile);
        }

        sceneSwitcher.LoadSceneName(gameManager.ChosenSave.lastScene);
    }
}
