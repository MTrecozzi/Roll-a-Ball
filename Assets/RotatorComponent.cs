using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorComponent : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(14, 30, 45) * Time.deltaTime);
    }
}
