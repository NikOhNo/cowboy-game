using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class ConstructionQuestDisplay : MonoBehaviour
{
    [SerializeField] ConstructionQuestLog constructionQuestLog;
    [SerializeField] ConstructionQuestUsageDisplay revolver;
    [SerializeField] ConstructionQuestUsageDisplay hardHat;
    [SerializeField] ConstructionQuestUsageDisplay idCard;


    private void Awake()
    {
        constructionQuestLog.OnBeginQuest.AddListener(() => this.gameObject.SetActive(true));
        constructionQuestLog.OnEndQuest.AddListener(() => this.gameObject.SetActive(false));

        constructionQuestLog.OnObtainRevolver.AddListener(() => revolver.gameObject.SetActive(true));
        constructionQuestLog.OnObtainHardHat.AddListener(() => hardHat.gameObject.SetActive(true));
        constructionQuestLog.OnObtainID.AddListener(() => idCard.gameObject.SetActive(true));

        constructionQuestLog.OnUseRevolver.AddListener(() => revolver.UpdateDisplay(constructionQuestLog.TimesRevolverUsed));
        constructionQuestLog.OnUseHardHat.AddListener(() => hardHat.UpdateDisplay(constructionQuestLog.TimesHardHatUsed));
        constructionQuestLog.OnUseID.AddListener(() => idCard.UpdateDisplay(constructionQuestLog.TimesIDUsed));

        this.gameObject.SetActive(constructionQuestLog.QuestActive);

        if (constructionQuestLog.QuestActive)
        {
            this.gameObject.SetActive(true);
        }

        if (constructionQuestLog.HasRevolver)
        {
            revolver.gameObject.SetActive(true);
        }
        if (constructionQuestLog.HasHardHat)
        {
            hardHat.gameObject.SetActive(true);
        }
        if (constructionQuestLog.HasID)
        {
            idCard.gameObject.SetActive(true);
        }

        revolver.UpdateDisplay(constructionQuestLog.TimesRevolverUsed);
        hardHat.UpdateDisplay(constructionQuestLog.TimesHardHatUsed);
        idCard.UpdateDisplay(constructionQuestLog.TimesIDUsed);
    }
}
