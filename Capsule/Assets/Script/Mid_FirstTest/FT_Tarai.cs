using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FT_Tarai : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    public void TaraiStart()
    {
        rb.useGravity = true;
    }
}
