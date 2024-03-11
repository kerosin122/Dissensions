using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    public Transform objectPrefab;
    public Vector2 areaSize;
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;
    public int minPrefabCount;
    public int maxPrefabCount;



    /// <summary>
    /// ///////
    /// </summary>



    public void Start()
    {
        int randomCount = Random.Range(minPrefabCount, maxPrefabCount + 1);

        for (int i = 0; i < randomCount; i++)
            PlaceObject();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            PlaceObject();
    }

    private void PlaceObject()
    {
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector3 randomPosition = new Vector3(randomX, randomY, 0);
        Instantiate(objectPrefab, randomPosition, Quaternion.identity);
    }

    public void OnDrawosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(areaSize.x, areaSize.y, 0));

        Gizmos.color = Color.red;
        Vector3 spawnAreaCenter = new Vector3((spawnAreaMin.x + spawnAreaMax.x) / 2, (spawnAreaMin.y + spawnAreaMax.y) / 2, 0);
        Vector3 spawnAreaSize = new Vector3(spawnAreaMax.x - spawnAreaMin.x, spawnAreaMax.y - spawnAreaMin.y, 0);
        Gizmos.DrawWireCube(spawnAreaCenter, spawnAreaSize);
    }
















}