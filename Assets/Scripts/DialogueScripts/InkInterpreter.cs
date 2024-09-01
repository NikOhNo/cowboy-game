using Ink.Runtime;
using Ink.UnityIntegration;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InkInterpreter : MonoBehaviour
{
    [SerializeField] private InkStoryDisplay inkStoryDisplay;

    public void PlayStory(TextAsset storyJSON)
    {
        Debug.Log($"Playing story: {storyJSON.name}");

        Story story = new(storyJSON.text);
        story.BindExternalFunction("SetSpeaker", (string name) => inkStoryDisplay.SetSpeaker(name));

        inkStoryDisplay.OnChoiceMade.AddListener(() => ContinueUntilChoice(story));
        inkStoryDisplay.ShowDisplay();
        ContinueUntilChoice(story);
    }

    private void ContinueUntilChoice(Story story)
    {
        while (story.canContinue)
        {
            string newDialogue = story.Continue();
            newDialogue = newDialogue.Trim();
            inkStoryDisplay.SetSpeech(newDialogue);
        }

        if (story.currentChoices.Count > 0)
        {
            inkStoryDisplay.SetUpChoices(story);
        }
        else
        {
            inkStoryDisplay.ShowEndButton();
        }
    }
}
