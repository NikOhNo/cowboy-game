using DialogueEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class SecurityConvo : MonoBehaviour
{
    [SerializeField] NPCConversation officeFailureDialogue;
    [SerializeField] List<NPCConversation> generalFailureDialogues = new();

    Queue<NPCConversation> randomFailDialgoues = new();

    private void Awake()
    {
        FillRandomFailDialogues();
    }

    public void StartOfficeFailureDialogue()
    {
        ConversationManager.Instance.StartConversation(officeFailureDialogue);
    }

    public void StartRandomFailureDialogue()
    {
        ConversationManager.Instance.StartConversation(randomFailDialgoues.Dequeue());
        if (randomFailDialgoues.Count == 0)
        {
            FillRandomFailDialogues();
        }
    }

    private void FillRandomFailDialogues()
    {
        System.Random rng = new();
        generalFailureDialogues = generalFailureDialogues.OrderBy(x => rng.Next()).ToList();

        foreach (var dialogue in generalFailureDialogues)
        {
            randomFailDialgoues.Enqueue(dialogue);
        }
    }
}
