using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class IntroSequenceHandler : MonoBehaviour
{
    [SerializeField] UnityEvent OnCutsceneBegin;
    [SerializeField] UnityEvent OnCutsceneEnd;
    //[SerializeField] QuestCompletionLog questLog;

    PlayableDirector playableDirector;

    private void Awake()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }

    private void Start()
    {
        IntroQuest introQuest = GameManager.Instance.GetQuest<IntroQuest>();

        if (introQuest.SeenFirstCutscene == false)
        {
            playableDirector.Play();
            OnCutsceneBegin.Invoke();
            GameManager.Instance.GetQuest<IntroQuest>().SeenFirstCutscene = true;
            GameManager.Instance.SaveGame();
        }
        else
        {
            AnnounceCutsceneEnd();
        }
    }

    public void AnnounceCutsceneEnd()
    {
        Debug.Log("yippieeeee!!!!!!!!!!!!");
        OnCutsceneEnd.Invoke();
    }
}
