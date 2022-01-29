using System;
using System.Linq;
using Core.Sound;
using Sound;
using Sound.Core;
using UnityEngine;
using UnityEngine.Audio;

public class SoundPlayer:MonoBehaviour, ISoundPlayer
{
    [SerializeField] private SoundDataList _soundDataList;

    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource seSource;

    [SerializeField] private AudioMixer _audioMixer;

    public void PlayBGM(BgmType type)
    {
        {
            var clip = _soundDataList.GetBgmAudioClip(type); 
            if (clip == null) return;
            
            bgmSource.PlayOneShot(clip);
        }
    }

    public void StopBGMAll()
    {
        bgmSource.Stop();
    }

    public void PlaySE(SeType type)
    {
        var clip = _soundDataList.GetSeAudioClip(type);
        if (clip == null) return;
        
        seSource.PlayOneShot(clip);
    }

    public void SetVolume(MixerType type, float volume)
    {
       _audioMixer.SetFloat(GetMixerVolumeParameterName(type), ConvertVolume2dB(volume));
       
    }

    public float GetVolume(MixerType type)
    {
        float volume;
        _audioMixer.GetFloat(GetMixerVolumeParameterName(type), out volume);

        return volume;
    }

    private string GetMixerVolumeParameterName(MixerType type)
    {
        switch (type)
        {
            case MixerType.Master:
                return "MasterVolume";
            case MixerType.Bgm:
                return "BgmVolume";
            case MixerType.Se:
                return "SeVolume";
            
        }

        return String.Empty;
    }
    
    float ConvertVolume2dB(float volume) => Mathf.Clamp(20f * Mathf.Log10(Mathf.Clamp(volume, 0f, 1f)), -80f, 0f);
}
