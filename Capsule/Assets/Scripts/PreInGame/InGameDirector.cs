using Cinemachine;
using UniRx;
using UnityEngine;

public class InGameDirector : MonoBehaviour
{
    [SerializeField] private AirGaugeView _airGaugeView;

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private Playercontrol currentPlayer;


    public void SetupInGame()
    {
        var startPoint = GameObject.Find("Start");
        currentPlayer = GameObject.Instantiate(playerPrefab, startPoint.transform.position, startPoint.transform.rotation).GetComponent<Playercontrol>();
        virtualCamera.Follow = currentPlayer.transform;
        Observable.EveryUpdate().Where(x => currentPlayer !=null)
            .Select(x => currentPlayer.airGage)
            .DistinctUntilChanged()
            .SubscribeOnMainThread()
            .Subscribe(SetAirValue).AddTo(this);
    }

    private void SetAirValue(int value)
    {
        _airGaugeView.SetValue(value);
    }
}
