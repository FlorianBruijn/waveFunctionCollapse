using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callMesh : MonoBehaviour
{
    [SerializeField] private int Xlen;
    [SerializeField] private int Ylen;
    [SerializeField] private MeshFilter filter;
    [SerializeField] private float change;
    void Start()
    {
        float[,] heightmap = waveFunction_v1.elevation(Xlen, Ylen, change);
        MeshData meshData = makeMesh.generateMesh(heightmap);

        filter.sharedMesh = meshData.createMesh();
    }

    void Update()
    {
        
    }
}
