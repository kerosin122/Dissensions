using UnityEngine;
using UnityEngine.EventSystems;

public class ClickEffect : MonoBehaviour
{
    private const float TimeDestroyObject = 1f;

    [SerializeField] private GameObject _effectPrefab;

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(0))
            ClickEffector(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    private void ClickEffector(Vector2 position)
    {
        GameObject gameObject = Instantiate(_effectPrefab, position, Quaternion.identity);
        Destroy(gameObject, TimeDestroyObject);
    }
}