using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Gameplay.Questing;
using DialogueEditor;
using UnityEngine;

public class TownsfolkConvo : NPCConvo
{
    [SerializeField] private QuestCompletionLog questLog;
    
    [SerializeField] private NPCConversation wrongTimeDialogue;
    [SerializeField] private NPCConversation quest2Dialogue;

    private void Awake()
    {
        ProducerQuestManager.Instance.CompleteSheriffStep += OnFinishSheriffStep;
        if (myConvo != quest2Dialogue)
        {
            myConvo = wrongTimeDialogue;
        }
    }

    private void OnFinishSheriffStep()
    {
        myConvo = quest2Dialogue;
    }
}
