using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void SwitchScene(SceneAsset newScene)
    {
        // SceneManager.LoadScene(scene.buildIndex);
        var assetPath = AssetDatabase.GetAssetPath(newScene);
        SceneManager.LoadScene(assetPath);
        // var scene = SceneManager.GetSceneByPath(assetPath);
        Debug.Log($"asset path is {assetPath}");
        // SceneManager.LoadScene(scene.buildIndex);
    }

    public void LoadSceneName(string name)
    {
        SceneManager.LoadScene(name);
    }
}
