using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SavePanelDisplay : MonoBehaviour
{
    [SerializeField] List<SaveFileDisplay> saveDisplays = new();
    [SerializeField] SaveManager saveManager;

    public void OpenDisplay()
    {
        gameObject.SetActive(true);
        List<SaveFile> saveFiles = saveManager.LoadSaves();

        for (int i = 0; i < saveDisplays.Count; i++)
        {
            saveDisplays[i].SetSave(saveFiles.ElementAtOrDefault(i));
        }
    }

    public void CloseDisplay()
    {
        gameObject.SetActive(false);
    }
}
