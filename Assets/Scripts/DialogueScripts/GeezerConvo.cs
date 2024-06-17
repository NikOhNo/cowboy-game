using System;
using Assets.Scripts.Gameplay.Questing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeezerConvo : NPCConvo
{
    [SerializeField] QuestCompletionLog questLog;

    //[SerializeField] NPCConversation introConvo;
    //[SerializeField] NPCConversation quest2IntroConvo;
    //[SerializeField] NPCConversation quest2ActualConvo;
    
    public bool quest2_usedDialogue = false;
    

    private void Awake()
    {
        if (ProducerQuestManager.Instance)
        {
            ProducerQuestManager.Instance.CompleteGeezerStep += OnCompleteGeezerStep;
        }
        UpdateDialogue();
    }

    private void UpdateDialogue()
    {
        if (questLog.TalkedToGeezer == false)
        {
            //myConvo = introConvo;
        }
        else if (questLog.ConstructionComplete && !questLog.ProducerStarted)
        {
            //myConvo = quest2IntroConvo;
        }
        else if (questLog.ProducerStarted && !quest2_usedDialogue)
        {
            //myConvo = quest2ActualConvo;
        }
    }

    protected override void BeginConversation()
    {
        UpdateDialogue();
        base.BeginConversation();
    }

    public void OnCompleteGeezerStep()
    {
        quest2_usedDialogue = true;
        UpdateDialogue();
        // TODO switch dialogue to some other one
    }
}
