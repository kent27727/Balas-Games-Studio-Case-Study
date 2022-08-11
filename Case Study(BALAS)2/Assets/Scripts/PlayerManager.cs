using System;

using System.Linq;

using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerManager : MonoBehaviour
{
    private Vector3 direction;
    private Camera Cam;
    [SerializeField] private float playerSpeed;
    private Animator Anim;
    private float YAxis, delay;
    
    //public Slider staminaBar;
    //private int maxStamina = 100;
    //private int currentStamina;
    //private int amount;

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Cam = Camera.main;
        Anim = GetComponent<Animator>();
        //currentStamina = maxStamina;
        //staminaBar.maxValue = maxStamina;
        //staminaBar.value = maxStamina;
        //StartCoroutine(Stamina());


    }

    // Update is called once per frame
    void Update()
    {

        //staminaBar.maxValue = maxStamina;
        if (Input.GetMouseButton(0))
        {
            if (StaminaBar.currentStamina > 0)
            {
                Plane plane = new Plane(Vector3.up, transform.position);
                Ray ray = Cam.ScreenPointToRay(Input.mousePosition);

                if (plane.Raycast(ray, out var distance))
                    direction = ray.GetPoint(distance);

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(direction.x, 0f, direction.z),
                    playerSpeed * Time.deltaTime);

                var offset = direction - transform.position;

                if (offset.magnitude > 1f)
                    transform.LookAt(direction);
                Anim.SetFloat("MoveSpeed", Vector3.ClampMagnitude(direction, 1).magnitude, delay, Time.deltaTime * 10);
            }
            

            StaminaBar.instance.UseSTAMÝNA(10);
            


            //Anim.SetFloat("MoveSpeed", direction.magnitude);
            


        }

    }
    //public IEnumerator Stamina()
    //{
    //    while (true)
    //    {
    //        if (currentStamina - 10 >= 0)
    //        {
    //            currentStamina -= 10;
    //            staminaBar.value = currentStamina;
    //        }

    //        yield return new WaitForSeconds(1);
    //    }


    //}
}
