using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Scripts.Gameplay.Questing
{
    [CreateAssetMenu(fileName = "newQuestCompleteLog", menuName = "New Quest Completion Log")]
    public class QuestCompletionLog : ScriptableObject
    {
        [SerializeField] private bool talkedToGeezer;
        [SerializeField] private bool constructionComplete;
        [SerializeField] private bool producerStarted;
        [SerializeField] private bool producerFinishedGeezerStep;
        [SerializeField] private bool producerFinishedSheriffStep;
        [SerializeField] private bool producerFinishedHouseStep;
        [SerializeField] private bool producerFinishedBarnStep;
        [SerializeField] private bool producerComplete;
        [SerializeField] private bool twinsComplete;
        [SerializeField] private bool dustDevilComplete;
        
        public bool TalkedToGeezer
        {
            get => talkedToGeezer;
            set => talkedToGeezer = value;
        }

        public bool ConstructionComplete
        {
            get => constructionComplete;
            set => constructionComplete = value;
        }

        public bool ProducerStarted
        {
            get => producerStarted;
            set => producerStarted = value;
        }

        public bool ProducerFinishedGeezerStep
        {
            get => producerFinishedGeezerStep;
            set => producerFinishedGeezerStep = value;
        }

        public bool ProducerFinishedSheriffStep
        {
            get => producerFinishedSheriffStep;
            set => producerFinishedSheriffStep = value;
        }
        
        public bool ProducerFinishedHouseStep
        {
            get => producerFinishedHouseStep;
            set => producerFinishedHouseStep = value;
        }

        public bool ProducerFinishedBarnStep
        {
            get => producerFinishedBarnStep;
            set => producerFinishedBarnStep = value;
        }

        public bool ProducerComplete
        {
            get => producerComplete;
            set => producerComplete = value;
        }

        public bool TwinsComplete
        {
            get => twinsComplete;
            set => twinsComplete = value;
        }

        public bool DustDevilComplete
        {
            get => dustDevilComplete;
            set => dustDevilComplete = value;
        }
    }
}