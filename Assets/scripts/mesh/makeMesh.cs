using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class makeMesh
{
    public static MeshData generateMesh(float[,] heightmap)
    {
        int width = heightmap.GetLength(0);
        int height = heightmap.GetLength(1);
        float topLeftX = (width - 1) / -2;
        float topLeftY = (height - 1) / 2;

        MeshData meshData = new MeshData(width, height);
        int vertexIndex = 0;

        for (int y = 0; y < heightmap.GetLength(1); y++)
        {
            for (int x = 0; x < heightmap.GetLength(0); x++)
            {
                meshData.vertices[vertexIndex] = new Vector3(x + topLeftX, heightmap[x, y], y - topLeftY);
                meshData.uvs[vertexIndex] = new Vector2(x / (float)width, y / (float)height);

                if (x < width - 1 && y < height - 1)
                {
                    meshData.addTriangel(vertexIndex, vertexIndex + width + 1, vertexIndex + width);
                    meshData.addTriangel(vertexIndex + width + 1, vertexIndex, vertexIndex + 1);
                }

                vertexIndex++;
            }
        }
        return meshData;
    }
}

public class MeshData
{
    public Vector3[] vertices;
    public Vector2[] uvs;
    public int[] triangels;

    int triangelIndex;

    public MeshData(int meshWidth, int meshHeight)
    {
        vertices = new Vector3[meshWidth * meshHeight];
        uvs = new Vector2[meshWidth * meshHeight];
        triangels = new int[(meshWidth - 1) * (meshHeight - 1) * 6];
    }

    public void addTriangel(int a, int b, int c)
    {
        triangels[triangelIndex] = a;
        triangels[triangelIndex + 1] = b;
        triangels[triangelIndex + 2] = c;
        triangelIndex += 3;
    }

    public Mesh createMesh()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = triangels;
        mesh.RecalculateNormals();
        return mesh;
    }
}
