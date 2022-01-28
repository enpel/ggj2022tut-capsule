
using System;
using Sound;
using Sound.Core;
using UnityEngine;

public static class GlobalSoundPlayer
{
    static private ISoundPlayer _soundPlayer;
    public static void SetSoundPlayer(ISoundPlayer soundPlayer)
    {
        _soundPlayer = soundPlayer;
    }

    public static void PlayBGM(BgmType type)
    {
        _soundPlayer?.PlayBGM(type);
    }

    public static void PlaySE(SeType type)
    {
        _soundPlayer?.PlaySE(type);
    }
}

public interface ISoundPlayer
{
    public void PlayBGM(BgmType type);
    public void PlaySE(SeType type);
}

public class SoundPlayer:MonoBehaviour, ISoundPlayer
{
    [SerializeField] private SoundDataList _soundDataList;

    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource seSource;

    public void PlayBGM(BgmType type)
    {
        {
            var clip = _soundDataList.GetBgmAudioClip(type); 
            if (clip == null) return;
            
            bgmSource.PlayOneShot(clip);
        }
    }

    public void PlaySE(SeType type)
    {
        var clip = _soundDataList.GetSeAudioClip(type);
        if (clip == null) return;
        
        seSource.PlayOneShot(clip);
    }
}
