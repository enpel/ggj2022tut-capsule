using System.Collections;
using System.Collections.Generic;
using Core.Effect.Scripts;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class EffectExample : MonoBehaviour
{
    [SerializeField] private EffectPlayer _effectPlayer;

    [SerializeField] private Button _button;

    [SerializeField] private Transform _effectParent;
    // Start is called before the first frame update
    void Start()
    {

        _button.OnClickAsObservable().Subscribe(x =>
        {
            _effectPlayer.PlayEffect(EffectType.HitGariPunch);
            _effectPlayer.PlayEffect(EffectType.HitGariPunch, Vector3.forward, _effectParent);
        }).AddTo(this);
    }

}
