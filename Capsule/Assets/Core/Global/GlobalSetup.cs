using Core.Effect.Scripts;
using Core.Global;
using UnityEngine;

public class GlobalSetup : MonoBehaviour
{
    [SerializeField] private SoundPlayer _soundPlayer;
    [SerializeField] private EffectPlayer _effectPlayer;
    // Start is called before the first frame update
    void Awake()
    {
        Global.SetSoundPlayer(_soundPlayer);
        Global.SetEffectPlayer(_effectPlayer);
    }
}
