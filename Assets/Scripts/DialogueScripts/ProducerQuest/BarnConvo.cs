using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Gameplay.Questing;
using DialogueEditor;
using UnityEngine;

public class BarnConvo : NPCConvo
{
    [SerializeField] private QuestCompletionLog questLog;
    
    [SerializeField] private NPCConversation wrongTimeConvo;
    [SerializeField] private NPCConversation quest2Convo;

    private void Awake()
    {
        if (ProducerQuestManager.Instance)
        {
            ProducerQuestManager.Instance.CompleteHouseStep += UpdateDialogue;
            ProducerQuestManager.Instance.CompleteBarnStep += UpdateDialogue;
        }

        UpdateDialogue();
    }

    private void OnFinishHouseStep()
    {
        UpdateDialogue();
    }

    private void UpdateDialogue()
    {
        if (!questLog.ProducerFinishedHouseStep)
        {
            myConvo = wrongTimeConvo;
        }
        else if (!questLog.ProducerFinishedBarnStep)
        {
            myConvo = quest2Convo;
        }
        else
        {
            myConvo = wrongTimeConvo;
        }
    }
}
