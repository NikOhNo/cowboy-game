using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] SaveManager saveManager;

    public SaveFile ChosenSave { get; private set; } = null;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SaveGame()
    {
        saveManager.UpdateSave(ChosenSave, true);
    }

    public void SetSave(SaveFile save)
    {
        ChosenSave = save;
    }

    public void AddQuest<T>(T quest) where T : Quest
    {
        ChosenSave.quests.Add(typeof(T).Name, quest);
    }

    public bool HasQuest<T>() where T : Quest
    {
        return ChosenSave.quests.ContainsKey(typeof(T).Name);
    }

    public T GetQuest<T>() where T: Quest
    {
        return ChosenSave.quests.TryGetValue(typeof(T).Name, out var quest) ? (T)quest : null;
    }
}
