using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFreezer : MonoBehaviour
{
    public void FreezeGame()
    {
        Time.timeScale = 0f;
    }

    public void UnfreezeGame()
    {
        Time.timeScale = 1f;
    }
}
