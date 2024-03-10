using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExampleOldGeezer : MonoBehaviour
{
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        QuestManager.Instance.OnActivateQuest += OnActivateGeezerQuest;
    }

    private void OnActivateGeezerQuest(string questID)
    {
        // activate when geezer quest is activated
        if (questID == "quest_TalkToOldGeezer")
        {
            gameObject.SetActive(true);
            button = GetComponent<Button>();
            button.onClick.AddListener(delegate { gameObject.SetActive(false); QuestManager.Instance.CompleteQuest(questID); });
        }
    }

}
