using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;


// detects collisions 
public class SceneTransitionController : MonoBehaviour
{
    public SceneAsset sceneToLoad;
    private string sceneAssetPath;
    public int sceneBuildIndex;
    
    void Start()
    {
        BoxCollider2D bc2d;
        bc2d = GetComponent<BoxCollider2D>();
        bc2d.isTrigger = true;
        sceneAssetPath = AssetDatabase.GetAssetPath(sceneToLoad);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Debug.Log("SceneTransitionController collided with " + col.name);
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
        // if the collider is a player, load the next scene
        if (col.CompareTag("Player")) SceneManager.LoadScene(sceneToLoad.name, LoadSceneMode.Single);
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
