using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrol : MonoBehaviour
{
    //逆立ち状態の時True
    public bool handStand;
    //空気量
    public int airGage;
    //マッチョか否か
    public bool mascle;
    //プレイヤーの移動速度
    public float speed;
    //マッチョの時のジャンプ力
    public float mukiKapoeraJumpForce;
    //ガリガリ時の潜水力
    public float gariKapoeraDiveForce;

    //水に入ってるかどうかの判定
    public bool inWater;
    //水の浮力
    public float inWaterForce;

    //右向き左向き判定
    public bool rightFront;

    //スプライトオブジェクト
    public GameObject charaSprite;
    //
    public float punchForce;

    //攻撃系コライダオブジェクト
    public GameObject gariPunchHandL;
    public GameObject mukiPunchHandL;
    public GameObject gariPunchHandR;
    public GameObject mukiPunchHandR;
    public GameObject gariKapoeraKick;
    public GameObject mukiKapoeraKick;


    public KeyCode leftMoveKey;
    public KeyCode rightMoveKey;

    


    //攻撃コライダ出現時間
    public float punchInitTime;
    public float punchTime;
    public float kapoeraInitTime;
    public float kapoeraTime;

    Rigidbody2D rigid;

    CapsuleCollider2D colmanage;

    public bool Move;
    public bool Action;

    // Start is called before the first frame update
    void Start()
    {
        //初期化設定
        handStand = false;
        airGage = 0;
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
        rightFront = true;
        colmanage = gameObject.GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //ガリ・ムキ判定
        if(airGage>=1)
        {
            mascle = true;
        }
        if(airGage<=0)
        {
            airGage = 0;
            mascle = false;
        }

        //カプセルコライダ調整
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

        //右向きと左向きでサイズを変更
        if(rightFront==true)
        {
            charaSprite.transform.localScale=new Vector3(0.1f,0.1f,0.1f);
        }
        else
        {
            charaSprite.transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
        }
        //逆立ちになった時
        /*
        if(handStand==true)
        {
            //逆立ち状態になる(仮)
            //this.gameObject.transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else
        {
            //普通に立つ（仮）
            //this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }*/

        //Move処理
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
  

        if(inWater==true)
        {
            rigid.AddForce(new Vector2(0, inWaterForce),ForceMode2D.Force);
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
                    rigid.AddForce(new Vector2(0, mukiKapoeraJumpForce), ForceMode2D.Impulse);
                }
                else
                {
                    gariKapoeraKick.SetActive(true);
                    kapoeraTime = kapoeraInitTime * 50;
                    if (inWater == true)
                    {
                        rigid.AddForce(new Vector2(0, -gariKapoeraDiveForce), ForceMode2D.Impulse);
                    }
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
                }
            }
            
        }
        else 
        {
            if(kapoeraTime<=0)
            {
                mukiKapoeraKick.SetActive(false);
                gariKapoeraKick.SetActive(false);
                kapoeraTime = 0;
                Action = false;
            }
            if(punchTime<=0)
            {
                mukiPunchHandL.SetActive(false);
                gariPunchHandL.SetActive(false);
                mukiPunchHandR.SetActive(false);
                gariPunchHandR.SetActive(false);
                punchTime = 0;
                rigid.velocity=new Vector2(0, 0);
                Action = false;
            }
        }

    }
    void FixedUpdate()
    {
        punchTime -= 1;
        kapoeraTime -= 1;
    }
}
