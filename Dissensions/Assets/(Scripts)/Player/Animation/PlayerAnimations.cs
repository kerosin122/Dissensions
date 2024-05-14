//using UnityEngine;

//public class PlayerAnimation : MonoBehaviour
//{
//    [SerializeField] private Transform _waypoint;
//    [SerializeField] private float _moveSpeed;
//    [SerializeField] private float _currentTimeOnPath, _time;

//    private Animator _animator;
//    private string[] _animations;
//    private Vector2 _initialPosition;

//    private void Start()
//    {
//        _animator = GetComponent<Animator>();

//        _initialPosition = transform.position;
//        _animations = new string[] { "attack", "jump", "shoot", "dying", "run", "attack2" };
//    }

//    private void Update()
//    {
//        _time += Time.deltaTime;

//        if (_time < 43)
//            Walk();

//        else
//        {
//            if (_time >= 53)
//            {
//                _animator.Play(_animations[Random.Range(0, _animations.Length - 1)]);
//                _time = 50;
//            }
//        }
//    }

//    private void Look(Vector2 direction)
//    {
//        if (direction.x > transform.position.x)
//            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);

//        else if (direction.x < transform.position.x)
//            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
//    }

//    private void Walk()
//    {
//        _animator.Play("walk");

//        Vector3 startPosition = _initialPosition;
//        Vector3 endPosition = _waypoint.transform.GetChild(0).transform.position;

//        float pathLength = Vector3.Distance(startPosition, endPosition);
//        float totalTimeForPath = pathLength / _moveSpeed;

//        _currentTimeOnPath += 1 * Time.deltaTime;
//        gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, _currentTimeOnPath / totalTimeForPath);

//        if (gameObject.transform.position.Equals(endPosition))
//        {
//            _initialPosition = transform.position;
//            _waypoint = _waypoint.transform.GetChild(0);
//            _currentTimeOnPath = 0;

//            Look(_waypoint.transform.GetChild(0).position);
//        }
//    }
//}