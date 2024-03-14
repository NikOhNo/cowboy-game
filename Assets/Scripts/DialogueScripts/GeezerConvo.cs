using Assets.Scripts.Gameplay.Questing;
using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeezerConvo : NPCConvo
{
    [SerializeField] QuestCompletionLog questLog;

    [SerializeField] NPCConversation introConvo;

    private void Awake()
    {
        if (questLog.TalkedToGeezer == false)
        {
            myConvo = introConvo;
        }
    }

}
