using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpell : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Attack Spell Instantiated");
    }

    private void Update()
    {
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 0.5f);
    }
}
