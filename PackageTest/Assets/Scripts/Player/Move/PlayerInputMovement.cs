using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace ScriptsPlayer
{
    public class PlayerInputMovement : MonoBehaviour
    {
        public UnityEvent OnMoving = new();

        private void Update() => InputMovement();

        private void InputMovement()
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