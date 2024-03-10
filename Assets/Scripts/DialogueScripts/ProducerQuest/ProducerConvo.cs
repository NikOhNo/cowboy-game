using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Gameplay.Questing;
using DialogueEditor;
using UnityEngine;

public class ProducerConvo : NPCConvo
{
    [SerializeField] QuestCompletionLog questLog;
    
    [SerializeField] NPCConversation incompleteQuestConvo;
    [SerializeField] NPCConversation introConvo;
    
    private void Awake()
    {
        if (!questLog.TalkedToGeezer)
        {
            myConvo = incompleteQuestConvo;
        }
        else if (questLog.TalkedToGeezer && questLog.ConstructionComplete)
        {
            myConvo = introConvo;
        }
    }
}
