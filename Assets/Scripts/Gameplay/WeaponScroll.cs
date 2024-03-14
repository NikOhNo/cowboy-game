using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScroll : MonoBehaviour
{
    public float scrollSpeed = 10.0f;
    public int currentValue = 0;
    private int lastValue = -1;
    public int numWeapons = 3;
    public List<Sprite> weaponSprites = new List<Sprite>();
    public WeaponDisplay weaponDisplay;

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
        //only update on switches
        if(currentValue != lastValue)
        {
            lastValue = currentValue;
            WeaponLogic();
        }
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
        WeaponDisplay();
    }

    void WeaponDisplay(){
        weaponDisplay.WeaponDisplayUpdate(currentValue);
    }

    public void UpdateAmmoCount(int changeValue){
        //convert to channel system if there's time.
        weaponDisplay.UpdateAmmoCount(changeValue);
    }

}
