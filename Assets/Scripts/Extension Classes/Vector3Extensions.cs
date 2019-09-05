using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Tutorial by Jason Weinman, written by MT
public static class Vector3Extensions
{
    public static Vector3 With(this Vector3 original, float? x = null, float ? y = null, float ? z = null){

        // Was X set? if not use original value, if so use the set value in the constructor
        return new Vector3(x ?? original.x, y ?? original.y, z?? original.z);
    }

    public static Vector3 Flat (this Vector3 original){
        return new Vector3 (original.x, 0, original.z);
    }

    public static Vector3 DirectionTo (this Vector3 source, Vector3 destination){
        return (destination - source).normalized;
    }
}
