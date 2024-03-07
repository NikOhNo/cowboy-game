using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        // change to initial game start scene thing
        // Maybe make a saving/loading system and have this be a New Game option and add a Load Game option too
        // ^^^ very much an "if we have extra time" goal
        
        Debug.Log("totally started the game");
    }

    public void QuitGame()
    {
        Debug.Log("totally quit the game");
        Application.Quit(); // die
    }
}
