using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEff : MonoBehaviour
{
    private ParticleSystem PS;

    void Start()
    {
        PS = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (PS == null)
        {
            Destroy(gameObject);
        }
    }
}
