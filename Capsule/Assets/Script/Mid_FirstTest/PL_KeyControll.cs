using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_KeyControll : MonoBehaviour
{
    Rigidbody rb;

    public bool LookRight = true;
    public bool Handstand = false;

    public int AirNum = 3;
    public int AirNumMax = 3;
    public float TimeNow = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        TimeNow += Time.deltaTime;
        if (TimeNow >= 1)
        {
            while(true)
            {
                if (TimeNow < 1)
                {
                    break;
                }
                TimeNow--;
                if (AirNum < AirNumMax)
                {
                    AirNum++;
                }
            }
        }

        if (rb.velocity.magnitude > 7.0)
        {
            rb.velocity = rb.velocity.normalized;
            rb.velocity *= 7;
        }

        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (AirNum >= 1)
            {
                AirNum--;
                ChangeHandstand();
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (AirNum >= 1)
            {
                AirNum--;
                if (Handstand)
                {
                    AttackHandStand();
                }
                else
                {
                    AttackNormal();
                }
            }
        }
    }

    void AttackNormal()
    {
        if (LookRight)
        {
            rb.AddForce(new Vector3(7, 0, 0), ForceMode.Impulse);
        }
        else
        {
            rb.AddForce(new Vector3(-7, 0, 0), ForceMode.Impulse);
        }
    }
    void AttackHandStand()
    {
        rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
    }

    void ChangeHandstand()
    {
        Handstand = !Handstand;
    }

    void MoveLeft()
    {
        rb.AddForce(new Vector3(-20 * Time.deltaTime, 0, 0), ForceMode.Impulse);
        LookRight = false;
    }
    void MoveRight()
    {
        rb.AddForce(new Vector3(20 * Time.deltaTime, 0, 0), ForceMode.Impulse);
        LookRight = true;
    }
}
