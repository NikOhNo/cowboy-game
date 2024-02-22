using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UIController : MonoBehaviour
{
    public GameObject blackSquare;
    public static UIController Instance {get; private set; }
    
    public event Action onFinishFadeToBlack;
    public event Action onFinishFadeFromBlack;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        // make permanent
        DontDestroyOnLoad(GameObject.Find("Canvas"));
    }
    
    public IEnumerator FadeToBlack(int fadeSpeed = 5)
    {
        Color objColor = blackSquare.GetComponent<Image>().color;
        float fadeAmount;

        
        while (objColor.a < 1.0)
        {
            fadeAmount = objColor.a + fadeSpeed * Time.deltaTime;
            objColor = new Color(objColor.r, objColor.g, objColor.b, fadeAmount);
            blackSquare.GetComponent<Image>().color = objColor;
            yield return null;
        }
        onFinishFadeToBlack?.Invoke();


    }

    public IEnumerator FadeFromBlack(int fadeSpeed = 5)
    {
        Color objColor = blackSquare.GetComponent<Image>().color;
        float fadeAmount;
        
        while (objColor.a > 0.0)
        {
            fadeAmount = objColor.a - fadeSpeed * Time.deltaTime;

            objColor = new Color(objColor.r, objColor.g, objColor.b, fadeAmount);
            blackSquare.GetComponent<Image>().color = objColor;
            yield return null;
        }
        onFinishFadeFromBlack?.Invoke();
    }
}
