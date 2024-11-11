using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ManagerNPC : MonoBehaviour
{
    //[SerializeField] QuestCompletionLog questLog;
    //[SerializeField] ConstructionQuestLog constructionQuestLog;
    [SerializeField] GameObject Q1StartTrigger;
    [SerializeField] GameObject DialogueTrigger;

    private void Start()
    {
        //if (questLog.ConstructionComplete == false && constructionQuestLog.QuestActive == false)
        //{
        //    Q1StartTrigger.SetActive(true);
        //}
        //else
        //{
        //    Q1StartTrigger.SetActive(false);
        //}
    }

    public void DisableQ1StartTrigger()
    {
        Q1StartTrigger.SetActive(false);
    }
}
