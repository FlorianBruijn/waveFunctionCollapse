using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public static class perlinNiose
{
    public static float[,] heightMap(int width, int height, int seed)
    {
        Random.seed = seed;
        float[,] toReturn = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                toReturn[x, y] = Mathf.PerlinNoise(x * Random.value, y * Random.value);
            }
        }
        return toReturn;
    }
}
