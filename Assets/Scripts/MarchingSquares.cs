using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MarchingSquares : MonoBehaviour
{
    public Tile[] states;
    public Tilemap tileMap;

    public int xSize = 50;
    public int ySize = 50;
    public float speed = 0.01f;

    float noiseZ = 0;
    double count = 0;

    private void FixedUpdate()
    {
        tileMap.ClearAllTiles();
        int[,] values = new int[xSize, ySize];
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                //tileMap.SetTile(new Vector3Int(x - (size / 2), y - (size / 2), 0), states[Random.Range(0, states.Length)]);
                double noiseX;
                double noiseY;
                if(xSize > ySize)
                {
                    noiseX = (double)x / xSize;
                    noiseY = (double)y / xSize;
                }
                else
                {
                    noiseX = (double)x / ySize;
                    noiseY = (double)y / ySize;
                }
                

                values[x, y] = (int)Mathf.Floor((float)NoiseS3D.Noise(noiseX / .12f, noiseY / .12f, noiseZ) + 1);
                //values[x, y] = Mathf.FloorToInt(Random.Range(0f, 2f));
                //values[x, y] = Mathf.FloorToInt(Mathf.PerlinNoise((float)noiseX / .5f, (float)noiseY / .5f) * 2);
                
                
            }
        }
        count += speed;

        for (int x = 0; x < values.GetLength(0) - 1; x++)
        {
            for (int y = 0; y < values.GetLength(1) - 1; y++)
            {
                int curState = getState(values[x, y], values[x + 1, y], values[x + 1, y + 1], values[x, y + 1]);

                tileMap.SetTile(new Vector3Int(x - (xSize / 2), y - (ySize / 2), 0), states[curState]);
                
                
                
            }
        }
        noiseZ += speed;

        if(1 / Time.deltaTime != 25)
        {
            Application.targetFrameRate = 25;
        }
    }

    int getState(int a, int b, int c, int d)
    {
        return a * 1 + b * 2 + c * 4 + d * 8;
    }

    private void Start()
    {
        Application.targetFrameRate = 25;
    }

    
}
