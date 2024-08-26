using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InkStoryDisplay : MonoBehaviour
{
    [SerializeField] Button choiceButtonPrefab;
    [SerializeField] Dictionary<string, SpeakerProfileSO> nameToSpeakerProfile = new();
    [SerializeField] Image speakerImage;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text dialogueText;

    SpeakerProfileSO currentSpeaker;

    string folderPath = "Assets/SpeakerProfiles";
    List<UnityEngine.Object> scriptableObjects = new();
    System.Type scriptableObjectType = typeof(SpeakerProfileSO);

    private void Awake()
    {
        ParseSpeakerProfiles();
    }

    public void SetSpeech(string text)
    {
        // TODO: typewriter effect
        dialogueText.text = text;
    }

    public void SetUpChoices(Story story)
    {
        foreach (Choice choice in story.currentChoices)
        {
            Button choiceButton = Instantiate(choiceButtonPrefab) as Button;
            choiceButton.onClick.AddListener(delegate {
                OnClickChoiceButton(story, choice);
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

    private void OnClickChoiceButton(Story story, Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
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
            Debug.LogError("ERM could not fild the speaker profiles");
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
