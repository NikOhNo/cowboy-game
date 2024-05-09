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

    public void PlayRevolverDialogue()
    {
        ConversationManager.Instance.StartConversation(revolverInteractions[constructionLog.TimesRevolverUsed]);
    }

    public void PlayHardHatDialogue()
    {
        ConversationManager.Instance.StartConversation(hardHatInteractions[constructionLog.TimesHardHatUsed]);
    }

    public void PlayIDDialogue()
    {
        ConversationManager.Instance.StartConversation(idInteractions[constructionLog.TimesIDUsed]);
    }
}
