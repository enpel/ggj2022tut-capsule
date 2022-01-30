using System;
using Cinemachine;
using DG.Tweening;
using UniRx;
using UnityEngine;

public class InGameDirector : MonoBehaviour
{
    [SerializeField] private AirGaugeView _airGaugeView;

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private Playercontrol currentPlayer;
    private bool isSetuped = false;

    private void Start()
    {
        var startPoint = GameObject.Find("Start");
        if (startPoint != null) SetupInGame();
    }

    public void SetupInGame()
    {
        if (isSetuped)
        {
            Debug.LogWarning("セットアップ済みです");
            return;
        }
        var startPoint = GameObject.Find("Start");
        currentPlayer = GameObject.Instantiate(playerPrefab, startPoint.transform.position, startPoint.transform.rotation).GetComponent<Playercontrol>();
        virtualCamera.Follow = currentPlayer.transform;
        Observable.EveryUpdate().Where(x => currentPlayer !=null)
            .Select(x => currentPlayer.airGage)
            .DistinctUntilChanged()
            .SubscribeOnMainThread()
            .Subscribe(SetAirValue).AddTo(this);

        isSetuped = true;
    }

    private void SetAirValue(int value)
    {
        _airGaugeView.SetValue(value);
    }
}
