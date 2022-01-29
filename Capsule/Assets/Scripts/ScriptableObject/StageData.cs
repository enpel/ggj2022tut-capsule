using UnityEngine;

namespace ScriptableObject
{
    [CreateAssetMenu(fileName = "StageData", menuName = "ゲームデータ/ステージデータ", order = 2)]
    public class StageData : UnityEngine.ScriptableObject
    {
        [SerializeField] private string ステージ名;
        [SerializeField] private LevelDesignerData レベルデザイナー;
        [SerializeField] private Texture2D サムネイル;
        [SerializeField] private SceneObject scene;

        public string StageName => ステージ名;
        public LevelDesignerData LevelDesigner => レベルデザイナー;
        public Texture2D StageThumbnail => サムネイル;
        public SceneObject StageScene => scene;

    }

}