using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace ScriptsPlayer
{
    public class PlayerInputMovement : MonoBehaviour
    {
        public UnityEvent OnMoving = new();

        private PlayerMovement _playerMovement;

        private void OnValidate() => _playerMovement = GetComponent<PlayerMovement>();

        private void Start() => _playerMovement ??= GetComponent<PlayerMovement>();

        private void Update() => InputMovement();

        private void InputMovement()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                    return;

                OnMoving?.Invoke();
            }

            else if (Input.GetMouseButtonDown(1))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                    return;

                _playerMovement.IsMoving = false;
            }
        }
    }
}