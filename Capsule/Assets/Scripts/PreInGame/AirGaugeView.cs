
using UnityEngine;

public class AirGaugeView : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image[] AirIcons;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var airIcon in AirIcons)
        {
            airIcon.fillAmount = 0;
        }
    }

    public void SetValue(int value)
    {
        for (int i= 0; i < AirIcons.Length; i++)
        {
            AirIcons[i].fillAmount = i < value ? 1 : 0;
        }
    }
}
