using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace Core.Effect.Scripts
{
    public interface IEffectPlayer
    {
        void PlayEffect(EffectType effectType);
        
        void PlayEffect(EffectType effectType, Vector3 worldPosition);
        void PlayEffect(EffectType effectType, Vector3 worldPosition, Quaternion rotation);
        void PlayEffect(EffectType effectType, Vector3 localPosition, Transform parent);
        void PlayEffect(EffectType effectType, Vector3 localPosition, Quaternion rotation, Transform parent);
    }
}