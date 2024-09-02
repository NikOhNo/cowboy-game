using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newSpeakerProfile", menuName = "New Speaker Profile")]
public class SpeakerProfileSO : ScriptableObject
{
    public Sprite SpeakerSprite;
    public AudioClip Voice;
}
