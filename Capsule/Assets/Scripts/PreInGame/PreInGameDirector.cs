using System;
using Core.Global;
using Cysharp.Threading.Tasks;
using Sound;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PreInGame
{
    public class PreInGameDirector : MonoBehaviour
    {
        [SerializeField] private GameObject preInGameSceneObject;

        [SerializeField] private bool isDebug = false;

        // Start is called before the first frame update
        async void Start()
        {
            Global.SoundPlayer.PlayBGM(BgmType.PreInGame);
            preInGameSceneObject.SetActive(true);
            await UniTask.Delay(TimeSpan.FromSeconds(3.0f));
            
            await SceneManager.LoadSceneAsync("InGameSetup", LoadSceneMode.Additive);
            if (!isDebug) await SceneManager.LoadSceneAsync(Global.CurrentStageData.StageScene, LoadSceneMode.Additive);
            
            GameObject.FindObjectOfType<InGameDirector>().SetupInGame();
            preInGameSceneObject.SetActive(false);
            
            Global.SetCurrentStageData(Global.CurrentStageData);

        }

    }
}
