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

    //攻撃系コライダオブジェクト
    public GameObject punchHand;
    public GameObject kapoeraKick;

    public KeyCode leftMoveKey;
    public KeyCode rightMoveKey;


    //攻撃コライダ出現時間
    public float punchInitTime;
    public float punchTime;
    public float kapoeraInitTime;
    public float kapoeraTime;


    // Start is called before the first frame update
    void Start()
    {
        //初期化設定
        handStand = false;
        airGage = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
