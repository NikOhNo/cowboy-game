using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDMProducer : MonoBehaviour
{
    [SerializeField] private GameObject producerQuestManagerPrefab;
    // the SOLE purpose of this script is to be attached to the edm producer and create the ProducerQuestManager when
    // the dialogue is ended.
    // i think a better way to do this is add to the ability to optionally run callbacks on quest completion or quest
    // acceptance. but that would probably conflict with changes made by others, so maybe that's something to do
    // if/when this evolves from being a quarter project to something Greater.
    public void BeginProducerQuest()
    {
        // in case the quest was failed and the quest manager still exists
        //if (!ProducerQuestManager.Instance)
        //{
        //    Instantiate(producerQuestManagerPrefab);
        //}
    }

    public void CompleteProducerQuest()
    {
        //if (ProducerQuestManager.Instance)
        //{
        //    // purpose fulfilled, time to die
        //    Destroy(ProducerQuestManager.Instance.gameObject);
        //}
    }
}
