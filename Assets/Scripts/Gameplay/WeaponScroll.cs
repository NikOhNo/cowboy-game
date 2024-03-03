using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScroll : MonoBehaviour
{
    public float scrollSpeed = 10.0f;
    public int currentValue = 0;
    public int numWeapons = 3;

    void Update()
    {
        // Get the scroll wheel input
        float scrollInput = Input.GetAxisRaw("Mouse ScrollWheel");

        // Change the current value based on the scroll input
        float midValue = scrollInput * scrollSpeed;
        currentValue += (int)(midValue);
        if(currentValue < 0)
        {
            currentValue = numWeapons - 1;
        }
        else{
            currentValue = currentValue % numWeapons;
        }
        WeaponLogic();
    }


    void WeaponLogic(){
        //not proud of this, but didn't want to invest time on O(1).
        for (int i = 0; i < numWeapons; i++)
        {
            if (i == currentValue)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

}
