using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionQuestManager : MonoBehaviour
{
    [SerializeField] ConstructionQuestLog constructionLog;

    [SerializeField] List<NPCConversation> revolverInteractions;
    [SerializeField] NPCConversation officeHardHatInteraction;
    [SerializeField] List<NPCConversation> hardHatInteractions;
    [SerializeField] List<NPCConversation> idInteractions;

    private void Awake()
    {
        //constructionLog.OnBeginQuest.AddListener();
        //constructionLog.OnFailQuest.AddListener();
    }
}
