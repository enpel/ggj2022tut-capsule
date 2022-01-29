using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCreditButton : MonoBehaviour
{
    [SerializeField] GameObject Credit;
    [SerializeField] GameObject Creditbutton;
    [SerializeField] GameObject HideCreditButtonUI;
    [SerializeField] GameObject OptionButton;
    public void ClickButton()
    {
        Credit.SetActive(false);
        Creditbutton.SetActive(true);
        HideCreditButtonUI.SetActive(false);
        OptionButton.SetActive(true);
    }
}
