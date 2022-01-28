using Core.Global;
using Sound;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Button seButton;

    [SerializeField] private SoundPlayer _soundPlayer;
    // Start is called before the first frame update
    void Start()
    {
        _soundPlayer.PlayBGM(BgmType.Title);
        seButton.OnClickAsObservable().Subscribe(x => _soundPlayer.PlaySE(SeType.OK)).AddTo(this);
    }

}
