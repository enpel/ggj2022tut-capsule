using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MukiGariSwitcher : MonoBehaviour
{

    public GameObject gariSprite;
    public GameObject mukiSprite;

    public Animator gariAnimator;
    public Animator mukiAnimator;
    public Animator nowAnimator;

    public Playercontrol controller;
    public int Time;
    // Start is called before the first frame update
    void Start()
    {
        gariAnimator = gariSprite.GetComponent<Animator>();
        mukiAnimator = mukiSprite.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(controller.mascle==true)
        {
            nowAnimator = mukiAnimator;
            mukiSprite.SetActive(true);
            gariSprite.SetActive(false);
        }
        else
        {
            nowAnimator = gariAnimator;
            gariSprite.SetActive(true);
            mukiSprite.SetActive(false);
        }

        if (controller.handStand == true)
        {
            nowAnimator.SetBool("HandStand", true);
        }
        else
        {
            nowAnimator.SetBool("HandStand", false);
        }

        if (controller.Move == true)
        {
            nowAnimator.SetBool("Move", true);

        }
        else
        {
            nowAnimator.SetBool("Move", false);
            
        }

        if (controller.Action==true)
        {
            Time += 1;
            if(Time==1)
                gariAnimator.SetTrigger("Action");
           
        }
        else
        {
            Time = 0;
        }

    }
}
