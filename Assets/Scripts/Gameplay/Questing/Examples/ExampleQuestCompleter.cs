using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExampleQuestCompleter : MonoBehaviour
{
    // example of a Completer of a quest

    private Button completeQuestButton;

    void Start()
    {
        completeQuestButton = GetComponent<Button>();

        completeQuestButton.onClick.AddListener(delegate { QuestManager.instance.CompleteQuest("quest_PressButton"); gameObject.SetActive(false); });
    }
}
