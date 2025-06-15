using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ProceduralTerrain : MonoBehaviour
{
    private int width = 50;
    private int height = 50;
    private Vector3[] vertices;
    public float scale = 0.1f;
    public float amplitude = 5f;
    private int[] triangles;

    void Start()
    {
        vertices = new Vector3[width*height];
        for ( int i = 0; i < width; i++)
        {
            for ( int j = 0; j < height; j++)
            {
                vertices[i*width + j] = new Vector3(i, Mathf.PerlinNoise(i * scale, j * scale) * amplitude, j);
            }
        }
        CreateTriangles();

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }
    void CreateTriangles()
    {
        triangles = new int[(width - 1) * (height - 1) * 6];
        int triangleIndex = 0;
        for (int j = 0; j < width - 1; j++)
        {
            for (int i = 0; i < height - 1; i++)
            {
                triangles[triangleIndex] = i * width + j;
                triangles[triangleIndex + 1] = i * width + (j + 1);
                triangles[triangleIndex + 2] = (i + 1) * width + j;
                triangles[triangleIndex + 3] = (i + 1) * width + j;
                triangles[triangleIndex + 4] = i * width + (j + 1);
                triangles[triangleIndex + 5] = (i + 1) * width + (j + 1);
                triangleIndex += 6;
            }
        }
    }
}
