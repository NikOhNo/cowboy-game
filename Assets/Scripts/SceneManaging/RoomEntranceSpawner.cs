using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class RoomEntranceSpawner : MonoBehaviour
{
    // this object is instantiated by a room exit when it is traveled through.
    // it is then destroyed by itself after doing its job
    // used to persist information between scenes
    
    public UIController uiController;
    
    // all of these are set by the RoomEntranceController who creates this RoomEntranceSpawner
    public GameObject player;
    public RoomEntranceController roomEntrance;
    public string previousScene;
    public string correspondingEntranceName;

    public void Start()
    {
        uiController = GameObject.Find("UIController").GetComponent<UIController>();
    }

    public void OnEnable()
    {
        SceneManager.sceneLoaded += FindCorrespondingEntrance;
    }

    public void OnDisable()
    {
        SceneManager.sceneLoaded -= FindCorrespondingEntrance;
    }
    
    public void FindCorrespondingEntrance(Scene scene, LoadSceneMode mode)
    {
        //uiController.FinishRoomTransition();
        // find the room exit in this room
        // roomEntrance = GameObject.Find("RoomExit");
        
        var roomEntranceList = FindObjectsOfType<RoomEntranceController>();
        foreach (var roomEntrance in roomEntranceList)
        {
            if (roomEntrance.gameObject.name == correspondingEntranceName)
            {
                Debug.Log($"{roomEntrance.gameObject.name} matches with {correspondingEntranceName}!!!!!");
                PlacePlayer(roomEntrance);
                uiController.StartCoroutine(uiController.FadeFromBlack());
                Destroy(gameObject);
                return;
            }
            
            Debug.Log($"{roomEntrance.gameObject.name} does not match with {correspondingEntranceName}, apparently");
            Debug.Log(roomEntrance.gameObject.name == correspondingEntranceName);
            
        }
        
        Debug.Log($"RoomExit with name {correspondingEntranceName} not found, defaulting to scene name");
        
        // if there's no RoomExit that has the right name
        foreach (var roomEntrance in roomEntranceList)
        {
            if (previousScene == roomEntrance.sceneToLoad.name)
            {
                Debug.Log($"scene holder found, it's {roomEntrance.sceneToLoad.name}");
                // time for spaghetti 😈
                PlacePlayer(roomEntrance);
                // purpose fulfilled, time to die
                uiController.StartCoroutine(uiController.FadeFromBlack());
                Destroy(gameObject);
                return;
            }
        }

        if (roomEntranceList.Length == 0)
        {
            Debug.Log("length of roomEntranceList is ZERO!!!!!");
        }
    }

    public void PlacePlayer(RoomEntranceController roomEntrance)
    {
        Vector3 playerSpawnPosition = roomEntrance.playerSpawnPosition.transform.position;
        player.transform.position = playerSpawnPosition;
        GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>().Follow = player.transform;
    }
}
