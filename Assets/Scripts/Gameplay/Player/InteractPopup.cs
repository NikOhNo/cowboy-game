using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPopup : MonoBehaviour
{
    [SerializeField] Sprite doorPopup;
    [SerializeField] Sprite npcPopup;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        HidePopup();
    }

    public void DisplayDoorPopup()
    {
        gameObject.SetActive(true);
        spriteRenderer.sprite = doorPopup;
    }

    public void DisplayNPCPopup()
    {
        gameObject.SetActive(true);
        spriteRenderer.sprite = npcPopup;
    }

    public void HidePopup()
    {
        gameObject.SetActive(false);
    }
}
