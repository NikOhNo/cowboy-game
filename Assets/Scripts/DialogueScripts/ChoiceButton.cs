using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    public Button Button { get; private set; }
    public TMP_Text Text { get; private set; }

    private void Awake()
    {
        Button = GetComponent<Button>();
        Text = GetComponentInChildren<TMP_Text>();

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
        gameObject.SetActive(false);

        Button.onClick.RemoveAllListeners();
        Text.text = "";
    }
}
