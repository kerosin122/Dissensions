using UnityEngine;
using System.Collections;

namespace ScriptsPlayer
{
    [RequireComponent(typeof(Animator))]
    public class PlayerMovement : MonoBehaviour
    {
        private readonly int Idle = Animator.StringToHash(nameof(Idle));
        private readonly int Walk = Animator.StringToHash(nameof(Walk));

        private const float AnimationCheckDelay = 0.1f;

        [SerializeField, Range(1f, 5f)] private float _speedWalking = 1f;

        public bool IsMoving
        {
            get { return _isMoving; }
            set { _isMoving = value; }
        }

        public Vector3 TargetPosition
        {
            get { return _targetPosition; }
            set { _targetPosition = value; }
        }

        private bool _isMoving;
        private Animator _animator;
        private Vector3 _targetPosition;

        private void Start() => _animator = GetComponent<Animator>();

        private void Update()
        {
            Move();
            Rotation();
            SetPlayerAnimation();
        }

        private void Move()
        {
            if (_isMoving)
            {
                transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _speedWalking * Time.deltaTime);
                StartCoroutine(CheckAnimationStop());
            }
        }

        private void Rotation()
        {
            Vector3 direction = _targetPosition - transform.position;
            direction.Normalize();

            if (direction.x < 0f)
                transform.eulerAngles = new Vector2(0f, 180f);

            else if (direction.x > 0f)
                transform.eulerAngles = new Vector2(0f, 0f);
        }

        private void SetPlayerAnimation()
        {
            _animator.SetBool(Walk, _isMoving);
            _animator.SetBool(Idle, !_isMoving);
        }

        private IEnumerator CheckAnimationStop()
        {
            Vector3 durationPosition = transform.position;

            yield return new WaitForSeconds(AnimationCheckDelay);

            if (transform.position == durationPosition)
                _isMoving = false;
        }
    }
}