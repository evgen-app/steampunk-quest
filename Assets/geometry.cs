using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geometry : MonoBehaviour
{
    public bool intersects(float ax, float ay, float ax1, float ay1, float bx, float by, float bx1, float by1)
    {
        return (ay < by1 || ay1 > by || ax1 < bx || ax > bx1);
    }
}
