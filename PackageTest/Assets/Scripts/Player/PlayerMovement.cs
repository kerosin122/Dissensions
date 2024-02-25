using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private readonly int Idle = Animator.StringToHash(nameof(Idle));
    private readonly int Walk = Animator.StringToHash(nameof(Walk));

    [SerializeField] private float _speed = 1f;
    [SerializeField] private bool _isPaused = false;
    [SerializeField] private bool _isMoving = false;

    private bool _isIdle;
    private bool _isRinging;
    private Animator _animator;
    private Vector3 _targetPosition;

    private void Start() => _animator = GetComponent<Animator>();
    private void Update() => PlayerMove();

    public void Play() => ActionGame(false, 1f);
    public void Pause() => ActionGame(true, 0f);

    private void PlayerMove()
    {
        if (!_isPaused)
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
                transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

                StartCoroutine(CheckAnimationStop());
            }

            Vector3 direction = _targetPosition - transform.position;

            direction.Normalize();

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            PlayerRotation(direction);
            PlayerActions();

            SetPlayerAnimation();
        }
    }

    private void ActionGame(bool isPause, float actionTime)
    {
        _isPaused = isPause;
        Time.timeScale = actionTime;
    }

    private void PlayerRotation(Vector3 direction)
    {
        if (direction.x < 0)
            transform.rotation = Quaternion.Euler(0, 180f, 0);

        else if (direction.x > 0)
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    private void PlayerActions()
    {
        _isRinging = _isMoving;
        _isIdle = !_isMoving;
    }

    private void SetPlayerAnimation()
    {
        _animator.SetBool(Walk, _isRinging);
        _animator.SetBool(Idle, _isIdle);
    }

    private IEnumerator CheckAnimationStop()
    {
        Vector3 durationPosition = transform.position;

        yield return new WaitForSeconds(0.1f);

        if (transform.position == durationPosition)
            _isMoving = false;
    }
}