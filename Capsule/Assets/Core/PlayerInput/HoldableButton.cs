using UnityEngine;

public class HoldableButton : MonoBehaviour
{
    private bool isHold = false;
    public bool IsHold => isHold;

    public void ButtonDown()
    {
        isHold = true;
    }

    public void ButtonUp()
    {
        isHold = false;
    }
}
