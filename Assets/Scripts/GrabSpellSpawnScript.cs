using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSpellSpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject _grabSpell;
    [SerializeField] private GameObject _player;
    [SerializeField] private float distance;
    private PlayerMovement _playerMovement;
    
    void Awake()
    {
        _playerMovement = _player.GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            CastGrab();
        }
    }

    public void CastGrab()
    {
        _playerMovement._speed = 0f;
        Instantiate(_grabSpell, transform.position + transform.forward * distance, transform.rotation);
    }
}
