using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Global;
using Sound;
using UniRx;

public class GariMoveSE : MonoBehaviour
{
    public void GMSE()
    {
        Global.SoundPlayer.PlaySE(SeType.GariWalk);
    }
}
