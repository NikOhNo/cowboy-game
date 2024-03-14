using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPoint : MonoBehaviour
{
    public void ReturnPlayer()
    {
        FindObjectOfType<PlayableCharacter>().gameObject.transform.position = this.transform.position;
    }
}
