using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCreditButton : MonoBehaviour
{
    [SerializeField] GameObject Credit;
    [SerializeField] GameObject HideCreditButtonUI;
    public void ClickButton()
    {
        Credit.SetActive(false);
        HideCreditButtonUI.SetActive(false);
    }
}
