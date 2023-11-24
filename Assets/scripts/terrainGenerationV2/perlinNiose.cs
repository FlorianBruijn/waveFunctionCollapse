using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public static class perlinNiose
{
    public static float[,] heightMap(int width, int height, int seed, float scale, int octaves, float percistance, float lacunarity)
    {
        float[,] toReturn = new float[width, height];

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;
                for (int i = 0; i < octaves; i++)
                {
                    float sampleX = x / scale * frequency;
                    float sampleY = y / scale * frequency;

                    float prelinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    noiseHeight += prelinValue * amplitude;

                    amplitude *= percistance;
                    frequency *= lacunarity;
                }
                if(noiseHeight > maxNoiseHeight)
                {
                    maxNoiseHeight = noiseHeight;
                }
                else if (noiseHeight < minNoiseHeight)
                {
                    minNoiseHeight = noiseHeight;
                }
                toReturn[x, y] = noiseHeight;
            }
        }
        for (int x = 0; x < width; x++) 
        {
            for (int y = 0; y < height; y++)
            {
                toReturn[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, toReturn[x, y]);
            }
        }
        return toReturn;
    }
}
