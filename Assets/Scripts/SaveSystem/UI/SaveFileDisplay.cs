using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class SaveFileDisplay : MonoBehaviour
{
    [SerializeField] string saveName;
    [SerializeField] TMP_Text newSaveText;
    [SerializeField] TMP_Text saveNameText;
    [SerializeField] TMP_Text dateText;
    [SerializeField] TMP_Text timeText;
    [SerializeField] SaveManager saveManager;

    SaveFile saveFile = null;

    public void SetSave(SaveFile saveFile)
    {
        this.saveFile = saveFile;
        bool savePresent = saveFile != null;

        newSaveText.enabled = !savePresent;

        saveNameText.enabled = savePresent;
        dateText.enabled = savePresent;
        timeText.enabled = savePresent;

        saveNameText.text = saveName;

        if (saveFile != null)
        {
            // Parse back into DateTime
            DateTime parsedDate = DateTime.ParseExact(saveFile?.saveDate, "yyyy-MM-dd", null);
            DateTime parsedTime = DateTime.ParseExact(saveFile?.saveTime, "HH:mm:ss", null);

            // Reformat to more readable formats
            string readableDate = parsedDate.ToString("MM/dd/yyyy"); 
            string readableTime = parsedTime.ToString("h:mm tt");

            dateText.text = "Date: " + readableDate;
            timeText.text = "Time: " + readableTime;
        }
    }

    public void OnSaveFilePressed()
    {
        // TODO: load saves & start game

        if (saveFile == null)
        {
            Debug.Log($"Creating save: {saveName}");
            saveManager.CreateNewSave(saveName);
        }
        else
        {

        }
    }
}
