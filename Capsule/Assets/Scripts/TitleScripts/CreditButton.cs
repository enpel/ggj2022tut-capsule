using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditButton : MonoBehaviour
{
    [SerializeField] GameObject Credit;
    [SerializeField] GameObject HideCreditButton;
    public void ClickButton()
    {
        Credit.SetActive(true);
        HideCreditButton.SetActive(true);
    }
}
