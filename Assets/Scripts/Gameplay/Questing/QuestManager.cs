using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // QuestManager singleton!
    public static QuestManager Instance;

    private List<Quest> activeQuests = new List<Quest>();
    private List<Quest> completedQuests = new List<Quest>();

    private Dictionary<string, Quest> questMap = new Dictionary<string, Quest>();

    public void Awake()
    {
        Instance = this;
    }

    //--EVENTS
    // subscribe to this event to do Things when a quest is completed
    public event Action<string> OnQuestComplete;
    public void QuestComplete(string questID)
    {
        OnQuestComplete?.Invoke(questID);
        Debug.Log($"quest {questID} completed!");
    }

    // subscribe to this event to do Things when a quest is activated
    public event Action<string> OnActivateQuest;
    public void ActivateQuest(string questID)
    { 
        OnActivateQuest?.Invoke(questID);

        Quest quest = questMap[questID];
        activeQuests.Add(quest);
        Debug.Log($"quest {questID} activated!");
    }

    public void CompleteQuest(string questID)
    {
        // get quest from id
        Quest quest = questMap[questID];
        if (activeQuests.Contains(quest))
        {
            activeQuests.Remove(quest);
            completedQuests.Add(quest);
            QuestComplete(questID);
        }
    }

    // add quest to quest map, do this PROBABLY at the start of the game when adding quests that exist
    public void AddQuest(string id, string desc)
    {
        var quest = new Quest(desc);
        questMap.Add(id, quest);
    }

    // use in other scripts to get the description of the quest with the given id
    public string GetQuestDescription(string questID)
    {
        Quest quest = questMap[questID];
        return quest.description;
    }

    public void Start()
    {
        // FIXME temporary start stuff, setting up quests that exist, specific to test/example scene
        // might not need to make anything more complicated than this actually, if there's only going to be 8 quests
        AddQuest("quest_PressButton", "Press the button!");
        AddQuest("quest_TalkToOldGeezer", "Talk to the old geezer!");
        AddQuest("quest_DefeatDustDevil", "Defeat the dust devil!");
        
        AddQuest("quest_TalkToProducer", "Investigate the saloon!");
        AddQuest("quest_Producer", "Solve the producer's problems!");
    }
}
