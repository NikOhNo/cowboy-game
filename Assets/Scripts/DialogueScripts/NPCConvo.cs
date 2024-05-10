using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPCConvo : MonoBehaviour
{
    public NPCConversation myConvo;
    bool canTalk = false;
    // private void OnMouseOver() {
    //     if (Input.GetMouseButtonDown(0)) {
    //         ConversationManager.Instance.StartConversation(myConvo);
    //     }
    // }

    protected void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            canTalk = true;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            canTalk = false;
        }
    }

    private void Update()
    {
        if (canTalk && (Input.GetKeyDown(KeyCode.F)))
        {
            BeginConversation();
        }
    }

    protected virtual void BeginConversation()
    {
        ConversationManager.Instance.StartConversation(myConvo);
        canTalk = false;
    }
}
