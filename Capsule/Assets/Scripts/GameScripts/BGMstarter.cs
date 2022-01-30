using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Global;
using Sound;
using UniRx;

public class BGMstarter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Global.SoundPlayer.PlayBGM(BgmType.InGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
