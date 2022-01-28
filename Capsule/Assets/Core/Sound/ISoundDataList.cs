using System.Collections.Generic;
using UnityEngine;

namespace Sound.Core.Interfaces
{
    public interface ISoundDataList
    {
        AudioClip GetBgmAudioClip(BgmType type);
        AudioClip GetSeAudioClip(SeType type);
    }
}
