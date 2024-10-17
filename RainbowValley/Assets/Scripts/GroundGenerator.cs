using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public int[,] grid;
    public MeshRenderer groundPref, obstaclePref;
    public Color green, darkerGreen;

    private void Start()
    {
        Generate();
    }

    void Generate()
    {
        grid = new int[80, 5];

        for (int i = 0; i < 80; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Vector3 pos = new(i, 0, j);
                MeshRenderer map = Instantiate(groundPref, pos, Quaternion.identity);

                if ((i + j) % 2 == 0)
                {
                    map.material.color = green;
                    grid[i, j] = 1;
                }
                else
                {
                    map.material.color = darkerGreen;
                    grid[i, j] = 0;
                }

                if (Random.Range(0, 100) < 6.5f)
                {
                    MeshRenderer obstacle = Instantiate(obstaclePref, pos + Vector3.up * Random.Range(0.5f, 0.7f), Quaternion.identity);
                    obstacle.material.color = Random.ColorHSV(0, 1, 0.5f, 1, 0.5f, 1);
                }
            }
        }
    }
}
