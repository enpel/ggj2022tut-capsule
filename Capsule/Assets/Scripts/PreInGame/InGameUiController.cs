using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUiController : MonoBehaviour
{
    [SerializeField] private AirGaugeView _airGaugeView;

    public void SetAirValue(int value)
    {
        _airGaugeView.SetValue(value);
    }
}
