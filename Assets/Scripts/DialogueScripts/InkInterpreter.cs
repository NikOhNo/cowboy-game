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
        Story story = new Story(storyJSON.text);
        story.BindExternalFunction("SetSpeaker", (string name) => inkStoryDisplay.SetSpeaker(name));

        while (story.canContinue)
        {
            string newDialogue = story.Continue();
            newDialogue = newDialogue.Trim();

            if (story.currentChoices.Count > 0)
            {
                inkStoryDisplay.SetUpChoices(story);
            }
        }
    }

    //public void StartStory(TextAsset storyJson);

}
