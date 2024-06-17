using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Gameplay.Questing;
using UnityEngine;
using UnityEngine.Serialization;

public class TownsfolkConvo : NPCConvo
{
    [SerializeField] private QuestCompletionLog questLog;
    
    //[SerializeField] private NPCConversation wrongTimeConvo;
    //[SerializeField] private NPCConversation quest2Convo;

    private void Awake()
    {
        if (ProducerQuestManager.Instance)
        {
            ProducerQuestManager.Instance.CompleteSheriffStep += UpdateDialogue;
            ProducerQuestManager.Instance.CompleteHouseStep += UpdateDialogue;
        }

        UpdateDialogue();
    }

    private void OnFinishSheriffStep()
    {
        UpdateDialogue();
    }

    private void UpdateDialogue()
    {
        //if (!questLog.ProducerFinishedSheriffStep)
        //{
        //    myConvo = wrongTimeConvo;
        //}
        //else if (!questLog.ProducerFinishedHouseStep)
        //{
        //    myConvo = quest2Convo;
        //}
        //else
        //{
        //    myConvo = wrongTimeConvo;
        //}
    }
}
