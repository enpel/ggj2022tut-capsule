using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inWarterSwitch : MonoBehaviour
{
    public Playercontrol player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Water")
        {
            player.inWater = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            player.inWater = false;
            player.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 2, 0);
        }
    }
}
