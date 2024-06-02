using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionConvo : NPCConvo
{
    [SerializeField] ConstructionQuestOptions dialogueOptions;
    [SerializeField] GameObject npcObject;

    protected override void BeginConversation()
    {
        dialogueOptions.DisplayOptions();
    }

    private void HideNPC()
    {
        npcObject.SetActive(false);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.CompareTag("Player"))
        {
            ConversationManager.OnConversationEnded += HideNPC;
        }
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);

        if (collision.CompareTag("Player"))
        {
            ConversationManager.OnConversationEnded -= HideNPC;
            dialogueOptions.HideOptions();
        }
    }
}
