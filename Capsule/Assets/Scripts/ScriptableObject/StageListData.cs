using ScriptableObject;
using UnityEngine;

[CreateAssetMenu(fileName = "StageListData", menuName = "ゲームデータ/ステージリスト", order = 2)]
public class StageListData : UnityEngine.ScriptableObject
{
    public StageData[] Stages;
}
