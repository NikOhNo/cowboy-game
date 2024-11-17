using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Quest
{
    public abstract string QuestID { get; }
    public abstract string Description { get; }
    public virtual bool Complete { get; set; } = false;
}