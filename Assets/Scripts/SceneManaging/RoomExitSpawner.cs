using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

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
    public string correspondingRoomExitName;

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
            if (roomExit.gameObject.name == correspondingRoomExitName)
            {
                Debug.Log($"{roomExit.gameObject.name} matches with {correspondingRoomExitName}!!!!!");
                PlacePlayer(roomExit);
                uiController.StartCoroutine(uiController.FadeFromBlack());
                Destroy(gameObject);
                return;
            }
            
            Debug.Log($"{roomExit.gameObject.name} does not match with {correspondingRoomExitName}, apparently");
            Debug.Log(roomExit.gameObject.name == correspondingRoomExitName);
            
        }
        
        Debug.Log($"RoomExit with name {correspondingRoomExitName} not found, defaulting to scene name");
        
        // if there's no RoomExit that has the right name
        foreach (var roomExit in roomExitList)
        {
            if (previousScene == roomExit.sceneToLoad.name)
            {
                Debug.Log($"scene holder found, it's {roomExit.sceneToLoad.name}");
                // time for spaghetti 😈
                PlacePlayer(roomExit);
                // purpose fulfilled
                uiController.StartCoroutine(uiController.FadeFromBlack());
                Destroy(gameObject);
                return;
            }
        }

        if (roomExitList.Length == 0)
        {
            Debug.Log("length of roomExitList is ZERO!!!!!");
        }
    }

    public void PlacePlayer(RoomExitController roomExit)
    {
        Vector3 playerSpawnPosition = roomExit.playerSpawnPosition.transform.position;
        player.transform.position = playerSpawnPosition;
    }
}
