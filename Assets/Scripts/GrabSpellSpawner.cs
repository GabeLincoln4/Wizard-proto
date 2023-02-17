using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSpellSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _grabSpell;
    [SerializeField] private float spawnDistance = 10f;
    private Vector3 spawnPos;
    private bool isCasting;
    
    

    void Awake()
    {
        
        
    }

    void Update()
    {
        spawnPos = transform.position + transform.forward * spawnDistance;

        if (Input.GetButton("Jump") && !isCasting)
        {
            Instantiate(_grabSpell, spawnPos, transform.rotation);
            isCasting = true;
            StartCoroutine(GrabSpellCoroutine());
        }   
    }

    IEnumerator GrabSpellCoroutine()
    {
        Debug.Log("Grab Spell delay started");
        yield return new WaitForSeconds(3);
        Debug.Log("Grab Spell delay ended");
        isCasting = false;
    }
}
