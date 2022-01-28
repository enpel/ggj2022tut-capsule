using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSoundPlayerSetup : MonoBehaviour
{
    [SerializeField] private SoundPlayer _soundPlayer;
    // Start is called before the first frame update
    void Awake()
    {
        GlobalSoundPlayer.SetSoundPlayer(_soundPlayer);
    }
}
