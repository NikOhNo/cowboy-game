using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomExitSpawner : MonoBehaviour
{
    // this object is instantiated by a room exit when it is traveled through.
    // it is then destroyed by itself after doing its job
    // used to persist information between scenes
    
    public UIController uiController;
    
    // all of these are set by the RoomExitController who creates this RoomExitSpawner
    public GameObject player;
    public RoomExitController roomExit;
    public string previousScene;

    public void Start()
    {
        uiController = GameObject.Find("UIController").GetComponent<UIController>();
    }

    public void OnEnable()
    {
        SceneManager.sceneLoaded += FindRoomExit;
    }

    public void OnDisable()
    {
        SceneManager.sceneLoaded -= FindRoomExit;
    }
    
    public void FindRoomExit(Scene scene, LoadSceneMode mode)
    {
        //uiController.FinishRoomTransition();
        // find the room exit in this room
        // roomExit = GameObject.Find("RoomExit");
        
        var roomExitList = FindObjectsOfType<RoomExitController>();
        foreach (var roomExit in roomExitList)
        {
            if (previousScene.Equals(roomExit.sceneToLoad.name))
            {
                Debug.Log($"previous scene: {previousScene}, roomExitList: {roomExitList}");
                // time for spaghetti 😈
                Vector3 playerSpawnPosition = roomExit.playerSpawnPosition.transform.position;
                player.transform.position = playerSpawnPosition;
                // purpose fulfilled
                uiController.StartCoroutine(uiController.FadeFromBlack());
                Destroy(gameObject);
            }
        }

        if (roomExitList.Length == 0)
        {
            Debug.Log("length of roomExitList is ZERO!!!!!");
        }
    }
}
