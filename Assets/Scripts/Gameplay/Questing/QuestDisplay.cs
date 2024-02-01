using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;

public class QuestDisplay : MonoBehaviour
{
    PlayerInputActions playerInputActions;

    public GameObject questTextItemPrefab;

    private List<string> activeQuests = new List<string>();
    private List<string> completedQuests = new List<string>();

    private Vector2 textOrigin;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        if (playerInputActions == null)
        {
            playerInputActions = new();
        }

        playerInputActions.Enable();
        playerInputActions.UI.DisplayQuestList.started += ctx => { gameObject.SetActive(true); };
        playerInputActions.UI.DisplayQuestList.canceled += ctx => { gameObject.SetActive(false); };

        //questListText = GetComponentInChildren<TextMeshProUGUI>();

        // subscribe to quest manager's quest events
        QuestManager.instance.OnActivateQuest += ActivateQuest;
        QuestManager.instance.OnQuestComplete += CompleteQuest;

        textOrigin = GetComponentInChildren<TextMeshProUGUI>().transform.position;
    }

    //private void OnEnable()
    //{

    //}

    //private void OnDisable()
    //{
    //    QuestManager.instance.OnActivateQuest -= ActivateQuest;
    //    QuestManager.instance.OnQuestComplete -= CompleteQuest;
    //}


    // disclaimer i have no idea what i'm doing with the ui
    private void Update()
    {

    }
    
    // event callback for QuestManager.onActivateQuest
    private void ActivateQuest(string id)
    {
        string questDescription = QuestManager.instance.GetQuestDescription(id);
        if (questDescription != null)
        {
            activeQuests.Add(id);
            // instantiate text item
            var textItem = Instantiate(questTextItemPrefab, new Vector3(textOrigin.x, textOrigin.y, 0), Quaternion.identity, gameObject.transform);
            
            textItem.GetComponent<TextMeshProUGUI>().text = questDescription;
            textOrigin += new Vector2(0, -50);
        }

        // TODO draw completed quests. this will require you to remove the active quest prefabs? so you don't draw them anymore? then move them to completed.
        // probably maintain a list of active and completed quests, and every time this event is called, destroy and replace all the prefabs so that they draw correctly.
        // maybe a better way to do it, i'm not experienced in ui stuff
    }

    // event callback for QuestManager.onCompleteQuest
    private void CompleteQuest(string id)
    {
        activeQuests.Remove(id);
        completedQuests.Add(id);
    }

    // call when state of quests change (when activating a quest or completing a quest)
    // in order to move down the completed quest list (when adding an active quest) or moving UP the active quest list (when adding a completed quest)
    private void RedrawQuestText()
    {
        // TODO
    }
}
