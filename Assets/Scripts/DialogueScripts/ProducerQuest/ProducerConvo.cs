using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Gameplay.Questing;
using UnityEngine;

public class ProducerConvo : NPCConvo
{
    [SerializeField] QuestCompletionLog questLog;
    
    //[SerializeField] NPCConversation incompleteQuestConvo;
    //[SerializeField] NPCConversation introConvo;
    //[SerializeField] NPCConversation finishQuestDialogue;
    
    private void Awake()
    {
        if (ProducerQuestManager.Instance)
        {
            ProducerQuestManager.Instance.CompleteBarnStep += UpdateDialogue;
        }
        UpdateDialogue();
    }

    private void UpdateDialogue()
    {
        if (!questLog.TalkedToGeezer)
        {
            //myConvo = incompleteQuestConvo;
        }
        else if (questLog.TalkedToGeezer && questLog.ConstructionComplete && !questLog.ProducerFinishedBarnStep)
        {
            //myConvo = introConvo;
        }
        else if (questLog.ProducerFinishedBarnStep)
        {
            //myConvo = finishQuestDialogue;
        }
    }
}
