using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlaneGenerator : MonoBehaviour
{
    [Header("Water Settings")]
    public float size = 1f;
    public int gridSize = 1;

    private MeshFilter filter;

    void Start()
    {
        filter = GetComponent<MeshFilter>();
        filter.mesh = GenerateMesh();
    }

    private Mesh GenerateMesh()
    {
        Mesh mesh = new Mesh();
        var verticies = new List<Vector3>();
        var normals = new List<Vector3>();
        var uvs = new List<Vector2>();
        var triangles = new List<int>();
        var vertCount = gridSize + 1;
        for (int x = 0; x < gridSize + 1; x++)
        {
            for (int y = 0; y < gridSize + 1; y++)
            {
                verticies.Add(new Vector3(-size * 0.5f + size * ( x / (float)gridSize), 0, -size * 0.5f + size * ( y / (float)gridSize)));
                normals.Add(Vector3.up);
                uvs.Add(new Vector2(x / (float)gridSize, y / (float)gridSize));
            }
        }
        for (int i = 0; i < vertCount * vertCount - vertCount; i++)
        {
            if((i + 1) % vertCount != 0)
            {
                triangles.AddRange(new List<int>()
                {
                    i + 1 + vertCount,
                    i + vertCount,
                    i, i,
                    i + 1,
                    i + vertCount + 1
                });
            }           
        }
        mesh.SetVertices(verticies);
        mesh.SetNormals(normals);
        mesh.SetUVs(0, uvs);
        mesh.SetTriangles(triangles, 0);
        return mesh;
    }
}
