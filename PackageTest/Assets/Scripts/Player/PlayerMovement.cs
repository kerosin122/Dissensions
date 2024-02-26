using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
<<<<<<< HEAD
    private readonly int Idle = Animator.StringToHash(nameof(Idle));
    private readonly int Walk = Animator.StringToHash(nameof(Walk));
=======
    private const string Idle = "Idle";
    private const string Walk = "Walk";
>>>>>>> 59f1b752b32e3957ccc25e3a670a5f351afbea85

    [SerializeField] private float _speed = 1f;
    [SerializeField] private bool _isPaused = false;
    [SerializeField] private bool _isMoving = false;

    private bool _isIdle;
    private bool _isRinging;
    private Animator _animator;
    private Vector3 _targetPosition;

    private void Start() => _animator = GetComponent<Animator>();
<<<<<<< HEAD
    private void Update() => PlayerMove();
=======
    private void Update() => Move();
>>>>>>> 59f1b752b32e3957ccc25e3a670a5f351afbea85

    public void Play() => ActionGame(false, 1f);
    public void Pause() => ActionGame(true, 0f);

<<<<<<< HEAD
    private void PlayerMove()
=======
    private void Move()
>>>>>>> 59f1b752b32e3957ccc25e3a670a5f351afbea85
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
<<<<<<< HEAD
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
=======

            if (_isMoving)
            {
                _isRinging = true;
                _isIdle = false;
            }

            else
            {
                _isRinging = false;
                _isIdle = true;
            }

            _animator.SetBool(Walk, _isRinging);
            _animator.SetBool(Idle, _isIdle);
        }
    }

    private void PlayerRotation(Vector3 direction)
    {
        if (direction.x < 0)
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
>>>>>>> 59f1b752b32e3957ccc25e3a670a5f351afbea85

        else if (direction.x > 0)
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

<<<<<<< HEAD
    private void PlayerActions()
    {
        _isRinging = _isMoving;
        _isIdle = !_isMoving;
    }

    private void SetPlayerAnimation()
    {
        _animator.SetBool(Walk, _isRinging);
        _animator.SetBool(Idle, _isIdle);
=======
    private void ActionGame(bool isPause, float time)
    {
        _isPaused = isPause;
        Time.timeScale = time;
>>>>>>> 59f1b752b32e3957ccc25e3a670a5f351afbea85
    }

    private IEnumerator CheckAnimationStop()
    {
<<<<<<< HEAD
        Vector3 durationPosition = transform.position;

        yield return new WaitForSeconds(0.1f);

        if (transform.position == durationPosition)
=======
        Vector3 setPosition = transform.position;

        yield return new WaitForSeconds(0.1f);

        if (transform.position == setPosition)
>>>>>>> 59f1b752b32e3957ccc25e3a670a5f351afbea85
            _isMoving = false;
    }
}