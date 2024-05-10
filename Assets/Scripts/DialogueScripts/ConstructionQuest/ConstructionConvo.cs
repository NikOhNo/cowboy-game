using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionConvo : NPCConvo
{
    [SerializeField] ConstructionQuestOptions dialogueOptions;

    protected override void BeginConversation()
    {
        // TODO: put logic for choosing convo
        dialogueOptions.DisplayOptions();
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);

        if (collision.CompareTag("Player"))
        {
            dialogueOptions.HideOptions();
        }
    }
}
