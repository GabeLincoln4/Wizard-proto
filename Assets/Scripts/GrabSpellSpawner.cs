using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSpellSpawner : MonoBehaviour
{
    public bool _isCasting = false;
    public GameObject _grabSpell;
    public bool _isCaught = false;

    [SerializeField] private float spawnDistance = 10f;
    [SerializeField] private float _grabSpellDuration = 2.5f;
    private Vector3 spawnPos;
    private PlayerMovement _playerMovement;
    
    
    void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        _isCaught = _grabSpell.GetComponent<GrabSpellMovement>()._spellCaught;
        spawnPos = transform.position + transform.up + (transform.right * 2) + transform.forward * spawnDistance;

        if (Input.GetButton("Jump") && !_isCasting)
        {
            Instantiate(_grabSpell, spawnPos, transform.rotation);
            _isCasting = true;
            DetectCaughtSpell();
            StartCoroutine(GrabSpellCoroutine());
        }   

        
    }

    IEnumerator GrabSpellCoroutine()
    {
        Debug.Log("Grab Spell delay started");
        _playerMovement.enabled = false;
        yield return new WaitForSeconds(_grabSpellDuration);
        Debug.Log("Grab Spell delay ended");
        _playerMovement.enabled = true;
        _isCasting = false;
    }

    private void DetectCaughtSpell()
    {   
        var capturedSpell = _grabSpell.GetComponent<GrabSpellMovement>()._capturedSpell;
        if (capturedSpell != null)
        {
            _isCaught = true;
        }
    }
}
