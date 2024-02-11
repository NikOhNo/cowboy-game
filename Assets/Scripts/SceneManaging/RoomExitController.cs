using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;


// detects collisions 
public class RoomExitController : MonoBehaviour
{
    public SceneAsset sceneToLoad;
    private string sceneAssetPath;
    BoxCollider2D bc2d;
    public GameObject playerSpawnPosition;
    
    /*
     TODO make player persistent, so the player isn't re-created with every room they go into, and so we don't have to
        put a player object in every room
    */

    void Start()
    {
        bc2d = GetComponent<BoxCollider2D>();
        bc2d.isTrigger = true;
        sceneAssetPath = AssetDatabase.GetAssetPath(sceneToLoad);
        // get position of the PlayerSpawnPosition child object
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Debug.Log("SceneTransitionController collided with " + col.name);
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
        // if the collider is a player, load the next scene
        if (col.CompareTag("Player"))
        {
            // set player position to the position they /would/ be in the next room
            DontDestroyOnLoad(col);
            // switch to the next room
            SceneManager.LoadScene(sceneToLoad.name, LoadSceneMode.Single);
            col.gameObject.transform.position = playerSpawnPosition.transform.position;
            // TODO do a sick cool awesome transition effect
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.black;
    }
    
    // dont worry about this method
    public void SwitchScene(SceneAsset newScene)
    {
        // SceneManager.LoadScene(scene.buildIndex);
        
        SceneManager.LoadSceneAsync(sceneToLoad.name, LoadSceneMode.Single);
        // var scene = SceneManager.GetSceneByPath(assetPath);
        // Debug.Log($"asset path is {assetPath}");
        // SceneManager.LoadScene(scene.buildIndex);
    }
}
