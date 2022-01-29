using UnityEngine;

namespace ScriptableObject
{
    [CreateAssetMenu(fileName = "LevelDesigner", menuName = "ゲームデータ/レベルデザイナーデータ", order = 2)]
    public class LevelDesignerData : UnityEngine.ScriptableObject
    {
        [SerializeField] private string 名前;
        [SerializeField] private Texture2D アイコン;

        public string Name => 名前;
        public Texture2D IconTexture => アイコン;
    }
}