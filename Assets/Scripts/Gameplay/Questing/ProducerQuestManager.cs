using System;
using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class ProducerQuestManager : MonoBehaviour
{
    // manager for the producer quest, tracks the timer and completion progress, rather than using the quest manager

    private bool questStarted;
    private Countdown countdown;
    
    [FormerlySerializedAs("CountdownTimerDisplayPrefab")] [SerializeField] private GameObject countdownTimerDisplayPrefab;
    private GameObject countdownTimerDisplay;
    
    public static ProducerQuestManager Instance;
    
    [SerializeField] private NPCConversation initiateQuestDialogue;
    [SerializeField] private NPCConversation completeGeezerStepDialogue;
    [SerializeField] private NPCConversation completeSheriffStepDialogue;
    [SerializeField] private NPCConversation completeHouseStepDialogue;
    [SerializeField] private NPCConversation completeBarnStepDialogue;
    
    private bool geezerStepFinished = false;
    private bool sheriffStepFinished = false;
    private bool houseStepFinished = false;
    private bool barnStepFinished = false;
    
    public event Action CompleteGeezerStep;
    public event Action CompleteSheriffStep;
    public event Action CompleteHouseStep;
    public event Action CompleteBarnStep;

void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        countdown = GetComponent<Countdown>();
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSwitchScene;
    }
    
    private void Update()
    {
        // update countdownTimerDisplay to show the current time if it is counting down
        if (countdownTimerDisplay && countdown.isCountingDown)
        {
            countdownTimerDisplay.GetComponent<TextMeshProUGUI>().text = countdown.timeRemaining.ToString();
        }
    }
    
    public void OnSwitchScene(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name != "Town")
        {
            return;
        }

        if (!questStarted)
        {
            // right now the quest starts when the player leaves the saloon and before the dialogue box pops up
            // might want to change this to activate when the player finishes the dialogue
            StartQuestAndCountdown();
        }

        if (!countdownTimerDisplay)
        {
            countdownTimerDisplay = Instantiate(countdownTimerDisplayPrefab, GameObject.Find("Canvas").transform, true);
        }
    }
    
    public void StartQuestAndCountdown()
    {
        questStarted = true;
        countdown.Begin();
        ConversationManager.Instance.StartConversation(initiateQuestDialogue);
    }

    

    public void Progress()
    {
        if (!geezerStepFinished)
        {
            geezerStepFinished = true;
            countdown.AddTime(30); // can change this if it's too long or short
            ConversationManager.Instance.StartConversation(completeGeezerStepDialogue);
            CompleteGeezerStep?.Invoke();
            return;
        }

        if (!sheriffStepFinished)
        {
            sheriffStepFinished = true;
            countdown.AddTime(30);
            ConversationManager.Instance.StartConversation(completeSheriffStepDialogue);
            CompleteSheriffStep?.Invoke();
            return;
        }

        if (!houseStepFinished)
        {
            houseStepFinished = true;
            countdown.AddTime(30);
            ConversationManager.Instance.StartConversation(completeHouseStepDialogue);
            CompleteSheriffStep?.Invoke();
            return;
        }

        if (!barnStepFinished)
        {
            barnStepFinished = true;
            countdown.AddTime(30);
            ConversationManager.Instance.StartConversation(completeBarnStepDialogue);
            CompleteBarnStep?.Invoke();
            return;
        }
    }
}
