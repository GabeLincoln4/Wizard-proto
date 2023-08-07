using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticlePosition : MonoBehaviour
{
    void Update()
    {
        transform.localEulerAngles = new Vector3(transform.eulerAngles.x, 0, 0);
    }
}
