using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Gameplay.Questing;
using DialogueEditor;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class ProducerQuestManager : MonoBehaviour
{
    // manager for the producer quest, tracks the timer and completion progress, rather than using the quest manager
    // object is created and dontdestroyonloaded when the player accepts the quest from the producer :)

    private bool questStarted;
    private Countdown countdown;
    
    [FormerlySerializedAs("CountdownTimerDisplayPrefab")] [SerializeField] private GameObject countdownTimerDisplayPrefab;
    private GameObject countdownTimerDisplay;
    
    // use this to Observe whenever the quest states change
    [SerializeField] private QuestCompletionLog questLog;
    
    public static ProducerQuestManager Instance;
    
    // producer dialogues that are called when each step is complete
    [SerializeField] private NPCConversation initiateQuestDialogue;
    [SerializeField] private NPCConversation completeGeezerStepDialogue;
    [SerializeField] private NPCConversation completeSheriffStepDialogue;
    [SerializeField] private NPCConversation completeHouseStepDialogue;
    [SerializeField] private NPCConversation completeBarnStepDialogue;
    
    private bool geezerStepFinished = false;
    private bool sheriffStepFinished = false;
    private bool houseStepFinished = false;
    private bool barnStepFinished = false;
    
    // queue conversations if one is happening already
    private Queue<NPCConversation> conversationQueue;
    
    public event Action CompleteGeezerStep;
    public event Action CompleteSheriffStep;
    public event Action CompleteHouseStep;
    public event Action CompleteBarnStep;

void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        conversationQueue = new Queue<NPCConversation>();
        countdown = GetComponent<Countdown>();
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSwitchScene;
        questLog.ProducerStarted = true;
    }
    
    private void Update()
    {
        // update countdownTimerDisplay to show the current time if it is counting down
        if (countdownTimerDisplay && countdown.isCountingDown)
        {
            countdownTimerDisplay.GetComponent<TextMeshProUGUI>().text = countdown.timeRemaining.ToString();

            if (questLog.ProducerFinishedGeezerStep && !geezerStepFinished)
            {
                Progress();
            }
            if (questLog.ProducerFinishedSheriffStep && !sheriffStepFinished)
            {
                Progress();
            }

            if (questLog.ProducerFinishedHouseStep && !houseStepFinished)
            {
                Progress();
            }

            if (questLog.ProducerFinishedBarnStep && !barnStepFinished)
            {
                Progress();
            }
        }
        
        // if the conversation queue is nonempty, continuously check if there isn't a conversation so we can run the 
        // conversation in the queue. could probably switch this to hook into the ConversationManager.Instance.OnConversationEnd event
        if (conversationQueue.Count != 0)
        {
            if (!ConversationManager.Instance.IsConversationActive)
            {
                var newConvo = conversationQueue.Dequeue();
                ConversationManager.Instance.StartConversation(newConvo);
            }
        }
    }
    
    public void OnSwitchScene(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name != "Town Scene")
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
            countdownTimerDisplay.transform.position = new Vector2(871 * 2, 490 * 2); // put it in the top right corner
        }
    }
    
    public void StartQuestAndCountdown()
    {
        questStarted = true;
        countdown.duration = 60; // seconds
        countdown.Begin();
        ConversationManager.Instance.StartConversation(initiateQuestDialogue);
    }

    

    public void Progress()
    {
        // We Accessing Quest Log Directly
        if (!geezerStepFinished)
        {
            Debug.Log("completed geezer step!");
            geezerStepFinished = true;
            countdown.AddTime(10); // can change this if it's too long or short
            conversationQueue.Enqueue(completeGeezerStepDialogue);
            CompleteGeezerStep?.Invoke();
            return;
        }

        if (!sheriffStepFinished)
        {
            Debug.Log("completed sheriff step!");
            sheriffStepFinished = true;
            countdown.AddTime(10);
            conversationQueue.Enqueue(completeSheriffStepDialogue);
            CompleteSheriffStep?.Invoke();
            return;
        }

        if (!houseStepFinished)
        {
            Debug.Log("completed house step!");
            houseStepFinished = true;
            countdown.AddTime(10);
            conversationQueue.Enqueue(completeHouseStepDialogue);
            CompleteHouseStep?.Invoke();
            return;
        }

        if (!barnStepFinished)
        {
            Debug.Log("completed barn step!");
            barnStepFinished = true;
            countdown.AddTime(10);
            conversationQueue.Enqueue(completeBarnStepDialogue);
            CompleteBarnStep?.Invoke();
            return;
        }
    }
}
