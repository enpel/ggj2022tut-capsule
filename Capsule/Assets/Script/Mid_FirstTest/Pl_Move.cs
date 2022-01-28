using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pl_Move : MonoBehaviour
{
    //FirstTest
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3(-1, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(1, 0, 0));
        }
    }

    void MoveLeft()
    {
        rb.AddForce(new Vector3(-1, 0, 0));
    }

    void MoveRight()
    {
        rb.AddForce(new Vector3(1, 0, 0));
    }
}
