using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConstructionQuestUsageDisplay : MonoBehaviour
{
    [SerializeField] string itemName;
    [SerializeField] TMP_Text displayText;

    public void UpdateDisplay(int number)
    {
        displayText.text = itemName + " - " + number;
    }
}
