using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinGenerator : MonoBehaviour
{
    public float spd = 0.5f, time;
    public int width, height;
    Texture2D texture;

    void Start()
    {
        texture = new Texture2D(width, height);
        GetComponent<Renderer>().material.mainTexture = texture;
    }

    void Generator()
    {
        time += Time.deltaTime * spd;
        texture = new Texture2D(width, height);
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float sample = Mathf.PerlinNoise(x * 0.1f + time, y * 0.1f + time);
                texture.SetPixel(x, y, Color.HSVToRGB(sample, 1, 1));
            }
        }
        texture.Apply();
        GetComponent<Renderer>().material.mainTexture = texture;
    }

    void Update()
    {
        Generator();
    }
}
