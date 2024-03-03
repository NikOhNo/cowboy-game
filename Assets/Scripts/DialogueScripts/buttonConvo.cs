using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class buttonConvo : MonoBehaviour
{
    public NPCConversation myConvo;
    private void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            ConversationManager.Instance.StartConversation(myConvo);
        }
    }
}
