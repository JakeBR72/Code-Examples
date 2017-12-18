using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{

    public Vector3 destination; //temporary

    List<JPS> ai = new List<JPS>();
    private int currentAI = -1;
    private int nextAI;
    ObjectGrid grid;
    bool start;

    void Start()
    {
        grid = GameObject.Find("_ObjectGrid").GetComponent<ObjectGrid>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            start = true;
        }
        if (start && grid.DoneLoading && ai.Count > 0)
        {
            if (currentAI == -1)
            {
                for (int i = 0; i < ai.Count; i++)
                {
                    if (ai[i].destination == new Vector3(-1, -1, -1))
                    {
                        destination = new Vector3(grid.MapSizeX / 2, 0, grid.MapSizeY / 2);
                        ai[i].destination = destination;
                    }
                    if (ai[i].waiting)
                    {
                        ai[i].waiting = false;
                        ai[i].Search();
                        currentAI = i;
                    }
                }
            }
            else if (!ai[currentAI].searching && ai[currentAI].searched)
            {
                currentAI = -1;
            }
        }
    }
    public void Add(JPS newJPS)
    {
        ai.Add(newJPS);
    }
}
