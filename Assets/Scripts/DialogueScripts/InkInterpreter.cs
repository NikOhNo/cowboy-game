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

        inkStoryDisplay.OnChoiceMade.RemoveAllListeners();
        inkStoryDisplay.OnContinue.RemoveAllListeners();

        inkStoryDisplay.OnChoiceMade.AddListener(() => StartCoroutine(ContinueStoryFlow(story)));
        inkStoryDisplay.OnContinue.AddListener(() => StartCoroutine(ContinueStoryFlow(story)));

        inkStoryDisplay.ShowDisplay();

        StartCoroutine(ContinueStoryFlow(story));
    }

    IEnumerator ContinueStoryFlow(Story story)
    {
        // Begin Current Speech
        if (story.canContinue)
        {
            string speech = story.Continue();
            speech = speech.Trim();
            inkStoryDisplay.BeginSpeech(speech);
        }

        // Wait for Speech to Complete
        while (!inkStoryDisplay.SpeechComplete)
        {
            yield return null;
        }

        // Decide What To Do After Speech
        if (story.canContinue)
        {
            inkStoryDisplay.ShowContinueButton();
        }
        else if (story.currentChoices.Count > 0)
        {
            inkStoryDisplay.SetUpChoices(story);
        }
        else
        {
            inkStoryDisplay.ShowEndButton();
        }
    }
}
