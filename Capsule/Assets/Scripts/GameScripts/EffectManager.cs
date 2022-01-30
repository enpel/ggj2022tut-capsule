using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public GameObject startPos;

    public ParticleSystem gariKapoeraEffect;
    public ParticleSystem mukiKapoeraEffect;

    public Playercontrol controller;

    public int time;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ParticleSystem nowParticle;
        GameObject nowPObj;

        if (controller.Action == true)
        {
            if(controller.handStand==true)
            {
                if(controller.mascle==true)
                {
                    time += 1;
                    if (time == 1)
                    {
                        nowPObj = Instantiate(mukiKapoeraEffect.gameObject, startPos.transform);
                        nowParticle = nowPObj.GetComponent<ParticleSystem>();
                        nowParticle.Play();
                    }
                }
                else
                {
                    time += 1;
                    if (time == 1)
                    {
                        nowPObj = Instantiate(gariKapoeraEffect.gameObject, startPos.transform);
                        nowParticle = nowPObj.GetComponent<ParticleSystem>();
                        nowParticle.Play();
                    }
                }
            }
            else
            {
                return;
            }
        }
        else
        {
            time = 0;
            return;
        }
    }
}
