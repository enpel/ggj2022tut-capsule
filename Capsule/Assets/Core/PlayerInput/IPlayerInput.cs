using UnityEngine;

namespace Core.PlayerInput
{
    public interface IPlayerInput
    {
        int MoveDirection { get; }
        bool IsAction { get; }
        bool IsChangeStance { get; }
    }

    public class StandardPlayerInput:IPlayerInput
    {
        public int MoveDirection
        {
            get
            {
                return Input.GetKey(KeyCode.D) ? 1 : Input.GetKey(KeyCode.A) ? -1 : 0;
            }
        }

        public bool IsAction => Input.GetMouseButtonDown(0);
        public bool IsChangeStance => Input.GetMouseButtonDown(1);
    }
}
