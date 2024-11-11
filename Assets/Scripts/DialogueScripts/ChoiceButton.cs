using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button Button { get; private set; }
    public TMP_Text Text { get; private set; }

    [SerializeField] float hoverExpandMultiplier = 1.1f;
    [SerializeField] float hoverExpandTime = 0.1f;

    private RectTransform rectTransform;
    private Vector2 originalSize;
    private Coroutine resizeCoroutine;

    private void Awake()
    {
        Button = GetComponent<Button>();
        Text = GetComponentInChildren<TMP_Text>();
        rectTransform = GetComponent<RectTransform>();
        originalSize = rectTransform.sizeDelta;

        ClearButton();
    }

    public void SetChoice(Choice choice, UnityAction choiceAction)
    {
        gameObject.SetActive(true);

        Text.text = choice.text;
        Button.onClick.AddListener(choiceAction);
    }

    public void ClearButton()
    {
        StopAllCoroutines();
        gameObject.SetActive(false);

        rectTransform.sizeDelta = originalSize;
        Button.onClick.RemoveAllListeners();
        Text.text = "";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ExpandButton();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ShrinkButton();
    }

    private void ExpandButton()
    {
        if (resizeCoroutine != null) StopCoroutine(resizeCoroutine);
        StartCoroutine(ResizeButton(originalSize * hoverExpandMultiplier));
    }

    private void ShrinkButton()
    {
        if (resizeCoroutine != null) StopCoroutine(resizeCoroutine);
        StartCoroutine(ResizeButton(originalSize));
    }

    IEnumerator ResizeButton(Vector2 newSize)
    {
        Vector2 startSize = rectTransform.sizeDelta;

        float startTime = Time.unscaledTime;
        float timeElapsed = 0f;

        while (timeElapsed < hoverExpandTime)
        {
            rectTransform.sizeDelta = Vector2.Lerp(startSize, newSize, timeElapsed / hoverExpandTime);

            timeElapsed = Time.unscaledTime - startTime;
            yield return null;
        }

        rectTransform.sizeDelta = newSize;
    }
}
