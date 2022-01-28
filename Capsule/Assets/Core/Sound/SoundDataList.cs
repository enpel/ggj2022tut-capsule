using System;
using System.Collections.Generic;
using System.Linq;
using Sound.Core.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sound.Core
{
    [Serializable]
    public class BgmData
    {
        [FormerlySerializedAs("BgmType")] public BgmType bgmType;
        [FormerlySerializedAs("AudioClip")] public AudioClip audioClip;
    }

    [Serializable]
    public class SeData
    {
        [FormerlySerializedAs("BgmType")] public SeType seType;
        [FormerlySerializedAs("AudioClip")] public AudioClip audioClip;
    }

    public class SoundDataList : MonoBehaviour, ISoundDataList
    {
        [SerializeField]
        private BgmData[] bgmData;
        
        [SerializeField]
        private SeData[] seData;


        public AudioClip GetBgmAudioClip(BgmType type)
        {
            var data = bgmData.FirstOrDefault(x => x.bgmType == type);
            if (data == null || data.audioClip == null) return null;

            return data.audioClip;
        }

        public AudioClip GetSeAudioClip(SeType type)
        {
            var data = seData.FirstOrDefault(x => x.seType == type);
            if (data == null || data.audioClip == null) return null;

            return data.audioClip;
        }
    }
}
