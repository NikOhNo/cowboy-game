using Assets.Scripts.Gameplay.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConstructionQuestManager : MonoBehaviour
{
    //[SerializeField] QuestCompletionLog questLog;
    //[SerializeField] ConstructionQuestLog constructionLog;

    [SerializeField] SecurityConvo securityGuard;

    //[SerializeField] List<NPCConversation> revolverInteractions;
    //[SerializeField] NPCConversation officeHardHatInteraction;
    //[SerializeField] List<NPCConversation> hardHatInteractions;
    //[SerializeField] List<NPCConversation> idInteractions;

    private void Awake()
    {
        //constructionLog.OnBeginQuest.AddListener();
        //constructionLog.OnFailQuest.AddListener();
        //constructionLog.OnCompleteQuest.AddListener(CompleteQuest);
        //constructionLog.OnFailQuest.AddListener(HandleQuestFail);

        //constructionLog.OnUseRevolver.AddListener(PlayRevolverDialogue);
        //constructionLog.OnUseHardHat.AddListener(PlayHardHatDialogue);
        //constructionLog.OnUseID.AddListener(PlayIDDialogue);
    }

    private void CompleteQuest()
    {
        //questLog.ConstructionComplete = true;
    }

    private void HandleQuestFail()
    {
        securityGuard.StartRandomFailureDialogue();
        //ConversationManager.OnConversationEnded += () => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void PlayRevolverDialogue()
    {
        //ConversationManager.Instance.StartConversation(revolverInteractions[constructionLog.TimesRevolverUsed - 1]);
    }

    private void PlayHardHatDialogue()
    {
        //ConversationManager.Instance.StartConversation(hardHatInteractions[constructionLog.TimesHardHatUsed - 1]);
    }

    private void PlayIDDialogue()
    {
        //ConversationManager.Instance.StartConversation(idInteractions[constructionLog.TimesIDUsed - 1]);
    }
}
