using Assets.Scripts.Gameplay.Questing;
using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeezerConvo : NPCConvo
{
    [SerializeField] QuestCompletionLog questLog;

    [SerializeField] NPCConversation introConvo;
    [SerializeField] NPCConversation quest2IntroConvo;
    

    private void Awake()
    {
        if (questLog.TalkedToGeezer == false)
        {
            myConvo = introConvo;
        }
        else if (questLog.ConstructionComplete)
        {
            myConvo = quest2IntroConvo;
        }
    }

}
