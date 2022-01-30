using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall1 : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] GameObject wall;
    private void OnCollisionEnter2D(Collision2D collision)
    {
       // if (collision.gameObject.tag == "")GariPunch
        //{
            Debug.Log("G");
            rb.AddForce(new Vector2 (1.0f, 0));
        //  }

        // else if (collision.gameObject.tag == "") MukiPunch
        //{
            Debug.Log("M");
        rb.AddForce(new Vector2(3.0f, 0));
        wall.SetActive(false);
        //  }
    }
}
