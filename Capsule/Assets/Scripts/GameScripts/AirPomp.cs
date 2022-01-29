using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AirPomp : MonoBehaviour
{
    public TextMeshPro text;

    public int initLimit;
    public int Limit;

    // Start is called before the first frame update
    void Start()
    {
        Limit = initLimit;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Limit+"";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Playercontrol>().handStand == true)
            {
                if (Limit >= 1)
                {
                    if (collision.gameObject.GetComponent<Playercontrol>().airGage < 3)
                    {
                        collision.gameObject.GetComponent<Playercontrol>().airGage = 3;
                        Limit -= 1;
                    }
                }
            }
        }

    }
}
