using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSetting : MonoBehaviour
{
    private AudioSource audioSource;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void SoundSliderOnValueChange(float newSliderValu)
    {
        audioSource.volume = newSliderValu;
    }
}
