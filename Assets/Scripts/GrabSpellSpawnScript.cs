using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSpellSpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject _grabSpell;
    [SerializeField] private float distance = 1;
    
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            CastGrab();
        }
    }

    public void CastGrab()
    {
        Instantiate(_grabSpell, transform.position + transform.forward * distance, transform.rotation);
    }
}
