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


    //�U���R���C�_�o������
    public float punchInitTime;
    public float punchTime;
    public float kapoeraInitTime;
    public float kapoeraTime;


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
            this.gameObject.transform.Translate(speed, 0, 0);
        }
        else if (Input.GetKey(leftMoveKey))
        {
            this.gameObject.transform.Translate(-speed, 0, 0);
        }

        
        if(Input.GetMouseButtonDown(1))
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
        
        if(Input.GetMouseButtonDown(0))
        {
            if(handStand==true)
            {
                kapoeraKick.SetActive(true);
                kapoeraTime = kapoeraInitTime*50;
            }
            else
            {

                punchHand.SetActive(true);
                punchTime = punchInitTime*50;
            }
            
        }
        else 
        {
            if(kapoeraTime>=0)
            {
                kapoeraKick.SetActive(false);
            }
            if(punchTime>=0)
            {
                punchHand.SetActive(false);
            }
        }
    }
}
