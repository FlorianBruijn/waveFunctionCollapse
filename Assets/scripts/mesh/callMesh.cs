using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class callMesh : MonoBehaviour
{
    [Header("perlinSettings")]
    [SerializeField] private int Xlen;
    [SerializeField] private int Ylen;
    [SerializeField] private int seed;
    [SerializeField] private float scale;
    [SerializeField] private int octaves;
    [SerializeField] private float percistance;
    [SerializeField] private float lacunarity;
    [SerializeField] private float steepness;
    [Header("mesh references")]
    [SerializeField] private MeshFilter filter;
    [SerializeField] private MeshCollider collider;
    void Start()
    {
        //float[,] heightmap = waveFunction_v1.elevation(Xlen, Ylen, change);
        float[,] heightmap = perlinNiose.heightMap(Xlen, Ylen, seed, scale, octaves, percistance, lacunarity);
        int[,] terrainName = nameTerrain.setTerrain(heightmap);
        heightmap = biomeEditor.addMountains(heightmap, terrainName, steepness);
        MeshData meshData = makeMesh.generateMesh(heightmap);

        filter.sharedMesh = meshData.createMesh();
        collider.sharedMesh = meshData.createMesh();
    }

    void Update()
    {
        
    }
}
