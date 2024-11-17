using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IntroQuest : Quest
{
    public override string QuestID { get => "IntroQuest"; }
    public override string Description { get => "Find out what's going on!"; }
}
