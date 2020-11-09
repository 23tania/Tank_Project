using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    void Update()
    {
        // Since we always want it to rotate we multiply by computer time: deltaTime
        // Looks at itself:
        transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime, Space.Self);
        // Looks at the world reference space:
        transform.Rotate(new Vector3(0, 70, 0) * Time.deltaTime, Space.World);
        // Our box will be rotating
    }
}
