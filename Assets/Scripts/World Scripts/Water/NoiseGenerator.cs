using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseGenerator : MonoBehaviour
{

    [Header("Properties")]
    public float power = 3f;
    public float scale = 1f;
    public float timeScale = 1f;

    private float xOffSet;
    private float yOffSet;
    private MeshFilter meshFilter;

    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        MakeNoise(); 
    }

    // Update is called once per frame
    void Update()
    {
        MakeNoise();
        xOffSet += Time.deltaTime * timeScale;
        yOffSet += Time.deltaTime * timeScale;
    }

    private void MakeNoise()
    {
        Vector3[] verticies = meshFilter.mesh.vertices;
        for (int i = 0; i < verticies.Length; i++)
        {
            verticies[i].y = CalculateHeight(verticies[i].x, verticies[i].z) * power;
        }
        meshFilter.mesh.vertices = verticies;
    }

    private float CalculateHeight(float x, float y)
    {
        float xCord = x * scale + xOffSet;
        float yCord = y * scale + yOffSet;
        return Mathf.PerlinNoise(xCord, yCord);
    }
}
