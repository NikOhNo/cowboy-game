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
}
