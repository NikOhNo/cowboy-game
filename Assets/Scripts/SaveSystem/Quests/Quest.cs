using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Quest : IQuest
{
    public virtual string Description { get; }
    public virtual bool Complete { get; set; } = false;
}