using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;


// detects collisions 
public class RoomExitController : MonoBehaviour
{
    public SceneAsset sceneToLoad;
    private string sceneAssetPath;
    BoxCollider2D bc2d; // controls area in which the player gets the prompt to switch rooms
    public GameObject playerSpawnPosition;
    public Collider2D target; // collider2d attached to player

    public UIController uiController;
    
    public KeyCode interactButton = KeyCode.F;

    public GameObject roomExitSpawner;
    
    private bool activatable = false;
    
    /*
     * a plan
     *  create a gameobject that is dontdestroyonload-ed, store in this game object the reference to the target
     *  find the roomexit in the new scene, place the player at that roomexit's playerSpawnPosition. then destroy the
     *  previously created object.. ... ... . .yeyyyghlkjajh
     */

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
        if (activatable && Input.GetKeyDown(interactButton))
        {
            SwitchSceneAndRepositionPlayer(target);
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
        var spawnerInstance = Instantiate(roomExitSpawner);
        DontDestroyOnLoad(spawnerInstance);
        var roomExitSpawnerScript = spawnerInstance.GetComponent<RoomExitSpawner>();
        roomExitSpawnerScript.player = target.gameObject;
        //uiController.StartRoomTransition(); // uncomment for fade to black effect
        SceneManager.LoadScene(sceneToLoad.name, LoadSceneMode.Single);
        //
        // target.transform.position = playerSpawnPosition.transform.position;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
