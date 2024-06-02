using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "newConstructionQuestLog", menuName = "New Construction Quest Log")]
public class ConstructionQuestLog : ScriptableObject
{
    public UnityEvent OnBeginQuest;
    public UnityEvent OnFailQuest;
    public UnityEvent OnCompleteQuest;
    public UnityEvent OnEndQuest;
    public UnityEvent OnObtainRevolver;
    public UnityEvent OnObtainHardHat;
    public UnityEvent OnObtainID;
    public UnityEvent OnUseRevolver;
    public UnityEvent OnUseHardHat;
    public UnityEvent OnUseID;

    public bool QuestActive = false;
    public bool HasRevolver = true;
    public int TimesRevolverUsed = 0;
    public bool HasHardHat = false;
    public int TimesHardHatUsed = 0;
    public bool HasID = false;
    public int TimesIDUsed = 0;

    public int WorkersGone = 0;

    public void ObtainRevolver()
    {
        HasRevolver = true;
        OnObtainRevolver.Invoke();
    }

    public void ObtainHardHat()
    {
        HasHardHat = true;
        OnObtainHardHat.Invoke();
    }

    public void ObtainID()
    {
        HasID = true;
        OnObtainID.Invoke();
    }

    public void UseRevolver()
    {
        TimesRevolverUsed++;
        if (TimesRevolverUsed > 3)
        {
            FailQuest();
            return;
        }
        OnUseRevolver.Invoke();
    }

    public void UseHardHat()
    {
        TimesHardHatUsed++;
        if (TimesHardHatUsed > 3)
        {
            FailQuest();
            return;
        }
        OnUseHardHat.Invoke();
    }   

    public void UseID()
    {
        TimesIDUsed++;
        if (TimesIDUsed > 3)
        {
            FailQuest();
            return;
        }
        OnUseID.Invoke();
    }

    public void AnnounceWorkerGone()
    {
        WorkersGone++;

        if (WorkersGone >= 9)
        {
            OnCompleteQuest.Invoke();
        }
    }

    public void BeginQuest()
    {
        QuestActive = true;
        OnBeginQuest.Invoke();
    }

    public void FailQuest()
    {
        Debug.Log("Failed Q1 :(");
        ResetLog();
        OnFailQuest.Invoke();
    }

    public void CompleteQuest()
    {
        QuestActive = false;
        OnCompleteQuest.Invoke();
    }

    public void ResetLog()
    {
        QuestActive = false;
        HasRevolver = true;
        TimesRevolverUsed = 0;
        HasHardHat = false;
        TimesHardHatUsed = 0;
        HasID = false;
        TimesIDUsed = 0;
        WorkersGone = 0;
    }
}
