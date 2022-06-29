using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // See Node class in editor when serialized Node variables.
public class Node // pure class. Not inherited from other class.
{
    public Vector2Int coordinates; // Pure data class. No methods.
    public bool isWalkable;
    public bool isExplored;
    public bool isPath;
    public Node connectedTo;

    public Node(Vector2Int coordinates, bool isWalkable){ // constructor.
        this.coordinates = coordinates;
        this.isWalkable = isWalkable;
    }
}
