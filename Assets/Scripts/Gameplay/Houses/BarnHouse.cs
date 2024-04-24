using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarnHouse : House
{
    [SerializeField] private GameObject barnEntrance;
    [SerializeField] private GameObject dialogueTrigger;

    private void Start()
    {
        if (AllQuestsComplete())
        {
            barnEntrance.SetActive(true);
            dialogueTrigger.SetActive(false);
        }
        else
        {
            barnEntrance.SetActive(false);
            dialogueTrigger.SetActive(true);
        }
    }

    public bool AllQuestsComplete()
    {
        return questLog.ConstructionComplete && questLog.ProducerComplete && questLog.TwinsComplete;
    }    
}
