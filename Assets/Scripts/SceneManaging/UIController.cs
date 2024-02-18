using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UIController : MonoBehaviour
{
    public GameObject blackSquare;

    public void Awake()
    {
        // make permanent
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(GameObject.Find("Canvas"));
    }

    public void StartRoomTransition()
    {
        StartCoroutine(FadeToBlack());
    }

    public void FinishRoomTransition()
    {
        StartCoroutine(FadeToBlack(false));
    }
    
    public IEnumerator FadeToBlack(bool intoBlack = true, int fadeSpeed = 5)
    {
        Color objColor = blackSquare.GetComponent<Image>().color;
        float fadeAmount;

        if (intoBlack)
        {
            while (objColor.a < 1.0)
            {
                fadeAmount = objColor.a + fadeSpeed * Time.deltaTime;

                objColor = new Color(objColor.r, objColor.g, objColor.b, fadeAmount);
                blackSquare.GetComponent<Image>().color = objColor;
                yield return null;
            }
        }
        else
        {
            while (objColor.a > 0.0)
            {
                fadeAmount = objColor.a - fadeSpeed * Time.deltaTime;

                objColor = new Color(objColor.r, objColor.a, objColor.b, fadeAmount);
                blackSquare.GetComponent<Image>().color = objColor;
                yield return null;
            }
        }

    }
}
