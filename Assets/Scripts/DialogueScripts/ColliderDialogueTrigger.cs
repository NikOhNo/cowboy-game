using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDialogueTrigger : MonoBehaviour
{
    //[SerializeField] NPCConversation conversation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //ConversationManager.Instance.StartConversation(conversation);
        }
    }
}
