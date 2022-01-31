
using System;
using Core.PlayerInput;
using UnityEngine;
using UnityEngine.UI;

public class UIInputView : MonoBehaviour, IPlayerInput
{
    [SerializeField] private HoldableButton leftButton;
    [SerializeField] private HoldableButton rightButton;

    private bool isAction = false;
    private bool isChange = false;

    public int MoveDirection
    {
        get
        {
            return leftButton.IsHold ? -1 : rightButton.IsHold ? 1 : 0;
        }
    }

    public void Action()
    {
        isAction = true;
    }

    public void Change()
    {
        isChange = true;
    }

    private void LateUpdate()
    {
        isAction = false;
        isChange = false;
    }

    public bool IsAction => isAction;
    public bool IsChangeStance => isChange;
}
