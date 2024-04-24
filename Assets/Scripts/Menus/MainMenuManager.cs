using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] MusicChannelSO musicChannel;
    [SerializeField] AudioClip menuMusic;

    private void Start()
    {
        musicChannel.RequestSong(menuMusic);
        musicChannel.PlaySong();
    }

    public void StartGame()
    {
        // change to initial game start scene thing
        // Maybe make a saving/loading system and have this be a New Game option and add a Load Game option too
        // ^^^ very much an "if we have extra time" goal
        SceneManager.LoadScene(1);
        
        Debug.Log("totally started the game");
    }

    public void QuitGame()
    {
        Debug.Log("totally quit the game");
        Application.Quit(); // die
    }
}
