using UnityEngine;

namespace ScriptsPlayer
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerAnimations : MonoBehaviour
    {
        private readonly int Walk = Animator.StringToHash(nameof(Walk));

        [SerializeField] private Animator _animator;
        [SerializeField] private PlayerMovement _movement;

        private void OnValidate()
        {
            _animator = GetComponent<Animator>();
            _movement = GetComponent<PlayerMovement>();
        }

        private void Start()
        {
            _animator ??= GetComponent<Animator>();
            _movement ??= GetComponent<PlayerMovement>();
        }

        private void Update() => SetPlayerAnimation();
        private void SetPlayerAnimation() => _animator.SetBool(Walk, _movement.IsMoving);
    }
}