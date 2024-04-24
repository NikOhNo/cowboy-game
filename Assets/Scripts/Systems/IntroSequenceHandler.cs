using Assets.Scripts.Gameplay.Questing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class IntroSequenceHandler : MonoBehaviour
{
    [SerializeField] UnityEvent OnCutsceneBegin;
    [SerializeField] UnityEvent OnCutsceneEnd;
    [SerializeField] QuestCompletionLog questLog;

    PlayableDirector playableDirector;

    private void Awake()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }

    private void Start()
    {
        if (questLog.SeenFirstCutscene == false)
        {
            playableDirector.Play();
            OnCutsceneBegin.Invoke();
            questLog.SeenFirstCutscene = true;
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
