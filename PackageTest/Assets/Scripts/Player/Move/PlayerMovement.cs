using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerMovement : MonoBehaviour
    {
        private readonly int Idle = Animator.StringToHash(nameof(Idle));
        private readonly int Walk = Animator.StringToHash(nameof(Walk));

        private const float AnimationCheckDelay = 0.1f;

        [SerializeField, Range(1f, 5f)] private float _speedWalking = 1f;

        private bool _isMoving = false;
        private Animator _animator;
        private Vector3 _targetPosition;

        private void Start() => _animator = GetComponent<Animator>();
        private void Update() => PlayerMover();

        private void PlayerMover()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                    return;

                _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _isMoving = true;
            }

            if (_isMoving)
            {
                transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _speedWalking * Time.deltaTime);
                StartCoroutine(CheckAnimationStop());
            }

            Vector3 direction = _targetPosition - transform.position;

            direction.Normalize();
            PlayerRotation(direction);
            SetPlayerAnimation();
        }

        private void PlayerRotation(Vector3 direction)
        {
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