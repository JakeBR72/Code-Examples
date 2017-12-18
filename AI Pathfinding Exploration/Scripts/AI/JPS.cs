using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPS : MonoBehaviour
{
    public bool DebugMode;
    public bool destinationFound;
    public bool navigating;
    public bool searching;
    public bool waiting;
    public bool searched;
    private int placeInPath;

    public Vector3 destination;
    public  Vector3 oldDestination;
    public Vector3 startingPosition;

    public List<JPSNode> open = new List<JPSNode>();
    public List<JPSNode> closed = new List<JPSNode>();
    public List<JPSNode> path = new List<JPSNode>();

    private JPSNode currentNode;
    private ObjectGrid grid;
    private ProceduralGrid floor; // not needed unless using debug feature
    AIManager manager;


    void Start()
    {
        grid = GameObject.Find("_ObjectGrid").GetComponent<ObjectGrid>();
        floor = GameObject.Find("_FloorGrid").GetComponent<ProceduralGrid>(); //remove with removal of debugmode
        GameObject.Find("_AI").GetComponent<AIManager>().Add(this);
        startingPosition = new Vector3((int)transform.position.x, (int)transform.position.y, (int)transform.position.z);
        destination = new Vector3(10,0,10);
    }

    void Update()
    {
        if(oldDestination != destination)
        {
            oldDestination = destination;
            searched = false;
        }
        if(!searched && transform.position != destination)
        {
            waiting = true;
        }
        if (navigating)
        {
            Navigate();
        }
    }

    public void Search()
    {
        searched = true;
        //Reset Debug floor
        if (DebugMode)
        {
            foreach (JPSNode node in closed)
            {
                floor.HighlightUV((int)node.pos.x, (int)node.pos.z, Color.white);

            }
            foreach (JPSNode node in path)
            {
                floor.HighlightUV((int)node.pos.x, (int)node.pos.z, Color.white);
            }
        }
        //Prime search values
        searching = true;
        destinationFound = false;
        placeInPath = 0;
        open.Clear();
        closed.Clear();
        path.Clear();
        currentNode = new JPSNode(startingPosition, null, destination);

        //First node must have all directions
        currentNode.AddDirection(new Vector3(1, 0, 1));
        currentNode.AddDirection(new Vector3(1, 0, -1));
        currentNode.AddDirection(new Vector3(-1, 0, 1));
        currentNode.AddDirection(new Vector3(-1, 0, -1));
        currentNode.AddDirection(new Vector3(1, 0, 0));
        currentNode.AddDirection(new Vector3(-1, 0, 0));
        currentNode.AddDirection(new Vector3(0, 0, 1));
        currentNode.AddDirection(new Vector3(0, 0, -1));
        AddToOpen(currentNode);

        //begin main search loop
        while (!destinationFound && open.Count > 0)
        {
            currentNode = open[0];
            for (int i = 0; i < open.Count; i++)
            {
                if (currentNode.priority > open[i].priority)
                {
                    currentNode = open[i];
                }
            }

            open.Remove(currentNode);
            closed.Add(currentNode);
            for (int i = 0; i < currentNode.directions.Count; i++)
            {
                if (currentNode.directions[i].magnitude == 1)
                {
                    FindNodes(currentNode.pos + currentNode.directions[i], currentNode, currentNode.directions[i], true);
                }
                else
                {
                    FindNodes(currentNode.pos + currentNode.directions[i], currentNode, currentNode.directions[i], false);
                }
            }
        }
        //Prepare path for unit
        currentNode = null;
        for (int i = 0; i < closed.Count; i++)
        {
            if (closed[i].pos == destination)
            {
                currentNode = closed[i];
            }
        }
        if (DebugMode)
            Debug.Log("Path Cost: " + currentNode.priority);
        if (currentNode != null)
        {
            while (currentNode.parent != null)
            {
                if (DebugMode)
                    floor.HighlightUV((int)currentNode.pos.x, (int)currentNode.pos.z, Color.green);
                path.Add(currentNode);
                currentNode = currentNode.parent;
            }
            path.Reverse();
            if (destinationFound)
            {
                navigating = true;
            }
        }
        searching = false;
    }

    private void Navigate()
    {
        if (placeInPath < path.Count)
        {
            if (transform.position != path[placeInPath].pos)
            {
                transform.LookAt(path[placeInPath].pos);
                transform.position = Vector3.MoveTowards(transform.position, path[placeInPath].pos, 5 * Time.deltaTime);
            }
            else
            {
                placeInPath++;
            }
        }
        if (placeInPath >= path.Count)
        {
            navigating = false;
            //Reverse dest/start for now
            Vector3 temp = destination;
            destination = startingPosition;
            startingPosition = temp;
            //Remove this later^
        }
    }

    private bool FindNodes(Vector3 position, JPSNode parent, Vector3 direction, bool core)
    {
        Vector3 currentPosition = position;

        while (IsInBounds(currentPosition) && !ObjectAt(currentPosition))
        {
            if (currentPosition == destination)
            {
                JPSNode destNode = new JPSNode(currentPosition, parent, destination);
                closed.Add(destNode);
                destinationFound = true;
                return true;
            }
            if (direction.magnitude > 1) // do diagonal stuff
            {
                bool addDiag = false;
                JPSNode diagNode = new JPSNode(currentPosition, parent, destination);
                if (!ObjectAt(currentPosition + new Vector3(-direction.x, 0, 0))
                    || !ObjectAt(currentPosition + new Vector3(0, 0, -direction.z)))
                {
                    if (!ObjectAt(currentPosition + new Vector3(-direction.x, 0, 0)) && ObjectAt(currentPosition + new Vector3(0, 0, -direction.z)))
                    {
                        diagNode.AddDirection(new Vector3(direction.x, 0, -direction.z));
                        addDiag = true;
                    }
                    else if (!ObjectAt(currentPosition + new Vector3(0, 0, -direction.z)) && ObjectAt(currentPosition + new Vector3(-direction.x, 0, 0)))
                    {
                        diagNode.AddDirection(new Vector3(-direction.x, 0, direction.z));
                        addDiag = true;
                    }
                    if (FindNodes(currentPosition + new Vector3(direction.x, 0, 0), diagNode, new Vector3(direction.x, 0, 0), false))
                    {
                        diagNode.AddDirection(new Vector3(direction.x, 0, 0));
                        addDiag = true;
                    }
                    if (FindNodes(currentPosition + new Vector3(0, 0, direction.z), diagNode, new Vector3(0, 0, direction.z), false))
                    {
                        diagNode.AddDirection(new Vector3(0, 0, direction.z));
                        addDiag = true;
                    }
                    if (addDiag)
                    {
                        AddToOpen(diagNode);
                    }
                }
                else
                {
                    return false;
                }
            }
            else // do horizontal/vertical stuff
            {

                bool addNode = false;
                JPSNode newNode = new JPSNode(currentPosition, parent, destination);
                newNode.AddDirection(direction);
                if (currentPosition == destination)
                {
                    closed.Add(newNode);
                    destinationFound = true;
                    return true;
                }
                bool horizVert = (Mathf.Abs(direction.x) == 1) ? true : false;
                if (!ObjectAt(currentPosition + direction)
                    && ObjectAt(currentPosition + ((horizVert) ? new Vector3(0, 0, 1) : new Vector3(1, 0, 0)))
                    && !ObjectAt(currentPosition + ((horizVert) ? new Vector3(direction.x, 0, 1) : new Vector3(1, 0, direction.z))))
                {
                    newNode.AddDirection((horizVert) ? new Vector3(direction.x, 0, 1) : new Vector3(1, 0, direction.z));
                    addNode = true;
                }
                if (!ObjectAt(currentPosition + direction)
                     && ObjectAt(currentPosition + ((horizVert) ? new Vector3(0, 0, -1) : new Vector3(-1, 0, 0)))
                    && !ObjectAt(currentPosition + ((horizVert) ? new Vector3(direction.x, 0, -1) : new Vector3(-1, 0, direction.z))))
                {
                    newNode.AddDirection((horizVert) ? new Vector3(direction.x, 0, -1) : new Vector3(-1, 0, direction.z));
                    addNode = true;
                }
                if (addNode)
                {
                    if (core)
                        AddToOpen(newNode);
                    return true;
                }

            }
            currentPosition += direction;
        }
        return false;
    }

    private void AddToOpen(JPSNode newNode)
    {
        for (int i = 0; i < open.Count; i++)
        {
            if (open[i].pos == newNode.pos)
            {
                return;
            }
        }
        for (int i = 0; i < closed.Count; i++)
        {
            if (closed[i].pos == newNode.pos)
            {
                return;
            }
        }
        /*
        if (newNode.pos == new Vector3(2, 0, 1)  || newNode.pos == new Vector3(2, 0, 3))
        {
            Debug.Log(newNode.pos + "F: " + newNode.priority + " H:" + newNode.H);
        }
        */
        if (DebugMode)
            floor.HighlightUV((int)newNode.pos.x, (int)newNode.pos.z, Color.blue);
        open.Add(newNode);
    }

    private bool ObjectAt(Vector3 pos)
    {
        if (IsInBounds(pos))
        {
            return grid.objects[(int)pos.x, (int)pos.z] != null;
        }
        return true;
    }

    private bool IsInBounds(Vector3 pos)
    {
        return (pos.x < grid.MapSizeX && pos.x >= 0 && pos.z < grid.MapSizeY && pos.z >= 0);
    }
}
