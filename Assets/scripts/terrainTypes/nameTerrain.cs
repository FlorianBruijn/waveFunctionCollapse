using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public static class nameTerrain
{
    public static int[,] setTerrain(float[,] heightmap)
    {
        int width = heightmap.GetLength(0);
        int height = heightmap.GetLength(1);

        int[,] toReturn = new int[width,height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                switch (heightmap[x, y])
                {
                    case float n when(n<0.16):
                        toReturn[x, y] = -1;
                        break;
                    case float n when (n < 0.30):
                        toReturn[x, y] = 0;
                        break;
                    case float n when (n < 0.60):
                        toReturn[x, y] = 1;
                        break;
                    case float n when (n < 0.70):
                        toReturn[x, y] = 2;
                        break;
                    case float n when (n < 0.80):
                        toReturn[x, y] = 3;
                        break;
                    case float n when (n < 0.90):
                        toReturn[x, y] = 4;
                        break;
                    case float n when (n < 1):
                        toReturn[x, y] = 5;
                        break;
                }
                Debug.Log(toReturn[x, y]);
            }
        }
        return toReturn;
    }
}
