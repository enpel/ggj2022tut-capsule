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

    //攻撃系コライダオブジェクト
    public GameObject gariPunchHand;
    public GameObject mukiPunchHand;
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


    // Start is called before the first frame update
    void Start()
    {
        //初期化設定
        handStand = false;
        airGage = 0;
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
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
       //逆立ちになった時
        if(handStand==true)
        {
            //逆立ち状態になる(仮)
            this.gameObject.transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else
        {
            //普通に立つ（仮）
            this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        //Move処理
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
            if(handStand==true)
            {
                if (mascle == true)
                {
                    mukiKapoeraKick.SetActive(true);
                    kapoeraTime = kapoeraInitTime*50;
                    rigid.AddForce(new Vector2(0, mukiKapoeraJumpForce),ForceMode2D.Impulse);
                }
                else
                {
                    gariKapoeraKick.SetActive(true);
                    kapoeraTime = kapoeraInitTime * 50;
                    if(inWater==true)
                    {
                        rigid.AddForce(new Vector2(0, -gariKapoeraDiveForce), ForceMode2D.Impulse);
                    }
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
