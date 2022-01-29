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
        // Start is called before the first frame update
        async void Start()
        {
            Global.SoundPlayer.PlayBGM(BgmType.PreInGame);

            await UniTask.Delay(TimeSpan.FromSeconds(3.0f));
            
            await SceneManager.LoadSceneAsync(Global.CurrentStageData.StageScene);
        }

    }
}
