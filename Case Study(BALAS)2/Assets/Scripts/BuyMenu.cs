using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BuyMenu : MonoBehaviour
{
    public static bool buyEnergyToButton=false;
    public static bool buyBoxCarryPower=false;
    public GameObject BuyMenuBox;
    public GameObject BuyMenuEnergy;
    public Transform playerDOTween;
    public bool BuyMenuActive=false;
    // Start is called before the first frame update

    private void Update()
    {
        if (buyEnergyToButton == true)
        {
            BuyMenuEnergy.SetActive(true);
        }
        if (buyBoxCarryPower==true)
        {
            BuyMenuBox.SetActive(true);
        }
        if(buyEnergyToButton==false)
        {
            BuyMenuEnergy.SetActive(false);
        }
        if (buyBoxCarryPower == false)
        {
            BuyMenuBox.SetActive(false);
        }
        
       
    }

    public void increaseStaminaaa()
    {
        if (BuyManager.moneyCount>=200)
        {
            playerDOTween.DOScale(new Vector3(1, 1, 1),2f);
            BuyManager.moneyCount -= 200;
            StaminaBar.maxStamina += 20;
        }
        
    }
    public void increaseBoxCapacity()
    {
        if (BuyManager.moneyCount>=200)
        {
            playerDOTween.DORotate(new Vector3(1, 90, 1), 2f);
            BuyManager.moneyCount -= 200;
            CollectManager.boxLimit += 1;
        }
        
    }
}
