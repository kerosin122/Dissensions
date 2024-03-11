using UnityEngine;

namespace ScriptsPlayer
{
    public class ObjectPlacer : MonoBehaviour
    {
        [SerializeField] private Transform _objectPrefab;

        private Vector2 _areaSize;
        private Vector2 _spawnAreaMin;
        private Vector2 _spawnAreaMax;

        private int _minPrefabCount;
        private int _maxPrefabCount;

        private void Start()
        {
            int randomCount = Random.Range(_minPrefabCount, _maxPrefabCount + 1);

            for (int i = 0; i < randomCount; i++)
                PlaceObject();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
                PlaceObject();
        }

        private void PlaceObject()
        {
            float randomX = Random.Range(_spawnAreaMin.x, _spawnAreaMax.x);
            float randomY = Random.Range(_spawnAreaMin.y, _spawnAreaMax.y);

            Vector3 randomPosition = new Vector3(randomX, randomY, 0);

            Instantiate(_objectPrefab, randomPosition, Quaternion.identity);
        }

        private void OnDrawSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, new Vector3(_areaSize.x, _areaSize.y, 0));
            Gizmos.color = Color.red;

            Vector3 spawnAreaCenter = new Vector3((_spawnAreaMin.x + _spawnAreaMax.x) / 2, (_spawnAreaMin.y + _spawnAreaMax.y) / 2, 0);
            Vector3 spawnAreaSize = new Vector3(_spawnAreaMax.x - _spawnAreaMin.x, _spawnAreaMax.y - _spawnAreaMin.y, 0);

            Gizmos.DrawWireCube(spawnAreaCenter, spawnAreaSize);
        }
    }
}