using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BuyManager : MonoBehaviour
{
    public static int moneyCount = 0;
    public static int energyCount = 0;
    private string moneyString;
    public Text moneyText;
    public Transform moneytextDOTween;

    private void OnEnable()
    {
        TriggerManager.OnMoneyCollected += IncreaseMoney;
        TriggerManager.OnBuyingEnergy += BuyEnergyAreaaa;


    }

    private void Update()
    {
        moneyText.text = moneyCount.ToString();
    }

    void BuyEnergyAreaaa()
    {
        if (TriggerManager.energyToBuy != null)
        {
            if (moneyCount > 1)
            {
                TriggerManager.energyToBuy.BuyE(1);
                //moneyCount -= 1;
               // energyCount += 1;
            }
        }
    }

    private void OnDisable()
    {

        TriggerManager.OnMoneyCollected -= IncreaseMoney;
        TriggerManager.OnBuyingEnergy -= BuyEnergyAreaaa;

    }

    void IncreaseMoney()
    {
        moneytextDOTween.DOScale(new Vector3(3, 3, 3), 1f);
        moneyCount += 50;
    }
}
