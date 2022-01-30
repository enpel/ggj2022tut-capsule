
using UnityEngine;

public class AirGaugeView : MonoBehaviour
{
    [SerializeField] private GameObject[] AirIcons;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var airIcon in AirIcons)
        {
            airIcon.SetActive(false);
        }
    }

    public void SetValue(int value)
    {
        for (int i= 0; i < AirIcons.Length; i++)
        {
            AirIcons[i].SetActive(i < value);
        }
    }
}
