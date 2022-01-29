using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditButton : MonoBehaviour
{
    [SerializeField] GameObject Credit;
    [SerializeField] GameObject Creditbutton;
    [SerializeField] GameObject HideCreditButton;
    public void ClickButton()
    {
        Credit.SetActive(true);
        Creditbutton.SetActive(false);
        HideCreditButton.SetActive(true);
    }
}
