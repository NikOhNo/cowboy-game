using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExampleWakeUp : MonoBehaviour
{
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        QuestManager.Instance.OnQuestComplete += OnCompleteButtonQuest;
    }

    private void OnCompleteButtonQuest(string questID)
    {
        if (questID == "quest_PressButton")
        {
            gameObject.SetActive(true);
            button = GetComponent<Button>();
            button.onClick.AddListener(delegate { gameObject.SetActive(false); QuestManager.Instance.ActivateQuest("quest_TalkToOldGeezer"); });
        }
    }
}
