using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInitiator : MonoBehaviour
{
    private void Awake()
    {
        QuestManager.instance.ActivateQuest("TalkGeezer");
    }
}
