using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueCaster : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    [SerializeField] LeverManager _leverManager;

    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        // if (_enemySpellSpawner._readyToFire == true)
        // {
        //     Debug.Log("Caster is ready to fire"); 
        //     _meshRenderer.material.SetColor("_Color", Color.red);
        //     StartCoroutine(TurnRogueCasterBlue());
        // }
    }
}
