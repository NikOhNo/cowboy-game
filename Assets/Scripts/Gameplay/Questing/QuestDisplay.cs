using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.UI;
using UnityEngine;

public class QuestDisplay : MonoBehaviour
{
    public GameObject questTextItemPrefab;

    private List<string> activeQuests = new List<string>();
    private List<string> completedQuests = new List<string>();

    private List<GameObject> textItems = new List<GameObject>();

    private Vector2 textOrigin;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);

        //playerInputActions.UI.DisplayQuestList.started += ctx => { gameObject.SetActive(true); };
        //playerInputActions.UI.DisplayQuestList.canceled += ctx => { gameObject.SetActive(false); };

        //questListText = GetComponentInChildren<TextMeshProUGUI>();

        // subscribe to quest manager's quest events
        QuestManager.Instance.OnActivateQuest += ActivateQuest;
        QuestManager.Instance.OnQuestComplete += CompleteQuest;

        textOrigin = GetComponentInChildren<TextMeshProUGUI>().transform.position;
    }

    //private void OnEnable()
    //{

    //}

    //private void OnDisable()
    //{
    //    QuestManager.Instance.OnActivateQuest -= ActivateQuest;
    //    QuestManager.Instance.OnQuestComplete -= CompleteQuest;
    //}


    // disclaimer i have no idea what i'm doing with the ui
    private void Update()
    {

    }
    
    // event callback for QuestManager.onActivateQuest
    private void ActivateQuest(string id)
    {
        // destroy all previously created textItem gameObjects
        foreach (GameObject textItem in textItems)
        {
            Destroy(textItem);
        }

        var newQuestTextOrigin = RedrawActiveQuestText(textOrigin);

        // create new quest text
        string newQuestDescription = QuestManager.Instance.GetQuestDescription(id);
        if (newQuestDescription != null)
        {
            activeQuests.Add(id);
            // instantiate text item
            var textItem = Instantiate(questTextItemPrefab, new Vector3(newQuestTextOrigin.x, newQuestTextOrigin.y, 0), Quaternion.identity, gameObject.transform);

            // add it to the array for later
            textItems.Add(textItem);
            
            textItem.GetComponent<TextMeshProUGUI>().text = newQuestDescription;
            newQuestTextOrigin += new Vector2(0, -50);
        }

        RedrawCompletedQuestText(newQuestTextOrigin);
    }

    // event callback for QuestManager.onCompleteQuest
    private void CompleteQuest(string id)
    {
        activeQuests.Remove(id);
        completedQuests = completedQuests.Prepend(id).ToList(); // (prepend because we want the completed quests to be in the OPPOSITE order you completed them, i.e., most recent to least recent)

        // destroy all previously created textItem gameObjects
        foreach (GameObject textItem in textItems)
        {
            Destroy(textItem);
        }

        var newQuestTextOrigin = RedrawActiveQuestText(textOrigin);

        RedrawCompletedQuestText(newQuestTextOrigin);
    }

    // recreates questTextItemPrefabs for active quests. origin is where the first textItem should be placed, the rest will be placed based on that
    // returns the position of the last placed textItem
    private Vector2 RedrawActiveQuestText(Vector2 origin)
    {

        var textOriginTemp = origin;
        // create ONLY active quest texts
        foreach (string questID in activeQuests)
        {
            string questDescription = QuestManager.Instance.GetQuestDescription(questID);

            var textItem = Instantiate(questTextItemPrefab, new Vector3(textOriginTemp.x, textOriginTemp.y, 0), Quaternion.identity, gameObject.transform);

            textItems.Add(textItem);

            textItem.GetComponent<TextMeshProUGUI>().text = questDescription;
            textOriginTemp += new Vector2(0, -50);
        }

        return textOriginTemp;
    }

    // recreates questTextItemPrefabs for completed quests. origin is where the first textItem should be placed, the rest will be placed based on that
    // returns the position of the last placed textItem
    private Vector2 RedrawCompletedQuestText(Vector2 origin)
    {
        var textOriginTemp = origin;
        // create old COMPLETED quest texts
        foreach (string questID in completedQuests)
        {
            string questDescription = QuestManager.Instance.GetQuestDescription(questID);

            var textItem = Instantiate(questTextItemPrefab, new Vector3(textOriginTemp.x, textOriginTemp.y, 0), Quaternion.identity, gameObject.transform);

            textItems.Add(textItem);

            textItem.GetComponent<TextMeshProUGUI>().text = questDescription;
            textItem.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            textOriginTemp += new Vector2(0, -50);
        }

        return textOriginTemp;
    }
}
