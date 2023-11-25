using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class biomeEditor
{
    public static float[,] addMountains(float[,] oldHeight, int[,] levelmap, float steepness)
    {
        int width = oldHeight.GetLength(0);
        int height = oldHeight.GetLength(1);

        float[,] toReturn = new float[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                switch(levelmap[x, y])
                {
                    case 2:
                        toReturn[x,y] = oldHeight[x, y] * steepness;
                        break;
                    case 3:
                        toReturn[x, y] = oldHeight[x, y] * steepness * 2;
                        break;
                    case 4:
                        toReturn[x, y] = oldHeight[x, y] * steepness * 3;
                        break;
                    case 5:
                        toReturn[x, y] = oldHeight[x, y] * steepness * 4;
                        break;
                }
            }
        }

        return toReturn;
    }
}