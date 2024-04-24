using Assets.Scripts.Gameplay.Questing;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ManagerNPC : MonoBehaviour
{
    [SerializeField] QuestCompletionLog questLog;
    [SerializeField] GameObject Q1StartTrigger;
    [SerializeField] GameObject DialogueTrigger;

    private void Start()
    {
        if (questLog.ConstructionComplete == false)
        {
            Q1StartTrigger.SetActive(true);
        }
        else
        {
            Q1StartTrigger.SetActive(false);
        }
    }

    public void DisableQ1StartTrigger()
    {
        Q1StartTrigger.SetActive(false);
    }
}
