using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Global;
using Sound;

public class SStoIG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(SceneTracker.ssToIG==true)
            Global.SoundPlayer.PlaySE(SeType.OK);
        SceneTracker.ssToIG = false;
        if(SceneTracker.cleaToIG==true)
            Global.SoundPlayer.PlaySE(SeType.OK);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
