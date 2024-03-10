using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Questing
{
    [CreateAssetMenu(fileName = "newQuestCompleteLog", menuName = "New Quest Completion Log")]
    public class QuestCompletionLog : ScriptableObject
    {
        public bool TalkedToGeezer = false;
        public bool ConstructionComplete = false;
        public bool EDMStarted = false;
        public bool EDMComplete = false;
        public bool TwinsComplete = false;
        public bool DustDevilComplete = false;
    }
}