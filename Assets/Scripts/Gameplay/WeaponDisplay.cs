using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponDisplay : MonoBehaviour
{
    public List<Sprite> weaponSprites = new List<Sprite>();
    public List<string> weaponNames = new List<string>();
    public List<int> ammoCounts = new List<int>();
    public int currentValue = 0;
    public TextMeshProUGUI nameDisplay; 
    public TextMeshProUGUI ammoDisplay;

    public void WeaponDisplayUpdate(int value){
        currentValue = value;
        GetComponent<Image>().sprite = weaponSprites[currentValue];
        nameDisplay.text = weaponNames[currentValue];
        ammoDisplay.text = ammoCounts[currentValue].ToString();
        //ammoCounts[currentValue]--;
    }
    public void UpdateAmmoCount(int changeValue){
        if(ammoCounts[currentValue] + changeValue < 0)
        {
            return;
        }
        ammoCounts[currentValue] += changeValue;
        ammoDisplay.text = ammoCounts[currentValue].ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        nameDisplay = gameObject.transform.parent.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        ammoDisplay = gameObject.transform.parent.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        //WeaponDisplayUpdate(0);
        UpdateAmmoCount(0);
    }

}
