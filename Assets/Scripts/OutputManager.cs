using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Lightning Strike");
        }
    }
}
