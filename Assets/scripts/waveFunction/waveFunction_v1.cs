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
        for (int i = 0; i < xLenght; i++)
        {
            for (int j = 0; j < yLenght; j++)
            {
                switch (i)
                {
                    case 0:
                        switch (j)
                        {
                            case 0:
                                toReturn[i,j] = Random.Range(0,10);
                                break;
                            case int m when(m > 0):
                                toReturn[i, j] = Random.Range(toReturn[i, j - 1] - change, toReturn[i, j - 1] - change);
                                break;
                        }
                        break;
                    case int n when (n > 1):
                        switch (j)
                        {
                            case 0:
                                toReturn[i, j] = Random.Range((toReturn[i - 1, j] + toReturn[i - 1, j + 1]) / 2 - change, (toReturn[i - 1, j] + toReturn[i - 1, j + 1]) / 2 + change);
                                break;
                            case int m when (m > 0 && m < yLenght - 1):
                                toReturn[i, j] = Random.Range((toReturn[i - 1, j] + toReturn[i - 1, j + 1] + toReturn[i, j - 1] + toReturn[i - 1, j - 1]) / 4 - change, (toReturn[i - 1, j] + toReturn[i - 1, j + 1] + toReturn[i, j - 1] + toReturn[i - 1, j - 1]) / 4 + change);
                                break;
                            case int m when (m == yLenght):
                                toReturn[i, j] = Random.Range((toReturn[i - 1, j] + toReturn[i, j - 1] + toReturn[i - 1, j - 1]) / 3 - change, (toReturn[i - 1, j] + toReturn[i, j - 1] + toReturn[i - 1, j - 1]) / 3 + change);
                                break;
                        }
                        break;
                }
            }
        }
        foreach (int i in toReturn)
        {
            Debug.Log(i);
        }
        return toReturn;
    }
}