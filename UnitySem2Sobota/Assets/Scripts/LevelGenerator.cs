using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] colorMap;
    public float offset = 5f;


    void Start()
    {
        
    }

    void GenerateTile(int x, int z) {
        Color pixelColor = map.GetPixel(x,z);

        if (pixelColor.a == 0) {
            return;
        }

        foreach (ColorToPrefab colorToPrefab in colorMap) {
            if (colorToPrefab.color == pixelColor) {
                Vector3 positionToSpawn = new Vector3(x, 0, z) * offset;
                Instantiate(colorToPrefab.prefab, positionToSpawn, Quaternion.identity, transform);
            }
        }

    }
}
