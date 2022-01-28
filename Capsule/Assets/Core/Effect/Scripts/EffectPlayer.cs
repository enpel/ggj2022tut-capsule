using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace Core.Effect.Scripts
{
    public class EffectPlayer : MonoBehaviour, IEffectPlayer
    {
        [SerializeField] private EffectList _effectList;

        public void PlayEffect(EffectType effectType)
        {
            PlayEffect(effectType, Vector3.zero, Quaternion.identity);
        }

        public void PlayEffect(EffectType effectType, Vector3 worldPosition)
        {
            PlayEffect(effectType, worldPosition, Quaternion.identity);
        }

        public void PlayEffect(EffectType effectType, Vector3 worldPosition, Quaternion rotation)
        {
            var effectPrefab = _effectList.GetEffectPrefab(effectType);
            if (effectPrefab == null) return;

            Instantiate(effectPrefab, worldPosition, rotation);
        }

        public void PlayEffect(EffectType effectType, Vector3 localPosition, Transform parent)
        {
            PlayEffect(effectType, localPosition, Quaternion.identity, parent);
        }

        public void PlayEffect(EffectType effectType, Vector3 localPosition, Quaternion rotation, Transform parent)
        {
            
            var effectPrefab = _effectList.GetEffectPrefab(effectType);
            if (effectPrefab == null) return;

            var instance = Instantiate(effectPrefab, Vector3.zero, rotation, parent);
            instance.transform.localPosition = localPosition;
        }
    }
}
