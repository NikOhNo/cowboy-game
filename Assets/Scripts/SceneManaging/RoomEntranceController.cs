using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;


// script for Controlling the exiting of rooms.
// when the player gets near, they can press a button to move to sceneToLoad.
// uses a RoomEntranceSpawner (i know it's a bad name im sorry) to preserve data between scenes.
// places player at child playerSpawnPosition of the roomExitController in sceneToLoad that has the same scene as the one we just transitioned from (the corresponding exit to this one).
// has a lot of Annoying dependencies, such as a UIController.
// works properly when there are multiple roomExitControllers in the scene it is transitioning to.
// doesn't so much work properly when there are multiple roomExitControllers that go to the same scene in the scene it's transitioning to. it'll go to the first one in the hierarchy. this can be
// fixed by having more specificity of the connection between the roomExits. idk how to actually implement this though. just don't have multiple entrances to the same place
public class RoomEntranceController : MonoBehaviour
{
    public SceneAsset sceneToLoad;
    private string sceneAssetPath;
    BoxCollider2D bc2d; // controls area in which the player gets the prompt to switch rooms
    public GameObject playerSpawnPosition;
    public Collider2D target; // collider2d attached to player
    public GameObject interactIcon; // set in IN SPEC TOR
    
    // EXACT NAME of the RoomEntrance that THIS RoomEntrance is supposed to put the player in front of when they go through.
    // this is the first thing it checks, if there is no RoomEntrance in sceneToLoad that has this name, it puts the player at the RoomEntrance with sceneToLoad of this RoomEntrance.
    // msg me if the above doesn't make sense lol
    public string correspondingEntranceName; 

    public UIController uiController;
    
    public KeyCode interactButton = KeyCode.F;
    // object that will be created when the player goes through this entrance, essentially preserves data
    public GameObject roomEntranceSpawner;
    // can the player press a button to go into this entrance
    private bool activatable = false;

    void Start()
    {
        bc2d = GetComponent<BoxCollider2D>();
        bc2d.isTrigger = true;
        sceneAssetPath = AssetDatabase.GetAssetPath(sceneToLoad);
        uiController = GameObject.Find("UIController").GetComponent<UIController>();
        // get position of the PlayerSpawnPosition child object
    }

    public void Update()
    {
        // FIXME maybe trigger something on the player that lets them know that they're activatable?
        if (activatable)
        {
            if (!interactIcon.activeSelf)
            {
                interactIcon.SetActive(true);
            }
            interactIcon.transform.position = target.transform.position + new Vector3(0, 1.25f, 0);
            // TODO replace with actual dimensions of screen
            // Vector3 finalPosition = interactIcon.transform.position;
            // // Vector3 viewPos = Camera.main.WorldToViewportPoint(interactIcon.transform.position);
            // finalPosition.x = Mathf.Clamp(finalPosition.x, 0, Screen.width);
            // finalPosition.y = Mathf.Clamp(finalPosition.y, 0, Screen.height);
            // // interactIcon.transform.position = math.clamp(target.transform.TransformPoint(interactIcon.transform.position), new Vector3(0, 0, 0), new Vector3(1920, 1080, 0));
            // interactIcon.transform.position = finalPosition;

            if (Input.GetKeyDown(interactButton))
            {
                SwitchSceneAndRepositionPlayer(target);
            }
        }

        if (!activatable)
        {
            if (interactIcon.activeSelf)
            {
                interactIcon.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            activatable = true;
            target = col;
            var spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.red;
        }
        
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player") && activatable)
        {
            activatable = false;
            target = null;
            var spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.black;
        }
    }

    public void SwitchSceneAndRepositionPlayer(Collider2D target)
    {
        DontDestroyOnLoad(target);
        // create RoomEntranceSpawner, which will persist into the next room and place the player at the right location 
        // for the entrance in that room. 
        // in the RoomEntranceSpawner script, it checks which entrance to place the player at, this will be the entrance who's gameObject has name correspondingEntranceName
        var spawnerInstance = Instantiate(this.roomEntranceSpawner);
        DontDestroyOnLoad(spawnerInstance);
        var roomEntranceSpawner = spawnerInstance.GetComponent<RoomEntranceSpawner>();
        roomEntranceSpawner.player = target.gameObject;
        roomEntranceSpawner.previousScene = SceneManager.GetActiveScene().name;
        roomEntranceSpawner.correspondingEntranceName = correspondingEntranceName;
        uiController.StartCoroutine(uiController.FadeToBlack()); // uncomment for fade to black effect
        // wait until the fade to black has finished to load the scene...
        uiController.onFinishFadeToBlack += OnFinishFadeToBlack;
        // SceneManager.LoadScene(sceneToLoad.name, LoadSceneMode.Single);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnFinishFadeToBlack()
    {
        uiController.onFinishFadeToBlack -= OnFinishFadeToBlack;
        SceneManager.LoadScene(sceneToLoad.name, LoadSceneMode.Single);
    }
}
