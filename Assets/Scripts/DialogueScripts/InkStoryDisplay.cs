using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InkStoryDisplay : MonoBehaviour
{
    [SerializeField] List<ChoiceButton> choiceButtons = new List<ChoiceButton>();
    [SerializeField] VerticalLayoutGroup choiceButtonsLayoutGroup;
    [SerializeField] Dictionary<string, SpeakerProfileSO> nameToSpeakerProfile = new();
    [SerializeField] Image speakerImage;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text dialogueText;

    public UnityEvent OnChoiceMade { get; private set; } = new();

    SpeakerProfileSO currentSpeaker;

    string folderPath = "Assets/SpeakerProfiles";
    List<UnityEngine.Object> scriptableObjects = new();
    System.Type scriptableObjectType = typeof(SpeakerProfileSO);

    private void Awake()
    {
        ParseSpeakerProfiles();
        HideDisplay();
    }

    public void SetSpeech(string text)
    {
        // TODO: typewriter effect
        dialogueText.text = text;
    }

    public void SetUpChoices(Story story)
    {
        for (int i = 0; i < story.currentChoices.Count; i++)
        {
            Choice currentChoice = story.currentChoices[i];
            choiceButtons[i].SetChoice(currentChoice, delegate {
                ClearChoiceButtons();
                story.ChooseChoiceIndex(currentChoice.index);
                OnChoiceMade.Invoke();
            });
        }
    }

    public void SetSpeaker(string name)
    {
        SpeakerProfileSO newSpeaker = FindSpeaker(name);
        if (newSpeaker == null) return;

        nameText.text = newSpeaker.name;
        speakerImage.sprite = newSpeaker.SpeakerSprite;

        currentSpeaker = newSpeaker;
    }

    public void ShowEndButton()
    {
        choiceButtons[0].SetChoice(new Choice() { text = "End." }, delegate {
            ClearChoiceButtons();
            HideDisplay();
        });
    }

    public void ShowDisplay()
    {
        gameObject.SetActive(true);
    }

    public void HideDisplay()
    {
        gameObject.SetActive(false);
    }

    public void ClearChoiceButtons()
    {
        foreach (var choiceButton in choiceButtons)
        {
            choiceButton.ClearButton();
        }
    }

    private SpeakerProfileSO FindSpeaker(string name)
    {
        try
        {
            return nameToSpeakerProfile[name];
        }
        catch
        {
            Debug.LogError($"Could not find speaker profile with name: '{name}'. Please ensure it is spelled correctly in the ink file and that a speaker profile exists with that name and is in the list on this object.");
            return null;
        }
    }

    private void ParseSpeakerProfiles()
    {
        if (!AssetDatabase.IsValidFolder(folderPath))
        {
            Debug.LogError("Could not find the speaker profiles");
        }

        if (scriptableObjectType == null)
        {
            Debug.LogError("Could not find SpeakerProfileSO type");
        }

        // Find asset GUIDs of the specified type in the folder.
        string[] guids = AssetDatabase.FindAssets("t:" + scriptableObjectType.Name, new[] { folderPath });

        // Load the assets from the GUIDs.
        foreach (string guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            UnityEngine.Object asset = AssetDatabase.LoadAssetAtPath(assetPath, scriptableObjectType);
            if (asset != null)
            {
                scriptableObjects.Add(asset);
            }
        }

        foreach (var scriptableObj in scriptableObjects)
        {
            SpeakerProfileSO speakerProfile = scriptableObj as SpeakerProfileSO;
            nameToSpeakerProfile.Add(speakerProfile.name, speakerProfile);
        }
    }
}
