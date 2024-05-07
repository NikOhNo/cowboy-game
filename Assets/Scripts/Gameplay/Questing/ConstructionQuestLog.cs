using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "newConstructionQuestLog", menuName = "New Construction Quest Log")]
public class ConstructionQuestLog : ScriptableObject
{
    public UnityEvent OnBeginQuest;
    public UnityEvent OnFailQuest;

    public bool QuestActive = false;
    public bool HasRevolver = true;
    public int TimesRevolverUsed = 0;
    public bool HasHardHat = false;
    public int TimesHardHatUsed = 0;
    public bool HasID = false;
    public int TimesIDUsed = 0;

    private void Awake()
    {
        OnFailQuest.AddListener(ResetLog);
    }

    public void BeginQuest()
    {
        QuestActive = true;
        OnBeginQuest.Invoke();
    }

    public void UseRevolver()
    {
        TimesRevolverUsed++;
        if (TimesRevolverUsed > 3)
        {
            FailQuest();
        }
    }

    public void UseHardHate()
    {
        TimesHardHatUsed++;
        if (TimesHardHatUsed > 3)
        {
            FailQuest();
        }
    }   

    public void UseID()
    {
        TimesIDUsed++;
        if (TimesIDUsed > 3)
        {
            FailQuest();
        }
    }

    public void FailQuest()
    {
        OnFailQuest.Invoke();
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
    }
}
