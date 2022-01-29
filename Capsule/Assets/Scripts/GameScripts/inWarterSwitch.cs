using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inWarterSwitch : MonoBehaviour
{
    public Playercontrol player;
    public bool inwater;
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
        if(inwater==true)
        {
            Time -= 1;
        }
        if(Time<=0)
        {
            player.inWater = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Water")
        {
            inwater = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            player.inWater = false;
            inwater = false;
            Time = flowStartTime * 50;
            if(player.gameObject.GetComponent<Rigidbody2D>().velocity.y>=5)
            {
                player.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 4f);
            }
        }
    }
}
