using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrol : MonoBehaviour
{
    //�t������Ԃ̎�True
    public bool handStand;
    //��C��
    public int airGage;
    //�}�b�`�����ۂ�
    public bool mascle;
    //�v���C���[�̈ړ����x
    public float speed;

    //�U���n�R���C�_�I�u�W�F�N�g
    public GameObject punchHand;
    public GameObject kapoeraKick;

    public KeyCode leftMoveKey;
    public KeyCode rightMoveKey;
    public KeyCode handStandSwitch;
    public KeyCode actionKey;

    // Start is called before the first frame update
    void Start()
    {
        //�������ݒ�
        handStand = false;
        airGage = 0;
    }

    // Update is called once per frame
    void Update()
    {
       //�t�����ɂȂ�����
        if(handStand==true)
        {
            //�t������ԂɂȂ�(��)
            this.gameObject.transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else
        {
            //���ʂɗ��i���j
            this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        //Move����
        if(Input.GetKey(rightMoveKey))
        {

        }
        else if (Input.GetKey(leftMoveKey))
        {

        }

        
        if(Input.GetKey(handStandSwitch))
        {
            if(handStand==true)
            {
                handStand = false;
            }
            else 
            {
                handStand = true;
            }
        }

        if(Input.GetKey(actionKey))
        {
            if(handStand==true)
            {

            }
            else
            {

            }
            
        }
    }
}
