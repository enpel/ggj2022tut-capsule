using System.Collections;
using System.Collections.Generic;
using Core.Global;
using Sound;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class GlobalExample : MonoBehaviour
{
    [SerializeField] private Button _playBgmButton;
    [SerializeField] private Button _stopBgmButton;
    [SerializeField] private Button _playSeButton;
    [SerializeField] private Button _playEffectButton;
    // Start is called before the first frame update
    void Start()
    {
        _playBgmButton.OnClickAsObservable().Subscribe(x => Global.SoundPlayer.PlayBGM(BgmType.Title)).AddTo(this);
        _stopBgmButton.OnClickAsObservable().Subscribe(x => Global.SoundPlayer.StopBGMAll()).AddTo(this);
        _playSeButton.OnClickAsObservable().Subscribe(x => Global.SoundPlayer.PlaySE(SeType.OK)).AddTo(this);
        _playEffectButton.OnClickAsObservable().Subscribe(x => Global.EffectPlayer.PlayEffect(EffectType.GariPunch)).AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
