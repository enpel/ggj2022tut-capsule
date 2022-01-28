using Core.Sound;
using Sound;
using Sound.Core;
using UnityEngine;


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
