using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Global;
using Sound;
using UniRx;

public class SoundManager : MonoBehaviour
{
    public Playercontrol control;
    public int time;

    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(control.Move==true)
        {
            if(control.mascle==true)
            {
                Global.SoundPlayer.PlaySE(SeType.MukiWalk);
            }
            else
            {
                Global.SoundPlayer.PlaySE(SeType.GariWalk);
            }
        }
        */

        if(control.Action==true)
        {
            if(control.handStand==true)
            {
                if(control.mascle==true)
                {
                    time += 1;
                    if(time==1)
                        Global.SoundPlayer.PlaySE(SeType.MukiCapoeira);
                }
                else
                {
                    time += 1;
                    if (time == 1)
                        Global.SoundPlayer.PlaySE(SeType.GariCapoeira);
                }
            }
            else
            {
                if (control.mascle == true)
                {
                    time += 1;
                    if (time == 1)
                        Global.SoundPlayer.PlaySE(SeType.MukiPunch);
                }
                else
                {
                    time += 1;
                    if (time == 1)
                        Global.SoundPlayer.PlaySE(SeType.GariPunch);
                }
            }
        }
    }
}
