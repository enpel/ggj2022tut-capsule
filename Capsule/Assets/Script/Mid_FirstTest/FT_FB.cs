using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FT_FB : MonoBehaviour
{
    public GameObject Tarai;
    private FT_Tarai FTT;

    void Start()
    {
        FTT = Tarai.GetComponent<FT_Tarai>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            FTT.TaraiStart();
        }
    }
}
