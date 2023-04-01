using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    public Texture2D map;
    public ColorToPrefab[] colorMap;
    public float offset = 5f;
    public Material material01;
    public Material material02;


    void Start() {

    }

    void GenerateTile(int x, int z) {
        Color pixelColor = map.GetPixel(x, z);

        if (pixelColor.a == 0) {
            return;
        }

        foreach (ColorToPrefab colorToPrefab in colorMap) {
            if (colorToPrefab.color == pixelColor) {
                Vector3 positionToSpawn = new Vector3(x, 0, z) * offset;
                GameObject tile = Instantiate(colorToPrefab.prefab, positionToSpawn, Quaternion.identity, transform);
                tile.transform.localPosition = positionToSpawn;

                if (tile.tag == "Wall") {
                    tile.transform.localPosition += new Vector3(0, 2.5f, 0);
                }
            }
        }
    }

    public void GenerateLabirynth() {
        for (int x = 0; x < map.width; x++) {
            for (int y = 0; y < map.height; y++) {
                GenerateTile(x, y);
            }
        }

        ColorTheChildren();
    }

    public void ColorTheChildren() {
        foreach (Transform child in transform) {
            if (child.tag == "Wall") {
                if (Random.Range(1, 100) % 3 == 0)
                    child.gameObject.GetComponent<Renderer>().material = material02;
                else
                    child.gameObject.GetComponent<Renderer>().material = material01;
            }
        }
    }
}
