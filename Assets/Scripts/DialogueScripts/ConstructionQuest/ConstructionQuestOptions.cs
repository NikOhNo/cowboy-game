using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionQuestOptions : MonoBehaviour
{
    [SerializeField] ConstructionQuestLog questLog;

    [SerializeField] GameObject displayPanel;

    [SerializeField] GameObject revolverOption;
    [SerializeField] GameObject hardHatOption;
    [SerializeField] GameObject idOption;

    private void Awake()
    {
        HideOptions();
    }

    public void DisplayOptions()
    {
        displayPanel.SetActive(true);
        UpdateOptions();
    }

    public void HideOptions()
    {
        displayPanel.SetActive(false);
    }

    private void UpdateOptions()
    {
        revolverOption.SetActive(questLog.HasRevolver);
        hardHatOption.SetActive(questLog.HasHardHat);
        idOption.SetActive(questLog.HasID);
    }
}
