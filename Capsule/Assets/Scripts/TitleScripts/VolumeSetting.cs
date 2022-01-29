using System.Collections;
using System.Collections.Generic;
using Core.Global;
using Sound;
using UnityEngine;

public class VolumeSetting : MonoBehaviour
{
    void Start()
    {
        Global.SoundPlayer.PlayBGM(BgmType.Title);
    }

    public void SoundSliderOnValueChange(float newSliderValu)
    {
        Global.SoundPlayer.SetVolume(MixerType.Master, newSliderValu);
    }
}
