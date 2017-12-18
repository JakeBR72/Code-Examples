using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;

public class ObjectGrid : MonoBehaviour
{
    public bool DoneLoading;
    public int MapSizeX = 0;
    public int MapSizeY = 0;
    public GameObject[,] objects;
    public GameObject cube;

    void Start()
    {
        StreamReader theReader = new StreamReader(MapController.map, Encoding.Default);
        string line = theReader.ReadLine();
        string[] exploded = line.Split(',');
        MapSizeX = int.Parse(exploded[0]);
        MapSizeY = int.Parse(exploded[1]);
        objects = new GameObject[MapSizeX, MapSizeY];
        line = theReader.ReadLine();
        exploded = line.Split(',');
        for (int y = MapSizeY - 1; y >= 0; y--)
        {
            for (int x = 0; x < MapSizeX; x++)
            {
                if (int.Parse(exploded[x]) != 0)
                {
                    
                        //do other things with value
                        objects[x, y] = Instantiate(cube, new Vector3(x, 0, y), new Quaternion(0, 0, 0, 0), this.transform);
                }
            }
            if (y > 0)
            {
                line = theReader.ReadLine();
                exploded = line.Split(',');
            }
        }
        DoneLoading = true;
    }

    void Update()
    {

    }
}