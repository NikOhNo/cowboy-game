using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExampleQuestGiver : MonoBehaviour
{
    // example of a Giver of a Questt

    private Button giveQuestButton;

    void Start()
    {
        giveQuestButton = GetComponent<Button>();

        giveQuestButton.onClick.AddListener(delegate { QuestManager.Instance.ActivateQuest("quest_PressButton"); gameObject.SetActive(false); });
    }
}
