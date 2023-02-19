using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSpellSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _grabSpell;
    [SerializeField] private float spawnDistance = 10f;
    private Vector3 spawnPos;
    private bool isCasting;
    private PlayerMovement _playerMovement;
    
    void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        spawnPos = transform.position + transform.up + (transform.right * 2) + transform.forward * spawnDistance;

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
        _playerMovement.enabled = false;
        yield return new WaitForSeconds(3);
        Debug.Log("Grab Spell delay ended");
        _playerMovement.enabled = true;
        isCasting = false;
    }
}
