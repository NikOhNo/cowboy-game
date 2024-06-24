using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InkStoryDisplay : MonoBehaviour
{
    [SerializeField] Button choiceButtonPrefab;
    [SerializeField] List<SpeakerProfileSO> speakerProfiles;
    [SerializeField] Image speakerImage;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text dialogueText;

    SpeakerProfileSO currentSpeaker;

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
        foreach (SpeakerProfileSO speaker in speakerProfiles)
        {
            if (speaker.name == name)
            {
                return speaker;
            }
        }
        Debug.LogWarning($"Could not find speaker profile with name: '{name}'. Please ensure it is spelled correctly in the ink file and that a speaker profile exists with that name and is in the list on this object.");
        return null;
    }
}
