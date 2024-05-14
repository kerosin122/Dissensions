﻿using UnityEngine;
using MapGenerator.UnityPort;

public class LayerOrderSetter : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private MapGeneratorTool mapGeneratorTool;

    private void Start()
    {
        mapGeneratorTool = FindObjectOfType<MapGeneratorTool>();
        spriteRenderer.sortingOrder = (int)(mapGeneratorTool.height - transform.position.z);
    }
}
