using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SaveFileDisplay : MonoBehaviour
{
    public string SaveName;
    [SerializeField] TMP_Text newSaveText;
    [SerializeField] TMP_Text saveNameText;
    [SerializeField] TMP_Text dateText;
    [SerializeField] TMP_Text timeText;

    public Button Button { get; private set; }
    public SaveFile SaveFile { get; private set; } = null;

    private void Awake()
    {
        Button = GetComponent<Button>();
    }

    public void SetSave(SaveFile saveFile)
    {
        this.SaveFile = saveFile;
        bool savePresent = saveFile != null;

        newSaveText.enabled = !savePresent;

        saveNameText.enabled = savePresent;
        dateText.enabled = savePresent;
        timeText.enabled = savePresent;

        saveNameText.text = SaveName;

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
}
