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
    public GameObject gariPunchHand;
    public GameObject mukiPunchHand;
    public GameObject gariKapoeraKick;
    public GameObject mukiKapoeraKick;


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
       //�K���E���L����
       if(airGage>=1)
       {
            mascle = true;
       }
       if(airGage<=0)
        {
            airGage = 0;
            mascle = false;
        }
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
            if(handStand==false)
                this.gameObject.transform.Translate(speed, 0, 0);
            if (handStand == true)
                this.gameObject.transform.Translate(-speed, 0, 0);
        }
        else if (Input.GetKey(leftMoveKey))
        {
            if(handStand==false)
                this.gameObject.transform.Translate(-speed, 0, 0);
            if (handStand == true)
                this.gameObject.transform.Translate(speed, 0, 0);
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
            airGage -= 1;
            if(handStand==true)
            {
                if (mascle == true)
                {
                    mukiKapoeraKick.SetActive(true);
                    kapoeraTime = kapoeraInitTime*50;
                }
                else
                {
                    gariKapoeraKick.SetActive(true);
                    kapoeraTime = kapoeraInitTime * 50;
                }                
            }
            else
            {
                if (mascle == true)
                {
                    mukiPunchHand.SetActive(true);
                    punchTime = punchInitTime * 50;
                }
                else
                {
                    gariPunchHand.SetActive(true);
                    punchTime = punchInitTime * 50;                }
            }
            
        }
        else 
        {
            if(kapoeraTime<=0)
            {
                mukiKapoeraKick.SetActive(false);
                gariKapoeraKick.SetActive(false);
                kapoeraTime = 0;
            }
            if(punchTime<=0)
            {
                mukiPunchHand.SetActive(false);
                gariPunchHand.SetActive(false);
                punchTime = 0;
            }
        }

    }
    void FixedUpdate()
    {
        punchTime -= 1;
        kapoeraTime -= 1;
    }
}
