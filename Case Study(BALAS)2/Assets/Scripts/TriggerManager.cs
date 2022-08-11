using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public delegate void OnCollectArea();
    public static event OnCollectArea OnBoxCollect;
    public static BoxManager boxManager;
    public static WorkerManager workerManager;
    public delegate void OnArea();
    public static event OnArea OnBoxGive;

    public delegate void OnMoneyArea();
    public static event OnMoneyArea OnMoneyCollected;

    public delegate void OnBuyEnergy();
    public static event OnBuyEnergy OnBuyingEnergy;
    public static BuyEnergy energyToBuy;
    private Animator Anim;
    public int energyCount = 1000;


    bool isCollecting,isGiving;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        StartCoroutine(CollectEnum());
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            GetComponent<Animator>().Play("CollectAnim");
            isCollecting = true;
            boxManager = other.gameObject.GetComponent<BoxManager>();
        }
        if (other.gameObject.CompareTag("GiveArea"))
        {
            isGiving = true;
            workerManager = other.gameObject.GetComponent<WorkerManager>();

        }
        if (other.gameObject.CompareTag("BuyEnergy"))
        {
            BuyMenu.buyEnergyToButton = true;
            BuyMenu.buyBoxCarryPower = true;
                OnBuyingEnergy();
                energyToBuy = other.gameObject.GetComponent<BuyEnergy>();
            
            
            
        }
        if (other.gameObject.CompareTag("FullEnergy"))
        {
            StaminaBar.InArea=true;
            StaminaBar.currentStamina = StaminaBar.maxStamina;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            OnMoneyCollected();
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            GetComponent<Animator>().Play("Midair");
            isCollecting = false;
            boxManager = null;
        }
        if (other.gameObject.CompareTag("GiveArea"))
        {
            isGiving = false;
            workerManager = null;
        }

        if (other.gameObject.CompareTag("BuyEnergy"))
        {
            BuyMenu.buyEnergyToButton = false;
            BuyMenu.buyBoxCarryPower = false;
            energyToBuy = null;
        }
        if (other.gameObject.CompareTag("FullEnergy"))
        {
            StaminaBar.InArea=false;
        }

    }

    private IEnumerator CollectEnum()
    {
        while (true)
        {
            if (isCollecting == true)
            {
                OnBoxCollect();
            }
            if (isGiving == true)
            {
                OnBoxGive();
            }
            yield return new WaitForSeconds(1);
        }
        
    }

    

    
}
