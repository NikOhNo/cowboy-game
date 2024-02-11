using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest
{
    // quest class, used in QuestManager to keep track of quests (both active and complete)
    // honestly, probably not necessary because quests only have a description. the isActive property isn't even used

    public string description;
    public bool isActive;

    public Quest(string description) 
    {
        this.description = description;
        isActive = false;
    }

    public void Activate()
    {
        isActive = true;
    }

    public void Complete() 
    {
        isActive = false;
    }
}
