using UnityEngine;

namespace ScriptsPlayer
{
    [RequireComponent(typeof(PlayerInputMovement))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerInputMovement _inputMovement;

        public bool IsMoving => _isMoving;

        [SerializeField, Range(1f, 5f)] private float _speedWalking = 1f;

        private bool _isMoving;
        private Vector3 _targetPosition;

        private void OnValidate() => _inputMovement = GetComponent<PlayerInputMovement>();

        private void Start()
        {
            _inputMovement ??= GetComponent<PlayerInputMovement>();
            _inputMovement.OnMoving.AddListener(PointCamera);
        }

        private void OnDestroy() => _inputMovement.OnMoving.RemoveListener(PointCamera);

        private void Update()
        {
            Move();
            Rotation();
        }

        private void Move()
        {
            var diffPosition = transform.position - _targetPosition;

            if (_isMoving && (Mathf.Abs(diffPosition.x) > 0.01f || Mathf.Abs(diffPosition.y) > 0.01f))
                transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _speedWalking * Time.deltaTime);

            else
                _isMoving = false;
        }

        private void Rotation()
        {
            Vector2 direction = (_targetPosition - transform.position).normalized;

            transform.eulerAngles = direction.x < 0f
                ? new Vector2(0f, 180f)
                : Vector2.zero;
        }

        private void PointCamera()
        {
            _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _isMoving = true;
        }
    }
}