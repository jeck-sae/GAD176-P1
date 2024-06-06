using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Extensions
{
    public static Vector2Int toInt(this Vector2 v2)
        => new Vector2Int((int)v2.x, (int)v2.y);

    public static Vector3 XY(this Vector3 vector)
        => new Vector3(vector.x, vector.y);

}
