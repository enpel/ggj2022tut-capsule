using Core.Global;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PreInGame
{
    public class PreInGameDirector : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            SceneManager.LoadScene(Global.CurrentStageData.StageScene);
        }

    }
}
