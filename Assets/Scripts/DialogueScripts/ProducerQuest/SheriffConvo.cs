using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheriffConvo : NPCConvo
{
    //[SerializeField] QuestCompletionLog questLog;
    
    
    //[SerializeField] NPCConversation wrongTimeConvo;
    //[SerializeField] NPCConversation quest2Convo;
    
    public bool quest2_usedDialogue = false;
    

    private void Awake()
    {
        //if (ProducerQuestManager.Instance)
        //{
        //    ProducerQuestManager.Instance.CompleteGeezerStep += UpdateDialogue;
        //    ProducerQuestManager.Instance.CompleteSheriffStep += UpdateDialogue;
        //}

        UpdateDialogue();
    }
    
    public void OnCompleteGeezerStep()
    {
        UpdateDialogue();
        // TODO switch dialogue to some other one
    }

    public void UpdateDialogue()
    {
        //if (questLog.ProducerStarted && questLog.ProducerFinishedGeezerStep && !quest2_usedDialogue)
        //{
        //    myConvo = quest2Convo;
        //    Debug.Log($"set sheriff myConvo to {myConvo}");
        //}
        //else
        //{
        //    myConvo = wrongTimeConvo;
        //}
    }
}
