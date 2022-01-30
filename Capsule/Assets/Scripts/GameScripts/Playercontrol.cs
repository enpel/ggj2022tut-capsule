using System.Collections;
using System.Collections.Generic;
using Core.Global;
using Sound;
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
    //�}�b�`���̎��̃W�����v��
    public float mukiKapoeraJumpForce;
    //�K���K�����̐�����
    public float gariKapoeraDiveForce;

    //���ɓ����Ă邩�ǂ����̔���
    public bool inWater;
    //���̕���
    public float inWaterForce;

    //�E��������������
    public bool rightFront;

    //�X�v���C�g�I�u�W�F�N�g
    public GameObject charaSprite;
    //
    public float punchForce;

    //�U���n�R���C�_�I�u�W�F�N�g
    public GameObject gariPunchHandL;
    public GameObject mukiPunchHandL;
    public GameObject gariPunchHandR;
    public GameObject mukiPunchHandR;
    public GameObject gariKapoeraKick;
    public GameObject mukiKapoeraKick;

    public KeyCode leftMoveKey;
    public KeyCode rightMoveKey;

    //�U���R���C�_�o������
    public float punchInitTime;
    public float punchTime;
    public float kapoeraInitTime;
    public float kapoeraTime;

    Rigidbody2D rigid;

    CapsuleCollider2D colmanage;

    public bool Move;
    public bool Action;

    public GameObject MascleGetEffect;

    // Start is called before the first frame update
    void Start()
    {
        //�������ݒ�
        handStand = false;
        airGage = 0;
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
        rightFront = true;
        colmanage = gameObject.GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //�K���E���L����
        if(airGage>=1)
        {
            if (!mascle)
            {
                Instantiate(MascleGetEffect, transform.position, transform.rotation, transform);
            }
            mascle = true;
        }
        if(airGage<=0)
        {
            airGage = 0;
            mascle = false;
        }

        //�J�v�Z���R���C�_����
        if(mascle==true)
        {
            colmanage.offset = new Vector2(0f, -0.2f);
            colmanage.size=new Vector2(1f, 1.56f);
        }
        else
        {
            colmanage.offset = new Vector2(0f, -0.2f);
            colmanage.size = new Vector2(0.22f, 1.56f);
        }

        //Move����
        if(Input.GetKey(rightMoveKey))
        {
            Move = true;
            rightFront = true;
           // if(handStand==false)
                this.gameObject.transform.position += transform.right * speed * Time.deltaTime;
           // if (handStand == true)
                //this.gameObject.transform.position -= transform.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey(leftMoveKey))
        {
            Move = true;
            rightFront = false;
            //if (handStand == false)
                this.gameObject.transform.position -= transform.right * speed * Time.deltaTime;
            //if (handStand == true)
                //this.gameObject.transform.position += transform.right * speed * Time.deltaTime;
        }
        else
        {
            Move = false;
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
            Action = true;
            if (handStand == true)
            {
                if (mascle == true)
                {
                    mukiKapoeraKick.SetActive(true);
                    kapoeraTime = kapoeraInitTime * 50;
                    gameObject.transform.Translate( new Vector3(0f, 1f, 0f));
                    rigid.AddForce(new Vector2(0, mukiKapoeraJumpForce), ForceMode2D.Impulse);
                    Action = true;
                    Global.SoundPlayer.PlaySE(SeType.MukiCapoeira);
                }
                else
                {
                    gariKapoeraKick.SetActive(true);
                    kapoeraTime = kapoeraInitTime * 50;
                    if (inWater == true)
                    {
                        rigid.AddForce(new Vector2(0, -gariKapoeraDiveForce), ForceMode2D.Impulse);
                    }
                    Global.SoundPlayer.PlaySE(SeType.GariCapoeira);
                }
            }
            else
            {
                if (mascle == true)
                {
                    if (rightFront == true)
                    {
                        mukiPunchHandR.SetActive(true);
                        rigid.AddForce(new Vector2(punchForce, 0), ForceMode2D.Impulse);
                    }
                    else
                    {
                        mukiPunchHandL.SetActive(true);
                        rigid.AddForce(new Vector2(-punchForce, 0), ForceMode2D.Impulse);
                    }
                    punchTime = punchInitTime * 50;
                    Global.SoundPlayer.PlaySE(SeType.MukiPunch);

                }
                else
                {
                    if (rightFront == true)
                    {
                        gariPunchHandR.SetActive(true);
                    }
                    else
                    {
                        gariPunchHandL.SetActive(true);
                    }
                    punchTime = punchInitTime * 50;
                    Global.SoundPlayer.PlaySE(SeType.GariPunch);
                }
            }
            
        }
        else 
        {
            if (handStand == true)
            {
                if (kapoeraTime <= 0)
                {
                    mukiKapoeraKick.SetActive(false);
                    gariKapoeraKick.SetActive(false);
                    kapoeraTime = 0;
                    Action = false;
                }
            }

            if (handStand == false)
            {
                if (punchTime <= 0)
                {
                    mukiPunchHandL.SetActive(false);
                    gariPunchHandL.SetActive(false);
                    mukiPunchHandR.SetActive(false);
                    gariPunchHandR.SetActive(false);
                    punchTime = 0;
                    rigid.velocity = new Vector2(0, rigid.velocity.y);
                    Action = false;
                }
            }
        }

    }
    void FixedUpdate()
    {
        punchTime -= 1;
        kapoeraTime -= 1;
        
        
        if(inWater==true)
        {
            rigid.AddForce(new Vector2(0, inWaterForce));
        }

    }
}
