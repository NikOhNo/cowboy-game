using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InkStoryDisplay : MonoBehaviour
{
    [SerializeField] float fadeInTime = 0.3f;
    [SerializeField] float fadeOutTime = 0.5f;

    [SerializeField] List<ChoiceButton> choiceButtons = new List<ChoiceButton>();
    [SerializeField] VerticalLayoutGroup choiceButtonsLayoutGroup;
    [SerializeField] Dictionary<string, SpeakerProfileSO> nameToSpeakerProfile = new();
    [SerializeField] Image speakerImage;
    [SerializeField] Typewriter typewriter;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text dialogueText;
    CanvasGroup canvasGroup;
    AudioSource audioSource;

    public bool IsFadedIn { get; private set; } = false;
    public bool SpeechComplete { get; private set; } = true;
    public UnityEvent OnContinue { get; private set; } = new();
    public UnityEvent OnChoiceMade { get; private set; } = new();

    SpeakerProfileSO currentSpeaker;
    Coroutine speechCoroutine;

    string folderPath = "Assets/SpeakerProfiles";
    List<UnityEngine.Object> scriptableObjects = new();
    System.Type scriptableObjectType = typeof(SpeakerProfileSO);

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        audioSource = GetComponent<AudioSource>();
        ParseSpeakerProfiles();
        HideDisplay();
        typewriter.SetConfig(new()
        {
            display = this
        });
    }

    public void BeginSpeech(string text)
    {
        speechCoroutine = StartCoroutine(SpeakMessage(text));
    }

    IEnumerator SpeakMessage(string text)
    {
        SpeechComplete = false;

        typewriter.SetConfig(new()
        {
            display = this,
            speaker = currentSpeaker
        });

        typewriter.BeginTypewriter(text);
        yield return new WaitUntil(() => typewriter.IsTyping == false);

        SpeechComplete = true;
    }

    public void SkipSpeech()
    {
        if (speechCoroutine == null) return;

        StopCoroutine(speechCoroutine);
        typewriter.SkipTypewriter();
        SpeechComplete = true;
    }

    public void SetText(string text)
    {
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

    public void PlayAudio(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }

    public void SetSpeaker(string name)
    {
        SpeakerProfileSO newSpeaker = FindSpeaker(name);
        if (newSpeaker == null) return;

        nameText.text = newSpeaker.name;
        speakerImage.sprite = newSpeaker.SpeakerSprite;

        currentSpeaker = newSpeaker;
    }

    public void ShowContinueButton()
    {
        choiceButtons[0].SetChoice(new Choice() { text = "Continue..." }, delegate {
            ClearChoiceButtons();
            OnContinue.Invoke();
        });
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
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            IsFadedIn = false;
            StartCoroutine(FadeOverTime(0, 1, fadeInTime, () => IsFadedIn = true));
        }
    }

    public void HideDisplay()
    {
        if (gameObject.activeSelf)
        {
            IsFadedIn = true;
            StartCoroutine(FadeOverTime(1, 0, fadeOutTime, () =>
            {
                IsFadedIn = false;
                gameObject.SetActive(false);
            }));
        }
    }

    IEnumerator FadeOverTime(float startValue, float endValue, float fadeTime, UnityAction onComplete)
    {
        canvasGroup.alpha = startValue;

        float startTime = Time.unscaledTime;
        float timeElapsed = 0f;

        while (timeElapsed < fadeTime)
        {
            canvasGroup.alpha = Mathf.Lerp(startValue, endValue, timeElapsed / fadeTime);
            timeElapsed = Time.unscaledTime - startTime;
            yield return null;
        }

        canvasGroup.alpha = endValue;

        onComplete.Invoke();
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
