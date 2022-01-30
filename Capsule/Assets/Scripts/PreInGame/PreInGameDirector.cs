using System;
using Cinemachine;
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

        [SerializeField] private bool isDebug = false;

        [SerializeField] private GameObject playerPrefab;

        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        // Start is called before the first frame update
        async void Start()
        {
            Global.SoundPlayer.PlayBGM(BgmType.PreInGame);

            await UniTask.Delay(TimeSpan.FromSeconds(3.0f));
            
            if (!isDebug)
            await SceneManager.LoadSceneAsync(Global.CurrentStageData.StageScene, LoadSceneMode.Additive);
            
            GameObject.Destroy(preInGameSceneObject);

            var startPoint = GameObject.Find("Start");
            var player = GameObject.Instantiate(playerPrefab, startPoint.transform.position,
                startPoint.transform.rotation).GetComponent<Playercontrol>();
            virtualCamera.Follow = player.transform;
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
