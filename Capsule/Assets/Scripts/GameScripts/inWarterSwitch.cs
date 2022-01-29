using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inWarterSwitch : MonoBehaviour
{
    public Playercontrol player;
    public float flowStartTime;
    public float Time;

    // Start is called before the first frame update
    void Start()
    {
        Time = flowStartTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time<=0)
        {
            player.inWater = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Water")
        {
            Time -= 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            player.inWater = false;
            Time = flowStartTime * 50;
        }
    }
}
