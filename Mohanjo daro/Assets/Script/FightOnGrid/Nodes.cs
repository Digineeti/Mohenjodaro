using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes : MonoBehaviour
{
    public List<Nodes> neighbours;
    public int x;
    public int y;

    public Nodes()
    {
        neighbours = new List<Nodes>();
    }

    public float DistanceTo(Nodes n)
    {
        if (n == null)
        {
            Debug.LogError("WTF?");
        }

        return Vector2.Distance(
            new Vector2(x, y),
            new Vector2(n.x, n.y)
            );
    }
}
