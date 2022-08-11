using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;
    public static int maxStamina=100;
    public static int currentStamina;
    private static int amount;
    public static bool InArea;

    public static StaminaBar instance;


   

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.value = maxStamina;
        StartCoroutine(Stamina());
    }

    private void Update()
    {
        
        staminaBar.maxValue = maxStamina;
        
    }

    // Update is called once per frame
    public void UseSTAMÝNA(int _samount)
    {
        

    }

    public IEnumerator Stamina()
    {
        while (true)
        {
            if(currentStamina -1 >= 0)
            {
                currentStamina -= 1;
                staminaBar.value = currentStamina;
            }
            
            yield return new WaitForSeconds(0.2f);
        }
        
        
    }
}

