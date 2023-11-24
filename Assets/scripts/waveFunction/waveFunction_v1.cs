using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public static class waveFunction_v1
{
    
    public static float[,] elevation(int xLenght, int yLenght, float change) 
    {
        float[,] toReturn = new float[xLenght,yLenght];
        for (int x = 0; x < xLenght; x++)
        {
            for (int y = 0; y < yLenght; y++)
            {
                switch (x)
                {
                    case 0:
                        switch (y)
                        {
                            case 0:
                                toReturn[x,y] = Random.Range(0,10);
                                break;
                            case int m when(m > 0):
                                toReturn[x, y] = Random.Range(toReturn[x, y - 1] - change, toReturn[x, y - 1] - change);
                                break;
                        }
                        break;
                    case int n when (n > 1):
                        switch (y)
                        {
                            case 0:
                                toReturn[x, y] = Random.Range((toReturn[x - 1, y] + toReturn[x - 1, y + 1]) / 2 - change, (toReturn[x - 1, y] + toReturn[x - 1, y + 1]) / 2 + change);
                                break;
                            case int m when (m > 0 && m < yLenght - 1):
                                toReturn[x, y] = Random.Range((toReturn[x - 1, y] + toReturn[x - 1, y + 1] + toReturn[x, y - 1] + toReturn[x - 1, y - 1]) / 4 - change, (toReturn[x - 1, y] + toReturn[x - 1, y + 1] + toReturn[x, y - 1] + toReturn[x - 1, y - 1]) / 4 + change);
                                break;
                            case int m when (m == yLenght):
                                toReturn[x, y] = Random.Range((toReturn[x - 1, y] + toReturn[x, y - 1] + toReturn[x - 1, y - 1]) / 3 - change, (toReturn[x - 1, y] + toReturn[x, y - 1] + toReturn[x - 1, y - 1]) / 3 + change);
                                break;
                        }
                        break;
                }
            }
        }
        Debug.Log(yLenght * xLenght + "should" + toReturn.Length + "is");
        return toReturn;
    }
}