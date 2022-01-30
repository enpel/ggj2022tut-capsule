using ScriptableObject;
using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "ゲームデータ/ステージデータ", order = 2)]
public class StageListData : UnityEngine.ScriptableObject
{
    public StageData[] Stages;
}
