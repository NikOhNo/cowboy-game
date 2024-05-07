using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConstructionQuestUsageDisplay : MonoBehaviour
{
    [SerializeField] string itemName;
    TMP_Text displayText;

    private void Awake()
    {
        displayText = GetComponentInChildren<TMP_Text>();
    }

    public void UpdateDisplay(int number)
    {
        displayText.text = itemName + " - " + number;
    }
}
