using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Global;
using Sound;
using UniRx;

public class MukiMoveSE : MonoBehaviour
{
    public void MMSE()
    {
        Global.SoundPlayer.PlaySE(SeType.MukiWalk);
    }
}
