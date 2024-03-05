using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace ScriptsPlayer
{
    public class PlayerInputMovement : MonoBehaviour
    {
        public UnityEvent OnMoving = new();

        private void Update() => InputMove();

        private void InputMove()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                    return;

                OnMoving?.Invoke();
            }
        }
    }
}