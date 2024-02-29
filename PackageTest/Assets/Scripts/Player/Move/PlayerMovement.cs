using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private readonly int Idle = Animator.StringToHash(nameof(Idle));
    private readonly int Walk = Animator.StringToHash(nameof(Walk));

    [SerializeField] private float _speed = 1f;
    [SerializeField] private bool _isMoving = false;

    private Animator _animator;
    private Vector3 _targetPosition;

    private void Start() => _animator = GetComponent<Animator>();
    private void Update() => PlayerMove();

    private void PlayerMove()
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
        SetPlayerAnimation();
    }

    private void PlayerRotation(Vector3 direction)
    {
        if (direction.x < 0)
            transform.rotation = Quaternion.Euler(0, 180f, 0);

        else if (direction.x > 0)
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    private void SetPlayerAnimation()
    {
        _animator.SetBool(Walk, _isMoving);
        _animator.SetBool(Idle, !_isMoving);
    }

    private IEnumerator CheckAnimationStop()
    {
        Vector3 durationPosition = transform.position;

        yield return new WaitForSeconds(0.1f);

        if (transform.position == durationPosition)
            _isMoving = false;
    }
}