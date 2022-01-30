using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Global;
using Sound;

public class SStoTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneTracker.returnTitleScene == true)
        {
            Global.SoundPlayer.PlaySE(SeType.Cancel);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
