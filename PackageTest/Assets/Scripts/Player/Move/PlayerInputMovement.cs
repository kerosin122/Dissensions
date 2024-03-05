using UnityEngine;
using UnityEngine.EventSystems;

namespace ScriptsPlayer
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerInputMovement : MonoBehaviour
    {
        private PlayerMovement _playerMovement;

        private void Start() => _playerMovement = GetComponent<PlayerMovement>();
        private void Update() => InputMove();

        private void InputMove()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                    return;

                _playerMovement.IsMoving = true;
                _playerMovement.TargetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
    }
}