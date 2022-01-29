using System;
using Core.Global;
using Cysharp.Threading.Tasks;
using Sound;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PreInGame
{
    public class PreInGameDirector : MonoBehaviour
    {
        [SerializeField] private GameObject preInGameSceneObject;

        [SerializeField] private InGameUiController inGameUiController;
        // Start is called before the first frame update
        async void Start()
        {
            Global.SoundPlayer.PlayBGM(BgmType.PreInGame);

            await UniTask.Delay(TimeSpan.FromSeconds(3.0f));
            
            await SceneManager.LoadSceneAsync(Global.CurrentStageData.StageScene, LoadSceneMode.Additive);
            
            GameObject.Destroy(preInGameSceneObject);

            var player = GameObject.Find("Player").GetComponent<Playercontrol>();
            Observable.EveryUpdate().Select(x => player.airGage)
                .DistinctUntilChanged()
                .SubscribeOnMainThread()
                .Subscribe(x =>
                {
                    inGameUiController.SetAirValue(x);
                }).AddTo(this);
        }

    }
}
