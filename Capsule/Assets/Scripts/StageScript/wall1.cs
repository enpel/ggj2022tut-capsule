using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall1 : MonoBehaviour
{
    private Rigidbody rb;
    private void OnCollisionEnter2D(Collision2D collision)
    {
       // if (collision.gameObject.tag == "Player")
        //{
            Debug.Log("a");
            rb.AddForce(new Vector2 (10, 5));
            transform.localScale = new Vector2(0.5f, 0.5f);
      //  }
    }
}
