using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JPSNode
{

    public Vector3 pos;
    public JPSNode parent;
    public List<Vector3> directions;
    public float priority = 0;
    public float G;
    public float H;
    public Vector3 parentPos;
    public float parentF;

    public JPSNode(Vector3 newPos, JPSNode par, Vector3 dest)
    {
        pos = newPos;
        parent = par;
        int dx = (int)Mathf.Abs(dest.x - pos.x);
        int dz = (int)Mathf.Abs(dest.z - pos.z);
        H = (dx + dz) + ((Mathf.Sqrt(2) - 2) * Mathf.Min(dx, dz));
            // Chebyshev Mathf.Max(Mathf.Abs(dest.x - pos.x), Mathf.Abs(dest.z - pos.z));
        directions = new List<Vector3>();
        if (parent != null)
        {
            parentPos = parent.pos;
            parentF = parent.priority;
            G += parent.G
                + (Mathf.Sqrt(Mathf.Pow(parent.pos.x - pos.x, 2) + Mathf.Pow(parent.pos .z - pos.z, 2)));
        }
        priority = G + H;
    }
    
    public void AddDirection(Vector3 dir)
    {
        if (!directions.Contains(dir))
        {
            directions.Add(dir);
        }
    }
}