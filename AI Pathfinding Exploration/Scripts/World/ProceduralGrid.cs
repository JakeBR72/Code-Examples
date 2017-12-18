using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(BoxCollider))]
public class ProceduralGrid : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    Vector2[] uvs;
    Vector2[,] textures;
    Color[] colors;

    //Grid settings
    public Texture2D texture;
    public int AtlasSize = 1;
    public float cellsize = 1;
    private Vector3 gridOffset;
    private int gridSizeX = 1;
    private int gridSizeY = 1;
    public Shader shader;
    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    void Start()
    {
        StreamReader theReader = new StreamReader(MapController.map, Encoding.Default);
        string line = theReader.ReadLine();
        string[] exploded = line.Split(',');
        gridSizeX = int.Parse(exploded[0]);
        gridSizeY = int.Parse(exploded[1]);
        MakeDiscreteProceduralGrid();
        UpdateMesh();
    }

    private void MakeDiscreteProceduralGrid()
    {
        //set array sizes
        vertices = new Vector3[4 * gridSizeX * gridSizeY];
        triangles = new int[6 * gridSizeX * gridSizeY];
        uvs = new Vector2[vertices.Length];
        colors = new Color[vertices.Length];
        //set tracker ints
        int v = 0;
        int t = 0;        


        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 cellOffset = new Vector3(x * cellsize, 0, y * cellsize);
                //populate vertices and triangles
                vertices[v] = new Vector3(0, 0, 0) + gridOffset + cellOffset;
                vertices[v + 1] = new Vector3(0, 0, cellsize) + gridOffset + cellOffset;
                vertices[v + 2] = new Vector3(cellsize, 0, 0) + gridOffset + cellOffset;
                vertices[v + 3] = new Vector3(cellsize, 0, cellsize) + gridOffset + cellOffset;

                triangles[t] = v;
                triangles[t + 1] = triangles[t + 4] = v + 1;
                triangles[t + 2] = triangles[t + 3] = v + 2;
                triangles[t + 5] = v + 3;

                //Apply correct texture (for now just iterate over entire atlas
                float texX = 0;
                float texY = 0;

                uvs[v] = new Vector2(texX / AtlasSize, texY / AtlasSize);
                uvs[v + 1] = new Vector2((texX + 1) / AtlasSize, texY / AtlasSize);
                uvs[v + 2] = new Vector2(texX / AtlasSize, (texY + 1) / AtlasSize);
                uvs[v + 3] = new Vector2((texX + 1) / AtlasSize, (texY + 1) / AtlasSize);
                colors[v] = Color.white;
                colors[v + 1] = Color.white;
                colors[v + 2] = Color.white;
                colors[v + 3] = Color.white;


                //increment vertice/triangle indices
                v += 4;
                t += 6;
            }
        }
    }

    private void UpdateMesh()
    {
        Material mat = GetComponent<MeshRenderer>().material;
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.colors = colors;
        mat.mainTexture = texture;
        mat.SetFloat("_Glossiness", 0f);
        mat.shader = shader;
        mesh.RecalculateNormals();
        GetComponent<BoxCollider>().size = new Vector3(gridSizeX, 0, gridSizeY);
        GetComponent<BoxCollider>().center = new Vector3((gridSizeX / 2), 0, (gridSizeY / 2));
    }

    public void UpdateUV(int posX, int posY, int newTexX, int newTexY)
    {
        if ((posX < gridSizeX && posY < gridSizeY && posX >= 0 && posY >= 0) && (newTexX < AtlasSize && newTexX >= 0 && newTexY < AtlasSize && newTexY >= 0))
        {
            int currentUV = (posX * gridSizeY + posY) * 4;
            float texX = newTexX % AtlasSize;
            float texY = newTexY % AtlasSize;
            uvs[currentUV] = new Vector2(texX / AtlasSize, texY / AtlasSize);
            uvs[currentUV + 1] = new Vector2((texX + 1) / AtlasSize, texY / AtlasSize);
            uvs[currentUV + 2] = new Vector2(texX / AtlasSize, (texY + 1) / AtlasSize);
            uvs[currentUV + 3] = new Vector2((texX + 1) / AtlasSize, (texY + 1) / AtlasSize);
            UpdateMesh();
        }
    }

    public void HighlightUV(int posX, int posY, Color newColor)
    {
        if ((posX < gridSizeX && posY < gridSizeY && posX >= 0 && posY >= 0))
        {
            int currentUV = (posX * gridSizeY + posY) * 4;
            colors[currentUV] = newColor;
            colors[currentUV + 1] = newColor;
            colors[currentUV + 2] = newColor;
            colors[currentUV + 3] = newColor;
            UpdateMesh();
        }
    }
}
