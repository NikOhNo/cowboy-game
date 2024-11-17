using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionQuest : Quest
{
    public override string QuestID => "ConstructionQuest";
    public override string Description => "Chase out the construction workers!";

    public bool TalkedToManager;
}
