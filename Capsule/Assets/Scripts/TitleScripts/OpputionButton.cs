using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpputionButton : MonoBehaviour
{
    [SerializeField] GameObject HideOptionButton;
    [SerializeField] GameObject OpenOptionButton;
    [SerializeField] GameObject OptionFrame;
    private bool option = false;
    public void ClickButton()
    {
        if (option == false)
        {
            OptionFrame.SetActive(true);//�ݒ��ʂ̃t���[��
            option = true;

        }
        else
        {
            OptionFrame.SetActive(false);//�ݒ��ʂ̃t���[��
            option = false;
        }
    }
}
