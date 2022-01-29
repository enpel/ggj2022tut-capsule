using ScriptableObject;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Test
{
    public class SelectTestSceneDirector : MonoBehaviour
    {
        [SerializeField] private StageData _stageData;

        public void Awake()
        {
            Debug.Log("select test stage");
            SceneManager.LoadScene(_stageData.StageScene);
        }
    }
}
