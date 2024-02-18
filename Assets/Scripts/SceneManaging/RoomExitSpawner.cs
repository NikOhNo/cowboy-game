using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomExitSpawner : MonoBehaviour
{
    // this object is instantiated by a room exit when it is traveled through.
    // it is then destroyed by itself after doing its job
    // used to persist information between scenes
    
    public GameObject player;
    public GameObject roomExit;
    public UIController uiController;

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
        roomExit = GameObject.Find("RoomExit");
        if (roomExit)
        {
            // time for spaghetti 😈
            Vector3 playerSpawnPosition = roomExit.GetComponent<RoomExitController>().playerSpawnPosition.transform.position;
            player.transform.position = playerSpawnPosition;
            // purpose fulfilled
            Destroy(gameObject);
        }
    }
}
