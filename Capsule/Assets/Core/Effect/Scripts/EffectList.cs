using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class EffectData
{
    public EffectType effectType;
    public GameObject effectPrefab;

}

public interface IEffectList
{
    GameObject GetEffectPrefab(EffectType type);
}

public class EffectList : MonoBehaviour, IEffectList
{
    public EffectData[] EffectData;

    public GameObject GetEffectPrefab(EffectType type)
    {
        var data =  EffectData.FirstOrDefault(x => x.effectType == type);
        if (data == null || data.effectPrefab == null) return null;

        return data.effectPrefab;
    }
}
