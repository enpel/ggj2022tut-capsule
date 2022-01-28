using Core.Sound;
using Sound;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Button seButton;
    // Start is called before the first frame update
    void Start()
    {
        GlobalSoundPlayer.PlayBGM(BgmType.Title);
        seButton.OnClickAsObservable().Subscribe(x => GlobalSoundPlayer.PlaySE(SeType.OK)).AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
